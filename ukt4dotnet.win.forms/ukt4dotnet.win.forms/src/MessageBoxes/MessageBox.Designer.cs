namespace romo.windows.forms.MessageBoxes
{
    partial class MessageBox
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
            this.MessageLabel = new System.Windows.Forms.Label();
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
            this.MainPanel.Controls.Add(this.MessageLabel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(638, 204);
            this.MainPanel.TabIndex = 0;
            // 
            // NoExitButton
            // 
            this.NoExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NoExitButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoExitButton.Location = new System.Drawing.Point(384, 64);
            this.NoExitButton.Name = "NoExitButton";
            this.NoExitButton.Size = new System.Drawing.Size(128, 128);
            this.NoExitButton.TabIndex = 20;
            this.NoExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NoExitButton.UseVisualStyleBackColor = true;
            // 
            // YesExitButton
            // 
            this.YesExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.YesExitButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesExitButton.Location = new System.Drawing.Point(54, 64);
            this.YesExitButton.Name = "YesExitButton";
            this.YesExitButton.Size = new System.Drawing.Size(128, 128);
            this.YesExitButton.TabIndex = 19;
            this.YesExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.YesExitButton.UseVisualStyleBackColor = true;
            // 
            // CancelExitButton
            // 
            this.CancelExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelExitButton.Location = new System.Drawing.Point(498, 64);
            this.CancelExitButton.Name = "CancelExitButton";
            this.CancelExitButton.Size = new System.Drawing.Size(128, 128);
            this.CancelExitButton.TabIndex = 18;
            this.CancelExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CancelExitButton.UseVisualStyleBackColor = true;
            // 
            // OKExitButton
            // 
            this.OKExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKExitButton.Location = new System.Drawing.Point(17, 64);
            this.OKExitButton.Name = "OKExitButton";
            this.OKExitButton.Size = new System.Drawing.Size(128, 128);
            this.OKExitButton.TabIndex = 17;
            this.OKExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OKExitButton.UseVisualStyleBackColor = true;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(12, 9);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(114, 26);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "{Message}";
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 204);
            this.Controls.Add(this.MainPanel);
            this.Name = "MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{Title}";
            this.Shown += new System.EventHandler(this.MessageBox_Shown);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button NoExitButton;
        private System.Windows.Forms.Button YesExitButton;
        private System.Windows.Forms.Button CancelExitButton;
        private System.Windows.Forms.Button OKExitButton;

    }
}