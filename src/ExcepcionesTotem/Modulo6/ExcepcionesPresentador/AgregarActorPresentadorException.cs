using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
   public class AgregarActorPresentadorException:ExcepcionesTotem.ExceptionTotem
    {
       public AgregarActorPresentadorException()
            : base()
        { }

        public AgregarActorPresentadorException(string message)
            : base(message)
        {
        }

        public AgregarActorPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
