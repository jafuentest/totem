using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class BorrarArchivoException : ExceptionTotem
    {
        public BorrarArchivoException()
            : base()
        { }

        public BorrarArchivoException(string message)
            : base(message)
        { }

        public BorrarArchivoException(string message, Exception inner)
            : base(message, inner)
        { }
        public BorrarArchivoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
