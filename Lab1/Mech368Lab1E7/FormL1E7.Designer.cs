
namespace Mech368Lab1E7
{
    partial class FormL1E7
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
            this.processInput = new System.Windows.Forms.Button();
            this.myLabel = new System.Windows.Forms.Label();
            this.stateBox = new System.Windows.Forms.TextBox();
            this.textBoxDatastreamOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.streamProcessingTimer = new System.Windows.Forms.Timer(this.components);
            this.toggleButtonUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processInput
            // 
            this.processInput.Location = new System.Drawing.Point(16, 76);
            this.processInput.Name = "processInput";
            this.processInput.Size = new System.Drawing.Size(412, 34);
            this.processInput.TabIndex = 1;
            this.processInput.Text = "Process Input";
            this.processInput.UseVisualStyleBackColor = true;
            // 
            // myLabel
            // 
            this.myLabel.AutoSize = true;
            this.myLabel.Location = new System.Drawing.Point(201, 128);
            this.myLabel.Name = "myLabel";
            this.myLabel.Size = new System.Drawing.Size(51, 25);
            this.myLabel.TabIndex = 2;
            this.myLabel.Text = "State";
            // 
            // stateBox
            // 
            this.stateBox.Enabled = false;
            this.stateBox.Location = new System.Drawing.Point(262, 122);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(166, 31);
            this.stateBox.TabIndex = 3;
            // 
            // textBoxDatastreamOutput
            // 
            this.textBoxDatastreamOutput.Location = new System.Drawing.Point(16, 194);
            this.textBoxDatastreamOutput.Multiline = true;
            this.textBoxDatastreamOutput.Name = "textBoxDatastreamOutput";
            this.textBoxDatastreamOutput.Size = new System.Drawing.Size(411, 161);
            this.textBoxDatastreamOutput.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Datastream Output:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ax";
            // 
            // textBoxAx
            // 
            this.textBoxAx.Location = new System.Drawing.Point(55, 21);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(82, 31);
            this.textBoxAx.TabIndex = 5;
            // 
            // textBoxAy
            // 
            this.textBoxAy.Location = new System.Drawing.Point(201, 21);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(80, 31);
            this.textBoxAy.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ay";
            // 
            // textBoxAz
            // 
            this.textBoxAz.Location = new System.Drawing.Point(347, 21);
            this.textBoxAz.Name = "textBoxAz";
            this.textBoxAz.Size = new System.Drawing.Size(77, 31);
            this.textBoxAz.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Az";
            // 
            // FormL1E7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 369);
            this.Controls.Add(this.textBoxAz);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDatastreamOutput);
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.myLabel);
            this.Controls.Add(this.processInput);
            this.Name = "FormL1E7";
            this.Text = "Lab 1 Exercise 7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.Load += new System.EventHandler(this.onFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button processInput;
        private System.Windows.Forms.Label myLabel;
        private System.Windows.Forms.TextBox stateBox;
        private System.Windows.Forms.TextBox textBoxDatastreamOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer streamProcessingTimer;
        private System.Windows.Forms.Timer toggleButtonUpdateTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAz;
        private System.Windows.Forms.Label label7;
    }
}

