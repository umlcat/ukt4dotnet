using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace romo.windows.forms.MessageBoxes
{
    public class ConfirmBox
    {
        #region "constructor"
            public ConfirmBox()
            {
                //
            }
        #endregion "constructor"

        public static DialogResult Show(string message)
        {
            DialogResult Result = DialogResult.None;

            //Result = MessageBox.Show(message, "", MessageBoxButtons.YesNo);

            Result = romo.windows.forms.MessageBoxes.MessageBox.Show(message, "", MessageBoxButtons.YesNo);

            return Result;
        } // static DialogResult Show(...)


        public static DialogResult Show(string message, string caption)
        {
            DialogResult Result = DialogResult.None;

            //Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

            Result = romo.windows.forms.MessageBoxes.MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

            return Result;
        } // static DialogResult Show(...)
    } // class
} // namespace
