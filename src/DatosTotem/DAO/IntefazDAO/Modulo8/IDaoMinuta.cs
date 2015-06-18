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
        /// Firma del Metodo para eliminar una minuta
        /// </summary>
        /// <param name="idMinuta">Minuta a eliminar</param>
        /// <returns>retorna true si se elimina </returns>
        bool EliminarMinuta(int idMinuta);
       
    }
}