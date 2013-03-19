using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using romo.shared.utilities;

namespace romo.shared.utilities
{
    /// <summary>
    /// Clase para manejo de funciones para colores,
    /// en el formato Alpha (transparencia) + RGB.
    /// Se maneja como descendiente de <code>object</code>,
    /// a proposito, no como tipo primitivo o <code>struct</code>.
    /// Aunque tiene funciones estaticas, se puede instanciar.
    /// </summary>
    public class ARGB
    {
        protected byte _Alpha = 0;
        public byte Alpha
        {
            get { return _Alpha; }
            set { _Alpha = value; }
        }

        protected byte _Red = 0;
        public byte Red
        {
            get { return _Red; }
            set { _Red = value; }
        }

        protected byte _Blue = 0;
        public byte Blue
        {
            get { return _Blue; }
            set { _Blue = value; }
        }

        protected byte _Green = 0;
        public byte Green
        {
            get { return _Green; }
            set { _Green = value; }
        }

        #region "constructor"
        public ARGB()
        {
            // ...
        }

        public ARGB(String value)
        {
            ARGB temp = null;

            // warning: may generate cast exception (error)
            if (ARGB.tryStringToARGB(value, out temp))
            {
                this.Alpha = temp.Alpha;
                this.Red = temp.Red;
                this.Green = temp.Green;
                this.Blue = temp.Blue;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public ARGB(Int16 value)
        {
            ARGB tempARGB = null;

            String tempStr = romo.shared.utilities.Hexadecimal.IntToHex(value);
            if (tryStringToARGB(tempStr, out tempARGB))
            {
                this.Alpha = tempARGB.Alpha;
                this.Red = tempARGB.Red;
                this.Green = tempARGB.Green;
                this.Blue = tempARGB.Blue;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public ARGB(Color value)
        {
            if (value == null)
            {
                throw new InvalidCastException();
            }
            else
            {
                this.Alpha = value.A;
                this.Red = value.R;
                this.Blue = value.B;
                this.Green = value.G;
            }
        }
        #endregion "constructor"

        public override string ToString()
        {
            string Result;

            String A = romo.shared.utilities.Hexadecimal.IntToHex((short)Alpha);
            String R = romo.shared.utilities.Hexadecimal.IntToHex((short)Red);
            String B = romo.shared.utilities.Hexadecimal.IntToHex((short)Blue);
            String G = romo.shared.utilities.Hexadecimal.IntToHex((short)Green);

            StringBuilder ARGB = new StringBuilder();
            ARGB.Append(A);
            ARGB.Append(R);
            ARGB.Append(B);
            ARGB.Append(G);
            Result = ARGB.ToString();

            return Result;
        } // override string ToString(...)

        /// <summary>
        /// Tries to convert the current value into a
        /// string hexadecimal value.
        /// Does not generates an exception, if operation fails.
        /// </summary>
        /// <param name="destination">String hexadecimal equivalent, if operation succed,
        /// empty string, if operation succeed.</param>
        /// <returns>Could operation been performed</returns>
        public bool tryConvertToString(out String destination)
        {
            bool Result = true;

            destination = this.ToString();

            return Result;
        }

        /// <summary>
        /// Tries to convert the current value into an integer.
        /// Does not generates an exception, if operation fails.
        /// </summary>
        /// <param name="destination">Integer value equivalent, if operation succed,
        /// empty string, if operation succeed.</param>
        /// <returns>Could operation been performed</returns>
        public bool tryConvertToInt(out Int16 destination)
        {
            bool Result = false;
            destination = 0;

            String tempHex = this.ToString();
            destination = (Int16)romo.shared.utilities.Hexadecimal.HexToInt(tempHex);

            return Result;
        }

        /// <summary>
        /// Tries to convert the current value into a <code>Color</code> object.
        /// Does not generates an exception, if operation fails.
        /// </summary>
        /// <param name="destination"><code>Color</code> object equivalent, if operation succed,
        /// empty string, if operation succeed.</param>
        /// <returns>Could operation been performed</returns>
        public bool tryConvertToColor(out Color destination)
        {
            bool Result = true;
            destination = Color.Black;

            // --> "Color" class already has a method for it
            destination = Color.FromArgb(
                (int)this.Alpha,
                (int)this.Red,
                (int)this.Blue,
                (int)this.Green
            );

            return Result;
        }

        /// <summary>
        /// Tries to convert the current value into a
        /// string hexadecimal value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="destination">String hexadecimal equivalent, if operation succed,
        /// empty string, if operation succeed.</param>
        /// <returns>Equivalent String Hexadecimal value</returns>
        public String convertToString()
        {
            String Result = "";

            if (!tryConvertToString(out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the current value into an equivalent integer value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <returns>Equivalent integer value</returns>
        public Int16 convertToInt()
        {
            Int16 Result = 0;

            if (!tryConvertToInt(out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the current value into an equivalent <code>Color</code> value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <returns>Equivalent <code>Color</code> value</returns>
        public Color convertToColor()
        {
            Color Result = Color.Black;

            if (!tryConvertToColor(out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given parameter value into a
        /// string hexadecimal value.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source">ARGB instance</param>
        /// <param name="destination">String result</param>
        /// <returns>Could operation been performed</returns>
        public static bool tryARGBToString(ARGB source, out String destination)
        {
            bool Result = false;
            destination = "";

            // first, check we didn't get a null value
            Result = (source != null);
            if (source != null)
            {
                destination = source.ToString();
            }

            return Result;
        }

        /// <summary>
        /// Return if a string is a valid ARGB format.
        /// </summary>
        /// <param name="source">An ARGB value as an hexadecimal string.</param>
        /// <returns>Result of validation.</returns>
        public static bool isValidString(String value)
        {
            bool Result = false;

            if (romo.shared.utilities.Hexadecimal.IsHexString(value))
            {
                Result = (value.Length == 8);
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given string value into the given <code>ARGB</code> parameter.
        /// The string is expected tobe an hexadecimal equivalent value.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source">String value</param>
        /// <param name="destination"></param>
        /// <returns>Could operation been performed.</returns>
        public static bool tryStringToARGB(String source, out ARGB destination)
        {
            bool Result = false;
            destination = null;

            // first, check we didn't get a null value
            Result = (isValidString(source));
            if (Result)
            {
                destination = new ARGB();
                destination.Alpha = Convert.ToByte(StrUtils.LeftCopyByLength(source, 2), 16);
                destination.Red = Convert.ToByte(StrUtils.MidCopy(source, 2, 2), 16);
                destination.Blue = Convert.ToByte(StrUtils.MidCopy(source, 4, 2), 16);
                destination.Green = Convert.ToByte(StrUtils.RightCopyByLength(source, 2), 16);
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>ARGB</code> parameter into an integer.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source"><code>ARGB</code> instance</param>
        /// <param name="destination"></param>
        /// <returns>Could operation been performed.</returns>
        public static bool tryARGBToInt(ARGB source, out Int16 destination)
        {
            bool Result = false;
            destination = 0;

            String temp = "";
            Result = tryARGBToString(source, out temp);
            if (!String.IsNullOrEmpty(temp))
            {
                destination = (Int16)romo.shared.utilities.Hexadecimal.HexToInt(temp);
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>ARGB</code> parameter, into a <code>Color</code> instance.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"><code>Color</code> instance</param>
        /// <returns>Could operation been performed.</returns>
        public static bool tryARGBToColor(ARGB source, out Color destination)
        {
            bool Result = false;
            destination = Color.Black;

            Result = (source != null);
            if (Result)
            {
                destination = Color.FromArgb(
                    (int)source.Alpha,
                    (int)source.Red,
                    (int)source.Blue,
                    (int)source.Green
                );
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given integer parameter, into a <code>ARGB</code> instance.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source">Integer value</param>
        /// <param name="destination"><code>ARGB</code> instance</param>
        /// <returns>Could operation been performed.</returns>
        public static bool tryIntToARGB(Int16 source, out ARGB destination)
        {
            bool Result = false;
            destination = null;

            String temp = romo.shared.utilities.Hexadecimal.IntToHex(source);
            Result = tryStringToARGB(temp, out destination);

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>source</code> parameter, into a <code>ARGB</code> instance.
        /// Does not generates an exception, if operation fails.
        /// Note: This is a <code>static</code> function.
        /// </summary>
        /// <param name="source"><code>Color</code> instance</param>
        /// <param name="destination"><code>ARGB</code> instance</param>
        /// <returns>Could operation been performed.</returns>
        public static bool tryColorToARGB(Color source, out ARGB destination)
        {
            bool Result = false;
            destination = null;

            Result = (source != null);
            if (Result)
            {
                destination = new ARGB(source);
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given parameter value into a
        /// string hexadecimal value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value"><code>ARGB</code> instance</param>
        /// <returns>String Hexadecimal equivalent.</returns>
        public static String ARGBToString(ARGB value)
        {
            String Result = "";

            if (!tryARGBToString(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given string value into the given <code>ARGB</code> parameter.
        /// The string is expected to be an hexadecimal equivalent value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value">String Hexadecimal equivalent</param>
        /// <returns><code>ARGB</code> equivalent</returns>
        public static ARGB StringToARGB(String value)
        {
            ARGB Result = null;

            if (!tryStringToARGB(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>ARGB</code> parameter value into an integer equivalent.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value"><code>ARGB</code> instance</param>
        /// <returns>Integer equivalent</returns>
        public static Int16 ARGBToInt(ARGB value)
        {
            Int16 Result = 0;

            if (!tryARGBToInt(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>ARGB</code> parameter value into a
        /// <code>Color</code> equivalent value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value"><code>ARGB</code> intasnce.</param>
        /// <returns><code>Color</code> equivalent.</returns>
        public static Color ARGBToColor(ARGB value)
        {
            Color Result = Color.Black;

            if (!tryARGBToColor(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given integer parameter value into a
        /// <code>ARGB</code> equivalent value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value">Integer equivalent value.</param>
        /// <returns><code>ARGB</code> equivalent.</returns>
        public static ARGB IntToARGB(Int16 value)
        {
            ARGB Result = null;

            if (!tryIntToARGB(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Tries to convert the given <code>Color</code> parameter value into a
        /// <code>ARGB</code> equivalent value.
        /// If operation fails, a <code>InvalidCastException</code> exception is generated.
        /// </summary>
        /// <param name="value"><code>Color</code> equivalent value.</param>
        /// <returns><code>ARGB</code> equivalent.</returns>
        public static ARGB ColorToARGB(Color value)
        {
            ARGB Result = null;

            if (!tryColorToARGB(value, out Result))
            {
                throw new InvalidCastException();
            }

            return Result;
        }

        /// <summary>
        /// Recibe un valor tipo <code>Color</code>,
        /// y regresa el equivalente alfanumerico (8 caracteres formato hexadecimal: "AARRGGBB"),
        /// se utiliza para guardar en B.D.
        /// </summary>
        /// <param name="value">Estructura ARGB</param>
        /// <returns>Equivalente Alfanumerico</returns>
        public static String ColorToString(Color value)
        {
            String Result = "00000000";

            // ...

            return Result;
        } // static Color ColorToString(...)

        /// <summary>
        /// Recibe un valor tipo alfanumerico,
        /// y lo convierte a una estructura ARGB,
        /// se utiliza para leer un valor, previamente almacenado, en una B.D.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color StringToColor(String value)
        {
            Color Result = Color.Black;

            // nos aseguramos que la cadena siga el formato hexadecimal "AARRGGBB"

            if (!String.IsNullOrEmpty(value)) {
                // --> cuando la cadena no es nula o vacia:
                if (value.Length == 8) {
                    // --> cuando la cadena son exactamente los 8 caracteres

                    if (romo.shared.utilities.Hexadecimal.IsHexString(value))
                    {
                        int N = romo.shared.utilities.Hexadecimal.HexToInt(value);

                        Result = Color.FromArgb(N);
                    }
                }
            }

            return Result;
        } // static Color StringToColor(...)
    } // class ARGB

    // ...

} // namespace
