using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comandos;
using Datos.Fabrica;
using Datos.IntefazDAO.Modulo7;
using ExcepcionesTotem.Modulo7;
using ExcepcionesTotem;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para listar todos los cargos de la Base de Datos
    /// </summary>
    public class ComandoListarCargos: Comando<bool,List<String>>
    {
        /// <summary>
        /// Este metodo se utiliza para Listar todos los cargos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Lista de strings que tienen el nombre del cargo</returns>
        public override List<string> Ejecutar(bool parametro)
        {
 	        //Respuesta de la consulta;
            List<String> listaCargos = new List<String>();

            //Instanciamos la fabrica concreta SQLServer
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            //Obtenemos el DAO del usuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            try
            {
                //Consultamos en la BD
                listaCargos = daoUsuario.ListarCargos();

                //Retornamos la respuesta
                return listaCargos;
            }
            catch(CargosNoExistentesException e)
            {
                //Escribimos en el logger y lanzamos la exception
                ComandoCargosNoExistentesException cargosInexistentes = new ComandoCargosNoExistentesException(
                    RecursosComandoModulo7.EXCEPTION_CARGOS_NO_EXISTENTES_CODIGO,
                    RecursosComandoModulo7.EXCEPTION_CARGOS_NO_EXISTENTES_MENSAJE,e);
                Logger.EscribirError(this.GetType().Name,cargosInexistentes);
                throw cargosInexistentes;
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
