using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo5
{
    public class CamposInvalidosException: ExceptionTotem
    {
        public CamposInvalidosException() : base()
	   {
	   }

	   public CamposInvalidosException(string message)
		  : base(message)
	   {
	   }

	   public CamposInvalidosException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public CamposInvalidosException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
