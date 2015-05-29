using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class InvolucradosInexistentesException : ExceptionTotem
    {
        public InvolucradosInexistentesException()
            : base()
        { }

        public InvolucradosInexistentesException(string message)
            : base(message)
        { }

        public InvolucradosInexistentesException(string message, Exception inner)
            : base(message, inner)
        { }

        public InvolucradosInexistentesException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
