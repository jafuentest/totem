using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
   public class ActorNoModificadoComandoException:ExcepcionesTotem.ExceptionTotem
    {
       public ActorNoModificadoComandoException()
            : base()
        { }

        public ActorNoModificadoComandoException(string message)
            : base(message)
        {
        }

        public ActorNoModificadoComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ActorNoModificadoComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
