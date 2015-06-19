using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class RequerimientoNoModificadoException : ExceptionTotem
    {
	   public RequerimientoNoModificadoException() : base()
	   {
	   }

	   public RequerimientoNoModificadoException(string message)
		  : base(message)
	   {
	   }

	   public RequerimientoNoModificadoException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

	   public RequerimientoNoModificadoException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
