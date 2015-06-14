using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class LoggerException : ExceptionTotem
    {
        public LoggerException()
            : base()
        { }

        public LoggerException(string message)
            : base(message)
        {
        }

        public LoggerException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public LoggerException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
