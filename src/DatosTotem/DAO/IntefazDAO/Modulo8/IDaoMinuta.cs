using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo8
{
    public interface IDaoMinuta : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Firma del metodo que devuelve una lista de todas las minutas asociadas a un Proyecto
        /// </summary>
        /// <param name="idProyecto">id de proyecto que se desea buscar</param>
        /// <returns>Retorna lista de minutas</returns>
        List<Entidad> ConsultarMinutasProyecto(string idProyecto);
        /// <summary>
        ///  Firma del Metodo para eliminar una minuta
        /// </summary>
        /// <param name="idMinuta">Id de la Minuta a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        bool EliminarMinuta(int idMinuta);
       

        
        /// <summary>
        /// Firma del método para consultar los datos de una minuta en la BD
        /// </summary>
        /// <param name="id">Se recibe el id de la minuta que se desea consultar</param>
        /// <returns>Retrorna el objeto Minuta</returns>
        Entidad ConsultarMinutaBD(int id);

        /// <summary>
        /// Firma del metodo para buscar la ultima minuta en bd
        /// </summary>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        int BuscarUltimaMinuta();

         /// <summary>
        /// firma del metodo para guardar una Minuta en la BD
        /// </summary>
        /// <param name="parametro">Objeto de tipo Minuta</param>
        /// <returns>retorna el id de la minuta insertada en caso contrario retorna 0</returns>
        int AgregarMinuta(Entidad parametro);
    }
}