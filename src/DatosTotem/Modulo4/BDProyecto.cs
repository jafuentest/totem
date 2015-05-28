
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
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, true);
            parametros.Add(parametro);
           
            
            
            BDConexion con = new BDConexion();
            List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoExisteProyecto, parametros);


            if (bool.Parse(resultados[0].valor) == true)
            {
                try
                {

                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, proyecto.Codigo, false);
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


                    con = new BDConexion();
                    resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyecto, parametros);
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
            parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.Int, clienteJuridico.Jur_Id, false);
            parametros.Add(parametro);

            try
            {
                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyectoClienteJuridico, parametros);
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


        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <param name="clienteNatural">Cliente natural del proyecto</param>
        /// <returns>Retrorna True si se crea, False si no </returns>
        public static bool CrearProyecto(Proyecto proyecto, ClienteNatural clienteNatural)
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
            parametro = new Parametro(RecursosBDModulo4.ParametroMonedaProyecto, SqlDbType.Int, clienteNatural.Nat_Id, false);
            parametros.Add(parametro);

            try
            {
                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo4.ProcedimientoAgregarProyectoClienteNatural, parametros);
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


        #region Modificar
        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto"> proyecto modificado</param>
        /// <param name="codigoViejo">codigo del proyecto a modificar</param>
        /// <returns>Retrorna True si se modifica, False si no </returns>
        public static bool ModificarProyecto(Proyecto proyecto, String codigoViejo)
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
            parametro = new Parametro(RecursosBDModulo4.ParametroCodigoViejoProyecto, SqlDbType.VarChar, codigoViejo, false);
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
                    throw new NotImplementedException();

                }

            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }
        #endregion

        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar</param>
        /// <returns>Retrorna el proyecto</returns>
        public static Proyecto ConsultarProyecto(String codigo)
        {
            throw new System.NotImplementedException();
        }


    }
}
