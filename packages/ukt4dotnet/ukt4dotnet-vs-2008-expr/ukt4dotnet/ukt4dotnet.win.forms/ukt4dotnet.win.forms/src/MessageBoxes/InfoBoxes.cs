using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ukt4dotnet.shared.utilities;
using ukt4dotnet.shared.utilities.Interfaces;

namespace ukt4dotnet.win.forms.MessageBoxes
{
    /// <summary>
    /// Clase generica para capturar un valor alfanumerico extenso,
    /// en varias lineas, usese de forma similar a <code>MessageBox</code>.
    /// </summary>
    public partial class InfoBox : Form
    {
        #region "properties"
        private String[] _Lines;
        public String[] Lines
        {
            get { return _Lines; }
            set { _Lines = value; }
        }
        #endregion "properties"

        #region "constructor"
        public InfoBox()
        {
            InitializeComponent();
        }
        #endregion "constructor"

        private void InfoBox_Shown(object sender, EventArgs e)
        {
            // --> pasar propiedad publica a valor control
            DataTextBox.Lines = this.Lines;
        } // void InfoBox_Shown(...)

        private void ExitCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ...

        // ...

        /// <summary>
        /// Clase generica para capturar un valor alfanumerico extenso,
        /// en varias lineas, usese de forma similar a <code>MessageBox</code>.
        /// Nota: Este metodo ejecuta la forma regresando como parametros,
        /// algunas propiedades significas de la forma.
        /// Considerese este metodo estatico como funcion global del "namespace",
        /// no como un metodo de esta clase.
        /// </summary>
        /// <param name="Msg">Texto del mensaje, puede tener saltos de linea.</param>
        /// <param name="buttons">Grupo de Botones.</param>
        /// <returns>Boton seleccionado.</returns>
        public static DialogResult Show(String Msg)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            InfoBox thisForm = new InfoBox();

            String[] Lines = Msg.Split('\n');
            thisForm.Lines = Lines;

            Result = thisForm.ShowDialog();

            return Result;
        } // static DialogResult Show(...)

        public static DialogResult Show(String[] Lines)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            InfoBox thisForm = new InfoBox();

            thisForm.Lines = Lines;

            Result = thisForm.ShowDialog();

            return Result;
        } // static DialogResult Show(...)

        public static DialogResult Show(List<String> Lines)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            InfoBox thisForm = new InfoBox();

            // ## @to-do: optimizar esto:
            // ## {
            // convertir a una sola cadena
            String S = "";
            foreach (String eachItem in Lines)
            {
                S += eachItem + '\n';
            } // foreach

            thisForm.Lines = ukt4dotnet.shared.utilities.StrUtils.SplitBySingleCharArray(S, '\n', false);
            // ## }

            Result = thisForm.ShowDialog();

            return Result;
        } //  // static DialogResult Show(...)

    } // class InfoBox

} // namespace ukt4dotnet.win.forms.MessageBoxes
