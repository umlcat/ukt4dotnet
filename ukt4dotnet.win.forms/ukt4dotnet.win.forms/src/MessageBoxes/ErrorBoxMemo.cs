using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace romo.windows.forms.MessageBoxes
{
    public class ErrorBoxMemo
    {
        // public static void Show(String Msg, String Title = "Error")
        public static void Show(String Msg)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show("Error", Msg, MessageBoxButtons.OK);
        } // static void Show(...)

        // public static void Show(String Msg, String Title = "Error")
        public static void ShowTitle(String Msg, String Title)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show(Title, Msg, MessageBoxButtons.OK);
        } // static void Show(...)

        //public static void Show(String[] Lines, String Title = "Error")
        public static void Show(String[] Lines, String Title)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show(Title, Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        public static void ShowTitle(String[] Lines)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show("Error", Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        //public static void Show(List<String> Lines, String Title = "Error")
        public static void Show(List<String> Lines, String Title)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show(Title, Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        public static void ShowTitle(List<String> Lines)
        {
            romo.windows.forms.MessageBoxes.MessageBoxMemo.Show("Error", Lines, MessageBoxButtons.OK);
        } // static void Show(...)
    } // class ErrorBoxMemo
} // namespace
