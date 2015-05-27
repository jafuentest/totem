using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class UserNameRepetidoException : ExceptionTotem
    {
         public UserNameRepetidoException()
            : base()
        { }

        public UserNameRepetidoException(string message)
            : base(message)
        {
        }

        public UserNameRepetidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public UserNameRepetidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
