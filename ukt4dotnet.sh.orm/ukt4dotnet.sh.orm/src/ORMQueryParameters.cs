using System;
using System.Collections.Generic;
using System.Text;
using romo.shared.utilities;
using romo.shared.objects;
using romo.shared.collections;

namespace romo.shared.orm
{




    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class ORMQueryParamsClass : CloneableObjectClass
    {
        #region "fields"
            // ...
            
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            /// <summary>
            /// Indica si se buscaran datos de una sola tabla.
            /// </summary>
            public bool WantSingleTable;
            /// <summary>
            /// Indica si se regresaran datos de una sola columna.
            /// </summary>
            public bool WantSingleColumn;

            /// <summary>
            /// Identificador de la tabla,
            /// requiere <code>WantSingleTable</code>.
            /// </summary>
            public String TableName;

            /// <summary>
            /// Identificador de llave primaria,
            /// requiere <code>WantSingleTable</code>code>,
            /// requiere <code>TableName</code>.
            /// </summary>
            public String KeyFieldName;

            /// <summary>
            /// Valor de la llave primaria,
            /// requiere <code>WantSingleTable</code>code>,
            /// requiere <code>TableName</code>.
            /// </summary>
            public String KeyFieldValue;

            /// <summary>
            /// Indica si se descartaran los registros,
            /// omitiendo aquellos que tengan esta bandera activada.
            /// </summary>
            public bool SkipDisabledRows;

            /// <summary>
            /// Indica si se agregara el registro,
            /// que se considera como "valor nulo",
            /// o, valor por-de-facto.
            /// </summary>
            public bool SkipDefaultRows;

            /// <summary>
            /// Identificador del campo tipo <code>bit</code>,
            /// que sirve para marcar como "borrado logico",
            /// a registros,
            /// requiere <code>WantSingleTable</code>code>,
            /// requiere <code>TableName</code>code>,
            /// requiere <code>SkipDisabledRows</code>.
            /// </summary>
            public String DisabledFieldName;

            /// <summary>
            /// Indica el valor de la llave primaria,
            /// que indica si un registro,
            /// se considerara como "valor nulo" o "valor por-de-facto",
            /// requiere <code>WantSingleTable</code>code>,
            /// requiere <code>TableName</code>code>,
            /// requiere <code>SingleTableName</code>code>,
            /// requiere <code>KeyFieldName</code>,
            /// </summary>
            public String DefaultFieldValue;

            private FilterListClass F_Filters;
            /// <summary>
            /// Lista de condiciones, que se utilizaran,
            /// para consultar, o, actualizar registros
            /// </summary>
            public FilterListClass Filters
            {
                get { return F_Filters; }
                set { F_Filters = value; }
            }

            private bool _IsFiltersManaged;
            /// <summary>
            /// Indica si la propiedad <code>Filters</code>,
            /// es creada y destruida por esta clase.
            /// </summary>
            public bool IsFiltersManaged
            {
                get { return _IsFiltersManaged; }
                set { _IsFiltersManaged = value; }
            }

            // ...
        #endregion "properties"

        #region "support"
            private bool F_ORMQueryParamsClass_IsReady;
        
            public ORMQueryParamsClass(): base()
            {
                // --> clear status
                F_ORMQueryParamsClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // ORMQueryParamsClass()        
      
            public override bool IsReady()
            {
                bool Result = F_ORMQueryParamsClass_IsReady;
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
                    this.F_Filters = null;
                } // if (Result == 0)

                // --> update status
                F_ORMQueryParamsClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deallocate fields
                if (Result == 0)
                {
                    RemoveFilters();
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                // --> update status
                F_ORMQueryParamsClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...
			
            public void RemoveFilters()
            {
                if (this.IsFiltersManaged)
                {
                    if (this.F_Filters != null)
                    {
                        FilterListClass.Disposer(ref this.F_Filters);
                    }
                } // if (this.IsFiltersManaged)

                this.F_Filters = null;
                this.IsFiltersManaged = false;
            } // public void RemoveFilters()

            public void AssociateFilters(FilterListClass ThisFilters)
            {
                RemoveFilters();

                if (ThisFilters != null)
                {
                    this.F_Filters = ThisFilters;
                } // if (EstaPersona != null)

                this.IsFiltersManaged = false;
            } // void AssociateFilters(...)

            public void SubordinateFilters(FilterListClass ThisFilters)
            {
                RemoveFilters();

                if (ThisFilters != null)
                {
                    this.F_Filters = ThisFilters;
                    this.IsFiltersManaged = true;
                } // if (ThisFilters != null)
            } // void SubordinateFilters(...)

            // ...
        #endregion "methods"
        
        #region "static"
			// ...
			
            /// <summary>
            /// Construye un nuevo objeto de la clase <code>ORMQueryParamsClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static ORMQueryParamsClass Factory()
            {
                ORMQueryParamsClass Result = new ORMQueryParamsClass();
                Result.Create();

                return Result;
            } // static ORMQueryParamsClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>ORMQueryParamsClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref ORMQueryParamsClass AObject)
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

    } // class ORMQueryParamsClass

    // ...

    /// <summary>
    /// Sirve para indicar diversos parametros,
    /// al ejecutar una consulta para S.Q.L.
    /// Evita que se esten agregando condiciones,
    /// ("filtros" o "predicados"), comunmente utilizados.
    /// </summary>
    public class ORMSelectParamsClass : ORMQueryParamsClass
    {
        #region "fields"
        // ...

        // ...
        #endregion "fields"

        #region "properties"
        // ...

        /// <summary>
        /// Identificador de la columna,
        /// requiere <code>WantSingleTable</code>code>,
        /// requiere <code>WantSingleColumn<code>.
        /// </summary>
        public String FieldName;

        // ...
        #endregion "properties"

        #region "support"
        private bool F_ORMSelectParamsClass_IsReady;

        public ORMSelectParamsClass()
            : base()
        {
            // --> clear status
            F_ORMSelectParamsClass_IsReady = false;

            // --> clear fields
            // ...
        } // ORMSelectParamsClass()        

        public override bool IsReady()
        {
            bool Result = F_ORMSelectParamsClass_IsReady;
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
            F_ORMSelectParamsClass_IsReady = true;

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
            F_ORMSelectParamsClass_IsReady = false;

            return Result;
        } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
        // ...

        // ...
        #endregion "methods"

        #region "static"
        // ...

        /// <summary>
        /// Construye un nuevo objeto de la clase <code>ORMSelectParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// y ejecuta el inicializador virtual, por-de-facto.
        /// Para ejecutar otro inicializador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <returns>Nuevo objeto</returns>
        new public static ORMSelectParamsClass Factory()
        {
            ORMSelectParamsClass Result = new ORMSelectParamsClass();
            Result.Create();

            return Result;
        } // static ORMSelectParamsClass Factory(...)

        /// <summary>
        /// Desecha objeto de la clase <code>ORMSelectParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// ejecutando el metodo finalizador, por-de-facto.
        /// Para ejecutar otro finalizador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <param name="AObject">Objeto que se desechara de memoria</param>
        public static void Disposer(ref ORMSelectParamsClass AObject)
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

    } // class ORMSelectParamsClass

    // ...

    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class AlterClass : ORMQueryParamsClass
    {
        #region "fields"
        // ...

        // ...
        #endregion "fields"

        #region "properties"
        // ...

        private Dictionary<string, Object> F_Record;
        public Dictionary<string, Object> Record
        {
            get { return F_Record; }
            set { F_Record = value; }
        }

        // ...
        #endregion "properties"

        #region "support"
        private bool F_AlterClass_IsReady;

        public AlterClass()
            : base()
        {
            // --> clear status
            F_AlterClass_IsReady = false;

            // --> clear fields
            // ...
        } // AlterClass()        

        public override bool IsReady()
        {
            bool Result = F_AlterClass_IsReady;
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
                this.F_Record = null;
            } // if (Result == 0)

            // --> update status
            F_AlterClass_IsReady = true;

            return Result;
        } // public override Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;

            // --> deallocate fields
            if (Result == 0)
            {
                this.F_Record = null;
            } // if (Result == 0)

            // --> execute inherited destructor
            Result = base.Destroy();

            // --> update status
            F_AlterClass_IsReady = false;

            return Result;
        } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
        // ...

        // ...
        #endregion "methods"

        #region "static"
        // ...

        /// <summary>
        /// Construye un nuevo objeto de la clase <code>AlterClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// y ejecuta el inicializador virtual, por-de-facto.
        /// Para ejecutar otro inicializador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <returns>Nuevo objeto</returns>
        new public static AlterClass Factory()
        {
            AlterClass Result = new AlterClass();
            Result.Create();

            return Result;
        } // static AlterClass Factory(...)

        /// <summary>
        /// Desecha objeto de la clase <code>AlterClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// ejecutando el metodo finalizador, por-de-facto.
        /// Para ejecutar otro finalizador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <param name="AObject">Objeto que se desechara de memoria</param>
        public static void Disposer(ref AlterClass AObject)
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

    } // class AlterClass

    // ...

    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class ORMUpdateParamsClass : AlterClass
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
        private bool F_ORMUpdateParamsClass_IsReady;

        public ORMUpdateParamsClass()
            : base()
        {
            // --> clear status
            F_ORMUpdateParamsClass_IsReady = false;

            // --> clear fields
            // ...
        } // ORMUpdateParamsClass()        

        public override bool IsReady()
        {
            bool Result = F_ORMUpdateParamsClass_IsReady;
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
            F_ORMUpdateParamsClass_IsReady = true;

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
            F_ORMUpdateParamsClass_IsReady = false;

            return Result;
        } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
        // ...

        // ...
        #endregion "methods"

        #region "static"
        // ...

        /// <summary>
        /// Construye un nuevo objeto de la clase <code>ORMUpdateParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// y ejecuta el inicializador virtual, por-de-facto.
        /// Para ejecutar otro inicializador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <returns>Nuevo objeto</returns>
        new public static ORMUpdateParamsClass Factory()
        {
            ORMUpdateParamsClass Result = new ORMUpdateParamsClass();
            Result.Create();

            return Result;
        } // static ORMUpdateParamsClass Factory(...)

        /// <summary>
        /// Desecha objeto de la clase <code>ORMUpdateParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// ejecutando el metodo finalizador, por-de-facto.
        /// Para ejecutar otro finalizador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <param name="AObject">Objeto que se desechara de memoria</param>
        public static void Disposer(ref ORMUpdateParamsClass AObject)
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

    } // class ORMUpdateParamsClass

    // ...

    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class ORMInsertParamsClass : AlterClass
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
        private bool F_ORMInsertParamsClass_IsReady;

        public ORMInsertParamsClass()
            : base()
        {
            // --> clear status
            F_ORMInsertParamsClass_IsReady = false;

            // --> clear fields
            // ...
        } // ORMInsertParamsClass()        

        public override bool IsReady()
        {
            bool Result = F_ORMInsertParamsClass_IsReady;
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
            F_ORMInsertParamsClass_IsReady = true;

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
            F_ORMInsertParamsClass_IsReady = false;

            return Result;
        } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
        // ...

        // ...
        #endregion "methods"

        #region "static"
        // ...

        /// <summary>
        /// Construye un nuevo objeto de la clase <code>ORMInsertParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// y ejecuta el inicializador virtual, por-de-facto.
        /// Para ejecutar otro inicializador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <returns>Nuevo objeto</returns>
        new public static ORMInsertParamsClass Factory()
        {
            ORMInsertParamsClass Result = new ORMInsertParamsClass();
            Result.Create();

            return Result;
        } // static ORMInsertParamsClass Factory(...)

        /// <summary>
        /// Desecha objeto de la clase <code>ORMInsertParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// ejecutando el metodo finalizador, por-de-facto.
        /// Para ejecutar otro finalizador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <param name="AObject">Objeto que se desechara de memoria</param>
        public static void Disposer(ref ORMInsertParamsClass AObject)
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

    } // class ORMInsertParamsClass

    // ...

    /// <summary>
    /// A template for entity classes.
    /// </summary>
    public class ORMDeleteParamsClass : ORMQueryParamsClass
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
        private bool F_ORMDeleteParamsClass_IsReady;

        public ORMDeleteParamsClass()
            : base()
        {
            // --> clear status
            F_ORMDeleteParamsClass_IsReady = false;

            // --> clear fields
            // ...
        } // ORMDeleteParamsClass()        

        public override bool IsReady()
        {
            bool Result = F_ORMDeleteParamsClass_IsReady;
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
            F_ORMDeleteParamsClass_IsReady = true;

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
            F_ORMDeleteParamsClass_IsReady = false;

            return Result;
        } // public override Int64 Destroy(...)

        // ...
        #endregion "constructors"

        #region "methods"
        // ...

        // ...
        #endregion "methods"

        #region "static"
        // ...

        /// <summary>
        /// Construye un nuevo objeto de la clase <code>ORMDeleteParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// y ejecuta el inicializador virtual, por-de-facto.
        /// Para ejecutar otro inicializador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <returns>Nuevo objeto</returns>
        new public static ORMDeleteParamsClass Factory()
        {
            ORMDeleteParamsClass Result = new ORMDeleteParamsClass();
            Result.Create();

            return Result;
        } // static ORMDeleteParamsClass Factory(...)

        /// <summary>
        /// Desecha objeto de la clase <code>ORMDeleteParamsClass</code>,
        /// que desciende de <code>ObjectClass</code>,
        /// ejecutando el metodo finalizador, por-de-facto.
        /// Para ejecutar otro finalizador,
        /// se tiene que realizar estas operaciones como pasos separados.
        /// </summary>
        /// <param name="AObject">Objeto que se desechara de memoria</param>
        public static void Disposer(ref ORMDeleteParamsClass AObject)
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

    } // class ORMDeleteParamsClass

    // ...

} // namespace
