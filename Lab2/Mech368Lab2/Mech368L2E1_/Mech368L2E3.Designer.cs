
namespace Mech368L2E1_
{
    partial class Mech368L2E3
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
            this.ledButton = new System.Windows.Forms.Button();
            this.ledTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ledButton
            // 
            this.ledButton.Location = new System.Drawing.Point(45, 27);
            this.ledButton.Name = "ledButton";
            this.ledButton.Size = new System.Drawing.Size(75, 65);
            this.ledButton.TabIndex = 0;
            this.ledButton.Text = "LED";
            this.ledButton.UseVisualStyleBackColor = true;
            // 
            // Mech368L2E3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 120);
            this.Controls.Add(this.ledButton);
            this.Name = "Mech368L2E3";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ledButton;
        private System.Windows.Forms.Timer ledTimer;
    }
}

