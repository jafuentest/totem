using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.IntefazDAO.Modulo4
{
    public interface IDaoProyecto : IDao<Dominio.Entidad, Boolean, Dominio.Entidad>
    {
        #region Firma de Metodos Proyecto

	   #region Firma consultarProyectosPorUsuario
	   /// <summary>
	   /// Firma del método que permite consultar todos los proyectos asociados a un
	   /// usuario particular
	   /// </summary>
	   /// <param name="nombreUsuario">Nombre del usuario a consultar</param>
	   /// <returns>Lista con los proyectos asociados a un usuario</returns>
	   List<Dominio.Entidad> consultarProyectosPorUsuario(String nombreUsuario); 
	   #endregion

        # region Firma consultarProyecto
        /// <summary>
        /// Firma del metodo que
        /// consulta un proyecto a la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a consultar</param>
        /// <returns>Entidad con la informacion del proyecto consultado</returns>
        Dominio.Entidad consultarProyecto(String codigo);
        # endregion

        # region Firma eliminarProyecto
        /// <summary>
        /// Firma del metodo que
        /// elimina un proyecto de la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a eliminar</param>
        /// <returns>True si el proyecto fue eliminado excitosamente</returns>

        bool eliminarProyecto(String codigo);
        # endregion

        # region Firma existeProyecto
        /// <summary>
        /// Método para verificar si existe un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a verificar</param>
        /// <returns>Retrorna true si existe o false si no existe</returns>

        bool existeProyecto(String codigo);
        # endregion

        # region Firma contarRequerimientos
        /// <summary>
        /// Método para contar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar </param>
        /// <returns>Retorna el numero de requerimientos </returns>

        int contarRequerimientosProyecto(String codigo);
        # endregion

        # region Firma consultarRequerimientosFinalizadosPorProyecto
        /// <summary>
        /// Método para consultar los requerimientos finalizados de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos finalizados</returns>
        List<Dominio.Entidad> consultarRequerimientosFinalizadosPorProyecto(String codigo);
        # endregion

        # region Firma ConsultarTodoslosClienteNaturales
        /// <summary>
        /// Método para consultar todos los clientes naturales
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        System.Data.DataTable consultarTodoslosClienteNaturales();
        # endregion

        # region Firma obtenerIdClienteNatural
        /// <summary>
        /// Método para consultar el id de un cliente naturale
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        int obtenerIdClienteNatural(String cedula);
        # endregion

        # region Firma buscarProyectos
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
