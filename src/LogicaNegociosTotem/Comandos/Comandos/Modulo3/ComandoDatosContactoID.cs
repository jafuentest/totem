using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
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
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
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