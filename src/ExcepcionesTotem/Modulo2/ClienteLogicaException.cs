using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExcepcionesTotem.Modulo2
{
   public class ClienteLogicaException : ExceptionTotem
    {
         public ClienteLogicaException() : base()
        { }
   
        
        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

             public ClienteLogicaException(string message)
            : base(message)
        {
        }

        
              public ClienteLogicaException(string message, Exception inner)
            : base(message, inner)
        {
        }

              public ClienteLogicaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


        
           

          
   
    }
}
