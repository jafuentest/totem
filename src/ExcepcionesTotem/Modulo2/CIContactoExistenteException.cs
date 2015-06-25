using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
    public class CIContactoExistenteException : ExceptionTotem
    {
       public CIContactoExistenteException() : base()
	   {
	   }

	   public CIContactoExistenteException(string message)
		  : base(message)
	   {
	   }

	   public CIContactoExistenteException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public CIContactoExistenteException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
