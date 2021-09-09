
namespace Mech368_Lab1E2
{
    partial class FormL1E2
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
            this.enqueueButton = new System.Windows.Forms.Button();
            this.dequeueButton = new System.Windows.Forms.Button();
            this.enqueueInputBox = new System.Windows.Forms.TextBox();
            this.dequeueOutputBox = new System.Windows.Forms.TextBox();
            this.queueSizeReadout = new System.Windows.Forms.TextBox();
            this.itemsInQueueLabel = new System.Windows.Forms.Label();
            this.queueContentReadout = new System.Windows.Forms.TextBox();
            this.dequeueAverageOperationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dequeueAverageNInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dequeueAverageOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.updateQueueTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // enqueueButton
            // 
            this.enqueueButton.Location = new System.Drawing.Point(26, 30);
            this.enqueueButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enqueueButton.Name = "enqueueButton";
            this.enqueueButton.Size = new System.Drawing.Size(251, 57);
            this.enqueueButton.TabIndex = 0;
            this.enqueueButton.Text = "Enqueue";
            this.enqueueButton.UseVisualStyleBackColor = true;
            // 
            // dequeueButton
            // 
            this.dequeueButton.Location = new System.Drawing.Point(26, 102);
            this.dequeueButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dequeueButton.Name = "dequeueButton";
            this.dequeueButton.Size = new System.Drawing.Size(251, 57);
            this.dequeueButton.TabIndex = 1;
            this.dequeueButton.Text = "Dequeue";
            this.dequeueButton.UseVisualStyleBackColor = true;
            // 
            // enqueueInputBox
            // 
            this.enqueueInputBox.Location = new System.Drawing.Point(291, 30);
            this.enqueueInputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enqueueInputBox.Name = "enqueueInputBox";
            this.enqueueInputBox.Size = new System.Drawing.Size(371, 47);
            this.enqueueInputBox.TabIndex = 2;
            // 
            // dequeueOutputBox
            // 
            this.dequeueOutputBox.Location = new System.Drawing.Point(291, 102);
            this.dequeueOutputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dequeueOutputBox.Name = "dequeueOutputBox";
            this.dequeueOutputBox.ReadOnly = true;
            this.dequeueOutputBox.Size = new System.Drawing.Size(371, 47);
            this.dequeueOutputBox.TabIndex = 3;
            // 
            // queueSizeReadout
            // 
            this.queueSizeReadout.Location = new System.Drawing.Point(291, 176);
            this.queueSizeReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queueSizeReadout.Name = "queueSizeReadout";
            this.queueSizeReadout.ReadOnly = true;
            this.queueSizeReadout.Size = new System.Drawing.Size(371, 47);
            this.queueSizeReadout.TabIndex = 4;
            // 
            // itemsInQueueLabel
            // 
            this.itemsInQueueLabel.AutoSize = true;
            this.itemsInQueueLabel.Location = new System.Drawing.Point(92, 183);
            this.itemsInQueueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemsInQueueLabel.Name = "itemsInQueueLabel";
            this.itemsInQueueLabel.Size = new System.Drawing.Size(132, 25);
            this.itemsInQueueLabel.TabIndex = 5;
            this.itemsInQueueLabel.Text = "Items in Queue";
            // 
            // queueContentReadout
            // 
            this.queueContentReadout.Location = new System.Drawing.Point(26, 533);
            this.queueContentReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queueContentReadout.Multiline = true;
            this.queueContentReadout.Name = "queueContentReadout";
            this.queueContentReadout.Size = new System.Drawing.Size(635, 299);
            this.queueContentReadout.TabIndex = 6;
            // 
            // dequeueAverageOperationButton
            // 
            this.dequeueAverageOperationButton.Location = new System.Drawing.Point(26, 297);
            this.dequeueAverageOperationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dequeueAverageOperationButton.Name = "dequeueAverageOperationButton";
            this.dequeueAverageOperationButton.Size = new System.Drawing.Size(636, 57);
            this.dequeueAverageOperationButton.TabIndex = 7;
            this.dequeueAverageOperationButton.Text = "Dequeue and Average First N Datapoints";
            this.dequeueAverageOperationButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 378);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "N";
            // 
            // dequeueAverageNInput
            // 
            this.dequeueAverageNInput.Location = new System.Drawing.Point(74, 371);
            this.dequeueAverageNInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dequeueAverageNInput.Name = "dequeueAverageNInput";
            this.dequeueAverageNInput.Size = new System.Drawing.Size(203, 47);
            this.dequeueAverageNInput.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 378);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Average";
            // 
            // dequeueAverageOutput
            // 
            this.dequeueAverageOutput.Location = new System.Drawing.Point(456, 371);
            this.dequeueAverageOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dequeueAverageOutput.Name = "dequeueAverageOutput";
            this.dequeueAverageOutput.ReadOnly = true;
            this.dequeueAverageOutput.Size = new System.Drawing.Size(203, 47);
            this.dequeueAverageOutput.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 488);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Queue Contents";
            // 
            // FormL1E2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 1050);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dequeueAverageOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dequeueAverageNInput);
            this.Controls.Add(this.dequeueAverageOperationButton);
            this.Controls.Add(this.queueContentReadout);
            this.Controls.Add(this.itemsInQueueLabel);
            this.Controls.Add(this.queueSizeReadout);
            this.Controls.Add(this.dequeueOutputBox);
            this.Controls.Add(this.enqueueInputBox);
            this.Controls.Add(this.dequeueButton);
            this.Controls.Add(this.enqueueButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormL1E2";
            this.Text = "Lab 1 Exercise 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enqueueButton;
        private System.Windows.Forms.Button dequeueButton;
        private System.Windows.Forms.TextBox enqueueInputBox;
        private System.Windows.Forms.TextBox dequeueOutputBox;
        private System.Windows.Forms.TextBox queueSizeReadout;
        private System.Windows.Forms.Label itemsInQueueLabel;
        private System.Windows.Forms.TextBox queueContentReadout;
        private System.Windows.Forms.Button dequeueAverageOperationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dequeueAverageNInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dequeueAverageOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer updateQueueTimer;
    }
}

