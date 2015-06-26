using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoDatosContactoID : Comando<int, Dominio.Entidad>
    {
        /// <summary>
        /// Comando para obtener los datos de un contacto
        /// </summary>
        /// <param name="parametro">ID del contacto</param>
        /// <returns>el contacto solicitado</returns>
        public override Dominio.Entidad Ejecutar(int parametro)
        {
            Contacto contactoID;
            try
            {
                DAO.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDAO = new DAO.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                contactoID = (Contacto) daoInvolucrado.DatosContactoID(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return contactoID;
        }
    }

}