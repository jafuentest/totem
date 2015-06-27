using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoConsultarCargosContactos : Comando<Dominio.Entidad,List<String>>
    {
        /// <summary>
        /// Comando para consultar los cargos de un contacto
        /// </summary>
        /// <param name="parametro"> contactos</param>
        /// <returns>la lista con los cargos de los contactos</returns>
        public override List<String> Ejecutar(Dominio.Entidad parametro)
        {
            List<String> listCargo;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
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