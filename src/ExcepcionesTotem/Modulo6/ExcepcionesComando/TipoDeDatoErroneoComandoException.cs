using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class TipoDeDatoErroneoComandoException : ExcepcionesTotem.ExceptionTotem
    {
        public TipoDeDatoErroneoComandoException()
            : base()
        { }

        public TipoDeDatoErroneoComandoException(string message)
            : base(message)
        {
        }

        public TipoDeDatoErroneoComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TipoDeDatoErroneoComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
