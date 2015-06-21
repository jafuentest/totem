using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoAgregarRequerimiento: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando para ejecutar un requerimiento, recibe un requerimiento
        /// de entrada y retorna el requerimiento de salida
        /// </summary>
        /// <param name="parametro">Requerimiento a Agregar</param>
        /// <returns>true si se pudo realizar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            DAO.Fabrica.FabricaAbstractaDAO fabricaDAO;
            DAO.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
            
            fabricaDAO = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            daoRequerimiento = fabricaDAO.ObtenerDAORequerimiento();

            try
            {
                return daoRequerimiento.Agregar(parametro);
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
