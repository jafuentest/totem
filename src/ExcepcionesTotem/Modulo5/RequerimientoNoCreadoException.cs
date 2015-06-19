using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class RequerimientoNoCreadoException : ExceptionTotem
    {
	   public RequerimientoNoCreadoException() : base()
	   {
	   }

	   public RequerimientoNoCreadoException(string message)
		  : base(message)
	   {
	   }

	   public RequerimientoNoCreadoException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

	   public RequerimientoNoCreadoException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
