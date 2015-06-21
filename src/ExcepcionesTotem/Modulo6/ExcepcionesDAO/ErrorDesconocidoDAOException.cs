using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class ErrorDesconocidoDAOException:DAOException
    {
        public ErrorDesconocidoDAOException()
            : base()
        { }

        public ErrorDesconocidoDAOException(string message)
            : base(message)
        {
        }

        public ErrorDesconocidoDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorDesconocidoDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
