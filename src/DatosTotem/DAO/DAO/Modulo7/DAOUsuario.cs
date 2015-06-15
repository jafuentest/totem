using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO.Modulo7;
using Dominio.Entidades.Modulo7;

namespace DAO.DAO.Modulo7
{
    /// <summary>
    /// Clase DAO que interactua con la BD y realiza las operaciones del Usuario
    /// </summary>
    public class DAOUsuario : IDaoUsuario
    {
        /// <summary>
        /// Metodo que agrega un Usuario nuevo a la Base de Datos
        /// </summary>
        /// <param name="usuario">El usuario a ser insertado en la BD</param>
        /// <returns>Verdadero si el usuario fue agregado o falso sino fue agregado</returns>
        public bool AgregarUsuario(Usuario usuario)
        {
            return false;
        }
        
    }
}
