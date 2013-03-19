using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using romo.shared.objects;

namespace romo.shared.collections
{
    public class KeyValueTreeNodeClass<DataType> : TreeNodeClass<DataType> 
    {
        #region "properties"
            private String _Key;
            /// <summary>
            /// Access the key identifier of the node.
            /// </summary>
            public String Key
            {
                get
                {
                    return _Key;
                }

                set
                {
                    _Key = value;
                }
            }

            private String _Value;
            /// <summary>
            /// Access the main data value of the node.
            /// </summary>
            public String Value
            {
                get
                {
                    return _Value;
                }

                set
                {
                    _Value = value;
                }
            }
        #endregion "properties"

        #region "methods"
            public override string ToString()
            {
                string Result = "";

                string Template = "key: \"{0}\", value: \"{1}\",";
                Result = String.Format(Template, this.Key, this.Value);

                return Result;
            } // string ToString(...)

            public override String AbsolutePath()
            {
                String Result = "";

                // to-do:

                return Result;
            } // String AbsolutePath(...)

            // ...

        #endregion "methods"

        // ...

    } // class KeyValueTreeNodeClass

    // ...

} // namespace