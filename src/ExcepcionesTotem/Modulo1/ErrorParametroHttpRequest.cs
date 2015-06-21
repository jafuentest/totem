using System;

namespace ExcepcionesTotem.Modulo1
{
    public class ErrorParametroHttpRequest : ExceptionTotem
    {
        public ErrorParametroHttpRequest()
            : base()
        { }

        public ErrorParametroHttpRequest(string message)
            : base(message)
        {
        }

        public ErrorParametroHttpRequest(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorParametroHttpRequest(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }


}

