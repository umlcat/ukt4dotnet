using System;
using System.IO;
using System.Text;
using romo.shared.objects;
using romo.shared.utilities;
using romo.shared.utilities.Interfaces;
using romo.shared.utilities.InterfacesSupport;

namespace romo.Serialization
{
    /// <summary>
    /// Provides an abstract base class,
    /// for custom serialization of objects.
    /// Inspired by: <url>www.sharpserializer.com</url>
    /// </summary>
    public abstract class SerializerClass : ObjectClass
    {
        #region "constructor"
            /// <summary>
            /// Usese de forma similar a un metodo constructor, virtual, por-de-facto.
            /// El verdadero metodo constructor, debe ejecutarse sin parametros,
            /// y no debe ejecutar codigo alguno.
            /// Ejemplo:
            /// <code>
            /// ObjectClass MyObject = new ObjectClass();
            /// MyObject.create();
            /// // ...
            /// MyObject.destroy();
            /// MyObject = null;
            /// </code>
            /// </summary>
        public override Int64 Create()
            {
                Int64 Result = 0;
                Result = base.Create();
                return Result;
            } // public override Int64 Create(...)
        #endregion "constructor"

        #region "destructor"
            /// <summary>
            /// Usese de forma similar a un metodo destructor, virtual, por-de-facto.
            /// El verdadero metodo destructor, debe ejecutarse sin parametros,
            /// y no debe ejecutar codigo alguno.
            /// Ejemplo:
            /// <code>
            /// ObjectClass MyObject = new ObjectClass();
            /// MyObject.create();
            /// // ...
            /// MyObject.destroy();
            /// MyObject = null;
            /// </code>
            /// </summary>
            public override Int64 Destroy()
            {
                Int64 Result = 0;
                Result = base.Destroy();
                return Result;
            } // public override Int64 Destroy(...)
        #endregion "destructor"

        #region "methods"
            /// <summary>
            /// Indicates if this class uses a custom binary format,
            /// for serialization.
            /// </summary>
            /// <returns>Result of operation</returns>
            public virtual bool IsBinary()
            {
                bool Result = false;

                this.DoNothing();

                return Result;
            } // bool IsBinary(...)

            public virtual void Serialize(Stream Destination, object Data)
            {
                this.DoNothing();
            } // void Serialize(...)

            public virtual void Deserialize(Stream Source, object Data)
            {
                this.DoNothing();
            } // void Deserialize(...)
        #endregion "methods"

        #region "alias"
            /* ## nonvirtual */
            public bool isBinary()
            {
                bool Result = this.IsBinary();

                return Result;
            } // bool isBinary(...)

            /* ## nonvirtual */
            public bool isbinary()
            {
                bool Result = this.IsBinary();

                return Result;
            } // bool isbinary(...)

            /* ## nonvirtual */
            public void serialize(Stream Destination, object Data)
            {
                this.Serialize(Destination, Data);
            } // void serialize(...)

            public virtual void deserialize(Stream Source, object Data)
            {
                this.Deserialize(Source, Data);
            } // void deserialize(...)
        #endregion "alias"

        // ...

    } // class SerializerClass

    public class SerializerSettingsClass : ObjectClass
    {
        #region "properties"
            protected SerializerClass _Serializer;
            /// <summary>
            /// Reference to serializer class,
            /// that uses this settings manager.
            /// </summary>
            public SerializerClass Serializer
            {
                get { return _Serializer; }
                set { _Serializer = value; }
            }
        #endregion "properties"

        #region "constructor"
        /// <summary>
        /// Usese de forma similar a un metodo constructor, virtual, por-de-facto.
        /// El verdadero metodo constructor, debe ejecutarse sin parametros,
        /// y no debe ejecutar codigo alguno.
        /// Ejemplo:
        /// <code>
        /// ObjectClass MyObject = new ObjectClass();
        /// MyObject.create();
        /// // ...
        /// MyObject.destroy();
        /// MyObject = null;
        /// </code>
        /// </summary>
            public override Int64 Create()
        {
            Int64 Result = 0;
                Result = base.Create();
            return Result;
        } // public override Int64 Create(...)
        #endregion "constructor"

        #region "destructor"
        /// <summary>
        /// Usese de forma similar a un metodo destructor, virtual, por-de-facto.
        /// El verdadero metodo destructor, debe ejecutarse sin parametros,
        /// y no debe ejecutar codigo alguno.
        /// Ejemplo:
        /// <code>
        /// ObjectClass MyObject = new ObjectClass();
        /// MyObject.create();
        /// // ...
        /// MyObject.destroy();
        /// MyObject = null;
        /// </code>
        /// </summary>
        public override Int64 Destroy()
        {
            Int64 Result = 0;
              Result = base.Destroy();
            return Result;
        } // public override Int64 Destroy(...)
        #endregion "destructor"

        // ...

    } // class SerializerSettingsClass

    public abstract class SettingsSerializerClass : SerializerClass
    {
        #region "properties"
            protected SerializerSettingsClass _Settings;
            public SerializerSettingsClass Settings
            {
                get { return _Settings; }
                set { _Settings = value; }
            }
        #endregion "properties"

        #region "constructor"

            public virtual SerializerSettingsClass internalCreateSettings()
            {
                SerializerSettingsClass Result = new SerializerSettingsClass();
                Result.Create();

                return Result;
            } // SerializerSettingsClass createSettings(...)

            /* public nonvirtual */
            public SerializerSettingsClass createSettings()
            {
                SerializerSettingsClass Result = internalCreateSettings();

                Result.Serializer = this;

                return Result;
            } // SerializerSettingsClass createSettings(...)

        /// <summary>
        /// Usese de forma similar a un metodo constructor, virtual, por-de-facto.
        /// El verdadero metodo constructor, debe ejecutarse sin parametros,
        /// y no debe ejecutar codigo alguno.
        /// Ejemplo:
        /// <code>
        /// ObjectClass MyObject = new ObjectClass();
        /// MyObject.create();
        /// // ...
        /// MyObject.destroy();
        /// MyObject = null;
        /// </code>
        /// </summary>
        public override Int64 Create()
        {
            Int64 Result = 0;
              this._Settings = createSettings();
            return Result;
        } // public override Int64 Create(...)

        #endregion "constructor"

        #region "destructor"
        /// <summary>
        /// Usese de forma similar a un metodo destructor, virtual, por-de-facto.
        /// El verdadero metodo destructor, debe ejecutarse sin parametros,
        /// y no debe ejecutar codigo alguno.
        /// Ejemplo:
        /// <code>
        /// ObjectClass MyObject = new ObjectClass();
        /// MyObject.create();
        /// // ...
        /// MyObject.destroy();
        /// MyObject = null;
        /// </code>
        /// </summary>
        public override Int64 Destroy()
        {
            Int64 Result = 0;
            this._Settings.Destroy();
              this._Settings = null;
            return Result;
        } // public override Int64 Destroy(...)

        // ...

        #endregion "destructor"

        // ...

    } // class SettingsSerializerClass

    public class XMLSerializerSettingsClass : SerializerSettingsClass
    {
        #region "properties"
            protected string _RootName;
            /// <summary>
            /// Indicates a custom root tag for the X.M.L. file.
            /// Requires <code>OverrideRootName = true</code>,
            /// and <code>IgnoreRootName = false</code>.
            /// </summary>
            public string RootName
            {
                get { return _RootName; }
                set { _RootName = value; }
            }

            protected bool _OverrideRootName;
            /// <summary>
            /// Indicates, that a custom root tag for the X.M.L. file,
            /// will be used.
            /// requires <code>IgnoreRootName = true</code>.
            /// </summary>
            public bool OverrideRootName
            {
                get { return _OverrideRootName; }
                set { _OverrideRootName = value; }
            }

            protected bool _IgnoreRootName;
            /// <summary>
            /// Indicates that a root tag, will not be generated directly,
            /// but, an internal root object, will be used, instead.
            /// </summary>
            public bool IgnoreRootName
            {
                get { return _IgnoreRootName; }
                set { _IgnoreRootName = value; }
            }
        #endregion "properties"

        #region "constructor"

        public override Int64 Create()
        {
            Int64 Result = 0;
              this.IgnoreRootName = false;
              this.OverrideRootName = false;
              this.RootName = "root";            
            return Result;
        } // public override Int64 Create(...)

        #endregion "constructor"

    } // class XMLSerializerSettingsClass

    public abstract class XMLSerializerClass : SettingsSerializerClass
    {
        #region "constructor"

            public override SerializerSettingsClass internalCreateSettings()
            {
                SerializerSettingsClass Result = new XMLSerializerSettingsClass();
                Result.Create();

                return Result;
            } // SerializerSettingsClass createSettings(...)

        #endregion "constructor"

        #region "methods"
            /// <summary>
            /// Indicates if this class uses a custom binary format,
            /// for serialization.
            /// </summary>
            /// <returns>Result of operation</returns>
            public override bool IsBinary()
            {
                bool Result = false;

                Result = false;

                return Result;
            } // bool IsBinary(...)

            public override void Serialize(Stream Destination, object Data)
            {
                this.DoNothing();
            } // void Serialize(...)

            public override void Deserialize(Stream Source, object Data)
            {
                this.DoNothing();
            } // void Deserialize(...)
        #endregion "methods"

        // ...

    } // class XMLSerializerClass

    // ...

} // namespace romo.shared.utilities