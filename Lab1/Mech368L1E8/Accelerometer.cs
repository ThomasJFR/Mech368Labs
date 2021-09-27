using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO.Ports;

namespace AccelerometerIO
{
    public struct Acceleration
    {
        public int ax, ay, az;
    }

    public class Accelerometer
    {
        enum DSTokens
        {
            ACCEL_STREAM_REQUEST = 'A',
            ACCEL_PACKET_HEADER = 0xFF,
        }

        enum DSDataTracker
        {
            Unknown = -1,
            Ax = 0,
            Ay,
            Az
        }
        DSDataTracker tracker;

        private SerialPort port;
        private Func<int[]> callback;
        private ConcurrentQueue<byte> streamBuffer;

        public Accelerometer(string comID)
        {
            this.streamBuffer = new ConcurrentQueue<byte>();
            this.tracker = DSDataTracker.Unknown;

            this.port = new SerialPort
            {
                PortName = comID,
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };
            this.port.DataReceived += this.CaptureDatastream;
        }

        public void OpenStream()
        {
            this.port.Open();
            this.port.Write(((char) DSTokens.ACCEL_STREAM_REQUEST).ToString());
        }

        public bool IsOPen()
        {
            return this.port != null && this.port.IsOpen;
        }

        public void CloseStream()
        {
            if (this.port != null)
            {
                if (this.port.IsOpen)
                    this.port.Close();
                this.port.Dispose();
            }
        }

        private void CaptureDatastream(object sender, EventArgs e)
        {
            int next;  // Byte buffer
            try
            {
                while ((next = this.port.ReadByte()) != -1)
                    this.streamBuffer.Enqueue((byte)next);  // ConcurrentQueue buffer implementation    
            }
            catch { /*Ignored!*/ }
        }

        public List<Acceleration> ParseDatastream()
        {
            List<Acceleration> accelerations = new List<Acceleration>();

            Acceleration acceleration = new Acceleration();
            while (this.streamBuffer.TryDequeue(out byte next))
            {
                if (next == (int)DSTokens.ACCEL_PACKET_HEADER)
                {
                    this.tracker = DSDataTracker.Ax;
                    continue;
                }

                switch (this.tracker)
                {
                    case DSDataTracker.Ax:
                        acceleration.ax = next;
                        break;
                    case DSDataTracker.Ay:
                        acceleration.ay = next;
                        break;
                    case DSDataTracker.Az:
                        acceleration.az = next;

                        accelerations.Add(acceleration);
                        acceleration = new Acceleration();
                        break;
                }
                this.tracker++;
            }

            return accelerations;
        }
    }
}
