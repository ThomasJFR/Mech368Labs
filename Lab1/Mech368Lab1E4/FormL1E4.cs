using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Concurrent;

namespace Mech368Lab1E4
{

    public partial class FormL1E4 : Form
    {
        const string ACCELEROMETER_STREAM_REQUEST = "A";

        private SerialPort port;
        private string streamBuffer;
        private ConcurrentQueue<Int32> dataQueue;

        public FormL1E4()
        {
            InitializeComponent();

            // this.streamBuffer = "";  // Empty stream buffer
            this.dataQueue = new ConcurrentQueue<Int32>();
        }

        private void FormL1E4_Load(object _, EventArgs e)
        {
            if (this.LoadAvailableSerialPorts())
                this.ConfigureSerialPort(comboBoxCOMPorts.SelectedItem.ToString());

            datastreamToggleButton.Click             += this.ToggleDatastream;
            comboBoxCOMPorts.SelectedIndexChanged += this.PortRebind;
            streamProcessingTimer.Tick            += this.ProcessDatastream;
            toggleButtonUpdateTimer.Tick          += this.UpdateSerialToggleButton;

            streamProcessingTimer.Enabled = true;
            toggleButtonUpdateTimer.Enabled = true;
        }

        private SerialPort ConfigureSerialPort(string portname)
        {
            SerialPort _port = new SerialPort
            {
                PortName  = portname,
                BaudRate  = 9600,
                Parity    = Parity.None,
                DataBits  = sizeof(byte),
                StopBits  = StopBits.One,
                Handshake = Handshake.None
            };

            _port.DataReceived += this.CaptureBytestream;  // String buffer

            return _port;
        }

        private void OpenDatastream()
        {
            this.port.Open();
            this.port.Write(ACCELEROMETER_STREAM_REQUEST);
        }

        private void CloseDatastream()
        {
            this.port.Close();
            this.port.Dispose();
        }

        private void ToggleDatastream(object sender, EventArgs e)
        {
            if (this.port is null)
                return;

            if (this.port.IsOpen)
                this.CloseDatastream();
            else
                this.OpenDatastream();
        }

        private void PortRebind(object sender, EventArgs e)
        {
            this.CloseDatastream();
            this.ConfigureSerialPort(comboBoxCOMPorts.SelectedItem.ToString());
        }

        private void ProcessDatastream(object sender, EventArgs e)
        {
            if (this.port is null)
                return;

            if (this.port.IsOpen)
                textBoxBytesToRead.Text = this.port.BytesToRead.ToString();

            // STRING BUFFER IMPLEMENTATION
            /* 
            textBoxBufferLength.Text = this.streamBuffer.Length.ToString();
            textBoxDatastreamOutput.AppendText(this.streamBuffer);
            this.streamBuffer = "";
            */

            // CONCURRENT-QUEUE BUFFER IMPLEMENTATION
            textBoxBufferLength.Text = this.dataQueue.Count.ToString();
            while (this.dataQueue.TryDequeue(out int next))
                textBoxDatastreamOutput.AppendText(next.ToString("X"));

        }

        private bool LoadAvailableSerialPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            int nPorts = ports.Length;

            if (nPorts == 0)
            {
                comboBoxCOMPorts.Items.Clear();
                datastreamToggleButton.Text = "No COM ports detected!";
                return false;
            }
            else
            {
                comboBoxCOMPorts.Items.Clear();
                comboBoxCOMPorts.Items.AddRange(ports);
                comboBoxCOMPorts.SelectedIndex = 0;
                return true;
            }
        }

        private void CaptureBytestream(object sender, EventArgs e)
        {
            int next;  // Byte buffer
            while ((next = this.port.ReadByte()) != -1)
                //this.streamBuffer += next.ToString("X") + ", ";  // String buffer implementation
                this.dataQueue.Enqueue(next);  // ConcurrentQueue buffer implementation
        }

        private void UpdateSerialToggleButton(object sender, EventArgs e)
        {
            if (this.port is null)
                return;

            datastreamToggleButton.Text = 
                (this.port.IsOpen ? "Disconnect" : "Connect") + "Serial";
        }
    }
}
