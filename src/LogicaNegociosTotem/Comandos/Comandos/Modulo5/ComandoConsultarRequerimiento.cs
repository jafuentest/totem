using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoConsultarRequerimiento : Comando<Dominio.Entidad, Dominio.Entidad>
    {
        /// <summary>
        /// Comando para consultar un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo
        /// para buscar la informacion en la base de datos</param>
        /// <returns>Requerimiento con los datos cargados</returns>
        public override Dominio.Entidad Ejecutar(Dominio.Entidad parametro)
        {
            DAO.Fabrica.FabricaAbstractaDAO fabricaDAO;
            DAO.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;

            fabricaDAO = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            daoRequerimiento = fabricaDAO.ObtenerDAORequerimiento();

            try
            {
                return daoRequerimiento.ConsultarXId(parametro);
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
