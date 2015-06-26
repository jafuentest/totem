using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ActorInexistenteComandoException:ExcepcionesTotem.ExceptionTotem
    {
         public ActorInexistenteComandoException()
            : base()
        { }

        public ActorInexistenteComandoException(string message)
            : base(message)
        {
        }

        public ActorInexistenteComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ActorInexistenteComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
