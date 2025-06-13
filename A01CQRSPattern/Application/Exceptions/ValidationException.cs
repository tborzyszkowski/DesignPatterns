using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    class ValidationException : Exception
    {
        public ValidationException() : base()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
