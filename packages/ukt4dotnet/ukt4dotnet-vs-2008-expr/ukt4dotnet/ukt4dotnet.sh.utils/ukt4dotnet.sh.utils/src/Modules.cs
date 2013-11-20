using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ukt4dotnet.shared.utilities
{
    public abstract class Module
    {
        /// <summary>
        /// I emulate a virtual constructor function,
        /// with meaningful name.
        /// </summary>
        public virtual void start()
        {
            // ...
        } // public virtual void start(...)

        /// <summary>
        /// I emulate a virtual destroy function,
        /// with meaningful name.
        /// </summary>
        public virtual void finish()
        {
            // ...
        } // public virtual void finish(...)
    } // class Module

    public abstract class StaticModule : Module
    {
        /*
        /// <summary>
        /// I emulate a virtual constructor function,
        /// with meaningful name.
        /// </summary>
        public virtual void start()
        {
            // ...
        } // public virtual void start(...)

        /// <summary>
        /// I emulate a virtual destroy function,
        /// with meaningful name.
        /// </summary>
        public virtual void finish()
        {
            // ...
        } // public virtual void finish(...)
        */
    } // class StaticModule

    public abstract class DynamicModule : Module
    {
        /*
        /// <summary>
        /// I emulate a virtual constructor function,
        /// with meaningful name.
        /// </summary>
        public virtual void start()
        {
            // ...
        } // public virtual void start(...)

        /// <summary>
        /// I emulate a virtual destroy function,
        /// with meaningful name.
        /// </summary>
        public virtual void finish()
        {
            // ...
        } // public virtual void finish(...)
        */
    } // class DynamicModule

    public abstract class ProgramModule : Module
    {
        /*
        /// <summary>
        /// I emulate a virtual constructor function,
        /// with meaningful name.
        /// </summary>
        public virtual void start()
        {
            // ...
        } // public virtual void start(...)

        /// <summary>
        /// I emulate a virtual destroy function,
        /// with meaningful name.
        /// </summary>
        public virtual void finish()
        {
            // ...
        } // public virtual void finish(...)
        */
    } // class ProgramModule

} // namespace
