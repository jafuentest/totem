using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
   public class AgregarActorBDPresentadorException:ExcepcionesTotem.ExceptionTotem
    {
        public AgregarActorBDPresentadorException()
            : base()
        { }

        public AgregarActorBDPresentadorException(string message)
            : base(message)
        {
        }

        public AgregarActorBDPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorBDPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
