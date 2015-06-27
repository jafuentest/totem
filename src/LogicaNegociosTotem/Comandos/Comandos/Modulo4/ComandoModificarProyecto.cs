using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.DAO.Modulo4;
using Datos.IntefazDAO.Modulo4;

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
                Datos.IntefazDAO.Modulo4.IDaoProyecto daoProyecto;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDao = new Datos.Fabrica.FabricaDAOSqlServer();
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
