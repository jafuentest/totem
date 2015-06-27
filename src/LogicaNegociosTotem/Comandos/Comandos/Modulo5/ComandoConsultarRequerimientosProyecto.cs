using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoConsultarRequerimientosProyecto : Comando<String,
        List<Dominio.Entidad>>
    {
        /// <summary>
        /// Comando que consulta los requerimientos de un proyecto
        /// </summary>
        /// <param name="parametro">id del proyecto</param>
        /// <returns>Lista de requerimientos asociadas al proyecto</returns>
        public override List<Dominio.Entidad> Ejecutar(string parametro)
        {
            Datos.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
            Datos.Fabrica.FabricaDAOSqlServer fabricaDao = new Datos.Fabrica.FabricaDAOSqlServer();
            daoRequerimiento = fabricaDao.ObtenerDAORequerimiento();

            try
            {
                return daoRequerimiento.ConsultarRequerimientoDeProyecto(parametro);
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
