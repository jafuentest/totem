using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    public class ContactoInexistenteException : ExceptionTotem
    { 
        public ContactoInexistenteException()
            : base()
        { 
        }

        public ContactoInexistenteException(string message)
            : base(message)
        {
        }

        public ContactoInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ContactoInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
