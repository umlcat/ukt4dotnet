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
using ukt4dotnet.win.forms;

namespace ukt4dotnet.win.forms.MessageBoxes
{
    /// <summary>
    /// Clase generica para capturar un valor alfanumerico extenso,
    /// en varias lineas, usese de forma similar a <code>MessageBox</code>.
    /// Adicionalmente, permite, copiar el mensaje al portapeles del S.O.
    /// </summary>
    public partial class MessageBoxMemo : Form
    {
        #region "properties"
        private String[] _Lines;
        public String[] Lines
        {
            get { return _Lines; }
            set { _Lines = value; }
        }

        MessageBoxButtons _SelectedButtons;
        /// <summary>
        /// Grupo de botones seleccionados,
        /// e indicados por medio de parametros.
        /// </summary>
        public MessageBoxButtons SelectedButtons
        {
            get { return _SelectedButtons; }
            set { _SelectedButtons = value; }
        }

        private BitArray _VisibleButtons = null;
        /// <summary>
        /// Guarda por valor numerico,
        /// cuales botones deben estar visibles,
        /// y cuales no.
        /// </summary>
        protected BitArray VisibleButtons
        {
            get { return _VisibleButtons; }
            set { _VisibleButtons = value; }
        }

        private List<Button> _Buttons;      
        /// <summary>
        /// Referencias a botones,
        /// para poder ser accesados por medio de indices.
        /// </summary>
        public List<Button> Buttons
        {
          get { return _Buttons; }
          set { _Buttons = value; }
        }

        private DialogResult _LowerLimit;
        public DialogResult LowerLimit
        {
            get { return _LowerLimit; }
            set { _LowerLimit = value; }
        }

        private DialogResult _HigherLimit;
        public DialogResult HigherLimit
        {
            get { return _HigherLimit; }
            set { _HigherLimit = value; }
        }
        #endregion "properties"

        #region "constructor"
        public MessageBoxMemo()
        {
            InitializeComponent();

            // ...

            Bitmap resourceImage = null;

            resourceImage = ukt4dotnet.win.forms.Properties.Resources.ok;
            ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage
                (ref this.OKExitButton, resourceImage, true);

            resourceImage = ukt4dotnet.win.forms.Properties.Resources.cancel;
            ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage
                (ref this.CancelExitButton, resourceImage, true);

            resourceImage = ukt4dotnet.win.forms.Properties.Resources.ok;
            ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage
                (ref this.YesExitButton, resourceImage, true);

            resourceImage = ukt4dotnet.win.forms.Properties.Resources.cancel;
            ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage
                (ref this.NoExitButton, resourceImage, true);

            // ...

            // --> grupo predeterminado
            this._SelectedButtons = MessageBoxButtons.OKCancel;

            // --> obtener maximo valor de un enumerado
            List<DialogResult> ListEnums = new List<System.Windows.Forms.DialogResult>();

            // se conocen los valores, pero no se sabe cual es el menor, y cual es el mayor
            ListEnums.Add(DialogResult.None);
            ListEnums.Add(DialogResult.Abort);
            ListEnums.Add(DialogResult.Cancel);
            ListEnums.Add(DialogResult.Ignore);
            ListEnums.Add(DialogResult.No);
            ListEnums.Add(DialogResult.OK);
            ListEnums.Add(DialogResult.Retry);
            ListEnums.Add(DialogResult.Yes);

            // asignamos uno menor y uno mayor al azar,
            this.LowerLimit  = DialogResult.None;
            this.HigherLimit = DialogResult.None;

            foreach (DialogResult eachItem in ListEnums)
            {
                // reemplazar mayor
                if (eachItem > this.HigherLimit)
                {
                    this.HigherLimit = eachItem;
                }

                // reemplazar menor
                if (eachItem < this.LowerLimit)
                {
                    this.LowerLimit = eachItem;
                }
            } // foreach

            // --> agregar un valor booleano por cada tipo de boton,
            // --> a la lista, esta lista no cambiara la cantidad de elementos,
            // --> solo el valor booleano de cada elemento, funcionando
            // --> como un conjunto
            int Last = (int)this.HigherLimit;
            // los arreglos son de 0 ... ultimo,
            // la cantidad es (ultimo + 1)
            this._VisibleButtons = new BitArray(Last + 1, false);

            // @to-do: faltar agregar controles botones
            // --> asignar referencias controles boton en arreglo
            this._Buttons = new List<Button>();

            bool CanContinue = true;
            DialogResult eachEnum = this.LowerLimit;
            while (CanContinue)
            {
                CanContinue = (eachEnum <= this.HigherLimit);

                switch (eachEnum) 
                {
                    case DialogResult.None:
                        this._Buttons.Add(null);
                        break;

                    case DialogResult.Abort:
                        this._Buttons.Add(null);
                        break;

                    case DialogResult.Cancel:
                        this._Buttons.Add(this.CancelExitButton);
                        break;

                    case DialogResult.Ignore:
                        this._Buttons.Add(null);
                        break;

                    case DialogResult.No:
                        this._Buttons.Add(this.NoExitButton);
                        break;

                    case DialogResult.OK:
                        this._Buttons.Add(this.OKExitButton);
                        break;

                    case DialogResult.Retry:
                        this._Buttons.Add(null);
                        break;

                    case DialogResult.Yes:
                        this._Buttons.Add(this.YesExitButton);
                        break;

                    default:
                        break;
                } // switch

                if (CanContinue)
                {
                    eachEnum++;
                }
            } // while

            Bitmap ANewImage = null;
            if (ukt4dotnet.win.forms.Configuration.CustomizeImages)
            {
                ANewImage = ukt4dotnet.win.forms.Configuration.getImage(System.Windows.Forms.DialogResult.OK);
                ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage(ref OKExitButton, ANewImage, true);

                ANewImage = ukt4dotnet.win.forms.Configuration.getImage(System.Windows.Forms.DialogResult.Yes);
                ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage(ref YesExitButton, ANewImage, true);

                ANewImage = ukt4dotnet.win.forms.Configuration.getImage(System.Windows.Forms.DialogResult.Cancel);
                ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage(ref CancelExitButton, ANewImage, true);

                ANewImage = ukt4dotnet.win.forms.Configuration.getImage(System.Windows.Forms.DialogResult.No);
                ukt4dotnet.win.forms.Resources.AssignButtonBackgroundImage(ref NoExitButton, ANewImage, true);
            } // if (ukt4dotnet.win.forms.Configuration.CustomizeImages)
        }
        #endregion "constructor"

        /// <summary>
        /// Toma un grupo de valores para botones,
        /// y regresa una lista individual, con los botones correspondientes.
        /// </summary>
        /// <param name="buttons">Grupo de Botones</param>
        /// <returns>Lista equivalente con botones individuales.</returns>
        public List<DialogResult> MessageBoxButtonsToDialogResult(MessageBoxButtons buttons)
        {
            List<DialogResult> Result = new List<DialogResult>();

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    Result.Add(DialogResult.Abort);
                    Result.Add(DialogResult.Retry);
                    Result.Add(DialogResult.Ignore);
                    break;

                case MessageBoxButtons.OK:
                    Result.Add(DialogResult.OK);
                    break;

                case MessageBoxButtons.OKCancel:
                    Result.Add(DialogResult.OK);
                    Result.Add(DialogResult.Cancel);
                    break;

                case MessageBoxButtons.RetryCancel:
                    Result.Add(DialogResult.Retry);
                    Result.Add(DialogResult.Cancel);
                    break;

                case MessageBoxButtons.YesNoCancel:
                    Result.Add(DialogResult.Yes);
                    Result.Add(DialogResult.No);
                    Result.Add(DialogResult.Cancel);
                    break;

                //case MessageBoxButtons.YesNo:
                default:
                    Result.Add(DialogResult.Yes);
                    Result.Add(DialogResult.No);
                    break;
            } // switch

            return Result;
        } // List<DialogResult> MessageBoxButtonsToDialogResult(...)

        protected bool getIsButtonVisible(DialogResult thisButton)
        {
            bool Result = false;

            // --> pasar valor enumerado a indice entero
            int AIndex = (int)thisButton;
            // --> revisar este disponible en lista referencias
            if (AIndex < this.Buttons.Count)
            {
                Button ButtonRef = this.Buttons[AIndex];
                if (ButtonRef != null)
                {
                    Result = this.Buttons[AIndex].Visible;
                }                
            }

            return Result;
        } // bool getIsButtonVisible(...)

        protected void setIsButtonVisible(DialogResult thisButton, bool value)
        {
            // --> pasar valor enumerado a indice entero
            int AIndex = (int)thisButton;
            // --> revisar este disponible en lista referencias
            if (AIndex < this.Buttons.Count)
            {
                Button ButtonRef = this.Buttons[AIndex];
                if (ButtonRef != null)
                {
                    this.Buttons[AIndex].Visible = value;
                }
            }
        } // void setIsButtonVisible(...)

        private void MessageBoxesMemo_Shown(object sender, EventArgs e)
        {
            // --> pasar propiedad publica a valor control
            DataTextBox.Lines = this.Lines;

            // --> alinear botones
            this.OKExitButton.Left  = this.DataTextBox.Left;
            this.YesExitButton.Left = this.DataTextBox.Left;
            this.NoExitButton.Left  = this.CancelExitButton.Left;

            // --> ajustar botones
            this.YesExitButton.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            this.OKExitButton.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            this.NoExitButton.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
            this.CancelExitButton.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

            // --> ocultar todos los botones
            foreach (Button eachButton in this.Buttons)
            {
                if (eachButton != null)
                {
                    eachButton.Visible = false;
                }
            } // foreach

            // --> desplegar solo botones seleccionados
            List<DialogResult> GrupoSeleccionado = MessageBoxButtonsToDialogResult(this.SelectedButtons);
            foreach (DialogResult cadaBotonSeleccionado in GrupoSeleccionado)
            {
                setIsButtonVisible(cadaBotonSeleccionado, true);
            } // foreach       
        } // void MessageBoxesMemo_Shown(...)

        // ...

        /// <summary>
        /// Clase generica para capturar un valor alfanumerico extenso,
        /// en varias lineas, usese de forma similar a <code>MessageBox</code>.
        /// Nota: Este metodo ejecuta la forma regresando como parametros,
        /// algunas propiedades significas de la forma.
        /// Considerese este metodo estatico como funcion global del "namespace",
        /// no como un metodo de esta clase.
        /// </summary>
        /// <param name="Title">Titulo de la forma.</param>
        /// <param name="Msg">Texto del mensaje, puede tener saltos de linea.</param>
        /// <param name="buttons">Grupo de Botones.</param>
        /// <returns>Boton seleccionado.</returns>
        /// public static DialogResult Show(string Title, String Msg, MessageBoxButtons buttons = MessageBoxButtons.OK)
        public static DialogResult Show(string Title, String Msg, MessageBoxButtons buttons)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            MessageBoxMemo thisForm = new MessageBoxMemo();
            thisForm.Text = Title;
            thisForm.SelectedButtons = buttons;

            String[] Lines = Msg.Split('\n');
            thisForm.Lines = Lines;

            Result = thisForm.ShowDialog();

            return Result;
        } // static DialogResult Show(...)

        //public static DialogResult Show(string Title, String[] Lines, MessageBoxButtons buttons = MessageBoxButtons.OK)
        public static DialogResult Show(string Title, String[] Lines, MessageBoxButtons buttons)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            MessageBoxMemo thisForm = new MessageBoxMemo();
            thisForm.Text = Title;
            thisForm.SelectedButtons = buttons;

            thisForm.Lines = Lines;

            Result = thisForm.ShowDialog();

            return Result;
        } // static DialogResult Show(...)

        //public static DialogResult Show(string Title, List<String> Lines, MessageBoxButtons buttons = MessageBoxButtons.OK)
        public static DialogResult Show(string Title, List<String> Lines, MessageBoxButtons buttons)
        {
            DialogResult Result = DialogResult.None;

            // --> ejecutar forma auxiliar
            MessageBoxMemo thisForm = new MessageBoxMemo();
            thisForm.Text = Title;
            thisForm.SelectedButtons = buttons;

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
        } // static DialogResult Show(...)
    } // class MessageBoxesMemo
} // namespace
