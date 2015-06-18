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
        ///  Firma del Metodo para eliminar una minuta
        /// </summary>
        /// <param name="idMinuta">Id de la Minuta a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        bool EliminarMinuta(int idMinuta);
       
    }
}