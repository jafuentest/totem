using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class CodigoRepetidoException : ExceptionTotem
    {
        public CodigoRepetidoException()
            : base()
        { }

        public CodigoRepetidoException(string message)
            : base(message)
        { }

        public CodigoRepetidoException(string message, Exception inner)
            : base(message, inner)
        { }

        public CodigoRepetidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
