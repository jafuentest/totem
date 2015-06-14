using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class AgregarActorDAOException:DAOException
    {
        public AgregarActorDAOException()
            : base()
        { }

        public AgregarActorDAOException(string message)
            : base(message)
        {
        }

        public AgregarActorDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarActorDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
