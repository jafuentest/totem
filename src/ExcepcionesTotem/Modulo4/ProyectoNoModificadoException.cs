using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
   public class ProyectoNoModificadoException : ExceptionTotem
    {
       public ProyectoNoModificadoException()
		  : base()
	   {
	   }
	   public ProyectoNoModificadoException(string message)
		  : base(message)
	   {
	   }
	   public ProyectoNoModificadoException(string message, Exception inner)
		  : base(message, inner)
	   {
	   }
       public ProyectoNoModificadoException(string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
