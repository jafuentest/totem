using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
	public class UsuarioNoModificadoException : ExceptionTotem
	{
		public UsuarioNoModificadoException() : base() { }

		public UsuarioNoModificadoException(string message) : base(message) { }

		public UsuarioNoModificadoException(string message, Exception inner) : base(message, inner) { }

		public UsuarioNoModificadoException(string codigo, string msg, Exception inner) : base(codigo, msg, inner) { }
	}
}
