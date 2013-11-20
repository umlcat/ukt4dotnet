using System;
using ukt4dotnet.shared.utilities;

namespace ukt4dotnet.shared.orm
{
    /// <summary>
    /// Indicates that there is not connection,
    /// when it suppose to be one.
    /// </summary>
    public class ConnectionNotFoundExceptionClass : DisposableException
    {
        // ...

        public ConnectionNotFoundExceptionClass(): base(null)
        {
            // ...
        } // ...

        // ...
    } // class ConnectionNotFoundExceptionClass

    /// <summary>
    /// Indicates that the parameters object was not assigned,
    /// for a query.
    /// </summary>
    public class ParametersNotProvidedExceptionClass : DisposableException
    {
        // ...

        public ParametersNotProvidedExceptionClass()
            : base(null)
        {
            // ...
        } // ...

        // ...
    } // class ParametersNotProvidedExceptionClass

    /// <summary>
    /// Indicates that the table ID., for a single table query,
    /// was not provided.
    /// </summary>
    public class TableNameNotProvidedExceptionClass : DisposableException
    {
        // ...

        public TableNameNotProvidedExceptionClass()
            : base(null)
        {
            // ...
        } // ...

        // ...
    } // class TableNameNotProvidedExceptionClass

    /// <summary>
    /// Indicates that a key fieldname was not provided,
    /// for a query.
    /// </summary>
    public class KeyFieldNameNotAssignedExceptionClass : DisposableException
    {
        // ...

        public KeyFieldNameNotAssignedExceptionClass()
            : base(null)
        {
            // ...
        } // ...

        // ...
    } // class KeyFieldNameNotAssignedExceptionClass

    /// <summary>
    /// Indicates that the value that identifies,
    /// the default, or null, record,
    /// for a query, was not provided.
    /// </summary>
    public class DefaultKeyValueNotAssignedExceptionClass : DisposableException
    {
        // ...

        public DefaultKeyValueNotAssignedExceptionClass()
            : base(null)
        {
            // ...
        } // ...

        // ...
    } // class DefaultKeyValueNotAssignedExceptionClass

} // namespace ukt4dotnet.shared.orm
