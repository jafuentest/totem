using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo3
{
    public class ProyectoSinCodigoException : ExceptionTotem
    {
        public ProyectoSinCodigoException()
            : base()
        { }

        public ProyectoSinCodigoException(string message)
            : base(message)
        {
        }

        public ProyectoSinCodigoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ProyectoSinCodigoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
