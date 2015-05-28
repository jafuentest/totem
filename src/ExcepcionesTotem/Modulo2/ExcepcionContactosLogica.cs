using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    class ExcepcionContactosLogica : ExceptionTotem
    {
        public ExcepcionContactosLogica()
            : base()
        { }


        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

        public ExcepcionContactosLogica(string message)
            : base(message)
        {
        }


        public ExcepcionContactosLogica(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionContactosLogica(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }



    }
}
