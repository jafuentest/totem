using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class CrearArchivoException : ExceptionTotem
    {
        public CrearArchivoException()
            : base()
        { }

        public CrearArchivoException(string message)
            : base(message)
        { }

        public CrearArchivoException(string message, Exception inner)
            : base(message, inner)
        { }
        public CrearArchivoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
