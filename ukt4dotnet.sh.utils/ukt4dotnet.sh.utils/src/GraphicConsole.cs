using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using romo.shared.utilities;

namespace romo.shared.utilities
{
    /// <summary>
    /// Es una clase para emular una consola,
    /// en un grafico.
    /// </summary>
    public class GraphicConsole: Console
    {
        #region "properties"
            protected Font _Font;
            /// <summary>
            /// Text font used for writing text.
            /// </summary>
            protected Font Font
            {
                get { return _Font; }
                set { _Font = value; }
            }

            private bool _IsCleared;
            /// <summary>
            /// Se utiliza para evitar imprimir un divisor,
            /// o salto de pagina, la primera vez.
            /// </summary>
            protected bool IsCleared
            {
                get { return _IsCleared; }
                set { _IsCleared = value; }
            }

            protected String _FontName;
            /// <summary>
            /// Indica el tipo-fuente que se utilizara, por default, en la consola.
            /// </summary>
            public String FontName
            {
                get { return _FontName; }
                set { setFontName(value); }
            }

            protected int _FontSize;
            /// <summary>
            /// Indica el tamaño del tipo-fuente que se utilizara,
            /// por default, en la consola.
            /// </summary>
            public int FontSize
            {
                get { return _FontSize; }
                set { setFontSize(value); }
            }

            protected FontStyle _FontStyle;
            public FontStyle FontStyle
            {
                get { return _FontStyle; }
                set { setFontStyle(value); }
            }

            protected int _CharWidth;
            /// <summary>
            /// Size of the width of each character.
            /// Used for <code>WriteTab()</code> y <code>WriteTabLine()</code>, primarily,
            /// even if a non-monospaced (variable) font is used.
            /// </summary>
            public int CharWidth
            {
                get { return _CharWidth; }
                set { _CharWidth = value; }
            }

            protected int _LineHeight;
            /// <summary>
            /// Size of the height of the lines.
            /// Used for <code>WriteLineBreak()</code>, primarily.
            /// </summary>
            public int LineHeight
            {
                get { return _LineHeight; }
                set { _LineHeight = value; }
            }

            protected Graphics _Graphics;
            protected Graphics Graphics
            {
                get { return _Graphics; }
                set { _Graphics = value; }
            }

            private Char _CharMarker;
            /// <summary>
            /// Caracter utilizado como espacio en blanco,
            /// se puede cambiar por cualquier otro caracter,
            /// para fines  de depuracion, aunque por-de-facto,
            /// se utilizar espacio en blanco.
            /// </summary>
            public Char CharMarker
            {
                get { return _CharMarker; }
                set { _CharMarker = value; }
            }

            protected Char _RulerMarker;
            /// <summary>
            /// Caracter utilizado para desplegar una linea como divisor horizontal.
            /// </summary>
            public Char RulerMarker
            {
                get { return _RulerMarker; }
                set { _RulerMarker = value; }
            }

            protected Char _PageMarker;
            /// <summary>
            /// Caracter utilizado para simular un salto de pagina.
            /// </summary>
            public Char PageMarker
            {
                get { return _PageMarker; }
                set { _PageMarker = value; }
            }

            protected int _LeftMargin;
            public int LeftMargin
            {
                get { return _LeftMargin; }
                set { _LeftMargin = value; }
            }

            protected int _TopMargin;
            public int TopMargin
            {
                get { return _TopMargin; }
                set { _TopMargin = value; }
            }

            protected StringBuilder _LineBuffer;
            public StringBuilder LineBuffer
            {
                get { return _LineBuffer; }
                set { _LineBuffer = value; }
            }
        #endregion "properties"

        public static string DefaultFontName = "Arial Narrow";
        public static int DefaultFontSize = 8;
        public static int DefaultLineHeight = 10;
        public static int DefaultCharWidth = 7;
        public static char DefaultBlankMarker = ' ';
        public static char DefaultRulerMarker = '=';
        public static char DefaultPageMarker = 'X';

        #region "constructor"
            public GraphicConsole(Graphics paramGraphics) :
                base()
            {
                this._IsCleared = true;

                this._FontName  = DefaultFontName;
                this._FontSize  = DefaultFontSize;
                this._FontStyle = FontStyle.Regular;
                this._Font = new Font(this._FontName, this._FontSize, this._FontStyle);

                // nota: el alto de linea es diferente y mayor al alto del tipo-fuente,
                // para que los caracteres no se sobrepongan
                this._LineHeight = DefaultLineHeight;
                this._CharWidth = DefaultCharWidth;

                this._Graphics = paramGraphics;
                this._PageMarker = DefaultPageMarker;
                this._RulerMarker = DefaultRulerMarker;
                this._CharMarker = DefaultBlankMarker;

                this._TopMargin  = 0;
                this._LeftMargin = 0;

                this._IsMonospaced = false;
                this._IsMonostyled = false;

                this._LineBuffer =
                    new StringBuilder(new String(this._CharMarker, this._Size.Width));
            }

            public GraphicConsole(Graphics paramGraphics, Size paramSize):
                base(paramSize)
            {
                this._IsCleared = true;

                this._FontName  = DefaultFontName;
                this._FontSize  = DefaultFontSize;
                this._FontStyle = FontStyle.Regular;
                this._Font = new Font(this._FontName, this._FontSize, this._FontStyle);

                // nota: el alto de linea es diferente y mayor al alto del tipo-fuente,
                // para que los caracteres no se sobrepongan
                this._LineHeight = DefaultLineHeight;
                this._CharWidth = DefaultCharWidth;

                this._Graphics = paramGraphics;
                this._PageMarker = DefaultPageMarker;
                this._RulerMarker = DefaultRulerMarker;

                this._TopMargin  = 0;
                this._LeftMargin = 0;

                this._IsMonospaced = false;
                this._IsMonostyled = false;

                this._LineBuffer =
                    new StringBuilder(new String(this.CharMarker, this._Size.Width));
            }
        #endregion "constructor"

        #region "additional-setters"
            protected virtual void rebuiltFont()
            {
                this._Font = new Font(this._FontName, this._FontSize, this._FontStyle);
            }

            protected virtual void setFontName(String value)
            {
                this._FontName = value;
                rebuiltFont();
            }

            protected virtual void setFontSize(int value)
            {
                this._FontSize = value;
                rebuiltFont();
            }

            protected virtual void setFontStyle(FontStyle value)
            {
                this._FontStyle = value;
                rebuiltFont();
            }
        #endregion "additional-setters"

        protected void rebuiltLineBuffer()
        {
            this._LineBuffer =
                new StringBuilder(new String(this.CharMarker, this._Size.Width));
        }

        public override void MoveToHome()
        {
           this._Location = new Point(0, 0);
        }

        protected virtual void displayLineBuffer()
        {
            // convertir coordenadas caracteres a coordenadas puntos
            /*
            int DeltaX = (this.LeftMargin + (this.Location.X * this.CharWidth));
            int DeltaY = (this.TopMargin + (this.Location.Y * this.LineHeight));
            */

            int DeltaX = this.LeftMargin;
            int DeltaY = (this.TopMargin + (this.Location.Y * this.LineHeight));

            String Line = LineBuffer.ToString();

            // ahora si, desplegar texto
            this.Graphics.DrawString(
                Line, this.Font, this.Forecolor,
                DeltaX, DeltaY);
        }

        public override void WriteLineMarker(int ACount)
        {
            for (int i = 1; i <= ACount; i++)
            {
                displayLineBuffer();

                ResetLine(1);

                rebuiltLineBuffer();
            }

            // salto-linea libera buffer
            this.IsBufferWaiting = false;
        } // override void WriteLineMarker(...)

        public override void WritePageMarker()
        {
            if (this.IsBufferWaiting)
            {
                WriteLineMarker(1);
            }

            int AWidth = (this.Size.Width - 1);
            String Msg = new String(this.PageMarker, AWidth);

            // respaldar estilo
            FontStyle backupStyle = this.FontStyle;

            // desplegar marcador salto-pagina en negritas
            this.FontStyle = System.Drawing.FontStyle.Bold;
            Write(Msg);

            //restaurar estilo
            this.FontStyle = backupStyle;

            displayLineBuffer();
            rebuiltLineBuffer();

            ResetPage();

            // salto-pagina libera buffer
            this.IsBufferWaiting = false;
        } // void WritePageMarker(...)

        public override void WriteRulerMarker(char ParamRulerChar)
        {
            if (this.IsBufferWaiting)
            {
                WriteLineMarker(1);
            }

            int AWidth = (this.Size.Width - 1);


            Char thisRulerChar = (ParamRulerChar == '\0') ? this.RulerMarker : ParamRulerChar;
            String Msg = new String(thisRulerChar, AWidth);

            // respaldar estilo
            FontStyle backupStyle = this.FontStyle;

            // desplegar marcador salto-pagina en negritas
            this.FontStyle = System.Drawing.FontStyle.Bold;
            Write(Msg);

            //restaurar estilo
            this.FontStyle = backupStyle;

            displayLineBuffer();
            rebuiltLineBuffer();

            ResetLine(1);

            // divisor-horizontal libera buffer
            this.IsBufferWaiting = false;
        } // void WriteRulerMarker(...)

        public override void Clear()
        {
            this.Graphics.Clear(this.Backcolor);
            MoveToHome();

            if (this.IsCleared)
            {
                this._IsCleared = false;
            }

            // limpiar indicador para texto pendiente
            this.IsBufferWaiting = false;
        } // void Clear(...)

        /// <summary>
        /// Despliega alineando de derecha a izquierda,
        /// un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public override void WriteRight(Object text)
        {
            if (text != null)
            {
                String Line = text.ToString();
                if (Line != "")
                {
                    foreach (char thisChar in Line)
                    {
                        // reemplazar caracter
                        _LineBuffer[_Location.X] = thisChar;
                        // mover el cursor
                        _Location.X = (_Location.X + 1);
                    }

                    // indicar buffer tiene texto pendiente
                    this.IsBufferWaiting = true;
                } // if (Line != "")
            } // if (text != null)
        } // void WriteRight(...)

        /// <summary>
        /// Despliega alineando de izquierda a derecha,
        /// un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public override void WriteLeft(Object text)
        {
            if (text != null)
            {
                String Line = text.ToString();
                if (Line != "")
                {
                    // como se escribe hacia atras, se evita pasarse
                    int AvailableLength = System.Math.Min((Location.X + 1), Line.Length);

                    // recortar cadena
                    Line = StrUtils.LeftCopyByLength(Line, AvailableLength);

                    // iniciar despliege en columna respectiva
                    int thisX = (_Location.X - AvailableLength);
                    foreach (char thisChar in Line)
                    {
                        // reemplazar caracter
                        _LineBuffer[thisX] = thisChar;
                        // mover el cursor
                        thisX = (thisX + 1);
                    }

                    _Location.X = thisX;

                    // indicar buffer tiene texto pendiente
                    this.IsBufferWaiting = true;
                } // if (Line != "")
            } // if (text != null)
        } // void WriteLeft(...)

        /// <summary>
        /// Despliega un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public override void Write(Object text)
        {
            this.WriteRight(text);
        } // void Write(...)

    } // class
} // namespace
