using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoListarContactosPorEmpresa : Comando<Dominio.Entidad,List<Dominio.Entidad> >
    {
        /// <summary>
        /// Comando que lista lo contactos de una empresa
        /// </summary>
        /// <param name="parametro">cliente juridico</param>
        /// <returns>lista de contactos</returns>
        public override List<Dominio.Entidad> Ejecutar(Dominio.Entidad parametro)
        {
            List<Entidad> listContacto;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                listContacto = daoInvolucrado.ListarContactosPorEmpresa(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listContacto;
        }
    }
}
