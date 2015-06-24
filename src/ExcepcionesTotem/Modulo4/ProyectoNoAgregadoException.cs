using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class ProyectoNoAgregadoException : ExceptionTotem
    {
	   public ProyectoNoAgregadoException()
		  : base()
	   {
	   }
	   public ProyectoNoAgregadoException(string message)
		  : base(message)
	   {
	   }
	   public ProyectoNoAgregadoException(string message, Exception inner)
		  : base(message, inner)
	   {
	   }
	   public ProyectoNoAgregadoException(string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
