using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.utilities
{

    /// <summary>
    /// Provee algunas funciones matematicas adicionales,
    /// de uso comun, que no hay en el <code>namespace System.Math</code>.
    /// </summary>
    public static class Math
    {
        public const string CurrencyWithSymbolFormat = "c";
        public const string CurrencyWithoutSymbolFormat = "###,###,##0.00";

        /// <summary>
        /// Regresa si un numero entero es par.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsEven(int Value)
        {
            bool Result = (Value % 2 == 0);

            return Result;
        } // bool IsEven(...)

        /// <summary>
        /// Regresa si un numero entero es impar.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool IsOdd(int Value)
        {
            bool Result = (Value % 2 != 0);

            return Result;
        } // bool IsOdd(...)

        /// <summary>
        /// Toma un valor y regresa siempre el mismo valor con signo negativo,
        /// Sin importar, si el valor original tenia signo positivo o negativo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int NegAbs(int value)
        {
            int Result = System.Math.Abs(value) * -1;

            return Result;
        } // static int NegAbs(...)

        /// <summary>
        /// Toma un valor y regresa siempre el mismo valor con signo negativo,
        /// Sin importar, si el valor original tenia signo positivo o negativo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double NegAbs(double value)
        {
            double Result = System.Math.Abs(value) * -1;

            return Result;
        } // static double NegAbs(...)

        /// <summary>
        /// Toma un valor y regresa siempre el mismo valor con signo negativo,
        /// Sin importar, si el valor original tenia signo positivo o negativo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal NegAbs(decimal value)
        {
            decimal Result = System.Math.Abs(value) * -1;

            return Result;
        } // static decimal NegAbs(...)

        /// <summary>
        /// Toma 2 valores enteros,
        /// y al hacer una division,
        /// que pudiese generar un resultado de punto flotante,
        /// regresa la parte entera de un modulo,
        /// aunque haya parte fraccionaria ("decimal")
        /// </summary>
        /// <param name="a">Divisor</param>
        /// <param name="b">Dividendo</param>
        /// <returns>Resultado entero mas aproximado sin pasarse</returns>
        public static int IntToIntDiv(int a, int b)
        {
            int Result = 0;

            int rem = 0;
            Result = System.Math.DivRem(a, b, out rem);

            return Result;
        } // function

        public static int IntToIntRem(int a, int b)
        {
            int Result = 0;

            int ignore = 0;
            ignore = System.Math.DivRem(a, b, out Result);

            return Result;
        } // function

        /// <summary>
        /// Toma 2 valores enteros,
        /// y al hacer una division,
        /// que pudiese generar un resultado de punto flotante,
        /// regresa resultado de punto flotante.
        /// </summary>
        /// <param name="a">Divisor</param>
        /// <param name="b">Dividendo</param>
        /// <returns>Resultado de punto flotante</returns>
        public static float IntToFloatDiv(int a, int b)
        {
            int Result = 0;

            Result = (a / b);

            return Result;
        } // function

        /// <summary>
        /// Toma 2 valores enteros,
        /// y al hacer una division,
        /// que pudiese generar un resultado de punto flotante,
        /// regresa la parte entera de un modulo,
        /// aunque haya parte fraccionaria ("decimal").
        /// Nota: En caso de que el dividendo sea {0},
        /// no se genera excepcion, y se regresa {0}, como resultado.
        /// </summary>
        /// <param name="a">Divisor</param>
        /// <param name="b">Dividendo</param>
        /// <returns>Resultado entero mas aproximado sin pasarse</returns>
        public static int SafeIntToIntDiv(int a, int b)
        {
            int Result = 0;

            if (b != 0)
            {
                int rem = 0;
                Result = System.Math.DivRem(a, b, out rem);
            }

            return Result;
        } // int SafeIntToIntDiv

        /// <summary>
        /// Toma 2 valores enteros,
        /// en donde , el segundo valor es un porcentaje,
        /// y regresa el valor entero sin parte fraccionaria.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int IntPercent(int a, int b)
        {
            int Result = 0;

            int x = (a * b);
            Result = SafeIntToIntDiv(x, 100);

            return Result;
        } // int IntPercent

        /// <summary>
        /// Toma un valor de punto flotante,
        /// y extrae por separado las partes entera y fraccionaria.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="intSection"></param>
        /// <param name="fracSection"></param>
        public static void SplitFloat(float value, out int numIntSection, out int numFracSection)
        {
            numIntSection = 0;
            numFracSection = 0;

            // pasar a alfanumerico
            String strTemp = value.ToString();

            // obtener ubicacion punto
            int i = strTemp.IndexOf('.');
            if (i > 0)
            {
                String strIntSection = StrUtils.LeftCopyByLength(strTemp, i + 1);
                numIntSection = Convert.ToInt16(strIntSection);

                String strFraccSection = StrUtils.LeftCopyByLength(strTemp, i + 1);
                numFracSection = Convert.ToInt16(strFraccSection);
            }
            else
            {
                numIntSection = Convert.ToInt16(strTemp);
            }
        } // static void SplitFloat(...)

        /// <summary>
        /// Toma un valor de punto flotante,
        /// y extrae por separado las partes entera y fraccionaria.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="intSection"></param>
        /// <param name="fracSection"></param>
        public static void SplitDouble(double value, out Int32 numIntSection, out Int32 numFracSection)
        {
            numIntSection = 0;
            numFracSection = 0;

            // pasar a alfanumerico
            String strTemp = value.ToString();

            // obtener ubicacion punto
            int i = strTemp.IndexOf('.');
            if (i > 0)
            {
                String strIntSection = StrUtils.LeftCopyByLength(strTemp, i + 1);
                numIntSection = Convert.ToInt16(strIntSection);

                String strFraccSection = StrUtils.RightCopyByLength(strTemp, i);
                numFracSection = Convert.ToInt16(strFraccSection);
            }
            else
            {
                numIntSection = Convert.ToInt16(strTemp);
            }
        } // static void SplitDouble(...)

        /// <summary>
        /// Toma un valor de punto flotante,
        /// y extrae por separado las partes entera y fraccionaria.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="intSection"></param>
        /// <param name="fracSection"></param>
        public static void SplitDecimal(decimal value, out Int64 numIntSection, out Int64 numFracSection)
        {
            numIntSection = 0;
            numFracSection = 0;

            // pasar a alfanumerico
            String strTemp = value.ToString();

            // obtener ubicacion punto
            int i = strTemp.IndexOf('.');
            if (i > 0)
            {
                //String strIntSection = ukt4dotnet.shared.utilities.StrUtils.LeftCopy(strTemp, i + 1);

                String strIntSection = StrUtils.LeftCopyByLength(strTemp, i);
                numIntSection = Convert.ToInt16(strIntSection);

                // "* - 1" no contar punto decimal
                int ALength = (strTemp.Length - 1);
                int HowMany = (ALength - i);
                String strFraccSection = StrUtils.RightCopyByLength(strTemp, HowMany);
                numFracSection = Convert.ToInt64(strFraccSection);
            }
            else
            {
                numIntSection = Convert.ToInt64(strTemp);
            }
        } // static void SplitDecimal(...)

        // ...

    } // static class Math


} // namespace
