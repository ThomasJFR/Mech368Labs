using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using Gestures;
using AccelerometerIO;

namespace Mech368L1E8
{
    public partial class FormL1E8 : Form
    {
        private Gesture action;
        private GestureHandler gestureHandler;
        private Accelerometer accelerometer;
        private Bitmap spritesheet;

        private StreamWriter streamWriter;

        public FormL1E8()
        {
            InitializeComponent();
            InitializeListeners();

            this.spritesheet = (Bitmap)this.spriteDisplay.Image;

            this.accelerometer = new Accelerometer("COM3");
            this.action = Gesture.IDLE;
            this.gestureHandler = new GestureHandler();
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            this.spritesheet = (Bitmap)this.spriteDisplay.Image;
            this.accelerometer.OpenStream();

            this.actionTicker.Enabled = true;
            this.spriteTicker.Enabled = true;

            MessageBox.Show(JsonSerializer.Serialize(this.gestureHandler.actionsTable));
        }
        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            this.accelerometer.CloseStream();
            if (this.streamWriter != null)
                this.streamWriter.Close();
        }

        private void InitializeListeners()
        {
            this.savefileCheckbox.CheckedChanged += this.ToggleFilewriter;
            this.savefileBox.Click += this.ConfigureOutputStream;

            this.actionTicker.Tick += this.ActionUpdateTick;
            this.spriteTicker.Tick += this.SpriteUpdateTick;

            //this.spriteDisplay.Click += (object o, EventArgs e) => this.gestureHandler.currAction.id = "Punch";

        }

        private void ConfigureOutputStream(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                savefileBox.Text = sfd.FileName;
        }

        private void ToggleFilewriter(object sender, EventArgs e)
        {
            if (this.streamWriter == null)
                if (this.savefileBox.Text.Length > 0)
                    this.streamWriter = new StreamWriter(this.savefileBox.Text);
                else
                    MessageBox.Show("Invalid filename!");
            else
            {
                this.streamWriter.Close();
                this.streamWriter = null;
            }
        }

        private int gestureTimer = 0;
        private  Queue<int> axQueue = new Queue<int>();
        private Queue<int> ayQueue = new Queue<int>();
        private Queue<int> azQueue = new Queue<int>();
        private void ActionUpdateTick(object sender, EventArgs e)
        {
            List<Acceleration> accelerations = this.accelerometer.ParseDatastream();
            if (accelerations.Count == 0 && this.accelerometer.IsOPen())
            {
                this.accelerometer.CloseStream();
                MessageBox.Show("COMPort Disconnected!");
                return;
            }
            /*            while (accelerations.Count > 3)
                            accelerations.RemoveAt(0);

                        int ax = 0, ay = 0, az = 0;
                        foreach (Acceleration acceleration in accelerations)
                        {
                            ax += (int)((acceleration.ax - 126));
                            ay += (int)((acceleration.ay - 100));
                            az += (int)((acceleration.az - 126));
                        }

                        ax /= 20 * 3;
                        ay /= 40 * 3;
                        az /= 40 * 3;
            
                    if (this.gestureHandler.Interpret(new int[] { ax, ay, az }, out Gesture g))
                    {
                        if (this.action.id != g.id)
                        {
                            this.gestureTimer = g.duration;
                            this.action = g;
                        }
                        else
                        {
                            if (this.gestureTimer > 0)
                                this.gestureTimer--;
                            else
                                this.action = Gesture.IDLE;
                        }
                    }
                    else if (this.gestureTimer > 0)
                        this.gestureTimer--;
                    else
                        this.action = Gesture.IDLE;
                }*/
            
            foreach (Acceleration acceleration in accelerations)
            {
                void EnqueueCircular(Queue<int> queue, int next, int max)
                {
                    queue.Enqueue(next);
                    if (queue.Count > max)
                        queue.Dequeue();
                }

                EnqueueCircular(this.axQueue, acceleration.ax - 126, 4);
                EnqueueCircular(this.ayQueue, acceleration.ay - 100, 4);
                EnqueueCircular(this.azQueue, acceleration.az - 126, 4);

                int AverageAndDiscretize(Queue<int> queue, int disc_base)
                {
                    float avg = 0;
                    foreach (int val in queue)
                        avg += val;
                    avg /= (float) queue.Count;

                    float acc = avg / (1f * disc_base);
                    return (int) (acc > 0 ? Math.Floor(acc) : Math.Ceiling(acc));
                }

                // Tune the disc_base as needed
                int ax = AverageAndDiscretize(this.axQueue, 20);
                int ay = AverageAndDiscretize(this.ayQueue, 35);
                int az = AverageAndDiscretize(this.azQueue, 40);

                this.console.AppendText($"{ax}, {ay}, {az}" + Environment.NewLine);

                if (this.gestureHandler.Interpret(new int[] { ax, ay, az }, out Gesture g, this.action))
                {
                    if (this.action.id != g.id)
                    {
                        this.gestureTimer = g.duration;
                        this.action = g;
                    }
                }

                if (this.streamWriter != null)
                    this.streamWriter.WriteLine($"{ax}, {ay}, {az}, {this.action.id}");
            }
            if (this.gestureTimer > 0)
                this.gestureTimer--;
            else
                this.action = Gesture.IDLE;
        }

        private void SpriteUpdateTick(object sender, EventArgs e)
        {
            /*            Rectangle cutout;
                        switch (this.action.id)
                        {
                            default:
                            case "Idle":
                                cutout = new Rectangle(
                                    new Point(60, 0), new Size(45, 95));
                                break;

                            case "Punch":
                                cutout = new Rectangle(
                                    new Point(150, 0), new Size(70, 95));
                                break;

                            case "High Punch":
                                cutout = new Rectangle(
                                    new Point(180, 220), new Size(40, 70));
                                break;
                        }
            */
            // Capture the sprite
            Rectangle cutout = new Rectangle(
                new Point(this.action.sprite[0], this.action.sprite[1]),
                new Size( this.action.sprite[2], this.action.sprite[3]));
            Bitmap nextsprite = this.spritesheet.Clone(
                cutout, this.spritesheet.PixelFormat);

            // Resize the sprite
            Bitmap resized = new Bitmap(500, 500);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.DrawImage(nextsprite, 0, 0, 267, 426);
            }

            // Display the sprite
            this.spriteDisplay.Image = resized;
            this.actionLabel.Text = this.action.id;

        }
    }
}
