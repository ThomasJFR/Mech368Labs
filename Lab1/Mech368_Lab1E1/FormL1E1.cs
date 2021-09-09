using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mech368_Lab1
{
    public partial class FormL1E1 : Form
    {
        public FormL1E1()
        {
            InitializeComponent();
            InitializeVirtualTrackpad();
        }

        private void InitializeVirtualTrackpad()
        {
            virtTrackpad.MouseMove += this.BindMouseToReadouts;
            virtTrackpad.MouseClick += this.RecordClick;
        }

        private void BindMouseToReadouts(object _, MouseEventArgs e)
        {
            XPosReadout.Text = e.X.ToString("000");
            YPosReadout.Text = e.Y.ToString("000");
        }

        private void RecordClick(object _, MouseEventArgs e)
        {
            mouseClickRecorderBox.AppendText(
                String.Format(
                    "({0}, {1}){2}",
                    e.X,
                    e.Y,
                    Environment.NewLine));
        }
    }
}
