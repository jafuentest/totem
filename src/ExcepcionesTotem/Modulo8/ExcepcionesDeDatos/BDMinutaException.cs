using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo8.ExcepcionesDeDatos
{
    public class BDMinutaException: ExceptionTotem
    {
        public BDMinutaException()
            : base()
        { 
        }

        public BDMinutaException(string message)
            : base(message)
        { 
        }

        public BDMinutaException(string message, Exception inner)
            : base(message)
        {
        }

        public BDMinutaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
