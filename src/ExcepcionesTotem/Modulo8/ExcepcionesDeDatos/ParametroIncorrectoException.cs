using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo8.ExcepcionesDeDatos
{
    public class ParametroIncorrectoException: ExceptionTotem
    {
        public ParametroIncorrectoException()
            : base()
        {
        }

        public ParametroIncorrectoException(string message)
            : base(message)
        {
        }

        public ParametroIncorrectoException(string message, Exception inner)
            : base(message)
        {
        }

        public ParametroIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
