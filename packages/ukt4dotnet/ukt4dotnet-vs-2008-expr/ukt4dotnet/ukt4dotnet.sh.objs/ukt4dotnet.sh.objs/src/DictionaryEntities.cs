using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.utilities.DictionaryEntities
{
    public class DictionaryEntityPropertyClass : ObjectClass
    {
        #region "accessors"
        public virtual String getPropertyName()
        {
            return this._PropertyName;
        } // String getPropertyName(...)

        public virtual void setPropertyName(String Value)
        {
            this._PropertyName = Value;
        } // void setPropertyName(...)

        // ...

        #endregion "properties"

        #region "properties"

        protected String _PropertyName = "";
        public String PropertyName
        {
            get { return this.getPropertyName(); }
            set { this.setPropertyName(value); }
        }

        // ...

        #endregion "properties"

        #region "constructors"
        public override Int64 Create()
        {
            Int64 Result = 0;
            this._PropertyName = "";
            return Result;
        } // Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;
            this._PropertyName = "";
            return Result;
        } // Int64 Destroy(...)
        #endregion "constructors"

        #region "methods"

        public bool matchesName(String AName)
        {
            bool Result = StrUtils.Same(this._PropertyName, AName);

            return Result;
        } // bool matchesName(...)

        #endregion "methods"

        // ...

    } // class DictionaryEntityPropertyClass

    public class DictionaryEntityClass : ObjectClass
    {
        #region "properties"

        List<DictionaryEntityPropertyClass> Properties = null;

            // ...

        #endregion "properties"

        #region "constructors"
        public override Int64 Create()
        {
            Int64 Result = 0;
                this.Properties = new List<DictionaryEntityPropertyClass>();
            return Result;
        } // Int64 Create(...)

        public override Int64 Destroy()
        {
            Int64 Result = 0;
                this.Properties.Clear();
                this.Properties = null;
            return Result;
        } // Int64 Destroy(...)
        #endregion "constructors"

        #region "methods"

        /// <summary>
        /// Busca una propiedad, que tenga el mismo identificador,
        /// que el parametro proporcionado. No es sensible-al-caso.
        /// No puede haber 2 propiedades, en la misma entidad,
        /// con el mismo identificador, aunque alguna letra,
        /// difiera con el caso.
        /// </summary>
        /// <param name="AName">Identificador de la propiedad</param>
        /// <returns><code>null</code></returns>
        public DictionaryEntityPropertyClass findByName(String AName)
        {
            DictionaryEntityPropertyClass Result = null;

            foreach (DictionaryEntityPropertyClass eachProperty in this.Properties)
            {
                if (eachProperty.matchesName(AName))
                {
                    Result = eachProperty;
                    break;
                }
            } // foreach

            return Result;
        } // DictionaryEntityPropertyClass findByName(...)

        public bool RegisterPropertyByName(String AName)
        {
            bool Result = false;

            DictionaryEntityPropertyClass AProperty = findByName(AName);
            Result = (AProperty == null);

            if (Result)
            {




            } // if (Result)

            return Result;
        } // bool RegisterPropertyByName(String AName)


        #endregion "methods"

        // ...

    } // class DictionaryEntityClass



} // namespace ukt4dotnet.DictionaryEntities
