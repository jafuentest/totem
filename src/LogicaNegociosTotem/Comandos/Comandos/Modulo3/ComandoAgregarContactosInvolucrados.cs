using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using ExcepcionesTotem.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoAgregarContactosInvolucrados: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool exito = false;
            try
            {
                DAO.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDAO = new DAO.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                exito = daoInvolucrado.AgregarContactosInvolucrados(parametro);
            }
            catch (ListaSinInvolucradosException)
            {
                exito = true;
            }
            catch (ListaSinProyectoException)
            {
                exito = false;
            }
            return exito;
        }
}

}