using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Configuration;
using System.Security.Cryptography;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.win.forms
{
    // ukt4dotnet.win.forms.Resources
    public static class Resources
    {
        /// <summary>
        /// Obtiene el identificador completo,
        /// para extraer una imagen del folder de recursos.
        /// </summary>
        /// <param name="BaseID">Identificador Simple</param>
        /// <returns>Identificador Completo</returns>
        public static String fullResourceID(string BaseID)
        {
            String Result = "";

            // obtener ID. de la aplicacion
            String MainNamespaceId = Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath);

            // integrar con otros Id's requeridos
            Result =
                String.Format("{0}.Resources.{1}", MainNamespaceId, BaseID);

            return Result;
        } // function

        public static Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap Result = null;

            if (nWidth > 0 && nHeight > 0)
            {
                Result = new Bitmap(nWidth, nHeight);
                if (b != null)
                {
                    using (Graphics g = Graphics.FromImage((Image)Result))
                        g.DrawImage(b, 0, 0, nWidth, nHeight);
                }
            }

            return Result;
        } // static Bitmap ResizeBitmap(...)

        /// <summary>
        /// Asigna y redimensiona la imagen de fondo de un boton, 
        /// tomando en cuenta cuando ademas, se asignara un texto al boton.
        /// </summary>
        /// <param name="thisButton"></param>
        /// <param name="thisImage"></param>
        /// <param name="WillAddText"></param>
        public static void AssignButtonBackgroundImage
            (ref Button thisButton, Bitmap thisImage, bool WillAddText)
        {
            bool AreAssigned =
                ((thisButton != null) && (thisImage != null));
            if (AreAssigned)
            {
                thisButton.Image = null;
                thisButton.BackgroundImage = null;

                thisButton.FlatStyle = FlatStyle.Flat;
                thisButton.FlatAppearance.BorderSize = 0;
                thisButton.BackColor = Color.Transparent;
                thisButton.BackgroundImage = thisImage;
                thisButton.BackgroundImageLayout = ImageLayout.Stretch;
            } // if (AreAssigned)
        } // static void AssignButtonBackgroundImage(...)

        /// <summary>
        /// Asigna y redimensiona la imagen de fondo de un boton, 
        /// tomando en cuenta cuando ademas, se asignara un texto al boton.
        /// </summary>
        /// <param name="thisButton"></param>
        /// <param name="thisImage"></param>
        /// <param name="WillAddText"></param>
        public static void AssignButtonImage
            (ref Button thisButton, Bitmap thisImage, bool WillAddText)
        {
            bool AreAssigned =
                ((thisButton != null) && (thisImage != null));
            if (AreAssigned)
            {
                // ajustar dimensiones imagen en base a boton
                int nWidth = thisButton.Width;
                int nHeight = thisButton.Height;
                int nSize = System.Math.Min(nWidth, nHeight);

                if (WillAddText)
                {
                    // ajustar dimensiones imagen debido a texto
                    nWidth = ukt4dotnet.shared.utilities.Math.IntToIntDiv(nSize, 2);
                    nHeight = ukt4dotnet.shared.utilities.Math.IntToIntDiv(nSize, 2);

                    // ajustar ubicacion imagen e ubicacion texto
                    thisButton.ImageAlign = ContentAlignment.TopCenter;
                    thisButton.TextAlign = ContentAlignment.BottomCenter;
                }
                else
                {
                    // ajustar ubicacion imagen, no hay texto
                    thisButton.ImageAlign = ContentAlignment.MiddleCenter;
                }

                // ahora si, asignar imagen
                Bitmap newBitmap = new Bitmap(nWidth, nHeight);
                using (Graphics g = Graphics.FromImage((Image)newBitmap))
                    g.DrawImage(thisImage, 0, 0, nWidth, nHeight);

                thisButton.BackgroundImage = null;
                thisButton.Image = newBitmap;
                //thisButton.BackgroundImageLayout = ImageLayout.Center;
            } // if (AreAssigned)
        } // static void AssignButtonImage(...)

    } // static class Resources


} // namespace
