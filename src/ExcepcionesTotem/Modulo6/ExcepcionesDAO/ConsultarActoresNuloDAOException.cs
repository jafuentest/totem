using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
    public class ConsultarActoresNuloDAOException : DAOException
    {

        public ConsultarActoresNuloDAOException()
            : base()
        { }

        public ConsultarActoresNuloDAOException(string message)
            : base(message)
        {
        }

        public ConsultarActoresNuloDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarActoresNuloDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
