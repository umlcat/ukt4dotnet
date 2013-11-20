using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.utilities
{
    /// <summary>
    /// Its the base classe for primitive data types,
    /// intended to be boxed as an object.
    /// Note: Consumes a lot of resources.
    /// </summary>
    public class BoxedDataTypeClass : CloneableObjectClass
    {
        // ...
    } // class BoxedDataTypeClass

    /// <summary>
    /// Encapsulates a primitive <code>Int16</code> primitive type,
    /// into an object.
    /// </summary>
    public class BoxedInt16Class : BoxedDataTypeClass
    {
        #region "fields"
            private Int16 F_Data;
        #endregion "fields"

        #region "methods"
            public virtual Int64 Box(Int16 AValue)
            {
                Int64 Result = 0;

                //Result = PrepareItems();

                this.F_Data = AValue;

                return Result;
            } // public virtual Int64 Box(...)

            public Int16 Unbox()
            {
                Int16 Result = new Int16();
                Result = F_Data;
                return Result;
            } // Int16 Unbox()
        #endregion "methods"
    } // class BoxedInt16Class

    /// <summary>
    /// This static class provides utilities,
    /// for expliciting encapsulating primitive types data,
    /// into object types data.
    /// </summary>
    public static class Boxing
    {
        public static Object FromInt16(Int16 AValue)
        {
            Object Result = null;

            // ...

            return Result;
        } // static Object FromInt16(...)

        public static Object FromString(string AValue)
        {
            Object Result = null;

            // ...

            return Result;
        } // static Object FromString(...)

        public static Object FromDate(DateTime AValue)
        {
            Object Result = null;

            // ...

            return Result;
        } // static Object FromDate(...)

        public static Object FromTime(DateTime AValue)
        {
            Object Result = null;

            // ...

            return Result;
        } // static Object FromTime(...)

        // ...

    } // static class Boxing

    /// <summary>
    /// This static class provides utilities,
    /// for expliciting decapsulating object data,
    /// that formerly was, primitive types data.
    /// </summary>
    public static class Unboxing
    {
        public static Int16 ToInt16(Object AValue)
        {
            Int16 Result = 0;

            // ...

            return Result;
        } // static Object ToInt16(...)

        public static String ToString(Object AValue)
        {
            String Result = "";

            // ...

            return Result;
        } // static Object ToString(...)

        public static String ToDate(Object AValue)
        {
            String Result = "";

            // ...

            return Result;
        } // static Object ToDate(...)

        public static String ToTime(Object AValue)
        {
            String Result = "";

            // ...

            return Result;
        } // static Object ToTime(...)

        // ...
    } // static class Unboxing

} // namespace
