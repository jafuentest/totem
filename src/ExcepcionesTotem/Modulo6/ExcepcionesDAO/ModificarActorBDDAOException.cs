using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem; 

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class ModificarActorBDDAOException:DAOException
    {
        public ModificarActorBDDAOException()
            : base()
        { }

        public ModificarActorBDDAOException(string message)
            : base(message)
        {
        }

        public ModificarActorBDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ModificarActorBDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
