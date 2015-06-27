using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.IntefazDAO.Modulo7;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para eliminar un usuario de la base de datos
    /// </summary>
    public class ComandoEliminarUsuario: Comando<String,bool>
    {
        /// <summary>
        /// Este metodo se utiliza para eliminar los usuarios
        /// </summary>
        /// <param name="parametro">El username que se desea eliminar</param>
        /// <returns>Verdadero si se logro eliminar, falso sino se pudo eliminar</returns>
        public override bool Ejecutar(string parametro)
        {
            //Variable que retornara el exito o fallo del registro
            bool exito = false;

            //Instanciamos la fabrica
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            //Instanciamos el DAO
            IDaoUsuario usuario = fabrica.ObtenerDAOUsuario();

            try
            {
                //Obtenemos la respuesta del metodo
                exito = usuario.EliminarUsuario(parametro);

                //Retornamos la respuesta
                return exito;
            }
            catch (UsernameVacioException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoUsernameVacioException usernameVacio = new ComandoUsernameVacioException(
                    RecursosComandoModulo7.EXCEPTION_USERNAME_VACIO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_USERNAME_VACIO_MENSAJE,e);
                Logger.EscribirError(this.GetType().Name, usernameVacio);
                throw usernameVacio;
            }
            catch(BDDAOUsuarioException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoBDDAOUsuarioException daoException = new ComandoBDDAOUsuarioException(
                    RecursosComandoModulo7.EXCEPTION_BDDAOUSUARIO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_BDDAOUSUARIO_MENSAJE,e);
                Logger.EscribirError(this.GetType().Name, daoException);
                throw daoException;
            }
            catch(ErrorInesperadoDAOUsuarioException e)
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
