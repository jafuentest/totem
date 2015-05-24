using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class CodigoRepetidoException : ExceptionTotem
    {
        public CodigoRepetidoException()
            : base()
        { }

        public CodigoRepetidoException(string message)
            : base(message)
        { }

        public CodigoRepetidoException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
