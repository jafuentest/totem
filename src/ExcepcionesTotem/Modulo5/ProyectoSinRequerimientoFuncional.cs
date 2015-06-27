using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class ProyectoSinRequerimientoFuncional : ExceptionTotem
    {
        public ProyectoSinRequerimientoFuncional() : base()
	   {
	   }

	   public ProyectoSinRequerimientoFuncional(string message)
		  : base(message)
	   {
	   }

	   public ProyectoSinRequerimientoFuncional(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public ProyectoSinRequerimientoFuncional(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
