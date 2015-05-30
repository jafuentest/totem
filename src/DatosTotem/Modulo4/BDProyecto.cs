
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

                //parametros para insertar un proyecto
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
        /// <returns>Retrorna el proyecto</returns>
        public static DataTable ConsultarProyectosUsuario(String username)
        {
            try
            {

                //parametros para insertar un proyecto
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo4.ParametroUsuario, SqlDbType.VarChar, username, false);
                parametros.Add(parametro);
                /*parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, true);
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
                parametros.Add(parametro);*/

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

    }
}
