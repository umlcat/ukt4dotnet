using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ukt4dotnet.win.forms.Properties;

namespace ukt4dotnet.win.forms
{
    //ukt4dotnet.win.forms.Configuration
    public static class Configuration
    {
        private static bool _CustomizeImages = false;
        /// <summary>
        /// Indicates wheter the default images of the form's buttons,
        /// are going to be replaced by custom app.
        /// </summary>
        public static bool CustomizeImages
        {
            get { return Configuration._CustomizeImages; }
            set { Configuration._CustomizeImages = value; }
        }

        public static Bitmap ImageNone = null;
        public static Bitmap ImageOK = null;
        public static Bitmap ImageCancel = null;
        public static Bitmap ImageAbort = null;
        public static Bitmap ImageRetry = null;
        public static Bitmap ImageIgnore = null;
        public static Bitmap ImageYes = null;
        public static Bitmap ImageNo = null;

        /// <summary>
        /// Regresa la imagen customizable asignada segun el indice indicado.
        /// </summary>
        /// <param name="AIndex">Indice por el cual se buscara</param>
        /// <returns>Imagen correspondiente</returns>
        public static Bitmap getImage(DialogResult AIndex)
        {
            Bitmap Result = null;

            switch (AIndex)
            {
                case DialogResult.OK:
                    if (ImageOK != null)
                    {
                        Result = ImageOK;
                    }
                    else
                    {
                        Result = ukt4dotnet.win.forms.Properties.Resources.generic;
                    }
                break;

                case DialogResult.Cancel:
                    if (ImageCancel != null)
                    {
                        Result = ImageCancel;
                    }
                    else
                    {
                        Result = ukt4dotnet.win.forms.Properties.Resources.generic;
                    }
                break;

                case DialogResult.Abort:
                    if (ImageAbort != null)
                    {
                        Result = ImageAbort;
                    }
                    else
                    {
                        Result = Properties.Resources.generic;
                    }
                break;

                case DialogResult.Retry:
                    if (ImageRetry != null)
                    {
                        Result = ImageRetry;
                    }
                    else
                    {
                        Result = Properties.Resources.generic;
                    }
                break;

                case DialogResult.Ignore:
                    if (ImageIgnore != null)
                    {
                        Result = ImageIgnore;
                    }
                    else
                    {
                        Result = Properties.Resources.generic;
                    }
                break;

                case DialogResult.Yes:
                    if (ImageYes != null)
                    {
                        Result = ImageYes;
                    }
                    else
                    {
                        Result = Properties.Resources.generic;
                    }
                break;

                case DialogResult.No:
                    if (ImageNo != null)
                    {
                        Result = ImageNo;
                    }
                    else
                    {
                        Result = Properties.Resources.generic;
                    }
                break;

                default:
                    Result = Properties.Resources.generic;
                    break;
            } // switch

            return Result;
        } // static Bitmap getImage(...)

        /// <summary>
        /// Reemplaza la imagen customizable que corresponde,
        /// al indice proporcionado.
        /// </summary>
        /// <param name="AIndex">Indice correspondiente</param>
        /// <param name="value">Nueva Imagen</param>
        public static void setImage(DialogResult AIndex, Bitmap value)
        {
            bool CanAssign =
              ((AIndex != DialogResult.None) && (value != null));

            if (CanAssign)
            {
                switch (AIndex)
                {
                    case DialogResult.OK:
                        ImageOK = value;
                        break;

                    case DialogResult.Cancel:
                        ImageCancel = value;
                        break;

                    case DialogResult.Abort:
                        ImageAbort = value;
                        break;

                    case DialogResult.Retry:
                        ImageAbort = value;
                        break;

                    case DialogResult.Ignore:
                        ImageIgnore = value;
                        break;

                    case DialogResult.Yes:
                        ImageYes = value;
                        break;

                    case DialogResult.No:
                        ImageNo = value;
                        break;

                    default:
                        break;
                } // switch
            } // if (CanAssign)
        } // static void setImage(...)

    } // public static class Configuration

} // namespace ukt4dotnet.win.forms
