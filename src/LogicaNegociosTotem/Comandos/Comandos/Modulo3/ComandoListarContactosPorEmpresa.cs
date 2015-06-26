using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
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
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override List<Dominio.Entidad> Ejecutar(Dominio.Entidad parametro)
        {
            List<Entidad> listContacto;
            try
            {
                DAO.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDAO = new DAO.Fabrica.FabricaDAOSqlServer();
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
