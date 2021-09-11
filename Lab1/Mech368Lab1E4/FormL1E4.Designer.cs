
namespace Mech368Lab1E4
{
    partial class FormL1E4
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
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.serialConnectToggle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBytesToRead = new System.Windows.Forms.TextBox();
            this.textBoxBufferLength = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxDatastreamOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.streamProcessingTimer = new System.Windows.Forms.Timer(this.components);
            this.toggleButtonUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(13, 13);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(182, 33);
            this.comboBoxCOMPorts.TabIndex = 0;
            // 
            // serialConnectToggle
            // 
            this.serialConnectToggle.Location = new System.Drawing.Point(218, 11);
            this.serialConnectToggle.Name = "serialConnectToggle";
            this.serialConnectToggle.Size = new System.Drawing.Size(206, 34);
            this.serialConnectToggle.TabIndex = 1;
            this.serialConnectToggle.Text = "N/A";
            this.serialConnectToggle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Bytes to Read";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buffer Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Items in Queue";
            // 
            // textBoxBytesToRead
            // 
            this.textBoxBytesToRead.Location = new System.Drawing.Point(218, 92);
            this.textBoxBytesToRead.Name = "textBoxBytesToRead";
            this.textBoxBytesToRead.Size = new System.Drawing.Size(166, 31);
            this.textBoxBytesToRead.TabIndex = 3;
            // 
            // textBoxBufferLength
            // 
            this.textBoxBufferLength.Location = new System.Drawing.Point(218, 132);
            this.textBoxBufferLength.Name = "textBoxBufferLength";
            this.textBoxBufferLength.Size = new System.Drawing.Size(166, 31);
            this.textBoxBufferLength.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(218, 172);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(166, 31);
            this.textBox4.TabIndex = 3;
            // 
            // textBoxDatastreamOutput
            // 
            this.textBoxDatastreamOutput.Location = new System.Drawing.Point(13, 277);
            this.textBoxDatastreamOutput.Multiline = true;
            this.textBoxDatastreamOutput.Name = "textBoxDatastreamOutput";
            this.textBoxDatastreamOutput.Size = new System.Drawing.Size(411, 161);
            this.textBoxDatastreamOutput.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Datastream Output:";
            // 
            // FormL1E4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.textBoxDatastreamOutput);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBoxBufferLength);
            this.Controls.Add(this.textBoxBytesToRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialConnectToggle);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Name = "FormL1E4";
            this.Text = "Lab 1 Exercise 4";
            this.Load += new System.EventHandler(this.FormL1E4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button serialConnectToggle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBytesToRead;
        private System.Windows.Forms.TextBox textBoxBufferLength;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxDatastreamOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer streamProcessingTimer;
        private System.Windows.Forms.Timer toggleButtonUpdateTimer;
    }
}

