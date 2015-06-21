using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
    public class ConsultarActoresBDDAOException : DAOException
    {

        public ConsultarActoresBDDAOException()
            : base()
        { }

        public ConsultarActoresBDDAOException(string message)
            : base(message)
        {
        }

        public ConsultarActoresBDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarActoresBDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
