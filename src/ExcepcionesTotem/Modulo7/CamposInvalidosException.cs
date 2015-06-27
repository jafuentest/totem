using System;

namespace ExcepcionesTotem.Modulo7
{
	public class CamposInvalidosUsuarioException : ExceptionTotem
	{
		public CamposInvalidosUsuarioException() : base() { }

		public CamposInvalidosUsuarioException(string message) : base(message) { }

		public CamposInvalidosUsuarioException(string message, Exception inner) : base(message, inner) { }

		public CamposInvalidosUsuarioException(string codigo, string message, Exception inner) : base(codigo, message, inner) { }
	}
}
