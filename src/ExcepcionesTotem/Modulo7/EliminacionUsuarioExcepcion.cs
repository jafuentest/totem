using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    public class EliminacionUsuarioExcepcion: ExceptionTotem
    {
         public EliminacionUsuarioExcepcion()
            : base()
        { }

        public EliminacionUsuarioExcepcion(string message)
            : base(message)
        {
        }

        public EliminacionUsuarioExcepcion(string message, Exception inner)
            : base(message, inner)
        {
        }

        public EliminacionUsuarioExcepcion(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
