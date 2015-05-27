using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class CorreoRepetidoException : ExceptionTotem
    {
        public CorreoRepetidoException()
            : base()
        { }

        public CorreoRepetidoException(string message)
            : base(message)
        {
        }

        public CorreoRepetidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CorreoRepetidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
