using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using romo.shared.utilities;
using romo.shared.utilities.IO.Paths;

namespace romo.windows.forms.FileSystem
{
    /// <summary>
    /// Its a class that "wraps" some of its members, 
    /// each one, with a new identifier,
    /// in order to reuse their previous identifiers.
    /// </summary>
    public class InternalPathListView : ListView
    {
        protected ListViewItemCollection InternalItems()
        {
            ListViewItemCollection Result = this.Items;

            // ...

            return Result;
        } // ListViewItemCollection InternalItems(...)
    } // class InternalPathListView 

    public class PathListViewItem : ListViewItem
    {
        #region "properties"
        protected romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum _FileSystemType;
        public romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum FileSystemType
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
        public PathListViewItem()
            : base()
        {
            this._Code = "";
        }

        // ...

        #endregion "constructor"

    } // class PathListViewItem 
    
    /// <summary>
    /// Since the <code>ListView.Items</code> property,
    /// cannot be directly, overriden, we use this "adapter",
    /// class, to indirectly override that member.
    /// </summary>
    public class ListViewItemCollectionWrapper :
        IEnumerable, ICollection, IList
    {
        #region "properties"

        protected InternalPathListView _ListView;
        public InternalPathListView ListView
        {
            get { return _ListView; }
            set { _ListView = value; }
        }

        protected ListView.ListViewItemCollection _ItemsCollection;
        public ListView.ListViewItemCollection ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; }
        }

        public virtual Object this[int index]
        {
            get { return IList_getAt(index); }
            set { IList_setAt(index, value); }
        }

        // ...

        #endregion "properties"

        // ...

        #region "methods-IEnumerable"

        protected virtual IEnumerator IEnumerable_GetEnumerator()
        {
            IEnumerator Result = (IEnumerator)this.ItemsCollection;

            return Result;
        } // IEnumerator IEnumerable_GetEnumerator(...)

        #endregion "methods-IEnumerable"

        #region "methods-ICollection"

        protected /* nonvirtual */ int ICollection_getCount()
        {
            int Result = this.ItemsCollection.Count;

            return Result;
        } // int ICollection_getCount(...)

        protected virtual Object ICollection_getSyncRoot()
        {
            Object Result = null;

            ICollection thisCollection = (ICollection)this.ItemsCollection;
            Result = thisCollection.SyncRoot;

            return Result;
        } // Object ICollection_getSyncRoot(...)

        protected virtual bool ICollection_getIsSynchronized()
        {
            bool Result = false;

            ICollection thisCollection = (ICollection)this.ItemsCollection;
            Result = thisCollection.IsSynchronized;

            return Result;
        } // bool ICollection_getIsSynchronized(...)

        protected virtual void ICollection_CopyTo(Array array, int index)
        {
            this.ItemsCollection.CopyTo(array, index);
        } // void ICollection_CopyTo(...)

        #endregion "methods-ICollection"

        #region "methods-IList"

        protected virtual bool IList_IsFixedSize()
        {
            bool Result = false;

            IList thisList = (IList)this.ItemsCollection;
            Result = thisList.IsFixedSize;

            return Result;
        } // bool IList_IsFixedSize(...)

        protected virtual bool IList_IsReadOnly()
        {
            bool Result = false;

            IList thisList = (IList)this.ItemsCollection;
            Result = thisList.IsReadOnly;

            return Result;
        } // bool IList_IsReadOnly(...)

        protected virtual int IList_Add(Object node)
        {
            int Result = -1;

            IList thisList = (IList)this.ItemsCollection;
            Result = thisList.Add(node);

            return Result;
        } // int IList_Add(...)

        protected virtual void IList_Clear()
        {
            IList thisList = (IList)this.ItemsCollection;
            thisList.Clear();
        } // void IList_Clear(...)

        protected virtual bool IList_Contains(Object node)
        {
            bool Result = false;

            IList thisList = (IList)this.ItemsCollection;
            Result = thisList.Contains(node);

            return Result;
        } // bool IList_Contains(...)

        protected virtual int IList_IndexOf(Object node)
        {
            int Result = -1;

            IList thisList = (IList)this.ItemsCollection;
            Result = thisList.IndexOf(node);

            return Result;
        } // int IList_IndexOf(...)

        public virtual void IList_Insert(int index, Object node)
        {
            IList thisList = (IList)this.ItemsCollection;
            thisList.Insert(index, node);
        } // void IList_Insert(...)

        protected virtual void IList_Remove(Object node)
        {
            IList thisList = (IList)this.ItemsCollection;
            thisList.Remove(node);
        } // void IList_Remove(...) 

        protected virtual void IList_RemoveAt(int index)
        {
            IList thisList = (IList)this.ItemsCollection;
            thisList.RemoveAt(index);
        } // void IList_RemoveAt(...) 

        protected virtual Object IList_getAt(int index)
        {
            Object Result = null;

            PathListViewItem thisNode = (PathListViewItem)this.ItemsCollection[index];

            Result = (Object)thisNode;
            return Result;
        } // Object IList_getAt(...)

        protected virtual void IList_setAt(int index, Object value)
        {
            if (this.IsPathListViewItem(value))
            {
                this.ItemsCollection[index] = (PathListViewItem)value;
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

        /* intfscope */
        bool IList.IsFixedSize
        {
            get { return IList_IsFixedSize(); }
        }

        /* intfscope */
        bool IList.IsReadOnly
        {
            get { return IList_IsReadOnly(); }
        }

        /* intfscope */
        int IList.Add(Object node)
        {
            int Result = IList_Add(node);

            // ...

            return Result;
        } // int IList.Add(...)

        /* intfscope */
        void IList.Clear()
        {
            IList_Clear();
        } // void IList.Clear(...)

        /* intfscope */
        bool IList.Contains(Object node)
        {
            bool Result = IList_Contains(node);

            // ...

            return Result;
        } // bool IList.Contains(...)

        /* intfscope */
        int IList.IndexOf(Object node)
        {
            int Result = -1;

            // ...

            return Result;
        } // int IList.IndexOf(...)

        /* intfscope */
        void IList.Insert(int index, Object node)
        {
            this.IList_Insert(index, node);
        } // void IList.Insert(...)

        /* intfscope */
        void IList.Remove(Object node)
        {
            this.IList_Remove(node);
        } // void IList.Remove(...) 

        /* intfscope */
        void IList.RemoveAt(int index)
        {
            this.IList_RemoveAt(index);
        } // void IList.RemoveAt(...) 

        #endregion "interface-IList"


        // ...

        #region "ListViewItemCollection-methods"

        public virtual ListViewItem Add(ListViewItem node)
        {
            ListViewItem Result = this.AddByListItem(node);
            return Result;
        } // ListViewItem Add(...)

        public virtual ListViewItem Add(string text)
        {
            ListViewItem Result = this.AddByText(text);
            return Result;
        } // ListViewItem Add(...)

        public virtual ListViewItem Add(
	        string text,
	        string imageKey
        )
        {
            ListViewItem Result = this.AddByTextImgKey(text, imageKey);
            return Result;
        } // ListViewItem Add(...)

        public virtual ListViewItem Add(
	        string key,
	        string text,
	        int imageIndex
        )
        {
            ListViewItem Result = this.AddByKeyValueImgIndex(key, text, imageIndex);
            return Result;
        } // ListViewItem Add(...)

        public virtual ListViewItem Add(
            string key,
            string text,
            string imageKey
        )
        {
            ListViewItem Result = this.AddByKeyValueImgKey(key, text, imageKey);
            return Result;
        } // ListViewItem Add(...)

        public void AddRange(
	        ListViewItem[] items
        )
        {
            this.AddRangeByArray(items);
        } // void AddRange(...)

        public void AddRange(
	        ListView.ListViewItemCollection items
        )
        {
            this.AddRangeByCollection(items);
        } // void AddRange(...)

        public ListViewItem Insert(
            int index,
            ListViewItem item
        )
        {
            ListViewItem Result = this.InsertByListViewItem(index, item);
            return Result;
        } // ListViewItem Insert(...)

        public ListViewItem Insert(
	        int index,
	        string text
        )
        {
            ListViewItem Result = this.InsertByText(index, text);
            return Result;
        } // ListViewItem Insert(...)

        public ListViewItem Insert(
	        int index,
	        string text,
	        int imageIndex
        )
        {
            ListViewItem Result = this.InsertByTextImgIndex(index, text, imageIndex);
            return Result;
        } // ListViewItem Insert(...)

        public ListViewItem Insert(
	        int index,
	        string text,
	        string imageKey
         )
        {
            ListViewItem Result = this.InsertByTextImgKey(index, text, imageKey);
            return Result;
        } // ListViewItem Insert(...)

        /*
        public virtual ListViewItem Insert(
            int index,
            string key,
            string text
        )
        {
            ListViewItem Result = this.InsertByKeyValue(index, text);
            return Result;
        } // ListViewItem Insert(...)
        */

        public virtual ListViewItem Insert(
	        int index,
	        string key,
	        string text,
	        int imageIndex
        )
        {
            ListViewItem Result = this.InsertByTextImgKey(index, text, text);
            return Result;
        } // ListViewItem Insert(...)

        public virtual ListViewItem Insert(
            int index,
            string key,
            string text,
            string imageKey
        )
        {
            ListViewItem Result = this.InsertByKeyValueImgKey(index, key, text, imageKey);
            return Result;
        } // ListViewItem Insert(...)

        #endregion "ListViewItemCollection-methods"

        #region "methods"

        public override string ToString()
        {
            string Result = this.ItemsCollection.ToString();
            return Result;
        } // string ToString(...)

        public virtual bool ContainsKey(
	        string key
        )
        {
            bool Result = this.ItemsCollection.ContainsKey(key);
            return Result;
        } // bool ContainsKey(...)

        public virtual int IndexOfKey(
	        string key
        )
        {
            int Result = this.ItemsCollection.IndexOfKey(key);
            return Result;
        } // int ContainsKey(...)

        public virtual void RemoveByKey(
	        string key
        )
        {
            this.ItemsCollection.RemoveByKey(key);
        } // int RemoveByKey(...)

        public bool IsPathListViewItem(Object Item)
        {
            bool Result = (Item is PathListViewItem);
            return Result;
        } // bool IsPathListViewItem(...)

        public virtual ListViewItem AddByListItem(ListViewItem Item)
        {
            ListViewItem Result = null;

            if (this.IsPathListViewItem(Item))
            {
                Result = this.ItemsCollection.Add(Item);
            }
            else
            {
                throw new InvalidCastException();
            }

            return Result;
        } // ListViewItem AddByListItem(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByText(string text)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Text = text;

            return Result;
        } // PathListViewItem NewNodeByText(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByKeyValue(
            string key, string value)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Code = key;
            Result.Text = value;

            return Result;
        } // PathListViewItem NewNodeByKeyValue(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByTextImgKey(
            string text, string imageKey)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Text = text;
            Result.ImageKey = imageKey;

            return Result;
        } // PathListViewItem NewNodeByTextImgKey(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByTextImgIndex(
            string text, int imageIndex)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Text = text;
            Result.ImageIndex = imageIndex;

            return Result;
        } // PathListViewItem NewNodeByTextImgIndex(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByKeyValueImgIndex(
            string key, string value, int imageIndex)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Name = key;
            Result.Text = value;
            Result.ImageIndex = imageIndex;

            return Result;
        } // PathListViewItem NewNodeByKeyValueImgIndex(...)

        protected /* nonvirtual */ PathListViewItem NewNodeByKeyValueImgKey(
            string key, string value, string imageKey)
        {
            PathListViewItem Result = new PathListViewItem();
            Result.Name = key;
            Result.Text = value;
            Result.ImageKey = imageKey;

            return Result;
        } // PathListViewItem NewNodeByKeyValueImgKey(...)

        public virtual ListViewItem AddByText(string text)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByText(text);

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByText(...)

        public virtual ListViewItem AddByKeyValue(string key, string value)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByKeyValue(key, value);               

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByKeyValue(...)

        public virtual ListViewItem AddByTextImgKey(string text, string imageKey)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByTextImgKey(text, imageKey);

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByTextImgKey(...)

        public virtual ListViewItem AddByTextImgIndex
            (string text, int ImageIndex)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByTextImgIndex(text, ImageIndex);

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByTextImgIndex(...)

        public virtual ListViewItem AddByKeyValueImgIndex
            (string key, string value, int imageIndex)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByKeyValueImgIndex(key, value, imageIndex);

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByKeyValueImgIndex(...)

        public virtual ListViewItem AddByKeyValueImgKey
            (string key, string value, string imageKey)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByKeyValueImgKey(key, value, imageKey);              

            Result = this.ItemsCollection.Add(Result);
            return Result;
        } // ListViewItem AddByKeyValueImgKey

        public void AddRangeByArray(
            ListViewItem[] items
        )
        {
            foreach (ListViewItem eachNode in this.ItemsCollection)
            {
                if (!this.IsPathListViewItem(eachNode))
                {
                    throw new InvalidCastException();
                }
            } // foreach

            this.ItemsCollection.AddRange(items);
        } // void AddRangeByArray(...)

        public void AddRangeByCollection(
            ListView.ListViewItemCollection items
        )
        {
            foreach (ListViewItem eachNode in this.ItemsCollection)
            {
                if (!this.IsPathListViewItem(eachNode))
                {
                    throw new InvalidCastException();
                }
            } // foreach

            this.ItemsCollection.AddRange(items);
        } // void AddRangeByCollection(...)

        public virtual ListViewItem InsertByListViewItem(
            int index,
            ListViewItem item
        )
        {
            ListViewItem Result = null;

            if (this.IsPathListViewItem(item))
            {
                this.ItemsCollection.Insert(index, item);
                Result = item;
            }
            else
            {
                throw new InvalidCastException();
            }

            return Result;
        } // ListViewItem InsertByListViewItem(...)

        public virtual ListViewItem InsertByText(
            int index, string text)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByText(text);

            Result = this.ItemsCollection.Insert(index, Result);
            return Result;
        } // ListViewItem InsertByText(...)

        public virtual ListViewItem InsertByTextImgIndex(
            int index, string text, int imageIndex)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByTextImgIndex(text, imageIndex);

            Result = this.ItemsCollection.Insert(index, Result);
            return Result;
        } // ListViewItem InsertByTextImgIndex(...)

        public virtual ListViewItem InsertByTextImgKey(
            int index, string text, string imageKey)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByTextImgKey(text, imageKey);

            Result = this.ItemsCollection.Insert(index, Result);
            return Result;
        } // ListViewItem InsertByTextImgKey(...)

        public virtual ListViewItem InsertByKeyValue(
            int index, string key, string value)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByKeyValue(key, value);

            Result = this.ItemsCollection.Insert(index, Result);
            return Result;
        } // ListViewItem InsertByKeyValue(...)

        public virtual ListViewItem InsertByKeyValueImgKey(
            int index, string key, string value, string imageKey)
        {
            ListViewItem Result = null;

            Result = (PathListViewItem)NewNodeByKeyValueImgKey(key, value, imageKey);

            Result = this.ItemsCollection.Insert(index, Result);
            return Result;
        } // ListViewItem InsertByKeyValueImgKey(...)

        // ...

        #endregion "methods"

        // ...

    } // class ListViewItemCollectionWrapper 

    // ...

    public class PathListView : InternalPathListView
    {
        #region "properties"

        protected ListViewItemCollectionWrapper _ItemsWrapper;
        public ListViewItemCollectionWrapper ItemsWrapper
        {
            get { return _ItemsWrapper; }
            set { _ItemsWrapper = value; }
        }

        // ...

        #endregion "properties"

        #region "constructor"

        public PathListView()
            : base()
        {
            this._ItemsWrapper = null;
        }

        // ...

        #endregion "constructor"

        public virtual void prepareItems()
        {
            this._ItemsWrapper = new ListViewItemCollectionWrapper();
            this._ItemsWrapper.ListView = this;
            this._ItemsWrapper.ItemsCollection = this.Items;
        } // void prepareItems(...)

    } // class PathListView 

    // ...

} // namespace
