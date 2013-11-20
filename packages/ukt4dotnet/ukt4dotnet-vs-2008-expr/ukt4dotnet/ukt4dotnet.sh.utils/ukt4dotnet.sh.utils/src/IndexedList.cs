using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ukt4dotnet.shared.utilities
{
    /// <summary>
    /// Its an structure to store an item,
    /// that has a unique integer field,
    /// and additional fields,
    /// that doesn't matter its quantity or type.
    /// Note: It should be a <code>struct</code>,
    /// but, in dotnet, structs sometimes behave like,
    /// objects, pointers to objects, and sometimes,
    /// like structs, or pointers to structs.
    /// </summary>
    public class IndexedItem
    {
        #region "properties"
            private int _Key = 0;
            /// <summary>
            /// Unique value that identifies each item,
            /// from anothers. Can be first assigned with 0,
            /// and be duplicated, but later, must be reassigned,
            /// with an unique value.
            /// </summary>
            public int Key
            {
                get { return _Key; }
                set { _Key = value; }
            }

            private object _Data = null;
            /// <summary>
            /// Additional data for the item,
            /// it can be <code>null</code>,
            /// it can be a single field,
            /// or several fields, of any type.
            /// </summary>
            public object Data
            {
                get { return _Data; }
                set { _Data = value; }
            }
        #endregion "properties"

        #region "constructor"
            /// <summary>
            /// Empty constructor without parameters.
            /// </summary>
            public IndexedItem()
            {
                //
            }

            /// <summary>
            /// Constructor for assigning all properties.
            /// </summary>
            /// <param name="aKey">Fieldname</param>
            /// <param name="aData">Field value</param>
            public IndexedItem(int aKey, object aData)
            {
                this._Key = aKey;
                this._Data = aData;
            }
        #endregion "constructor"

        #region "methods"
            // Representation as string
            public override string ToString()
            {
                string Result = "";

                // detectar cuando el resto de los datos es {null}
                string strValue = "";
                if (this.Data == null)
                {
                    strValue = "<<null>>";
                }
                else
                {
                    strValue = this.Data.ToString();
                }

                Result = strValue;

                // display key and contents as text
                //Result = String.Format("({0}:{1})", this.Key, strValue);
                
                return Result;
            } // string ToString(...)
        #endregion "methods"
    } // class IndexedItem

    /// <summary>
    /// Its a list that stores several items,
    /// with a unique non-consecutive integer field.
    /// Additionally, each item can have additional
    /// fields.
    /// Each item has a consecutive index from the <code>List</code>,
    /// and also an integer key.
    /// The index and the key are different concepts.
    /// </summary>
    public class IndexedList : List<IndexedItem>
    {
        #region "constructor"
            public IndexedList()
            {
                //
            }
        #endregion "constructor"

        #region "methods"
            /// <summary>
            /// Returns a consecutive of all the items' keys,
            /// without the rest of the fields.
            /// </summary>
            /// <returns>List</returns>
            public ICollection Keys()
            {
                ArrayList Result = new ArrayList();

                foreach (IndexedItem eachItem in this)
                {
                    Result.Add(eachItem.Key);
                } // foreach

                return Result;
            } // ICollection Keys(...)

            /// <summary>
            /// Searchs the list for the item that has
            /// the indicated unique integer key.
            /// </summary>
            /// <param name="aKey"></param>
            /// <returns></returns>
            public bool ContainsKey(int aKey)
            {
                bool Result = false;

                foreach (IndexedItem eachItem in this)
                {
                    Result = (eachItem.Key.Equals(aKey));
                    if (Result)
                    {
                        break;
                    }
                } // foreach

                return Result;
            } // bool ContainsKey(....)

            /// <summary>
            /// Searchs for the item that has the given unique non-consecutive key,
            /// and returns the consecutive index on the list.
            /// </summary>
            /// <param name="aKey"></param>
            /// <returns>Consecutive index of the item on the list.</returns>
            public int IndexOf(int aKey)
            {
                int Result = -1;

                bool Found = false;
                int AIndex = 0;
                while ((!Found) && (AIndex < this.Count))
                {
                    Found = (this[AIndex].Key == aKey);
                    AIndex++;
                } // while

                if (Found)
                {
                    Result = (AIndex - 1);
                }

                return Result;
            } // int IndexOf(...)
        #endregion "methods"
    } // class IndexedList
} // namespace
