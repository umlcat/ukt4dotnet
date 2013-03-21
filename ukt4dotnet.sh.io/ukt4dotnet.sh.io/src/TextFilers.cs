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
    /// Base class for classes accessing text.
    /// </summary>
    public abstract class TextFilerClass : ObjectClass
    {
        #region "fields"
            // ...
            
            // ...
        #endregion "fields"

        #region "properties"
            // ...
            
            private String F_BlankMarker;
            public String BlankMarker
            {
                get { return F_BlankMarker; }
                set { F_BlankMarker = value; }
            }

            private String F_TabMarker;
            public String TabMarker
            {
                get { return F_TabMarker; }
                set { F_TabMarker = value; }
            }

            private String F_LineBreak;
            public String LineBreak
            {
                get { return F_LineBreak; }
                set { F_LineBreak = value; }
            }

            private String F_PageBreak;
            public String PageBreak
            {
                get { return F_PageBreak; }
                set { F_PageBreak = value; }
            }

            // ...
        #endregion "properties"

        #region "support"
            private bool F_TextFilerClass_IsReady;
        
            public TextFilerClass(): base()
            {
                // --> clear status
                F_TextFilerClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // TextFilerClass()        
      
            public override bool IsReady()
            {
                bool Result = F_TextFilerClass_IsReady;
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
                    this.F_BlankMarker = " ";
                    this.F_TabMarker = "  ";

                    this.F_LineBreak = "\n";
                    this.F_PageBreak = "\xA";
                } // if (Result == 0)

                // --> update status
                F_TextFilerClass_IsReady = true;

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
                F_TextFilerClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public abstract void Close();

            // ...
        #endregion "methods"
        
        #region "static"
			// ...			
		
            // ...
        #endregion "static"

        // ...

    } // class TextFilerClass

} // namespace
