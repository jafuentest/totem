using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo7;
using DAO.IntefazDAO.Modulo7;
using ExcepcionesTotem.Modulo7;
using ExcepcionesTotem;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando para validar si el correo ingresado existe o no
    /// </summary>
    public class ComandoValidarCorreoUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el correo existe o no
        /// </summary>
        /// <param name="parametro">el correo que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso si ya esta registrado en la BD</returns>
        public override bool Ejecutar(String parametro)
        {
            //Instanciamos la fabrica concreta SQLServer
            FabricaDAOSqlServer correoValido = new FabricaDAOSqlServer();

            //Instanciamos el DAOUsuario
            IDaoUsuario daoUsuario = correoValido.ObtenerDAOUsuario();
            try
            {
                //Ejecutamos la instruccion pertinente y esperamos la respuesta
                bool valido = daoUsuario.ValidarCorreoUnico(parametro);

                //Retornamos la respuesta
                return valido;
            }
            catch (CorreoVacioException ex)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoCorreoVacioException correoVacio = new ComandoCorreoVacioException(
                    RecursosComandoModulo7.EXCEPTION_CORREO_VACIO_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_CORREO_VACIO_MENSAJE, ex);
                Logger.EscribirError(this.GetType().Name, correoVacio);
                throw correoVacio;
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
