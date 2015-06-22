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
        bool AgregarUsuariosInvolucrados(Entidad parametro);
        bool AgregarContactosInvolucrados(Entidad parametro);
        Entidad ConsultarUsuariosInvolucradosPorProyecto(Entidad parametro);
        Entidad ConsultarContactosInvolucradosPorProyecto(Entidad parametro);
        bool EliminarContactoDeIvolucradosEnProyecto(Entidad parametroc, Entidad parametrol);
        bool EliminarUsuariosDeIvolucradosEnProyecto(Entidad parametrou, Entidad parametrol);
        List<String> ConsultarCargosContactos(Entidad parametro);
        Entidad DatosUsuarioUsername(String user);
        Entidad DatosContactoID(int idCon);
        List<Entidad> ListarContactosPorEmpresa(Entidad parametro);
        List<Entidad> ListarContactosPorCargoEmpresa(Entidad parametro, String cargo);
        bool Agregar(Dominio.Entidad parametro);
        bool Modificar(Dominio.Entidad parametro);
        Dominio.Entidad ConsultarXId(Dominio.Entidad parametro);
        List<Dominio.Entidad> ConsultarTodos();
    }
}
