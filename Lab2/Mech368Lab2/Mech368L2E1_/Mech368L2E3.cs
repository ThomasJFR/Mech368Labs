using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading.Tasks;
namespace Mech368L2E1_
{
    public partial class Mech368L2E3 : Form
    {
        enum AD2Token
        {
            LED_ON  = '5',
            LED_OFF = '%'
        }

        const int MAX_LED_INTERVAL = 3000;
        const int MIN_LED_INTERVAL = 500;
        readonly Color CON  = Color.DarkBlue;
        readonly Color COFF = Color.DarkGray;

        SerialPort port = new SerialPort();

        public Mech368L2E3()
        {
            InitializeComponent();
            InitializeSerial();

            Random generator = new Random();
            ledTimer.Interval = 
                generator.Next(MAX_LED_INTERVAL - MIN_LED_INTERVAL)
                + MIN_LED_INTERVAL + 1;
            ledTimer.Tick += this.LEDOn;
            ledTimer.Tick += (sender, e) =>
                Task.Delay(MIN_LED_INTERVAL).ContinueWith(
                    t => this.LEDOff());
            ledTimer.Enabled = true;
        }

        private void InitializeSerial()
        {
            this.port = new SerialPort("COM3");
            this.port.Open();
        }

        private void LEDOn(object sender, EventArgs e)
        {
            // Write to EXP board
            this.port.Write(((char)AD2Token.LED_ON).ToString());

            // Display on UI
            this.ledButton.BackColor = CON;
        }

        private void LEDOff()
        {
            // Write to EXP board
            this.port.Write(((char)AD2Token.LED_OFF).ToString());

            // Display on UI
            this.ledButton.BackColor = COFF;

        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            if (this.port != null && this.port.IsOpen)
                this.port.Close();
        }
    }
}
