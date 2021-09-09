using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mech368_Lab1E2
{
    public partial class FormL1E2 : Form
    {
        readonly Queue<Int32> dataQueue;  // FIFO

        public FormL1E2()
        {
            InitializeComponent();

            this.dataQueue = new Queue<Int32>();

            enqueueButton.Click += this.Enqueue;
            dequeueButton.Click += this.Dequeue;
            dequeueAverageOperationButton.Click += this.DequeueAverageOperation;

            updateQueueTimer.Tick += this.UpdateQueue;
            this.updateQueueTimer.Enabled = true;
        }

        private void Enqueue(object _, EventArgs e)
        {
            if (enqueueInputBox.TextLength > 0)
                dataQueue.Enqueue(Convert.ToInt32(enqueueInputBox.Text));
        }

        private void Dequeue(object _, EventArgs e)
        {
            if (dataQueue.Count == 0)
            {
                MessageBox.Show("Cannot Dequeue from an Empty Queue!!");
                return;
            }

            int data = dataQueue.Dequeue();
            dequeueOutputBox.Text = data.ToString();
        }
        private void DequeueAverageOperation(object _, EventArgs e)
        {
            int N = Convert.ToInt32(dequeueAverageNInput.Text);
            if (N > this.dataQueue.Count)
            {
                MessageBox.Show("Not Enough Datapoints for Given N!!");
                return;
            }

            int sum = 0;
            for (int i = 0; i < N; i++)
                sum += this.dataQueue.Dequeue();
            float average = sum / N;
            dequeueAverageOutput.Text = average.ToString();
        }

        private void UpdateQueue(object _, EventArgs e)
        {
            queueContentReadout.ResetText();
            bool justStarted = true;
            foreach (int data in this.dataQueue)
            {
                string chunk = (justStarted ? "" : ", ") + data.ToString();
                queueContentReadout.AppendText(chunk);
                justStarted = false;
            }
            queueSizeReadout.Text = this.dataQueue.Count().ToString();
        }
    }
}
