using System;
using System.Collections.Generic;
using System.Text;
using ukt4dotnet.shared.objects;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.utilities.InterfacesSupport
{
    public class InterfaceID : ObjectClass
    {
        protected int _ID = 0;

        #region "constructor"
        public virtual Int64 createbyID(int AID)
        {
            Int64 Result = 0;

            this._ID = AID;

            return Result;
        } // public virtual Int64 createbyID(...)
        #endregion "constructor"

        #region "methods"

        public int ID()
        {
            int Result = this._ID;

            return Result;
        } // public int ID(...)

        #endregion "methods"

    } // class InterfaceID

    /// <summary>
    /// This class is used for cross-platform compatibility,
    /// for programming languages that doesn't support,
    /// interfaces directly.
    /// </summary>
    public class InterfaceClass : ObjectClass
    {
        #region "methods"
            public override Int64 Create()
            {
                Int64 Result = 0;
                this.DoNothing();
                return Result;
            } // Int64 Create(...)
            public override Int64 Destroy()
            {
                Int64 Result = 0;
                this.DoNothing();
                return Result;
            } // Int64 Destroy(...)

            public virtual bool IsImplemented(InterfaceID AID)
            {
                bool Result = false;

                this.DoNothing();

                return Result;
            } // public virtual bool IsImplemented(...)

            public virtual object implementedAs(InterfaceID AID)
            {
                object Result = null;

                this.DoNothing();

                return Result;
            } // public virtual object implementedAs(...)

            public virtual void registerInterface(InterfaceID AID)
            {
                this.DoNothing();
            } // public virtual void registerInterface(...)

        #endregion "methods"

        #region "query-methods"

            /// <summary>
            /// Prepare class to be queried for interfaces
            /// </summary>
            public virtual void startQuery()
            {
                this.DoNothing();
            } // public virtual void startQuery(...)

            /// <summary>
            /// Return next interface identifier.
            /// </summary>
            /// <param name="AID"></param>
            /// <returns></returns>
            public virtual bool nextQuery(ref InterfaceID AID)
            {
                bool Result = false;

                this.DoNothing();

                return Result;
            } // public virtual bool nextQuery(...)

            /// <summary>
            /// UnPrepare class after been queried for interfaces
            /// </summary>
            public virtual void finishQuery()
            {
                this.DoNothing();
            } // public virtual void finishQuery(...)

        #endregion "query-methods"

    } // class InterfaceClass

} // namespace
