using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ukt4dotnet.shared.utilities.Collections
{
    /*
    public struct KeyTypeValueItem<KeyType, TypeType, ValueType>
    {
        public KeyType   KeyData;
        public TypeType  TypeData;
        public ValueType ValueData;
    } // struct KeyTypeValueItem

    public class KeyTypeValueCollection<KeyType, TypeType, ValueType>
        //: IEnumerable<KeyType>
    {
        #region "properties"
            public List<KeyTypeValueItem < KeyType, TypeType, ValueType > > Items = null;

            int Count
            {
                get { return this.Items.Count;  }
            }
        #endregion "properties"

        #region "constructor"
        public KeyTypeValueCollection()
        {
            this.Items =
                new List < KeyTypeValueItem < KeyType, TypeType, ValueType > >();
        }
        #endregion "constructor"

        #region "methods"
        public void Clear()
        {
            this.Items.Clear();
        } // void Clear(...)
     * 
        public void AddItem(KeyTypeValueItem<KeyType, TypeType, ValueType> item)
     * 
     * 
        {
            this.Items.Add(item);
        } // void AddItem(...)

        public void AddKeyTypeValue(KeyType AKeyData, TypeType ATypeData, ValueType AValueData)
        {
            KeyTypeValueItem<KeyType, TypeType, ValueType> item = new KeyTypeValueItem<KeyType, TypeType, ValueType>();
            item.KeyData   = AKeyData;
            item.TypeData  = ATypeData;
            item.ValueData = AValueData;

            this.AddItem(item);
        } // void AddKeyTypeValue(...)

        public void Add(KeyTypeValueItem<KeyType, TypeType, ValueType> item)
        {
            this.AddItem(item);
        } // void Add(...)

        public bool Remove(KeyTypeValueItem<KeyType, TypeType, ValueType> item)
        {
            bool Result = this.Items.Remove(item);
            return Result;
        } // void Remove(...)

        //public bool Contains(T item)

        public bool Contains(KeyType AKey)
        {
            bool Result = false;

            int AIndex = 0;
            int ACount = this.Items.Count;
            while (!Result && (AIndex < ACount))
            {
                KeyTypeValueItem<KeyType, TypeType, ValueType> item = this.Items[AIndex]
                //Result = (item == AIndex);

                AIndex++;
            } // while

            return Result;
        } // bool Contains(...)

        #endregion "methods"


    } // class KeyTypeValueCollection
    */

    public interface KeyValueStreamer
    {
        void Write(StreamWriter Stream);
        void Reader(StreamReader Stream);
    }

    public struct KeyTypeValueItem
    {
        public string KeyData;
        public string TypeData;
        public string ValueData;
    } // struct KeyTypeValueItem

    public class KeyTypeValueCollection
    //: IEnumerable<KeyType>
    {
        #region "properties"
        protected List<KeyTypeValueItem> _Items = null;
        public List<KeyTypeValueItem> Items
        {
            get { return this._Items; }
            set { this._Items = value; }
        }

        #endregion "properties"

        #region "constructor"
        public KeyTypeValueCollection()
        {
            this.Items = new List<KeyTypeValueItem>();
        }
        #endregion "constructor"

        #region "methods"

        public int IndexByKey(string AKeyData)
        {
            int Result = -1;

            bool Found = false;
            int AIndex = 0;
            int ACount = this.Items.Count;
            while (!Found && (AIndex < ACount))
            {
                KeyTypeValueItem eachItem = this.Items[AIndex];
                Found = (eachItem.KeyData == AKeyData);
                AIndex++;
            } // while

            if (Found)
            {
                Result = (AIndex - 1);
            }

            return Result;
        } // int IndexByKey(...)

        public int IndexByItem(KeyTypeValueItem AItem)
        {
            int Result = -1;

            bool Found = false;
            int AIndex = 0;
            int ACount = this.Items.Count;
            while (!Found && (AIndex < ACount))
            {
                KeyTypeValueItem eachItem = this.Items[AIndex];
                Found = (eachItem.KeyData == AItem.KeyData);
                AIndex++;
            } // while

            if (Found)
            {
                Result = (AIndex - 1);
            }

            return Result;
        } // int IndexByItem(...)

        public void Clear()
        {
            this.Items.Clear();
        } // void Clear(...)

        public void AddByItem(KeyTypeValueItem item)
        {
            this.Items.Add(item);
        } // void AddByItem(...)

        public void AddByKeyTypeValue(string AKeyData, string ATypeData, string AValueData)
        {
            KeyTypeValueItem item = new KeyTypeValueItem();
            item.KeyData = AKeyData;
            item.TypeData = ATypeData;
            item.ValueData = AValueData;

            this.AddByItem(item);
        } // void AddByKeyTypeValue(...)

        public bool RemoveByKey(string AKeyData)
        {
            bool Result = false;

            int AIndex = IndexByKey(AKeyData);
            Result = (AIndex >= 0);
            if (Result)
            {
                this.Items.RemoveAt(AIndex);
            }

            return Result;
        } // void RemoveByKey(...)

        public bool RemoveByIndex(int AIndex)
        {
            bool Result = false;

            Result = ((AIndex >= 0) && (AIndex < this.Items.Count));
            if (Result)
            {
                this.Items.RemoveAt(AIndex);
            }

            return Result;
        } // void RemoveByIndex(...)

        #endregion "methods"
    } // class KeyTypeValueCollection

} // namespace
