using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using DatosTotem.Modulo2;
using ExcepcionesTotem.Modulo2;
namespace LogicaNegociosTotem.Modulo2
{
    public class LogicaContacto
    {
        private BDContacto baseDeDatosContacto; 
       /// <summary>
       /// Constructor de la Clase LogicaContacto
       /// </summary>
       public LogicaContacto() 
       {
           baseDeDatosContacto = new BDContacto(); 
       }

       

       /// <summary>
       /// Método que consulta los datos de un contacto según su id
       /// </summary>
       /// <param name="clienteJuridico">Información del Contacto</param>
       /// <returns>Retorna el objeto de tipo Contacto, null si el objeto no existe</returns>
       public Contacto ConsultarDatosDeContacto(int identificador)
       {
           Contacto contacto = new Contacto(identificador);

           //return baseDeDatosContacto.(identificador); 
           throw new NotImplementedException(); 
       }


    }
}
