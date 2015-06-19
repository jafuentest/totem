using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class RequerimientoInvalidoException : ExceptionTotem
    {
        public RequerimientoInvalidoException() : base()
	   {
	   }

	   public RequerimientoInvalidoException(string message)
		  : base(message)
	   {
	   }

	   public RequerimientoInvalidoException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public RequerimientoInvalidoException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
