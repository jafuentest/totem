using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;

namespace DatosTotem.Modulo3
{
    public static class BDInvolucrados
    {
        /// <summary>
        /// Metodo que agrega la lista de usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de usuarios a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarUsuariosInvolucrados(ListaInvolucradoUsuario lista)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que agrega la lista de contactos involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de contactos a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarContactosInvolucrados(ListaInvolucradoContacto lista)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que consulta los usuarios involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de usuarios involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoUsuario consultarUsuariosInvolucradosPorProyecto(Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que consulta los contactos involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de contactos involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoContacto consultarContactosInvolucradosPorProyecto(Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que elimina un contacto involucrado a un proyecto
        /// </summary>
        /// <param name="c">contacto a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarContactoDeIvolucradosEnProyecto(Contacto c, Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que elimina un usuario involucrado a un proyecto
        /// </summary>
        /// <param name="c">usuario a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarUsuariosDeIvolucradosEnProyecto(Usuario u, Proyecto p)
        {
            throw new NotImplementedException();
        }

    }
}
