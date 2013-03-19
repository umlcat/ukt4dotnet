namespace romo.windows.forms.MessageBoxes
{
    partial class MessageBoxMemo
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.NoExitButton = new System.Windows.Forms.Button();
            this.YesExitButton = new System.Windows.Forms.Button();
            this.CancelExitButton = new System.Windows.Forms.Button();
            this.OKExitButton = new System.Windows.Forms.Button();
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainPanel.Controls.Add(this.NoExitButton);
            this.MainPanel.Controls.Add(this.YesExitButton);
            this.MainPanel.Controls.Add(this.CancelExitButton);
            this.MainPanel.Controls.Add(this.OKExitButton);
            this.MainPanel.Controls.Add(this.DataTextBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(494, 479);
            this.MainPanel.TabIndex = 12;
            // 
            // NoExitButton
            // 
            this.NoExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NoExitButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoExitButton.Location = new System.Drawing.Point(290, 339);
            this.NoExitButton.Name = "NoExitButton";
            this.NoExitButton.Size = new System.Drawing.Size(128, 128);
            this.NoExitButton.TabIndex = 16;
            this.NoExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NoExitButton.UseVisualStyleBackColor = true;
            // 
            // YesExitButton
            // 
            this.YesExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.YesExitButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesExitButton.Location = new System.Drawing.Point(80, 339);
            this.YesExitButton.Name = "YesExitButton";
            this.YesExitButton.Size = new System.Drawing.Size(128, 128);
            this.YesExitButton.TabIndex = 15;
            this.YesExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.YesExitButton.UseVisualStyleBackColor = true;
            // 
            // CancelExitButton
            // 
            this.CancelExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelExitButton.Location = new System.Drawing.Point(354, 339);
            this.CancelExitButton.Name = "CancelExitButton";
            this.CancelExitButton.Size = new System.Drawing.Size(128, 128);
            this.CancelExitButton.TabIndex = 14;
            this.CancelExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CancelExitButton.UseVisualStyleBackColor = true;
            // 
            // OKExitButton
            // 
            this.OKExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKExitButton.Location = new System.Drawing.Point(12, 339);
            this.OKExitButton.Name = "OKExitButton";
            this.OKExitButton.Size = new System.Drawing.Size(128, 128);
            this.OKExitButton.TabIndex = 13;
            this.OKExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OKExitButton.UseVisualStyleBackColor = true;
            // 
            // DataTextBox
            // 
            this.DataTextBox.AcceptsReturn = true;
            this.DataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTextBox.Location = new System.Drawing.Point(12, 12);
            this.DataTextBox.Multiline = true;
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.ReadOnly = true;
            this.DataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DataTextBox.Size = new System.Drawing.Size(470, 308);
            this.DataTextBox.TabIndex = 12;
            this.DataTextBox.WordWrap = false;
            // 
            // MessageBoxMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 479);
            this.Controls.Add(this.MainPanel);
            this.Name = "MessageBoxMemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxesMemo";
            this.Shown += new System.EventHandler(this.MessageBoxesMemo_Shown);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button NoExitButton;
        private System.Windows.Forms.Button YesExitButton;
        private System.Windows.Forms.Button CancelExitButton;
        private System.Windows.Forms.Button OKExitButton;
        private System.Windows.Forms.TextBox DataTextBox;

    }
}