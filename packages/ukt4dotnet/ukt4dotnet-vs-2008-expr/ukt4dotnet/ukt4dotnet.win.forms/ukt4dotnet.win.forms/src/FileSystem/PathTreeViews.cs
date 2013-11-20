using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.utilities.IO.Paths;

namespace ukt4dotnet.win.forms.FileSystem
{
    /// <summary>
    /// Its a class that "wraps" some of its members, 
    /// each one, with a new identifier,
    /// in order to reuse their previous identifiers.
    /// </summary>
    public class InternalTreeView : TreeView
    {
        protected TreeNodeCollection InternalNodes()
        {
            TreeNodeCollection Result = this.Nodes;

            // ...

            return Result;
        } // TreeNodeCollection InternalNodes(...)
    } // class InternalTreeView 

    public class PathTreeNode : TreeNode
    {
        #region "properties"
        protected ukt4dotnet.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum _FileSystemType;
        public ukt4dotnet.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum FileSystemType
        {
            get { return _FileSystemType; }
            set { _FileSystemType = value; }
        }

        protected String _Code;
        public String Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        protected String _LinkDestPath;
        public String LinkDestPath
        {
            get { return _LinkDestPath; }
            set { _LinkDestPath = value; }
        }

        protected bool _IsFile = false;
        public bool IsFile
        {
            get { return _IsFile; }
            set { _IsFile = value; }
        }

        protected bool _IsFolder = false;
        public bool IsFolder
        {
            get { return _IsFolder; }
            set { _IsFolder = value; }
        }

        protected bool _IsLink = false;
        public bool IsLink
        {
            get { return _IsLink; }
            set { _IsLink = value; }
        }
        #endregion "properties"

        #region "constructor"
        public PathTreeNode() : base()
        {
            this._Code = "";
        }

        public PathTreeNode(
	        string text
        )
            : base(text)
        {
            this._Code = text;
        }

        protected PathTreeNode(
	        SerializationInfo serializationInfo,
	        StreamingContext context
        )
            : base(serializationInfo, context)
        {
            //this._Code = "";
        }

        public PathTreeNode(
	        string text,
	        int imageIndex,
	        int selectedImageIndex
        ) : base(text, imageIndex, selectedImageIndex)
        {
            this._Code = text;
        }

        public PathTreeNode(
	        string text,
	        TreeNode[] children
        )
            : base(text, children)
        {
            this._Code = text;
        }

        public PathTreeNode(
	        string text,
	        int imageIndex,
	        int selectedImageIndex,
	        TreeNode[] children
        )
            : base(text, imageIndex, selectedImageIndex, children)
        {
            this._Code = text;
        }
        #endregion "constructor"

        public virtual String ExpandPath()
        {
            String Result = "";

            PathTreeNode ParentNode =(PathTreeNode)this.Parent;
            if (ParentNode != null)
            {
                String Temp = ParentNode.ExpandPath();
                if (Temp != "")
                {
                    Result += Temp;
                    Result += this.TreeView.PathSeparator;
                }
            }
            Result += this.Code;

            return Result;
        } // String ExpandPath(...)

        // ...

    } // class PathTreeNode 

    /// <summary>
    /// Since the <code>TreeView.Nodes</code> property,
    /// cannot be directly, overriden, we use this "adapter",
    /// class, to indirectly override that member.
    /// </summary>
    public class TreeNodeCollectionWrapper :
        IEnumerable, ICollection, IList
    {
        #region "properties"

        protected InternalTreeView _TreeView;
        public InternalTreeView TreeView
        {
            get { return _TreeView; }
            set { _TreeView = value; }
        }

        protected TreeNodeCollection _TreeCollection;
        public TreeNodeCollection TreeCollection
        {
            get { return _TreeCollection; }
            set { _TreeCollection = value; }
        }

        public virtual Object this[int index]
        {
            get { return IList_getAt(index); }
            set { IList_setAt(index, value); }
        }

        #endregion "properties"

        // ...

        #region "methods-IEnumerable"

        protected virtual IEnumerator IEnumerable_GetEnumerator()
        {
            IEnumerator Result = (IEnumerator)this.TreeCollection;

            return Result;
        } // IEnumerator IEnumerable_GetEnumerator(...)

        #endregion "methods-IEnumerable"

        #region "methods-ICollection"

        protected /* nonvirtual */ int ICollection_getCount()
        {
            int Result = this.TreeCollection.Count;

            return Result;
        } // int ICollection_getCount(...)

        protected virtual Object ICollection_getSyncRoot()
        {
            Object Result = null;

            ICollection thisCollection = (ICollection)this.TreeCollection;
            Result = thisCollection.SyncRoot;

            return Result;
        } // Object ICollection_getSyncRoot(...)

        protected virtual bool ICollection_getIsSynchronized()
        {
            bool Result = false;

            ICollection thisCollection = (ICollection)this.TreeCollection;
            Result = thisCollection.IsSynchronized;

            return Result;
        } // bool ICollection_getIsSynchronized(...)

        protected virtual void ICollection_CopyTo(Array array, int index)
        {
            this.TreeCollection.CopyTo(array, index);
        } // void ICollection_CopyTo(...)

        #endregion "methods-ICollection"

        #region "methods-IList"

        protected virtual bool IList_IsFixedSize()
        {
            bool Result = false;

            IList thisList = (IList)this.TreeCollection;
            Result = thisList.IsFixedSize;

            return Result;
        } // bool IList_IsFixedSize(...)

        protected virtual bool IList_IsReadOnly()
        {
            bool Result = false;

            IList thisList = (IList)this.TreeCollection;
            Result = thisList.IsReadOnly;

            return Result;
        } // bool IList_IsReadOnly(...)

        protected virtual int IList_Add(Object node)
        {
            int Result = -1;

            IList thisList = (IList)this.TreeCollection;
            Result = thisList.Add(node);

            return Result;
        } // int IList_Add(...)

        protected virtual void IList_Clear()
        {
            IList thisList = (IList)this.TreeCollection;
            thisList.Clear();
        } // void IList_Clear(...)

        protected virtual bool IList_Contains(Object node)
        {
            bool Result = false;

            IList thisList = (IList)this.TreeCollection;
            Result = thisList.Contains(node);

            return Result;
        } // bool IList_Contains(...)

        protected virtual int IList_IndexOf(Object node)
        {
            int Result = -1;

            IList thisList = (IList)this.TreeCollection;
            Result = thisList.IndexOf(node);

            return Result;
        } // int IList_IndexOf(...)

        public virtual void IList_Insert(int index, Object node)
        {
            IList thisList = (IList)this.TreeCollection;
            thisList.Insert(index, node);
        } // void IList_Insert(...)

        protected virtual void IList_Remove(Object node)
        {
            IList thisList = (IList)this.TreeCollection;
            thisList.Remove(node);
        } // void IList_Remove(...) 

        protected virtual void IList_RemoveAt(int index)
        {
            IList thisList = (IList)this.TreeCollection;
            thisList.RemoveAt(index);
        } // void IList_RemoveAt(...) 

        protected virtual Object IList_getAt(int index)
        {
            Object Result = null;

            PathTreeNode thisNode = (PathTreeNode)this.TreeCollection[index];

            Result = (Object)thisNode;
            return Result;
        } // Object IList_getAt(...)

        protected virtual void IList_setAt(int index, Object value)
        {
            if (this.IsPathTreeNode(value))
            {
                this.TreeCollection[index] = (TreeNode)value;
            }
            else
            {
                throw new InvalidCastException();
            }
        } // void IList_setAt(...)

        #endregion "methods-IList"

        // ...

        #region "interface-IEnumerable"
        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator Result = IEnumerable_GetEnumerator();

            return Result;
        } // IEnumerator IEnumerable.GetEnumerator(...)
        #endregion "interface-IEnumerable"

        #region "interface-ICollection"

        int ICollection.Count
        {
            get { return ICollection_getCount(); }
        }

        Object ICollection.SyncRoot
        {
            get { return ICollection_getSyncRoot(); }
        }

        bool ICollection.IsSynchronized
        {
            get { return ICollection_getIsSynchronized(); }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ICollection_CopyTo(array, index);
        } // void ICollection.CopyTo(...)

        // ...

        #endregion "interface-ICollection"

        #region "interface-IList"

        /* intfscope */ bool IList.IsFixedSize
        {
            get { return IList_IsFixedSize(); }
        }

        /* intfscope */ bool IList.IsReadOnly
        {
            get { return IList_IsReadOnly(); }
        }

        /* intfscope */ int IList.Add(Object node)
        {
            int Result = IList_Add(node);

            // ...

            return Result;
        } // int IList.Add(...)

        /* intfscope */ void IList.Clear()
        {
            IList_Clear();
        } // void IList.Clear(...)

        /* intfscope */ bool IList.Contains(Object node)
        {
            bool Result = IList_Contains(node);

            // ...

            return Result;
        } // bool IList.Contains(...)

        /* intfscope */ int IList.IndexOf(Object node)
        {
            int Result = -1;

            // ...

            return Result;
        } // int IList.IndexOf(...)

        /* intfscope */ void IList.Insert(int index, Object node)
        {
            this.IList_Insert(index, node);
        } // void IList.Insert(...)

        /* intfscope */ void IList.Remove(Object node)
        {
            this.IList_Remove(node);
        } // void IList.Remove(...) 

        /* intfscope */ void IList.RemoveAt(int index)
        {
            this.IList_RemoveAt(index);
        } // void IList.RemoveAt(...) 

        #endregion "interface-IList"

        // ...

        #region "TreeNodeCollection-methods"

        public virtual int Add(TreeNode node)
        {
            int Result = this.AddByTreeNode(node);
            return Result;
        } // int Add(...)

        public virtual TreeNode Add(string text)
        {
            TreeNode Result = this.AddByText(text);
            return Result;
        } // TreeNode Add(...)

        public virtual TreeNode Add(
            string key, 
            string text)
        {
            TreeNode Result = this.AddKeyValue(key, text);
            return Result;
        } // TreeNode Add(...)

        public virtual TreeNode Add(
	        string key,
	        string text,
	        int imageIndex
        )
        {
            TreeNode Result = this.AddByKeyValueImgIndex(key, text, imageIndex);
            return Result;
        } // TreeNode Add(...)

        public virtual TreeNode Add(
	        string key,
	        string text,
	        string imageKey
        )
        {
            TreeNode Result = this.AddByKeyValueImgKey(key, text, imageKey);
            return Result;
        } // TreeNode Add(...)

        public virtual TreeNode Add(
	        string key,
	        string text,
	        int imageIndex,
	        int selectedImageIndex
        )
        {
            TreeNode Result =
                this.AddByKeyValueSelImgIndex(key, text, imageIndex, selectedImageIndex);
            return Result;
        } // TreeNode Add(...)

        public virtual TreeNode Add(
	        string key,
	        string text,
	        string imageKey,
	        string selectedImageKey
        )
        {
            TreeNode Result =
                this.AddByKeyValueSelImgKey(key, text, imageKey, selectedImageKey);
            return Result;
        } // TreeNode Add(...)

        public virtual void AddRange(TreeNode[] nodes)
        {
            foreach (TreeNode eachNode in nodes)
            {
                if (!this.IsPathTreeNode(eachNode))
                {
                    throw new InvalidCastException();
                }
            } // foreach

            this.TreeCollection.AddRange(nodes);
        } // void AddRange(...)

        public virtual void Insert(
            int index,
            TreeNode node
        )
        {
            this.InsertByTreeNode(index, node);
        } // void Insert(...)

        public virtual TreeNode Insert(
	        int index,
	        string text
        )
        {
            TreeNode Result =
                this.InsertByText(index, text);
            return Result;
        } // TreeNode Insert(...)

        public virtual TreeNode Insert(
	        int index,
	        string key,
	        string text
        )
        {           
            TreeNode Result =
                this.InsertByKeyValue(index, key, text);
            return Result;
        } // TreeNode Insert(...)

        public virtual TreeNode Insert(
	        int index,
	        string key,
	        string text,
	        int imageIndex
        )
        {
            TreeNode Result =
                this.InsertByKeyValueImgIndex(index, key, text, imageIndex);
            return Result;
        } // void Insert(...)

        public virtual TreeNode Insert(
	        int index,
	        string key,
	        string text,
	        string imageKey
        )
        {
            TreeNode Result =
                this.InsertByKeyValueImgKey(index, key, text, imageKey);
            return Result;
        } // void Insert(...)

        public virtual TreeNode Insert(
            int index,
            string key,
            string text,
            int imageIndex,
            int selectedImageIndex
        )
        {
            TreeNode Result =
                this.InsertByKeyValueSelImgIndex
                (index, key, text, imageIndex, selectedImageIndex);
            return Result;
        } // void Insert(...)

        public virtual TreeNode Insert(
	        int index,
	        string key,
	        string text,
	        string imageKey,
	        string selectedImageKey
        )
        {
            TreeNode Result =
                this.InsertByKeyValueSelImgKey
                (index, key, text, imageKey, selectedImageKey);
            return Result;
        } // void Insert(...)

        #endregion "TreeNodeCollection-methods"

        #region "methods"

        public override string ToString()
        {
            string Result = this.TreeCollection.ToString();
            return Result;
        } // string ToString(...)

        public bool IsPathTreeNode(Object Node)
        {
            bool Result = (Node is PathTreeNode);

            return Result;
        } // bool IsPathTreeNode(...)

        public TreeNodeCollection Items()
        {
            TreeNodeCollection Result = this.TreeCollection;

            return Result;
        } // TreeNodeCollection Items(...)

        public virtual int AddByTreeNode(TreeNode node)
        {
            int Result = -1;

            if (this.IsPathTreeNode(node))
            {
                Result = this.TreeCollection.Add(node);
            }
            else
            {
                throw new InvalidCastException();
            }

            return Result;
        } // int AddByTreeNode(...)

        public virtual void InsertByTreeNode(
            int index,
            TreeNode node
        )
        {
            if (this.IsPathTreeNode(node))
            {
                this.TreeCollection.Insert(index, node);
            }
            else
            {
                throw new InvalidCastException();
            }
        } // void InsertByTreeNode(...)

        protected /* nonvirtual */ int AddPathNode(PathTreeNode node)
        {
            int Result = -1;

            TreeNode thisNode = (TreeNode)node;
            Result = this.TreeCollection.Add(thisNode);

            return Result;
        } // int AddPathNode(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByText(string text)
        {
            PathTreeNode Result = new PathTreeNode();
            Result.Text = text;

            return Result;
        } // PathTreeNode NewNodeByText(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByKeyValue(
            string key, string value)
        {
            PathTreeNode Result = new PathTreeNode();
            Result.Name = key;
            Result.Text = value;

            return Result;
        } // PathTreeNode NewNodeByKeyValue(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByKeyValueImgIndex(
            string key, string value, int ImageIndex)
        {
            PathTreeNode Result = new PathTreeNode();
                Result.Name = key;
                Result.Text = value;
                Result.ImageIndex = ImageIndex;

            return Result;
        } // PathTreeNode NewNodeByKeyValueImgIndex(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByKeyValueImgKey(
            string key, string value, string ImageKey)
        {
            PathTreeNode Result = new PathTreeNode();
                Result.Name = key;
                Result.Text = value;
                Result.ImageKey = ImageKey;
            return Result;
        } // PathTreeNode NewNodeByKeyValueImgKey(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByKeyValueSelImgIndex(
            string key, string value, int ImageIndex, int SelImageIndex)
        {
            PathTreeNode Result = new PathTreeNode();
                Result.Name = key;
                Result.Text = value;
                Result.ImageIndex = ImageIndex;
                Result.SelectedImageIndex = SelImageIndex;
            return Result;
        } // PathTreeNode NewNodeByKeyValueSelImgIndex(...)

        protected /* nonvirtual */ PathTreeNode NewNodeByKeyValueSelImgKey(
            string key, string value, string ImageKey, string SelImageKey)
        {
            PathTreeNode Result = new PathTreeNode();
                Result.Name = key;
                Result.Text = value;
                Result.ImageKey = ImageKey;
                Result.SelectedImageKey = SelImageKey;
            return Result;
        } // PathTreeNode NewNodeByKeyValueSelImgKey(...)

        public virtual TreeNode AddByText(string text)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByText(text);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddText(...)

        public virtual TreeNode AddKeyValue(string key, string value)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValue(key, value);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddKeyValue(...)

        public virtual TreeNode AddByKeyValueImgIndex
            (string key, string value, int ImageIndex)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueImgIndex(key, value, ImageIndex);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddKeyValueImgIndex(...)

        public virtual TreeNode AddByKeyValueImgKey
            (string key, string value, string ImageKey)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueImgKey(key, value, ImageKey);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddKeyValueImgKey(...)

        public virtual TreeNode AddByKeyValueSelImgIndex
            (string key, string value, int ImageIndex, int SelImageIndex)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueSelImgIndex(key, value, ImageIndex, SelImageIndex);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddKeyValueImgKey(...)

        public virtual TreeNode AddByKeyValueSelImgKey
            (string key, string value, string ImageKey, string SelImageKey)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueSelImgKey(key, value, ImageKey, SelImageKey);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode AddKeyValueSelImgKey(...)

        public virtual TreeNode InsertByText(int index, string text)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByText(text);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertString(...)

        public virtual TreeNode InsertByKeyValue
            (int index, string key, string value)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValue(key, value);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertKeyValue(...)

        public virtual TreeNode InsertByKeyValueImgIndex
            (int index, string key, string value, int ImageIndex)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueImgIndex(key, value, ImageIndex);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertKeyValueImgIndex(...)

        public virtual TreeNode InsertByKeyValueImgKey
            (int index, string key, string value, string ImageKey)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueImgKey(key, value, ImageKey);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertKeyValueImgIndex(...)

        public virtual TreeNode InsertByKeyValueSelImgIndex
            (int index, string key, string value, int ImageIndex, int SelImageIndex)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueSelImgIndex(key, value, ImageIndex, SelImageIndex);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertKeyValueSelImgIndex(...)

        public virtual TreeNode InsertByKeyValueSelImgKey
            (int index, string key, string value, string ImageKey, string SelImageKey)
        {
            TreeNode Result = null;

            PathTreeNode thisNode =
                NewNodeByKeyValueSelImgKey(key, value, ImageKey, SelImageKey);
            this.InsertByTreeNode(index, thisNode);

            Result = (TreeNode)thisNode;
            return Result;
        } // TreeNode InsertKeyValueSelImgKey(...)

        public virtual int IndexOfKey(string key)
        {
            int Result = this.TreeCollection.IndexOfKey(key);

            return Result;
        } // int IndexOfKey(...)

        public TreeNode[] Find(
	        string key,
	        bool searchAllChildren
        )
        {
            TreeNode[] Result =
                this.TreeCollection.Find(key, searchAllChildren);

            return Result;
        } // TreeNode[] Find(...)

        public virtual void RemoveByKey(string key)
        {
            this.TreeCollection.RemoveByKey(key);
        } // int IndexOfKey(...)

        public virtual bool ContainsKey(string key)
        {
            this.TreeCollection.RemoveByKey(key);

            bool Result =
                this.TreeCollection.ContainsKey(key);

            return Result;

        } // int ContainsKey(...)

        public override int GetHashCode()
        {
            int Result =
                this.TreeCollection.GetHashCode();
            return Result;
        } // int GetHashCode(...)

        public override bool Equals(Object obj)
        {
            bool Result = 
                this.TreeCollection.Equals(obj);
            return Result;
        } // bool Equals(...)

        #endregion "methods"

        // ...

    } // class TreeNodeCollectionWrapper 

    public class PathTreeView : InternalTreeView
    {
        #region "properties"

        protected TreeNodeCollectionWrapper _NodesWrapper;
        public TreeNodeCollectionWrapper NodesWrapper
        {
            get { return _NodesWrapper; }
            set { _NodesWrapper = value; }
        }

        // ...

        #endregion "properties"

        #region "constructor"

        public PathTreeView()
            : base()
        {
            this._NodesWrapper = null;
        }

        // ...

        #endregion "constructor"

        public virtual void prepareItems()
        {
            this._NodesWrapper = new TreeNodeCollectionWrapper();
            this._NodesWrapper.TreeView = this;
            this._NodesWrapper.TreeCollection = this.Nodes;
        } // void prepareItems(...)

        // ...

    } // class PathTreeView 

    // ...

} // namespace
