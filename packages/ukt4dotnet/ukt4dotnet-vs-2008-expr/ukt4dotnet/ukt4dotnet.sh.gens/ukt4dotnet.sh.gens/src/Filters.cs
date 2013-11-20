using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using ukt4dotnet.shared.text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.collections
{
    /// <summary>
    /// Indica con cual operacion,
    /// se aplicara un filtro.
    /// </summary>
    public enum FilterConcatOperator
    {
        None,
        AND,
        OR,
        XOR
    } // enum FilterConcatOperator

    /// <summary>
    /// Class for register operations & values,
    /// to filter a query.
    /// Note: Fields, operations and values are stored as <code>string</code>.
    /// Example: 
    /// Filter: {Key: "FirstName", Value: "John", Operation: ">="}
    /// </summary>
    public class FilterClass : CloneableObjectClass
    {
        #region "fields"
            // ...
            private bool F_FilterClass_IsReady;            
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            private string _Key = "";
            /// <summary>
            /// First operand of a filter,
            /// could be a single parameter, a single fieldname,
            /// or a list of parameters or a list of fieldnames.
            /// its stored as <code>string</code>.
            /// </summary>
            public string Key
            {
                get { return _Key; }
                set { _Key = value; }
            }

            private string _Value = "";
            /// <summary>
            /// Second operand of a filter,
            /// usually is a constant value,
            /// but, can be a list of values, too.
            /// its stored as <code>string</code>,
            /// even if represents another data type.
            /// </summary>
            public string Value
            {
                get { return _Value; }
                set { _Value = value; }
            }

            private string _Operation = "";
            /// <summary>
            /// Operation that causes data to be filtered,
            /// its stored as <code>string</code>.
            /// </summary>
            public string Operation
            {
                get { return _Operation; }
                set { _Operation = value; }
            }

            private bool _IsExpression = false;
            /// <summary>
            /// Indica que el valor de <code>Value</code>,
            /// contiene una expresion que sera generada tal cual,
            /// ignorando <code>Key</code> y <code>Operation</code>.
            /// </summary>
            public bool IsExpression
            {
                get { return _IsExpression; }
                set { _IsExpression = value; }
            }

            private FilterConcatOperator _ConcatOperator = FilterConcatOperator.None;
            /// <summary>
            /// Indica con que operador se concatenara con otros filtros.
            /// </summary>
            public FilterConcatOperator ConcatOperator
            {
                get { return _ConcatOperator; }
                set { _ConcatOperator = value; }
            }

            // ...
        #endregion "properties"

        #region "support"
            public FilterClass(): base()
            {
                // --> clear status
                F_FilterClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // FilterClass()        
      
            public override bool IsReady()
            {
                bool Result = F_FilterClass_IsReady;
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
                F_FilterClass_IsReady = true;

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
                F_FilterClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            /// <summary>
            /// Constructor for assigning all properties.
            /// </summary>
            /// <param name="aKey">Fieldname</param>
            /// <param name="aValue">Field value</param>
            /// <param name="aOperation">Operation between <code>aKey</code> and <code>aValue</code>,
            /// by default, <code>=</code>, the equality operator is used.</param>
            /// <param name="aUseOR">Operator used to concatenate with other filters,
            /// by default, <code>AND</code> operator is used, otherwise, <code>OR</code> operator.</param>
            public virtual Int64 CreateFilter
              (string aKey, string aValue,
               string aOperation, FilterConcatOperator aConcatOperator)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    this._Key = aKey;
                    this._Value = aValue;
                    this._Operation = aOperation;
                    this._ConcatOperator = aConcatOperator;
                } // if (Result == 0)

                // --> update status
                F_FilterClass_IsReady = true;

                return Result;
            } // public override Int64 CreateFilter(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            /// <summary>
            /// Generates an expression for a SQL where sentence.
            /// There should be a previous predicate in the SQL sentence.
            /// </summary>
            /// <returns>SQL expression equivalent.</returns>
            public string ToSQL(bool IgnoreConcatOperator)
            {
                string Result = "";

                string strConcatOperator = "";

                // se utiliza para el primer elemento
                if (!IgnoreConcatOperator)
                {
                    switch (ConcatOperator)
                    {
                        case FilterConcatOperator.AND:
                            strConcatOperator = "AND";
                            break;

                        case FilterConcatOperator.OR:
                            strConcatOperator = "OR";
                            break;

                        default:
                            break;
                    } // switch
                }

                if (IsExpression)
                {
                    // es una condicion de texto, se genera tal cual
                    Result = String.Format("{0} ({1}) ", strConcatOperator, this.Value);
                }
                else
                {
                    Result =
                        String.Format("{0} ({1} {2} {3}) ",
                            strConcatOperator, this.Key, this.Operation, this.Value);
                }

                return Result;
            } // string ToSQL(...)

            public override string ToString()
            {
                string Result = this.ToSQL(false);

                return Result;
            } // string ToString(...)

            // ...

            /// <summary>
            /// Copies all value properties from <code>ASource</code>,
            /// to the current object.
            /// </summary>
            /// <param name="ASource">Object to be used as a template</param>
            public override void AssignFrom(CloneableObjectClass ASource)
            {
                if (this.IsReady())
                {
                    if (ASource != null)
                    {
                        FilterClass Data = (ASource as FilterClass);

                        this.ConcatOperator = Data.ConcatOperator;
                        this.Key            = Data.Key;
                        this.Operation      = Data.Operation;
                        this.Value          = Data.Value;
                        this.IsExpression   = Data.IsExpression;
                    } // if (ASource != null)
                } // if (this.IsReady())
            } // void AssignFrom(...)

            /// <summary>
            /// When an object of this class is instantiated,
            /// creates & returns a "Shallow" copy of itself.
            /// </summary>
            /// <returns>"Shallow" copy of the object.</returns>
            public override CloneableObjectClass Clone()
            {
                CloneableObjectClass Result = null;

                FilterClass AResult = FilterClass.Factory();
                AResult.AssignFrom(this);
                Result = (CloneableObjectClass)AResult;

                return Result;
            } // CloneableObjectClass Clone(...)

            // ...
        #endregion "methods"

        #region "static"
			// ...
			
            /// <summary>
            /// Construye un nuevo objeto de la clase <code>FilterClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static FilterClass Factory()
            {
                FilterClass Result = new FilterClass();
                Result.Create();

                return Result;
            } // static FilterClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>FilterClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref FilterClass AObject)
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

    } // class FilterClass

    /// <summary>
    /// Its a collection used to register a set of
    /// filters, to apply in a D.B. query.
    /// It has some additional operations,
    /// like searching for a particular filter.
    /// </summary>
    public class FilterListClass : CloneableObjectClass
    {
        #region "fields"
            // ...
            private bool F_FilterListClass_IsReady;            
            // ...
        #endregion "fields"

        #region "properties"
            // ...

            // @to-do: reemplazar con lista tipo "ObjectClass"
            private   List<FilterClass> _InternalList;
            protected List<FilterClass> InternalList
            {
                get { return _InternalList; }
                set { _InternalList = value; }
            }

            /// <summary>
            /// Indexador
            /// </summary>
            /// <param name="AIndex">Indice a buscar</param>
            /// <returns>Elemento segun indice</returns>
            public FilterClass this[int AIndex]
            {
                get
                {
                    return this.getItemAt(AIndex);
                }
                set
                {
                    this.setItemAt(AIndex, value);
                }
            }

            // ...
        #endregion "properties"

        #region "support"
            public FilterListClass(): base()
            {
                // --> clear status
                F_FilterListClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // FilterListClass()        
      
            public override bool IsReady()
            {
                bool Result = F_FilterListClass_IsReady;
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
                    this.InternalList = new List<FilterClass>();
                } // if (Result == 0)

                // --> update status
                F_FilterListClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> deallocate fields
                if (Result == 0)
                {
                    RemoveList();
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                // --> update status
                F_FilterListClass_IsReady = false;

                return Result;
            } // public override Int64 Destroy(...)

            // ...
        #endregion "constructors"

        #region "methods"
			// ...

            protected void RemoveList()
            {
                if (this.InternalList != null)
                {
                    this.InternalList.Clear();
                    this.InternalList = null;
                } // if (this.InternalList)
            } // void RemoveList(...)   

            /// <summary>
            /// Gets the number of elements actually contained in the list.
            /// </summary>
            /// <returns>Items' quantity.</returns>
            public int Count()
            {
                int Result = 0;

                Result = this.InternalList.Count;             

                return Result;
            } // int Count(...)

            public ICollection Keys()
            {
                ArrayList Result = new ArrayList();

                foreach (FilterClass EachFilter in this.InternalList)
                {
                    Result.Add(EachFilter.Key);
                } // foreach

                return Result;
            } // ICollection Keys(...)

            public bool ContainsKey(string aKey)
            {
                bool Result = false;

                foreach (FilterClass EachFilter in this.InternalList)
                {
                    Result = (EachFilter.Key.Equals(aKey));
                    if (Result)
                    {
                        break;
                    }
                } // foreach

                return Result;
            } // bool ContainsKey(....)

            public int IndexOf(string aKey)
            {
                int Result = -1;

                bool Found = false;
                int AIndex = 0;
                while ((!Found) && (AIndex < this.InternalList.Count))
                {
                    // @to-do: revisar si aplica sensible a mayusculas
                    Found = (this.InternalList[AIndex].Key.Equals(aKey));
                    AIndex++;
                } // while

                if (Found)
                {
                    Result = (AIndex - 1);
                }

                return Result;
            } // int IndexOf(...)

            /// <summary>
            /// Genera una lista de condiciones en la clausula "WHERE",
            /// para una sentencia S.Q.L.
            /// </summary>
            /// <param name="IncludeWhere">Indica si se genera la palabra reservada "WHERE"</param>
            /// <returns>Lista de filtroscomo texto</returns>
            public string ToSQL(bool IncludeWhere, bool IncludeParenthesis, bool FirstItemNoConcat)
            {
                string Result = "";

                // --> preparar manejador texto
                StringBuilderClass strSentence = new StringBuilderClass();

                if (IncludeWhere)
                {
                    strSentence.AppendLine("WHERE (1=1) ");
                }

                if (IncludeParenthesis)
                {
                    if (IncludeWhere)
                    {
                        strSentence.Append("AND ");
                    }

                    strSentence.AppendLine("( ");
                }

                int AMax = this.InternalList.Count;
                for (int AIndex = 0; AIndex < AMax; AIndex++)
                {
                    FilterClass EachFilter = this.InternalList[AIndex];

                    bool IgnoreConcatOperator =
                      (AIndex == 0) && FirstItemNoConcat;

                    String strPredicate = EachFilter.ToSQL(IgnoreConcatOperator);

                    strSentence.AppendLine(strPredicate);
                } // for

                if (IncludeParenthesis)
                {
                    strSentence.AppendLine(") ");
                }

                // ahora si, convertir a una cadena
                Result = strSentence.ToString();

                // --> liberar manejador texto
                strSentence.Destroy();
                strSentence = null;

                return Result;
            } // string ToSQL(...)

            /// <summary>
            /// Adds an object to the end of the collection.
            /// </summary>
            /// <param name="item">Element to be added</param>
            public void Add(FilterClass item)
            {
                this.InternalList.Add(item);
            } // void Add(...)

            /// <summary>
            /// Removes all elements from the list.
            /// </summary>
            public void Clear()
            {
                this.InternalList.Clear();
            } // void Clear(...)

            public FilterClass getItemAt(int AIndex)
            {
                FilterClass Result = null;

                Result = this.InternalList[AIndex];

                return Result;
            } // FilterClass getItemAt(...)

            public void setItemAt(int AIndex, FilterClass item)
            {
                if (item != null)
                {
                    this.InternalList[AIndex] = item;
                } // if (item != null)
            } // void setItemAt(...)

            // ...

            /// <summary>
            /// Copies all value properties from <code>ASource</code>,
            /// to the current object.
            /// </summary>
            /// <param name="ASource">Object to be used as a template</param>
            public override void AssignFrom(CloneableObjectClass ASource)
            {
                if (this.IsReady())
                {                   
                    if (ASource != null)
                    {
                        FilterListClass Data = (ASource as FilterListClass);
                        foreach (FilterClass EachSourceFilter in Data.InternalList)
                        {
                            FilterClass EachDestFilter =
                                (FilterClass)EachSourceFilter.Clone();

                            this.Add(EachDestFilter);
                        } // foreach
                    } // if (ASource != null)
                } // if (this.IsReady())
            } // void AssignFrom(...)

            /// <summary>
            /// When an object of this class is instantiated,
            /// creates & returns a "Shallow" copy of itself.
            /// </summary>
            /// <returns>"Shallow" copy of the object.</returns>
            public override CloneableObjectClass Clone()
            {
                CloneableObjectClass Result = null;

                FilterListClass AResult = FilterListClass.Factory();
                AResult.AssignFrom(this);
                Result = (CloneableObjectClass)AResult;

                return Result;
            } // CloneableObjectClass Clone(...)

            // ...
        #endregion "methods"

        #region "static"
			// ...
			
            /// <summary>
            /// Construye un nuevo objeto de la clase <code>FilterListClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static FilterListClass Factory()
            {
                FilterListClass Result = new FilterListClass();
                Result.Create();

                return Result;
            } // static FilterListClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>FilterListClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref FilterListClass AObject)
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

    } // class FilterListClass

} // namespace