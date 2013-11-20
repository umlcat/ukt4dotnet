using System;
using System.Windows.Forms;
using System.Text;

namespace ukt4dotnet.win.forms
{
    // ukt4dotnet.win.forms.Application
    public static class Application
    {
        /// <summary>
        /// Reemplazo de <code>System.Windows.Forms.Application.Exit()</code>,
        /// que no se puede utilizar en el constructor de una forma,
        /// solamente, cuando la forma ya ha sido construida.
        /// </summary>
        /// public static void Exit(bool forceExit = false)
        public static void Exit(bool forceExit)
        {
            // --> cerrar la forma principal, y consecuentemente, toda la aplicacion
            if (System.Windows.Forms.Application.MessageLoop && !forceExit)
            {
                // Use this since we are a WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Use this since we are a console app
                System.Environment.Exit(1);
            }
        } // static void Exit(...)

        public static void resizeSplitterPanel(ref SplitContainer AContainer, int Height)
        {
            int Difference = (AContainer.Size.Height - AContainer.SplitterWidth);
            Difference -= Height;
            AContainer.SplitterDistance = Difference;
        } // static void resizeSplitterPanel(...)

        public static void UnderConstruction()
        {
            string MsgTitle = "Informacion";
            string MsgText = "Bajo Construccion";
            ukt4dotnet.win.forms.MessageBoxes.MessageBox.Show(MsgText, MsgTitle, MessageBoxButtons.OK);
        } // static void UnderConstruction(...)

    } // static class Application
} // namespace
