using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo5
{
    public interface IDaoRequerimiento : IDao<Dominio.Entidad, Boolean, Dominio.Entidad>
    {
        #region Firma de Metodos
   
        /// <summary>
        /// Firma de metodo que
        /// busca el ID de un proyecto dado el codigo de el
        /// </summary>
        /// <param name="codigo">Codigo del proyecto</param>
        /// <returns>integer con el id del proyecto</returns>
        int BuscarIdProyecto(String codigo);

        /// <summary>
        /// Firma de metodo que
        /// Verifica el requerimiento con la informacion de la base de datos
        /// </summary>
        /// <param name="requerimiento">Entidad con la informacion del
        /// requerimiento</param>
        /// <returns>retorna true si existe</returns>
        bool VerificarRequerimiento(Dominio.Entidad requerimiento);

        /// <summary>
        /// Firma de metodo que
        /// elimina de la base de datos el requerimiento de un proyecto
        /// </summary>
        /// <param name="requerimiento">Requerimiento a eliminar</param>
        /// <param name="idProyecto">string con el id del proyecto</param>
        /// <returns>retorna true si se logro eliminar</returns>
        bool EliminarRequerimiento(Dominio.Entidad requerimiento);


        /// <summary>
        /// Metodo que retorna todos los requerimientos asociados a un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo del proyecto</param>
        /// <returns>Lista de requerimientos</returns>
        List<Dominio.Entidad> ConsultarRequerimientoDeProyecto(string codigoProyecto);

        /// <summary>
        /// Metodo que retorna los codigos de requerimiento
        /// </summary>
        /// <param name="requerimiento">Requerimiento con el codigo del proyecto
        /// y el tipo</param>
        /// <returns>Lista de String con los dos posibles valor a tomar, si es 
        /// funcional o no funcional</returns>
        List<String> ObtenerCodigoRequerimiento(String requerimiento);

        /// <summary>
        /// Metodo que retorna el codigo del requerimiento funcional
        /// </summary>
        /// <param name="idProyecto">int del id del proyecto</param>
        /// <returns>String con el codigo</returns>
        String ObtenerCodigoRequerimientoFuncional(int idProyecto);

        /// <summary>
        /// Metodo que retorna el codigo del requerimiento no funcional
        /// </summary>
        /// <param name="idProyecto">int del id del proyecto</param>
        /// <returns>String con el codigo</returns>
        String ObtenerCodigoRequerimientoNoFuncional(int idProyecto);
        #endregion
    }
}
