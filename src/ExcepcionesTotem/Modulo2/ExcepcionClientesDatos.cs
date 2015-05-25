using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
   
    class ExcepcionClientesDatos : ExceptionTotem
    {
         public ExcepcionClientesDatos() : base()
        { }
   
        
        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

             public ExcepcionClientesDatos(string message)
            : base(message)
        {
        }

        
              public ExcepcionClientesDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

              public ExcepcionClientesDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


        
           

 
}
