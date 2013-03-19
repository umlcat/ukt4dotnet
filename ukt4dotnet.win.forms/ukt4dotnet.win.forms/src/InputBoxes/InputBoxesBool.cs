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
    /// Clase generica para capturar un valor alfanumerica,
    /// usese de forma similar a <code>MessageBox</code>
    /// </summary>
    public partial class InputBoxBool : Form
    {
        #region "properties"
            private bool _Data = false;
            public bool Data
            {
                get { return _Data; }
                set { _Data = value; }
            }
        #endregion "properties"

        #region "constructor"
            public InputBoxBool()
            {
                InitializeComponent();

                Bitmap resourceImage = null;

                resourceImage = romo.windows.forms.Properties.Resources.ok;
                romo.windows.forms.Resources.AssignButtonBackgroundImage
                    (ref this.btnOK, resourceImage, true);

                resourceImage = romo.windows.forms.Properties.Resources.cancel;
                romo.windows.forms.Resources.AssignButtonBackgroundImage
                    (ref this.btnCancel, resourceImage, true);

                Bitmap ANewImage = null;
                if (romo.windows.forms.Configuration.CustomizeImages)
                {
                    ANewImage = romo.windows.forms.Configuration.getImage(System.Windows.Forms.DialogResult.OK);
                    romo.windows.forms.Resources.AssignButtonBackgroundImage(ref btnOK, ANewImage, true);

                    ANewImage = romo.windows.forms.Configuration.getImage(System.Windows.Forms.DialogResult.Cancel);
                    romo.windows.forms.Resources.AssignButtonBackgroundImage(ref btnCancel, ANewImage, true);
                } // if (romo.windows.forms.Configuration.CustomizeImages)
            }
        #endregion "constructor"

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Data = (rdbtnTrue.Checked);
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            // pasar propiedad publica a valor control
            if (this.Data)
            {
                rdbtnTrue.Checked = true;
            }
            else
            {
                rdbtnFalse.Checked = true;
            }
        }

        private void InputBox_Activated(object sender, EventArgs e)
        {
            DataGroupBox.Focus();
        }

        /// <summary>
        /// Cambia el estatus de una mesa directamente, sin resultado operaciones secundarias.
        /// Nota: Este metodo ejecuta la forma regresando como parametros,
        /// algunas propiedades significas de la forma.
        /// Considerese este metodo estatico como funcion global del "namespace",
        /// no como un metodo de esta clase.
        /// </summary>
        /// <returns>Cuando hubo cambio de estatus de la mesa indicada.</returns>
        public static bool Show(string Title, string Label, ref bool Data)
        {
            bool Result = false;

            // --> ejecutar forma auxiliar
            InputBoxBool thisForm = new InputBoxBool();
                thisForm.Text = Title;
                thisForm.DataGroupBox.Text = Label;
                thisForm.Data = Data;

            Result = (thisForm.ShowDialog() == DialogResult.OK);

            // --> obtener que modo se selecciono al ejecutar forma
            if (Result)
            {
                Data = thisForm.Data;
            }
            else
            {
                Data = false;
            }

            return Result;
        } // static bool Show(...)

    } // class
} // namespace
