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
    /// Represents a reader that can read a sequential series of characters.
    /// </summary>
    public abstract class TextReaderClass : TextFilerClass
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
            private bool F_TextReaderClass_IsReady;
        
            public TextReaderClass(): base()
            {
                // --> clear status
                F_TextReaderClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // TextReaderClass()        
      
            public override bool IsReady()
            {
                bool Result = F_TextReaderClass_IsReady;
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
                F_TextReaderClass_IsReady = true;

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
                F_TextReaderClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public override void Close()
            {
                this.DoNothing();
            } // void Close(...)

            // ...
        #endregion "methods"
        
        #region "static"
			// ...
			
		
            // ...
        #endregion "static"

        // ...

    } // class TextReaderClass

} // namespace
