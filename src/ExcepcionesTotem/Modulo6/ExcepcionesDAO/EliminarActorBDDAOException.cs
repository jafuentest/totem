using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem; 

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
    public class EliminarActorBDDAOException:DAOException
    {
        public EliminarActorBDDAOException()
            : base()
        { }

        public EliminarActorBDDAOException(string message)
            : base(message)
        {
        }

        public EliminarActorBDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public EliminarActorBDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
