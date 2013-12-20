using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class DBIOException : Exception
    {
        public DBIOException()
            : base()
        {
        }

        public DBIOException(string message)
            : base(message)
        {
        }

        public DBIOException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
