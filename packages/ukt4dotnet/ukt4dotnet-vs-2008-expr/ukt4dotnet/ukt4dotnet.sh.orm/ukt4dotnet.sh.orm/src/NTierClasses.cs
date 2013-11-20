using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.ntier;
using ukt4dotnet.shared.orm;
using ukt4dotnet.shared.utilities.Collections;

namespace ukt4dotnet.shared.ntier
{
    // ...

    /// <summary>
    /// Base class for the stand-alone properties,
    /// of a <code>DataAccessEntityClass</code> object.
    /// </summary>
    public class DataAccessPropertiesClass : ORMPlainDataObjectClass
    {
        // ...

        // ...
    } // class DataAccessPropertiesClass

    /// <summary>
    /// Base class for the stand-alone properties,
    /// of a <code>BusinessLogicEntityClass</code> object.
    /// </summary>
    public class BusinessLogicPropertiesClass : ORMPlainDataObjectClass
    {
        // ...

        // ...
    } // class BusinessLogicPropertiesClass

    /// <summary>
    /// Base class for the stand-alone properties,
    /// of a <code>UserInterfaceEntityClass</code> object.
    /// </summary>
    public class UserInterfacePropertiesClass : ORMPlainDataObjectClass
    {
        // ...

        // ...
    } // class UserInterfacePropertiesClass

    // ...

    /// <summary>
    /// Base class for entity classes sended,
    /// or received from a Web Service.
    /// </summary>
    public class WSEntityClass : ORMWarehouseEntityClass
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
            private bool F_WSEntityClass_IsReady;
        
            public WSEntityClass(): base()
            {
                // --> clear status
                F_WSEntityClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // WSEntityClass()        
      
            public override bool IsReady()
            {
                bool Result = F_WSEntityClass_IsReady;
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
                F_WSEntityClass_IsReady = true;

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
                F_WSEntityClass_IsReady = false;

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
            /// Construye un nuevo objeto de la clase <code>WSEntityClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static WSEntityClass Factory()
            {
                WSEntityClass Result = new WSEntityClass();
                Result.Create();

                return Result;
            } // static WSEntityClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>WSEntityClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref WSEntityClass AObject)
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

    } // class WSEntityClass

    // ...

    /// <summary>
    /// Clase base para los objetos entidad,
    /// que interactuan, en la Capa para Acceso a Datos,
    /// de una Aplicacion de Software.
    /// Tambien se les conoce como objetos para "B.D.",
    /// u objetos para "Persistencia".
    /// </summary>
    public class DataAccessEntityClass : ORMWarehouseEntityClass
    {
        // ...

        #region "fields"
        // ...


        // ...
        #endregion "fields"

        #region "properties"
            // ...

            // ...
        #endregion "properties"

        #region "constructors"
        // ...



        // ...
        #endregion "constructors"

        #region "methods"
            // ...

            // ...
        #endregion "methods"

        #region "static"
            // ...

        /*

        /// <summary>
        /// Convierte un registro basado en pares llave-valor,
        /// en una entidad <code>DataAccessEntityClass</code>.
        /// </summary>
        /// <param name="ARow">Registro basado en pares llave-valor</param>
        /// <returns>Destination Entity</returns>
        public static DataAccessEntityClass DictionaryToData
            (ORMWarehouseClass AWarehouse, Dictionary<string, Object> ARow)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // DataAccessEntityClass DictionaryToData(...)

        public static List<DataAccessEntityClass> DictionaryToDataList
            (ORMWarehouseClass AWarehouse, List<Dictionary<string, Object>> ARows)
        {
            List<DataAccessEntityClass> Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<DataAccessEntityClass> DictionaryToDataList(...)

        /// <summary>
        /// Busca la entidad que tenga la llave proporcionada,
        /// o <code>null</code> en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad que tiene la llave indicada</returns>
        public static DataAccessEntityClass FindNOTDefault
            (ORMWarehouseClass AWarehouse, object AKey)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass FindNOTDefault(...)

        /// <summary>
        /// Busca la entidad que corresponde al registro, por-de-facto,
        /// o <code>null</code> en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad por-de-facto</returns>
        public static DataAccessEntityClass FindDefault
            (ORMWarehouseClass AWarehouse)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass FindDefault(...)

        /// <summary>
        /// Busca la entidad que tenga la llave proporcionada,
        /// o registro, por-de-facto, en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad que tiene la llave indicada</returns>
        public static DataAccessEntityClass FindORDefault
            (ORMWarehouseClass AWarehouse, object AKey)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass FindORDefault(...)

        /// <summary>
        /// Regresa el primer registro, de una lista de registros,
        /// que cumpla con los filtros proporcionados,
        /// en caso de no coincidir, regresa <code>null</code>.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static DataAccessEntityClass First
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass First(...)

        /// <summary>
        /// Regresa el primer registro, de una lista de registros,
        /// que cumpla con los filtros proporcionados,
        /// en caso de no coincidir, regresa el registro, por-de-facto.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static DataAccessEntityClass FirstORDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass FirstORDefault(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// incluyendo registro "defacto", si coincide,
        /// con el criterio, o excluyendolo, en caso contrario.
        /// En caso de no encontrar algun registro,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<DataAccessEntityClass>
             Select(ORMWarehouseClass AWarehouse)
        {
            List<DataAccessEntityClass> Result = new List<DataAccessEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<DataAccessEntityClass> Select(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// incluyendo registro "defacto", si coincide,
        /// con el criterio, o excluyendolo, en caso contrario.
        /// En caso de no encontrar algun registro,
        /// regresa la lista, con el registro por-de-facto.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<DataAccessEntityClass>
             SelectORDefault(ORMWarehouseClass AWarehouse)
        {
            List<DataAccessEntityClass> Result = new List<DataAccessEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<DataAccessEntityClass> SelectORDefault(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// excluyendo registro "defacto".
        /// En caso de no encontrar algun registro,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<DataAccessEntityClass>
             SelectNotDefault(ORMWarehouseClass AWarehouse)
        {
            List<DataAccessEntityClass> Result = new List<DataAccessEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<DataAccessEntityClass> SelectNotDefault(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados.
        /// En caso de no haber registros que coincidan,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static DataAccessEntityClass Where
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass Where(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados,
        /// En caso de no haber registros que coincidan,
        /// regresa la lista, incluyendo el registro, por-de-facto,
        /// aunque no coincida con los criterios.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static DataAccessEntityClass WhereORDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass WhereORDefault(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados,
        /// exlucyendo, explicitamente, el registro por-de-facto.
        /// En caso de no haber registros que coincidan,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static DataAccessEntityClass WhereNotDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            DataAccessEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static DataAccessEntityClass WhereORDefault(...)

        */

        /// <summary>
            /// Desecha objeto de la clase <code>DataAccessEntityClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref DataAccessEntityClass AObject)
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
    } // class DataAccessEntityClass

    /// <summary>
    /// Clase base para los objetos entidad,
    /// que interactuan, en la Capa para Logica de Negocios,
    /// de una Aplicacion de Software.
    /// Tambien se les conoce como objetos de "control".
    /// </summary>
    public class BusinessLogicEntityClass : ORMWarehouseEntityClass
    {
        // ...

        #region "fields"
            // ...


            // ...
        #endregion "fields"

        #region "properties"
            // ...

            // ...
        #endregion "properties"

        #region "constructors"
        // ...



        // ...
        #endregion "constructors"

        #region "methods"
            // ...

            /// <summary>
            /// Guarda las propiedades de este objeto de logica-negocios
            /// en un objeto de acceso-datos.
            /// </summary>
            public virtual void SaveTo(ref DataAccessEntityClass Destination)
            {
                this.DoNothing();
            } // void SaveTo(...)

            /// <summary>
            /// Lee las propiedades de este objeto de logica-negocios
            /// de un objeto de acceso-datos.
            /// </summary>
            public virtual void LoadFrom(DataAccessEntityClass Source)
            {
                this.DoNothing();
            } // void LoadFrom(...)

            // ...
        #endregion "methods"

        #region "static"
            // ...

        /*

        /// <summary>
        /// Busca la entidad que tenga la llave proporcionada,
        /// o <code>null</code> en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad que tiene la llave indicada</returns>
        public static BusinessLogicEntityClass FindNOTDefault
            (ORMWarehouseClass AWarehouse, object AKey)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass FindNOTDefault(...)

        /// <summary>
        /// Busca la entidad que corresponde al registro, por-de-facto,
        /// o <code>null</code> en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad por-de-facto</returns>
        public static BusinessLogicEntityClass FindDefault
            (ORMWarehouseClass AWarehouse)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass FindDefault(...)

        /// <summary>
        /// Busca la entidad que tenga la llave proporcionada,
        /// o registro, por-de-facto, en caso contrario.
        /// </summary>
        /// <param name="AKey">Llave buscada</param>
        /// <returns>Entidad que tiene la llave indicada</returns>
        public static BusinessLogicEntityClass FindORDefault
            (ORMWarehouseClass AWarehouse, object AKey)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass FindORDefault(...)

        /// <summary>
        /// Regresa el primer registro, de una lista de registros,
        /// que cumpla con los filtros proporcionados,
        /// en caso de no coincidir, regresa <code>null</code>.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static BusinessLogicEntityClass First
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass First(...)

        /// <summary>
        /// Regresa el primer registro, de una lista de registros,
        /// que cumpla con los filtros proporcionados,
        /// en caso de no coincidir, regresa el registro, por-de-facto.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static BusinessLogicEntityClass FirstORDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass FirstORDefault(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// incluyendo registro "defacto", si coincide,
        /// con el criterio, o excluyendolo, en caso contrario.
        /// En caso de no encontrar algun registro,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<BusinessLogicEntityClass>
             Select(ORMWarehouseClass AWarehouse)
        {
            List<BusinessLogicEntityClass> Result = new List<BusinessLogicEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<BusinessLogicEntityClass> Select(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// incluyendo registro "defacto", si coincide,
        /// con el criterio, o excluyendolo, en caso contrario.
        /// En caso de no encontrar algun registro,
        /// regresa la lista, con el registro por-de-facto.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<BusinessLogicEntityClass>
             SelectORDefault(ORMWarehouseClass AWarehouse)
        {
            List<BusinessLogicEntityClass> Result = new List<BusinessLogicEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<BusinessLogicEntityClass> SelectORDefault(...)

        /// <summary>
        /// Regresa todos los registros de la tabla indicada,
        /// excluyendo registro "defacto".
        /// En caso de no encontrar algun registro,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse"></param>
        /// <returns>Todos los Registros</returns>
        public static List<BusinessLogicEntityClass>
             SelectNotDefault(ORMWarehouseClass AWarehouse)
        {
            List<BusinessLogicEntityClass> Result = new List<BusinessLogicEntityClass>();

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static List<BusinessLogicEntityClass> SelectNotDefault(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados.
        /// En caso de no haber registros que coincidan,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static BusinessLogicEntityClass Where
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass Where(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados,
        /// En caso de no haber registros que coincidan,
        /// regresa la lista, incluyendo el registro, por-de-facto,
        /// aunque no coincida con los criterios.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static BusinessLogicEntityClass WhereORDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass WhereORDefault(...)

        /// <summary>
        /// Regresa todos los registros,
        /// que cumplan con los filtros proporcionados,
        /// exlucyendo, explicitamente, el registro por-de-facto.
        /// En caso de no haber registros que coincidan,
        /// regresa la lista vacia.
        /// </summary>
        /// <param name="AWarehouse">B.D.</param>
        /// <param name="Filters">Lista de Predicados</param>
        /// <returns>Primer registro encontrado</returns>
        public static BusinessLogicEntityClass WhereNotDefault
            (ORMWarehouseClass AWarehouse, FilterListClass Filters)
        {
            BusinessLogicEntityClass Result = null;

            // Se "sobrecargara" este codigo en clases descendientes

            return Result;
        } // static BusinessLogicEntityClass WhereORDefault(...)

        */

        // ...
        #endregion "static"

        // ...
    } // class BusinessLogicEntityClass

    /// <summary>
    /// Base class for entity objects that interact,
    /// at the Presentation Layer, of a Software Application.
    /// Also known as "Boundary" objects, or "(Graphical) Interface" objects.
    /// </summary>
    public class UserInterfaceEntityClass : ORMWarehouseEntityClass
    {
        // ...

        #region "fields"
            // ...


            // ...
        #endregion "fields"

        #region "properties"
            // ...

            // ...
        #endregion "properties"

        #region "constructors"
        // ...



        // ...
        #endregion "constructors"

        #region "methods"
            // ...

            // ...
        #endregion "methods"

        #region "static"
        // ...

        // ...
        #endregion "static"

        // ...
    } // class UserInterfaceEntityClass

    // ...
} // namespace