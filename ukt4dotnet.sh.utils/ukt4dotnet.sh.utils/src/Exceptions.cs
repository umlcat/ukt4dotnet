using System;
using System.Text;

namespace romo.shared.utilities
{
    /// <summary>
    /// Clase que permite encapsular una excepcion,
    /// proporcionando un "pseudodestructor".
    /// </summary>
    public class DisposableException: Exception, IDisposable
    {
        protected bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // It is safe to access other objects here.
                }

                //Console.WriteLine("Cleaning up object");
                disposed = true;
            }
        } // public void Dispose(...)

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } // public void Dispose(...)

        #region "constructor"
            public DisposableException(Exception NewInnerException):
              base("", NewInnerException)
            {
                //InitializeComponent();
            }
        #endregion "constructor"

    } // class DisposableException

} // namespace
