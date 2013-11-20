using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.utilities.Collections;

namespace ukt4dotnet.shared.orm
{
    /// <summary>
    /// Superclase de todos los objetos,
    /// que son parte del O.R.M.
    /// </summary>
    public class ORMClass : CloneableObjectClass
    {
        #region "fields"
            //private bool F_ORMClass_IsReady;
        #endregion "fields"

        #region "properties"
            protected string F_DBIdentifier;
            /// <summary>
            /// Es el identificador interno en la B.D. .
            /// </summary>
            public string DBIdentifier
            {
                get { return F_DBIdentifier; }
                set { F_DBIdentifier = value; }
            }
        #endregion "properties"

        #region "support"
            private bool F_ORMClass_IsReady;

            public ORMClass()
                : base()
            {
                // --> clear status
                F_ORMClass_IsReady = false;

                // --> clear fields
                F_DBIdentifier = null;
            } // ORMClass()

            public override bool IsReady()
            {
                bool Result = F_ORMClass_IsReady;
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
                    F_DBIdentifier = "";
                } // if (Result == 0)

                // --> update status
                F_ORMClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ORMClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_DBIdentifier = "";
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
            // ...

            // ...
        #endregion "methods"

      // ...

    } // class ORMClass

    /// <summary>
    /// Es la clase base para objetos que seran utilizados,
    /// para manejo de datos. Salvo casos especiales,
    /// casi no se utilizaran metodos, solo propiedades
    /// </summary>
    public class ORMPlainDataObjectClass : ORMClass
    {
        // ...

        // ...
    } // class ORMPlainDataObjectClass

    /// <summary>
    /// Superclase para entidades.
    /// En este caso, las propiedades,
    /// no se agregan directamente a la entidad,
    /// como se utilizan en varias metodologias,
    /// para Desarrollo de Software,
    /// sino que se almacenan en un "Plain  Old Data Object",
    /// que es propiedad de la entidad.
    /// Esto permite hacer encapsular de manera independiente,
    /// los datos, y agregar otras propiedades de uso interno.
    /// </summary>
    public class ORMEntityClass : ORMClass
    {
        #region "fields"
            // ...

            // ...
        #endregion "fields"

        #region "properties"
            // ...

            private ORMPlainDataObjectClass _Properties;
            /// <summary>
            /// Son las propiedades de la entidad.
            /// Se manejan como un objeto aparte,
            /// a proposito, en lugar de ser almacenadas,
            /// directamente en la entidad.
            /// </summary>
            public ORMPlainDataObjectClass Properties
            {
                get { return _Properties; }
                set { _Properties = value; }
            }

            // ...
        #endregion "properties"

        #region "support"
            private bool F_ORMEntityClass_IsReady;        
        
            public ORMEntityClass()
                : base()
            {
                // --> clear status
                F_ORMEntityClass_IsReady = false;

                // clear other fields
                this._Properties = null;
            } // ORMConnectionClass()

            public override bool IsReady()
            {
                bool Result = F_ORMEntityClass_IsReady;
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
                    this._Properties = AllocateProperties();
                    this.ClearProperties();
                } // if (Result == 0)

                // --> update status
                F_ORMEntityClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ORMEntityClass_IsReady = false;

                // --> deallocate fields
                if (Result == 0)
                {
                    if (this._Properties != null)
                    {
                        this._Properties.Destroy();
                        this._Properties = null;
                    } // if (this._Properties != null)
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
            // ...

            /// <summary>
            /// Prepara las propiedades especificas para la entidad.
            /// </summary>
            /// <returns></returns>
            public virtual ORMPlainDataObjectClass AllocateProperties()
            {
                ORMPlainDataObjectClass Result = null;
                
                this.DoNothing();
                
                return Result;
            } // ORMPlainDataObjectClass AllocateProperties(...)

            public virtual void ClearProperties()
            {
                this.DoNothing();
            } // virtual void ClearProperties(...)

            // ...

        #endregion "methods"

        // ...

    } // class ORMEntityClass


    // ...
} // namespace
