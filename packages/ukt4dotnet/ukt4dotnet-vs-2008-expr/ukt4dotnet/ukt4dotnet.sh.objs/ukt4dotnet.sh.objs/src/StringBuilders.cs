using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.utilities.Collections;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.text
{
    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class StringBuilderClass : CloneableObjectClass
    {
        #region "support"
            private bool F_StringBuilderClass_IsReady;

            public StringBuilderClass()
                : base()
            {
                // --> clear status
                F_StringBuilderClass_IsReady = false;

                // --> clear fields
                F_Wrapped = null;
                F_LineBreak = null;
                F_PageBreak = null;
            } // StringBuilderClass()    

            public override bool IsReady()
            {
                bool Result = F_StringBuilderClass_IsReady;
                return Result;
            } // bool IsReady(...)

            // ...
        #endregion "support"

        #region "fields"
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            private System.Text.StringBuilder F_Wrapped;
            public System.Text.StringBuilder Wrapped
            {
                get { return F_Wrapped; }
                set { F_Wrapped = value; }
            }

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
                    this.F_Wrapped = new StringBuilder();

                    this.F_BlankMarker = " ";
                    this.F_TabMarker = "  ";

                    this.F_LineBreak = "\n";
                    this.F_PageBreak = "\xA";
                } // if (Result == 0)

                // --> update status
                F_StringBuilderClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_StringBuilderClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_Wrapped = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            public override string ToString()
            {
                string Result = this.Wrapped.ToString();
                return Result;
            } // string ToString(...)

            public int Length()
            {
                int Result = 0;

                Result = this.Wrapped.Length;
            
                return Result;
            }

            public virtual void Clear()
            {
                if (this.Wrapped != null)
                {
                    this.Wrapped = null;
                }
                
                this.Wrapped = new StringBuilder();
            } // virtual void Clear(...)

            public virtual void Append(String AMsg)
            {
                this.Wrapped.Append(AMsg);

            } // void Append(...)

            public virtual void AppendLine(String AMsg)
            {
                this.Wrapped.Append(AMsg);
                this.Wrapped.Append(F_LineBreak);

            } // void AppendLine(...)

            public virtual void AppendPage(String AMsg)
            {
                this.Wrapped.Append(AMsg);
                this.Wrapped.Append(F_PageBreak);

            } // void AppendPage(...)

            public virtual void AppendLineBreak()
            {
                this.Wrapped.Append(F_LineBreak);

            } // void AppendLineBreak(...)

            public virtual void AppendPageBreak()
            {
                this.Wrapped.Append(F_PageBreak);

            } // void AppendPageBreak(...)

            // ...
        #endregion "methods"

        #region "static"
            // ...

            /// <summary>
            /// Construye un nuevo objeto de la clase <code>StringBuilderClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static StringBuilderClass Factory()
            {
                StringBuilderClass Result = new StringBuilderClass();
                Result.Create();

                return Result;
            } // static StringBuilderClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>StringBuilderClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref StringBuilderClass AObject)
            {
                if (AObject != null)
                {
                    AObject.Destroy();
                    AObject = null;
                } // if (AObject != null)
            } // public static void Disposer(...)

            // ...
        #endregion "static"
        
        // ...

    } // class StringBuilderClass

    // ...

    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class HTMLStringBuilderClass : StringBuilderClass
    {
        #region "fields"
        // ...
        #endregion "fields"

        #region "properties"
        // ...

        // ...
        #endregion "properties"

        #region "support"
            // ...
        
            private bool F_HTMLStringBuilderClass_IsReady;
            
            public HTMLStringBuilderClass() : base()
            {
                // --> clear status
                F_HTMLStringBuilderClass_IsReady = false;
                
                // --> clear fields
            } // HTMLStringBuilderClass()

            public override bool IsReady()
            {
                bool Result = F_HTMLStringBuilderClass_IsReady;
                return Result;
            } // bool IsReady(...)

            // ...
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
                F_HTMLStringBuilderClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_HTMLStringBuilderClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    // ...
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
        // ...

        //public void

        // ...
        #endregion "methods"

        // ...

    } // class HTMLStringBuilderClass

    // ...

} // namespace
