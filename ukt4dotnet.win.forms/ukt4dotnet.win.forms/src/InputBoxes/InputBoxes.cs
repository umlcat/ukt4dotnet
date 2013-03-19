using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using romo.shared.utilities;
using romo.shared.utilities.Interfaces;
using romo.windows.forms;

namespace romo.windows.forms.InputBoxes
{
    /// <summary>
    /// Clase generica para capturar un valor alfanumerico corto,
    /// en una sola linea, usese de forma similar a <code>MessageBox</code>
    /// </summary>
    public partial class InputBox : Form
    {
        #region "properties"
            private string _Data = "";
            public string Data
            {
                get { return _Data; }
                set { _Data = value; }
            }

            private int _MaxLength = 1000;
            /// <summary>
            /// Limite de caracteres a capturar
            /// </summary>
            public int MaxLength
            {
                get { return _MaxLength; }
                set { _MaxLength = value; }
            }
        #endregion "properties"

        #region "constructor"
            public InputBox()
            {
                InitializeComponent();

                Bitmap resourceImage = null;

                resourceImage = romo.windows.forms.Properties.Resources.ok;
                romo.windows.forms.Resources.AssignButtonBackgroundImage
                    (ref this.OKExitButton, resourceImage, true);

                resourceImage = romo.windows.forms.Properties.Resources.cancel;
                romo.windows.forms.Resources.AssignButtonBackgroundImage
                    (ref this.CancelExitButton, resourceImage, true);

                Bitmap ANewImage = null;
                if (romo.windows.forms.Configuration.CustomizeImages)
                {
                    ANewImage = romo.windows.forms.Configuration.getImage(System.Windows.Forms.DialogResult.OK);
                    romo.windows.forms.Resources.AssignButtonBackgroundImage(ref OKExitButton, ANewImage, true);

                    ANewImage = romo.windows.forms.Configuration.getImage(System.Windows.Forms.DialogResult.Cancel);
                    romo.windows.forms.Resources.AssignButtonBackgroundImage(ref CancelExitButton, ANewImage, true);
                } // if (romo.windows.forms.Configuration.CustomizeImages)
            }
        #endregion "constructor"

        private void OKExitButton_Click(object sender, EventArgs e)
        {
            this.Data = this.DataTextBox.Text;
        }

        private void CancelExitButton_Click(object sender, EventArgs e)
        {
            this.Data = "";
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            // pasar propiedad publica a valor control
            DataTextBox.Text = Convert.ToString(this.Data);

            this.DataTextBox.MaxLength = this.MaxLength;
        } // void InputBox_Shown(...)

        private void InputBox_Activated(object sender, EventArgs e)
        {
            DataTextBox.Focus();
        } // void InputBox_Activated(...)

        /// <summary>
        /// Despliega una caja de dialogo, para capturar un valor alfanumerico
        /// </summary>
        /// <param name="Title">Titulo de la caja de dialogo</param>
        /// <param name="Label">Etiqueta para el titulo del valor</param>
        /// <param name="Data">valor inicial y valor final que se capturara</param>
        /// <param name="Len">Longuitud maxima permitida para el valor capturado</param>
        /// <returns>Indica si el usuario confirma la captura del valor</returns>
        /// public static bool Show(string Title, string Label, ref string Data, int Len = 1000)
        public static bool ShowLen(string Title, string Label, ref string Data, int Len)
        {
            bool Result = false;

            // --> ejecutar forma auxiliar
            InputBox thisForm = new InputBox();
                thisForm.Text = Title;
                thisForm.DataLabel.Text = Label + ":";
                thisForm.Data = Data;
                thisForm.MaxLength = Len;

            Result = (thisForm.ShowDialog() == DialogResult.OK);

            // --> obtener que modo se selecciono al ejecutar forma
            if (Result)
            {
                Data = thisForm.Data;
            }
            else
            {
                Data = "";
            }

            return Result;
        } // static bool ShowLen(...)

        public static bool Show(string Title, string Label, ref string Data)
        {
            bool Result = ShowLen(Title, Label, ref Data, 1000);

            return Result;
        } // static bool Show(...)

    } // public class InputBox
} // namespace
