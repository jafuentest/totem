using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.IntefazDAO.Modulo3
{
    public interface IDaoInvolucrados: IDao<Entidad, bool, Entidad>
    {
        bool AgregarUsuariosInvolucrados(ListaInvolucradoUsuario listaUsuarios);
        bool AgregarContactosInvolucrados(ListaInvolucradoContacto listaContactos);
        ListaInvolucradoUsuario ConsultarUsuariosInvolucradosPorProyecto(Proyecto p);
        ListaInvolucradoContacto ConsultarContactosInvolucradosPorProyecto(Proyecto p);
        bool EliminarContactoDeIvolucradosEnProyecto(Contacto c, ListaInvolucradoContacto l);
        bool EliminarUsuariosDeIvolucradosEnProyecto(Usuario u, ListaInvolucradoUsuario l);
        List<String> ConsultarCargosContactos(ClienteJuridico laEmpresa);
        Usuario DatosUsuarioUsername(String user);
        Contacto DatosContactoID(int idCon);
        List<Contacto> ListarContactosPorCargoEmpresa(ClienteJuridico laEmpresa, String cargo);
        bool Agregar(Dominio.Entidad parametro);
        bool Modificar(Dominio.Entidad parametro);
        Dominio.Entidad ConsultarXId(Dominio.Entidad parametro);
        List<Dominio.Entidad> ConsultarTodos();
    }
}
