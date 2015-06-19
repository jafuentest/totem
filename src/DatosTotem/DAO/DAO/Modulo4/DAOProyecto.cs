using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo4;
namespace DAO.DAO.Modulo4
{
    class DAOProyecto : DAO, IntefazDAO.Modulo4.IDaoProyecto
    {

        #region de Metodos Proyecto

        # region agregarProyecto
        /// <summary>
        /// Metodo que
        /// agrega un proyecto a la base de datos
        /// </summary>
        /// <param name="proyecto"> Entidad con los datos del proyecto 
        /// a agregar</param>
        /// <returns>True si el proyecto es creado exitosamente</returns>

        public bool AgregarProyecto(Proyecto proyecto)
        {
            //Si no existe el proyecto se agrega
            if (!existeProyecto(proyecto.codigo))
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
        # endregion

        # region modificarProyecto
        /// <summary>
        /// Metodo que
        /// modifica un proyecto en la base de datos
        /// </summary>
        /// <param name="proyecto">Entidad con los datos del proyecto 
        /// modificado</param>
        /// <param name="codigoAnterior">codigo con los datos del proyecto 
        /// a modificar</param>
        /// <returns>True si el proyecto es modificado exitosamente</returns>

        bool agregarProyecto(Dominio.Entidad proyecto);
        # endregion

        # region consultarProyecto
        /// <summary>
        /// Metodo que
        /// consulta un proyecto a la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a consultar</param>
        /// <returns>Entidad con la informacion del proyecto consultado</returns>

        Dominio.Entidad consultarProyecto(String codigo);
        # endregion

        # region eliminarProyecto
        /// <summary>
        /// Metodo que
        /// elimina un proyecto de la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a eliminar</param>
        /// <returns>True si el proyecto fue eliminado excitosamente</returns>

        bool eliminarProyecto(String codigo);
        # endregion

        # region existeProyecto
        /// <summary>
        /// Método para verificar si existe un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a verificar</param>
        /// <returns>Retrorna true si existe o false si no existe</returns>

        bool existeProyecto(String codigo);
        # endregion

        # region contarRequerimientos
        /// <summary>
        /// Método para contar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar </param>
        /// <returns>Retorna el numero de requerimientos </returns>

        int ContarRequerimientosProyecto(String codigo);
        # endregion

        # region consultarRequerimientosFinalizadosPorProyecto
        /// <summary>
        /// Método para consultar los requerimientos finalizados de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos finalizados</returns>
        List<Dominio.Entidad> consultarRequerimientosFinalizadosPorProyecto(String codigo);
        # endregion

        # region ConsultarTodoslosClienteNaturales
        /// <summary>
        /// Método para consultar todos los clientes naturales
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        System.Data.DataTable ConsultarTodoslosClienteNaturales();
        # endregion

        # region obtenerIdClienteNatural
        /// <summary>
        /// Método para consultar el id de un cliente naturale
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        int obtenerIdClienteNatural(String cedula);
        # endregion

        # region buscarProyectos
        /// <summary>
        /// Método para buscar proyectos en la bd
        /// </summary>
        /// <param name="busqueda">Cadena para la busqueda</param>
        /// <returns>Retrorna los proyectos de relacionado con el parametro</returns>
        System.Data.DataTable buscarProyectos(String busqueda, String username);
        # endregion

        # endregion

    }
}
