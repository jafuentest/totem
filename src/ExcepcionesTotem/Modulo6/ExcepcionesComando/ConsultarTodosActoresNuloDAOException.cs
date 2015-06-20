using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ConsultarTodosActoresNuloDAOException : ExcepcionesTotem.ExceptionTotem
    {
        public ConsultarTodosActoresNuloDAOException()
            : base()
        { }

        public ConsultarTodosActoresNuloDAOException(string message)
            : base(message)
        {
        }

        public ConsultarTodosActoresNuloDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarTodosActoresNuloDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
