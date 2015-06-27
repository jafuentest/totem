using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoConsultarContactosInvolucradosPorProyecto : Comando<Dominio.Entidad, Dominio.Entidad>
    {
        /// <summary>
        /// Comando para obtener los contactos involucrados en un proyecto
        /// </summary>
        /// <param name="parametro">proyecto</param>
        /// <returns>lista de contactos involucrados</returns>
        public override Dominio.Entidad Ejecutar(Dominio.Entidad parametro)
        {
            ListaInvolucradoContacto listContacto = null;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                listContacto = (ListaInvolucradoContacto)daoInvolucrado.ConsultarContactosInvolucradosPorProyecto(parametro);                 
            }
            catch (Exception ex)
            {
                throw ex;                 
            }
            return listContacto;
        }
    }

}
