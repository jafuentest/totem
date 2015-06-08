using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class DAOException : ExceptionTotem
    {
        public DAOException()
            : base()
        { }

        public DAOException(string message)
            : base(message)
        {
        }

        public DAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public DAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
