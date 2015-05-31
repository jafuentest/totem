using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class CompilarTexException : ExceptionTotem
    {
        public CompilarTexException()
            : base()
        { }

        public CompilarTexException(string message)
            : base(message)
        { }

        public CompilarTexException(string message, Exception inner)
            : base(message, inner)
        { }
        public CompilarTexException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
