using Datos.Fabrica;
using Datos.IntefazDAO.Modulo7;
using Dominio;
using System.Data;

namespace Comandos.Comandos.Modulo7
{
	class ComandoListarCargosConId : Comando<object, DataSet>
	{
		/// <summary>
		/// Comando para consultar cargos disponibles
		/// </summary>
		/// <param name="parametro">Usuario con username para buscar la informacion en la base de datos</param>
		/// <returns>Lista de cargos</returns>
		public override DataSet Ejecutar(object o)
		{
			IDaoUsuario daoUsuario;
			daoUsuario = new FabricaDAOSqlServer().ObtenerDAOUsuario();

			//try
			//{
			return daoUsuario.ConsultarCargosConId();
			//}
			//catch (Exception e)
			//{
			//	throw e;
			//}
		}
	}
}
