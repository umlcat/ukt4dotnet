using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace romo.shared.collections
{
    public class NamedTreeNodeClass<DataType> : TreeNodeClass<DataType>
    {
        #region "properties"
            private String _Name;
            /// <summary>
            /// Access the identifier of the node.
            /// </summary>
            public String Name
            {
                get
                {
                    return _Name;
                }

                set
                {
                    _Name = value;
                }
            }
        #endregion "properties"

        #region "methods"
            public override string ToString()
            {
                string Result = this.Name;
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

    } // class NamedTreeNodeClass

    // ...

} // namespace