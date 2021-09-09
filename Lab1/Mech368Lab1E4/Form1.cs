using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Mech368Lab1E4
{
    public partial class FormL1E4 : Form
    {
        private static System.IO.Ports.SerialPort port;  // Singleton instance, don't want multiples

        public FormL1E4()
        {
            InitializeComponent();

            FormL1E4.port = GenerateSerialPort();
        }

        private static SerialPort GenerateSerialPort()
        {
            port = new SerialPort();

            port.PortName = "COMX";
            port.BaudRate = 9600;
            port.Parity = false;
            port.DataBits = 8;
            port.StopBits = 1;
            port.Handshake = false;

            return port;
        }

    }
}
