using System;
using System.Text;
using romo.shared.objects;

namespace romo.shared.collections
{
    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class Stack<BaseType> : ItemCollectionClass<BaseType>
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
            private bool F_Stack_IsReady;

            public Stack()
            {
                // --> clear status
                F_Stack_IsReady = false;
				// --> clear fields
				// ...
            } // Stack()

            public override bool IsReady()
            {
                bool Result = F_Stack_IsReady;
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
                F_Stack_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_Stack_IsReady = false;

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

            public virtual void Push(BaseType Item)
            {
                if (Item != null)
                {


                } // if (Item != null)
            } // void Push(...)

            public virtual void Pull(BaseType Item)
            {
                if (Item != null)
                {


                } // if (Item != null)
            } // void Pull(...)

			// ...
        #endregion "methods"

        // ...

    } // class Stack

} // namespace
