using System;
using System.Collections.Generic;
using System.Text;

namespace ukt4dotnet.shared.utilities
{
    // ukt4dotnet.shared.utilities.KeyGenerator
    /// <summary>
    /// Clase que se usa para generar llaves primarias temporales para B.D.
    /// </summary>
    public class KeyGenerator
    {
        #region "fields"
            private int _Key;
            protected int Key
            {
                get { return _Key; }
                set { _Key = value; }
            }
        #endregion "fields"

        #region "constructor"
            public KeyGenerator()
			{
                _Key = 0;
			}
        #endregion "constructor"

        #region "methods"

        /// <summary>
        /// Regresa la siguiente llave,
        /// aumentando el contador interno.
        /// </summary>
        /// <returns></returns>
        public int NextKey()
        {
            this._Key++;
            return this._Key;
        }

        /// <summary>
        /// Vuelve a reiniciar el valor inicial.
        /// </summary>
        public void Reset()
        {
            this.Key = 0;
        }

        #endregion "methods"
    } // class KeyGenerators
} // namespace
