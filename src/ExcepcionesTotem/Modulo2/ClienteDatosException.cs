using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{

   public class ClienteDatosException : ExceptionTotem
    {
        public ClienteDatosException()
            : base()
        { }


        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

        public ClienteDatosException(string message)
            : base(message)
        {
        }


        public ClienteDatosException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ClienteDatosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }



    }
           

 
}
