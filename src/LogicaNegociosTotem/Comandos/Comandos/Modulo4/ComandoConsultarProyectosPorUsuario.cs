using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.DAO.Modulo4;
using Datos.IntefazDAO.Modulo4;

namespace Comandos.Comandos.Modulo4
{
    public class ComandoConsultarProyectosPorUsuario : Comando<String, List<Dominio.Entidad>>
    {
	   public override List<Dominio.Entidad> Ejecutar(String parametro)
	   {
		  List<Dominio.Entidad> listaProyectos = null;

		  FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
		  IDaoProyecto daoProyecto = fabricaDAO.ObtenerDAOProyecto();

		  try
		  {
			 listaProyectos = daoProyecto.consultarProyectosPorUsuario(parametro);
		  }
		  catch (ExcepcionesTotem.Modulo4.UsuarioSinProyectosException ex)
		  {
			 throw ex;
		  }
		  catch (ExcepcionesTotem.ExceptionTotem ex)
		  {			 
			 throw ex;
		  }

		  return listaProyectos;
	   }
    }
}
