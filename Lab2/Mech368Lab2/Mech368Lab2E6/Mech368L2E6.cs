using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mech368Lab2E6
{
    public partial class Mech368L2E6 : Form
    {
        enum AD2Token
        {
            PACKET_HEADER = 0xFF,

            STREAM_REQUEST_ACCELEROMETER = 'A',
            STREAM_REQUEST_THERMISTOR    = 'c',

            LED5_ON = '5',
            LED5_OFF = '%'
        }

        private ConcurrentQueue<int> streamBuffer;
        private SerialPort port;
        private StreamWriter streamWriter;
        private Series temperatures;


        public Mech368L2E6()
        {
            InitializeComponent();
            InitializeListeners();

            this.streamBuffer = new ConcurrentQueue<int>();
            this.port = this.BindSerial();
            this.port.Write(((char)AD2Token.STREAM_REQUEST_THERMISTOR).ToString());
            
            this.temperatures = new Series("Temperatures");
            this.temperatures.ChartType = SeriesChartType.FastLine;
            this.temperatures.YValueType = ChartValueType.Double;
            plot.Series.Add(this.temperatures);

        }

        private void InitializeListeners()
        {
            this.filepathTB.Click            += this.ConfigureOutputStream;
            this.savetofileCB.CheckedChanged += this.ToggleFilewriter;
            this.processLoop.Tick            += this.ProcessDatastream;
        }
    

        private SerialPort BindSerial()
        {
            SerialPort p = new SerialPort()
            {
                PortName = "COM3",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            p.DataReceived += this.CaptureDatastream;
            p.Open();
            
            return p;
        }

        private void ConfigureOutputStream(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                filepathTB.Text = sfd.FileName;
        }

        private void ToggleFilewriter(object sender, EventArgs e)
        {
            if (this.streamWriter == null)
                if (this.filepathTB.Text.Length > 0)
                    this.streamWriter = new StreamWriter(this.filepathTB.Text);
                else
                    MessageBox.Show("Invalid filename!");
            else
            {
                this.streamWriter.Close();
                this.streamWriter = null;
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            if (this.port != null && this.port.IsOpen)
                this.port.Close();

            if (this.streamWriter != null)
                this.streamWriter.Close();
        }
        private void CaptureDatastream(object sender, EventArgs e)
        {
            int next;  // Byte buffer
            try
            {
                while ((next = this.port.ReadByte()) != -1)
                    this.streamBuffer.Enqueue(next);  // ConcurrentQueue buffer implementation    
            }
            catch { /*Ignored!*/ }
        }

        Queue<int> circularBuffer = new Queue<int>();
        private void ProcessDatastream(object sender, EventArgs e)
        {
            void EnqueueCircular(Queue<int> queue, int next, int max)
            {
                queue.Enqueue(next);
                if (queue.Count > max)
                    queue.Dequeue();
            }

            int AverageQueue(Queue<int> queue, int offset = 0)
            {
                float avg = 0;
                foreach (int val in queue)
                    avg += val - offset;
                avg /= (float)queue.Count;
                return (int) Math.Round(avg);
            }

            int signal = -1;
            while (this.streamBuffer.TryDequeue(out int next))
            {
                if (next == (int)AD2Token.PACKET_HEADER)
                {
                    if (signal == -1)
                    {
                        signal = 0;
                        continue;
                    }

                    int nextVoltage = signal * (3300 / (2 << 9));
                    EnqueueCircular(this.circularBuffer, nextVoltage, 100);
                    int avgVoltage = AverageQueue(this.circularBuffer);

                    voltageTB.Text    = nextVoltage.ToString();
                    voltageAvgTB.Text = signal.ToString();//  avgVoltage.ToString();

                    double Temperature(int millivoltage)
                    {
                        double B = 3435, T25 = 25 + 273;  // K
                        double R1 = 10;  // kOhms
                        double Rth = R1 * millivoltage / (3300 - millivoltage);  // Rearranged voltage divider expression

                        double T = 1/(1/B * Math.Log(Rth/R1) + 1/T25);
                        return T - 273;
                    }

                    double temperature = Temperature(avgVoltage);
                    tempTB.Text = temperature.ToString("0.#");
                    this.temperatures.Points.AddY(temperature);

                    if (this.streamWriter != null)
                        this.streamWriter.WriteLine(
                            $"{DateTime.Now.ToString("hh.mm.ss.ffffff")}, "
                            + $"{nextVoltage}, "
                            + $"{avgVoltage}, "
                            + temperature.ToString("0.##"));

                    signal = 0;
                    continue;
                }
                else if (signal == -1)  // Haven't captured a packet header
                    continue;
                else  // Assemble bytes
                    signal = (signal << 5) + next;
            }

        }
    }
}

