namespace romo.windows.forms.FileSystem
{
    partial class FolderGroupForm
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
            this.FolderPathPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.ExitButtonsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImageCancelExitButton = new System.Windows.Forms.Button();
            this.ImageOKExitButton = new System.Windows.Forms.Button();
            this.OKExitButton = new System.Windows.Forms.Button();
            this.CancelExitButton = new System.Windows.Forms.Button();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ParentFolderPathLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.NewFolderNameTextBox = new System.Windows.Forms.TextBox();
            this.NewFolderNameLabel = new System.Windows.Forms.Label();
            this.NewFolderNameValidateButton = new System.Windows.Forms.Button();
            this.ParentFolderButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.FolderPathPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButtonsSplitContainer)).BeginInit();
            this.ExitButtonsSplitContainer.Panel1.SuspendLayout();
            this.ExitButtonsSplitContainer.Panel2.SuspendLayout();
            this.ExitButtonsSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.FolderPathPanel);
            this.MainPanel.Controls.Add(this.BottomPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(659, 326);
            this.MainPanel.TabIndex = 1;
            // 
            // FolderPathPanel
            // 
            this.FolderPathPanel.Controls.Add(this.NewFolderNameValidateButton);
            this.FolderPathPanel.Controls.Add(this.ParentFolderButton);
            this.FolderPathPanel.Controls.Add(this.NewFolderNameTextBox);
            this.FolderPathPanel.Controls.Add(this.NewFolderNameLabel);
            this.FolderPathPanel.Controls.Add(this.PathTextBox);
            this.FolderPathPanel.Controls.Add(this.ParentFolderPathLabel);
            this.FolderPathPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderPathPanel.Location = new System.Drawing.Point(0, 0);
            this.FolderPathPanel.Name = "FolderPathPanel";
            this.FolderPathPanel.Size = new System.Drawing.Size(659, 140);
            this.FolderPathPanel.TabIndex = 4;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ExitButtonsSplitContainer);
            this.BottomPanel.Controls.Add(this.MainStatusStrip);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 140);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(659, 186);
            this.BottomPanel.TabIndex = 1;
            // 
            // ExitButtonsSplitContainer
            // 
            this.ExitButtonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitButtonsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ExitButtonsSplitContainer.Name = "ExitButtonsSplitContainer";
            // 
            // ExitButtonsSplitContainer.Panel1
            // 
            this.ExitButtonsSplitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // ExitButtonsSplitContainer.Panel2
            // 
            this.ExitButtonsSplitContainer.Panel2.Controls.Add(this.OKExitButton);
            this.ExitButtonsSplitContainer.Panel2.Controls.Add(this.CancelExitButton);
            this.ExitButtonsSplitContainer.Size = new System.Drawing.Size(659, 164);
            this.ExitButtonsSplitContainer.SplitterDistance = 431;
            this.ExitButtonsSplitContainer.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.ImageCancelExitButton);
            this.panel1.Controls.Add(this.ImageOKExitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 164);
            this.panel1.TabIndex = 1;
            // 
            // ImageCancelExitButton
            // 
            this.ImageCancelExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageCancelExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageCancelExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageCancelExitButton.Location = new System.Drawing.Point(284, 24);
            this.ImageCancelExitButton.Name = "ImageCancelExitButton";
            this.ImageCancelExitButton.Size = new System.Drawing.Size(128, 128);
            this.ImageCancelExitButton.TabIndex = 20;
            this.ImageCancelExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ImageCancelExitButton.UseVisualStyleBackColor = true;
            this.ImageCancelExitButton.Click += new System.EventHandler(this.ImageCancelExitButton_Click);
            // 
            // ImageOKExitButton
            // 
            this.ImageOKExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageOKExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageOKExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageOKExitButton.Location = new System.Drawing.Point(12, 24);
            this.ImageOKExitButton.Name = "ImageOKExitButton";
            this.ImageOKExitButton.Size = new System.Drawing.Size(128, 128);
            this.ImageOKExitButton.TabIndex = 17;
            this.ImageOKExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ImageOKExitButton.UseVisualStyleBackColor = true;
            this.ImageOKExitButton.Click += new System.EventHandler(this.ImageOKExitButton_Click);
            // 
            // OKExitButton
            // 
            this.OKExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKExitButton.Location = new System.Drawing.Point(94, 102);
            this.OKExitButton.Name = "OKExitButton";
            this.OKExitButton.Size = new System.Drawing.Size(118, 23);
            this.OKExitButton.TabIndex = 3;
            this.OKExitButton.Text = "[OKEXITBUTTON]";
            this.OKExitButton.UseVisualStyleBackColor = true;
            this.OKExitButton.Click += new System.EventHandler(this.OKExitButton_Click);
            // 
            // CancelExitButton
            // 
            this.CancelExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelExitButton.Location = new System.Drawing.Point(94, 131);
            this.CancelExitButton.Name = "CancelExitButton";
            this.CancelExitButton.Size = new System.Drawing.Size(118, 23);
            this.CancelExitButton.TabIndex = 2;
            this.CancelExitButton.Text = "[CANCELEXITBUTTON]";
            this.CancelExitButton.UseVisualStyleBackColor = true;
            this.CancelExitButton.Click += new System.EventHandler(this.CancelExitButton_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 164);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(659, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // ParentFolderPathLabel
            // 
            this.ParentFolderPathLabel.AutoSize = true;
            this.ParentFolderPathLabel.Location = new System.Drawing.Point(12, 9);
            this.ParentFolderPathLabel.Name = "ParentFolderPathLabel";
            this.ParentFolderPathLabel.Size = new System.Drawing.Size(129, 13);
            this.ParentFolderPathLabel.TabIndex = 0;
            this.ParentFolderPathLabel.Text = "[PARENTFOLDERPATH]";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(12, 25);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(635, 20);
            this.PathTextBox.TabIndex = 1;
            // 
            // NewFolderNameTextBox
            // 
            this.NewFolderNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewFolderNameTextBox.Location = new System.Drawing.Point(12, 80);
            this.NewFolderNameTextBox.Name = "NewFolderNameTextBox";
            this.NewFolderNameTextBox.Size = new System.Drawing.Size(635, 20);
            this.NewFolderNameTextBox.TabIndex = 4;
            // 
            // NewFolderNameLabel
            // 
            this.NewFolderNameLabel.AutoSize = true;
            this.NewFolderNameLabel.Location = new System.Drawing.Point(12, 64);
            this.NewFolderNameLabel.Name = "NewFolderNameLabel";
            this.NewFolderNameLabel.Size = new System.Drawing.Size(113, 13);
            this.NewFolderNameLabel.TabIndex = 3;
            this.NewFolderNameLabel.Text = "[NEWFOLDERNAME]";
            // 
            // NewFolderNameValidateButton
            // 
            this.NewFolderNameValidateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewFolderNameValidateButton.Location = new System.Drawing.Point(529, 106);
            this.NewFolderNameValidateButton.Name = "NewFolderNameValidateButton";
            this.NewFolderNameValidateButton.Size = new System.Drawing.Size(118, 23);
            this.NewFolderNameValidateButton.TabIndex = 5;
            this.NewFolderNameValidateButton.Text = "[NEWFOLDERNAMEVALIDATEBUTTON]";
            this.NewFolderNameValidateButton.UseVisualStyleBackColor = true;
            // 
            // ParentFolderButton
            // 
            this.ParentFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ParentFolderButton.Location = new System.Drawing.Point(529, 51);
            this.ParentFolderButton.Name = "ParentFolderButton";
            this.ParentFolderButton.Size = new System.Drawing.Size(118, 23);
            this.ParentFolderButton.TabIndex = 2;
            this.ParentFolderButton.Text = "[PARENTFOLDERBUTTON]";
            this.ParentFolderButton.UseVisualStyleBackColor = true;
            // 
            // FolderGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 326);
            this.Controls.Add(this.MainPanel);
            this.Name = "FolderGroupForm";
            this.Text = "FolderGroupForm";
            this.MainPanel.ResumeLayout(false);
            this.FolderPathPanel.ResumeLayout(false);
            this.FolderPathPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ExitButtonsSplitContainer.Panel1.ResumeLayout(false);
            this.ExitButtonsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitButtonsSplitContainer)).EndInit();
            this.ExitButtonsSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel FolderPathPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.SplitContainer ExitButtonsSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ImageCancelExitButton;
        private System.Windows.Forms.Button ImageOKExitButton;
        private System.Windows.Forms.Button OKExitButton;
        private System.Windows.Forms.Button CancelExitButton;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.Label ParentFolderPathLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.TextBox NewFolderNameTextBox;
        private System.Windows.Forms.Label NewFolderNameLabel;
        private System.Windows.Forms.Button NewFolderNameValidateButton;
        private System.Windows.Forms.Button ParentFolderButton;
    }
}