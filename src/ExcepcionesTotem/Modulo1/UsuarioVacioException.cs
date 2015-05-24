using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class UsuarioVacioException : ExceptionTotem
    {
      public UsuarioVacioException()
            : base()
        { }

        public UsuarioVacioException(string message)
            : base(message)
        {
        }

        public UsuarioVacioException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public UsuarioVacioException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

}


    }

