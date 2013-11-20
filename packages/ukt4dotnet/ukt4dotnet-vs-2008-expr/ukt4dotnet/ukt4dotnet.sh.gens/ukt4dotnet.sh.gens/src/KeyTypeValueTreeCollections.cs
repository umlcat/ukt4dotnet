using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using ukt4dotnet.shared.objects;

namespace ukt4dotnet.shared.collections
{
    public class KeyTypeValueTreeNodeClass<DataType> : KeyValueTreeNodeClass<DataType>
    {
        #region "properties"
            private String _Type;
            /// <summary>
            /// Access the type identifier of the node.
            /// </summary>
            public String Type
            {
                get
                {
                    return _Type;
                }

                set
                {
                    _Type = value;
                }
            }
        #endregion "properties"

        #region "methods"
            public override string ToString()
            {
                string Result = "";

                string Template = "key: \"{0}\", type: \"{1}\", value: \"{2}\"";
                Result = String.Format(Template, this.Key, this.Type, this.Value);

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

    } // class KeyTypeValueTreeNodeClass

    // ...

} // namespace