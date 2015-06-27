using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.DAO.Modulo4;
using Datos.IntefazDAO.Modulo4;

namespace Comandos.Comandos.Modulo4
{
    public class ComandoAgregarProyecto : Comando<Dominio.Entidad, Boolean>
    {
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool resultado = false;

		  FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
		  IDaoProyecto daoProyecto = fabricaDAO.ObtenerDAOProyecto();

            try
            {
                resultado = daoProyecto.Agregar(parametro);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return resultado;
        }
    }
}
