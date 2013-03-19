using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shell32;
using romo.shared.utilities;
using romo.shared.utilities.IO.Paths;
using romo.windows.forms;

namespace romo.windows.forms.FileSystem
{
    public enum SelectFileSystemTypeEnum
    {
        sfsUnknown,
        sfsOnlyDrives,  // no root, no folders, no files
        sfsOnlyFolders, // no drives, no root, no files
        sfsOnlyFiles,  
        sfsAnyFolder,   // no files, yes root, yes drives, yes folders
    }

    public struct ItemInfoStruct
    {
        public bool IsFile;
        public bool IsFolder;
        public bool IsLink;

        public Boolean IsDrive;
        public String Code;
        public String Text;

        public String LinkDestPath;
    } // struct ItemInfoStruct

    /// <summary>
    /// This is a form used to select a folder,
    /// from the filesystem. The graphical interface,
    /// it a reduced similar version of the "File Explorer"
    /// ( "File Manager" ) application.
    /// </summary>
    public partial class FolderExplorerDialog : Form
    {
        public List<ItemInfoStruct> FolderLinks = null;
        public List<ItemInfoStruct> FileLinks = null;

        #region "properties"
        protected PathTreeView _FoldersTreeView = null;
        public PathTreeView FoldersTreeView
        {
            get { return _FoldersTreeView; }
            set { _FoldersTreeView = value; }
        }

        protected PathListView _ItemsListView = null;
        public PathListView ItemsListView
        {
            get { return _ItemsListView; }
            set { _ItemsListView = value; }
        }

        protected PathListView _SpecialFoldersListView = null;
        public PathListView SpecialFoldersListView
        {
            get { return _SpecialFoldersListView; }
            set { _SpecialFoldersListView = value; }
        }

        protected PathTreeNode _RootNode = null;
        public PathTreeNode RootNode
        {
            get { return _RootNode; }
            set { _RootNode = value; }
        }

        protected string _Description = "";
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        protected string _RootFolder = "";
        public string RootFolder
        {
            get { return _RootFolder; }
            set { _RootFolder = value; }
        }

        protected string _SelectedPath = "";
        public string SelectedPath
        {
            get { return _SelectedPath; }
            set { _SelectedPath = value; }
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

        protected bool _ShowResizeButtons = false;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowResizeButtons
        {
            get { return _ShowResizeButtons; }
            set { _ShowResizeButtons = value; }
        }

        protected bool _ShowNewFolderButton = false;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowNewFolderButton
        {
            get { return _ShowNewFolderButton; }
            set { _ShowNewFolderButton = value; }
        }

        protected bool _ShowParentFolderButton = true;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowParentFolderButton
        {
            get { return _ShowParentFolderButton; }
            set { _ShowParentFolderButton = value; }
        }

        protected bool _ShowFiles = false;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowFiles
        {
            get { return _ShowFiles; }
            set { _ShowFiles = value; }
        }

        protected bool _ShowLinks = false;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowLinks
        {
            get { return _ShowLinks; }
            set { _ShowLinks = value; }
        }

        protected bool _ShowSpecialFoldersTab = false;
        /// <summary>
        /// Only before showing form.
        /// </summary>
        public bool ShowSpecialFoldersTab
        {
            get { return _ShowSpecialFoldersTab; }
            set { setShowSpecialFoldersTab(value); }
        }

        protected string _PathLabelCaption = "";
        public string PathLabelCaption
        {
            get { return _PathLabelCaption; }
            set { _PathLabelCaption = value; }
        }

        protected string _OKButtonCaption = "";
        public string OKButtonCaption
        {
            get { return _OKButtonCaption; }
            set { _OKButtonCaption = value; }
        }

        protected string _CancelButtonCaption = "";
        public string CancelButtonCaption
        {
            get { return _CancelButtonCaption; }
            set { _CancelButtonCaption = value; }
        }

        protected SelectFileSystemTypeEnum _SelectType = SelectFileSystemTypeEnum.sfsOnlyFiles;
        public SelectFileSystemTypeEnum SelectType
        {
            get { return _SelectType; }
            set { _SelectType = value; }
        }

        // ...

        #endregion "properties"

        #region "constructor"
        public FolderExplorerDialog()
        {
            InitializeComponent();

            // this goes "true" by default
            this._ShowParentFolderButton = true;

            /*
            this._OKButtonCaption = "Seleccionar";
            this._CancelButtonCaption = "Cancelar";
            this.Text = "Seleccionar Folder";
            */

            // ...

            Bitmap resourceImage = null;

            resourceImage = romo.windows.forms.Properties.Resources.ok;
            Resources.AssignButtonBackgroundImage
                (ref this.ImageOKExitButton, resourceImage, true);
            this.ImageOKExitButton.FlatStyle = FlatStyle.Standard;

            resourceImage = romo.windows.forms.Properties.Resources.cancel;
            Resources.AssignButtonBackgroundImage
                (ref this.ImageCancelExitButton, resourceImage, true);
            this.ImageCancelExitButton.FlatStyle = FlatStyle.Standard;
        }
        #endregion "constructor"

        protected void setShowSpecialFoldersTab(bool Value)
        {
            this._ShowSpecialFoldersTab = Value;
            this.SpecialFoldersSplitContainer.Panel1Collapsed = (! Value);
        } // void setShowSpecialFoldersTab(...)

        protected void LoadExplorer()
        {
            String NormalizedPath =
                romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(this.SelectedPath);

            romo.shared.utilities.IO.Paths.MainModule.NormalizedPathScanner
                Scanner = new romo.shared.utilities.IO.Paths.MainModule.NormalizedPathScanner();

            // "virtual pseudoconstructor"
            Scanner.Create();

            Scanner.SourcePath = NormalizedPath;

            String FolderName = "";
            romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum FileSystemType =
                romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum.fsUnknown;

            PathTreeNode LoadingCurrentNode = null;

            FoldersTreeView.Nodes.Clear();
            this.RootNode = null;
            PathTreeNode eachTreeNode = null;

            while (Scanner.readFolderType(out FolderName, out FileSystemType))
            {
                switch (FileSystemType)
                {
                    case MainModule.FileSystemTypeEnum.fsRoot:

                    // add "mypc" item
                    eachTreeNode = new PathTreeNode();
                    eachTreeNode.FileSystemType = FileSystemType;
                    eachTreeNode.Code = "^";
                    eachTreeNode.Text = "My PC";
                    eachTreeNode.ImageIndex = 1;
                    eachTreeNode.SelectedImageIndex = 2;

                    FoldersTreeView.Nodes.Add(eachTreeNode);
                    // select as current parent node
                    LoadingCurrentNode = eachTreeNode;

                    // mark selected node as root
                    this.RootNode = eachTreeNode;
                    break;

                    case MainModule.FileSystemTypeEnum.fsDrive:

                    // add new node as child of current node
                    eachTreeNode = new PathTreeNode();
                    eachTreeNode.FileSystemType = FileSystemType;
                    eachTreeNode.Code = FolderName;
                    eachTreeNode.Text = FolderName + ":";
                    eachTreeNode.ImageIndex = 3;
                    eachTreeNode.SelectedImageIndex = 4;

                    LoadingCurrentNode.Nodes.Add(eachTreeNode);

                    // select as current parent node
                    LoadingCurrentNode = eachTreeNode;

                    break;

                    case MainModule.FileSystemTypeEnum.fsFolder:

                    // add new node as child of current node
                    eachTreeNode = new PathTreeNode();
                    eachTreeNode.FileSystemType = FileSystemType;
                    eachTreeNode.Code = FolderName;
                    eachTreeNode.Text = FolderName;
                    eachTreeNode.ImageIndex = 5;
                    eachTreeNode.SelectedImageIndex = 6;

                    LoadingCurrentNode.Nodes.Add(eachTreeNode);
                    // select as current parent node
                    LoadingCurrentNode = eachTreeNode;

                    break;

                    /*
                    case MainModule.FileSystemTypeEnum.fsFile:

                    // add new node as child of current node
                    eachTreeNode = new PathTreeNode();
                    eachTreeNode.FileSystemType = FileSystemType;
                    eachTreeNode.Code = FolderName;
                    eachTreeNode.Text = FolderName;
                    eachTreeNode.ImageIndex = 5;
                    eachTreeNode.SelectedImageIndex = 6;

                    LoadingCurrentNode.Nodes.Add(eachTreeNode);
                    // select as current parent node
                    LoadingCurrentNode = eachTreeNode;

                    break;
                    */
                } // switch

            } // while

            this.RootNode.ExpandAll();

            FoldersTreeView.SelectedNode = LoadingCurrentNode;
            
            // "virtual pseudodestructor"
            Scanner.Destroy();

            //String EachFolder = RootFolder;

            // ...

        } // void LoadExplorer(...)

        protected void LoadCaptions()
        {
            this.PathLabel.Text = this._PathLabelCaption + ":";
            this.OKExitButton.Text = this._OKButtonCaption;
            this.CancelExitButton.Text = this._CancelButtonCaption;
        } // void LoadCaptions(...)

        protected void LoadFoldersTreeview()
        {
            this.FoldersTreeView = new PathTreeView();
                this.FoldersTreeView.Name = "FoldersTreeView";
                this.FoldersTreeView.Dock = DockStyle.Fill;
                this.FoldersTreeView.FullRowSelect = true;
                this.FoldersTreeView.HideSelection = false;
                this.FoldersTreeView.ImageList = this.FoldersTreeViewImageList;
                this.FoldersTreeView.PathSeparator = "/";

                this.FoldersTreeView.prepareItems();

                this.FoldersTreeView.AfterSelect  += this.FoldersTreeView_AfterSelect;
            this.MainSplitContainer.Panel1.Controls.Add(this.FoldersTreeView);
        } // void LoadFoldersTreeview(...)

        protected void LoadItemsListview()
        {
            this.ItemsListView = new PathListView();
                this.ItemsListView.Name = "ItemsListView";
                this.ItemsListView.Dock = DockStyle.Fill;
                this.ItemsListView.FullRowSelect = true;
                this.ItemsListView.HideSelection = false;
                this.ItemsListView.SmallImageList = this.ItemsListViewSmallImageList;
                this.ItemsListView.LargeImageList = this.ItemsListViewLargeImageList;
                this.ItemsListView.MultiSelect = false;
                //this.ItemsListView.View = View.List;
                //this.ItemsListView.View = View.SmallIcon;
                this.ItemsListView.View = View.LargeIcon;

                this.ItemsListView.prepareItems();

                this.ItemsListView.MouseDoubleClick += this.ItemsListView_MouseDoubleClick;

            this.MainSplitContainer.Panel2.Controls.Add(this.ItemsListView);
        } // void LoadItemsListview(...)

        protected void addSpecialFoldersListviewNode
            (int AImageIndex, String ACode, String AText)
        {
            PathListViewItem eachListViewItem = new PathListViewItem();
                eachListViewItem.Code = ACode;
                eachListViewItem.Text = AText;
                eachListViewItem.ImageIndex = AImageIndex;
            this.SpecialFoldersListView.ItemsWrapper.Add(eachListViewItem);
        } // void addSpecialFoldersListviewNode(...)

        protected void LoadSpecialFoldersListview()
        {
            this.SpecialFoldersListView = new PathListView();
            this.SpecialFoldersListView.Name = "SpecialFoldersListView";
            this.SpecialFoldersListView.Dock = DockStyle.Fill;
            this.SpecialFoldersListView.FullRowSelect = true;
            this.SpecialFoldersListView.HideSelection = false;
            this.SpecialFoldersListView.SmallImageList = null;
            this.SpecialFoldersListView.LargeImageList = this.SpecialFoldersImageList;
            this.SpecialFoldersListView.MultiSelect = false;
            this.SpecialFoldersListView.View = View.LargeIcon;

            this.SpecialFoldersListView.prepareItems();

            this.SpecialFoldersListView.Click += this.SpecialFoldersListView_Click;

            // add hard-coded special folders
            addSpecialFoldersListviewNode(1, @"^", "My PC");
            String MyDocumentsOSPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
            String MyDocumentsNormalizedPath =
                romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(MyDocumentsOSPath);
            addSpecialFoldersListviewNode(3, MyDocumentsNormalizedPath, "My Documents");

            String MyDesktopOSPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";
            String MyDesktopNormalizedPath =
                romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(MyDesktopOSPath);
            addSpecialFoldersListviewNode(6, MyDesktopNormalizedPath, "My Desktop");

            this.SpecialFoldersSplitContainer.Panel1.Controls.Add(this.SpecialFoldersListView);
        } // void LoadSpecialFoldersListview(...)

        private void FolderBrowserDialog_Shown(object sender, EventArgs e)
        {
            if (this.SelectedPath == "")
            {
                this.SelectedPath = System.IO.Directory.GetCurrentDirectory();
            }

            // change from relative path to absoulte path
            this.SelectedPath = System.IO.Path.GetFullPath(this.SelectedPath);

            this.FolderLinks = new List<ItemInfoStruct>();
            this.FileLinks = new List<ItemInfoStruct>();

            LoadCaptions();
            LoadFoldersTreeview();
            LoadItemsListview();
            LoadSpecialFoldersListview();
            LoadExplorer();

            this.ShowSpecialFoldersTab = this.ShowSpecialFoldersTab;

            this.MinimizeBox = this.ShowResizeButtons;
            this.MaximizeBox = this.ShowResizeButtons;

            this.ExitButtonsSplitContainer.Panel1Collapsed = (!this.ShowImageExitButtons);
            this.ExitButtonsSplitContainer.Panel2Collapsed = (this.ShowImageExitButtons);
        } // void FolderBrowserDialog_Shown(...)

        private void NewButtonToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBoxes.MessageBox.Show("create new folder !!!", "", MessageBoxButtons.OK);
        } // void NewButtonToolStripButton_Click(...)

        private void MoveToParentFolderToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBoxes.MessageBox.Show("Move to parent folder !!!", "", MessageBoxButtons.OK);
        }

        protected void selectOnlyFiles()
        {
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
                    romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
                }
            }
            else
            {
                String ErrTitle = "Error";
                String ErrMsg = "No folder is selected";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
            }
        } // void selectOnlyFiles(...)

        protected void selectOnlyDrives()
        {
            bool CanSelect = (this.FoldersTreeView.SelectedNode != null);
            if (CanSelect)
            {
                PathTreeNode thisItem = (PathTreeNode)this.FoldersTreeView.SelectedNode;


                // ...
            }
            else
            {
                String ErrTitle = "Error";
                String ErrMsg = "No folder is selected";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
            }
        } // void selectOnlyDrives(...)

        protected void selectOnlyFolders()
        {
            bool CanSelect = (this.FoldersTreeView.SelectedNode != null);
            if (CanSelect)
            {
                PathTreeNode thisItem = (PathTreeNode)this.FoldersTreeView.SelectedNode;

                String NormalizedPath = thisItem.Code;

                this.SelectedPath =
                    romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(NormalizedPath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                String ErrTitle = "Error";
                String ErrMsg = "No folder is selected";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
            }
        } // void selectOnlyFolders(...)

        protected void selectAnyFolder()
        {
            bool CanSelect = (this.FoldersTreeView.SelectedNode != null);
            if (CanSelect)
            {
                PathTreeNode thisItem = (PathTreeNode)this.FoldersTreeView.SelectedNode;

                String NormalizedPath = thisItem.Code;

                this.SelectedPath =
                    romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(NormalizedPath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                String ErrTitle = "Error";
                String ErrMsg = "No folder is selected";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
            }
        } // void selectAnyFolder(...)

        protected void executeOKExitButton_Click()
        {
            switch (this.SelectType)
            {
                case SelectFileSystemTypeEnum.sfsOnlyFiles:
                    selectOnlyFiles();
                break;

                case SelectFileSystemTypeEnum.sfsAnyFolder:
                    selectAnyFolder();
                break;

                case SelectFileSystemTypeEnum.sfsOnlyDrives:
                    selectOnlyDrives();
                break;

                case SelectFileSystemTypeEnum.sfsOnlyFolders:
                    selectOnlyFolders();
                break;

                default:
                    String ErrTitle = "Error";
                    String ErrMsg = "Selected Criteria doesn't match";
                    romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(ErrMsg, ErrTitle);
                break;
            } // switch
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
        } // void OKExitButton_Click(...)

        private void ImageCancelExitButton_Click(object sender, EventArgs e)
        {
            executeCancelExitButton_Click();
        } // void ImageCancelExitButton_Click(...)

        protected void updatePathBarByTreeNode(PathTreeNode ANode)
        {
            String thisFullPath = "";

            bool IsRootNode = (ANode == this.RootNode);
            if (IsRootNode)
            {
                thisFullPath = ANode.Text;
            }
            else
            {
                thisFullPath = ANode.ExpandPath();
                thisFullPath = romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(thisFullPath);
            }

            // mostrar ruta en barra de direcciones
            thisFullPath += @"\";
            PathTextBox.Text = thisFullPath;
        } // void updatePathBarByTreeNode(...)

        protected PathTreeNode addFoldersTreeviewNode
            (PathTreeNode AParentNode, ItemInfoStruct thisItemInfo)
        {
            PathTreeNode Result = null;

            // add new node as child of current node

                Result = new PathTreeNode();
                Result.Code = thisItemInfo.Code;
                Result.Text = thisItemInfo.Text;

                Result.IsFolder = thisItemInfo.IsFolder;
                Result.IsFile = thisItemInfo.IsFile;
                Result.IsLink = thisItemInfo.IsLink;

                Result.LinkDestPath = thisItemInfo.LinkDestPath;

                if (thisItemInfo.IsDrive)
                {
                    // drives doesn't have "shorcuts"
                    Result.ImageIndex = 3;
                    Result.SelectedImageIndex = 4;
                }
                else
                {
                    Result.ImageIndex = (thisItemInfo.IsLink ? 7 : 5);
                    Result.SelectedImageIndex = (thisItemInfo.IsLink ? 8 : 6);
                }
                AParentNode.Nodes.Add(Result);

            return Result;
        } // PathTreeNode addFoldersTreeviewNode(...)

        protected void addItemsListviewNode
            (ItemInfoStruct thisItemInfo)
        {
            PathListViewItem eachListViewItem = new PathListViewItem();
                eachListViewItem.Code     = thisItemInfo.Code;
                eachListViewItem.Text     = thisItemInfo.Text;

                eachListViewItem.IsFolder = thisItemInfo.IsFolder;
                eachListViewItem.IsFile   = thisItemInfo.IsFile;
                eachListViewItem.IsLink   = thisItemInfo.IsLink;

                eachListViewItem.LinkDestPath = thisItemInfo.LinkDestPath;

                if (thisItemInfo.IsDrive)
                {
                    eachListViewItem.ImageIndex = (thisItemInfo.IsLink ? 4 : 2);
                }
                else
                {
                    if (thisItemInfo.IsFolder)
                    {
                        eachListViewItem.ImageIndex = (thisItemInfo.IsLink ? 5 : 3);
                    }
                    else
                    {
                        eachListViewItem.ImageIndex = 0;
                    }
                }
            this.ItemsListView.ItemsWrapper.Add(eachListViewItem);
        } // void addItemsListviewNode(...)

        protected void updateDrivesByTreeNode(PathTreeNode AParentNode)
        {
            System.IO.DriveInfo[] Drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo eachDriveInfo in Drives)
            {
                if (eachDriveInfo.IsReady)
                {
                    ItemInfoStruct thisItemInfo = new ItemInfoStruct();

                    thisItemInfo.Code =
                        romo.shared.utilities.Strings.MainModule.LeftCopyByLength(eachDriveInfo.Name, 1);

                    thisItemInfo.Text =
                        romo.shared.utilities.Strings.MainModule.LeftCopyByLength(eachDriveInfo.Name, 2);

                    thisItemInfo.LinkDestPath = "";

                    thisItemInfo.IsDrive = true;

                    thisItemInfo.IsFile = false;
                    thisItemInfo.IsFolder = true;
                    thisItemInfo.IsLink = false;

                    PathTreeNode thisTreeNode =
                        addFoldersTreeviewNode(AParentNode, thisItemInfo);

                    String AFullPath = thisTreeNode.ExpandPath();
                    thisItemInfo.Code = AFullPath;
                    addItemsListviewNode(thisItemInfo);
                } // if (eachDriveInfo.IsReady)
            } // foreach
        } // void updateDrivesByTreeNode(...)

        protected void updateFoldersByTreeNode(PathTreeNode AParentNode)
        {
            PathTreeNode thisParentNode = (PathTreeNode)AParentNode;
            String thisFullPath = AParentNode.ExpandPath();

            thisFullPath = romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(thisFullPath);
            thisFullPath += @"\";

            string[] Directories = System.IO.Directory.GetDirectories(thisFullPath);
            foreach (string eachFolderFullPath in Directories)
            {
                String eachPlainFolderName = System.IO.Path.GetFileName(eachFolderFullPath);

                ItemInfoStruct thisItemInfo = new ItemInfoStruct();

                thisItemInfo.IsDrive = false;
                thisItemInfo.Code    = eachPlainFolderName;
                thisItemInfo.Text    = eachPlainFolderName;
                thisItemInfo.LinkDestPath = "";

                thisItemInfo.IsFile = false;
                thisItemInfo.IsFolder = true;
                thisItemInfo.IsLink = false;

                PathTreeNode thisTreeNode =
                    addFoldersTreeviewNode(AParentNode, thisItemInfo);

                String AFullPath = thisTreeNode.ExpandPath();
                thisItemInfo.Code = AFullPath;
                addItemsListviewNode(thisItemInfo);
            } // foreach

            foreach (ItemInfoStruct eachFolderInfo in this.FolderLinks)
            {
                PathTreeNode thisTreeNode =
                    addFoldersTreeviewNode(AParentNode, eachFolderInfo);

                addItemsListviewNode(eachFolderInfo);
            } // foreach
        } // void updateFoldersByTreeNode(...)

        protected void updateFilesByTreeNode(PathTreeNode AParentNode)
        {
            PathTreeNode thisParentNode = (PathTreeNode)AParentNode;
            String thisFullPath = AParentNode.ExpandPath();

            thisFullPath = romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(thisFullPath);
            thisFullPath += @"\";

            string[] Files = System.IO.Directory.GetFiles(thisFullPath);
            foreach (string eachFileFullPath in Files)
            {
                String eachPlainFileName = System.IO.Path.GetFileName(eachFileFullPath);
                String eachFileExtension = System.IO.Path.GetExtension(eachPlainFileName);

                bool IsLink = (eachFileExtension == ".lnk");
                if (! IsLink)
                {
                    ItemInfoStruct thisItemInfo = new ItemInfoStruct();

                    thisItemInfo.IsDrive = false;
                    thisItemInfo.Code = eachPlainFileName;
                    thisItemInfo.Text = eachPlainFileName;

                    thisItemInfo.LinkDestPath = "";

                    thisItemInfo.IsFile = true;
                    thisItemInfo.IsFolder = false;
                    thisItemInfo.IsLink = false;

                    String AFullPath =
                        romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(eachFileFullPath);                    
                    thisItemInfo.Code = AFullPath;

                    addItemsListviewNode(thisItemInfo);
                } // if (! IsLink)
            } // foreach

            foreach (ItemInfoStruct eachFileInfo in this.FileLinks)
            {
                addItemsListviewNode(eachFileInfo);
            } // foreach
        } // void updateFilesByTreeNode(...)

        public static bool GetShortcutTargetFile
            (string shortcutFilename, out String TargetPath, out String TargetDescr)
        {
            bool Result = false;

            TargetPath = string.Empty;
            TargetDescr = string.Empty;

            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);

            Result = (folderItem != null);
            if (Result)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                TargetPath  = link.Path;
                //TargetDescr = link.Description;

                String FileName = System.IO.Path.GetFileName(link.Path);
                TargetDescr = FileName;
            } // if (Result)

            return Result;
        } // static bool GetShortcutTargetFile(...)

        protected void loadLinksByTreeNode(PathTreeNode AParentNode)
        {
            PathTreeNode thisParentNode = (PathTreeNode)AParentNode;
            if (this.RootNode != thisParentNode)
            {
                String thisFullPath = AParentNode.ExpandPath();

                thisFullPath = romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(thisFullPath);
                thisFullPath += @"\";

                string[] Files = System.IO.Directory.GetFiles(thisFullPath);
                foreach (string eachFileFullPath in Files)
                {
                    String eachPlainFileName = System.IO.Path.GetFileName(eachFileFullPath);
                    String eachFileExtension = System.IO.Path.GetExtension(eachPlainFileName);

                    bool IsLink = (eachFileExtension == ".lnk");
                    if (IsLink)
                    {
                        ItemInfoStruct thisItemInfo = new ItemInfoStruct();
                        thisItemInfo.IsDrive = false;
                        thisItemInfo.IsLink = true;

                        String AOSPath = string.Empty;
                        String ADescr  = string.Empty;

                        // to-do: add showfilelinks, showfolderlinks

                        bool Result = GetShortcutTargetFile(eachFileFullPath, out AOSPath, out ADescr);
                        if (Result)
                        {
                            String ANormalizedPath =
                                romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(AOSPath);

                            thisItemInfo.LinkDestPath = ANormalizedPath;

                            // file or folder ?
                            thisItemInfo.IsFolder = (System.IO.Directory.Exists(AOSPath));
                            thisItemInfo.IsFile = (!thisItemInfo.IsFolder);

                            String AFullPath =
                                romo.shared.utilities.IO.Paths.MainModule.OSPathToNormalizedPath(eachFileFullPath);
                            thisItemInfo.Code = AFullPath;

                            String DestFullPath = System.IO.Path.GetFileName(AOSPath);
                            //thisItemInfo.Text = DestFullPath;

                            thisItemInfo.Text = ADescr;

                            if (thisItemInfo.IsFolder)
                            {
                                this.FolderLinks.Add(thisItemInfo);
                            }
                            else
                            {
                                this.FileLinks.Add(thisItemInfo);
                            }
                        }
                    } // if (IsLink)
                } // foreach
            } // if (this.RootNode != thisParentNode)
        } // void loadLinksByTreeNode(...)

        protected void updateNodeItemsByTreeNode(PathTreeNode AParentNode)
        {
            // remove the treenodes existing subnodes
            AParentNode.Nodes.Clear();

            // remove all items from the items listview
            ItemsListView.Clear();

            this.FolderLinks.Clear();
            this.FileLinks.Clear();
            if (this.ShowLinks)
            {
                loadLinksByTreeNode(AParentNode);
            } // if (this.ShowLinks)

            bool IsRoot = (AParentNode == this.RootNode);
            if (IsRoot)
            {
                updateDrivesByTreeNode(AParentNode);
            }
            else
            {
                updateFoldersByTreeNode(AParentNode);
                if (this.ShowFiles)
                {
                    updateFilesByTreeNode(AParentNode);
                } // if (this.ShowFiles)
            }
        } // void updateNodeItemsByTreeNode(...)

        private void FoldersTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PathTreeNode thisTreeNode = (PathTreeNode)e.Node;
            updatePathBarByTreeNode(thisTreeNode);
            updateNodeItemsByTreeNode(thisTreeNode);
            thisTreeNode.ExpandAll();
        } // void FoldersTreeView_AfterSelect(...)

        private void RefreshItemToolStripButton_Click(object sender, EventArgs e)
        {
            //
        } // void RefreshItemToolStripButton_Click(...)

        private void ItemsListView_MouseDoubleClick(object sender, EventArgs e)
        {
            //PathTreeNode thisTreeNode = (PathTreeNode)e;
            //MessageBox.Show(String.Format("{0}: Hello World", sender.ToString()));

            MessageBox.Show(String.Format("{0}: Hello World", e.ToString()));

            //PathListViewItem = 

        } // void ItemsListView_MouseDoubleClick(...)

        private void SpecialFoldersListView_Click(object sender, EventArgs e)
        {
            PathListViewItem thisItem = (PathListViewItem)this.SpecialFoldersListView.SelectedItems[0];

            String thisNormalizedPath = thisItem.Code;
            String thisOSPath =
                romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(thisNormalizedPath);

            // change from relative path to absolute path
            this.SelectedPath = thisOSPath;

            FoldersTreeView.Nodes.Clear();

            //LoadCaptions();
            //LoadFoldersTreeview();
            //LoadItemsListview();
            //LoadSpecialFoldersListview();
            LoadExplorer();
        } // void SpecialFoldersListView_Click(...)

        private void ViewSmallIconsToolStripButton_Click(object sender, EventArgs e)
        {
            this.ItemsListView.View = View.SmallIcon;
        } // void ViewSmallIconsToolStripButton_Click(...)

        private void ViewLargelIconsToolStripButton_Click(object sender, EventArgs e)
        {
            this.ItemsListView.View = View.LargeIcon;
        } // void ViewLargelIconsToolStripButton_Click(...)

        private void NewFolderToolStripButton_Click(object sender, EventArgs e)
        {
            PathTreeNode thisParentTreeNode = (PathTreeNode)this.FoldersTreeView.SelectedNode;
            if (thisParentTreeNode == this.RootNode)
            {
                String errMsg1   = "Cannot create a folder in root";
                String errTitle1 = "Create New Folder";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(errMsg1, errTitle1);
            }
            else
            {
                string Title = "Crear Folder";
                string Label = "Nombre";
                string Data = "";
                int Len = 1000;

                bool Captured = romo.windows.forms.InputBoxes.InputBox.ShowLen
                    (Title, Label, ref Data, Len);
                if (Captured)
                {
                    String NormalizedPath = thisParentTreeNode.ExpandPath();
                    NormalizedPath += "/" + Data;

                    String OSPath = romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(NormalizedPath);

                    bool IsDuplicated = (System.IO.Directory.Exists(OSPath));
                    if (IsDuplicated)
                    {
                        String errMsg2 = "A folder with the same name already exists.";
                        String errTitle2 = "Create New Folder";
                        romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(errMsg2, errTitle2);
                    }
                    else
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(OSPath);
                            this.FoldersTreeView.SelectedNode = thisParentTreeNode;
                        }
                        catch (DisposableException ex)
                        {
                            ex.Dispose();
                            ex = null;
                        }
                    } // if (IsDuplicated)
                } // if (Captured)
            } // if (thisParentTreeNode == this.RootNode)
        } // void NewFolderToolStripButton_Click(...)

        private void DeleteFolderToolStripButton_Click(object sender, EventArgs e)
        {
            PathTreeNode thisTreeNode = (PathTreeNode)this.FoldersTreeView.SelectedNode;
            if (thisTreeNode == this.RootNode)
            {
                String errText1 = "Cannot delete the root folder";
                String errTitle1 = "Delete selected Folder";
                romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(errText1, errTitle1);
            }
            else
            {
                PathTreeNode thisParentTreeNode = (PathTreeNode)thisTreeNode.Parent;
                bool IsDriveFolder = (thisParentTreeNode == this.RootNode);
                if (IsDriveFolder)
                {
                    String errText2 = "Cannot delete a drive folder";
                    String errTitle2 = "Delete selected Folder";
                    romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(errText2, errTitle2);
                }
                else
                {
                    String msgText = String.Format("Are you sure you want to delete: \"{0}\" ?", thisTreeNode.Text);
                    String msgTitle = "Delete selected Folder";
                    bool ConfirmDeletion =
                      (romo.windows.forms.MessageBoxes.ConfirmBox.Show(msgText, msgTitle) == System.Windows.Forms.DialogResult.Yes);
                    if (ConfirmDeletion)
                    {
                        String NormalizedPath = thisTreeNode.ExpandPath();
                        String OSPath =
                            romo.shared.utilities.IO.Paths.MainModule.NormalizedPathToOSPath(NormalizedPath);

                        bool IsEmpty = romo.shared.utilities.IO.Paths.MainModule.IsEmpty(OSPath);
                        if (!IsEmpty)
                        {
                            String errText3 = "Folder is not empty";
                            String errTitle3 = "Delete selected Folder";
                            romo.windows.forms.MessageBoxes.ErrorBox.ShowTitle(errText3, errTitle3);
                        }
                        else
                        {
                            try
                            {
                                System.IO.Directory.Delete(OSPath);
                                this.FoldersTreeView.SelectedNode = thisParentTreeNode;
                            }
                            catch (DisposableException ex)
                            {
                                ex.Dispose();
                                ex = null;
                            }
                        }
                    } // if (ConfirmDeletion)
                } // if (IsDriveFolder)
            } // if (thisParentTreeNode == this.RootNode)
        } //  void DeleteFolderToolStripButton_Click(...)

        // ...

        public static DialogResult ShowFormModal(ref String ASelectedPath)
        {
            DialogResult Result = DialogResult.None;

            FolderExplorerDialog thisForm = new FolderExplorerDialog();
            try
            {
                thisForm.SelectedPath = ASelectedPath;

                Result = thisForm.ShowDialog();

                ASelectedPath = thisForm.SelectedPath;
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

        // ...

    } // class FolderBrowserDialog 

    // ...

} // namespace romo.windows.forms
