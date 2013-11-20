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
    /// Implements a TextWriter for writing characters to a stream in a particular encoding.
    /// </summary>
    public class StreamWriterClass : TextWriterClass
    {
        #region "fields"
            // ...
            
            // ...
        #endregion "fields"

        #region "properties"
            // ...

        protected StreamWriter InternalWriter;

            // ...
        #endregion "properties"

        #region "support"
            private bool F_StreamWriterClass_IsReady;
        
            public StreamWriterClass(): base()
            {
                // --> clear status
                F_StreamWriterClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // StreamWriterClass()        
      
            public override bool IsReady()
            {
                bool Result = F_StreamWriterClass_IsReady;
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
                    //this.InternalWriter = new StreamWriter();

                    this.InternalWriter = null;
                } // if (Result == 0)

                // --> update status
                F_StreamWriterClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deallocate fields
                if (Result == 0)
                {
                    if (this.InternalWriter != null)
                    {
                        this.InternalWriter.Dispose();
                        this.InternalWriter = null;
                    } // if (this.InternalReader != null)
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                // --> update status
                F_StreamWriterClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...

            public virtual Int64 CreateByPath(String APath)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this.InternalWriter = new StreamWriter(APath);
                } // if (Result == 0)

                // --> update status
                F_StreamWriterClass_IsReady = true;

                return Result;
            } // public override Int64 CreateByPath(...)

            public virtual Int64 CreateByStream(StreamClass AStream)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this.InternalWriter = null;
                    //this.InternalReader = new StreamWriter(APath);
                } // if (Result == 0)

                // --> update status
                F_StreamWriterClass_IsReady = true;

                return Result;
            } // public override Int64 CreateByStream(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...
			
            // ...
        #endregion "methods"
        
        #region "static"
			// ...
			
            /// <summary>
            /// Construye un nuevo objeto de la clase <code>StreamWriterClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static StreamWriterClass Factory()
            {
                StreamWriterClass Result = new StreamWriterClass();
                Result.Create();

                return Result;
            } // static StreamWriterClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>StreamWriterClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref StreamWriterClass AObject)
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

    } // class StreamWriterClass

} // namespace
