using Datos.Fabrica;
using Datos.IntefazDAO.Modulo7;
using Dominio;
using ExcepcionesTotem.Modulo7;
using System;

namespace Comandos.Comandos.Modulo7
{
	public class ComandoDetalleUsuario : Comando<Entidad, Entidad>
	{
		/// <summary>
        /// Comando para consultar un usuario
        /// </summary>
        /// <param name="parametro">Usuario con username para buscar la informacion en la base de datos</param>
        /// <returns>Usuario con los datos cargados</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            IDaoUsuario daoUsuario;
			daoUsuario = new FabricaDAOSqlServer().ObtenerDAOUsuario();

			try
			{
				return daoUsuario.ConsultarPorUsername(parametro);
            }
            catch (Exception e)
            {
                throw new UsuarioInvalidoException(e.Message);
            }
		}
	}
}
