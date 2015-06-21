using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
   public class ComandoBDException:ExcepcionesTotem.ExceptionTotem
    {
        public ComandoBDException()
            : base()
        { }

        public ComandoBDException(string message)
            : base(message)
        {
        }

        public ComandoBDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ComandoBDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
