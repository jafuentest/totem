using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio;

namespace DAO.IntefazDAO.Modulo7
{
    /// <summary>
    /// Interface a ser usada por la clase DAOUsuario
    /// </summary>
    public interface IDaoUsuario
    {
        /// <summary>
        /// Firma de metodo que implementara la logica del agregar usuario a la Base de Datos
        /// </summary>
        /// <param name="usuario">El usuario a ser agregado</param>
        /// <returns>Verdadero si fue agregado o falso sino fue agregado</returns>
        bool AgregarUsuario(Entidad usuario);

        /// <summary>
        /// Firma de metodo que implementara la logica de validar si el username ya existe en la Base de Datos
        /// </summary>
        /// <param name="username">el username que se desea registrar</param>
        /// <returns>Verdadero si es valido ese username o falso si ya existe</returns>
        bool ValidarUsernameUnico(String username);

        /// <summary>
        /// Firma de metodo que implementara la logica de validar si el correo ya existe en la Base de Datos
        /// </summary>
        /// <param name="correo">el correo que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso si ya existe</returns>
        bool ValidarCorreoUnico(String correo);
        
    }
}
