using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoListarContactosPorCargoEmpresa : Comando<Dominio.Entidad, List<Dominio.Entidad>>
    {
        /// <summary>
        /// Comando que
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>t</returns>
        public override List<Dominio.Entidad> Ejecutar(Dominio.Entidad parametro)
        {
            //recibir: Ejecutar(Dominio.Entidad parametro,string cargo)
            /*
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrado = laFabrica.ObtenerDaoInvolucrados();
                return daoInvolucrado.ListarContactosPorCargoEmpresa(parametro,cargo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
             */
            throw new NotImplementedException();
        }
    }

}