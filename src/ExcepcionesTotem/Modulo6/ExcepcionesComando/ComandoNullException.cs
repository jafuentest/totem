using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ComandoNullException:ExceptionTotem
    {
        
        public ComandoNullException()
            : base()
        { }

        public ComandoNullException(string message)
            : base(message)
        {
        }

        public ComandoNullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ComandoNullException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
