using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class ListaSinProyectoException : ExceptionTotem
    {
        public ListaSinProyectoException()
            : base()
        { }

        public ListaSinProyectoException(string message)
            : base(message)
        {
        }

        public ListaSinProyectoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaSinProyectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
