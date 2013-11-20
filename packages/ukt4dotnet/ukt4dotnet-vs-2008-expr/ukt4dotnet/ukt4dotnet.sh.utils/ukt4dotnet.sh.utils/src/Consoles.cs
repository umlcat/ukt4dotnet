using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ukt4dotnet.shared.utilities.Interfaces;

namespace ukt4dotnet.shared.utilities
{
    /// <summary>
    /// Es una clase generica y virtual para emular una consola.
    /// Se trata a la consola como un dispositivo de salida,
    /// similar a una impresora.
    /// Nota: Por default, <code>Console</code> es solo-escritura.
    /// </summary>
    public abstract class Console : IDoNothing
    {
        #region "properties"
            protected Size _Size;
            /// <summary>
            ///  Ancho y Largo visible, en caracteres, de la consola.
            /// </summary>
            public Size Size
            {
                get { return _Size; }
                set { _Size = value; }
            }

            protected Point _Location;
            /// <summary>
            /// Coordenadas, en caracteres, del "cursor".
            /// </summary>
            public Point Location
            {
                get { return _Location; }
                set { _Location = value; }
            }

            protected int _PageCount;
            /// <summary>
            /// Cantidad de "paginas" generadas.
            /// </summary>
            public int PageCount
            {
                get { return _PageCount; }
                set { _PageCount = value; }
            }

            protected Color _Backcolor;
            public Color Backcolor
            {
                get { return _Backcolor; }
                set { _Backcolor = value; }
            }

            protected Brush _Forecolor;
            public Brush Forecolor
            {
                get { return _Forecolor; }
                set { _Forecolor = value; }
            }

            protected bool _IsBW;
            /// <summary>
            /// Indica si la consola es B. y N. o a color.
            /// </summary>
            public bool IsBW
            {
                get { return _IsBW; }
                set { _IsBW = value; }
            }

            protected bool _IsMonospaced;
            /// <summary>
            /// Indica si la consola utiliza caracteres del mismo ancho y largo.
            /// </summary>
            public bool IsMonospaced
            {
                get { return _IsMonospaced; }
                set { _IsMonospaced = value; }
            }

            protected bool _IsMonostyled;
            /// <summary>
            /// Indica si la consola utiliza el mismo estilo para todos los caracteres.
            /// </summary>
            public bool IsMonostyled
            {
                get { return _IsMonostyled; }
                set { _IsMonostyled = value; }
            }

            private bool _IsBufferWaiting;
            /// <summary>
            /// Indica cuando se tiene que escribir,
            /// el contenido del buffer, con un salto-linea.
            /// </summary>
            public bool IsBufferWaiting
            {
                get { return _IsBufferWaiting; }
                set { _IsBufferWaiting = value; }
            }
        #endregion "properties"

        #region "constructor"
            public Console()
            {
                this._Location  = new Point(0, 0);
                this._PageCount = 0;
                this._IsBW = true;
                this._Backcolor = Color.White;
                this._Forecolor = Brushes.Black;
                this._IsMonospaced = true;
                this._IsMonostyled = true;
            }

            public Console(Size paramSize)
            {
                this._Size = paramSize;
                this._Location = new Point(0, 0);
                this._PageCount = 0;
                this._IsBW = true;
                this._Backcolor = Color.White;
                this._Forecolor = Brushes.Black;
                this._IsMonospaced = true;
                this._IsMonostyled = true;

                this._IsBufferWaiting = false;
            }
        #endregion "constructor"

        /// <summary>
        /// Se utiliza que los controles tengan una operacion "nula",
        /// que no sea el valor <code>null</code>.
        /// Aunque no se hace nada, la sintaxis ayuda a depurar codigo.
        /// </summary>
        public void DoNothing()
        {
            // Does NOTHING on purpouse !!!
        } // void DoNothing()

        public virtual void MoveToHome()
        {
            _Location = new Point(0, 0);
        }

        public virtual void MoveTo(int newColumn, int newRow)
        {
            _Location = new Point(newColumn, newRow);
        }

        public virtual void MoveToTab(int newColumn)
        {
            _Location.X = newColumn;
        }

        public virtual void Clear()
        {
            MoveToHome();

            // limpiar indicador para texto pendiente
            this.IsBufferWaiting = false;
        }

        /// <summary>
        /// Despliega alineando de izquierda a derecha,
        /// un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public virtual void WriteLeft(Object text)
        {
            // indicar buffer tiene texto pendiente
            this.IsBufferWaiting = true;
        }
        
        /// <summary>
        /// Despliega alineando de derecha a izquierda,
        /// un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public virtual void WriteRight(Object text)
        {
            // indicar buffer tiene texto pendiente
            this.IsBufferWaiting = true;
        }

        /// <summary>
        /// Despliega un texto, comenzando en la columna actual.
        /// </summary>
        /// <param name="text">Mensaje a imprimir.</param>
        public virtual void Write(Object text)
        {
            // indicar buffer tiene texto pendiente
            this.IsBufferWaiting = true;
        }

        /// <summary>
        /// Despliega alineando de izquierda a derecha,
        /// un texto, comenzando en la columna especificada.
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="text"></param>
        public virtual void WriteTab(int newColumn, Object text)
        {
            MoveToTab(newColumn);
            Write(text);

            // indicar buffer tiene texto pendiente
            this.IsBufferWaiting = true;
        }

        /// <summary>
        /// Despliega alineando de izquierda a derecha,
        /// un texto, comenzando en la columna especificada.
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="text"></param>
        public virtual void WriteTabRight(int newColumn, Object text)
        {
            MoveToTab(newColumn);
            WriteRight(text);

            // indicar buffer tiene texto pendiente
            this.IsBufferWaiting = true;
        }

        /// <summary>
        /// Despliega alineando de derecha a izquierda,
        /// un texto, comenzando en la columna especificada.
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="text"></param>
        public virtual void WriteTabLeft(int newColumn, Object text)
        {
            MoveToTab(newColumn);
            WriteLeft(text);
        }

        protected void ResetLine(int ACount)
        {
            this._Location.X = 0;
            this._Location.Y += 1;
        }

        protected void ResetPage()
        {
            this._Location.X = 0;
            this._Location.Y += 1;
            this._PageCount += 1;
        }

        public virtual void WriteLineMarker(int ACount)
        {
            // desplegar linebuffer

            ResetLine(ACount);

            // salto-linea libera buffer
            this.IsBufferWaiting = false;
        }

        public virtual void WritePageMarker()
        {
            // desplegar linebuffer

            if (this.IsBufferWaiting)
            {
                WriteLineMarker(1);
            }

            ResetPage();
        }

        public virtual void WriteRulerMarker(char ParamRulerChar)
        {
            // desplegar linebuffer

            if (this.IsBufferWaiting)
            {
                WriteLineMarker(1);
            }

            ResetLine(1);
        }

        /// <summary>
        /// Despliega una cadena de texto, seguida por un salto-linea.
        /// </summary>
        /// <param name="text"></param>
        public virtual void WriteLine(Object text)
        {
            Write(text);
            WriteLineMarker(1);
        }

        /// <summary>
        /// Despliega una cadena de texto, seguida por un salto-pagina.
        /// </summary>
        /// <param name="text"></param>
        public virtual void WritePage(Object text)
        {
            Write(text);
            WritePageMarker();
        }

        public virtual void WriteTabLine(int newColumn, Object text)
        {
            MoveToTab(newColumn);
            Write(text);
            WriteLineMarker(1);
        }
    } // class

} // namespace
