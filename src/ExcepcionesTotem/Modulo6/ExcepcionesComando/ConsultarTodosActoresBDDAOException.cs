using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesComando
{
    public class ConsultarTodosActoresBDDAOException : ExcepcionesTotem.ExceptionTotem
    {
        public ConsultarTodosActoresBDDAOException()
            : base()
        { }

        public ConsultarTodosActoresBDDAOException(string message)
            : base(message)
        {
        }

        public ConsultarTodosActoresBDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ConsultarTodosActoresBDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
