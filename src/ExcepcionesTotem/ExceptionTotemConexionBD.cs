using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class ExceptionTotemConexionBD: ExceptionTotem
    {

        public ExceptionTotemConexionBD()
            : base()
        { }

        public ExceptionTotemConexionBD(string message)
            : base(message)
        {
        }

        public ExceptionTotemConexionBD(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionTotemConexionBD(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
