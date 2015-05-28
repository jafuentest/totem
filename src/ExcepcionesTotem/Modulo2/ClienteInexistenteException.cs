using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem; 

namespace ExcepcionesTotem.Modulo2
{
   public class ClienteInexistenteException: ExceptionTotem
    {
       public ClienteInexistenteException()
            : base()
        { }

        public ClienteInexistenteException(string message)
            : base(message)
        {
        }

        public ClienteInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ClienteInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
