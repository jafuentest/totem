using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo8.ExcepcionesDeDatos
{
    public class AtributoIncorrectoException: ExceptionTotem
    {
        public AtributoIncorrectoException()
            : base() 
        {
        }

        public AtributoIncorrectoException(string message)
            : base(message)
        {
        }

        public AtributoIncorrectoException(string message, Exception inner)
            : base(message)
        {
        }

        public AtributoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
