using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class ContactoSinIDException : ExceptionTotem
    {
        public ContactoSinIDException()
            : base()
        { }

        public ContactoSinIDException(string message)
            : base(message)
        {
        }

        public ContactoSinIDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ContactoSinIDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
