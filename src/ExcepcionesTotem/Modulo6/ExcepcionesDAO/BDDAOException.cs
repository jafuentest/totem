using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem; 

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class BDDAOException:DAOException
    {
       public BDDAOException()
            : base()
        { }

        public BDDAOException(string message)
            : base(message)
        {
        }

        public BDDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BDDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
