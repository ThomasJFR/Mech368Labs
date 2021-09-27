using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Mech368Lab1E7
{
    public partial class FormL1E7 : Form
    {
        private class Action
        {
            public string id { get; set;  }
            public int[] key { get; set; }
            public int duration { get; set; }
            public Action[]? branches { get; set; }
        }
        Action baseAction;
        Action action;
 
        private ConcurrentQueue<Int32> dataQueue;


        public FormL1E7()
        {
            InitializeComponent();
            InitializeListeners();

            this.dataQueue = new ConcurrentQueue<Int32>();
        }

        private void InitializeListeners()
        {
            // Component Bindings
            processInput.Click += this.ProcessInput;

            // Timer Bindings
            //toggleButtonUpdateTimer.Tick += this.UpdateSerialToggleButton;
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("C:/Users/thoma/UBC/Mech 368/Labs/Lab1/Mech368Lab1E7/Gestures.JSON");
            this.baseAction = JsonSerializer.Deserialize<Action>(sr.ReadToEnd());
            this.action = this.baseAction;
            sr.Close();
            sr.Dispose();
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ProcessInput(object sender, EventArgs e)
        {
            int ax = textBoxAx.TextLength != 0 ? Convert.ToInt32(textBoxAx.Text) : 0,
                ay = textBoxAy.TextLength != 0 ? Convert.ToInt32(textBoxAy.Text) : 0,
                az = textBoxAz.TextLength != 0 ? Convert.ToInt32(textBoxAz.Text) : 0;
            textBoxDatastreamOutput.AppendText($"({ax}, {ay}, {az}), ");

            this.action = this.ProcessGesture(ax, ay, az);
            stateBox.Text = this.action.id;
        }

        int counter = 0;
        private Action ProcessGesture(int ax, int ay, int az)
        {
            if (this.action.branches != null)
            {
                Action next = Array.Find(this.action.branches, branch => (
                    ax == branch.key[0]
                    && ay == branch.key[1]
                    && az == branch.key[2]));

                if (next != null)
                {
                    counter = next.duration;
                    return next;
                }
            }
            if (counter > 0)
            {
                counter--;
                return this.action;
            }
            else
                return this.baseAction;
            
            
        }
    }
}
