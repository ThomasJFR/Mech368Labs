using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Mech368_Lab1E3
{
    public partial class FormL1E3 : Form
    {
        readonly ConcurrentQueue<Int32> dataQueue;  // FIFO

        public FormL1E3()
        {
            InitializeComponent();

            this.dataQueue = new ConcurrentQueue<Int32>();

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
            int data;
            if (dataQueue.TryDequeue(out data))
                dequeueOutputBox.Text = data.ToString();
            else
                MessageBox.Show("Cannot Dequeue from an Empty Queue!!"); 
        }
        private void DequeueAverageOperation(object _, EventArgs e)
        {
            int N = Convert.ToInt32(dequeueAverageNInput.Text);
            if (N > this.dataQueue.Count)
            {
                MessageBox.Show("Not Enough Datapoints for Given N!!");
                return;
            }

            int data;
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                if (this.dataQueue.TryDequeue(out data))
                    sum += data;
                else
                    throw new Exception("Now why did the N conditional allow this??");  // This should never be reached
            }
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
