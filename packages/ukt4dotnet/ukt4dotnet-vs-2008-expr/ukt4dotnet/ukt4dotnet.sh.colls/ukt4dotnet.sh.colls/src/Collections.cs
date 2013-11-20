using System;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.collections
{
    /// <summary>
    /// Base class for collections,
    /// supports the <code>NormalizedObjectInterface</code>.
    /// </summary>
    public class CollectionClass : ObjectClass
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
            private bool F_CollectionClass_IsReady;

            public CollectionClass()
            {
                // --> clear status
                F_CollectionClass_IsReady = false;
                // --> clear fields
                // ...
            } // CollectionClass()   

            public override bool IsReady()
            {
                bool Result = F_CollectionClass_IsReady;
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
                F_CollectionClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deassign fields
                // ...

                // --> update status
                F_CollectionClass_IsReady = false;

                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public virtual int Count()
            {
                int Result = 0;

                if (this.IsReady())
                {
                    //Result = F_Items.Count;
                }

                return Result;
            } // int Count(...)

            public virtual bool IsEmpty()
            {
                bool Result = false;

                // ...

                return Result;
            } // void Clear()

            public virtual void Clear()
            {
                // ...
            } // void Clear()

            // ...
        #endregion "methods"

        // ...

    } // class CollectionClass

} // namespace
