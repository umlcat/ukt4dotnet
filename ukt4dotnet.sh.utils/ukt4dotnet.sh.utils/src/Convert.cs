using System;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities
{
    // romo.shared.utilities.ExtendedConvert
    /// <summary>
    /// Extension de la clase <code>Convert</code>.
    /// </summary>
    public static class SafeConvert
    {
        /// <summary>
        /// Intenta convertir un valor tipo <code>Object</code> al tipo <code>DefaultValue</code>.
        /// Captura las excepciones generadas, y regresa el valor por-de-facto, proporcionado.
        /// </summary>
        /// <param name="Value">Valor fuente</param>
        /// <param name="DefaultValue">Valor destino por-de-facto, en caso de error</param>
        /// <returns>Resultado conversion.</returns>
        public static String ToString(Object Value, string DefaultValue)
        {
            string Result = "";

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToString(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static String ToString(...)

        /// <summary>
        /// Intenta convertir un valor tipo <code>Object</code> al tipo <code>DefaultValue</code>.
        /// Captura las excepciones generadas, y regresa el valor por-de-facto, proporcionado.
        /// </summary>
        /// <param name="Value">Valor fuente</param>
        /// <param name="DefaultValue">Valor destino por-de-facto, en caso de error</param>
        /// <returns>Resultado conversion.</returns>
        public static Boolean ToBoolean(Object Value, bool DefaultValue)
        {
            bool Result = false;

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToBoolean(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static Boolean ToBoolean(...)

        /// <summary>
        /// Intenta convertir un valor tipo <code>Object</code> al tipo <code>DefaultValue</code>.
        /// Captura las excepciones generadas, y regresa el valor por-de-facto, proporcionado.
        /// </summary>
        /// <param name="Value">Valor fuente</param>
        /// <param name="DefaultValue">Valor destino por-de-facto, en caso de error</param>
        /// <returns>Resultado conversion.</returns>
        public static Int16 ToInt16(Object Value, Int16 DefaultValue)
        {   
            Int16 Result = 0;

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToInt16(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static Int16 ToInt16(...)

        public static Int32 ToInt32(Object Value, Int16 DefaultValue)
        {
            Int32 Result = 0;

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToInt32(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static Int32 ToInt32(...)

        public static DateTime ToDateTime(Object Value, DateTime DefaultValue)
        {
            DateTime Result = System.DateTime.Now;

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToDateTime(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static DateTime ToDateTime(...)

        public static Decimal ToDecimal(Object Value, Decimal DefaultValue)
        {
            Decimal Result = 0;

            if (Value != null)
            {
                try
                {
                    Result = Convert.ToDecimal(Value);
                }
                catch (DisposableException ex)
                {
                    Result = DefaultValue;
                    ex.Dispose();
                    ex = null;
                }
            }
            else
            {
                Result = DefaultValue;
            }

            return Result;
        } // static Decimal ToDecimal(...)

    } // class ExtendedConvert

} // namespace romo.shared.utilities
