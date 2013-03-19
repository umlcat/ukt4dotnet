using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities
{
    // romo.shared.utilities.strings.StrUtils
    /// <summary>
    /// Provee algunas funciones matematicas adicionales,
    /// de uso comun, que no hay en el <code>namespace System.String</code>.
    /// </summary>
    public static class StrUtils
    {
        /// <summary>
        /// Regresa el equivalente textual,
        /// del valor booleano proporcionado.
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string BoolToStr(bool Value)
        {
            string Result = "";

            if (Value)
            {
                Result = "true";
            }
            else
            {
                Result = "false";
            }

            return Result;
        } // static string BoolToStr(...)

        /// <summary>
        /// Regresa una cadena compuesta por el mismo caracter,
        /// indicado por <code>AValue</code>,
        /// la cantidad indicada por <code>ACount</code>.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="ACount"></param>
        /// <returns></returns>
        public static string RepeatCopy(char AValue, int ACount)
        {
            string Result = new String(AValue, ACount);
            return Result;
        } // static string RepeatCopy(...)

        /// <summary>
        /// Agrega comillas simples a la copia de una cadena.
        /// </summary>
        /// <param name="source">Cadena Fuente</param>
        /// <returns>Cadena entre comillas</returns>
        public static string QuoteStr(string source)
        {
            // variable temporal para poder depurar mejor,
            // como resultado de funcion
            string Result = "'" + source + "'";
            return Result;
        }

        /// <summary>
        /// Agrega comillas dobles a la copia de una cadena.
        /// </summary>
        /// <param name="source">Cadena Fuente</param>
        /// <returns>Cadena entre comillas</returns>
        public static string QuoteDStr(string source)
        {
            // variable temporal para poder depurar mejor,
            // como resultado de funcion
            string Result = "\"" + source + "\"";
            return Result;
        }

        /// <summary>
        /// Regresa una copia de la cadena indicada,
        /// en donde, los corchetes con reemplazados,
        /// con comillas dobles.
        /// </summary>
        /// <param name="avalue"></param>
        /// <returns></returns>
        public static string BracketsToDQuotes(string avalue)
        {
            string Result = avalue;

            Result = Result.Replace('{', '"');
            Result = Result.Replace('}', '"');

            return Result;
        }

        /// <summary>
        /// Regresa una copia de la cadena indicada,
        /// en donde, los corchetes con reemplazados,
        /// con comillas dobles.
        /// </summary>
        /// <param name="avalue"></param>
        /// <returns></returns>
        public static string SquareBracketsToDQuotes(string avalue)
        {
            string Result = avalue;

            Result = Result.Replace('[', '"');
            Result = Result.Replace(']', '"');

            return Result;
        }

        public static string SquareBracketsToBrackets(string avalue)
        {
            string Result = avalue;

            Result = Result.Replace('[', '{');
            Result = Result.Replace(']', '}');

            return Result;
        }

        /// <summary>
        /// <summary>
        /// Regresa una copia de la cadena indicada,
        /// en donde, los corchetes con reemplazados,
        /// con comillas simples.
        /// </summary>
        /// <param name="avalue"></param>
        /// <returns></returns>
        public static string BracketsToSQuotes(string avalue)
        {
            string Result = avalue;

            Result = Result.Replace('{', '\'');
            Result = Result.Replace('}', '\'');

            return Result;
        } // static string BracketsToSQuotes(...)

        /// <summary>
        /// Regresa una copia de la cadena <code>AValue</code>,
        /// con las ocurrencias de la subcadena <code>Source</code>,
        /// reemplazadas con la subcadena <code>Dest</code>.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="Source"></param>
        /// <param name="Dest"></param>
        /// <returns></returns>
        public static string ReplaceStringCopy(String AValue, string ASource, string ADest)
        {
            string Result = "";

            Result = AValue.Replace(ASource, ADest);

            return Result;
        } // static string ReplaceStringCopy(...)

        /// <summary>
        /// Busca copias de la cadena indicada por <code></code>
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string RemoveStringCopy(String AValue, string ASource)
        {
            string Result = "";

            Result = AValue.Replace(ASource, "");

            return Result;
        } // static string RemoveStringCopy(...)

        public static char StrToCharDef(string ASource, char ADefaultValue)
        {
            char Result = '\0';

            if (String.IsNullOrEmpty(ASource))
            {
                Result = ADefaultValue;
            }
            else
	        {
                Result = ASource[0];
	        }

            return Result;
        } // static char StrToCharDef(...)

        public static char StrToChar(string ASource)
        {
            char Result = '\0';
            
            Result = ASource[0];

            return Result;
        } // static char StrToChar(...)

        public static string CharToStr(char ASource)
        {
            string Result = "";

            Result += ASource;

            return Result;
        } // static char CharToStr(...)

        public static string RemoveCharCopy(String AValue, char ASource)
        {
            string Result = "";

            string ASourceStr = CharToStr(ASource);

            Result = AValue.Replace(ASourceStr, "");

            return Result;
        } // static string RemoveCharCopy(...)

        /// <summary>
        /// Returns a copy of a string,
        /// where each character indicated by <code>ASource</code>,
        /// is replaced by the substring indicated by <code>ADest</code>.
        /// Note. The functions:
        /// <ul>
        /// <li><code>ReplaceCharByStrCopy</code>,</li>
        /// <li><code>ReplaceCharByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByStrCopy</code>,</li>
        /// </ul>
        /// Have identical goal, yet intended to be optimized,
        /// since string operations use a lot of resources.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="ASource"></param>
        /// <param name="ADest"></param>
        /// <returns></returns>
        public static string ReplaceCharByStrCopy(String AValue, char ASource, string ADest)
        {
            string Result = "";

            string ASourceStr = CharToStr(ASource);

            // @to-do: optimize !!!
            Result = AValue.Replace(ASourceStr, ADest);

            return Result;
        } // static string ReplaceCharByStrCopy(...)

        /// <summary>
        /// Returns a copy of a string,
        /// where each character indicated by <code>ASource</code>,
        /// is replaced by the character indicated by <code>ADest</code>.
        /// Note. The functions:
        /// <ul>
        /// <li><code>ReplaceCharByStrCopy</code>,</li>
        /// <li><code>ReplaceCharByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByStrCopy</code>,</li>
        /// </ul>
        /// Have identical goal, yet intended to be optimized,
        /// since string operations use a lot of resources.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="ASource"></param>
        /// <param name="ADest"></param>
        /// <returns></returns>
        public static string ReplaceCharByCharCopy(String AValue, char ASource, char ADest)
        {
            string Result = "";

            string ASourceStr = CharToStr(ASource);
            string ADestStr   = CharToStr(ADest);

            // @to-do: optimize !!!
            Result = AValue.Replace(ASourceStr, ADestStr);

            return Result;
        } // static string ReplaceCharByCharCopy(...)


        /// <summary>
        /// Returns a copy of a string,
        /// where each substring indicated by <code>ASource</code>,
        /// is replaced by the character indicated by <code>ADest</code>.
        /// Note. The functions:
        /// <ul>
        /// <li><code>ReplaceCharByStrCopy</code>,</li>
        /// <li><code>ReplaceCharByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByStrCopy</code>,</li>
        /// </ul>
        /// Have identical goal, yet intended to be optimized,
        /// since string operations use a lot of resources.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="ASource"></param>
        /// <param name="ADest"></param>
        /// <returns></returns>
        public static string ReplaceStrByCharCopy(String AValue, string ASource, char ADest)
        {
            string Result = "";

            string ADestStr = CharToStr(ADest);

            // @to-do: optimize !!!
            Result = AValue.Replace(ASource, ADestStr);

            return Result;
        } // static string ReplaceStrByCharCopy(...)


        /// <summary>
        /// Returns a copy of a string,
        /// where each substring indicated by <code>ASource</code>,
        /// is replaced by the substring indicated by <code>ADest</code>.
        /// Note. The functions:
        /// <ul>
        /// <li><code>ReplaceCharByStrCopy</code>,</li>
        /// <li><code>ReplaceCharByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByCharCopy</code>,</li>
        /// <li><code>ReplaceStrByStrCopy</code>,</li>
        /// </ul>
        /// Have identical goal, yet intended to be optimized,
        /// since string operations use a lot of resources.
        /// </summary>
        /// <param name="AValue"></param>
        /// <param name="ASource"></param>
        /// <param name="ADest"></param>
        /// <returns></returns>
        public static string ReplaceStrByStrCopy(String AValue, string ASource, string ADest)
        {
            string Result = "";

            // already provided
            Result = AValue.Replace(ASource, ADest);

            return Result;
        } // static string ReplaceStrByStrCopy(...)

        /// <summary>
        /// Obtains a partial copy of the given string,
        /// starting from the left, to the right,
        /// extracting the given quantity of characters.
        /// </summary>
        /// <param name="str">Full source string</param>
        /// <param name="len">Quantity of characters</param>
        /// <returns>Substring</returns>
        public static string LeftCopyByLength(String str, int len)
        {
            string Result = "";

            bool CanCopy =
                ((str != null) && (str.Length > 0) && (str.Length > len));
            if (CanCopy)
            {
                len = System.Math.Min(len, str.Length);
                Result = str.Substring(0, len);
            }

            return Result;
        } // static string LeftCopyByLength(...)

        /// <summary>
        /// Obtains a partial copy of the given string,
        /// starting from the right, to the left,
        /// of the given string.
        /// </summary>
        /// <param name="str">Full source string</param>
        /// <param name="len">Quantity of characters</param>
        /// <returns>Substring</returns>
        public static string RightCopyByLength(string str, int len)
        {
            string Result = "";

            bool CanCopy =
                ((str != null) && (str.Length > 0) && (str.Length >= len));
            if (CanCopy)
            {
                Result = str.Substring(str.Length - len);
            }

            return Result;
        } // string RightCopyByLength(...)

        /// <summary>
        /// Regresa una copia del primer caracter.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char FirstCharCopy(string str)
        {
            char Result = '\0';

            if (str.Length > 0)
            {
                Result = str[0];
            }

            return Result;
        } // char FirstCharCopy(...)

        /// <summary>
        /// Regresa una copia del ultimo caracter.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char LastCharCopy(string str)
        {
            char Result = '\0';

            int Len = str.Length;
            if (Len > 0)
            {
                Len--;
                Result = str[Len];
            }

            return Result;
        } // char LastCharCopy(...)

        /// <summary>
        /// Encodes a string to be represented as a string literal. The format
        /// is essentially a JSON string.
        /// The string returned includes outer quotes 
        /// Example Output: "Hello \"Rick\"!\r\nRock on"
        /// </summary>
        /// <param name="s">Source string</param>
        /// <returns>Escaped String</returns>
        public static string EscapeCopy(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\'':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    case '\0':
                        sb.Append("\\0");
                        break;
                    case '\a':
                        sb.Append("\\a");
                        break;
                    case '\v':
                        sb.Append("\\v");
                        break;
                    case '\x001A':
                        sb.Append("\\z");
                        break;
                    case ' ':
                        sb.Append("\\s");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                } // switch
            } // foreach

            string Result = sb.ToString();
            return Result;
        } // static string EscapeCopy(...)

        /// <summary>
        /// Obtains the current length,
        /// of the given string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>current lenght</returns>
        public static int Length(string str)
        {
            int Result = str.Length;

            return Result;
        } // int Length(...)

        /// <summary>
        /// Obtain remainning lenght,
        /// of the given string,
        /// starting at the given index.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>remainning current lenght</returns>
        public static int LengthAt(string str, int StartIndex)
        {
            int Result = 0;

            int Len = str.Length;
            if ((Len > 0) & (StartIndex > -1))
            {
                Result = (Len - StartIndex);
            }

            return Result;
        } // int Length(...)

        /*
        /// <summary>
        /// Obtains the last or rightest substring of characters,
        /// of the given string.
        /// </summary>
        /// <param name="str">Full source string</param>
        /// <param name="RightIndex">Index from left to right,
        /// where the first char starts.</param>
        /// <returns></returns>
        public static string RightCopyByIndex(string str, int RightIndex)
        {
            string Result = "";

            if (str != null)
            {
                int AIndex = ();
                Result = str.Substring(str.Length - len);
            }

            return Result;
        } // static string RightCopyByIndex(...)
        */

        public static string MidCopy(string str, int start, int len)
        {
            string Result = "";

            Result = str.Substring(start, len);

            return Result;
        } // static string MidCopy(...)

        /// <summary>
        /// If founds a string prefix in the given text,
        /// returns a copy without the prefix,
        /// otherwise, returns the full string.
        /// </summary>
        /// <param name="prefix">prefix substring</param>
        /// <param name="str">Text with an optional prefix</param>
        /// <returns>Text without a prefix</returns>
        public static string TrimPrefix(String prefix, String str)
        {
            string Result = "";

            if (str.StartsWith(prefix))
            {
                int alen = (str.Length - prefix.Length);
                Result = StrUtils.RightCopyByLength(str, alen);
            }
            else
            {
                Result = str;
            }

            return Result;
        } // static string TrimPrefix(...)

        /// <summary>
        /// If founds a string prefix in the given text,
        /// returns a copy without the posfix,
        /// otherwise, returns the full string.
        /// </summary>
        /// <param name="prefix">prefix substring</param>
        /// <param name="str">Text with an optional posfix</param>
        /// <returns>Text without a posfix</returns>
        public static string TrimPosfix(String posfix, String str)
        {
            string Result = "";

            if (str.EndsWith(posfix))
            {
                int alen = (str.Length - 1);
                str = StrUtils.LeftCopyByLength(str, alen);
            }

            Result = str;

            return Result;
        } // static string TrimPosfix(...)

        /// <summary>
        /// Returns a copy of the <code>str</code> string,
        /// where the given prefix &  posfix substrings, are removed.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="posfix"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimDelimiters(String prefix, String posfix, String str)
        {
            string Result = "";

            str = TrimPrefix(prefix, str);
            str = TrimPosfix(posfix, str);
            Result = str;

            return Result;
        } // string TrimDelimiters(...)

        public static List<string> XMLStringToList(string AValue)
        {
            List<string> Result = new List<string>();

            // --> pasar datos a lista
            AValue = StrUtils.TrimDelimiters("[", "]", AValue);
            Result = StrUtils.SplitBySingleCharList(AValue, ',', true);

            int Index = 0;
            int C = 0;

            // asegurarnos quitar espacios en blanco
            Index = 0; C = Result.Count;
            while (Index < C)
            {
                Result[Index] = Result[Index].Trim();

                Index++;
            } // while

            return Result;
        } // static List<string> XMLStringToList(...)

        /// <summary>
        /// Regresa si las 2 cadenas son iguales,
        /// ignorando caso sensitivo.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool Same(String A, String B)
        {
            bool Result = false;

            String C = A.ToLower();
            String D = B.ToLower();

            Result = (String.Equals(A, B));

            return Result;
        } // public static bool Same(...)

        /// <summary>
        /// Regresa una copia, con los caractares,
        /// en orden inverso de la cadena proporcionada.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseCopy(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        } // static string ReverseCopy(...)

        /// <summary>
        /// Regresa una cadena con la longuitud indicada,
        /// en donde se repite la secuencia de todos los digitos decimales,
        /// comenzando con 0.
        /// </summary>
        /// <param name="count">Longuitud cadena</param>
        /// <returns></returns>
        public static string DecimalSequenceFill(int count)
        {
            string Result = "";

            StringBuilder s = new StringBuilder();

            int k = 0;
            for (int g = 0; g < count; g++)
            {
                char AChar = k.ToString()[0];
                s.Append(AChar);

                if (k < 9)
                {
                    k++;
                }
                else
                {
                    k = 0;
                }
            } // for (g)

            Result = s.ToString();
            return Result;
        }

        // @to-do: funcion que cambie varios espacios consecutivos en uno solo,
        // sin usar expresiones regulares

        /// <summary>
        /// Toma un caracter e indica si se encuentra dentro de la cadena.
        /// </summary>
        /// <param name="AItem">Caracter en especifico que se va a buscar.</param>
        /// <param name="ASet">Cadena que se utiliza como un conjunto matematico de caracteres.</param>
        /// <returns>Resultado de la busqueda.</returns>
        public static bool InSet(Char AItem, String ASet)
        {
            bool Result = false;

            Result = (ASet.IndexOf(AItem) > -1);

            return Result;
        }

        /// <summary>
        /// Regresa una cadena con el alfabeto como si fuese un conjunto de caracteres.
        /// </summary>
        /// <returns></returns>
        public static String AlphaStringSet()
        {
            String Result = "";

            StringBuilder ASet = new StringBuilder();
            Char thisChar = '0';

            thisChar = 'a';
            do
            {
                ASet.Append(thisChar);

                thisChar++;
            }
            while (thisChar <= 'z');

            thisChar = 'A';
            do
            {
                ASet.Append(thisChar);

                thisChar++;
            }
            while (thisChar <= 'Z');

            Result = ASet.ToString();
            return Result;
        } // static String AlphaStringSet(...)

        /// <summary>
        /// Busca la primera ocurrencia de cualquiera de los caracteres,
        /// que estan en <code>Source</code>, en <code>Dest</code>.
        /// Importante: No busca la cadena completa de <code>Source</code>,
        /// en <code>Dest</code>, solo cualquiera de sus caracteres.
        /// </summary>
        /// <param name="Dest">Cadena en donde se buscaran caracteres.</param>
        /// <param name="Source">Cadena utilizada como conjunto fuente de caracteres.</param>
        /// <param name="startIndex">Indice en donde se comenzara la busqueda.</param>
        /// <returns></returns>
        public static int SetIndexOfAt(String Source, String Dest, int StartIndex)
        {
            int Result = -1;

            int EachIndex = StartIndex;
            bool CanSkip = false;
            bool CanContinue = false;

            do
            {
                // toma cada caracter de <code>Dest</code> y busca
                // que se encuentre en <code>Source</code>
                CanSkip = (!InSet(Dest[EachIndex], Source));

                // revisar siguiente caracter
                EachIndex++;
                CanContinue = (EachIndex < Dest.Length);
            }
            while (CanSkip && CanContinue);

            if (CanSkip)
            {
                Result = (EachIndex - 1);
            }

            return Result;
        } // static int SetIndexOfAt(...)

        /// <summary>
        /// Busca la primera NO-ocurrencia de cualquiera de los caracteres,
        /// que estan en <code>Source</code>, en <code>Dest</code>.
        /// Importante: No busca la cadena completa de <code>Source</code>,
        /// en <code>Dest</code>, solo busca que no coincida cualquiera de sus caracteres.
        /// </summary>
        /// <param name="Dest"></param>
        /// <param name="Source"></param>
        /// <param name="StartIndex"></param>
        /// <returns></returns>
        public static int SetNotIndexOfAt(String Dest, String Source, int StartIndex)
        {
            int Result = -1;

            int EachIndex = StartIndex;
            bool Match = false;
            bool CanContinue = false;

            do
            {
                // toma cada caracter de <code>Dest</code> y busca
                // que se encuentre en <code>Source</code>
                Match = (InSet(Dest[EachIndex], Source));

                // revisar siguiente caracter
                EachIndex++;
                CanContinue = (EachIndex < Dest.Length);
            }
            while (Match && CanContinue);

            if (!Match)
            {
                Result = (EachIndex - 1);
            }

            return Result;
        } // static int SetNotIndexOfAt(...)

        /// <summary>
        /// Recibe un conjunto de cadenas y los concatena en una sola lista.
        /// Opcionalmente, agrega un caracter delimitador entre las subcadenas.
        /// </summary>
        /// <param name="Lines">Lineas de texto tipo <code>Lines</code>.</param>
        /// <param name="Delimiter">Caracter que se utilizara como delimitador,
        /// en caso de <code> '\0'</code>, se ignora.
        /// Tampoco se agrega despues del ultimo elemento de la lista.</param>
        /// <returns>Una sola cadena conteniendo todos los elementos de la lista.</returns>
        public static string joinListByChar(List<string> Lines, char Delimiter)
        {
            string Result = "";

            int ALast = 0;
            string Line = "";

            StringBuilder sbLines = new StringBuilder();
            ALast = (Lines.Count - 1);
            for (int i = 0; i <= ALast; i++)
            {
                Line = Lines[i];
                sbLines.Append(Line);

                if ((i < ALast) && (Delimiter != '\0'))
                {
                    sbLines.Append(Delimiter);
                }
            } // for
            Result = sbLines.ToString();

            return Result;
        } // static string joinListByChar(...)

        public static string joinByListByStr(List<string> Lines, string Delimiter)
        {
            string Result = "";

            int ALast = 0;
            string Line = "";

            StringBuilder sbLines = new StringBuilder();
            ALast = (Lines.Count - 1);
            for (int i = 0; i <= ALast; i++)
            {
                Line = Lines[i];
                sbLines.Append(Line);

                if (i < ALast)
                {
                    sbLines.Append(Delimiter);
                }
            } // for
            Result = sbLines.ToString();

            return Result;
        } // static string joinByListByStr(...)

        public static string ListToString(List<string> AList)
        {
            string Result = "";

            StringBuilder sb = new StringBuilder();

            foreach (String EachItem in AList)
            {
                sb.Append(EachItem);
            } // foreach

            Result = sb.ToString();

            return Result;
        } // static string ListToString(...)

        /**
         * Se usa debido a un "bug" de <code>String.Split</code>,
         * despues se reemplazara.
         **/
        public static string[] SplitBySingleCharArray(String text, char Delimiter, bool IncludeDelimiter)
        {
            List<string> lista = new List<string>();

            int C = text.Length;

            String Buffer = "";
            for (int i = 0; i < C; i++)
            {
                char AChar =  text[i];
                if (AChar == Delimiter)
                {
                    // copiar cadena de var temporal
                    string Item = Buffer;

                    if (IncludeDelimiter)
                    {
                        Item += Delimiter;
                    }

                    // guardar copia en lista
                    lista.Add(Item);
                    // limpiar var temporal
                    Buffer = "";
                }
                else
                {
                    // agregar caracter a var temporal
                    Buffer += AChar;
                }
            } // for

            // --> agregar texto final, que no termina con delimitador
            if (Buffer != "")
            {
                // copiar cadena de var temporal
                string Item = Buffer;

                if (IncludeDelimiter)
                {
                    Item += Delimiter;
                }

                // guardar copia en lista
                lista.Add(Item);
                // limpar var temporal
                Buffer = "";
            }

            C = lista.Count;
            string[] Result = new string[C];

            for (int k = 0; k < C; k++)
            {
                Result[k] = lista[k];
            }

            return Result;
        } // string[] splitBySingleCharArray(...)

        /**
         * Se usa debido a un "bug" de <code>String.Split</code>,
         * despues se reemplazara.
         **/
        public static List<string> SplitBySingleCharList(String text, char Delimiter, bool IncludeDelimiter)
        {
            List<string> Result = new List<string>();

            int C = text.Length;

            String Buffer = "";
            for (int i = 0; i < C; i++)
            {
                char AChar = text[i];
                if (AChar == Delimiter)
                {
                    // copiar cadena de var temporal
                    string Item = Buffer;

                    if (IncludeDelimiter)
                    {
                        Item += Delimiter;
                    }

                    // guardar copia en lista
                    Result.Add(Item);
                    // limpiar var temporal
                    Buffer = "";
                }
                else
                {
                    // agregar caracter a var temporal
                    Buffer += AChar;
                }
            } // for

            // --> agregar texto final, que no termina con delimitador
            if (Buffer != "")
            {
                // copiar cadena de var temporal
                string Item = Buffer;

                if (IncludeDelimiter)
                {
                    Item += Delimiter;
                }

                // guardar copia en lista
                Result.Add(Item);
                // limpar var temporal
                Buffer = "";
            }

            return Result;
        } // List<string> splitBySingleCharList(...)

        /// <summary>
        /// Locates position to break the given line so as to avoid
        /// breaking words.
        /// </summary>
        /// <param name="text">String that contains line of text</param>
        /// <param name="pos">Index where line of text starts</param>
        /// <param name="max">Maximum line length</param>
        /// <returns>The modified line length</returns>
        public static int BreakLineIndex(string text, int pos, int max)
        {
            int Result = 0;

            // Find last whitespace in line
            int i = max - 1;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
            {
                i--;
            }

            if (i < 0)
            {
                Result = max;
                return Result; // No whitespace found; break at maximum length
            }

            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
            {
                i--;
            }

            // Return length of text before whitespace
            Result = i + 1;

            return Result;
        } // static int BreakLineIndex(...)

        public static string WordWrap(string the_string, int width, string _newline)
        {
            String Result = "";

            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if ( width < 1 )
            {
                Result = the_string;
                return Result;
            }

            // Parse each line of text
            for ( pos = 0; pos < the_string.Length; pos = next )
            {
                // Find end of line
                int eol = the_string.IndexOf( _newline, pos );

                if (eol == -1)
                {
                    next = eol = the_string.Length;
                }
                else
                {
                    next = eol + _newline.Length;
                }

                // Copy this line of text, breaking into smaller lines as needed
                if ( eol > pos )
                {
                    do {
                        int len = eol - pos;

                        if (len > width)
                        {
                            len = BreakLineIndex(the_string, pos, width);
                        }

                        sb.Append( the_string, pos, len );
                        sb.Append( _newline );

                        // Trim whitespace following break
                        pos += len;

                        while (pos < eol && Char.IsWhiteSpace(the_string[pos]))
                        {
                            pos++;
                        }

                    } while ( eol > pos );
                } else sb.Append( _newline ); // Empty line
            } // for

            Result = sb.ToString();

            return Result;
        } // static string WordWrap(...)

        /// <summary>
        /// Separa una cadena de texto, en varias lineas,
        /// tratando de que cada linea sea aproximadamente,
        /// de la longuitud indicada por <code>width</code>.
        /// Si el texto ya tiene saltos de linea, seran usados como separador.
        /// </summary>
        /// <param name="the_string">Cadena Fuente</param>
        /// <param name="width">Longuit maxima de cada linea</param>
        /// <returns>Arreglo de lineas.</returns>
        public static string[] WordWrapLines(string the_string, int width)
        {
            string[] Result = null;

            string StringWithBreaks = WordWrap(the_string, width, "\n");

            Result = SplitBySingleCharArray(StringWithBreaks, '\n', true);

            return Result;
        } // static string[] WordWrapLines(...)

        /// <summary>
        /// Regresa una copia de la cadena <code>source</code>,
        /// en donde se agrego el caracter <code>separator</code>,
        /// como separador, despues de una cantidad de caracteres,
        /// indicada por <code>count</code>.
        /// </summary>
        /// <param name="source">Cadena que se evaluara</param>
        /// <param name="separator">Cadena que se evaluara</param>
        /// <param name="count">Cantidad de caracteres entre separadores</param>
        /// <returns>Copia con separadores</returns>
        public static string AddCharSeparatorCountCopy(string source, char separator, int count)
        {
            string Result = "";

            int eachCount = 0;
            foreach (char c in source)
            {
                Result += c;

                eachCount++;

                if (eachCount == count)
                {
                    Result += separator;
                    eachCount = 0;
                }
            } // foreach

            return Result;
        } // static string AddCharSeparatorCountCopy(...)

        public static String[] ListToArray(List<String> Source)
        {
            int ACount = Source.Count;
            String[] Result = new String[ACount];

            for (int AIndex = 0; AIndex < ACount; AIndex++)
            {
                Result[AIndex] = Source[AIndex];
            } // for

            return Result;
        } // static String[] ListToArray(...)

        public static List<String> ArrayToList(String[] Source)
        {
            List<String> Result = new List<String>();
            int ACount = Source.Length;

            for (int AIndex = 0; AIndex < ACount; AIndex++)
            {
                Result.Add(Source[AIndex]);
            } // for

            return Result;
        } // static List<String> ArrayToList(...)

    } // static class StrUtils

} // namespace
