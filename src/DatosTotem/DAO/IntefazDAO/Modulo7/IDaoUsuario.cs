using Dominio;
using System;
using System.Collections.Generic;

namespace DAO.IntefazDAO.Modulo7
{
    /// <summary>
    /// Interface a ser usada por la clase DAOUsuario
    /// </summary>
	public interface IDaoUsuario : IDao <Dominio.Entidad, Boolean, Dominio.Entidad>
	{
		#region Teddy
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

        /// <summary>
        /// Firma de metodo que implementara la logica de Listar los cargos de la Base de Datos
        /// </summary>
        /// <returns>Lista con todos los cargos de la Base de Datos</returns>
        List<String> ListarCargos();

        /// <summary>
        /// Firma de metodo que implementara la logica de Listar los Usuarios de la Base de Datos
        /// </summary>
        /// <returns>Lista con todos los usuarios de la Base de Datos</returns>
        List<Entidad> ListarUsuarios();

        /// <summary>
        /// Firma de metodo que implementara la logica de Listar los Usuarios en base a los cargos que tengan de la BD
        /// </summary>
        /// <param name="cargo">Cargo por el cual se desean listar los usuarios</param>
        /// <returns>Los usuarios que tengan ese cargo</returns>
        List<Entidad> ListarUsuariosPorCargo(String cargo);

        /// <summary>
        /// Firma de metodo que implementara la logica de Listar los cargos si y solo si ese cargo lo tiene por lo menos un usuario
        /// </summary>
        /// <returns>Lista con todos los cargos de la Base de Datos</returns>
        List<String> LeerCargosUsuarios();

        /// <summary>
        /// Firma de metodo que implementara la logica de eliminar un usuario de la base de datos
        /// </summary>
        /// <param name="username">El username que se desea eliminar</param>
        /// <returns>Verdadero si se logro a eliminar, falso sino se logro eliminar</returns>
        bool EliminarUsuario(String username);
		#endregion

		#region Juan
		Entidad ConsultarPorUsername(Entidad parametro);
		#endregion
	}
}
