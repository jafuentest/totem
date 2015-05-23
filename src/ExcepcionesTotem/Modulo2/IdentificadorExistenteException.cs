using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo2
{
   public class IdentificadorExistenteException :ExceptionTotem
    {

       public IdentificadorExistenteException()
           : base()
       { 
       }

       public IdentificadorExistenteException(string mensaje) : base(mensaje) 
       { 
       }

       public IdentificadorExistenteException(string mensaje, Exception tipoExcepcion) : base(mensaje, tipoExcepcion) 
       {
       }
    }
}
