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
        private Queue<int> axQueue = new Queue<int>();
        private Queue<int> ayQueue = new Queue<int>();
        private Queue<int> azQueue = new Queue<int>();
        private const int axQueue_size = 4,
                          ayQueue_size = 4,
                          azQueue_size = 4;

        private Queue<int> axQueue2 = new Queue<int>();
        private Queue<int> ayQueue2 = new Queue<int>();
        private Queue<int> azQueue2 = new Queue<int>();
        private const int axQueue2_size = 50,
                          ayQueue2_size = 50,
                          azQueue2_size = 50;

        private Queue<float> gxMaxQueue = new Queue<float>();
        private Queue<float> gyMaxQueue = new Queue<float>();
        private Queue<float> gzMaxQueue = new Queue<float>();
        private const int gxMaxQueue_size = 500,
                          gyMaxQueue_size = 500,
                          gzMaxQueue_size = 500;

        private void ActionUpdateTick(object sender, EventArgs e)
        {
            this.serBufLenBox.Text = $"{this.accelerometer.port.BytesToWrite}";
            this.queueLenBox.Text = $"{this.accelerometer.streamBuffer.Count}";
            
            List<Acceleration> accelerations = this.accelerometer.ParseDatastream();
            if (accelerations.Count == 0 && this.accelerometer.IsOPen())
            {
                this.accelerometer.CloseStream();
                MessageBox.Show("COMPort Disconnected!");
                return;
            }
            
            foreach (Acceleration acceleration in accelerations)
            {
                this.axiBox.Text = $"{acceleration.ax}"; 
                this.ayiBox.Text = $"{acceleration.ay}"; 
                this.aziBox.Text = $"{acceleration.az}";
                void EnqueueCircular(Queue<int> queue, int next, int max)
                {
                    queue.Enqueue(next);
                    if (queue.Count > max)
                        queue.Dequeue();
                }

                void EnqueueCircularf(Queue<float> queue, float next, int max)
                {
                    queue.Enqueue(next);
                    if (queue.Count > max)
                        queue.Dequeue();
                }

                EnqueueCircular(this.axQueue, acceleration.ax, axQueue_size);
                EnqueueCircular(this.ayQueue, acceleration.ay, ayQueue_size);
                EnqueueCircular(this.azQueue, acceleration.az, azQueue_size);

                EnqueueCircular(this.axQueue2, acceleration.ax, axQueue2_size);
                EnqueueCircular(this.ayQueue2, acceleration.ay, ayQueue2_size);
                EnqueueCircular(this.azQueue2, acceleration.az, azQueue2_size);

                float GetQueueMax(Queue<float> queue)
                {
                    float max = 0;
                    foreach (float val in queue)
                        max = MathF.Abs(val) > MathF.Abs(max) ? val : max;
                    return max;
                }

                int AverageAndDiscretize(Queue<int> queue, int disc_base, int offset = 0)
                {
                    float avg = 0;
                    foreach (int val in queue)
                        avg += val - offset;
                    avg /= (float) queue.Count;

                    float acc = avg / (1f * disc_base);
                    return (int) (acc > 0 ? Math.Floor(acc) : Math.Ceiling(acc));
                }

                // Display some stuff
                float gx = (AverageAndDiscretize(this.axQueue2, 1, 128)) / 20f;
                float gy = (AverageAndDiscretize(this.ayQueue2, 1, 128)) / 20f;
                float gz = (AverageAndDiscretize(this.azQueue2, 1, 128)) / 20f;

                this.axBox.Text = $"{gx}";
                this.ayBox.Text = $"{gy}";
                this.azBox.Text = $"{gz}";

                this.oriXBox.Text = gx > 0 ? "+X" : (gx < 0 ? "-X" : "");
                this.oriYBox.Text = gy > 0 ? "+Y" : (gy < 0 ? "-Y" : "");
                this.oriZBox.Text = gz > 0 ? "+Z" : (gz < 0 ? "-Z" : "");

                EnqueueCircularf(this.gxMaxQueue, (acceleration.ax - 128) / 20f, gxMaxQueue_size);
                EnqueueCircularf(this.gyMaxQueue, (acceleration.ay - 128) / 20f, gyMaxQueue_size);
                EnqueueCircularf(this.gzMaxQueue, (acceleration.az - 128) / 20f, gzMaxQueue_size);
                float xMax = GetQueueMax(this.gxMaxQueue);
                float yMax = GetQueueMax(this.gyMaxQueue);
                float zMax = GetQueueMax(this.gzMaxQueue);
                this.gx500Box.Text = $"{xMax}";
                this.gy500Box.Text = $"{yMax}";
                this.gz500Box.Text = $"{zMax}";

                // Tune the disc_base as needed
                int ax = AverageAndDiscretize(this.axQueue, 20, 128);
                int ay = AverageAndDiscretize(this.ayQueue, 35, 100);
                int az = AverageAndDiscretize(this.azQueue, 40, 128);

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
                    this.streamWriter.WriteLine($"{acceleration.ax}, {acceleration.ay}, {acceleration.az}, {this.action.id}");
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
