using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
   public class ObjetoNuloDAOException:DAOException
    {
       
       public ObjetoNuloDAOException()
            : base()
        { }

        public ObjetoNuloDAOException(string message)
            : base(message)
        {
        }

        public ObjetoNuloDAOException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ObjetoNuloDAOException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
