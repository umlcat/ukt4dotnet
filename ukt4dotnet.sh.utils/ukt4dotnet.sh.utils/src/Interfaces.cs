using System;
using System.Collections.Generic;
using System.Text;

namespace romo.shared.utilities.Interfaces
{
    /// <summary>
    /// Se utiliza que los controles tengan un metodo "nulo",
    /// No confundir con el valor <code>null</code>.
    /// Aunque no se hace nada, la sintaxis ayuda a depurar codigo.
    /// </summary>
    public interface IDoNothing
    {
        /* public nonvirtual */
        void DoNothing();
    } // interface IDoNothing

    public interface ModuleInterface : IDoNothing
    {
        /* public virtual */
        void start(object Params);
        /* public virtual */
        void finish(object Params);

        /* public nonvirtual */
        void Start(object Params);   /* { this.start(Params); }*/
        /* public nonvirtual */
        void Finish(object Params);  /* { this.start(Params); }*/
    } // interface ModuleInterface

    // ...

} // namespace
