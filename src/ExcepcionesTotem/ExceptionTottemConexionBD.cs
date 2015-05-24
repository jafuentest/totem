using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class ExceptionTottemConexionBD: ExceptionTotem
    {

        public ExceptionTottemConexionBD()
            : base()
        { }

        public ExceptionTottemConexionBD(string message)
            : base(message)
        {
        }

        public ExceptionTottemConexionBD(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionTottemConexionBD(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
