using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class InvalidVersionException : Exception
    {
        public InvalidVersionException()
            : base()
        {
        }

        public InvalidVersionException(string message)
            : base(message)
        {
        }

        public InvalidVersionException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
