using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
   public class ComandoException:ExceptionTotem
    {
       
        public ComandoException()
            : base()
        { }

        public ComandoException(string message)
            : base(message)
        {
        }

        public ComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
