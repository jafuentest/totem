using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
   public class AgregarActorComandoException:ExceptionTotem
    {
       
        public AgregarActorComandoException()
            : base()
        { }

        public AgregarActorComandoException(string message)
            : base(message)
        {
        }

        public AgregarActorComandoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorComandoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
