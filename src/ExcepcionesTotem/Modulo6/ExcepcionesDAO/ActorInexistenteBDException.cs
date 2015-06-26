using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo6.ExcepcionesDAO
{
    public class ActorInexistenteBDException : DAOException
    {
        
       public ActorInexistenteBDException()
            : base()
        { }

        public ActorInexistenteBDException(string message)
            : base(message)
        {
        }

        public ActorInexistenteBDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ActorInexistenteBDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
