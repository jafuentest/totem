using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO.DAO.Modulo5
{
    public class DAORequerimiento : DAO, IntefazDAO.Modulo5.IDaoRequerimiento
    {
        #region IDAORequerimiento
        /// <summary>
        /// Metodo que busca el ID de un proyecto en la base de datos
        /// usando el codigo del proyecto
        /// </summary>
        /// <param name="codigo">codigo del requerimiento</param>
        /// <returns>integer con el id del proyecto</returns>
        public int BuscarIdProyecto(string codigo)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO,
                    SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_PRO_ID,
                    SqlDbType.Int, true);
                List<Resultado> resultados = EjecutarStoredProcedure(
                    RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_ID_POR_CODIGO_REQUERIMIENTO, parametros);
                foreach (Resultado resultado in resultados)
                {
                    if (resultado != null && resultado.valor != "")
                    {
                        return Convert.ToInt32(resultado.valor);
                    }
                }
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            
        }

        /// <summary>
        /// Metodo que verifica el requerimiento en la base de datos
        /// </summary>
        /// <param name="requerimiento">Requerimiento a validar</param>
        /// <returns>true si existe el requerimiento</returns>
        public bool VerificarRequerimiento(Dominio.Entidad requerimiento)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que elimina un requerimiento asociado a un proyecto
        /// </summary>
        /// <param name="requerimiento">Requerimiento a eliminar</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>true si lo logro eliminar</returns>
        public bool EliminarRequerimiento(Dominio.Entidad requerimiento, int idProyecto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que retorna todos los requerimientos asociados a un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo del proyecto</param>
        /// <returns>Lista de requerimientos</returns>
        public List<Dominio.Entidad> ConsultarRequerimientoDeProyecto(string codigoProyecto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para verificar si un requerimiento existe en la base de
        /// datos
        /// </summary>
        /// <param name="codigoRequerimiento">
        /// Código de requerimiento a buscar en la base de datos
        /// </param>
        /// <returns>
        /// Retrorna true si existe el código de requerimiento buscado, y
        /// false si ocurre lo contrario
        /// </returns>
        public bool ExisteRequerimiento(string codigoRequerimiento)
        {
            bool existeRequerimiento = false;

            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursosDAOModulo5.
               PARAMETRO_REQ_CODIGO, SqlDbType.VarChar, codigoRequerimiento,
               false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosDAOModulo5.
               PARAMETRO_RESULTADO, SqlDbType.Int, true);
            parametros.Add(parametro);

            try
            {


                List<Resultado> resultados = base.EjecutarStoredProcedure(
                 RecursosDAOModulo5.PROCEDIMIENTO_EXISTE_REQUERIMIENTO,
                 parametros);

                if (int.Parse(resultados[0].valor) == 1)
                    existeRequerimiento = true;
                else
                    existeRequerimiento = false;
            }
            catch (Exception)
            {
                throw;
            }

            return existeRequerimiento;
        }

        #endregion

        #region IDAO
        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public bool Agregar(Dominio.Entidad parametro)
        {
            try
            {
                Dominio.Entidades.Modulo5.Requerimiento requerimiento =
                    (Dominio.Entidades.Modulo5.Requerimiento)parametro;
                int idProyecto = BuscarIdProyecto(requerimiento.Codigo);
                if (idProyecto != null)
                {
                    #region Asignacion de Parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_REQ_CODIGO, SqlDbType.VarChar, 
                        requerimiento.Codigo, false);
                    parametros.Add(parametroBD);
                    parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_REQ_DESCRIPCION, SqlDbType.VarChar,
                        requerimiento.Descripcion, false);
                    parametros.Add(parametroBD);
                    parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_REQ_TIPO, SqlDbType.VarChar, 
                        requerimiento.Tipo, false);
                    parametros.Add(parametroBD);
                    parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_REQ_PRIORIDAD, SqlDbType.VarChar,
                        requerimiento.Prioridad, false);
                    parametros.Add(parametroBD);
                    parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_REQ_ESTATUS, SqlDbType.VarChar,
                        requerimiento.Estatus, false);
                    parametros.Add(parametroBD);
                    parametroBD = new Parametro(
                        RecursosDAOModulo5.PARAMETRO_PROYECTO_PRO_ID, SqlDbType.Int,
                        Convert.ToString(idProyecto), false);
                    parametros.Add(parametroBD);
                    #endregion

                    List<Resultado> resultados = 
                        EjecutarStoredProcedure(RecursosDAOModulo5.PROCEDIMIENTO_CREAR_REQUERIMIENTO,
                        parametros);
                    if (resultados.Count > 0)
                    {
                        return true;
                    }
                }
     
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// Metodo que modifica un requerimiento en la base de datos
        /// </summary>
        /// <param name="parametro">Requerimiento a modificar</param>
        /// <returns>true si lo logro modificar</returns>
        public bool Modificar(Dominio.Entidad parametro)
        {
            try
            {
                bool respuestaResultado = true;
                Dominio.Entidades.Modulo5.Requerimiento requerimiento = (Dominio.Entidades.Modulo5.Requerimiento)parametro;
                bool requerimientoModificado = false;

                if (true )
                {
                    List<Parametro> parametros = new List<Parametro>();

                    Parametro parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_ID, SqlDbType.Int,
                       requerimiento.Id.ToString(), false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_CODIGO, SqlDbType.VarChar,
                       requerimiento.Codigo, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_DESCRIPCION, SqlDbType.VarChar,
                       requerimiento.Descripcion, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_TIPO, SqlDbType.VarChar,
                       requerimiento.Tipo, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_PRIORIDAD, SqlDbType.VarChar,
                       requerimiento.Prioridad, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo5.
                       PARAMETRO_REQ_ESTATUS, SqlDbType.VarChar,
                       requerimiento.Estatus, false);
                    parametros.Add(parametroBD);


                        List<Resultado> resultados = base.EjecutarStoredProcedure(RecursosDAOModulo5.
                            PROCEDIMIENTO_MODIFICAR_REQUERIMIENTO, parametros);

                        if (resultados != null)
                        {
                            requerimientoModificado = true;
                        }
                        else
                        {
                           // throw new ExcepcionesTotem.Modulo5.
                             //  RequerimientoNoModificadoException(
                              // RecursosDAOModulo5.EXCEPCION_REQ_NO_MOD_CODIGO,
                               //RecursosDAOModulo5.EXCEPCION_REQ_NO_MOD_MENSAJE,
                            throw new Exception();
                           // );
                        }
                   
                }
                else
                {
                    requerimientoModificado = false;
                }

                return requerimientoModificado;

            }

            catch (ExcepcionesTotem.ExceptionTotem e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Metodo que busca a un requerimiento por su codigo
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo</param>
        /// <returns>Requerimiento con todos los datos</returns>
        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion

    
    }
}
