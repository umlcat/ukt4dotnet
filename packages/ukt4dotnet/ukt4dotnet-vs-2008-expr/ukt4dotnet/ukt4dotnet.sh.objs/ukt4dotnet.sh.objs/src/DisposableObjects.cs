using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.objects
{
    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class DisposableObjectClass : ObjectClass, IDisposable
    {
        #region "fields"
            // ...

            private bool F_IsDisposed;

            // ...
        #endregion "fields"

        #region "properties"
            // ...
            
            // ...
        #endregion "properties"

        #region "support"
            private bool F_DisposableObjectClass_IsReady;
        
            public DisposableObjectClass(): base()
            {
                // --> clear status
                F_DisposableObjectClass_IsReady = false;
                
                // --> clear fields
                F_IsDisposed = false;
            } // DisposableObjectClass()        
      
            public override bool IsReady()
            {
                bool Result = F_DisposableObjectClass_IsReady;
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
                    F_IsDisposed = false;
                } // if (Result == 0)

                // --> update status
                F_DisposableObjectClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deallocate fields
                if (Result == 0)
                {
                    // ...
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                // --> update status
                F_DisposableObjectClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            protected virtual void ConfirmedDispose(bool disposing)
            {
                if (disposing)
                {
                    // --> release managed
                    // if (this.IsReady())
                    // {
                    //   this.Destroy();
                    // }
                }
                // --> release unmanaged
                F_IsDisposed = true;
            } // virtual void ConfirmedDispose(...)

            public bool IsDisposed()
            {
                return F_IsDisposed;
            } // bool IsDisposed()

            public void Dispose()
            {
                ConfirmedDispose(true);
                GC.SuppressFinalize(this);
            } // void Dispose()

            // ...
        #endregion "methods"

        // ...

    } // class DisposableObjectClass

} // namespace
