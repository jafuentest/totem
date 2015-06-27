using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class ProyectoSinRequerimientoNoFuncional : ExceptionTotem
    {
        public ProyectoSinRequerimientoNoFuncional() : base()
	   {
	   }

	   public ProyectoSinRequerimientoNoFuncional(string message)
		  : base(message)
	   {
	   }

	   public ProyectoSinRequerimientoNoFuncional(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public ProyectoSinRequerimientoNoFuncional(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
