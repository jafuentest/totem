using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;

namespace DAO.IntefazDAO.Modulo7
{
    /// <summary>
    /// Interface a ser usada por la clase DAOUsuario
    /// </summary>
    interface IDaoUsuario
    {
        /// <summary>
        /// Metodo que implementara la logica del agregar usuario a la Base de Datos
        /// </summary>
        /// <param name="usuario">El usuario a ser agregado</param>
        /// <returns>Verdadero si fue agregado o falso sino fue agregado</returns>
        public bool AgregarUsuario(Usuario usuario);
        
    }
}
