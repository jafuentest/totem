
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatosTotem.Modulo4
{
    /// <summary>
    /// Clase para el manejo de proyectos en la bd
    /// a la BD
    /// </summary>
    public static class BDProyecto
    {

        #region Crear
        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <returns>Retrorna True si se crea, False si no </returns>
        public static bool CrearProyecto(Proyecto proyecto)
        {
           
            //Si no existe el proyecto se agrega 
            if (!ExisteProyecto(proyecto.Codigo))
            {
                try
                {
                    //parametros para insertar un proyecto
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroNombreProyecto, SqlDbType.VarChar, proyecto.Nombre, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroEstadoProyecto, SqlDbType.Bit, proyecto.Estado.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroDescripcionProyecto, SqlDbType.VarChar, proyecto.Descripcion, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroCostoProyecto, SqlDbType.Int, proyecto.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.VarChar, proyecto.Moneda, false);
                    parametros.Add(parametro);

                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyecto, parametros);

                    //si la creacion es correcta retorna true

                    if (resultados != null)
                    {
                        return true;
                    }
                    else
                    {
                        throw new NotImplementedException();

                    }

                }
                catch (NotImplementedException e)
                {
                    throw e;
                }
            }
            else
                //el codigo existe por lo tanto no se crea el proyecto
                throw new ExcepcionesTotem.Modulo4.CodigoRepetidoException(RecursosBDModulo4.CodigoProyectoExiste,
                           RecursosBDModulo4.MensajeCodigoProyectoExiste, new Exception());
        }

        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <param name="clienteJuridico">Cliente juridico del proyecto</param>
        /// <returns>Retrorna True si se crea, False si no </returns>
        public static bool CrearProyecto(Proyecto proyecto, ClienteJuridico clienteJuridico)
        {
            //Si no existe el proyecto se agrega 
            if (!ExisteProyecto(proyecto.Codigo))
            {
                try
                {
                    //parametros para insertar un proyecto
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroNombreProyecto, SqlDbType.VarChar, proyecto.Nombre, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroEstadoProyecto, SqlDbType.Bit, proyecto.Estado.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroDescripcionProyecto, SqlDbType.VarChar, proyecto.Descripcion, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroCostoProyecto, SqlDbType.Int, proyecto.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.VarChar, proyecto.Moneda, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroClienteJuridico, SqlDbType.Int, clienteJuridico.Jur_Id, false);
                    parametros.Add(parametro);


                    BDConexion con = new BDConexion();
                    List<Resultado>  resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyectoClienteJuridico, parametros);
                  

                    //si la creacion es correcta retorna true

                    if (resultados != null)
                    {
                        return true;
                    }
                    else
                    {
                        throw new NotImplementedException();

                    }

                }
                catch (NotImplementedException e)
                {
                    throw e;
                }
            }
            else
                //el codigo existe por lo tanto no se crea el proyecto
                throw new ExcepcionesTotem.Modulo4.CodigoRepetidoException(RecursosBDModulo4.CodigoProyectoExiste,
                           RecursosBDModulo4.MensajeCodigoProyectoExiste, new Exception());
        }


        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <param name="clienteNatural">Cliente natural del proyecto</param>
        /// <returns>Retrorna True si se crea, False si no </returns>
        public static bool CrearProyecto(Proyecto proyecto, ClienteNatural clienteNatural)
        {
           
            //Si no existe el proyecto se agrega 
            if (!ExisteProyecto(proyecto.Codigo))
            {
                try
                {
                    //parametros para insertar un proyecto
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroNombreProyecto, SqlDbType.VarChar, proyecto.Nombre, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroEstadoProyecto, SqlDbType.Bit, proyecto.Estado.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroDescripcionProyecto, SqlDbType.VarChar, proyecto.Descripcion, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroCostoProyecto, SqlDbType.Int, proyecto.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.VarChar, proyecto.Moneda, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo4.ParametroClienteNatural, SqlDbType.Int, clienteNatural.Nat_Id, false);
                    parametros.Add(parametro);


                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyectoClienteNatural, parametros);

                    //si la creacion es correcta retorna true

                    if (resultados != null)
                    {
                        return true;
                    }
                    else
                    {
                        throw new NotImplementedException();

                    }

                }
                catch (NotImplementedException e)
                {
                    throw e;
                }
            }
            else
                //el codigo existe por lo tanto no se crea el proyecto
                throw new ExcepcionesTotem.Modulo4.CodigoRepetidoException(RecursosBDModulo4.CodigoProyectoExiste,
                           RecursosBDModulo4.MensajeCodigoProyectoExiste, new Exception());
        }

        #endregion

        #region Modificar
        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto"> proyecto modificado</param>
        /// <param name="codigoAnterior">codigo del proyecto a modificar</param>
        /// <returns>Retrorna True si se modifica, False si no </returns>
        public static bool ModificarProyecto(Proyecto proyecto, String codigoAnterior)
        {
            //si cambio de codigo y no esta en uso ademas de que el proyecto a modificar existe
            // o si no hay cambio de codigo verifica que existe el proyecto a modificar
            if ((!(proyecto.Codigo.Equals(codigoAnterior)) && (!ExisteProyecto(proyecto.Codigo)) && (ExisteProyecto(codigoAnterior))) ||
                (proyecto.Codigo.Equals(codigoAnterior) && (ExisteProyecto(proyecto.Codigo))))
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroNombreProyecto, SqlDbType.VarChar, proyecto.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroEstadoProyecto, SqlDbType.Bit, proyecto.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroDescripcionProyecto, SqlDbType.VarChar, proyecto.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroCostoProyecto, SqlDbType.Int, proyecto.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.VarChar, proyecto.Moneda, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroCodigoAnteriorProyecto, SqlDbType.VarChar, codigoAnterior, false);
                parametros.Add(parametro);

                try
                {
                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoModificarProyecto, parametros);
                    if (resultados != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }

                }
                catch (NotImplementedException e)
                {
                    throw e;
                }
            }
            else
                return false;
        }
        #endregion

        #region Consultar
        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar</param>
        /// <returns>Retrorna el proyecto</returns>
        public static Proyecto ConsultarProyecto(String codigo)
        {
            try
            {
                //parametros para consultar un proyecto
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroCodigoConsultaProyecto, SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroNombreProyecto, SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroEstadoProyecto, SqlDbType.Bit, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroDescripcionProyecto, SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroCostoProyecto, SqlDbType.Int, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.VarChar, true);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoConsultarProyecto, parametros);


                if (resultados != null)
                {
                    Proyecto proyecto;
                    if (bool.Parse(resultados[2].valor))
                    {
                        proyecto=new Proyecto(resultados[0].valor, resultados[1].valor, true, resultados[3].valor, resultados[5].valor, int.Parse(resultados[4].valor));
                        return proyecto;
                    }
                    if (!bool.Parse(resultados[2].valor))
                    {
                        proyecto= new Proyecto(resultados[0].valor, resultados[1].valor, false, resultados[3].valor, resultados[5].valor, int.Parse(resultados[4].valor));
                        return proyecto;
                    }
                    return null; 
                }
                else
                {
                    return null; 

                }

            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="username">nombre del usuario a consultar </param>
        /// <returns>Retrorna los proyecto de los usuarios</returns>
        public static DataTable ConsultarProyectosUsuario(String username)
        {
            try
            {

                //parametros para consultar un proyecto
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroUsuario, SqlDbType.VarChar, username, false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientosProyectosDeUsuario, parametros);


                if (resultados.Rows.Count > 0)
                {
                    return resultados;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo4.InvolucradosInexistentesException(RecursosBDModulo4.CodigoInvolucradosInexistentes,
                     RecursosBDModulo4.MensajeInvolucradosInexistentes, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo4.InvolucradosInexistentesException e)
            {
                throw e;
            }
        }

        #endregion

        #region Eliminar
        /// <summary>
        /// Método para Eliminar un proyecto en la bd(solo para pruebas unitarias)
        /// </summary>
        /// <param name="codigo">codigo del proyecto a Eliminar</param>
        /// <returns>Retrorna True si se modifica, False si no </returns>
        public static bool EliminarProyecto(String codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
            parametros.Add(parametro);
            try
            {
                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoEliminarProyecto, parametros);
                if (resultados != null)
                {
                    return true;
                }
                else
                {
                    throw new NotImplementedException();

                }

            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }
        #endregion

        #region Existe

        /// <summary>
        /// Método para verificar si existe un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a verificar</param>
        /// <returns>Retrorna true si existe o false si no existe</returns>
        public static bool ExisteProyecto(String codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosBDModulo4.ParametroResultado, SqlDbType.Int, true);
            parametros.Add(parametro);



            BDConexion con = new BDConexion();
            List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoExisteProyecto, parametros);


            if (int.Parse(resultados[0].valor) == 1)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Contar Requerimientos

        /// <summary>
        /// Método para contar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar </param>
        /// <returns>Retorna el numero de requerimientos </returns>
        public static int ContarRequerimientosProyecto(String codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosBDModulo4.ParametroResultado, SqlDbType.Int, true);
            parametros.Add(parametro);



            BDConexion con = new BDConexion();
            List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoContarRequerimientosProyecto, parametros);


            if (resultados != null)
            {
                return int.Parse(resultados[0].valor);
            }
            else
                return 0;
        }


        /// <summary>
        /// Método para contar los requerimientos finalizados de un proyecto
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar </param>
        /// <returns>Retorna el numero de requerimientos finalizados </returns>
        public static int ContarRequerimientosFinalizadosProyecto(String codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosBDModulo4.ParametroResultado, SqlDbType.Int, true);
            parametros.Add(parametro);



            BDConexion con = new BDConexion();
            List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProccedimientoContarRequerimientosFinalizadosProyecto, parametros);


            if (resultados != null)
            {
                return int.Parse(resultados[0].valor);
            }
            else
                return 0;
        }

        #endregion

        #region Consultar Requerimientos

        /// <summary>
        /// Método para consultar los requerimientos finalizados de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos finalizados</returns>
        public static List<Requerimiento> ConsultarRequerimientosFinalizadosPorProyecto(String codigo)
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroUsuario, SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoConsultarRequerimientosFinalizadosPorProyecto, parametros);


                if (resultados.Rows.Count > 0)
                {
                    

                    List<Requerimiento> listaRequerimientos =
                       new List<Requerimiento>();

                    foreach (DataRow fila in resultados.Rows)
                    {
                        listaRequerimientos.Add(
                            new DominioTotem.Requerimiento(
                               Convert.ToInt32(fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ID]),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_TIPO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
                            )
                        );
                    }

                    return listaRequerimientos;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo4.RequerimientosInexistentesException(RecursosBDModulo4.CodigoRequerimientosInexistentes,
                     RecursosBDModulo4.MensajeRequerimientosInexistentes, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo4.RequerimientosInexistentesException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para consultar los requerimientos funcionales de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos funcionales</returns>
        public static List<Requerimiento> ConsultarRequerimientosFuncionalesPorProyecto(String codigo)
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroUsuario, SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoConsultarRequerimientosFuncionalesPorProyecto, parametros);


                if (resultados.Rows.Count > 0)
                {
                    List<Requerimiento> listaRequerimientos =
                      new List<Requerimiento>();

                    foreach (DataRow fila in resultados.Rows)
                    {
                        listaRequerimientos.Add(
                            new DominioTotem.Requerimiento(
                               Convert.ToInt32(fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ID]),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_TIPO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
                            )
                        );
                    }

                    return listaRequerimientos;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo4.RequerimientosInexistentesException(RecursosBDModulo4.CodigoRequerimientosInexistentes,
                     RecursosBDModulo4.MensajeRequerimientosInexistentes, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo4.RequerimientosInexistentesException e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Método para consultar los requerimientos no funcionales de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos no funcionales</returns>
        public static List<Requerimiento> ConsultarRequerimientosNoFuncionalesPorProyecto(String codigo)
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroUsuario, SqlDbType.VarChar, codigo, false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoConsultarRequerimientosNoFuncionalesPorProyecto, parametros);


                if (resultados.Rows.Count > 0)
                {
                    List<Requerimiento> listaRequerimientos =
                        new List<Requerimiento>();

                    foreach (DataRow fila in resultados.Rows)
                    {
                        listaRequerimientos.Add(
                            new DominioTotem.Requerimiento(
                               Convert.ToInt32(fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ID]),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_TIPO].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
                               fila[DatosTotem.Modulo5.RecursosBDModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
                            )
                        );
                    }

                    return listaRequerimientos;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo4.RequerimientosInexistentesException(RecursosBDModulo4.CodigoRequerimientosInexistentes,
                     RecursosBDModulo4.MensajeRequerimientosInexistentes, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo4.RequerimientosInexistentesException e)
            {
                throw e;
            }
        }


        #endregion 

        #region Mostrar Clientes




        /// <summary>
        /// Método para cnsultar todos los clientes naturales
        /// </summary>
        /// <returns>Retrorna todos los clientes naturales</returns>
        public static DataTable ConsultarTodoslosClienteNaturales()
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoConsultarTodosClientesNaturales, parametros);


                if (resultados.Rows.Count > 0)
                {
                    return resultados;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo2.ClienteInexistenteException(DatosTotem.Modulo2.RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                     DatosTotem.Modulo2.RecursosBaseDeDatosModulo2.MensajeClienteInexistente, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo2.ClienteInexistenteException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para cnsultar todos los clientes juridicos
        /// </summary>
        /// <returns>Retrorna todos los clientes juridicos</returns>
        public static DataTable ConsultarTodoslosClienteJuridicos()
        {
            try
            {

                List<Parametro> parametros = new List<Parametro>();
                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoConsultarTodosClientesJuridicos, parametros);


                if (resultados.Rows.Count > 0)
                {
                    return resultados;
                }
                else
                {

                    throw new ExcepcionesTotem.Modulo2.ClienteInexistenteException(DatosTotem.Modulo2.RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                     DatosTotem.Modulo2.RecursosBaseDeDatosModulo2.MensajeClienteInexistente, new Exception());

                }

            }
            catch (ExcepcionesTotem.Modulo2.ClienteInexistenteException e)
            {
                throw e;
            }
        }



        #endregion

        #region Buscar


        /// <summary>
        /// Método para buscar proyectos en la bd
        /// </summary>
        /// <param name="busqueda">Cadena para la busqueda</param>
        /// <returns>Retrorna los proyectos de relacionado con el parametro</returns>
        public static DataTable BuscarProyectos(String busqueda)
        {
            

                //parametros para buscar proyectos
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroBusqueda, SqlDbType.VarChar, busqueda, false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoBuscarProyecto, parametros);


                if (resultados.Rows.Count > 0)
                {
                    return resultados;
                }
                else
                {

                    return null;

                }

            
        }


        /// <summary>
        /// Método para buscar los proyectos inactivos en la bd
        /// </summary>
        /// <param name="busqueda">Cadena para la busqueda</param>
        /// <returns>Retrorna los proyectos de relacionado con el parametro</returns>
        public static DataTable BuscarProyectosInactivos(String busqueda)
        {


            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroBusqueda, SqlDbType.VarChar, busqueda, false);
            parametros.Add(parametro);

            BDConexion con = new BDConexion();
            DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoBuscarProyectoInactivo, parametros);


            if (resultados.Rows.Count > 0)
            {
                return resultados;
            }
            else
            {

                return null;

            }


        }

        /// <summary>
        /// Método para buscar los proyectos activos en la bd
        /// </summary>
        /// <param name="busqueda">Cadena para la busqueda</param>
        /// <returns>Retrorna los proyectos activos de relacionado con el parametro</returns>
        public static DataTable BuscarProyectosActivos(String busqueda)
        {


            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroBusqueda, SqlDbType.VarChar, busqueda, false);
            parametros.Add(parametro);

            BDConexion con = new BDConexion();
            DataTable resultados = con.EjecutarStoredProcedureTuplas(RecursosBDModulo4.ProcedimientoBuscarProyectoActivo, parametros);


            if (resultados.Rows.Count > 0)
            {
                return resultados;
            }
            else
            {

                return null;

            }


        }

        #endregion
    }
}
