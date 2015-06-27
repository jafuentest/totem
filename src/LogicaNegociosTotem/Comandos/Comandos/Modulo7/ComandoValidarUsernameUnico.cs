using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.DAO.Modulo7;
using Datos.Fabrica;
using Datos.IntefazDAO.Modulo7;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo7;



namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando para validar si el username ingresado existe o no
    /// </summary>
    public class ComandoValidarUsernameUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el username existe o no
        /// </summary>
        /// <param name="parametro">el username del usuario nuevo</param>
        /// <returns>Verdadero si es valido, falso sino es valido</returns>
        public override bool Ejecutar(String parametro)
        {
            //Instanciamos la fabrica
            FabricaDAOSqlServer usernameUnico = new FabricaDAOSqlServer();

            //Instanciamos el DAO
            IDaoUsuario daoUsuario = usernameUnico.ObtenerDAOUsuario();

            try
            {
                //Ejecutamos la instruccion y obtenemos la respuesta pertinente
                bool valido = daoUsuario.ValidarUsernameUnico(parametro);
            
                //Retornamos la respuesta
                return valido;
            }
            catch (UsernameVacioException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoUsernameVacioException usernameVacio = new ComandoUsernameVacioException(
                    RecursosComandoModulo7.EXCEPTION_USERNAME_VACIO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_USERNAME_VACIO_MENSAJE, e);
                Logger.EscribirError(this.GetType().Name, usernameVacio);
                throw usernameVacio;
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
