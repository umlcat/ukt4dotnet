using System;
using System.Text;
using romo.shared.objects;

namespace romo.shared.collections
{
    /// <summary>
    /// Base class for collections with a single generic base item.
    /// </summary>
    public class ItemCollectionClass<BaseType> : CollectionClass
        where BaseType : ObjectClass
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
            private bool F_ItemCollectionClass_IsReady;

            public ItemCollectionClass()
            {
                // --> clear status
                F_ItemCollectionClass_IsReady = false;
                // --> clear fields
                // ...
            } // ItemCollectionClass()   

            public override bool IsReady()
            {
                bool Result = F_ItemCollectionClass_IsReady;
                return Result;
            } // bool IsReady(...)
        #endregion "support"

        #region "constructors"
            // ...

            public override Int64 Create()
            {
                Int64 Result = 0;

                Result = base.Create();
                if (Result != 0)
                {
                    // --> assign fields
                    // ...
                }

                // --> update status
                F_ItemCollectionClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deassign fields
                // ...

                // --> update status
                F_ItemCollectionClass_IsReady = false;

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

    } // class ItemCollectionClass

} // namespace
