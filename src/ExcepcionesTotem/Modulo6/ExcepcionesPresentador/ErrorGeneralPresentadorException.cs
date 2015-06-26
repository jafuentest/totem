using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
   public class ErrorGeneralPresentadorException:ExcepcionesTotem.ExceptionTotem
    {
       public ErrorGeneralPresentadorException()
            : base()
        { }

        public ErrorGeneralPresentadorException(string message)
            : base(message)
        {
        }

        public ErrorGeneralPresentadorException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorGeneralPresentadorException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
