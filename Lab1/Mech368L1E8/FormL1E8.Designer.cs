
namespace Mech368L1E8
{
    partial class FormL1E8
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormL1E8));
            this.spriteDisplay = new System.Windows.Forms.PictureBox();
            this.spriteTicker = new System.Windows.Forms.Timer(this.components);
            this.actionTicker = new System.Windows.Forms.Timer(this.components);
            this.actionLabel = new System.Windows.Forms.Label();
            this.axBox = new System.Windows.Forms.TextBox();
            this.ayBox = new System.Windows.Forms.TextBox();
            this.azBox = new System.Windows.Forms.TextBox();
            this.console = new System.Windows.Forms.TextBox();
            this.savefileCheckbox = new System.Windows.Forms.CheckBox();
            this.savefileBox = new System.Windows.Forms.TextBox();
            this.axiBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ayiBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aziBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serBufLenBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.queueLenBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gx500Box = new System.Windows.Forms.TextBox();
            this.gy500Box = new System.Windows.Forms.TextBox();
            this.gz500Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.oriXBox = new System.Windows.Forms.TextBox();
            this.oriYBox = new System.Windows.Forms.TextBox();
            this.oriZBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spriteDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteDisplay
            // 
            this.spriteDisplay.Image = ((System.Drawing.Image)(resources.GetObject("spriteDisplay.Image")));
            this.spriteDisplay.Location = new System.Drawing.Point(12, 12);
            this.spriteDisplay.Name = "spriteDisplay";
            this.spriteDisplay.Size = new System.Drawing.Size(267, 426);
            this.spriteDisplay.TabIndex = 0;
            this.spriteDisplay.TabStop = false;
            // 
            // spriteTicker
            // 
            this.spriteTicker.Interval = 250;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(26, 448);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(0, 25);
            this.actionLabel.TabIndex = 1;
            // 
            // axBox
            // 
            this.axBox.Enabled = false;
            this.axBox.Location = new System.Drawing.Point(327, 251);
            this.axBox.Name = "axBox";
            this.axBox.Size = new System.Drawing.Size(104, 31);
            this.axBox.TabIndex = 2;
            // 
            // ayBox
            // 
            this.ayBox.Enabled = false;
            this.ayBox.Location = new System.Drawing.Point(327, 288);
            this.ayBox.Name = "ayBox";
            this.ayBox.Size = new System.Drawing.Size(104, 31);
            this.ayBox.TabIndex = 2;
            // 
            // azBox
            // 
            this.azBox.Enabled = false;
            this.azBox.Location = new System.Drawing.Point(327, 325);
            this.azBox.Name = "azBox";
            this.azBox.Size = new System.Drawing.Size(104, 31);
            this.azBox.TabIndex = 2;
            // 
            // console
            // 
            this.console.Enabled = false;
            this.console.Location = new System.Drawing.Point(578, 21);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(385, 310);
            this.console.TabIndex = 3;
            // 
            // savefileCheckbox
            // 
            this.savefileCheckbox.AutoSize = true;
            this.savefileCheckbox.Location = new System.Drawing.Point(578, 369);
            this.savefileCheckbox.Name = "savefileCheckbox";
            this.savefileCheckbox.Size = new System.Drawing.Size(128, 29);
            this.savefileCheckbox.TabIndex = 4;
            this.savefileCheckbox.Text = "Save to File";
            this.savefileCheckbox.UseVisualStyleBackColor = true;
            // 
            // savefileBox
            // 
            this.savefileBox.Location = new System.Drawing.Point(578, 404);
            this.savefileBox.Name = "savefileBox";
            this.savefileBox.Size = new System.Drawing.Size(385, 31);
            this.savefileBox.TabIndex = 2;
            // 
            // axiBox
            // 
            this.axiBox.Enabled = false;
            this.axiBox.Location = new System.Drawing.Point(297, 141);
            this.axiBox.Name = "axiBox";
            this.axiBox.Size = new System.Drawing.Size(64, 31);
            this.axiBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "ax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "ay";
            // 
            // ayiBox
            // 
            this.ayiBox.Enabled = false;
            this.ayiBox.Location = new System.Drawing.Point(367, 141);
            this.ayiBox.Name = "ayiBox";
            this.ayiBox.Size = new System.Drawing.Size(64, 31);
            this.ayiBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "az";
            // 
            // aziBox
            // 
            this.aziBox.Enabled = false;
            this.aziBox.Location = new System.Drawing.Point(437, 141);
            this.aziBox.Name = "aziBox";
            this.aziBox.Size = new System.Drawing.Size(64, 31);
            this.aziBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "gx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "gy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "gz";
            // 
            // serBufLenBox
            // 
            this.serBufLenBox.Enabled = false;
            this.serBufLenBox.Location = new System.Drawing.Point(456, 15);
            this.serBufLenBox.Name = "serBufLenBox";
            this.serBufLenBox.Size = new System.Drawing.Size(95, 31);
            this.serBufLenBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Serial Buffer Length";
            // 
            // queueLenBox
            // 
            this.queueLenBox.Enabled = false;
            this.queueLenBox.Location = new System.Drawing.Point(456, 66);
            this.queueLenBox.Name = "queueLenBox";
            this.queueLenBox.Size = new System.Drawing.Size(95, 31);
            this.queueLenBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Queue Length";
            // 
            // gx500Box
            // 
            this.gx500Box.Enabled = false;
            this.gx500Box.Location = new System.Drawing.Point(447, 251);
            this.gx500Box.Name = "gx500Box";
            this.gx500Box.Size = new System.Drawing.Size(104, 31);
            this.gx500Box.TabIndex = 2;
            // 
            // gy500Box
            // 
            this.gy500Box.Enabled = false;
            this.gy500Box.Location = new System.Drawing.Point(447, 288);
            this.gy500Box.Name = "gy500Box";
            this.gy500Box.Size = new System.Drawing.Size(104, 31);
            this.gy500Box.TabIndex = 2;
            // 
            // gz500Box
            // 
            this.gz500Box.Enabled = false;
            this.gz500Box.Location = new System.Drawing.Point(447, 325);
            this.gz500Box.Name = "gz500Box";
            this.gz500Box.Size = new System.Drawing.Size(104, 31);
            this.gz500Box.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(447, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "Max 500";
            // 
            // oriXBox
            // 
            this.oriXBox.Enabled = false;
            this.oriXBox.Location = new System.Drawing.Point(297, 178);
            this.oriXBox.Name = "oriXBox";
            this.oriXBox.Size = new System.Drawing.Size(64, 31);
            this.oriXBox.TabIndex = 2;
            // 
            // oriYBox
            // 
            this.oriYBox.Enabled = false;
            this.oriYBox.Location = new System.Drawing.Point(367, 178);
            this.oriYBox.Name = "oriYBox";
            this.oriYBox.Size = new System.Drawing.Size(64, 31);
            this.oriYBox.TabIndex = 6;
            // 
            // oriZBox
            // 
            this.oriZBox.Enabled = false;
            this.oriZBox.Location = new System.Drawing.Point(437, 178);
            this.oriZBox.Name = "oriZBox";
            this.oriZBox.Size = new System.Drawing.Size(64, 31);
            this.oriZBox.TabIndex = 8;
            // 
            // FormL1E8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oriZBox);
            this.Controls.Add(this.aziBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oriYBox);
            this.Controls.Add(this.ayiBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savefileCheckbox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.savefileBox);
            this.Controls.Add(this.gz500Box);
            this.Controls.Add(this.azBox);
            this.Controls.Add(this.queueLenBox);
            this.Controls.Add(this.gy500Box);
            this.Controls.Add(this.ayBox);
            this.Controls.Add(this.serBufLenBox);
            this.Controls.Add(this.oriXBox);
            this.Controls.Add(this.gx500Box);
            this.Controls.Add(this.axiBox);
            this.Controls.Add(this.axBox);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.spriteDisplay);
            this.Name = "FormL1E8";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.Load += new System.EventHandler(this.onFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.spriteDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox spriteDisplay;
        private System.Windows.Forms.Timer spriteTicker;
        private System.Windows.Forms.Timer actionTicker;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.TextBox axBox;
        private System.Windows.Forms.TextBox ayBox;
        private System.Windows.Forms.TextBox azBox;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.CheckBox savefileCheckbox;
        private System.Windows.Forms.TextBox savefileBox;
        private System.Windows.Forms.TextBox axiBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ayiBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aziBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox serBufLenBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox queueLenBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox gx500Box;
        private System.Windows.Forms.TextBox gy500Box;
        private System.Windows.Forms.TextBox gz500Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox oriXBox;
        private System.Windows.Forms.TextBox oriYBox;
        private System.Windows.Forms.TextBox oriZBox;
    }
}

