using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    class ComandoEliminarRequerimiento : Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            DAO.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
            DAO.Fabrica.FabricaDAOSqlServer fabricaDao = new DAO.Fabrica.FabricaDAOSqlServer();
            daoRequerimiento = fabricaDao.ObtenerDAORequerimiento();

            try
            {
                return daoRequerimiento.EliminarRequerimiento(parametro);
            }

            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {

                throw ex;
            }
            #endregion
        }
    }
}
