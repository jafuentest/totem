using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class AgregarActorComandoNullException:ExceptionTotem
    {
        
        public AgregarActorComandoNullException()
            : base()
        { }

        public AgregarActorComandoNullException(string message)
            : base(message)
        {
        }

        public AgregarActorComandoNullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorComandoNullException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
