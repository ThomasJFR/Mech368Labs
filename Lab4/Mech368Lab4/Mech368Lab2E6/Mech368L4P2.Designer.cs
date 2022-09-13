
namespace Mech368Lab2E6
{
    partial class Mech368L4P2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.voltageTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loadTB = new System.Windows.Forms.TextBox();
            this.filepathTB = new System.Windows.Forms.TextBox();
            this.savetofileCB = new System.Windows.Forms.CheckBox();
            this.processLoop = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.voltageAvgTB = new System.Windows.Forms.TextBox();
            this.plot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.plot)).BeginInit();
            this.SuspendLayout();
            // 
            // voltageTB
            // 
            this.voltageTB.Location = new System.Drawing.Point(119, 10);
            this.voltageTB.Name = "voltageTB";
            this.voltageTB.Size = new System.Drawing.Size(121, 26);
            this.voltageTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voltage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "mV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "cm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Distance";
            // 
            // loadTB
            // 
            this.loadTB.Location = new System.Drawing.Point(118, 122);
            this.loadTB.Name = "loadTB";
            this.loadTB.Size = new System.Drawing.Size(121, 26);
            this.loadTB.TabIndex = 3;
            // 
            // filepathTB
            // 
            this.filepathTB.Location = new System.Drawing.Point(17, 412);
            this.filepathTB.Name = "filepathTB";
            this.filepathTB.Size = new System.Drawing.Size(292, 26);
            this.filepathTB.TabIndex = 3;
            // 
            // savetofileCB
            // 
            this.savetofileCB.AutoSize = true;
            this.savetofileCB.Location = new System.Drawing.Point(17, 382);
            this.savetofileCB.Name = "savetofileCB";
            this.savetofileCB.Size = new System.Drawing.Size(118, 24);
            this.savetofileCB.TabIndex = 6;
            this.savetofileCB.Text = "Save to File";
            this.savetofileCB.UseVisualStyleBackColor = true;
            // 
            // processLoop
            // 
            this.processLoop.Enabled = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "mV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Voltage (Avg)";
            // 
            // voltageAvgTB
            // 
            this.voltageAvgTB.Location = new System.Drawing.Point(119, 42);
            this.voltageAvgTB.Name = "voltageAvgTB";
            this.voltageAvgTB.Size = new System.Drawing.Size(121, 26);
            this.voltageAvgTB.TabIndex = 7;
            // 
            // plot
            // 
            chartArea1.Name = "ChartArea1";
            this.plot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.plot.Legends.Add(legend1);
            this.plot.Location = new System.Drawing.Point(9, 154);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(807, 222);
            this.plot.TabIndex = 10;
            this.plot.Text = "chart1";
            // 
            // Mech368L4P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 446);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.voltageAvgTB);
            this.Controls.Add(this.savetofileCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filepathTB);
            this.Controls.Add(this.loadTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voltageTB);
            this.Name = "Mech368L4P2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.plot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox voltageTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loadTB;
        private System.Windows.Forms.TextBox filepathTB;
        private System.Windows.Forms.CheckBox savetofileCB;
        private System.Windows.Forms.Timer processLoop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox voltageAvgTB;
        private System.Windows.Forms.DataVisualization.Charting.Chart plot;
    }
}

