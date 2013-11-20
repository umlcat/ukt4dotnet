using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ukt4dotnet.win.forms.MessageBoxes
{
    public class ErrorBoxMemo
    {
        // public static void Show(String Msg, String Title = "Error")
        public static void Show(String Msg)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show("Error", Msg, MessageBoxButtons.OK);
        } // static void Show(...)

        // public static void Show(String Msg, String Title = "Error")
        public static void ShowTitle(String Msg, String Title)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show(Title, Msg, MessageBoxButtons.OK);
        } // static void Show(...)

        //public static void Show(String[] Lines, String Title = "Error")
        public static void Show(String[] Lines, String Title)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show(Title, Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        public static void ShowTitle(String[] Lines)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show("Error", Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        //public static void Show(List<String> Lines, String Title = "Error")
        public static void Show(List<String> Lines, String Title)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show(Title, Lines, MessageBoxButtons.OK);
        } // static void Show(...)

        public static void ShowTitle(List<String> Lines)
        {
            ukt4dotnet.win.forms.MessageBoxes.MessageBoxMemo.Show("Error", Lines, MessageBoxButtons.OK);
        } // static void Show(...)
    } // class ErrorBoxMemo
} // namespace
