using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo2
{
    public interface IDaoClienteJuridico : IDao<Entidad, bool, Entidad>
    {
        bool BuscarRifClienteJuridico(Entidad parametro);
        Entidad consultarDatosContactoID(Entidad parametro);
        List<Entidad> consultarListaDeContactosJuridico(Entidad parametro);
        bool eliminarClienteJuridico(Entidad parametro);
        bool eliminarContacto(Entidad parametro);
        List<String> consultarPaises();
        List<String> consultarEstadosPorPais(String elPais);
        List<String> consultarCiudadesPorEstado(String elEstado);
        List<String> consultarListaCargos();
        bool modificarContacto(Entidad parametro);
    }
}
