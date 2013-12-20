using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class CheckOutException : Exception
    {
        public CheckOutException()
            : base()
        {
        }

        public CheckOutException(string message)
            : base(message)
        {
        }

        public CheckOutException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
