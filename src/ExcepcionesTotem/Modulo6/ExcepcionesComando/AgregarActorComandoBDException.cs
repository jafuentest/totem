using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
   public class AgregarActorComandoBDException:ExcepcionesTotem.ExceptionTotem
    {
        public AgregarActorComandoBDException()
            : base()
        { }

        public AgregarActorComandoBDException(string message)
            : base(message)
        {
        }

        public AgregarActorComandoBDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorComandoBDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
