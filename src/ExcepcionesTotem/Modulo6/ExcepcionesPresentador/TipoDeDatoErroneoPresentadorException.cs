using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
    public class TipoDeDatoErroneoPresentadorException : ExcepcionesTotem.ExceptionTotem
    {
        public TipoDeDatoErroneoPresentadorException()
            : base()
        { }

        public TipoDeDatoErroneoPresentadorException(string message)
            : base(message)
        {
        }

        public TipoDeDatoErroneoPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TipoDeDatoErroneoPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
