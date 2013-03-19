namespace romo.windows.forms.FileSystem
{
    partial class FolderExplorerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderExplorerDialog));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ExplorerPanel = new System.Windows.Forms.Panel();
            this.SpecialFoldersSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.NewFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveToParentFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewSmallIconsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ViewLargelIconsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.ExitButtonsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImageCancelExitButton = new System.Windows.Forms.Button();
            this.ImageOKExitButton = new System.Windows.Forms.Button();
            this.OKExitButton = new System.Windows.Forms.Button();
            this.CancelExitButton = new System.Windows.Forms.Button();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.FoldersTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.ItemsListViewSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.ItemsListViewLargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SpecialFoldersImageList = new System.Windows.Forms.ImageList(this.components);
            this.MainPanel.SuspendLayout();
            this.ExplorerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialFoldersSplitContainer)).BeginInit();
            this.SpecialFoldersSplitContainer.Panel2.SuspendLayout();
            this.SpecialFoldersSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
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
            this.MainPanel.Controls.Add(this.ExplorerPanel);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Controls.Add(this.BottomPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(727, 486);
            this.MainPanel.TabIndex = 0;
            // 
            // ExplorerPanel
            // 
            this.ExplorerPanel.Controls.Add(this.SpecialFoldersSplitContainer);
            this.ExplorerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExplorerPanel.Location = new System.Drawing.Point(0, 55);
            this.ExplorerPanel.Name = "ExplorerPanel";
            this.ExplorerPanel.Size = new System.Drawing.Size(727, 245);
            this.ExplorerPanel.TabIndex = 4;
            // 
            // SpecialFoldersSplitContainer
            // 
            this.SpecialFoldersSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpecialFoldersSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SpecialFoldersSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SpecialFoldersSplitContainer.Name = "SpecialFoldersSplitContainer";
            // 
            // SpecialFoldersSplitContainer.Panel2
            // 
            this.SpecialFoldersSplitContainer.Panel2.Controls.Add(this.MainSplitContainer);
            this.SpecialFoldersSplitContainer.Size = new System.Drawing.Size(727, 245);
            this.SpecialFoldersSplitContainer.SplitterDistance = 102;
            this.SpecialFoldersSplitContainer.TabIndex = 7;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Size = new System.Drawing.Size(621, 245);
            this.MainSplitContainer.SplitterDistance = 214;
            this.MainSplitContainer.TabIndex = 7;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.PathTextBox);
            this.TopPanel.Controls.Add(this.PathLabel);
            this.TopPanel.Controls.Add(this.MainToolStrip);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(727, 55);
            this.TopPanel.TabIndex = 3;
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(73, 29);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(642, 20);
            this.PathTextBox.TabIndex = 5;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(12, 32);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(42, 13);
            this.PathLabel.TabIndex = 4;
            this.PathLabel.Text = "[PATH]";
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolderToolStripButton,
            this.toolStripSeparator1,
            this.MoveToParentFolderToolStripButton,
            this.RefreshItemToolStripButton,
            this.toolStripSeparator2,
            this.ViewSmallIconsToolStripButton,
            this.ViewLargelIconsToolStripButton,
            this.toolStripSeparator3,
            this.DeleteFolderToolStripButton});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainToolStrip.Size = new System.Drawing.Size(727, 25);
            this.MainToolStrip.TabIndex = 3;
            this.MainToolStrip.Text = "MainToolStrip";
            // 
            // NewFolderToolStripButton
            // 
            this.NewFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewFolderToolStripButton.Image")));
            this.NewFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewFolderToolStripButton.Name = "NewFolderToolStripButton";
            this.NewFolderToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.NewFolderToolStripButton.Text = "[FOLDERCREATE]";
            this.NewFolderToolStripButton.Click += new System.EventHandler(this.NewFolderToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // MoveToParentFolderToolStripButton
            // 
            this.MoveToParentFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveToParentFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MoveToParentFolderToolStripButton.Image")));
            this.MoveToParentFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveToParentFolderToolStripButton.Name = "MoveToParentFolderToolStripButton";
            this.MoveToParentFolderToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.MoveToParentFolderToolStripButton.Text = "[MOVETOPARENTFOLDER]";
            // 
            // RefreshItemToolStripButton
            // 
            this.RefreshItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshItemToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshItemToolStripButton.Image")));
            this.RefreshItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshItemToolStripButton.Name = "RefreshItemToolStripButton";
            this.RefreshItemToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshItemToolStripButton.Text = "[REFRESHITEM]";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ViewSmallIconsToolStripButton
            // 
            this.ViewSmallIconsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ViewSmallIconsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewSmallIconsToolStripButton.Image")));
            this.ViewSmallIconsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewSmallIconsToolStripButton.Name = "ViewSmallIconsToolStripButton";
            this.ViewSmallIconsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ViewSmallIconsToolStripButton.Text = "[VIEWSMALLICONS]";
            this.ViewSmallIconsToolStripButton.Click += new System.EventHandler(this.ViewSmallIconsToolStripButton_Click);
            // 
            // ViewLargelIconsToolStripButton
            // 
            this.ViewLargelIconsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ViewLargelIconsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewLargelIconsToolStripButton.Image")));
            this.ViewLargelIconsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewLargelIconsToolStripButton.Name = "ViewLargelIconsToolStripButton";
            this.ViewLargelIconsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ViewLargelIconsToolStripButton.Text = "[VIEWMEDIUMICONS]";
            this.ViewLargelIconsToolStripButton.Click += new System.EventHandler(this.ViewLargelIconsToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // DeleteFolderToolStripButton
            // 
            this.DeleteFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteFolderToolStripButton.Image")));
            this.DeleteFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteFolderToolStripButton.Name = "DeleteFolderToolStripButton";
            this.DeleteFolderToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteFolderToolStripButton.Text = "[FOLDERDELETE]";
            this.DeleteFolderToolStripButton.Click += new System.EventHandler(this.DeleteFolderToolStripButton_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ExitButtonsSplitContainer);
            this.BottomPanel.Controls.Add(this.MainStatusStrip);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 300);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(727, 186);
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
            this.ExitButtonsSplitContainer.Size = new System.Drawing.Size(727, 164);
            this.ExitButtonsSplitContainer.SplitterDistance = 476;
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
            this.panel1.Size = new System.Drawing.Size(476, 164);
            this.panel1.TabIndex = 1;
            // 
            // ImageCancelExitButton
            // 
            this.ImageCancelExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageCancelExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageCancelExitButton.Location = new System.Drawing.Point(329, 24);
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
            this.OKExitButton.Location = new System.Drawing.Point(117, 102);
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
            this.CancelExitButton.Location = new System.Drawing.Point(117, 131);
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
            this.MainStatusStrip.Size = new System.Drawing.Size(727, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // FoldersTreeViewImageList
            // 
            this.FoldersTreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FoldersTreeViewImageList.ImageStream")));
            this.FoldersTreeViewImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.FoldersTreeViewImageList.Images.SetKeyName(0, "unknown.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(1, "movetomypcfolder.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(2, "movetomypcfolder.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(3, "movetodiskfolder.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(4, "movetodiskfolder.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(5, "folderclosed.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(6, "folderopen.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(7, "folder-closed-link--16--24bits.bmp");
            this.FoldersTreeViewImageList.Images.SetKeyName(8, "folder-open-link--16--24bits.bmp");
            // 
            // ItemsListViewSmallImageList
            // 
            this.ItemsListViewSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ItemsListViewSmallImageList.ImageStream")));
            this.ItemsListViewSmallImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.ItemsListViewSmallImageList.Images.SetKeyName(0, "unknown.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(1, "movetomypcfolder.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(2, "movetodiskfolder.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(3, "folderclosed.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(4, "unknown.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(5, "folder-link--16--24bits.bmp");
            this.ItemsListViewSmallImageList.Images.SetKeyName(6, "file-link--16--24bits.bmp");
            // 
            // ItemsListViewLargeImageList
            // 
            this.ItemsListViewLargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ItemsListViewLargeImageList.ImageStream")));
            this.ItemsListViewLargeImageList.TransparentColor = System.Drawing.Color.Teal;
            this.ItemsListViewLargeImageList.Images.SetKeyName(0, "file-24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(1, "mypc-24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(2, "drive--24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(3, "folder-24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(4, "file--32--24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(5, "folder-link--32--24bits.bmp");
            this.ItemsListViewLargeImageList.Images.SetKeyName(6, "file-link--32--24bits.bmp");
            // 
            // SpecialFoldersImageList
            // 
            this.SpecialFoldersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SpecialFoldersImageList.ImageStream")));
            this.SpecialFoldersImageList.TransparentColor = System.Drawing.Color.Teal;
            this.SpecialFoldersImageList.Images.SetKeyName(0, "file-24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(1, "mypc-24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(2, "drive--24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(3, "folder-24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(4, "mydocuments-24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(5, "mynetwork-24bits.bmp");
            this.SpecialFoldersImageList.Images.SetKeyName(6, "desktop-24bits.bmp");
            // 
            // FolderExplorerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 486);
            this.Controls.Add(this.MainPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderExplorerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "[FILEEXPLORAREDIALOG]";
            this.Shown += new System.EventHandler(this.FolderBrowserDialog_Shown);
            this.MainPanel.ResumeLayout(false);
            this.ExplorerPanel.ResumeLayout(false);
            this.SpecialFoldersSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpecialFoldersSplitContainer)).EndInit();
            this.SpecialFoldersSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
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
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ImageList FoldersTreeViewImageList;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripButton NewFolderToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MoveToParentFolderToolStripButton;
        private System.Windows.Forms.ToolStripButton RefreshItemToolStripButton;
        private System.Windows.Forms.Panel ExplorerPanel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.SplitContainer SpecialFoldersSplitContainer;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ImageList ItemsListViewSmallImageList;
        private System.Windows.Forms.ImageList ItemsListViewLargeImageList;
        private System.Windows.Forms.ImageList SpecialFoldersImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ViewSmallIconsToolStripButton;
        private System.Windows.Forms.ToolStripButton ViewLargelIconsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton DeleteFolderToolStripButton;
        private System.Windows.Forms.SplitContainer ExitButtonsSplitContainer;
        private System.Windows.Forms.Button OKExitButton;
        private System.Windows.Forms.Button CancelExitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ImageOKExitButton;
        private System.Windows.Forms.Button ImageCancelExitButton;
    }
}