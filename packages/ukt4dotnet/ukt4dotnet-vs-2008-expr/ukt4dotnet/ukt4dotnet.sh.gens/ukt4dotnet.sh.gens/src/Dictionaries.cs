using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.collections
{
    public class KeyValuePairClass<KeyType, ValueType> : CollectionClass
        where ValueType : ObjectClass
    {
        #region "fields"
            // ...

            // ...
        #endregion "fields"

        #region "properties"
            // ...

            // ...
        #endregion "properties"

        #region "support"
            private bool F_KeyValuePairClass_IsReady;

            public KeyValuePairClass()
            {
                // --> clear status
                F_KeyValuePairClass_IsReady = false;
				// --> clear fields
				// ...
            } // KeyValuePairClass()

            public override bool IsReady()
            {
                bool Result = F_KeyValuePairClass_IsReady;
                return Result;
            } // bool IsReady(...)
        #endregion "support"

        #region "constructors"
            // ...

            public override Int64 Create()
            {
                Int64 Result = 0;

                Result = base.Create();

                // --> update status
                F_KeyValuePairClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_KeyValuePairClass_IsReady = false;

                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public override bool IsEmpty()
            {
                bool Result = false;

                // ...

                return Result;
            } // bool IsEmpty()

            public override void Clear()
            {
                // ...
            } // void Clear()

			// ...
        #endregion "methods"

        // ...
    } // class 

    /// <summary>
    /// Represents a collection of keys and values.
    /// It's the equivalent of the <code>Dictionary</code> generic class,
    /// that supports the <code>ObjectInterface</code> interface.
    /// </summary>
    public class DictionaryClass<KeyType, ValueType> : CollectionClass
        where ValueType : ObjectClass
    {
        #region "fields"
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            protected Dictionary<KeyType, ValueType> F_Items;
            protected Dictionary<KeyType, ValueType> Items
            {
                get { return F_Items; }
                set { F_Items = value; }
            }

            // ...
        #endregion "properties"

        #region "support"
            private bool F_DictionaryClass_IsReady;
        
            public DictionaryClass() : base()
            {
                // --> clear status
                F_DictionaryClass_IsReady = false;

                // --> clear fields
                F_Items = null;
            } // DictionaryClass()

            public override bool IsReady()
            {
                bool Result = F_DictionaryClass_IsReady;
                return Result;
            } // bool IsReady(...)

        #endregion "support"

        #region "constructors"
            // ...

            public override Int64 Create()
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    F_Items = new Dictionary<KeyType, ValueType>();
                } // if (Result == 0)

                // --> update status
                F_DictionaryClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_DictionaryClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_Items.Clear();
                    F_Items = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public override bool IsEmpty()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = (F_Items.Count > 0);
                }

                return Result;
            } // bool IsEmpty(...)

            public override int Count()
            {
                int Result = 0;

                if (this.IsReady())
                {
                    Result = F_Items.Count;
                }

                return Result;
            } // int Count(...)

            public override void Clear()
            {
                if (this.IsReady())
                {
                    F_Items.Clear();
                }
            } // void Clear(...)

            public bool ContainsKey(KeyType AKey)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = F_Items.ContainsKey(AKey);
                }

                return Result;
            } // bool ContainsKey(...)

            public bool ContainsValue(ValueType AValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = F_Items.ContainsValue(AValue);
                }

                return Result;
            } // bool ContainsValue(...)

            public bool TryGetValue(
	            KeyType AKey,
	            out ValueType AValue
            )
            {
                bool Result = false;
                AValue = default(ValueType);

                if (this.IsReady())
                {
                    Result = F_Items.TryGetValue(AKey, out AValue);
                }

                return Result;             
            } // bool TryGetValue(...)

            public void Add(
                KeyType AKey,
                ValueType AValue
            )
            {
                if (this.IsReady())
                {
                    this.Items.Add(AKey, AValue);
                }
            } // void Add(...)

            public bool Remove(KeyType AKey)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    ValueType AValue = default(ValueType);

                    Result = TryGetValue(AKey, out AValue);
                    if (Result)
                    {
                        AValue.Destroy();

                        Result = F_Items.Remove(AKey);
                    } // if (Result)
                } // if (this.IsReady())

                return Result;
            } // bool Remove(...)

			// ...
        #endregion "methods"

        // ...

    } // class DictionaryClass

} // namespace
