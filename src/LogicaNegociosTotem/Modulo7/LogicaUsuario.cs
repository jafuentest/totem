using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo7
{
    class LogicaUsuario
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="elUsuario">usuario a crear</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public Boolean agregarUsuario(DominioTotem.Usuario elUsuario)
        {
            return true;
        }
        /// <summary>
        /// Este metodo se utiliza para modificar los datos del usuario seleccionado
        /// </summary>
        /// <param name="elUsuario">usuario a modificar</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public Boolean modificarUsuario(DominioTotem.Usuario elUsuario)
        {
            return true;
        }
        /// <summary>
        /// Metodo que lista todos los usuarios existentes
        /// </summary>
        public void listarUsuario()
        {

        }
    }
}
