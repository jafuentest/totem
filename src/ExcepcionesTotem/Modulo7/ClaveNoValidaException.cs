using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class ClaveNoValidaException : ExceptionTotem
    {
         public ClaveNoValidaException()
            : base()
        { }

        public ClaveNoValidaException(string message)
            : base(message)
        {
        }

        public ClaveNoValidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ClaveNoValidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
