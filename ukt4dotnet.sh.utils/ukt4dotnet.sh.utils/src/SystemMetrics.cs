using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;

namespace romo.shared.utilities
{
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LOGFONT
    {
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string lfFaceName;
    } // struct LOGFONT

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct NONCLIENTMETRICS
    {
        public int cbSize;
        public int iBorderWidth;
        public int iScrollWidth;
        public int iScrollHeight;
        public int iCaptionWidth;
        public int iCaptionHeight;
        public LOGFONT lfCaptionFont;
        public int iSmCaptionWidth;
        public int iSmCaptionHeight;
        public LOGFONT lfSmCaptionFont;
        public int iMenuWidth;
        public int iMenuHeight;
        public LOGFONT lfMenuFont;
        public LOGFONT lfStatusFont;
        public LOGFONT lfMessageFont;
    } // struct NONCLIENTMETRICS

    public class NonClientMetrics
    {
        public NONCLIENTMETRICS Data;

        private String _CaptionFontFamily = "";
        public String CaptionFontFamily
        {
            get { return _CaptionFontFamily; }
            set { _CaptionFontFamily = value; }
        }

        private int _CaptionFontSize = 0;
        public int CaptionFontSize
        {
            get { return _CaptionFontSize; }
            set { _CaptionFontSize = value; }
        }

        /*
            SystemInformation.CaptionHeight
            SystemInformation.BorderSize.Height
            SystemInformation.BorderSize.Width
            SystemInformation.Border3DSize.Height
            SystemInformation.Border3DSize.Width
            SystemInformation.FixedFrameBorderSize.Height
            SystemInformation.FixedFrameBorderSize.Width
         */

        #region "constructor"
        public NonClientMetrics(NONCLIENTMETRICS AData)
        {
            this.Data = AData;

            this.CaptionFontFamily = AData.lfCaptionFont.lfFaceName;
            // returns negative, sometimes
            this.CaptionFontSize = System.Math.Abs(AData.lfCaptionFont.lfHeight);
        }
        #endregion "constructor"
    } // public class NonClientMetrics

    public static class SystemMetrics
    {
        const int SPI_GETNONCLIENTMETRICS = 0x0029;

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool SystemParametersInfo(int action,
                                                int intParam,
                                                ref NONCLIENTMETRICS metrics,
                                                int update);

        public static bool readMetrics(out NonClientMetrics thisMetrics)
        {
            bool Result = false;

            /* out */
            thisMetrics = null;

            NONCLIENTMETRICS metrics = new NONCLIENTMETRICS();
            metrics.cbSize = Marshal.SizeOf(metrics);

            Result =
                SystemParametersInfo(
                    SPI_GETNONCLIENTMETRICS,
                    0,
                    ref metrics,
                    0);

            // nota: "SystemParametersInfo" con "CharSet.Unicode",
            // y "LOGFONT" y "LOGFONT" con "CharSet.Auto", es el que funciona
            if (Result)
            {
                thisMetrics = new NonClientMetrics(metrics);
            }

            return Result;
        } // bool readMetrics(out NONCLIENTMETRICS metrics)

    } // static class SystemMetrics

} // namespace
