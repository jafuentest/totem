using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoModificarRequerimiento: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que modifica la informacion de un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a editar</param>
        /// <returns>true si se logro editar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            try
            {
                DAO.Fabrica.FabricaAbstractaDAO fabricaDaoSqlServer = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();

                DAO.DAO.Modulo5.DAORequerimiento daoRequerimiento = (DAO.DAO.Modulo5.DAORequerimiento)fabricaDaoSqlServer.ObtenerDAORequerimiento();
                bool resultado = daoRequerimiento.Modificar(parametro);
                return resultado;
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
