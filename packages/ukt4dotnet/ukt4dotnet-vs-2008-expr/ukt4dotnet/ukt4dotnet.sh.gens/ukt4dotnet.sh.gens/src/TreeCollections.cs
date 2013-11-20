using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.collections
{
    public class ForwardTreeCollectionClass<DataType> : ObjectClass
    {
        #region "fields"
            /// <summary>
            /// Used to generate unique "absoluteindex",
            /// never decreases.
            /// </summary>
          protected Int64 _AbsoluteIndexCounter = 0;

          /// <summary>
          /// Preserves current global items count.
          /// can decrease.
          /// </summary>
          protected Int64 _AbsoluteCount = 0;
        #endregion "fields"

        #region "read-only-properties"
            public Int64 AbsoluteIndexCounter()
           {
               Int64 Result = this._AbsoluteIndexCounter;

               return Result;
           } // Int64 AbsoluteIndexCounter(...)
        #endregion "read-only-properties"

        #region "methods"
           public void nextAbsoluteIndexCount()
           {
               this._AbsoluteIndexCounter++;
           } // void nextAbsoluteIndexCount(...)
        #endregion "methods"

        // ...

    } // class ForwardTreeCollectionClass<DataType>

    public class ForwardTreeNodeClass<DataType> : ObjectClass
    {
        #region "fields"
            /// <summary>
            /// Used to generate unique "localindex",
            /// never decreases.
            /// </summary>
            protected Int64 _LocalIndexCounter = 0;

            /// <summary>
            /// Preserves current subitems count.
            /// can decrease.
            /// </summary>
            protected Int64 _LocalCount = 0;
        #endregion "fields"

        #region "read-only-properties"
            public Int64 LocalIndexCounter()
            {
                Int64 Result = this._LocalIndexCounter;

                return Result;
            } // Int64 LocalIndexCounter(...)
        #endregion "read-only-properties"

        #region "methods"
            public void nextLocalCount()
            {
                this._LocalIndexCounter++;
            } // void nextLocalCount(...)

            // ...

        #endregion "methods"

        // ...

    } // class ForwardTreeNodeClass<DataType>

    public class TreeNodeListClass<DataType> : ObjectClass
    {
        #region "properties"
        protected List<TreeNodeClass<DataType>> _Items = null;
        public List<TreeNodeClass<DataType>> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

        protected TreeNodeClass<DataType> _Parent;
        /// <summary>
        /// Access the parent node.
        /// </summary>
        public TreeNodeClass<DataType> Parent
        {
            get
            {
                return _Parent;
            }

            set
            {
                _Parent = value;
            }
        }
        #endregion "properties"

        #region "constructors"
        public override Int64 Create()
        {
            Int64 Result = 0;
                this.Items = new List<TreeNodeClass<DataType>>();
            return Result;
        } // Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;
                this.Items.Clear();
                this.Items = null;
            return Result;
        } // Int64 Destroy(...)
        #endregion "constructors"

        #region "methods-non-overloaded"
            public virtual void AddByNode(TreeNodeClass<DataType> item)
            {
                item.Collection = this.Parent.Collection;
                item.Parent = this.Parent;
                item.Level = this.Parent.Level;

                item.GlobalIndex = item.Collection.AbsoluteIndexCounter();
                item.Collection.nextAbsoluteIndexCount();

                item.LocalIndex = item.Parent.LocalIndexCounter();
                item.Parent.nextLocalCount();

                this.Items.Add(item);
            } // void AddByNode(...)

            public virtual TreeNodeClass<DataType> AddByData(DataType DataValue)
            {
                TreeNodeClass<DataType> Result = new TreeNodeClass<DataType>();
                Result.Data = DataValue;

                this.AddByNode(Result);

                return Result;
            } // TreeNodeClass<DataType> AddByData(...)

            public virtual void RemoveByIndex(int index)
            {
                TreeNodeClass<DataType> eachItem = this.Items[index];
                eachItem.Destroy();

                this.Items.RemoveAt(index);
            } // void RemoveByIndex(...)
        #endregion "methods-non-overloaded"

        #region "methods"

        public virtual void Add(TreeNodeClass<DataType> item)
        {
            this.AddByNode(item);
        } // void Add(...)

        public virtual void RemoveAt(int index)
        {
            RemoveByIndex(index);
        } // void RemoveAt(...)

        public virtual void Clear()
        {
            int eachIndex = (this.Items.Count - 1);
            while (eachIndex >= 0)
            {
                RemoveAt(eachIndex);

                eachIndex--;
            } // while
        } // void Clear(...)

        #endregion "methods"

        // ...

    } // class TreeNodeListClass<DataType>

    public delegate void TreeNodeIteratorDelegate(ObjectClass ATreeNode, object AParam);

    public class TreeNodeClass<DataType> : ForwardTreeNodeClass<DataType> 
        //: IEnumerable<KeyType>
    {
        #region "fields"
            //protected Int64 _LocalCount = 0;
        #endregion "fields"

        #region "properties"
            protected DataType _Data;
            /// <summary>
            /// Access the parent node.
            /// </summary>
            public DataType Data
            {
                get
                {
                    return _Data;
                }

                set
                {
                    _Data = value;
                }
            }

            protected TreeNodeListClass<DataType> _Items = null;
            public TreeNodeListClass<DataType> Items
            {
                get
                {
                    return _Items;
                }

                set
                {
                    _Items = value;
                }
            }

            protected TreeNodeClass<DataType> _Parent;
            /// <summary>
            /// Access the parent node.
            /// </summary>
            public TreeNodeClass<DataType> Parent
            {
                get
                {
                    return _Parent;
                }

                set
                {
                    _Parent = value;
                }
            }

            protected Int64 _Level;
            /// <summary>
            /// Access the level. Returns 0 if root node.
            /// </summary>
            public Int64 Level
            {
                get
                {
                    return _Level;
                }

                set
                {
                    _Level = value;
                }
            }

            protected Int64 _LocalIndex;
            /// <summary>
            /// Consecutive sequential index, unique only for all nodes,
            /// that are children of the same node.
            /// </summary>
            public Int64 LocalIndex
            {
                get
                {
                    return _LocalIndex;
                }

                set
                {
                    _LocalIndex = value;
                }
            }

            protected Int64 _GlobalIndex;
            /// <summary>
            /// Consecutive sequential index, unique only for all nodes,
            /// that are children of the same node.
            /// </summary>
            public Int64 GlobalIndex
            {
                get
                {
                    return _GlobalIndex;
                }

                set
                {
                    _GlobalIndex = value;
                }
            }

            protected ForwardTreeCollectionClass<DataType> _Collection = null;
            public ForwardTreeCollectionClass<DataType> Collection
            {
                get
                {
                    return _Collection;
                }

                set
                {
                    _Collection = value;
                }
            }
        #endregion "properties"

        #region "constructors"
            public override Int64 Create()
            {
                Int64 Result = 0;
                  this.Items = new TreeNodeListClass<DataType>();
                  this.Items.Create();

                  this.Items.Parent = this;

                  this._GlobalIndex = 0;
                  this._LocalIndex = 0;
                return Result;
            } // Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;
                this._GlobalIndex = 0;
                this._LocalIndex = 0;

                this.Collection = null;
                this.Parent = null;
                this.Level = 0;

                this.Items.Destroy();
                this.Items = null;
                return Result;
            } // Int64 Destroy(...)
        #endregion "constructor"

        #region "methods"
            public override string ToString()
            {
                string Result = "";

                Object AData = (Object)this._Data;
                Result = String.Format("\"{0}\"", AData.ToString());

                return Result;
            } // string ToString(...)

            public virtual String AbsolutePath()
            {
                String Result = "";

                //Object AData = (Object)this._Data;
                //Result = AData.ToString();

                return Result;
            } // String AbsolutePath(...)

        // ...

        #endregion "methods"

        #region "iterators"
            public virtual void ForEachInmediateForward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                int ACount = this.Items.Items.Count;
                for (int eachIndex = 0; eachIndex < ACount; eachIndex++)
                {
                    TreeNodeClass<DataType> eachItem = this.Items.Items[eachIndex];
                    ObjectClass eachTreeNode = (ObjectClass)eachItem;
                    ADelegate(eachTreeNode, AParam);
                } // for
            } // void ForEachInmediateForward(...)

            public virtual void ForEachInmediateBackward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                int ACount = (this.Items.Items.Count - 1);
                for (int eachIndex = ACount; eachIndex >= 0; eachIndex--)
                {
                    TreeNodeClass<DataType> eachItem = this.Items.Items[eachIndex];
                    ObjectClass eachTreeNode = (ObjectClass)eachItem;
                    ADelegate(eachTreeNode, AParam);
                } // for
            } // void ForEachInmediateBackward(...)

            public virtual void ForEachRecursiveForward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                // --> parent node
                ObjectClass ParentTreeNode = (ObjectClass)this;
                ADelegate(ParentTreeNode, AParam);

                // --> children in "forward" order
                int ACount = this.Items.Items.Count;
                for (int eachIndex = 0; eachIndex < ACount; eachIndex++)
                {
                    TreeNodeClass<DataType> eachItem = this.Items.Items[eachIndex];
                    eachItem.ForEachRecursiveForward(ADelegate, AParam);
                } // for
            } // void ForEachRecursiveForward(...)

            public virtual void ForEachRecursiveBackward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                // --> parent node
                ObjectClass ParentTreeNode = (ObjectClass)this;
                ADelegate(ParentTreeNode, AParam);

                // --> children in "backward" order
                int ACount = (this.Items.Items.Count - 1);
                for (int eachIndex = ACount; eachIndex >= 0; eachIndex--)
                {
                    TreeNodeClass<DataType> eachItem = this.Items.Items[eachIndex];
                    eachItem.ForEachRecursiveBackward(ADelegate, AParam);
                } // for
            } // void ForEachRecursiveBackward(...)

            public virtual void ForEachUpward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                // --> this node
                ObjectClass ParentTreeNode = (ObjectClass)this;
                ADelegate(ParentTreeNode, AParam);

                // --> parent node
                if (this.Parent != null)
                {
                    this.Parent.ForEachUpward(ADelegate, AParam);
                }
            } // void ForEachUpward(...)

            public virtual void ForEachDownward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                // --> parent node
                if (this.Parent != null)
                {
                    this.Parent.ForEachUpward(ADelegate, AParam);
                }

                // --> this node
                ObjectClass ParentTreeNode = (ObjectClass)this;
                ADelegate(ParentTreeNode, AParam);
            } // void ForEachDownward(...)
        #endregion "iterators"

        // ...

    } // class TreeNodeClass

    public class TreeCollectionClass<DataType> : ForwardTreeCollectionClass<DataType>
    {
        #region "fields"
            protected TreeNodeClass<DataType> _Root = null;
        #endregion "fields"

        #region "properties"
            protected String _PathSeparator;
            /// <summary>
            /// Access the parent node.
            /// </summary>
            public String PathSeparator
            {
                get
                {
                    return _PathSeparator;
                }

                set
                {
                    _PathSeparator = value;
                }
            }
        #endregion "properties"

        #region "read-only-properties"
            public bool HasRoot()
            {
                bool Result = (this._Root != null);
                return Result;
            }

            public TreeNodeClass<DataType> Root()
            {
                TreeNodeClass<DataType> Result = this._Root;
                return this._Root;
            }
        #endregion "read-only-properties"

        #region "constructors"
            public override Int64 Create()
            {
                Int64 Result = 0;
                  this._Root = null;
                return Result;
            } // Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;
                  this._Root.Destroy();
                  this._Root = null;
                return Result;
            } // Int64 Destroy(...)
        #endregion "constructors"

        #region "methods"
            public virtual void deleteRoot()
            {
                if (this._Root != null)
                {
                    this._Root.Destroy();
                }
            } // void deleteRoot(...)

            public virtual void addRoot(TreeNodeClass<DataType> ARootNode)
            {
                if (ARootNode != null)
                {
                    ARootNode.Collection = this;
                    ARootNode.Parent = null;
                    ARootNode.Level = 0;

                    ARootNode.GlobalIndex = 0;
                    ARootNode.LocalIndex = 0;
                    this.nextAbsoluteIndexCount();

                    this._Root = ARootNode;
                }
            } // void addRoot(...)
        #endregion "methods"

        #region "iterators"
            public virtual void ForEachInmediateForward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                this._Root.ForEachInmediateForward(ADelegate, AParam);
            } // void ForEachInmediateForward(...)

            public virtual void ForEachInmediateBackward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                this._Root.ForEachInmediateBackward(ADelegate, AParam);
            } // void ForEachInmediateBackward(...)

            public virtual void ForEachRecursiveForward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                this._Root.ForEachRecursiveForward(ADelegate, AParam);
            } // void ForEachRecursiveForward(...)

            public virtual void ForEachRecursiveBackward(TreeNodeIteratorDelegate ADelegate, object AParam)
            {
                this._Root.ForEachRecursiveBackward(ADelegate, AParam);
            } // void ForEachRecursiveBackward(...)
        #endregion "iterators"

        // ...

    } // class TreeCollectionClass<DataType>


    // ...

} // namespace