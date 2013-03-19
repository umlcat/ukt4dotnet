using System;
using System.Text;
using romo.shared.utilities;
using romo.shared.objects;

namespace romo.shared.collections
{
    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class QueueClass<BaseType> : ItemCollectionClass<BaseType>
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
            private bool F_QueueClass_IsReady;

            public QueueClass()
            {
                // --> clear status
                F_QueueClass_IsReady = false;
				// --> clear fields
				// ...
            } // QueueClass()

            public override bool IsReady()
            {
                bool Result = F_QueueClass_IsReady;
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
                F_QueueClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_QueueClass_IsReady = false;

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

    } // class QueueClass

} // namespace
