using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
   public class OperacionInvalidaException:ExceptionTotem
    {
       
        public OperacionInvalidaException()
            : base()
        { }


        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

        public OperacionInvalidaException(string message)
            : base(message)
        {
        }


        public OperacionInvalidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OperacionInvalidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
