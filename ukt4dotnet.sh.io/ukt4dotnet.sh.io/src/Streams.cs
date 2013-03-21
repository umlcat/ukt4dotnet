using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using romo.shared.utilities;
using romo.shared.utilities.Collections;
using romo.shared.objects;

namespace romo.shared.io
{
    /// <summary>
    /// Provides a generic view of a sequence of bytes.
    /// </summary>
    public abstract class StreamClass : ObjectClass
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
            private bool F_StreamClass_IsReady;
        
            public StreamClass(): base()
            {
                // --> clear status
                F_StreamClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // StreamClass()        
      
            public override bool IsReady()
            {
                bool Result = F_StreamClass_IsReady;
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
                    // ...
                } // if (Result == 0)

                // --> update status
                F_StreamClass_IsReady = true;

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
                F_StreamClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public abstract bool CanRead();

            public abstract bool CanSeek();

            public abstract bool CanWrite();

            public abstract bool CanTimeOut();

            // ...
        #endregion "methods"
        
        #region "static"
			// ...
			
		
            // ...
        #endregion "static"

        // ...

    } // class StreamClass

} // namespace
