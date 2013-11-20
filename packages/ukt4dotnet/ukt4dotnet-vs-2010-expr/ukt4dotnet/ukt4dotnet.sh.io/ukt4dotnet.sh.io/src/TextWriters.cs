using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.utilities.Collections;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.io
{
    /// <summary>
    /// Represents a writer that can write a sequential series of characters. This class is abstract.
    /// </summary>
    public abstract class TextWriterClass : TextFilerClass
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
            private bool F_TextWriterClass_IsReady;
        
            public TextWriterClass(): base()
            {
                // --> clear status
                F_TextWriterClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // TextWriterClass()        
      
            public override bool IsReady()
            {
                bool Result = F_TextWriterClass_IsReady;
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
                F_TextWriterClass_IsReady = true;

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
                F_TextWriterClass_IsReady = false;

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

    } // class TextWriterClass

} // namespace
