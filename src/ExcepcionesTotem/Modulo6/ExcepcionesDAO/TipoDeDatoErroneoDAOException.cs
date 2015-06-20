using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
    public class TipoDeDatoErroneoDAOException : DAOException
    {
        public TipoDeDatoErroneoDAOException()
            : base()
        { }

        public TipoDeDatoErroneoDAOException(string message)
            : base(message)
        {
        }

        public TipoDeDatoErroneoDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TipoDeDatoErroneoDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
