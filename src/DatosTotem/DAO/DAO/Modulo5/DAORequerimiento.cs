using ExcepcionesTotem.Modulo5;
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
        /// <param name="codigo">codigo del proyecto</param>
        /// <returns>integer con el id del proyecto</returns>
        public int BuscarIdProyecto(string codigo)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_PRO_CODIGO,
                    SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_PRO_ID,
                    SqlDbType.Int, true);
                parametros.Add(parametro);
                List<Resultado> resultados = EjecutarStoredProcedure(
                    RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_ID_POR_CODIGO_PROYECTO, parametros);
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
        /// Metodo que verifica el requerimiento en la base de datos
        /// </summary>
        /// <param name="requerimiento">Requerimiento a validar</param>
        /// <returns>true si existe el requerimiento</returns>
        public bool VerificarRequerimiento(Dominio.Entidad requerimiento)
        {

            bool existeRequerimiento = false;
            Dominio.Entidades.Modulo5.Requerimiento requerimientoBD = (Dominio.Entidades.Modulo5.Requerimiento)requerimiento;
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursosDAOModulo5.
               PARAMETRO_REQ_CODIGO, SqlDbType.VarChar, requerimientoBD.Codigo,
               false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosDAOModulo5.
               PARAMETRO_RESULTADO, SqlDbType.Int, true);
            parametros.Add(parametro);

            try
            {


                List<Resultado> resultados = base.EjecutarStoredProcedure(
                 RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_REQUERIMIENTO_POR_CODIGO,
                 parametros);

                if (int.Parse(resultados[0].valor) == 1)
                    existeRequerimiento = true;
                else
                {
                    existeRequerimiento = false;
                    throw new RequerimientoNoExisteException();
                }
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion
            return existeRequerimiento;
        }

        /// <summary>
        /// Metodo que elimina un requerimiento asociado a un proyecto
        /// </summary>
        /// <param name="requerimiento">Requerimiento a eliminar</param>
        /// <returns>true si lo logro eliminar</returns>
        public bool EliminarRequerimiento(Dominio.Entidad requerimiento)
        {
            bool requerimientoEliminado = false;

            Dominio.Entidades.Modulo5.Requerimiento requerimientoAEliminar =
                (Dominio.Entidades.Modulo5.Requerimiento)requerimiento;

            List<Parametro> parametros = new List<Parametro>();
            
            Parametro parametro = new Parametro(RecursosDAOModulo5.
               PARAMETRO_REQ_CODIGO, SqlDbType.VarChar, requerimientoAEliminar.Codigo,
               false);
            parametros.Add(parametro);

            try
            {

                List<Resultado> resultados = EjecutarStoredProcedure(
                   RecursosDAOModulo5.PROCEDIMIENTO_ELIMINAR_REQUERIMIENTO,
                   parametros);

                if (resultados != null)
                {
                    requerimientoEliminado = true;
                }
                else
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                    throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                                RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                                RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                                new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
                }
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion

            return requerimientoEliminado;
        }

        /// <summary>
        /// Metodo que retorna todos los requerimientos asociados a un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo del proyecto</param>
        /// <returns>Lista de requerimientos</returns>
        public List<Dominio.Entidad> ConsultarRequerimientoDeProyecto(string codigoProyecto)
        {
            List<Parametro> parametros = new List<Parametro>();

            List<Dominio.Entidad> listaRequerimientos =
               new List<Dominio.Entidad>();

            int idProyecto = BuscarIdProyecto(codigoProyecto);
            Parametro parametro = new Parametro(
               RecursosDAOModulo5.PARAMETRO_PRO_ID,
               SqlDbType.Int, idProyecto.ToString(), false);
            parametros.Add(parametro);

            try
            {
                DataTable dataTableRequerimientos =
                   EjecutarStoredProcedureTuplas(
                   RecursosDAOModulo5.
                   PROCEDIMIENTO_CONSULTAR_REQUERIMIENTOS_POR_PROYECTO,
                   parametros);
                if (dataTableRequerimientos != null)
                {
                    foreach (DataRow fila in dataTableRequerimientos.Rows)
                    {
                        listaRequerimientos.Add(
                            new Dominio.Entidades.Modulo5.Requerimiento(
                               fila[RecursosDAOModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
                               fila[RecursosDAOModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
                               fila[RecursosDAOModulo5.ATRIBUTO_REQ_TIPO].ToString(),
                               fila[RecursosDAOModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
                               fila[RecursosDAOModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
                            )
                        );
                    }
                    return listaRequerimientos;
                }

                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    new ExcepcionesTotem.ExceptionTotemConexionBD());

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    new ExcepcionesTotem.ExceptionTotemConexionBD());
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// Metodo que retorna los codigos de requerimiento
        /// </summary>
        /// <param name="requerimiento">Requerimiento con el codigo del proyecto
        /// y el tipo</param>
        /// <returns>Lista de String con los dos posibles valor a tomar, si es 
        /// funcional o no funcional</returns>
        public List<string> ObtenerCodigoRequerimiento(string codigoProyecto)
        {
            try
            {
                List<String> codigosRequerimiento = new List<String>();
                int idProyecto = BuscarIdProyecto(codigoProyecto);
       
                codigosRequerimiento.Add(ObtenerCodigoRequerimientoFuncional(idProyecto));
                codigosRequerimiento.Add(ObtenerCodigoRequerimientoNoFuncional(idProyecto));

                return codigosRequerimiento;
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// Metodo que retorna los codigos de requerimiento
        /// </summary>
        /// <param name="requerimiento">Requerimiento con el codigo del proyecto
        /// y el tipo</param>
        /// <returns>Lista de String con los dos posibles valor a tomar, si es 
        /// funcional o no funcional</returns>
        public string ObtenerCodigoRequerimientoFuncional(int idProyecto)
        {
            try
            {
                #region Construccion Lista de Parametros
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_PRO_ID,
                    SqlDbType.Int, Convert.ToString(idProyecto), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_REQ_TIPO,
                    SqlDbType.VarChar, RecursosDAOModulo5.TIPO_FUNCIONAL,
                    false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                #endregion

                List<Resultado> resultados = EjecutarStoredProcedure(
                    RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_CODIGO_DE_REQUERIMIENTO,
                    parametros);
                if (resultados != null)
                {
                    foreach (Resultado resultado in resultados)
                    {
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO)
                            && resultado.valor != "")
                        {
                            return resultado.valor;
                        }
                    }
                }
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// Metodo que retorna el codigo del requerimiento no funcional
        /// </summary>
        /// <param name="idProyecto">int del id del proyecto</param>
        /// <returns>String con el codigo</returns>
        public string ObtenerCodigoRequerimientoNoFuncional(int idProyecto)
        {
            try
            {
                #region Construccion Lista de Parametros
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_PRO_ID,
                    SqlDbType.Int, Convert.ToString(idProyecto), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_REQ_TIPO,
                    SqlDbType.VarChar, RecursosDAOModulo5.TIPO_NO_FUNCIONAL,
                    false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                #endregion

                List<Resultado> resultados = EjecutarStoredProcedure(
                    RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_CODIGO_DE_REQUERIMIENTO,
                    parametros);
                if (resultados != null)
                {
                    foreach (Resultado resultado in resultados)
                    {
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO)
                            && resultado.valor != "")
                        {
                            return resultado.valor;
                        }
                    }
                }
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            #endregion
        }
        #endregion


        #region IDAO
        /// <summary>
        /// Metodo que agrega un requerimiento en la base de datos
        /// </summary>
        /// <param name="parametro">Requerimiento a agregar</param>
        /// <returns>true si se logro agregar</returns>
        public bool Agregar(Dominio.Entidad parametro)
        {
            try
            {
                Dominio.Entidades.Modulo5.Requerimiento requerimiento =
                    (Dominio.Entidades.Modulo5.Requerimiento)parametro;
                int idProyecto = BuscarIdProyecto(requerimiento.CodigoProyecto);
                if (idProyecto > 0)
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
                        EjecutarStoredProcedure(RecursosDAOModulo5.PROCEDIMIENTO_AGREGAR_REQUERIMIENTO,
                        parametros);
                    return true;
                }
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
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
               
                Dominio.Entidades.Modulo5.Requerimiento requerimiento = (Dominio.Entidades.Modulo5.Requerimiento)parametro;
                bool requerimientoModificado = false;
                
                    if (requerimiento != null || requerimiento.Descripcion != ""
                        || requerimiento.Estatus != ""  ||
                        requerimiento.Codigo != "" || requerimiento.Prioridad != "" || requerimiento.Tipo != ""
                        ){
                    #region Asignacion de Parametros bd
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
                    #endregion 

                    List<Resultado> resultados = base.EjecutarStoredProcedure(RecursosDAOModulo5.
                            PROCEDIMIENTO_MODIFICAR_REQUERIMIENTO, parametros);

                        if (resultados != null)
                        {
                            requerimientoModificado = true;
                        }
                        else
                        {
                            requerimientoModificado = false;
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   new ExcepcionesTotem.Modulo5.RequerimientoNoModificadoException());
                           throw new ExcepcionesTotem.Modulo5.
                              RequerimientoNoModificadoException(
                               RecursosDAOModulo5.EXCEPCION_REQ_NO_MOD_CODIGO,
                               RecursosDAOModulo5.EXCEPCION_REQ_NO_MOD_MENSAJE, 
                            new ExcepcionesTotem.Modulo5.RequerimientoNoModificadoException());
                        }
                    
                    }
                    else {
                     ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                            RecursosDAOModulo5.CODIGO_EXCEPCION_REQUERIMIENTO_ERRADO,
                            RecursosDAOModulo5.MENSAJE_EXCEPCION_REQUERIMIENTO_ERRADO,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
                    }
             
                return requerimientoModificado;

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
        /// Metodo que busca a un requerimiento por su codigo
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo</param>
        /// <returns>Requerimiento con todos los datos</returns>
        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
        {
            try
            {
                Dominio.Entidades.Modulo5.Requerimiento requerimiento =
                    (Dominio.Entidades.Modulo5.Requerimiento)parametro;

                #region Asignacion Parametros de BD
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_CODIGO,
                    SqlDbType.VarChar, requerimiento.Codigo, false);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_ID,
                    SqlDbType.Int, true);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_CODIGO_OUTPUT,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_DESCRIPCION,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_TIPO,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_PRIORIDAD,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroBD);
                parametroBD = new Parametro(
                    RecursosDAOModulo5.PARAMETRO_REQ_ESTATUS,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroBD);
                #endregion

                List<Resultado> resultados = EjecutarStoredProcedure(
                    RecursosDAOModulo5.PROCEDIMIENTO_RETORNAR_REQUERIMIENTO_POR_CODIGO,
                    parametros);

                if (resultados != null && resultados.Count > 0)
                {
                    #region Desglosado de resultado
                    foreach (Resultado resultado in resultados)
                    {
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_CODIGO_OUTPUT))
                        {
                            requerimiento.Codigo = resultado.valor;
                        }
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_DESCRIPCION))
                        {
                            requerimiento.Descripcion = resultado.valor;
                        }
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_TIPO))
                        {
                            requerimiento.Tipo = resultado.valor;
                        }
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_PRIORIDAD))
                        {
                            requerimiento.Prioridad = resultado.valor;
                        }
                        if (resultado.etiqueta.Equals(RecursosDAOModulo5.PARAMETRO_REQ_ESTATUS))
                        {
                            requerimiento.Estatus = resultado.valor;
                        }
                    }
                    #endregion
                    return requerimiento;
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
