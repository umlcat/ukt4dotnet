namespace romo.windows.forms.MessageBoxes
{
    partial class InfoBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitCloseButton = new System.Windows.Forms.Button();
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(441, 290);
            this.MainPanel.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.ExitCloseButton);
            this.panel1.Controls.Add(this.DataTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 290);
            this.panel1.TabIndex = 14;
            // 
            // ExitCloseButton
            // 
            this.ExitCloseButton.BackColor = System.Drawing.SystemColors.Info;
            this.ExitCloseButton.FlatAppearance.BorderSize = 0;
            this.ExitCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitCloseButton.Location = new System.Drawing.Point(345, 0);
            this.ExitCloseButton.Name = "ExitCloseButton";
            this.ExitCloseButton.Size = new System.Drawing.Size(96, 96);
            this.ExitCloseButton.TabIndex = 15;
            this.ExitCloseButton.Text = "X";
            this.ExitCloseButton.UseVisualStyleBackColor = false;
            this.ExitCloseButton.Click += new System.EventHandler(this.ExitCloseButton_Click);
            // 
            // DataTextBox
            // 
            this.DataTextBox.AcceptsReturn = true;
            this.DataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.DataTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTextBox.Location = new System.Drawing.Point(12, 102);
            this.DataTextBox.Multiline = true;
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.ReadOnly = true;
            this.DataTextBox.Size = new System.Drawing.Size(417, 176);
            this.DataTextBox.TabIndex = 14;
            // 
            // InfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 290);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HintBoxes";
            this.Shown += new System.EventHandler(this.InfoBox_Shown);
            this.MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExitCloseButton;
        private System.Windows.Forms.TextBox DataTextBox;

    }
}