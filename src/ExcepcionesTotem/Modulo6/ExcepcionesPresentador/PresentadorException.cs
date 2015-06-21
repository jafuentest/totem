using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
   public class PresentadorException:ExcepcionesTotem.ExceptionTotem
    {
        public PresentadorException()
            : base()
        { }

        public PresentadorException(string message)
            : base(message)
        {
        }

        public PresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
