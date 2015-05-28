using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    class ExcepcionContactosDatos : ExceptionTotem
    {
        public ExcepcionContactosDatos()
            : base()
        { }


        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

        public ExcepcionContactosDatos(string message)
            : base(message)
        {
        }


        public ExcepcionContactosDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionContactosDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }



    }
}
