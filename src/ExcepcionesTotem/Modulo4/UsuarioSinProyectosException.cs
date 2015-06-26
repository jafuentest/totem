using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo4
{
    public class UsuarioSinProyectosException : ExceptionTotem
    {
	   public UsuarioSinProyectosException()
		  : base()
        {
	   }
        public UsuarioSinProyectosException(string message)
            : base(message)
        {
	   }
        public UsuarioSinProyectosException(string message, Exception inner)
            : base(message, inner)
        {
	   }
	   public UsuarioSinProyectosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
