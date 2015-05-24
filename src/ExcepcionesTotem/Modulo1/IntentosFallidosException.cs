using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class IntentosFallidosException : ExceptionTotem
    {
      public IntentosFallidosException()
            : base()
        { }

        public IntentosFallidosException(string message)
            : base(message)
        {
        }

        public IntentosFallidosException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public IntentosFallidosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

}


    }

