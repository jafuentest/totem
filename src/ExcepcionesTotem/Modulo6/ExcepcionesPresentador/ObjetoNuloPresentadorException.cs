using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
    public class ObjetoNuloPresentadorException:ExcepcionesTotem.ExceptionTotem
    {
         public ObjetoNuloPresentadorException()
            : base()
        { }

        public ObjetoNuloPresentadorException(string message)
            : base(message)
        {
        }

        public ObjetoNuloPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ObjetoNuloPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
