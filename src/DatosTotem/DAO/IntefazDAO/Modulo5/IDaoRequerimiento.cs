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
        bool EliminarRequerimiento(Dominio.Entidad requerimiento, int idProyecto);

        /// <summary>
        /// Firma de Metodo que 
        /// busca los requerimientos asociados a un proyecto
        /// </summary>
        /// <param name="codigoProyecto">codigo del proyecto</param>
        /// <returns>Lista de requerimientos del proyecto</returns>
        List<Dominio.Entidad> ConsultarRequerimientoDeProyecto(String codigoProyecto);

        /// <summary>
        /// Firma de Metodo que 
        /// agrega un requerimiento en la base de datos
        /// </summary>
        /// <param name="requerimiento"></param>
        /// <returns></returns>
        bool AgregarRequerimiento(Dominio.Entidad requerimiento, int idProyecto);

        /// <summary>
        /// Firma de metodo que busca el requerimiento en la base de datos
        /// por el codigo
        /// </summary>
        /// <param name="codigo">Codigo del proyecto</param>
        /// <returns>El requerimiento como una entidad</returns>
        Dominio.Entidad BuscarRequerimientoPorCodigo(String codigoProyecto);
     
        #endregion
    }
}
