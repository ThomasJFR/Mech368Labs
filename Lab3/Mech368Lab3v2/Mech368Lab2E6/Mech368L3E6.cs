using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mech368Lab2E6
{
    public partial class Mech368L3E6 : Form
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
        private Series loadvoltages;
        private Series loads;

        private double load = 0;
        private double tare = double.NaN;

        public Mech368L3E6()
        {
            InitializeComponent();
            InitializeListeners();

            this.streamBuffer = new ConcurrentQueue<int>();
            this.port = this.BindSerial();
            this.port.Write(((char)AD2Token.STREAM_REQUEST_THERMISTOR).ToString());
            
            this.loadvoltages = new Series("Load Voltages");
            this.loadvoltages.ChartType = SeriesChartType.FastLine;
            this.loadvoltages.YValueType = ChartValueType.Double;
            //plot.Series.Add(this.loadvoltages);

            this.loads = new Series("Load");
            this.loads.ChartType = SeriesChartType.FastLine;
            this.loads.YValueType = ChartValueType.Double;
            plot.Series.Add(this.loads);
            
            //this.tareBtn.Visible = false;
            //this.stabilityLabel.Visible = false;
            //this.loadTB.Visible = false;
            //this.label3.Visible = false;
            //this.label4.Visible = false;
        }

        private void InitializeListeners()
        {
            this.filepathTB.Click            += this.ConfigureOutputStream;
            this.savetofileCB.CheckedChanged += this.ToggleFilewriter;
            this.processLoop.Tick            += this.ProcessDatastream;
            this.processLoop.Tick            += this.DetectStability;
            this.tareBtn.Click               += this.SetTare;
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


                    double discretized = signal / ((double)(2 << 9));
                    int nextVoltage = (int) (discretized * 3600);
                    EnqueueCircular(this.circularBuffer, nextVoltage, 50);
                    int avgVoltage = AverageQueue(this.circularBuffer);

                    voltageTB.Text    = nextVoltage.ToString();
                    voltageAvgTB.Text = avgVoltage.ToString();//  avgVoltage.ToString();
                    this.loadvoltages.Points.AddY(nextVoltage);

                    double nextLoad = avgVoltage * -0.9906;
                    if (double.IsNaN(this.tare))
                        this.tare = nextLoad;
                    nextLoad -= tare;
                    loadTB.Text = nextLoad.ToString();
                    this.loads.Points.AddY(load);

                    if (this.streamWriter != null)
                        this.streamWriter.WriteLine(
                            $"{DateTime.Now.ToString("hh.mm.ss.ffffff")}, "
                            + $"{nextVoltage}, "
                            + $"{avgVoltage}, "
                            + nextLoad.ToString("0.##"));
                    
                    this.load = nextLoad;
                    signal = 0;
                    continue;
                }
                else if (signal == -1)  // Haven't captured a packet header
                    continue;
                else  // Assemble bytes
                    signal = (signal << 5) + next;
            }
        }

        private void DetectStability(object sender, EventArgs e)
        {
            double SumSquaresQueue(Queue<int> queue)
            {
                float summed = 0;
                foreach (int val in queue)
                    summed += val * val;
                return summed;
            }

            double AverageQueue(Queue<int> queue, int offset = 0)
            {
                float avg = 0;
                foreach (int val in queue)
                    avg += val - offset;
                avg /= (float)queue.Count;
                return avg;
            }

            double sum = SumSquaresQueue(this.circularBuffer);
            double mean = AverageQueue(this.circularBuffer);
            double stdev = Math.Sqrt(sum / ((double)this.circularBuffer.Count) - mean * mean);

            //this.filepathTB.Text = stdev.ToString();
            this.stabilityLabel.Text = stdev < 10 ? "STABLE" : "UNSTABLE";
        }

        private void SetTare(object sender, EventArgs e)
        {
            this.tare = this.load + this.tare;
        }
    }
}

