using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    public class FormatoIncorrectoException : ExceptionTotem
    {
       public FormatoIncorrectoException()
            : base()
        { }


        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

        public FormatoIncorrectoException(string message)
            : base(message)
        {
        }


        public FormatoIncorrectoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
