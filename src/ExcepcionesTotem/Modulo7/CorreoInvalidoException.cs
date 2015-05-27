using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class CorreoInvalidoException : ExceptionTotem
    {
        public CorreoInvalidoException()
            : base()
        { }

        public CorreoInvalidoException(string message)
            : base(message)
        {
        }

        public CorreoInvalidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CorreoInvalidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
