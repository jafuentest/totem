using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo1
{
    public class BDSQLException : ExceptionTotem
    {

        public BDSQLException()
            : base()
        { }

        public BDSQLException(string message)
            : base(message)
        {
        }

        public BDSQLException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }


}

