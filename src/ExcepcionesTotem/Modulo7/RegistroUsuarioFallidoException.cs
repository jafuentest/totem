using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class RegistroUsuarioFallidoException:ExceptionTotem
    {
         public RegistroUsuarioFallidoException()
            : base()
        { }

        public RegistroUsuarioFallidoException(string message)
            : base(message)
        {
        }

        public RegistroUsuarioFallidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RegistroUsuarioFallidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
