using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class ExceptionTotem : Exception
    {
        private String _Codigo;
        private String _Mensaje;
      
        public  ExceptionTotem() : base()
        {}

         public ExceptionTotem(string message)
        : base(message)
    {
    }

    public ExceptionTotem(string message, Exception inner)
        : base(message, inner)
    {
    }
}


    }
