using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class IntentosErradosException : ExceptionTotem
    {

        public IntentosErradosException()
            : base()
        { }

        public IntentosErradosException(string message)
            : base(message)
        {
        }

        public IntentosErradosException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }


}

