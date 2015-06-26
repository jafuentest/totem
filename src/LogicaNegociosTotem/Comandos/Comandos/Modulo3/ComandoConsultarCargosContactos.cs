using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoConsultarCargosContactos : Comando<Dominio.Entidad,List<String>>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override List<String> Ejecutar(Dominio.Entidad parametro)
        {
            List<String> listCargo;
            try
            {
                DAO.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDAO = new DAO.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                listCargo = daoInvolucrado.ConsultarCargosContactos(parametro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listCargo;
        }
    }

}