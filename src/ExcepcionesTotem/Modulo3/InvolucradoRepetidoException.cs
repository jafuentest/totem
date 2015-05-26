using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class InvolucradoRepetidoException : ExceptionTotem
    {
        public InvolucradoRepetidoException()
            : base()
        { }

        public InvolucradoRepetidoException(string message)
            : base(message)
        {
        }

        public InvolucradoRepetidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvolucradoRepetidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }


}

