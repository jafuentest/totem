using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.IntefazDAO.Modulo3
{
    public interface IDaoInvolucrados: IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Firma de metodo que permite agregar usuarios a involucrados
        /// </summary>
        /// <param name="codigo">usuarios</param>
        /// <returns>true si se inserto correctamente</returns>
        bool AgregarUsuariosInvolucrados(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite agregar contactos a involucrados
        /// </summary>
        /// <param name="codigo">usuarios</param>
        /// <returns>true si se inserto correctamente</returns>
        bool AgregarContactosInvolucrados(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite obetener usuarios involucrados de un proyecto
        /// </summary>
        /// <param name="codigo">proyecto</param>
        /// <returns>usuarios involucrados</returns>
        Entidad ConsultarUsuariosInvolucradosPorProyecto(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite obetener contactos involucrados de un proyecto
        /// </summary>
        /// <param name="codigo">proyecto</param>
        /// <returns>contactos involucrados</returns>
        Entidad ConsultarContactosInvolucradosPorProyecto(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite eliminar contactos involucrados de un proyecto
        /// </summary>
        /// <param name="codigo">proyecto, contacto</param>
        /// <returns>true si se elimino correctamente</returns>
        bool EliminarContactoDeIvolucradosEnProyecto(Entidad parametroc, Entidad parametrol);
        /// <summary>
        /// Firma de metodo que permite eliminar usuario involucrados de un proyecto
        /// </summary>
        /// <param name="codigo">proyecto, usuario</param>
        /// <returns>true si se elimino correctamente</returns>
        bool EliminarUsuariosDeIvolucradosEnProyecto(Entidad parametrou, Entidad parametrol);
        /// <summary>
        /// Firma de metodo que permite consultar los cargos de los contactos
        /// </summary>
        /// <param name="codigo">empresa</param>
        /// <returns>lista de cargos</returns>
        List<String> ConsultarCargosContactos(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite consultar los datos de los usuarios 
        /// </summary>
        /// <param name="codigo">username</param>
        /// <returns>usuario</returns>
        Entidad DatosUsuarioUsername(String user);
        /// <summary>
        /// Firma de metodo que permite consultar los datos del contacto
        /// </summary>
        /// <param name="codigo">ID</param>
        /// <returns>contacto</returns>
        Entidad DatosContactoID(int idCon);
        /// <summary>
        /// Firma de metodo que permite obtener los contactos de una empresa
        /// </summary>
        /// <param name="codigo">empresa</param>
        /// <returns>lista de contactos</returns>
        List<Entidad> ListarContactosPorEmpresa(Entidad parametro);
        /// <summary>
        /// Firma de metodo que permite obetenr los contactos por cargo de una empresa
        /// </summary>
        /// <param name="codigo">empresa, cargo</param>
        /// <returns>Lista contactos</returns>
        List<Entidad> ListarContactosPorCargoEmpresa(Entidad parametro, String cargo);

         bool Agregar(Dominio.Entidad parametro);
        bool Modificar(Dominio.Entidad parametro);
        Dominio.Entidad ConsultarXId(Dominio.Entidad parametro);
        List<Dominio.Entidad> ConsultarTodos();
    }
}
