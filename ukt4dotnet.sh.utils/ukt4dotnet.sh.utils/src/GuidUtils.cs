using System;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities
{
    public static class GuidUtils
    {
        // ...

        public static String GuidToOnlyDigitsQuoted(Guid ASource)
        {
            String Result = null;

            Result = String.Format("'{0}'", ASource.ToString("n"));

            return Result;
        } // String GuidToOnlyDigitsQuoted(...)

        public static String GuidToOnlyDigitsDQuoted(Guid ASource)
        {
            String Result = null;

            Result = String.Format("\"{0}\"", ASource.ToString("n"));

            return Result;
        } // String GuidToOnlyDigitsDQuoted(...)

        public static String GuidToOnlyDigitsBrackets(Guid ASource)
        {
            String Result = null;

            Result = String.Format("{{0}}", ASource.ToString("n"));

            return Result;
        } // String GuidToOnlyDigitsBrackets(...)

        /// <summary>
        /// Espera recibir un G.U.I.D. formado,
        /// por una cadena de 32 caracteres que son,
        /// digitos hexadecimales,
        /// sin guiones, u otro separador,
        /// y lo convierte a un tipo G.U.I.D. nativo.
        /// </summary>
        /// <param name="ASource">String value assumed to be a <code>Guid</code></param>
        /// <returns>A Guid structure</returns>
        public static Guid OnlyDigitsToGuid(String ASource)
        {
            Guid Result = Guid.NewGuid();

            bool CanConvert =
                ((ASource != null) && (ASource.Length == 32));
            if (CanConvert)
            {
                Result = new Guid(ASource);
            } // if (CanConvert)
            
            return Result;
        } // static Guid OnlyDigitsToGuid (...)

        public static Guid CanonicalToGuid(String ASource)
        {
            Guid Result = Guid.NewGuid();

            bool CanConvert =
                ((ASource != null) && (ASource.Length == 32));
            if (CanConvert)
            {
                Result = new Guid(ASource);
            } // if (CanConvert)

            return Result;
        } // static Guid CanonicalToGuid (...)
        
        /// <summary>
        /// Recibe una estructura Guid,
        /// y la trnasforma en una cadena,
        /// compuesta, solo por, caracteres,
        /// que son digitos hexadecimales.
        /// </summary>
        /// <param name="ASource"></param>
        /// <returns></returns>
        public static String GuidToOnlyDigits(Guid ASource)
        {
            String Result = null;
            
            Result = ASource.ToString("n");          
            
            return Result;
        } // String GuidToOnlyDigits(...)

        public static String GuidToCanonical(Guid ASource)
        {
            String Result = null;

            Result = ASource.ToString("d");

            return Result;
        } // String GuidToCanonical(...)

        public static String EmptyGuidToOnlyDigits()
        {
            String Result = null;

            Guid AGuid = Guid.Empty;
            Result = AGuid.ToString("n");

            return Result;
        } // String EmptyGuidToOnlyDigits(...)

        public static String EmptyGuidToOnlyDigitsQuoted()
        {
            String Result = null;

            Result = String.Format("'{0}'", Guid.Empty.ToString("n"));

            return Result;
        } // String EmptyGuidToOnlyDigitsQuoted(...)

        public static String EmptyGuidToOnlyDigitsDQuoted()
        {
            String Result = null;

            Result = String.Format("\"{0}\"", Guid.Empty.ToString("n"));

            return Result;
        } // String EmptyGuidToOnlyDigitsQuoted(...)

        public static String EmptyGuidToOnlyDigitsBrackets()
        {
            String Result = null;

            Result = String.Format("{{0}}", Guid.Empty.ToString("n"));

            return Result;
        } // String EmptyGuidToOnlyDigitsQuoted(...)

        public static String EmptyGuidToCanonical()
        {
            String Result = null;

            Guid AGuid = Guid.Empty;
            Result = AGuid.ToString("d");

            return Result;
        } // String EmptyGuidToOnlyDigitsQuoted(...)

        /*
        Specifier   Format of the input parameter
        N           32 digits:
                    00000000000000000000000000000000
        D           32 digits separated by hyphens:
                    00000000-0000-0000-0000-000000000000
        B           32 digits separated by hyphens, enclosed in braces:
                    {00000000-0000-0000-0000-000000000000}
        P           32 digits separated by hyphens, enclosed in parentheses:
                    (00000000-0000-0000-0000-000000000000)
        X           Four hexadecimal values enclosed in braces, where the fourth value is a subset of eight hexadecimal values that is also enclosed in braces:
                    {0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
        */

        // ...
    } // class

} // namespace