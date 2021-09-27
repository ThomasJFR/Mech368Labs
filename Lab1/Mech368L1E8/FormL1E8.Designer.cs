
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
            this.actionLabel.Location = new System.Drawing.Point(507, 141);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(0, 25);
            this.actionLabel.TabIndex = 1;
            // 
            // axBox
            // 
            this.axBox.Enabled = false;
            this.axBox.Location = new System.Drawing.Point(401, 330);
            this.axBox.Name = "axBox";
            this.axBox.Size = new System.Drawing.Size(150, 31);
            this.axBox.TabIndex = 2;
            // 
            // ayBox
            // 
            this.ayBox.Enabled = false;
            this.ayBox.Location = new System.Drawing.Point(401, 367);
            this.ayBox.Name = "ayBox";
            this.ayBox.Size = new System.Drawing.Size(150, 31);
            this.ayBox.TabIndex = 2;
            // 
            // azBox
            // 
            this.azBox.Enabled = false;
            this.azBox.Location = new System.Drawing.Point(401, 404);
            this.azBox.Name = "azBox";
            this.azBox.Size = new System.Drawing.Size(150, 31);
            this.azBox.TabIndex = 2;
            // 
            // console
            // 
            this.console.Enabled = false;
            this.console.Location = new System.Drawing.Point(578, 21);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(385, 414);
            this.console.TabIndex = 3;
            // 
            // FormL1E8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 450);
            this.Controls.Add(this.console);
            this.Controls.Add(this.azBox);
            this.Controls.Add(this.ayBox);
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
    }
}

