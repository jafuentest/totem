using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo4;
using DAO.IntefazDAO.Modulo4;

namespace Comandos.Comandos.Modulo4
{
    public class ComandoModificarProyecto : Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que modifica la informacion de un proyecto
        /// </summary>
        /// <param name="parametro">Proyecto a editar</param>
        /// <returns>true si se logro editar</returns>

        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            try
            {
                DAO.IntefazDAO.Modulo4.IDaoProyecto daoProyecto;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDao = new DAO.Fabrica.FabricaDAOSqlServer();
                daoProyecto = fabricaDao.ObtenerDAOProyecto();
                bool resultado = daoProyecto.Modificar(parametro);
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
            catch (ExcepcionesTotem.Modulo4.CamposInvalidosException ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo4.ProyectoNoModificadoException ex)
            {

                throw ex;
            }
            #endregion

        }




    }
}
