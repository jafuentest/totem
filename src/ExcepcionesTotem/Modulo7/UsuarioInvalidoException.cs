using System;

namespace ExcepcionesTotem.Modulo7
{
	public class UsuarioInvalidoException : ExceptionTotem
	{
		public UsuarioInvalidoException() : base() { }

		public UsuarioInvalidoException(string message) : base(message) { }

		public UsuarioInvalidoException(string message, Exception inner) : base(message, inner) { }

		public UsuarioInvalidoException(string codigo, string msg, Exception inner) : base (codigo, msg, inner) { }
	}
}
