using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using romo.shared.utilities;

namespace romo.windows.forms.FileSystem
{
    /// <summary>
    /// This is a form to create & select a folder,
    /// where several items (folders, files), will be stored,
    /// grouped by the new folder.
    /// </summary>
    public partial class FolderGroupForm : Form
    {
        #region "properties"

        protected string _SelectedPath = "";
        public string SelectedPath
        {
            get { return _SelectedPath; }
            set { _SelectedPath = value; }
        }

        protected string _SelectedFolderName = "";
        public string SelectedFolderName
        {
            get { return _SelectedFolderName; }
            set { _SelectedFolderName = value; }
        }

        protected bool _ShowImageExitButtons = false;
        /// <summary>
        /// Indicates if exit butons with images,
        /// should be display instead.
        /// </summary>
        public bool ShowImageExitButtons
        {
            get { return _ShowImageExitButtons; }
            set { _ShowImageExitButtons = value; }
        }

        #endregion "properties"

        #region "constructor"

        public FolderGroupForm()
        {
            InitializeComponent();

            // ...

            Bitmap resourceImage = null;

            resourceImage = romo.windows.forms.Properties.Resources.ok;
            Resources.AssignButtonBackgroundImage
                (ref this.ImageOKExitButton, resourceImage, true);

            resourceImage = romo.windows.forms.Properties.Resources.cancel;
            Resources.AssignButtonBackgroundImage
                (ref this.ImageCancelExitButton, resourceImage, true);
        } // FolderGroupForm()

        #endregion "constructor"


        protected void executeOKExitButton_Click()
        {
            /*
            bool CanSelect = (this.ItemsListView.SelectedItems.Count > 0);
            if (CanSelect)
            {
                PathListViewItem thisItem = (PathListViewItem)this.ItemsListView.SelectedItems[0];

                if (thisItem.IsFolder)
                {
                    String NormalizedPath = thisItem.Code;

                    this.SelectedPath =
                        romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(NormalizedPath);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    String ErrTitle = "Error";
                    String ErrMsg = "Selected a file";
                    romo.windows.forms.MessageBoxes.ErrorBox.Show(ErrMsg, ErrTitle);
                }
            }
            else
            {
                String ErrTitle = "Error";
                String ErrMsg = "No folder is selected";
                romo.windows.forms.MessageBoxes.ErrorBox.Show(ErrMsg, ErrTitle);
            }
            */
        } // void executeOKExitButton_Click(...)

        protected void executeCancelExitButton_Click()
        {
            this.SelectedPath = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        } // void executeCancelExitButton_Click(...)

        private void OKExitButton_Click(object sender, EventArgs e)
        {
            executeOKExitButton_Click();
        } // void OKExitButton_Click(...)

        private void CancelExitButton_Click(object sender, EventArgs e)
        {
            executeCancelExitButton_Click();
        } // void CancelExitButton_Click(...)

        private void ImageOKExitButton_Click(object sender, EventArgs e)
        {
            executeOKExitButton_Click();
        } // void ImageOKExitButton_Click(...)

        private void ImageCancelExitButton_Click(object sender, EventArgs e)
        {
            executeCancelExitButton_Click();
        } // void ImageCancelExitButton_Click(...)

        private void ParentFolderButton_Click(object sender, EventArgs e)
        {
            //
        } // void ParentFolderButton_Click(...)

        private void NewFolderNameValidateButton_Click(object sender, EventArgs e)
        {
            //
        } // void NewFolderNameValidateButton_Click(...)

        // ...

        public static DialogResult ShowFormModal(ref String ASelectedPath, ref String ASelectedFolderName)
        {
            DialogResult Result = DialogResult.None;

            FolderGroupForm thisForm = new FolderGroupForm();
            try
            {
                thisForm.SelectedPath = ASelectedPath;
                thisForm.SelectedFolderName = ASelectedFolderName;

                Result = thisForm.ShowDialog();

                ASelectedPath = thisForm.SelectedPath;
                ASelectedFolderName = thisForm.SelectedFolderName;
            }
            catch (DisposableException ex)
            {
                ex.Dispose();
                ex = null;
            }
            finally
            {
                thisForm.Dispose();
                thisForm = null;
            }

            return Result;
        } // static DialogResult ShowFormModal(...)

    } // class FolderGroupForm
} // namespace romo.windows.forms.FileSystem
