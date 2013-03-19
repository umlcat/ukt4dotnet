namespace romo.windows.forms.InputBoxes
{
    partial class InputBox
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.CancelExitButton = new System.Windows.Forms.Button();
            this.OKExitButton = new System.Windows.Forms.Button();
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.DataLabel = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMain.Controls.Add(this.CancelExitButton);
            this.pnlMain.Controls.Add(this.OKExitButton);
            this.pnlMain.Controls.Add(this.DataTextBox);
            this.pnlMain.Controls.Add(this.DataLabel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(434, 237);
            this.pnlMain.TabIndex = 4;
            // 
            // CancelExitButton
            // 
            this.CancelExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelExitButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.CancelExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelExitButton.Location = new System.Drawing.Point(294, 99);
            this.CancelExitButton.Name = "CancelExitButton";
            this.CancelExitButton.Size = new System.Drawing.Size(128, 128);
            this.CancelExitButton.TabIndex = 7;
            this.CancelExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CancelExitButton.UseVisualStyleBackColor = true;
            this.CancelExitButton.Click += new System.EventHandler(this.CancelExitButton_Click);
            // 
            // OKExitButton
            // 
            this.OKExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKExitButton.Location = new System.Drawing.Point(12, 99);
            this.OKExitButton.Name = "OKExitButton";
            this.OKExitButton.Size = new System.Drawing.Size(128, 128);
            this.OKExitButton.TabIndex = 6;
            this.OKExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OKExitButton.UseVisualStyleBackColor = true;
            this.OKExitButton.Click += new System.EventHandler(this.OKExitButton_Click);
            // 
            // DataTextBox
            // 
            this.DataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTextBox.Location = new System.Drawing.Point(12, 38);
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.Size = new System.Drawing.Size(410, 32);
            this.DataTextBox.TabIndex = 5;
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataLabel.Location = new System.Drawing.Point(12, 9);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(125, 26);
            this.DataLabel.TabIndex = 4;
            this.DataLabel.Text = "{DataLabel}";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 237);
            this.Controls.Add(this.pnlMain);
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{InputBox}";
            this.Activated += new System.EventHandler(this.InputBox_Activated);
            this.Shown += new System.EventHandler(this.InputBox_Shown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button CancelExitButton;
        private System.Windows.Forms.Button OKExitButton;
        private System.Windows.Forms.TextBox DataTextBox;
        private System.Windows.Forms.Label DataLabel;

    }
}