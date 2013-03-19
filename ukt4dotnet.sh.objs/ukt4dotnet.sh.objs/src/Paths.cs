using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using romo.shared.objects;
using romo.shared.utilities;

namespace romo.shared.utilities.IO.Paths
{
    public static class MainModule
    {
        public enum FileSystemTypeEnum
        {
            fsUnknown,
            fsRoot,
            fsDrive,
            fsFolder,
            fsFile,
        }

        //public static String NormalizedPathToOSPath(String APath)

        /*
        public static String NormalizedPathToOSPath(String APath)
        {
            String Result = APath;

            int DriveSepIndex = 0;

            bool IsNormalizedRoot = (Result[0] == '^');
            if (!IsNormalizedRoot)
            {
                bool IsUnixRoot = (Result[0] == '\\');
                if (IsUnixRoot)
                {
                    // agregar solamente caracter para raiz
                    Result = "^" + Result;
                    DriveSepIndex = 3;
                }
                else
                {
                    DriveSepIndex = 1;
                }
            }

            bool IsDriveRoot = (Result[DriveSepIndex] == ':');
            if (IsDriveRoot)
            {
                // obtener "drive"
                Char DriveLetter = Result[DriveSepIndex - 1];
                // omitir separador de "drive"
                String RestPath = Strings.MainModule.RightCopyByLength(Result, Result.Length - 2);

                Result = DriveLetter + RestPath;

                // agregar caracter para raiz y separador
                Result = "^\\" + Result;
            }

            // use unix folder separator
            Result = Result.Replace('\\', '/');

            return Result;
        } // static String NormalizePath(...)

        public static string OSPathToNormalizedPath(String APath)
        {
            string Result = "";

            // replace unix-based path separators by windowze path separators
            Result = romo.shared.utilities.StrUtils.ReplaceCopy(APath, @"/", @"\");

            // add
            int ALen = (Result.Length - 1);
            Result =
                romo.shared.utilities.strings.StrUtils.FirstCharCopy(Result) + ":" +
                romo.shared.utilities.strings.StrUtils.RightCopyByLength(Result, ALen);

            Result = romo.shared.utilities.StrUtils.TrimPrefix("^/", Result);

            return Result;
        } // string static OSPathToNormalizedPath(...)
        */

        public static String NormalizedPathToOSPath(String APath)
        {
            // to-do: optimize all these function
            String Result = APath;

            // remove: root folder special syntax, and respective folder separator
            Result = StrUtils.TrimPrefix("^/", Result);

            String Before =
                StrUtils.FirstCharCopy(Result) + ":";

            // obtain remainning path without: drive letter
            int ALen = (Result.Length - 1);
            String After = StrUtils.RightCopyByLength(Result, ALen);

            // recover drive letter, windowze syntax
            Result = Before + After;

            // use windowze path separator
            Result = StrUtils.ReplaceStringCopy(Result, @"/", @"\");

            return Result;
        } // static String NormalizedPathToOSPath(...)

        public static string OSPathToNormalizedPath(String APath)
        {
            string Result = "";

            // replace unix-based folder separators by windowze folder separators
            Result = StrUtils.ReplaceStringCopy(APath, @"\", @"/");

            // is there any drive delimiter ?
            int AIndex = Result.IndexOf(":");
            // then, skip drive delimiter
            if (AIndex >= 0)
            {
                // to-do: optimize all these block
                int ALen = 0;
                
                // when taking characters from the left, the index is the same as the length
                ALen = AIndex;
                String Before = StrUtils.LeftCopyByLength(Result, ALen);

                ALen = (Result.Length - AIndex - 1);
                String After = StrUtils.RightCopyByLength(Result, ALen);

                Result = Before + After;
            } // if (AIndex >= 0)

            // add root folder special syntax identifier, and respective folder separator
            Result = "^/" + Result;

            // remove final folder separator
            Result = StrUtils.TrimPosfix("/", Result);

            return Result;
        } // string static OSPathToNormalizedPath(...)

        public static bool IsNormalizedPath(String APath)
        {
            bool Result = false;

            int AIndex = StrUtils.SetIndexOfAt(@":\", APath, 0);

            /*
            if (APath.Contains()
            {

            }
            */

            return Result;
        } // static bool IsNormalizedPath(...)

        public static bool IsEmpty(String AOSPath)
        {
            bool Result = false;

            string[] Files = System.IO.Directory.GetFiles(AOSPath);
            string[] Folders = System.IO.Directory.GetDirectories(AOSPath);
            bool IsEmpty = ((Files.Length == 0) && (Folders.Length == 0));

            return Result;
        } // static bool IsEmpty(...)

        public class NormalizedPathScanner: ObjectClass
        {
            protected int StartIndex = 0;
            protected bool WasRoot = false;
            protected bool WasDrive = false;

            #region "properties"

            protected String _SourcePath = "";
            public String SourcePath
            {
                get { return _SourcePath; }
                set { setSourcePath(value); }
            }

            // ...

            #endregion "properties"

            #region "constructors"
            public override Int64 Create()
            {
                Int64 Result = 0;
                  this.StartIndex = 0;
                  this._SourcePath = "";
                return Result;
            } // Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;
                  this.StartIndex = 0;
                  this._SourcePath = "";
                return Result;
            } // Int64 Destroy(...)
            #endregion "constructors"

            protected void setSourcePath(String Value)
            {
                this._SourcePath = "";

                int Last = Value.Length;
                if (Last > 0)
                {
                    Last--;
                    if (StrUtils.LastCharCopy(Value) != '/')
                    {
                        // agregar separador al final
                        this._SourcePath = Value + "/";
                    }
                }
            } // void setSourcePath(...)

            public void reset()
            {
                this.StartIndex = 0;
            } // void reset(...)

            public bool readFolderType(out String FolderName, out FileSystemTypeEnum FileSystemType)
            {
                bool Result = false;
                /* ## out */ FolderName = "";
                /* ## out */ FileSystemType = FileSystemTypeEnum.fsUnknown;

                // find next folder separator
                int FinishIndex = this._SourcePath.IndexOf('/', this.StartIndex);

                // used later, to copy substring
                int ALen = 0;

                Result = (FinishIndex >= 0);
                if (Result)
                {
                    ALen = (FinishIndex - this.StartIndex);

                    // obtain substring
                    FolderName = this._SourcePath.Substring(this.StartIndex, ALen);

                    bool IsRoot = (FolderName == "^");
                    if (IsRoot)
                    {
                        FileSystemType = FileSystemTypeEnum.fsRoot;
                        this.WasDrive  = false;
                    }
                    else
                    {
                        bool IsDrive = (this.WasRoot);
                        if (IsDrive)
                        {
                            FileSystemType = FileSystemTypeEnum.fsDrive;
                        }
                        else
                        {
                            FileSystemType = FileSystemTypeEnum.fsFolder;
                        } // if (IsDrive)
                        this.WasDrive = IsDrive;
                    } // if (IsRoot)
                    this.WasRoot = IsRoot;

                    // mover indice al siguiente elemento
                    this.StartIndex = (FinishIndex + 1);
                } // if (AIndex >= 0)

                return Result;
            } // bool readFolderType(...)

            public bool readFolder(out String FolderName)
            {
                FileSystemTypeEnum FileSystemType = FileSystemTypeEnum.fsUnknown;
                bool Result = readFolderType(out FolderName, out FileSystemType);

                return Result;
            } // bool readFolder(...)

            /*
            // "virtual pseudoconstructor"
            Scanner.create();
            Scanner.SourcePath = NormalizedPath;

            String FolderName = "";
            while (Scanner.readFolder(out FolderName))
            {
                //
            } // while

            // "virtual pseudodestructor"
            Scanner.destroy();
             * 
            // "virtual pseudoconstructor"
            Scanner.create();
            Scanner.SourcePath = NormalizedPath;

            String FolderName = "";
            romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum FileSystemType =
                romo.shared.utilities.IO.Paths.MainModule.FileSystemTypeEnum.fsUnknown;

            while (Scanner.readFolderType(out FolderName, out FileSystemType))
            {
                //
            } // while

            // "virtual pseudodestructor"
            Scanner.destroy();
            */

        } // class NormalizedPathScanner

        // ...

    } // static class MainModule

    // ...

} // namespace romo.shared.utilities.IO.Paths