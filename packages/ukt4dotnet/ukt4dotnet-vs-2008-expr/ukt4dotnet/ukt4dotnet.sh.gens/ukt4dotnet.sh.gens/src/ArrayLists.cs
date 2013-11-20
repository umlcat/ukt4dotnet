using System;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.collections
{
    /// <summary>
    /// A collection of elements of the same class,
    /// elements, can be added, at the end of the list,
    /// and be access, and replaced, randomly.
    /// </summary>
    public class ArrayList<BaseType> : ListClass<BaseType>
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
            private bool F_ArrayList_IsReady;

            public ArrayList()
            {
                // --> clear status
                F_ArrayList_IsReady = false;
				// --> clear fields
				// ...
            } // ArrayList()

            public override bool IsReady()
            {
                bool Result = F_ArrayList_IsReady;
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
                F_ArrayList_IsReady = true;

                return Result;
            } // public override Int64 Create(...)
            
            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ArrayList_IsReady = false;

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

            public override void Add(BaseType Item)
            {
                // ...
            } // void Add(...)

            public virtual bool IsValidIndex(int Index)
            {
                bool Result = false;

                // ...

                return Result;
            } // bool IsValidIndex(...)

            public virtual BaseType GetItemAt(int Index)
            {
                BaseType Result = null;

                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))

                return Result;
            } // BaseType GetItem(...)

            public virtual void SetItemAt(int Index, out BaseType Item)
            {
                Item = null;

                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))
            } // void SetItemAt(...)

            public virtual void InsertAt(int Index, BaseType Item)
            {
                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))
            } // void InsertAt(...)

            public virtual void RemoveAt(int Index, BaseType Item)
            {
                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))
            } // void RemoveAt(...)

            public virtual BaseType ExtractAt(int Index)
            {
                BaseType Result = null;

                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))

                return Result;
            } // BaseType GetItem(...)

            public virtual BaseType IndexOf(int Index)
            {
                BaseType Result = null;

                if (IsValidIndex(Index))
                {
                    // ...
                } // if (IsValidIndex(Index))

                return Result;
            } // BaseType GetItem(...)

			// ...
        #endregion "methods"

        // ...

    } // class ArrayList

} // namespace
