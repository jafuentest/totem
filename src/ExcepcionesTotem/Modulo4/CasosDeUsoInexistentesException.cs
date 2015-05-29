using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class CasosDeUsoInexistentesException : ExceptionTotem
    {
        public CasosDeUsoInexistentesException()
            : base()
        { }

        public CasosDeUsoInexistentesException(string message)
            : base(message)
        { }

        public CasosDeUsoInexistentesException(string message, Exception inner)
            : base(message, inner)
        { }
        public CasosDeUsoInexistentesException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
