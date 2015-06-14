using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo2
{
    public interface IDaoClienteNatural : IDao<Entidad, bool, Entidad>
    {
        bool eliminarClienteNatural(Entidad parametro);
        List<String> consultarPaises();
        List<String> consultarEstadosPorPais(String elPais);
        List<String> consultarCiudadesPorEstado(String elEstado);

    }
}
