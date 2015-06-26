using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoBuscarCodigoRequerimiento : Comando<String, List<String>>
    {
        /// <summary>
        /// Metodo que consigue el posible codigo del requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento con el codigo del proyecto</param>
        /// <returns>Posibles codigos, considerando que puede ser funcional o no 
        /// funcional</returns>
        public override List<string> Ejecutar(String parametro)
        {
            DAO.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
            DAO.Fabrica.FabricaDAOSqlServer fabricaDao = new DAO.Fabrica.FabricaDAOSqlServer();
            daoRequerimiento = fabricaDao.ObtenerDAORequerimiento();

            try
            {
                return daoRequerimiento.ObtenerCodigoRequerimiento(parametro);
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
