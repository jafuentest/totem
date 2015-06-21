using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ConsultarActoresComandoException : ExcepcionesTotem.ExceptionTotem
    {
        public ConsultarActoresComandoException()
            : base()
        { }

        public ConsultarActoresComandoException(string message)
            : base(message)
        {
        }

        public ConsultarActoresComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarActoresComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
