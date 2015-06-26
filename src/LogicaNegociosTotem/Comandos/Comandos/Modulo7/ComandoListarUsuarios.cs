using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para Listar todos los usuarios de Base de Datos
    /// </summary>
    public class ComandoListarUsuarios : Comando<bool,List<Entidad>>
    {
        /// <summary>
        /// Este metodo se utiliza para Listar todos los usuarios
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Lista que contiene todos los usuarios de la Base de Datos</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
 	        //Lista que contendra todos los usuarios
            List<Entidad> listaUsuarios;

            //Instanciamos la fabrica
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            //Instanciamos el DAOUsuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            try
            {
                //Obtenemos la lista con los usuarios
                listaUsuarios = daoUsuario.ListarUsuarios();

                //Retornamos la respuesta
                return listaUsuarios;
            }
            catch (BDDAOUsuarioException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoBDDAOUsuarioException daoException = new ComandoBDDAOUsuarioException(
                    RecursosComandoModulo7.EXCEPTION_BDDAOUSUARIO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_BDDAOUSUARIO_MENSAJE, e);
                Logger.EscribirError(this.GetType().Name, daoException);
                throw daoException;
            }
            catch (ErrorInesperadoDAOUsuarioException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoErrorInesperadoException errorInesperado = new ComandoErrorInesperadoException(
                    RecursosComandoModulo7.EXCEPTION_ERROR_COMANDO_INESPERADO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_ERROR_COMANDO_INESPERADO_MENSAJE, e);
                Logger.EscribirError(this.GetType().Name, errorInesperado);
                throw errorInesperado;
            }

        }
    }
}
