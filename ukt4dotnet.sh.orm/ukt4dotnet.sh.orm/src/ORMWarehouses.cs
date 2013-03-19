using System;
using System.Collections.Generic;
using System.Text;
using romo.shared.objects;
using romo.shared.utilities;
using romo.shared.collections;

namespace romo.shared.orm
{
    /// <summary>
    /// Superclase para declarar base-datos.
    /// </summary>
    public class ORMWarehouseClass : ORMClass
    {
        #region "fields"
            private bool F_Connected;
        #endregion "fields"

        #region "properties"
            protected string F_UserName;
            /// <summary>
            /// Usuario de la conexion.
            /// </summary>
            public string UserName
            {
                get { return F_UserName; }
                set { F_UserName = value; }
            }

            protected string F_Password;
            /// <summary>
            /// Usuario de la conexion.
            /// </summary>
            public string Password
            {
                get { return F_Password; }
                set { F_Password = value; }
            }

            /// <summary>
            /// Es el usuario que ingreso a la B.D.
            /// </summary>
            protected ORMEntityClass F_CurrentUser = null;
        #endregion "properties"

        #region "support"
        private bool F_ORMWarehouseClass_IsReady;

        public ORMWarehouseClass()
            : base()
        {
            // --> clear status              
            F_ORMWarehouseClass_IsReady = false;

            // --> clear fields
            F_Connected = false;
            F_UserName = null;
            F_Password = null;
        } // ORMConnectionClass()

        public override bool IsReady()
        {
            bool Result = F_ORMWarehouseClass_IsReady;
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
                this.F_Connected = false;
                this.F_UserName = "";
                this.F_Password = "";
            } // if (Result == 0)

            // --> update status
            F_ORMWarehouseClass_IsReady = true;

            return Result;
        } // public override Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;

            // --> update status
            F_ORMWarehouseClass_IsReady = false;

            // --> deallocate fields
            if (Result == 0)
            {
                this.F_Password = "";
                this.F_UserName = "";
                this.F_Connected = false;
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
            /// Indica si la conexion fue exitosa.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            public virtual bool IsConnected()
            {
                bool Result = false;

                Result = F_Connected;

                return Result;
            } // bool IsConnected()

            public virtual void Connect()
            {
                this.DoNothing();
            } // void Connect(...)

            public virtual void Disconnect()
            {
                this.DoNothing();
            } // void Disconnect(...)

            /// <summary>
            /// Propiedad de solo-lectura,
            /// regresa el usuario que se esta utilizando,
            /// para realizar operaciones.
            /// </summary>
            /// <returns>Usuario actual</returns>
            public ORMEntityClass CurrentUser()
            {
                return this.F_CurrentUser;
            } // ORMEntityClass CurrentUser(...)

            // ...

            public virtual ORMWarehouseEntityClass TableByID(string ATableID)
            {
                ORMWarehouseEntityClass Result = null;

                this.DoNothing();

                return Result;
            } // ORMWarehouseEntityClass TableByID(...)

            public virtual ORMWarehouseEntityClass CreateTable()
            {
                ORMWarehouseEntityClass Result = null;

                this.DoNothing();

                return Result;
            } // ORMWarehouseEntityClass CreateTable(...)

            public virtual void DropTableByObject(ORMWarehouseEntityClass ATableRef)
            {
                this.DoNothing();
            } // void dropTableByObject(...)

            public virtual void DropTableByID(string ATableID)
            {
                this.DoNothing();
            } // void dropTableByObject(...)

            // ...

            public virtual bool KeyFound
                (string ATableID, Object AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())          

                return Result;
            } // bool KeyFound(...)

            public virtual bool KeyFoundAsInt
                (string ATableID, Int32 AKeyValue)
            {
                bool Result = false;

                this.DoNothing();

                return Result;
            } // bool KeyFoundAsInt(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// Regresa todos los registros que apliquen para el criterio de busqueda,
            /// incluyendo registro "defacto", si coincide con el criterio,
            /// o excluyendolo, en caso contrario.
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Dictionary<string, Object>> Select
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Select(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// Regresa todos los registros que apliquen para el criterio de busqueda,
            /// excluyendo explicitamente registro "defacto".
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Dictionary<string, Object>> SelectNotDefault
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> SelectNotDefault(...)

            /// <summary>
            /// Realiza una consulta en una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// En caso de encontrar registros que cumplan el criterio
            /// de busqueda, los regresa, con excepcion del registro "de facto".
            /// En caso de no encontrar registro alguno,
            /// regresa la lista solo con el registro "de facto", si lo hay,
            /// aunque no cumpla con el criterio de busqueda,
            /// o lista vacia en caso contrario.
            /// </summary>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Dictionary<string, Object>> SelectORDefault
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> SelectORDefault(...)

            // ...


            /// <summary>
            /// Regresa una lista de registros, como pares llave-valor,
            /// de una sola tabla, que cumplan,
            /// con la lista de predicados proporcionada.
            /// Si hay registro nulo, o por-de-facto,
            /// se incluye si cumple con el criterio de busqueda.
            /// </summary>
            /// <param name="AParameters">Parametros para la consulta</param>
            /// <returns>Lista de Registros Resultante</returns>
            public virtual List<Dictionary<string, Object>> Where
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)

            /// <summary>
            /// Regresa una lista de registros, como pares llave-valor,
            /// de una sola tabla, que cumplan,
            /// con la lista de predicados proporcionada,
            /// excluyendo explicitamente registro "defacto".
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="AParameters">Parametros para la consulta</param>
            /// <returns>Lista de Registros Resultante</returns>
            public virtual List<Dictionary<string, Object>> WhereNOTDefault
                 (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> WhereNOTDefault(...)

            /// <summary>
            /// Regresa una lista de registros, como pares llave-valor,
            /// de una sola tabla, que cumplan,
            /// con la lista de predicados proporcionada,
            /// excluyendo explicitamente registro "defacto".
            /// En caso de no encontrar registro alguno,
            /// regresa la lista solo con el registro "de facto", si lo hay,
            /// aunque no cumpla con el criterio de busqueda,
            /// o lista vacia en caso contrario.
            /// </summary>
            /// <param name="AParameters">Parametros para la consulta</param>
            /// <returns>Lista de Registros Resultante</returns>
            public virtual List<Dictionary<string, Object>> WhereORDefault
                 (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (CanContinue)

                return Result;
            } // List<Dictionary<string, Object>> WhereORDefault(...)      

            /// <summary>
            /// Regresa una lista de registros, como pares llave-valor,
            /// de una sola tabla, que cumplan,
            /// con la lista de predicados proporcionada,
            /// Incluyendo explicitamente registro "defacto",
            /// aunque este registro no cumpla con la consulta.
            /// En caso de no encontrar registro alguno,
            /// regresa la lista solo con el registro "de facto", si lo hay,
            /// aunque no cumpla con el criterio de busqueda,
            /// o lista vacia en caso contrario.
            /// </summary>
            /// <param name="AParameters">Parametros para la consulta</param>
            /// <returns>Lista de Registros Resultante</returns>
            public virtual List<Dictionary<string, Object>> WhereANDDefault
                 (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> WhereANDDefault(...)

            // ...

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// Regresa el primer registro que aplique para el criterio de busqueda,
            /// que puede incluir o no, registro "defacto".
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="FilterClass">Lista de Condiciones o Predicados</param>
            /// <returns>Registro encontrado como lista llave-valor,
            /// <code>null</code>, en caso contrario</returns>
            public virtual Dictionary<string, Object> FirstMaybeDefault
                 (ORMSelectParamsClass AParameters)
            {
                Dictionary<string, Object> Result = new Dictionary<string, Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FirstMaybeDefault(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// Regresa el primer registro que aplique para el criterio de busqueda,
            /// excluyendo explicitamente registro "defacto".
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="FilterClass">Lista de Condiciones o Predicados</param>
            /// <returns>Registro encontrado como lista llave-valor,
            /// <code>null</code>, en caso contrario</returns>
            public virtual Dictionary<string, Object> FirstNOTDefault
                 (ORMSelectParamsClass AParameters)
            {
                Dictionary<string, Object> Result = new Dictionary<string, Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FirstNOTDefault(...)

            /// <summary>
            /// Realiza una consulta en una sola tabla,
            /// regresando todas las columnas.
            /// No realiza ninguna ordenacion.
            /// Regresa el primer registro que aplique para el criterio de busqueda,
            /// excluyendo explicitamente registro "defacto".
            /// En caso de no encontrar registro alguno,
            /// regresa solo el registro "de facto", si lo hay,
            /// aunque no cumpla con el criterio de busqueda,
            /// o lista vacia en caso contrario.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="FilterClass">Lista de Condiciones o Predicados</param>
            /// <returns>Registro encontrado como lista llave-valor,
            /// <code>null</code>, en caso contrario</returns>
            public virtual Dictionary<string, Object> FirstORDefault
                 (ORMSelectParamsClass AParameters)
            {
                Dictionary<string, Object> Result = new Dictionary<string, Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FirstORDefault(...)

            // ...

            /// <summary>
            /// Busca un registro, que coincida con el valor proporcionado,
            /// de la llave primaria.
            /// En caso de encontrar el registro,
            /// lo regresa como una lista llave-valor.
            /// En caso contrario, regresa la lista  vacia.
            /// El registro pudiese coincidir o no,
            /// con el registro nulo, o por-de-facto.
            /// Los valores de los campos deben ser proporcionados,
            /// en formato alfanumerico, compatible, para S.Q.L.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="AKeyField">Identificador de la columna o campo para llave primaria</param>
            /// <param name="AKeyDefaultValue">Valor de llave primaria, del registro por-de-facto</param>
            /// <returns>Registro buscado, como lista de llaves-valor</returns>
            public virtual Dictionary<string, Object> FindNOTDefault
                (string ATableID, string AKeyField, string AKeyValue)
            {
                Dictionary<string, Object> Result = new Dictionary<string, Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FindNOTDefault(...)

            /// <summary>
            /// Busca el registro, por de facto, o, nulo,
            /// de la tabla indicada.
            /// En caso de encontrar el registro,
            /// lo regresa como una lista llave-valor.
            /// En caso contrario, regresa la lista vacia.
            /// Los valores de los campos deben ser proporcionados,
            /// en formato alfanumerico, compatible, para S.Q.L.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="AKeyField">Identificador de la columna o campo para llave primaria</param>
            /// <param name="AKeyDefaultValue">Valor de llave primaria, del registro por-de-facto</param>
            /// <returns>Registro buscado, como lista de llaves-valor</returns>
            public virtual Dictionary<string, Object> FindDefault
                (string ATableID, string AKeyField, string AKeyDefaultValue)
            {
                Dictionary<string, Object> Result = new Dictionary<string, Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FindDefault(...)

            /// <summary>
            /// Busca un registro, que coincida con el valor proporcionado,
            /// de la llave primaria.
            /// En caso de encontrar el registro,
            /// lo regresa como una lista llave-valor.
            /// En caso contrario, trata de buscar el registro nulo, o  por de facto,
            /// y si lo encuentra, lo regresa, aunque no coincida con el criterio de busqueda.
            /// En caso de encotrar algun registro,
            /// lo regresa como una lista llave-valor.
            /// En caso contrario, regresa la lista vacia.
            /// Los valores de los campos deben ser proporcionados,
            /// en formato alfanumerico, compatible, para S.Q.L.
            /// </summary>
            /// <param name="ATableID">Identificador de la tabla</param>
            /// <param name="AKeyField">Identificador de la columna o campo para llave primaria</param>
            /// <param name="AKeyDefaultValue">Valor de llave primaria, del registro por-de-facto</param>
            /// <returns>Registro buscado, como lista de llaves-valor</returns>
            public virtual Dictionary<string, Object> FindORDefault
                (string ATableID, string AKeyField, string AKeyValue)
            {
                Dictionary<string, Object> Result = null;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> FindORDefault(...)

            // ...

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solo la columna indicada.
            /// No realiza ninguna ordenacion.
            /// Regresa todos los registros de la tabla indicada,
            /// incluyendo registro "defacto", si coincide,
            /// con el criterio, o excluyendolo, en caso contrario.
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Object> SingleColumn
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = new List<Object>();

                this.DoNothing();

                return Result;
            } // List<Object> SingleColumn(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solo la columna indicada.
            /// No realiza ninguna ordenacion.
            /// Regresa todos los registros de la tabla indicada,
            /// incluyendo registro "defacto", si coincide,
            /// con el criterio, o excluyendolo, en caso contrario.
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Object> SingleColumnNotDefault
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = new List<Object>();

                this.DoNothing();

                return Result;
            } // List<Object> SingleColumnNotDefault(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solo la columna indicada.
            /// No realiza ninguna ordenacion.
            /// En caso de encontrar registros que cumplan el criterio
            /// de busqueda, los regresa, con excepcion del registro "de facto".
            /// En caso de no encontrar registro alguno,
            /// regresa la lista, solo con el registro "de facto",
            /// si lo hay, o lista vacia en caso contrario.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de registros resultante</returns>
            public virtual List<Object> SingleColumnORDefault
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = new List<Object>();

                this.DoNothing();

                return Result;
            } // List<Object> SingleColumnORDefault(...)

            // ...

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solamente dos columnas,
            /// la columna de la llave primaria, y cualquier otra columna.
            /// No realiza ninguna ordenacion.
            /// Regresa todos los registros de la tabla indicada,
            /// incluyendo registro "defacto", si coincide,
            /// con el criterio, o excluyendolo, en caso contrario.
            /// En caso de no encontrar algun registro,
            /// regresa la lista vacia.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de Registros con par de campos llave-valor</returns>
            public virtual Dictionary<Object, Object> SingleKeyValue
                (ORMSelectParamsClass AParameters)
            {
                Dictionary<Object, Object> Result = new Dictionary<Object, Object>();

                this.DoNothing();

                return Result;
            } // Dictionary<Object, Object> SingleKeyValue(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solamente dos columnas,
            /// la columna de la llave primaria, y cualquier otra columna.
            /// No realiza ninguna ordenacion.
            /// En caso de encontrar registros que cumplan el criterio
            /// de busqueda, los regresa, con excepcion del registro de "de facto".
            /// En caso de no encontrar registro alguno,
            /// regresa la lista, solo con el registro "de facto",
            /// si lo hay, o lista vacia en caso contrario.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de Registros con par de campos llave-valor</returns>
            public virtual Dictionary<Object, Object> SingleKeyValueNotDefault
                (ORMSelectParamsClass AParameters)
            {
                Dictionary<Object, Object> Result = new Dictionary<Object, Object>();

                this.DoNothing();

                return Result;
            } // Dictionary<Object, Object> SingleKeyValueNotDefault(...)

            /// <summary>
            /// Realiza una consulta de una sola tabla,
            /// y regresa solamente dos columnas,
            /// la columna de la llave primaria, y cualquier otra columna.
            /// No realiza ninguna ordenacion.
            /// En caso de encontrar registros que cumplan el criterio
            /// de busqueda, los regresa, con excepcion del registro "de facto".
            /// En caso de no encontrar registro alguno,
            /// regresa la lista, solo con el registro "de facto",
            /// si lo hay, o lista vacia en caso contrario.
            /// </summary>
            /// <param name="AParameters">Parametros para la Consulta</param>
            /// <returns>Lista de Registros con par de campos llave-valor</returns>
            public virtual Dictionary<Object, Object> SingleKeyValueORDefault
                (ORMSelectParamsClass AParameters)
            {
                Dictionary<Object, Object> Result = new Dictionary<Object, Object>();

                this.DoNothing();

                return Result;
            } // Dictionary<Object, Object> SingleKeyValueORDefault(...)

            // ...

            // ...

            /// <summary>
            /// Regresa una lista de registros, como pares llave-valor,
            /// de una consulta S.Q.L., que cumplan,
            /// con la lista de predicados proporcionada.
            /// </summary>
            /// <param name="ASQLCommand">Consulta S.Q.L.</param>
            /// <param name="Filters">Lista de Predicados</param>
            /// <returns></returns>
            public virtual List<Dictionary<string, Object>> Join
                 (string ASQLCommand, FilterListClass Filters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Join(...)

            // ...

            public virtual bool Insert
                (ORMInsertParamsClass AParameters)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool Insert(...)

            public virtual bool Update
                (ORMUpdateParamsClass AParameters)            
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool Update(...)

            public virtual bool Delete
                (ORMDeleteParamsClass AParameters)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool Delete(...)

            public virtual bool MarkAsDeleted
                (ORMDeleteParamsClass AParameters)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool MarkAsDeleted(...)

            public virtual bool Restore
            (
                string ATableID,
                Dictionary<string, Object> ARecord,
                FilterListClass Filters,
                string AFlagField, string AFlagValue
            )
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool Restore(...)

            // ...

            /// <summary>
            /// Registrar el usuario que se utiliza,
            /// en las consultas.
            /// </summary>
            public void RegisterCurrentUser(ORMEntityClass ThisUser)
            {
                if (this.IsReady())
                {
                    if (ThisUser != null)
                    {
                        this.F_CurrentUser = ThisUser;
                    } // if (ThisUser != null)
                } // if (this.IsReady())
            } // void RegisterCurrentUser(...)

            // ...

            #endregion "methods"
    } // class ORMWarehouseClass

    public enum InsertKeyModeEnum
    {
        None,
        ServerGenerateKey,
        ClientGenerateKey,
        AssignedKey,
    } // enum InsertKeyModeEnum

    public enum DeleteModeEnum
    {
        None,
        RawDelete,
        MarkAsDeleted,
    } // enum DeleteModeEnum

    /// <summary>
    /// clase base para declarar entidades,
    /// que se almacenaran en un <code>ORMWarehouseClass</code>.
    /// </summary>
    public class ORMWarehouseEntityClass : ORMEntityClass
    {
        #region "fields"
            // ...

            // ...
        #endregion "fields"

        #region "properties"
            protected ORMWarehouseClass F_Warehouse;
            /// <summary>
            /// Referencia a la B.D. externa.
            /// </summary>
            public ORMWarehouseClass Warehouse
            {
                get { return F_Warehouse; }
                set { F_Warehouse = value; }
            }

            protected string F_KeyFieldName;
            /// <summary>
            /// Key Field Identifier.
            /// </summary>
            public string KeyFieldName
            {
                get { return F_KeyFieldName; }
                set { F_KeyFieldName = value; }
            }

            private InsertKeyModeEnum F_InsertKeyMode;
            /// <summary>
            /// Modo en que se ejecutara el metodo <code>Insert();</code>.
            /// </summary>
            public InsertKeyModeEnum InsertKeyMode
            {
                get { return F_InsertKeyMode; }
                set { F_InsertKeyMode = value; }
            }

            private DeleteModeEnum F_DeleteKeyMode;
            /// <summary>
            /// Modo en que se ejecutara el metodo <code>Delete();</code>.
            /// </summary>
            public DeleteModeEnum DeleteKeyMode
            {
                get { return F_DeleteKeyMode; }
                set { F_DeleteKeyMode = value; }
            }
        #endregion "properties"

        #region "support"
            private bool F_ORMWarehouseEntityClass_IsReady;

            public ORMWarehouseEntityClass()
                : base()
            {
                // --> clear status
                F_ORMWarehouseEntityClass_IsReady = false;

                // --> clear fields
                F_Warehouse = null;
                F_KeyFieldName = null;
            } // ORMWarehouseEntityClass()

            public override bool IsReady()
            {
                bool Result = F_ORMWarehouseEntityClass_IsReady;
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
                    this.F_InsertKeyMode = InsertKeyModeEnum.None;
                    this.F_DeleteKeyMode = DeleteModeEnum.None;

                    this.F_Warehouse = null;
                    this.F_KeyFieldName = "";
                } // if (Result == 0)

                // --> update status
                F_ORMWarehouseEntityClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ORMWarehouseEntityClass_IsReady = false;

                // --> deallocate fields
                if (Result == 0)
                {
                    this.F_KeyFieldName = "";
                    this.F_Warehouse = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            public virtual Int64 CreateAtWarehouse(ORMWarehouseClass AWarehouse)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this.F_InsertKeyMode = InsertKeyModeEnum.None;
                    this.F_Warehouse = AWarehouse;
                    this.F_KeyFieldName = "";
                } // if (Result == 0)

                // --> update status
                F_ORMWarehouseEntityClass_IsReady = true;

                return Result;
            } // public virtual Int64 CreateAtWarehouse(...)

            // ...
        #endregion "constructors"

        #region "methods"
        // ...

            /// <summary>
            /// Genera una nueva llave automaticamente,
            /// desde el lado del cliente, no del servidor,
            /// y la asigna al campo llave.
            /// </summary>
            /// <returns>Se pudo realizar la operacion</returns>
            protected virtual bool GenerateKey()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // --> if not overriden,
                    // --> assume we can continue with next step
                    Result = true;
                } // if (this.IsReady())

                return Result;
            } // bool GenerateKey(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// antes de insertar un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual bool BeforeInsert()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // --> if not overriden,
                    // --> assume we can continue with next step
                    Result = true;
                } // if (this.IsReady())

                return Result;
            } // bool BeforeInsert(...)

            protected virtual bool ConfirmedInsert()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool ConfirmedInsert(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// despues de insertar un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual void AfterInsert()
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void AfterInsert(...)

            /// <summary>
            /// Inserta un nuevo registro,
            /// el valor del campo, para llave primaria,
            /// se calculara, automaticamente, en la entidad,
            /// ejecutando el metodo <code>GenerateKey()</code>.
            /// </summary>
            public bool InsertAndGenerateKey()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = GenerateKey();
                    if (Result)
                    {
                        Result = BeforeInsert();
                        if (Result)
                        {
                            Result = ConfirmedInsert();
                            if (Result)
                            {
                                AfterInsert();
                            }
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool InsertAndGenerateKey

            /// <summary>
            /// Inserta un nuevo registro,
            /// el valor del campo, para llave primaria,
            /// se calculara automaticamente,
            /// en la B.D. .
            /// </summary>
            public bool InsertAndIgnoreKey()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = BeforeInsert();
                    if (Result)
                    {
                        Result = ConfirmedInsert();
                        if (Result)
                        {
                            AfterInsert();
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool InsertAndIgnoreKey(...)

            /// <summary>
            /// Inserta un nuevo registro,
            /// el valor del campo, para llave primaria,
            /// se proporcionara explicitamente,
            /// asignando el campo, correspondiente.
            /// </summary>
            public bool InsertWithKey()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = BeforeInsert();
                    if (Result)
                    {
                        Result = ConfirmedInsert();
                        if (Result)
                        {
                            AfterInsert();
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool InsertWithKey(...)

            /// <summary>
            /// Inserta un nuevo registro,
            /// el valor del campo, para llave primaria,
            /// se asignara dependiendo el campo <code>InsertKeyMode</code>.
            /// </summary>
            public bool Insert()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    switch (this.InsertKeyMode)
                    {
                        case InsertKeyModeEnum.AssignedKey:
                            Result = this.InsertWithKey();
                        break;
                        case InsertKeyModeEnum.ClientGenerateKey:
                            Result = this.InsertAndGenerateKey();
                        break;
                        case InsertKeyModeEnum.ServerGenerateKey:
                            Result = this.InsertAndIgnoreKey();
                        break;
                        default:
                            Result = true;
                        break;
                    } // switch
                } // if (this.IsReady())

                return Result;
            } // bool Insert(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// antes de actualizar un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual bool BeforeUpdate()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // --> if not overriden,
                    // --> assume we can continue with next step
                    Result = true;
                } // if (this.IsReady())

                return Result;
            } // bool BeforeUpdate(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// despues de actualizar un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual void AfterUpdate()
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void AfterUpdate(...)

            protected virtual bool ConfirmedUpdate()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool ConfirmedUpdate(...)

            /// <summary>
            /// Reemplaza el registro indicado,
            /// en la tabla correspondiente, de la B.D.
            /// </summary>
            public bool Update()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = BeforeUpdate();
                    if (Result)
                    {
                        Result = ConfirmedUpdate();
                        if (Result)
                        {
                            AfterUpdate();
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool Update(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// antes de eliminar fisicamente un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual bool BeforeDelete()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = true;
                } // if (this.IsReady())

                return Result;
            } // bool BeforeDelete(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// despues de eliminar fisicamente un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual void AfterDelete()
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void AfterDelete(...)

            protected virtual bool ConfirmedDelete()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool ConfirmedDelete(...)

            /// <summary>
            /// Elimina el registro indicado,
            /// de la B.D.
            /// </summary>
            public virtual bool Delete()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = BeforeDelete();
                    if (Result)
                    {
                        Result = ConfirmedDelete();
                        if (Result)
                        {
                            AfterDelete();
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool Delete(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// antes de eliminar logicamente un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual bool BeforeMarkAsDeleted()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = true;
                } // if (this.IsReady())

                return Result;
            } // bool BeforeMarkAsDeleted(...)

            /// <summary>
            /// Ejecuta las operaciones necesarias,
            /// despues de eliminar logicamente un registro.
            /// </summary>
            /// <returns>Resultado de la operacion</returns>
            protected virtual void AfterMarkAsDeleted()
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void AfterMarkAsDeleted(...)

            protected virtual bool ConfirmedMarkAsDeleted()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool ConfirmedMarkAsDeleted(...)

            /// <summary>
            /// Activa la bandera de oculto,
            /// o "borrado logico" para el registro.
            /// </summary>
            public bool MarkAsDeleted()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    Result = BeforeMarkAsDeleted();
                    if (Result)
                    {
                        Result = ConfirmedMarkAsDeleted();
                        if (Result)
                        {
                            AfterMarkAsDeleted();
                        }
                    }
                } // if (this.IsReady())

                return Result;
            } // bool MarkAsDeleted(...)

            // ...

            /// <summary>
            /// Recupera una entidad,
            /// desactivando la bandera de oculto,
            /// o "borrado logico" para el registro.
            /// </summary>
            public bool Restore()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();

                    /*
                    Result = BeforeMarkAsDeleted();
                    if (Result)
                    {
                        Result = ConfirmedMarkAsDeleted();
                        if (Result)
                        {
                            AfterMarkAsDeleted();
                        }
                    }
                    */
                } // if (this.IsReady())

                return Result;
            } // bool Restore(...)

            public virtual bool KeyFound(Object AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool KeyFound(...)

            public virtual bool KeyFoundAsInt(Int32 AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool KeyFoundAsInt(...)

            public virtual bool KeyFoundAsGUID(Guid AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // bool KeyFoundAsGUID(...)

            // ...
        #endregion "methods"

        #region "static"
            // ...

            /// <summary>
            /// Construye un nuevo objeto de la clase <code>ORMWarehouseEntityClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            public static ORMWarehouseEntityClass FactoryAtWarehouse(ORMWarehouseClass AWarehouse)
            {
                ORMWarehouseEntityClass Result = new ORMWarehouseEntityClass();
                Result.CreateAtWarehouse(AWarehouse);

                return Result;
            } // static ORMWarehouseEntityClass FactoryAtWarehouse(...)

            /// <summary>
            /// Desecha objeto de la clase <code>ORMWarehouseEntityClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref ORMWarehouseEntityClass AObject)
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

    } // class ORMWarehouseEntityClass

    // ...

} // namespace
