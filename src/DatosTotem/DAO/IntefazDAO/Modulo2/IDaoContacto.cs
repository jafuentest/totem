using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo2
{
    public interface IDaoContacto : IDao<Entidad,bool,Entidad>
    {
        bool BuscarCIContacto(String cedulaCon);
    }
}
