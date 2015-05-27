using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class UsuarioSinUsernameException : ExceptionTotem
    {
        public UsuarioSinUsernameException()
            : base()
        { }

        public UsuarioSinUsernameException(string message)
            : base(message)
        {
        }

        public UsuarioSinUsernameException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public UsuarioSinUsernameException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
