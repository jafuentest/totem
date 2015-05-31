using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class ProyectoNoEncontradoException : ExceptionTotem
    {
	   public ProyectoNoEncontradoException() : base()
	   {
	   }

	   public ProyectoNoEncontradoException(string message)
		  : base(message)
	   {
	   }

	   public ProyectoNoEncontradoException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

	   public ProyectoNoEncontradoException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }

    }

}
