using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class ListaSinInvolucradosException : ExceptionTotem
    {
        public ListaSinInvolucradosException()
            : base()
        { }

        public ListaSinInvolucradosException(string message)
            : base(message)
        {
        }

        public ListaSinInvolucradosException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaSinInvolucradosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
