using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;
using Dominio;
using System;

namespace Comandos.Comandos.Modulo7
{
	class ComandoModificarUsuario : Comando<Entidad, Boolean>
	{
		/// <summary>
		/// Comando que modifica la informacion de un usuario
		/// </summary>
		/// <param name="parametro">Usuario a editar</param>
		/// <returns>true si se logro modificar</returns>
		public override bool Ejecutar(Entidad parametro)
		{
			try
			{
				FabricaDAOSqlServer fabricaDao = new FabricaDAOSqlServer();

				IDaoUsuario daoUsuario = new FabricaDAOSqlServer().ObtenerDAOUsuario();

				return daoUsuario.Modificar(parametro);
			}
			catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException e)
			{
				throw e;
			}
			catch (ExcepcionesTotem.ExceptionTotemConexionBD e)
			{
				throw e;
			}
			catch (ExcepcionesTotem.Modulo7.UsuarioInvalidoException e)
			{
				throw e;
			}
			catch (ExcepcionesTotem.Modulo7.UsuarioNoModificadoException e)
			{
				throw e;
			}
		}
	}
}
