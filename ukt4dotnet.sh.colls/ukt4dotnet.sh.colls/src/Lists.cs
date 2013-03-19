using System;
using System.Text;
using romo.shared.objects;

namespace romo.shared.collections
{
    /// <summary>
    /// A collection of elements of the same class,
    /// elements, can be added, at the end of the list,
    /// but, can only be all removed.
    /// Useful, as a "constant", "read-only" collection.
    /// </summary>
    public class ListClass<BaseType> : ItemCollectionClass<BaseType>
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
            private bool F_ListClass_IsReady;

            public ListClass()
            {
                // --> clear status
                F_ListClass_IsReady = false;
				// --> clear fields
				// ...
            } // ListClass()

            public override bool IsReady()
            {
                bool Result = F_ListClass_IsReady;
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
                F_ListClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ListClass_IsReady = false;

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
            } // bool IsEmpty(...)

            public override void Clear()
            {
                // ...
            } // void Clear(...)

            public virtual void Add(BaseType Item)
            {
                // ...
            } // void Add(...)

			// ...
        #endregion "methods"

        // ...

    } // class ListClass

} // namespace
