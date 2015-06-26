using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
   public class ArchivoInexistenteException:ExcepcionesTotem.ExceptionTotem
    {
        public ArchivoInexistenteException()
            : base()
	   {
	   }

	   public ArchivoInexistenteException(string message)
		  : base(message)
	   {
	   }

	   public ArchivoInexistenteException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public ArchivoInexistenteException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
