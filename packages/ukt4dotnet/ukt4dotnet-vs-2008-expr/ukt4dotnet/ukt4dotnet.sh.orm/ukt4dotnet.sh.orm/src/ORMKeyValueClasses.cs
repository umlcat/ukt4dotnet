using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.collections;
using ukt4dotnet.shared.orm;

/**
 ** Declare classes to emulate a D.B., locally.
 **/

namespace ukt4dotnet.shared.orm
{
    /// <summary>
    /// To emulate a local table, using Key-Value data.
    /// Consumes a lot of resources, use it, only for small tests, only.
    /// </summary>
    public class KeyValueTableClass : ORMWarehouseEntityClass
    {
        #region "fields"
            //private bool F_KeyValueTableClass_IsReady;
        #endregion "fields"

        #region "properties"
            protected List<Dictionary<string, Object>> F_Rows;
            /// <summary>
            /// Es el identificador interno en la B.D. .
            /// </summary>
            public List<Dictionary<string, Object>> Rows
            {
                get { return F_Rows; }
                set { F_Rows = value; }
            }
        #endregion "properties"

        #region "support"
            private bool F_KeyValueTableClass_IsReady;

            public KeyValueTableClass()
                : base()
            {
                // --> clear status
                F_KeyValueTableClass_IsReady = false;

                // --> clear fields
                F_Rows = null;
            } // KeyValueTableClass()

            public override bool IsReady()
            {
                bool Result = F_KeyValueTableClass_IsReady;
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
                    F_Rows = new List<Dictionary<string, object>>();
                } // if (Result == 0)

                // --> update status
                F_KeyValueTableClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_KeyValueTableClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_Rows.Clear();
                    F_Rows = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
            public virtual Dictionary<string, Object> SelectRowByKey(Object AKeyValue)
            {
                Dictionary<string, Object> Result = null;

                if (this.IsReady())
                {
                    Dictionary<string, Object> EachRow = null;

                    int EachRowIndex = 0;
                    int LastRow = this.F_Rows.Count;
                    bool RowFound = false;
                    while ((!RowFound) && (EachRowIndex < LastRow))
                    {
                        EachRow = this.F_Rows[EachRowIndex];

                        foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                        {
                            RowFound = false;
                            if (EachFieldValue.Key.Equals(this.KeyFieldName))
                            {
                                RowFound = (EachFieldValue.Value.Equals(AKeyValue));
                                // keyfield found, exit loop
                                break;
                            } // if
                        } // foreach

                        EachRowIndex++;
                    } // while

                    if (RowFound)
                    {
                        Result = EachRow;
                    }

                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> ARow SelectRowByKey(...)

            public virtual void InsertRow(Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    // @to-do: validate avoid duplicated key
                    Rows.Add(ARow);
                } // if (this.IsReady())
            } // void InsertRow(...)

            public virtual void DeleteRowByKey(Object AKeyValue)
            {
                if (this.IsReady())
                {
                    // buscar referencia a registro
                    Dictionary<string, Object> thisRow = this.SelectRowByKey(AKeyValue);
                    if (thisRow != null)
                    {
                        this.F_Rows.Remove(thisRow);
                    } // if (ARow != null)
                } // if (this.IsReady())
            } // void DeleteRowByKey(...)

            public virtual void EmptyRows()
            {
                if (this.IsReady())
                {
                    this.F_Rows.Clear();
                } // if (this.IsReady())
            } // void EmptyRows(...)

            public virtual void UpdateRowWhere
              (Dictionary<string, Object> ARow,
               KeyValuePair<string, Object> APredicate)
            {
                if (this.IsReady())
                {
                    this.DoNothing();                
                } // if (this.IsReady())
            } // void UpdateRowWhere(...)

            public virtual void UpdateRowByKey
              (Object AKeyValue,
               Dictionary<string, Object> ARow
              )
            {
                if (this.IsReady())
                {
                    // buscar referencia a registro
                    Dictionary<string, Object> thisRow = this.SelectRowByKey(AKeyValue);
                    if (thisRow != null)
                    {
                        // registro encontrado,
                        // actualizar cada uno de los campos solicitados
                        foreach (KeyValuePair<string, Object> EachFieldValue in ARow)
                        {
                            // borrar par anterior y agregar nuevo par
                            if (thisRow.Remove(EachFieldValue.Key))
                            {
                                thisRow.Add(EachFieldValue.Key, EachFieldValue.Value);
                            } // if   
                        } // foreach
                    } // if (ARow != null)
                } // if (this.IsReady())
            } // void UpdateRowByKey(...)

            public virtual List<Dictionary<string, Object>> Select()
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    foreach (Dictionary<string, Object> EachRow in this.F_Rows)
                    {
                        // make a "shallow" copy of each record,
                        // we don't want to access them directly,
                        // because we will modify the database table directly
                        Dictionary<string, Object> EachRowCopy = new Dictionary<string, object>();

                        foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                        {
                            // add a copy of each field-value to the new row
                            EachRowCopy.Add(EachFieldValue.Key, EachFieldValue.Value);
                        } // foreach

                        // add clone of each row to result list
                        Result.Add(EachRowCopy);
                    } // foreach
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Select(...)

            public bool RowMatches
                (Dictionary<string, Object> EachRow, FilterClass APredicate)
            {
                bool Result = false;

                Object AValue = null;
                if (EachRow.TryGetValue(APredicate.Key, out AValue))
                {
                    if (APredicate.Operation.Equals("="))
                    {
                        Result = (AValue.Equals(APredicate.Value));                    
                    }
                }
                else if (EachRow.TryGetValue(APredicate.Key, out AValue))
                {
                    if (APredicate.Operation.Equals("<>") || APredicate.Operation.Equals("!="))
                    {
                        Result = (!AValue.Equals(APredicate.Value));
                    }
                } // if

                // more operations

                return Result;
            } // bool RowMatches(...)

            public bool RowMatchesList
                (Dictionary<string, Object> EachRow, FilterListClass APredicateList)
            {
                bool Result = true;

                if (APredicateList.Count() == 1)
                {
                    FilterClass EachPredicate = APredicateList.getItemAt(0);
                    Result = RowMatches(EachRow, EachPredicate);
                }
                else
                {
                    /*
                    bool IsFirst = true;
                    bool PrevResult = true;
                    foreach (FilterClass EachPredicate in APredicateList)
                    {
                        if (RowMatches(EachRow, EachPredicate))
                        {
                            this.DoNothing();
                        }
                    } // foreach
                    */
                }

                return Result;
            } // bool RowMatchesList(...)

            public virtual List<Dictionary<string, Object>> Where
                (FilterListClass APredicateList)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    foreach (Dictionary<string, Object> EachRow in this.F_Rows)
                    {
                        if (RowMatchesList(EachRow, APredicateList))
                        {
                            // make a "shallow" copy of each record,
                            // we don't want to access them directly,
                            // because we will modify the database table directly
                            Dictionary<string, Object> EachRowCopy = new Dictionary<string, object>();

                            foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                            {
                                // add a copy of each field-value to the new row
                                EachRowCopy.Add(EachFieldValue.Key, EachFieldValue.Value);
                            } // foreach

                            // add clone of each row to result list
                            Result.Add(EachRowCopy);
                        }  // if
                    } // foreach
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)

            // ...

            public virtual List<Object> SelectSingle
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = new List<Object>();

                if (this.IsReady())
                {
                    string AColumnID = AParameters.FieldName;

                    foreach (Dictionary<string, Object> EachRow in this.F_Rows)
                    {
                        foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                        {
                            if (EachFieldValue.Key.Equals(AColumnID))
                            {
                                // add a copy of each value to the new row
                                Result.Add(EachFieldValue.Value);
                                break;
                            } // if
                        } // foreach
                    } // foreach
                } // if (this.IsReady())

                return Result;
            } // List<Object> SelectSingle(...)

            public virtual List<Object> SelectKeyValue
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = new List<Object>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Object> SelectKeyValue(...)

            // ...

            public override bool KeyFound(Object AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    foreach (Dictionary<string, Object> EachRow in this.F_Rows)
                    {
                        Result = false;
                        foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                        {
                            if (EachFieldValue.Key.Equals(this.KeyFieldName))
                            {
                                Result = (EachFieldValue.Value.Equals(AKeyValue));
                                break;
                            } // if
                        } // foreach

                        if (Result)
                        {
                            break;
                        }
                    } // foreach
                } // if (this.IsReady())

                return Result;
            } // bool KeyFound(...)

            public override bool KeyFoundAsInt(Int32 AKeyFound)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    foreach (Dictionary<string, Object> EachRow in this.F_Rows)
                    {
                        Result = false;
                        foreach (KeyValuePair<string, Object> EachFieldValue in EachRow)
                        {
                            if (EachFieldValue.Key.Equals(this.KeyFieldName))
                            {
                                Result = (AKeyFound == (Int32)EachFieldValue.Value);
                                break;
                            } // if
                        } // foreach

                        if (Result)
                        {
                            break;
                        }
                    } // foreach
                } // if (this.IsReady())

                return Result;
            } // bool KeyFoundAsInt(...)

            // ...

        #endregion "methods"

        // ...

    } // class KeyValueTableClass

    public class ORMKeyValueWarehouseClass : ORMWarehouseClass
    {
        #region "support"
            private bool F_ORMKeyValueWarehouseClass_IsReady;
        
            public ORMKeyValueWarehouseClass() : base()
            {
                // --> clear status
                F_ORMKeyValueWarehouseClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // KeyValueTableDBClass()

            public override bool IsReady()
            {
                bool Result = F_ORMKeyValueWarehouseClass_IsReady;
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
                F_ORMKeyValueWarehouseClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ORMKeyValueWarehouseClass_IsReady = true;

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
            /// <summary>
            /// Inserta un solo registro en la B.D,
            /// como lista de llave-valor.
            /// </summary>
            /// <param name="TableName">Identificador de la tabla</param>
            /// <param name="ARecord">Lista de campos del registro, llave-valor</param>
            public virtual void InsertRow
                (string TableID, Dictionary<string, Object> ARecord)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void InsertRow(...)

            public virtual void UpdateRowWhere
                (string ATableID,
                 Dictionary<string, Object> ARow,
                 KeyValuePair<string, Object> APredicate)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void UpdateRowWhere(...)

            public virtual void UpdateRowByKey
                (string ATableID,
                 Object AKeyValue,
                 Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void UpdateRowByKey(...)

            public virtual void DeleteRowByKey
                (string ATableID,
                 Object AKeyValue)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void DeleteRowByKey(...)

            public virtual void EmptyRows(string ATableID)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void EmptyRows(...)

            public virtual Dictionary<string, Object> SelectRowByKey
                (string ATableID, Object AKeyValue)
            {
                Dictionary<string, Object> Result = null;

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> SelectRowByKey(...)

            /// <summary>
            /// Lee todos los registros de una tabla,
            /// y regresa todas las columnas,
            /// no realiza ninguna ordenacion.
            /// Advertencia: Consume muchos recursos, solo para pruebas y depuracion.
            /// </summary>
            /// <param name="TableName">Identificador de la tabla</param>
            public override List<Dictionary<string, Object>>
                Select(ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Select(...)

            public override List<Dictionary<string, Object>> Where
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)

            /*
            public override List<Dictionary<string, Object>> Where
                (string ATableID,
                 FilterListClass APredicateList)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)
            */

            // ...

        #endregion "methods"

        // ...

    } // class ORMKeyValueWarehouseClass

    /// <summary>
    /// To emulate a local database.
    /// </summary>
    public class KeyValueTableDBClass : ORMKeyValueWarehouseClass
    {
        #region "fields"
            //private bool F_LocalDatabase_IsReady;
        #endregion "fields"

        #region "properties"
            protected List<KeyValueTableClass> F_Tables;
            /// <summary>
            /// Es el identificador interno en la B.D. .
            /// </summary>
            public List<KeyValueTableClass> Tables
            {
                get { return F_Tables; }
                set { F_Tables = value; }
            }
        #endregion "properties"
    
        #region "support"
            private bool F_KeyValueTableDBClass_IsReady;
           
            public KeyValueTableDBClass() : base()
            {
                // --> clear status
                F_KeyValueTableDBClass_IsReady = false;
                
                // --> clear fields
                F_Tables = null;
            } // KeyValueTableDBClass()

            public override bool IsReady()
            {
                bool Result = F_KeyValueTableDBClass_IsReady;
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
                    F_Tables = new List<KeyValueTableClass>();
                } // if (Result == 0)

                // --> update status
                F_KeyValueTableDBClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_KeyValueTableDBClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_Tables.Clear();
                    F_Tables = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
            public override ORMWarehouseEntityClass CreateTable()
            {
                KeyValueTableClass Result = null;

                if (this.IsReady())
                {
                    // Create table
                    // (two-step initialization)
                    Result = new KeyValueTableClass();
                    Result.Create();

                    // add to list
                    F_Tables.Add(Result);
                } // if (this.IsReady())

                return Result;
            } // ORMEntityClass CreateTable(...)

            public override void DropTableByObject(ORMWarehouseEntityClass ATableRef)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void DropTableByObject(...)

            public override void DropTableByID(string ATableID)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void DropTableByID(...)

            public override ORMWarehouseEntityClass TableByID(string ATableID)
            {
                ORMWarehouseEntityClass Result = null;

                if (this.IsReady())
                {
                    KeyValueTableClass EachTable = null;

                    bool Found = false;
                    int EachIndex = 0;
                    int ACount = F_Tables.Count;
                    while ((!Found) && (EachIndex < ACount))
                    {
                        EachTable = F_Tables[EachIndex];

                        Found = (EachTable.DBIdentifier.Equals(ATableID));
                        EachIndex++;
                    } // for

                    if (Found)
                    {
                        Result = EachTable;
                    }
                    EachTable = null;
                } // if (this.IsReady())

                return Result;
            } // ORMEntityClass TableByID(...)

            public override List<Object> SingleColumn
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = null;

                if (this.IsReady())
                {
                    string ATableID = AParameters.TableName;

                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registros
                        Result = thisTable.SelectSingle(AParameters);
                    }
                    else
                    {
                        // no se encontro: regresar lista vacia
                        Result = new List<Object>();
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Object> SelectSingle(...)

            public override List<Dictionary<string, Object>> Select
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = null;

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(AParameters.TableName);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registros
                        Result = thisTable.Select();
                    }
                    else
                    {
                        // no se encontro: regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Select(...)

            public override List<Dictionary<string, Object>> Where
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    String ATableID = AParameters.TableName;
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registros
                        Result = thisTable.Where(AParameters.Filters);
                    }
                    else
                    {
                        // no se encontro: regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)

            /*
            public override List<Dictionary<string, Object>> Where
                (string ATableID, FilterListClass APredicateList)
            {
                List<Dictionary<string, Object>> Result = new List<Dictionary<string, Object>>();

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registros
                        Result = thisTable.Where(APredicateList);
                    }
                    else
                    {
                        // no se encontro: regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)
            */

            public override void InsertRow
                (string ATableID, Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: insertar registro
                        thisTable.InsertRow(ARow);
                    }
                } // if (this.IsReady())
            } // void InsertRow(...)        

            public override void DeleteRowByKey
                (string ATableID, Object AKeyValue)
            {
                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: eliminar registro
                        thisTable.DeleteRowByKey(AKeyValue);
                    }
                } // if (this.IsReady())
            } // void DeleteRowByKey(...)    

            public override void EmptyRows(string ATableID)
            {
                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: vaciar todos los registros
                        thisTable.EmptyRows();
                    }
                } // if (this.IsReady())
            } // void EmptyRows(...)   

            public override Dictionary<string, Object> SelectRowByKey
                (string ATableID, Object AKeyValue)
            {
                Dictionary<string, Object> Result = null;

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registro
                        Result = thisTable.SelectRowByKey(AKeyValue);
                    }
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> SelectRowByKey(...)

            public override bool KeyFound
                (string ATableID, Object AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: buscar llave
                        Result = thisTable.KeyFound(AKeyValue);
                    }
                } // if (this.IsReady())          

                return Result;
            } // bool KeyFound(...)

            public override bool KeyFoundAsInt
                (string ATableID, Int32 AKeyValue)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: regresar registros
                        Result = thisTable.KeyFoundAsInt(AKeyValue);
                    }
                } // if (this.IsReady())          

                return Result;
            } // bool KeyFoundAsInt(...)

            public override void UpdateRowWhere
                (string ATableID,
                 Dictionary<string, Object> ARow,
                 KeyValuePair<string, Object> APredicate)
            {
                if (this.IsReady())
                {
                    this.DoNothing();
                } // if (this.IsReady())
            } // void UpdateRowWhere(...)

            public override void UpdateRowByKey
                (string ATableID,
                 Object AKeyValue,
                 Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    // obtener referencia a tabla, directamente
                    KeyValueTableClass thisTable = (KeyValueTableClass)TableByID(ATableID);
                    if (thisTable != null)
                    {
                        // tabla encontrada: insertar registro
                        thisTable.UpdateRowByKey(AKeyValue, ARow);
                    }
                } // if (this.IsReady())
            } // void UpdateRowByKey(...)

            // ...

        #endregion "methods"

        // ...

    } // class KeyValueTableDBClass

    /// <summary>
    /// To connect to a local database emulation.
    /// </summary>
    public class KeyValueTableDBConnClass : ORMKeyValueWarehouseClass
    {
        #region "fields"
            protected KeyValueTableDBClass F_Database;
            public KeyValueTableDBClass Database
            {
                get { return F_Database; }
                set { F_Database = value; }
            }
        #endregion "fields"

        #region "properties"
            // ...
        #endregion "properties"

        #region "support" 
            private bool F_KeyValueTableDBConnClass_IsReady;
        
            public KeyValueTableDBConnClass(): base()
            {
                // --> clear status
                F_KeyValueTableDBConnClass_IsReady = false;

                // --> clear fields
                F_Database = null;
            } // KeyValueTableDBConnClass()

            public override bool IsReady()
            {
                bool Result = F_KeyValueTableDBConnClass_IsReady;
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
                    F_Database = null;
                } // if (Result == 0)

                // --> update status
                F_KeyValueTableDBConnClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_KeyValueTableDBConnClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    F_Database = null;
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
            public override bool IsConnected()
            {
                bool Result = false;

                if (this.IsReady())
                {
                    // @to-do: validate !!!
                    bool IsValidated = true;
                    Result = ((F_Database != null) && IsValidated);
                } // if (this.IsReady())

                return Result;
            } // bool Logged()

            public override List<Dictionary<string, Object>>
                Select(ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = null;

                if (this.IsReady())
                {
                    if (!IsConnected())
                    {
                        // regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                    else
                    {
                        Result = this.Database.Select(AParameters);
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Select(...)

            public override List<Object> SingleColumn
                (ORMSelectParamsClass AParameters)
            {
                List<Object> Result = null;

                if (this.IsReady())
                {
                    if (!IsConnected())
                    {
                        // regresar lista vacia
                        Result = new List<Object>();
                    }
                    else
                    {
                        Result = this.Database.SingleColumn(AParameters);
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Object> SelectSingle(...)

            public override Dictionary<string, Object> SelectRowByKey
                (string ATableID, Object AKeyValue)
            {
                Dictionary<string, Object> Result = null;

                if (this.IsReady())
                {
                    if (!IsConnected())
                    {
                        // regresar lista vacia
                        Result = new Dictionary<string, Object>();
                    }
                    else
                    {
                        Result = this.Database.SelectRowByKey(ATableID, AKeyValue);
                    }
                } // if (this.IsReady())

                return Result;
            } // Dictionary<string, Object> SelectRowByKey(...)


            public override List<Dictionary<string, Object>> Where
                (ORMSelectParamsClass AParameters)
            {
                List<Dictionary<string, Object>> Result = null;

                if (this.IsReady())
                {
                    if (!IsConnected())
                    {
                        // regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                    else
                    {
                        Result = this.Database.Where(AParameters);
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)

            /*
            public override List<Dictionary<string, Object>> Where
                (string ATableID,
                 FilterListClass APredicateList)
            {
                List<Dictionary<string, Object>> Result = null;

                if (this.IsReady())
                {
                    if (!IsConnected())
                    {
                        // regresar lista vacia
                        Result = new List<Dictionary<string, Object>>();
                    }
                    else
                    {
                        Result = this.Database.Where(ATableID, APredicateList);
                    }
                } // if (this.IsReady())

                return Result;
            } // List<Dictionary<string, Object>> Where(...)
            */

            public override void InsertRow
                (string ATableID, Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        this.Database.InsertRow(ATableID, ARow);
                    }
                } // if (this.IsReady())
            } // void InsertRow(...)

            public override void UpdateRowByKey
                (string ATableID,
                 Object AKeyValue,
                 Dictionary<string, Object> ARow)
            {
                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        this.Database.UpdateRowByKey
                            (ATableID, AKeyValue, ARow);
                    }
                } // if (this.IsReady())
            } // void UpdateRowByKey(...)

            public override void DeleteRowByKey
                (string ATableID,
                 Object AKeyValue)
            {
                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        this.Database.DeleteRowByKey(ATableID, AKeyValue);
                    }
                } // if (this.IsReady())
            } // void DeleteRowByKey(...)

            public override void EmptyRows(string ATableID)
            {
                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        this.Database.EmptyRows(ATableID);
                    }
                } // if (this.IsReady())
            } // void EmptyRows(...)

            public override bool KeyFound
                (string ATableID, Object AKey)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        Result = this.Database.KeyFound(ATableID, AKey);
                    }
                } // if (this.IsReady())          

                return Result;
            } // bool KeyFound(...)

            public override bool KeyFoundAsInt
                (string ATableID, Int32 AKey)
            {
                bool Result = false;

                if (this.IsReady())
                {
                    if (IsConnected())
                    {
                        Result = this.Database.KeyFoundAsInt(ATableID, AKey);
                    }
                } // if (this.IsReady())          

                return Result;
            } // bool KeyFoundAsInt(...)

            // ...
        #endregion "methods"

        #region "static"
            // ...

            // ...
        #endregion "static"

        // ...

    } // class KeyValueTableDBConnClass

} // namespace
