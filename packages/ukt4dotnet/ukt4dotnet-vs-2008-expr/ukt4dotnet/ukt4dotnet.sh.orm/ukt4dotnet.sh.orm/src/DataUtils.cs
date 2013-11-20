using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace ukt4dotnet.shared.orm
{
    public static class DataUtils
    {
        public static Object DataFieldToObject
            (Type ADataType, DataRow EachRow, string AKey)
        {
            Object Result = null;

            if (ADataType == typeof(System.Int16))
            {
                Result = (Int16)EachRow[AKey];
            }
            else if (ADataType == typeof(System.Int32))
            {
                Result = (Int32)EachRow[AKey];
            }
            else if (ADataType == typeof(System.Int64))
            {
                Result = (Int64)EachRow[AKey];
            }
            else if (ADataType == typeof(System.UInt16))
            {
                Result = (UInt16)EachRow[AKey];
            }
            else if (ADataType == typeof(System.UInt32))
            {
                Result = (UInt32)EachRow[AKey];
            }
            else if (ADataType == typeof(System.UInt64))
            {
                Result = (UInt64)EachRow[AKey];
            }
            else if (ADataType == typeof(System.DateTime))
            {
                Result = (DateTime)EachRow[AKey];
            }
            else if (ADataType == typeof(System.String))
            {
                Result = (String)EachRow[AKey];
            }
            else if (ADataType == typeof(System.Boolean))
            {
                Result = (int)EachRow[AKey];
            }

            return Result;
        } // static Object DataFieldToObject(...)

        public static string ObjectToSQL(Object AValue)
        {
            string Result = "";

            Type ADataType = AValue.GetType();

            if (ADataType == typeof(System.Int16))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.Int32))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.Int64))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.UInt16))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.UInt32))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.UInt64))
            {
                Result = AValue.ToString();
            }
            else if (ADataType == typeof(System.DateTime))
            {
                DateTime ADateTime = (DateTime)AValue;

                String ADatePart =
                    String.Format
                        ("{0}-{1}-{2}",
                            ADateTime.Year, ADateTime.Month, ADateTime.Day);
                String ATimePart =
                    String.Format
                        ("{0}:{1}:{2}",
                            ADateTime.Hour, ADateTime.Minute, ADateTime.Second);

                Result =
                    String.Format
                        ("'{0} {1}'", ADatePart, ATimePart);
            }
            else if (ADataType == typeof(System.Char))
            {
                Result = String.Format("'{0}'", AValue);
            }
            else if (ADataType == typeof(System.String))
            {
                Result = String.Format("'{0}'", AValue);
            }
            else if (ADataType == typeof(System.Boolean))
            {
                Result = (((bool) AValue) ? "1" : "0");
            }

            return Result;
        } // static string ObjectToSQL(...)

        public static Dictionary<string, Object> DataRowToDictionary
            (DataRow EachRow, DataColumnCollection AColumns)
        {
            Dictionary<string, Object> Result = new Dictionary<string, object>();

            foreach (DataColumn EachColumn in AColumns)
            {
                string AKey = EachColumn.ColumnName;
                Object AValue =
                    DataFieldToObject(EachColumn.DataType, EachRow, AKey);

                Result.Add(AKey, AValue);
            } // foreach

            return Result;
        } // static Dictionary<string, Object> DataRowToDictionary(...)

        // ...

    } // static class DataUtils
} // namespace
