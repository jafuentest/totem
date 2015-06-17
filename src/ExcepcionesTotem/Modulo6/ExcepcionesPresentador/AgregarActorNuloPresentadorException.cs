using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
    public class AgregarActorNuloPresentadorException:ExcepcionesTotem.ExceptionTotem
    {
         public AgregarActorNuloPresentadorException()
            : base()
        { }

        public AgregarActorNuloPresentadorException(string message)
            : base(message)
        {
        }

        public AgregarActorNuloPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorNuloPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
