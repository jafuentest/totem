using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class RequerimientoNoEliminadoException : ExceptionTotem
    {
	   public RequerimientoNoEliminadoException() : base()
	   {
	   }

	   public RequerimientoNoEliminadoException(string message)
		  : base(message)
	   {
	   }

	   public RequerimientoNoEliminadoException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

	   public RequerimientoNoEliminadoException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
