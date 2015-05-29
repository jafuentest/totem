using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class RequerimientosInexistentesException : ExceptionTotem
    {
        public RequerimientosInexistentesException()
            : base()
        { }

        public RequerimientosInexistentesException(string message)
            : base(message)
        { }

        public RequerimientosInexistentesException(string message, Exception inner)
            : base(message, inner)
        { }

        public RequerimientosInexistentesException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
