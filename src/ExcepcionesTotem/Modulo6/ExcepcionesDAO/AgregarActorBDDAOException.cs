using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem; 

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class AgregarActorBDDAOException:DAOException
    {
       public AgregarActorBDDAOException()
            : base()
        { }

        public AgregarActorBDDAOException(string message)
            : base(message)
        {
        }

        public AgregarActorBDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorBDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
