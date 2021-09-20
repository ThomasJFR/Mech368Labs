using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Mech368Lab1E4
{
    public partial class FormL1E6 : Form
    {
        enum DSTokens
        {
            ACCEL_STREAM_REQUEST = 'A',
            ACCEL_PACKET_HEADER  = 0xFF,
        }

        enum AccelComponent
        {
            Ax,
            Ay,
            Az,
            Seeking
        }
        AccelComponent accelComponent = AccelComponent.Seeking;

        private SerialPort port;
        private ConcurrentQueue<Int32> dataQueue;
        private TextBox[] accelComponentDisplays;

        private StreamWriter streamWriter;

        public FormL1E6()
        {
            InitializeComponent();
            InitializeListeners();

            this.dataQueue = new ConcurrentQueue<Int32>();
            this.accelComponentDisplays = new TextBox[] {  // Collect accel display textboxes
                textBoxAx, textBoxAy, textBoxAz            // as array for easy populating!!
            };
        }

        private void InitializeListeners()
        {
            // Component Bindings
            datastreamToggleButton.Click          += this.ToggleDatastream;
            comboBoxCOMPorts.SelectedIndexChanged += this.BindPort;
            buttonSelectFilename.Click            += this.ConfigureOutputStream;
            checkBoxSaveToFile.CheckedChanged     += this.ToggleOutputStream;

            // Timer Bindings
            streamProcessingTimer.Tick            += this.ProcessDatastream;
            toggleButtonUpdateTimer.Tick          += this.UpdateSerialToggleButton;
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            // Populate the combo box
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(this.GetAvailableSerialPorts());
            comboBoxCOMPorts.SelectedIndex = 0;

            // Enable the timers
            streamProcessingTimer.Enabled = true;
            toggleButtonUpdateTimer.Enabled = true;
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseDatastream();
            if (this.streamWriter != null)
                this.streamWriter.Close();
        }

        private SerialPort ConfigureSerialPort(string portname)
        {
            SerialPort _port = new SerialPort
            {
                PortName  = portname,
                BaudRate  = 9600,
                Parity    = Parity.None,
                DataBits  = 8,
                StopBits  = StopBits.One,
                Handshake = Handshake.None
            };

            _port.DataReceived += this.CaptureDatastream;  // String buffer

            return _port;
        }

        private void OpenDatastream()
        {
            this.port.Open();
            this.port.Write(((char)DSTokens.ACCEL_STREAM_REQUEST).ToString());
        }

        private void CloseDatastream()
        {
            if (this.port != null && this.port.IsOpen)
            {
                this.port.Close();
                this.port.Dispose();
            }
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

        private void BindPort(object sender, EventArgs e)
        {
            if (this.port != null && this.port.IsOpen)
                this.CloseDatastream();

            string portID = comboBoxCOMPorts.SelectedItem.ToString();
            this.port = this.ConfigureSerialPort(portID);
        }

        private void CaptureDatastream(object sender, EventArgs e)
        {
            int next;  // Byte buffer
            try
            {
                while ((next = this.port.ReadByte()) != -1)
                    this.dataQueue.Enqueue(next);  // ConcurrentQueue buffer implementation    
            }
            catch { /*Ignored!*/ }
        }

        private void ProcessDatastream(object sender, EventArgs e)
        {
            if (this.port is null)
                return;
            if (this.port.IsOpen)
                textBoxBytesToRead.Text = this.port.BytesToRead.ToString();

            textBoxDatastreamOutput.Clear();
            itemsInQueueTextbox.Text = this.dataQueue.Count.ToString();

            while (this.dataQueue.TryDequeue(out int next))
            {
                // Display the data we just received
                textBoxDatastreamOutput.AppendText($"{next}, ");

                // Process this datapoint
                switch (this.accelComponent)
                {
                    case AccelComponent.Ax:
                    case AccelComponent.Ay:
                    case AccelComponent.Az:
                        this.accelComponentDisplays[((int)this.accelComponent)].Text = next.ToString();
                        if (checkBoxSaveToFile.Checked)
                            this.streamWriter.Write($", {next.ToString()}");

                        this.accelComponent++;
                        break;
                    default:
                        if (next == (int) DSTokens.ACCEL_PACKET_HEADER)
                        {
                            this.accelComponent = AccelComponent.Ax;  // We expect this byte next
                            if (checkBoxSaveToFile.Checked)
                                this.streamWriter.Write("\n" + DateTime.Now.ToString("hh.mm.ss.ffffff"));
                        }
                        continue;
                }
            }

            textBoxBufferLength.Text = textBoxDatastreamOutput.Text.Length.ToString();
        }

        private void ConfigureOutputStream(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                textBoxFilename.Text = sfd.FileName;

            if (textBoxFilename.TextLength != 0)
                checkBoxSaveToFile.Enabled = true;
        }

        private void ToggleOutputStream(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                this.streamWriter = new StreamWriter(textBoxFilename.Text);
            else if (this.streamWriter != null)
                this.streamWriter.Close();
        }

        private string[] GetAvailableSerialPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            int nPorts = ports.Length;
            return ports;

            /*
            if (nPorts == 0)
                datastreamToggleButton.Text = "No COM ports detected!";
            else
            {
                comboBoxCOMPorts.Items.Clear();
                comboBoxCOMPorts.Items.AddRange(ports);
                comboBoxCOMPorts.SelectedIndex = 0;
                return true;
            }
            */
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
