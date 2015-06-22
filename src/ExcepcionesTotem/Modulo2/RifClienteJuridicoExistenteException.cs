using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    public class RifClienteJuridicoExistenteException  : ExceptionTotem
    {
        public RifClienteJuridicoExistenteException() : base()
	    {
	    }

	   public RifClienteJuridicoExistenteException(string message)
		  : base(message)
	   {
	   }

	   public RifClienteJuridicoExistenteException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public RifClienteJuridicoExistenteException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
