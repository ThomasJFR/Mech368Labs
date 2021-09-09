
namespace Mech368_Lab1
{
    partial class FormL1E1
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
            this.XPosLabel = new System.Windows.Forms.Label();
            this.YPosLabel = new System.Windows.Forms.Label();
            this.XPosReadout = new System.Windows.Forms.TextBox();
            this.YPosReadout = new System.Windows.Forms.TextBox();
            this.virtTrackpad = new System.Windows.Forms.PictureBox();
            this.mouseClickRecorderBox = new System.Windows.Forms.TextBox();
            this.recordedClicksLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.virtTrackpad)).BeginInit();
            this.SuspendLayout();
            // 
            // XPosLabel
            // 
            this.XPosLabel.AutoSize = true;
            this.XPosLabel.Location = new System.Drawing.Point(19, 22);
            this.XPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XPosLabel.Name = "XPosLabel";
            this.XPosLabel.Size = new System.Drawing.Size(23, 25);
            this.XPosLabel.TabIndex = 0;
            this.XPosLabel.Text = "X";
            // 
            // YPosLabel
            // 
            this.YPosLabel.AutoSize = true;
            this.YPosLabel.Location = new System.Drawing.Point(17, 47);
            this.YPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YPosLabel.Name = "YPosLabel";
            this.YPosLabel.Size = new System.Drawing.Size(22, 25);
            this.YPosLabel.TabIndex = 1;
            this.YPosLabel.Text = "Y";
            // 
            // XPosReadout
            // 
            this.XPosReadout.Location = new System.Drawing.Point(49, 7);
            this.XPosReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.XPosReadout.Name = "XPosReadout";
            this.XPosReadout.Size = new System.Drawing.Size(141, 31);
            this.XPosReadout.TabIndex = 2;
            // 
            // YPosReadout
            // 
            this.YPosReadout.Location = new System.Drawing.Point(49, 47);
            this.YPosReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.YPosReadout.Name = "YPosReadout";
            this.YPosReadout.Size = new System.Drawing.Size(141, 31);
            this.YPosReadout.TabIndex = 3;
            // 
            // virtTrackpad
            // 
            this.virtTrackpad.BackColor = System.Drawing.SystemColors.Control;
            this.virtTrackpad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.virtTrackpad.Location = new System.Drawing.Point(200, 7);
            this.virtTrackpad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.virtTrackpad.Name = "virtTrackpad";
            this.virtTrackpad.Size = new System.Drawing.Size(939, 739);
            this.virtTrackpad.TabIndex = 4;
            this.virtTrackpad.TabStop = false;
            // 
            // mouseClickRecorderBox
            // 
            this.mouseClickRecorderBox.Location = new System.Drawing.Point(19, 177);
            this.mouseClickRecorderBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mouseClickRecorderBox.Multiline = true;
            this.mouseClickRecorderBox.Name = "mouseClickRecorderBox";
            this.mouseClickRecorderBox.Size = new System.Drawing.Size(171, 567);
            this.mouseClickRecorderBox.TabIndex = 6;
            // 
            // recordedClicksLabel
            // 
            this.recordedClicksLabel.AutoEllipsis = true;
            this.recordedClicksLabel.AutoSize = true;
            this.recordedClicksLabel.Location = new System.Drawing.Point(36, 147);
            this.recordedClicksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recordedClicksLabel.Name = "recordedClicksLabel";
            this.recordedClicksLabel.Size = new System.Drawing.Size(136, 25);
            this.recordedClicksLabel.TabIndex = 5;
            this.recordedClicksLabel.Text = "Recorded Clicks";
            // 
            // FormL1E1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.mouseClickRecorderBox);
            this.Controls.Add(this.recordedClicksLabel);
            this.Controls.Add(this.virtTrackpad);
            this.Controls.Add(this.YPosReadout);
            this.Controls.Add(this.XPosReadout);
            this.Controls.Add(this.YPosLabel);
            this.Controls.Add(this.XPosLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormL1E1";
            this.Text = "Lab 1 Exercise 1";
            ((System.ComponentModel.ISupportInitialize)(this.virtTrackpad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label XPosLabel;
        private System.Windows.Forms.Label YPosLabel;
        private System.Windows.Forms.TextBox XPosReadout;
        private System.Windows.Forms.TextBox YPosReadout;
        private System.Windows.Forms.PictureBox virtTrackpad;
        private System.Windows.Forms.TextBox mouseClickRecorderBox;
        private System.Windows.Forms.Label recordedClicksLabel;
    }
}

