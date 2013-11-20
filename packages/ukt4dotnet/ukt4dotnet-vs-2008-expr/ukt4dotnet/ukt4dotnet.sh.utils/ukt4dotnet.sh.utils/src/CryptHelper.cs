using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
//using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Configuration;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;

namespace ukt4dotnet.shared.utilities
{
    /// <summary>
    /// Clase encargada de encriptar cadenas
    /// </summary>
	public class CryptHelper
    {
        // ukt4dotnet.shared.utilities.CryptHelper
        static byte[] key;
        static byte[] IV;
        
        //static string str_key = "C1081C436C0D4084A545936C";
        //static string str_IV  = "0EECB2B52851483494828F13";

        static string str_key = "C1081C436C0D4084A545936C";
        static string str_IV = "0EECB2B52851483494828F13";

        private static TripleDESCryptoServiceProvider des =
            new TripleDESCryptoServiceProvider();

        #region "constructor"
        public CryptHelper()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }
        #endregion "constructor"

        public static void SetKeys()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }

        public static void SetKeys(string Astr_key, string Astr_IV)
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(Astr_key);
            IV = textConverter.GetBytes(Astr_IV);
        }

        public static String Encriptar(String strEnc)
        {
            String Result = "";

            SetKeys();

            ASCIIEncoding textConverter = new ASCIIEncoding();
            byte[] toEncrypt;

            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                des.CreateEncryptor(key, IV), CryptoStreamMode.Write);

            toEncrypt = textConverter.GetBytes(strEnc);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            Result = Convert.ToBase64String(msEncrypt.ToArray());

            return Result;
        } // static String Encriptar(...)

        public static String Desencriptar(String strDesEnc)
        {
            String Result = "";

            SetKeys();

            ASCIIEncoding textConverter = new ASCIIEncoding();
            byte[] fromEncrypt;
            byte[] encrypted;
            byte[] ret;

            encrypted = Convert.FromBase64String(strDesEnc);

            MemoryStream msDecrypt = new MemoryStream(encrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                des.CreateDecryptor(key, IV), CryptoStreamMode.Read);

            fromEncrypt = new byte[encrypted.Length];

            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            ret = StripZeros(fromEncrypt);

            Result = textConverter.GetString(ret);

            return Result;
        } // static String Desencriptar(...)

        private static byte[] StripZeros(byte[] bites)
        {
            List<byte> list = new List<byte>();

            foreach (byte b in bites)
            {
                if (b != (byte)0)
                {
                    list.Add(b);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Aun presenta bugs: No utilizar
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <returns></returns>
        public static MemoryStream EncryptFile(string sInputFilename)
        {
            SetKeys();

            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            MemoryStream temp = new MemoryStream();
            MemoryStream output = new MemoryStream();

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(temp, desencrypt, CryptoStreamMode.Write);
           
            byte[] bytearrayinput = new byte[fsInput.Length];

            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            //Imprimir el contenido del archivo descifrado.             
            temp.WriteTo(output);

            //Cerrar los streams
            cryptostream.Close();
            fsInput.Close();

            return output;
        } // static MemoryStream EncryptFile(...)

        /// <summary>
        /// Lee el contenido de un archivo de texto,
        /// y regresa una copia encriptada, dentro de un flujo.
        /// </summary>
        /// <param name="sInputFilename">Ruta completa del archivo fuente</param>
        /// <returns>Flujo resultante</returns>
        public static MemoryStream EncryptFileToMemoryStream(string sInputFilename)
        {
            MemoryStream Result = null;

            Result = EncryptFile(sInputFilename);

            return Result;
        } // static MemoryStream EncryptFileToStream(...)

        /// <summary>
        /// Desencripta el archivo especificado
        /// </summary>
        /// <param name="sInputFilename">El archivo a desencriptar</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream DecryptFile(string sInputFilename)
        {
            SetKeys();
            
            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

            //Crear un descriptor de DES desde la instancia de DES. 
            ICryptoTransform desdecrypt = des.CreateDecryptor(key, IV);

            //Crear una secuencia de cifrado para leer y 
            //realizar una transformación de cifrado DES en los bytes de entrada. 
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);

            //Imprimir el contenido del archivo descifrado. 
            StreamReader sr = new StreamReader(cryptostreamDecr);
            byte[] buff = Encoding.ASCII.GetBytes(sr.ReadToEnd());

            fsread.Flush();
            fsread.Close();
            fsread.Dispose();
            sr.Close();
            sr.Dispose();

            return new MemoryStream(buff);
        } // static MemoryStream DecryptFile(...)

        public static void EncryptFile(string sInputFilename, string sOutputFilename)
        {
            SetKeys();

            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];

            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();           
        } // static void EncryptFile(...)

        public static void DecryptFile(string sInputFilename, string sOutputFilename)
        {
            SetKeys();
            
            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsRead = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

            //Crear un descriptor de DES desde la instancia de DES. 
            ICryptoTransform cryptRead = des.CreateDecryptor(key,IV);

            //Crear una secuencia de cifrado para leer y 
            //realizar una transformación de cifrado DES en los bytes de entrada. 
            CryptoStream cryptostreamDecrypter = new CryptoStream(fsRead, cryptRead, CryptoStreamMode.Read);

            //Imprimir el contenido del archivo descifrado. 
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);

            String data = new StreamReader(cryptostreamDecrypter).ReadToEnd();

            fsDecrypted.Write(data);
            fsDecrypted.Flush();
            fsDecrypted.Close();
        } // static void DecryptFile(...)

        public static void EncryptFile(Stream inputData, string sOutputFilename)
        {
            SetKeys();
            
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostreamEncrypter = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[inputData.Length];

            inputData.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostreamEncrypter.Write(bytearrayinput, 0, bytearrayinput.Length);
            
            cryptostreamEncrypter.Close();
            inputData.Close();
            fsEncrypted.Close();
        }

        public static void EncryptStreamToFile(Stream inputData, string sOutputFilename)
        {
            SetKeys();

            // abrir archivo para escritura
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[inputData.Length];

            inputData.Read(bytearrayinput, 0, bytearrayinput.Length);

            // guardar datos ya encriptados en archivo
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Close();
            inputData.Close();
            fsEncrypted.Close();
        } // static void EncryptStreamToFile(...)

        public static void EncriptarArchivo(string sSourceFilename, string sDestinationFilename)
        {
            SetKeys();

            FileStream fsInput = new FileStream(sSourceFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sDestinationFilename, FileMode.Create, FileAccess.Write);

                ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

                    byte[] bytearrayinput = new byte[fsInput.Length];
                    fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                    cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

                cryptostream.Close();
                cryptostream.Dispose();

            fsInput.Close();
            fsInput.Dispose();

            fsEncrypted.Close();
            fsEncrypted.Dispose();
        } // static void EncriptarArchivo(...)

        public static void EncriptarArchivo
            (string sSourceFilename, string sDestinationFilename,
            string Astr_key, string Astr_IV)
        {
            // preparar encriptacion utilizando las llaves capturadas
            SetKeys(Astr_key, Astr_IV);

            FileStream fsInput = new FileStream(sSourceFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sDestinationFilename, FileMode.Create, FileAccess.Write);

                ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

                    byte[] bytearrayinput = new byte[fsInput.Length];
                    fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                    cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

                cryptostream.Close();
                cryptostream.Dispose();

            fsInput.Close();
            fsInput.Dispose();

            fsEncrypted.Close();
            fsEncrypted.Dispose();
        } // static void EncriptarArchivo(...)

        public static void DesencriptarArchivo(string sSourceFilename, string sDestinationFilename)
        {
            SetKeys();

            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsSourceFile = new FileStream(sSourceFilename, FileMode.Open, FileAccess.Read);

                //Crear un descriptor de DES desde la instancia de DES. 
                ICryptoTransform desdecrypt = des.CreateDecryptor(key, IV);

                //Crear una secuencia de cifrado para leer y 
                //realizar una transformación de cifrado DES en los bytes de entrada. 
                CryptoStream cryptostreamDecr = new CryptoStream(fsSourceFile, desdecrypt, CryptoStreamMode.Read);

                //Imprimir el contenido del archivo descifrado. 
                StreamWriter fsDecrypted = new StreamWriter(sDestinationFilename);
            
                    fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                    fsDecrypted.Flush();

                fsDecrypted.Close();
                fsDecrypted.Dispose();

            fsSourceFile.Close();
            fsSourceFile.Dispose();
        } // static void DesencriptarArchivo(...)

        public static void DesencriptarArchivo
        (string sSourceFilename, string sDestinationFilename,
            string Astr_key, string Astr_IV)
        {
            SetKeys(Astr_key, Astr_IV);

            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsSourceFile = new FileStream(sSourceFilename, FileMode.Open, FileAccess.Read);

                //Crear un descriptor de DES desde la instancia de DES. 
                ICryptoTransform desdecrypt = des.CreateDecryptor(key, IV);

                //Crear una secuencia de cifrado para leer y 
                //realizar una transformación de cifrado DES en los bytes de entrada. 
                CryptoStream cryptostreamDecr = new CryptoStream(fsSourceFile, desdecrypt, CryptoStreamMode.Read);

                //Imprimir el contenido del archivo descifrado. 
                StreamWriter fsDecrypted = new StreamWriter(sDestinationFilename);
                    fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
                    fsDecrypted.Flush();

                fsDecrypted.Close();
                fsDecrypted.Dispose();

            fsSourceFile.Close();
            fsSourceFile.Dispose();
        } // static void DesencriptarArchivo(...)

        /*
        /// <summary>
        /// Guardar el contenido de un dataset como X.M.L.,
        /// en un flujo, y regresa el flujo.
        /// </summary>
        /// <param name="ds"></param>
        /// <returns>Flujop con los datos.</returns>
        public static Stream DataSetAsStream(DataSet ds)
        {
            MemoryStream result = new MemoryStream();

            ds.WriteXml(result);

            // Rewind the stream.
            result.Position = 0;

            return result;
        }
        */
    } // class CryptHelper

} // namespace ukt4dotnet.shared.utilities