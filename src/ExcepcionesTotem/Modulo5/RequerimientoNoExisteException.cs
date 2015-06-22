using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class RequerimientoNoExisteException : ExceptionTotem
    {
        public RequerimientoNoExisteException() : base()
	   {
	   }

	   public RequerimientoNoExisteException(string message)
		  : base(message)
	   {
	   }

	   public RequerimientoNoExisteException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public RequerimientoNoExisteException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
