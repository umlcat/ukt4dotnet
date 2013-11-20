using System;
using System.Collections.Generic;
using System.Text;

namespace ukt4dotnet.shared.utilities
{
    /// <summary>
    /// Sirve para convertir entre valores hexadecimales,
    /// alfanumericos y enteros.
    /// </summary>
    public static class Hexadecimal
    {
        public static bool IsHexChar(char value)
        {
            bool Result = false;

            String thisStringSet = "0123456789ABCDEFabcdef";

            bool Found = false;
            foreach (char c in thisStringSet)
            {
                Found = (value == c);
                if (Found)
                {
                    // --> se encontro el digito hexadecimal correspondiente,
                    // --> por lo tanto, salir del ciclo
                    Result = true;
                    break;
                }
            }

            return Result;
        } // static bool IsHexChar(...)

        public static bool IsHexString(String value)
        {
            bool Result = false;

            // cuando SI se pasa NULO o cadena vacia,
            // no se considera hexadecimal
            if (!String.IsNullOrEmpty(value))
            {
                bool ErrorFound = false;
                foreach (char c in value)
                {
                    ErrorFound = (!IsHexChar(c));
                    if (ErrorFound)
                    {
                        // --> se encontro un caracter que no es digito hexadecimal,
                        // --> por lo tanto, salir del ciclo
                        break;
                    }
                } // foreach

                Result = !ErrorFound;
            }

            return Result;
        } // static bool IsHexString(...)

        public static bool tryHexToInt(String value, out int ResultValue)
        {
            bool Result = false;

            ResultValue = 0;

            Result = (IsHexString(value));
            if (Result)
            {
                ResultValue = Convert.ToInt32(value, 16);
            }

            return Result;
        } // static bool tryHexToInt(...)

        public static int HexToInt(String value)
        {
            int Result = 0;

            bool couldConvert = tryHexToInt(value, out Result);
            if (!couldConvert)
            {
                throw new InvalidCastException();
            }

            return Result;
        } // static int HexToInt(...)

        public static String IntToHex(Int16 value)
        {
            String Result = "";

            Result = value.ToString("16");

            return Result;
        } // static String IntToHex(...)

        public static String StrToHex(String Value)
        {
            String Result = "";

            foreach (Char eachChar in Value)
            {
                String D = Convert.ToInt32(eachChar).ToString("X");
                Result += D;
            } // foreach

            return Result;
        } // String StrToHex(...)

    } // static class Hexadecimal


} // namespace
