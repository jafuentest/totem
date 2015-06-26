using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;
using Dominio;

namespace Comandos.Comandos.Modulo7
{
	public class ComandoDetalleUsuario : Comando<Dominio.Entidad, Dominio.Entidad>
	{
		/// <summary>
        /// Comando para consultar un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo
        /// para buscar la informacion en la base de datos</param>
        /// <returns>Requerimiento con los datos cargados</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            IDaoUsuario daoUsuario;
			daoUsuario = new FabricaDAOSqlServer().ObtenerDAOUsuario();

			//try
			//{
				return daoUsuario.ConsultarPorUsername(parametro);
			//}
			//catch (Exception e)
			//{
			//	throw e;
			//}
		}
	}
}
