using System;
using System.Collections.Generic;
using System.Text;
using romo.shared.utilities.Interfaces;

namespace romo.shared.objects
{
    /// <summary>
    /// Sirve para reemplazar el constructor de la clase,
    /// que tiene el mismo identificador que la clase,
    /// por un solo identificador que sera el mismo para toda una
    /// jerarquia de clases.
    /// Tambien, sirve para agregar un metodo que funciona como destructor,
    /// que tiene el mismo identificador, para toda una jerarquia de clases.
    /// Ventajas:
    /// <ul>
    /// <li>Usar identificador explicito para el constructor, sin usar nombre de clase</li> 
    /// <li>Usar identificador explicito para el destructor, sin usar nombre de clase</li> 
    /// <li>Agrega constructor virtual, como requisito</li> 
    /// <li>Agrega destructor virtual, como requisito</li> 
    /// </ul> 
    /// </summary>
    public interface NormalizedObjectInterface : IDoNothing
    {
        /* public virtual */
        Int64 Create();
        /* public virtual */
        Int64 Destroy();
    } // interface NormalizedObjectInterface

    public interface NormalizedObjectInterfaceParams : NormalizedObjectInterface
    {
        /* public virtual */
        Int64 createParams(object Params);
        /* public virtual */
        Int64 destroyParams(object Params);

        /* public nonvirtual */
        Int64 CreateParams(object Params);   /* { this.createparams(Params); }*/
        /* public nonvirtual */
        Int64 DestroyParams(object Params);  /* { this.destroyparams(Params); }*/

        /* public nonvirtual */
        Int64 createparams(object Params);   /* { this.createparams(Params); }*/
        /* public nonvirtual */
        Int64 destroyparams(object Params);  /* { this.destroyparams(Params); }*/
    } // interface NormalizedObjectInterfaceParams

    /// <summary>
    /// Sirve para reemplazar el constructor de la clase,
    /// que tiene el mismo identificador que la clase,
    /// por un solo identificador que sera el mismo para toda una
    /// jerarquia de clases.
    /// Tambien, sirve para agregar un metodo que funciona como destructor,
    /// que tiene el mismo identificador, para toda una jerarquia de clases.
    /// Ventajas:
    /// <ul>
    /// <li>Usar identificador explicito para el constructor, sin usar nombre de clase</li> 
    /// <li>Usar identificador explicito para el destructor, sin usar nombre de clase</li> 
    /// <li>Agrega constructor virtual, como requisito</li> 
    /// <li>Agrega destructor virtual, como requisito</li> 
    /// </ul>
    /// Ademas, se mantiene por compatibilidad de bibliotecas,
    /// en otros lenguajes de programacion.
    /// Se pueden agregar, tanto, constructores virtuales adicionales,
    /// como destructores virtuales adicionales, con una lista de parametros diferentes,
    /// se recomienda, que tengan un identificador distinto a,
    /// <code>create();</code> y <code>destroy();</code>
    /// </summary>
    public class ObjectClass : NormalizedObjectInterface
    {
        #region "support"
            private bool F_ObjectClass_IsReady;

            /// <summary>
            /// Utilizar el metodo virtual<code>create()</code>,
            /// en vez del constructor.
            /// </summary>
            public ObjectClass()
            {
                // --> clear status
                F_ObjectClass_IsReady = false;
                
                // --> clear fields
                // ...
            } // ObjectClass()

            /// <summary>
            /// Utilizar el metodo virtual<code>destroy()</code>,
            /// en vez del constructor.
            /// </summary>
            ~ObjectClass()
            {
                // "Destroy" was not called
                if (F_ObjectClass_IsReady)
                {
                    this.Destroy();
                }

                // --> clear status
                F_ObjectClass_IsReady = false;
            } // ~ObjectClass()
        #endregion "support"

        #region "constructors"
            /// <summary>
            /// Usese de forma similar a un metodo constructor, virtual, por-de-facto.
            /// El verdadero metodo constructor, debe ejecutarse sin parametros,
            /// y no debe ejecutar codigo alguno.
            /// Ejemplo:
            /// <code>
            /// ObjectClass MyObject = new ObjectClass();
            /// MyObject.create();
            /// // ...
            /// MyObject.destroy();
            /// MyObject = null;
            /// </code>
            /// <returns><code>0</code> if ok.</returns>
            /// </summary>
            public virtual Int64 Create()
            {
                Int64 Result = 0;

                // --> update status
                F_ObjectClass_IsReady = true;

                return Result;
            } // public virtual Int64 Create(...)

            /// <summary>
            /// Usese de forma similar a un metodo destructor, virtual, por-de-facto.
            /// El verdadero metodo destructor, debe ejecutarse sin parametros,
            /// y no debe ejecutar codigo alguno.
            /// Ejemplo:
            /// <code>
            /// ObjectClass MyObject = new ObjectClass();
            /// MyObject.create();
            /// // ...
            /// MyObject.destroy();
            /// MyObject = null;
            /// </code>
            /// </summary>
            public virtual Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_ObjectClass_IsReady = false;

                return Result;
            } // public virtual Int64 Destroy(...)
        #endregion "constructors"

        #region "methods"
            /// <summary>
            /// If the instantiated two-phase-initialization,
            /// object, is fully constructed, at the current class.
            /// </summary>
            /// <returns>Is object constructed.</returns>
            public virtual bool IsReady()
            {
                bool Result = F_ObjectClass_IsReady;
                return Result;
            } // bool IsReady(...)

            /* public nonvirtual */
            public void DoNothing()
            {
                // does nothing on purpose !!!
            } // void DoNothing(...)

            /// <summary>
            /// Mismo objetivo que el metodo <code>ToString</code>, se mantiene,
            /// por compatibilidad con otros lenguajes de programacion,
            /// y bibliotecas similares.
            /// </summary>
            /// <returns></returns>
            /* public nonvirtual */
            public string ToText()
            {
                string Result = this.ToText();
                return Result;
            } // string ToText(...)

            /// <summary>
            /// Usar o reemplazar <code>totext</code>,
            /// por compatibilidad con otros lenguajes de programacion,
            /// y bibliotecas similares.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                string Result = "ObjectClass";
                return Result;
            } // string ToString(...)

        #endregion "methods"

        #region "static"
            // ...

            /// <summary>
            /// Construye un nuevo objeto de la clase <code>ObjectClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            public static ObjectClass Factory()
            {
                ObjectClass Result = new ObjectClass();
                Result.Create();

                return Result;
            } // static ObjectClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>ObjectClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            public static void Disposer(ref ObjectClass AObject)
            {
                if (AObject != null)
                {
                    AObject.Destroy();
                    AObject = null;
                } // if (AObject != null)
            } // public static void Disposer(...)

            // ...
        #endregion "static"

        // ...

    } // class ObjectClass

    /// <summary>
    /// Its a class that supports copy operations,
    /// while maintaining the features of the <code>ObjectClass<code>.
    /// The methods allows to detect when an explict copy is required,
    /// instead of just a reference.
    /// </summary>
    public class CloneableObjectClass : ObjectClass
    {
        #region "support"
            private bool F_CloneableObjectClass_IsReady;
        
            public CloneableObjectClass() : base()
            {
                // --> clear status
                F_CloneableObjectClass_IsReady = false;
            } // CloneableObjectClass()

            ~CloneableObjectClass()
            {
                // "Destroy" was not called
                if (F_CloneableObjectClass_IsReady)
                {
                    this.Destroy();
                }

                // --> clear status
                F_CloneableObjectClass_IsReady = false;
            } // ~CloneableObjectClass()

            public override bool IsReady()
            {
                bool Result = F_CloneableObjectClass_IsReady;
                return Result;
            } // bool IsReady(...)
        #endregion "support"

        #region "constructors"
            // ...

            public override Int64 Create()
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    // ...
                } // if (Result == 0)

                // --> update status
                F_CloneableObjectClass_IsReady = true;

                return Result;
            } // public override Int64 Create(...)

            public override Int64 Destroy()
            {
                Int64 Result = 0;

                // --> update status
                F_CloneableObjectClass_IsReady = true;

                // --> deallocate fields
                if (Result == 0)
                {
                    // ...
                } // if (Result == 0)

                // --> execute inherited destructor
                Result = base.Destroy();

                return Result;
            } // public override Int64 Destroy(...)

            /// <summary>
            /// Constructor that allows to create a object,
            /// as a "shallow" copy of another object.
            /// It maintains, the two-step initialization,
            /// and two step finalization, technique,
            /// with virtual constructors & destructors.
            /// </summary>
            /// <param name="Source">Source object</param>
            /// <returns>Error Code, <code>0<code> if succesful.</returns>
            public virtual Int64 CreateCopy(CloneableObjectClass Source)
            {
                Int64 Result = 0;

                // --> execute inherited constructor
                Result = base.Create();

                // --> allocate fields
                if (Result == 0)
                {
                    // ...
                } // if (Result == 0)

                // --> update status
                F_CloneableObjectClass_IsReady = true;

                // --> special case
                this.AssignFrom(Source);

                return Result;
            } // public virtual Int64 CreateCopy(...)

            // ...
        #endregion "constructors"

        #region "methods"
            // ...

            /// <summary>
            /// Copies all value properties from <code>ASource</code>,
            /// to the current object.
            /// </summary>
            /// <param name="ASource">Object to be used as a template</param>
            public virtual void AssignFrom(CloneableObjectClass ASource)
            {
                this.DoNothing();        
            } // void AssignFrom(...)

            /// <summary>
            /// Copies all value properties from the current object,
            /// to <code>ADest</code>.
            /// </summary>
            /// <param name="ADest"></param>
            public void AssignTo(CloneableObjectClass ADest)
            {
                ADest.AssignFrom(this);        
            } // void AssignTo(...)

            /// <summary>
            /// When an object of this class is instantiated,
            /// creates & returns a "Shallow" copy of itself.
            /// </summary>
            /// <returns>"Shallow" copy of the object.</returns>
            public virtual CloneableObjectClass Clone()
            {
                CloneableObjectClass Result = new CloneableObjectClass();
                Result.Create();

                Result.AssignFrom(this);

                return Result;
            } // CloneableObjectClass Clone(...)

        #endregion "methods"

        #region "static"
			// ...
			
            /// <summary>
            /// Construye un nuevo objeto de la clase <code>ObjectClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// y ejecuta el inicializador virtual, por-de-facto.
            /// Para ejecutar otro inicializador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <returns>Nuevo objeto</returns>
            new public static ObjectClass Factory()
            {
                ObjectClass Result = new ObjectClass();
                Result.Create();

                return Result;
            } // static ObjectClass Factory(...)

            /// <summary>
            /// Desecha objeto de la clase <code>ObjectClass</code>,
            /// que desciende de <code>ObjectClass</code>,
            /// ejecutando el metodo finalizador, por-de-facto.
            /// Para ejecutar otro finalizador,
            /// se tiene que realizar estas operaciones como pasos separados.
            /// </summary>
            /// <param name="AObject">Objeto que se desechara de memoria</param>
            new public static void Disposer(ref ObjectClass AObject)
            {
                if (AObject != null)
                {
                    AObject.Destroy();
                    AObject = null;
                } // if (AObject != null)
            } // public static void Disposer(...)
			
            // ...
        #endregion "static"

    } // class CloneableObjectClass

    // ...

} // namespace
