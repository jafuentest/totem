﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;

namespace ExcepcionesTotem.Modulo2
{
    public class CIClienteNatExistenteException : ExceptionTotem
    {
       public CIClienteNatExistenteException() : base()
	   {
	   }

	   public CIClienteNatExistenteException(string message)
		  : base(message)
	   {
	   }

	   public CIClienteNatExistenteException(string message,
		  Exception inner)
		  : base(message, inner)
	   {
	   }

       public CIClienteNatExistenteException(
		  string codigo, string message, Exception inner)
		  : base(codigo, message, inner)
	   {
	   }
    }
}
