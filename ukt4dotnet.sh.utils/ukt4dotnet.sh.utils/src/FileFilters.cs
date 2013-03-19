using System;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities
{
    public class FileFilter
    {
        #region "properties"
            private string _FileExtension;
            public string FileExtension
            {
              get { return _FileExtension; }
              set { _FileExtension = value; }
            }

            private string _FileTitle;
            public string FileTitle
            {
                get { return _FileTitle; }
                set { _FileTitle = value; }
            }
        #endregion "properties"

        #region "constructor"
            public FileFilter(string AFileExtension, string AFileTitle)
            {
                _FileExtension = AFileExtension;
                _FileTitle = AFileTitle;
            }
        #endregion "constructor"
    } // class FileFilter

    public class FileFilters
    {
        #region "properties"
        private List<FileFilter> _Items;
        public List<FileFilter> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        #endregion "properties"

        #region "constructor"
            public FileFilters()
            {
                _Items = new List<FileFilter>();
            }
        #endregion "constructor"

        public void Add(FileFilter AFileFilter)
        {
            if (AFileFilter != null)
            {
                Items.Add(AFileFilter);

            }
        }

        public override string ToString()
        {
            string Result = "";

            int ACount = (Items.Count - 1);
            int AIndex = 0;
            foreach (FileFilter eachFileFilter in Items)
            {
                String  thisFilter =
                    String.Format("{0} (*.{1}) | *.{1}", eachFileFilter.FileTitle, eachFileFilter.FileExtension);
                Result += thisFilter;

                if (AIndex < ACount)
                {
                    AIndex++;
                    Result += "|";
                }
            }

            return Result;
        }

    } // class FileFilters
} // namespace
