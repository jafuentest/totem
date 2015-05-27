using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class ErrorEnvioDeCorreoException : ExceptionTotem
    {
        public ErrorEnvioDeCorreoException()
            : base()
        { }

        public ErrorEnvioDeCorreoException(string message)
            : base(message)
        {
        }

        public ErrorEnvioDeCorreoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorEnvioDeCorreoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
