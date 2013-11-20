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
    /// Implements a TextReader that reads characters from a byte stream in a particular encoding.
    /// </summary>
    public class StreamReaderClass : TextReaderClass
    {
        #region "fields"
            // ...
            
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            protected StreamReader InternalReader;

            // ...
        #endregion "properties"

        #region "support"
            private bool F_StreamReaderClass_IsReady;
        
            public StreamReaderClass(): base()
            {
                // --> clear status
                F_StreamReaderClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // StreamReaderClass()        
      
            public override bool IsReady()
            {
                bool Result = F_StreamReaderClass_IsReady;
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
                    //this.InternalReader = new StreamReader();

                    this.InternalReader = null;
                } // if (Result == 0)

                // --> update status
                F_StreamReaderClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deallocate fields
                if (Result == 0)
                {
                    if (this.InternalReader != null)
                    {
                        this.InternalReader.Dispose();
                        this.InternalReader = null;
                    } // if (this.InternalReader != null)
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                // --> update status
                F_StreamReaderClass_IsReady = false;

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
                    this.InternalReader = new StreamReader(APath);
                } // if (Result == 0)

                // --> update status
                F_StreamReaderClass_IsReady = true;

                return Result;
            } // public override Int64 CreateByPath(...)

            public virtual Int64 CreateByPathAppend
                (String APath, bool ApplyAppend)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this.InternalReader = new StreamReader(APath, ApplyAppend);
                } // if (Result == 0)

                // --> update status
                F_StreamReaderClass_IsReady = true;

                return Result;
            } // public override Int64 CreateByPathAppend(...)

            public virtual Int64 CreateByStream(StreamClass AStream)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this.InternalReader = null;
                    //this.InternalReader = new StreamReader(APath);
                } // if (Result == 0)

                // --> update status
                F_StreamReaderClass_IsReady = true;

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
            /// Construye un nuevo objeto de la clase <code>StreamReaderClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static StreamReaderClass Factory()
            {
                StreamReaderClass Result = new StreamReaderClass();
                Result.Create();

                return Result;
            } // static StreamReaderClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>StreamReaderClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref StreamReaderClass AObject)
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

    } // class StreamReaderClass

} // namespace
