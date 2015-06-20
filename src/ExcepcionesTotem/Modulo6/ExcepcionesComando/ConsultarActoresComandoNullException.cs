using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ConsultarActoresComandoNullException : ExcepcionesTotem.ExceptionTotem
    {
        public ConsultarActoresComandoNullException()
            : base()
        { }

        public ConsultarActoresComandoNullException(string message)
            : base(message)
        {
        }

        public ConsultarActoresComandoNullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarActoresComandoNullException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
