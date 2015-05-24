using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class EmailErradoException : ExceptionTotem
    {
        public EmailErradoException()
            : base()
        { }

        public EmailErradoException(string message)
            : base(message)
        {
        }

        public EmailErradoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public EmailErradoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }


}

