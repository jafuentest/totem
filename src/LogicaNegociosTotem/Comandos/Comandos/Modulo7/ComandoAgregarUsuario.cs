using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para Agregar un Usuario a la Base de Datos
    /// </summary>
    public class ComandoAgregarUsuario : Comando<Entidad,bool>
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="parametro">usuario a crear</param>
        /// <returns>returns true si se realizo bien y false, si no se realizo</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            throw new NotImplementedException();
        
        }
    }
}
