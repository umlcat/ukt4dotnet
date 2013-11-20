using System;
using System.Text;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.collections
{
    public class TypedKeyValuePairClass<KeyType, ValueType> : CollectionClass
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
        private bool F_TypedKeyValuePairClass_IsReady;

        public TypedKeyValuePairClass()
        {
            // --> clear status
            F_TypedKeyValuePairClass_IsReady = false;
            // --> clear fields
            // ...
        } // TypedKeyValuePairClass()

        public override bool IsReady()
        {
            bool Result = F_TypedKeyValuePairClass_IsReady;
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
            F_TypedKeyValuePairClass_IsReady = true;

            return Result;
        } // public override Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;

            // --> update status
            F_TypedKeyValuePairClass_IsReady = false;

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
    /// A template for entity classes.
    /// </summary>
    public class TypedDictionaryClass : CollectionClass
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
            private bool F_TypedDictionaryClass_IsReady;

            public TypedDictionaryClass()
            {
                // --> clear status
                F_TypedDictionaryClass_IsReady = false;
				// --> clear fields
				// ...
            } // TypedDictionaryClass()

            public override bool IsReady()
            {
                bool Result = F_TypedDictionaryClass_IsReady;
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
                F_TypedDictionaryClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_TypedDictionaryClass_IsReady = false;

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
            } // void Clear()

            public override void Clear()
            {
                // ...
            } // void Clear()

			// ...
        #endregion "methods"

        // ...

    } // class TypedDictionaryClass

} // namespace
