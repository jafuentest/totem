using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesPresentador
{
   public class CaracteresMaliciososException:ExcepcionesTotem.ExceptionTotem
    {
        public CaracteresMaliciososException()
            : base()
        { }

        public CaracteresMaliciososException(string message)
            : base(message)
        {
        }

        public CaracteresMaliciososException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CaracteresMaliciososException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
