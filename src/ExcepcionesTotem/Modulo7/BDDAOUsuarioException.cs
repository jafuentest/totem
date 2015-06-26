using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem.Modulo7
{
    /// <summary>
    /// Exception personalizada que se ejecuta cuando ocurre un error de Base de Datos SQL SERVER en DAOUsuario
    /// </summary>
   public class BDDAOUsuarioException : DAOException
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
       public BDDAOUsuarioException():base()
       {

       }

       /// <summary>
       /// Constructor que trabaja con el mensaje que se quiera dar
       /// </summary>
       /// <param name="mensaje">El mensaje personalizado</param>
       public BDDAOUsuarioException(String mensaje):base(mensaje)
       {

       }

       /// <summary>
       /// Constructor que trabaja con el mensaje que se quiera dar y la excepcion recibida
       /// </summary>
       /// <param name="mensaje">El mensaje personalizado</param>
       /// <param name="inner">La excepcion que se recibe</param>
       public BDDAOUsuarioException(String mensaje, Exception inner):base(mensaje,inner)
       {

       }

       /// <summary>
       /// Constructor que trabaja con el codigo del error, el mensaje que se queira dar y la excepcion recibida
       /// </summary>
       /// <param name="codigo">El codigo del error</param>
       /// <param name="mensaje">el mensaje personalizado</param>
       /// <param name="inner">Excepcion recibida</param>
       public BDDAOUsuarioException(String codigo, String mensaje, Exception inner):base(codigo, mensaje, inner)
       {

       }
    }
}
