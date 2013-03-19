namespace romo.windows.forms.InputBoxes
{
    partial class InputBoxBool
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
            this.DataGroupBox = new System.Windows.Forms.GroupBox();
            this.rdbtnTrue = new System.Windows.Forms.RadioButton();
            this.rdbtnFalse = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.DataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMain.Controls.Add(this.DataGroupBox);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(337, 297);
            this.pnlMain.TabIndex = 5;
            // 
            // DataGroupBox
            // 
            this.DataGroupBox.Controls.Add(this.rdbtnTrue);
            this.DataGroupBox.Controls.Add(this.rdbtnFalse);
            this.DataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGroupBox.Location = new System.Drawing.Point(13, 14);
            this.DataGroupBox.Name = "DataGroupBox";
            this.DataGroupBox.Size = new System.Drawing.Size(307, 105);
            this.DataGroupBox.TabIndex = 7;
            this.DataGroupBox.TabStop = false;
            this.DataGroupBox.Text = "{DataGroupBox}";
            // 
            // rdbtnTrue
            // 
            this.rdbtnTrue.AutoSize = true;
            this.rdbtnTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTrue.Location = new System.Drawing.Point(6, 67);
            this.rdbtnTrue.Name = "rdbtnTrue";
            this.rdbtnTrue.Size = new System.Drawing.Size(67, 30);
            this.rdbtnTrue.TabIndex = 1;
            this.rdbtnTrue.TabStop = true;
            this.rdbtnTrue.Text = "true";
            this.rdbtnTrue.UseVisualStyleBackColor = true;
            // 
            // rdbtnFalse
            // 
            this.rdbtnFalse.AutoSize = true;
            this.rdbtnFalse.Checked = true;
            this.rdbtnFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnFalse.Location = new System.Drawing.Point(6, 31);
            this.rdbtnFalse.Name = "rdbtnFalse";
            this.rdbtnFalse.Size = new System.Drawing.Size(76, 30);
            this.rdbtnFalse.TabIndex = 0;
            this.rdbtnFalse.TabStop = true;
            this.rdbtnFalse.Text = "false";
            this.rdbtnFalse.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(192, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 128);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(19, 157);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 128);
            this.btnOK.TabIndex = 5;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // InputBoxBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 297);
            this.Controls.Add(this.pnlMain);
            this.Name = "InputBoxBool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{InputBoxBool}";
            this.Activated += new System.EventHandler(this.InputBox_Activated);
            this.Shown += new System.EventHandler(this.InputBox_Shown);
            this.pnlMain.ResumeLayout(false);
            this.DataGroupBox.ResumeLayout(false);
            this.DataGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox DataGroupBox;
        private System.Windows.Forms.RadioButton rdbtnTrue;
        private System.Windows.Forms.RadioButton rdbtnFalse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

    }
}