using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class RespuestaErradoException : ExceptionTotem
    {

        public RespuestaErradoException()
            : base()
        { }

        public RespuestaErradoException(string message)
            : base(message)
        {
        }

        public RespuestaErradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }


}

