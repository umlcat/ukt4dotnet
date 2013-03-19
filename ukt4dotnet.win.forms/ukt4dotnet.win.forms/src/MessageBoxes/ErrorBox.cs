using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace romo.windows.forms.MessageBoxes
{
    public class ErrorBox
    {
        #region "constructor"
            public ErrorBox()
            {
                //
            }
        #endregion "constructor"

        //public static void Show(string message, string title = "Error")
        public static void Show(string message)
        {
            //MessageBox.Show(message, "", MessageBoxButtons.OK);

            romo.windows.forms.MessageBoxes.MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        } // static void Show(...)

        public static void ShowTitle(string message, string title)
        {
            //MessageBox.Show(message, "", MessageBoxButtons.OK);

            romo.windows.forms.MessageBoxes.MessageBox.Show(message, title, MessageBoxButtons.OK);
        } // static void ShowTitle(...)

    } // class ErrorBox

} // namespace
