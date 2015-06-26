using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
    public class CasoDeUsoInvalidoException : ExcepcionesTotem.ExceptionTotem
    {
        public CasoDeUsoInvalidoException()
            : base()
        { }

        public CasoDeUsoInvalidoException(string message)
            : base(message)
        {
        }

        public CasoDeUsoInvalidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CasoDeUsoInvalidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
