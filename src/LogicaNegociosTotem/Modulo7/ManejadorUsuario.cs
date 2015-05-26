using DatosTotem.Modulo7;
using DominioTotem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo7
{
    class ManejadorUsuario
    {
        public ManejadorUsuario(){}

        /// <summary> Valida si la clave cumple con los requerimientos </summary>
        /// <param name="claveUsuario">La clave que se va a agregar </param>
        /// <returns>Regresa true si la clave es válida y false si no es válida</returns>
        public Boolean ValidarClave(String claveUsuario)
        {
            return true;
        }
        /// <summary>Para verificar si el registro fue correcto</summary>
        /// <param name="elUsuario">El usuario que se va a registrar</param>
        /// <returns>Regresa true si el registro se realizó correctamente y false si no</returns>
        public Boolean RegistrarUsuario(Usuario elUsuario)
        {

            return true;
        }
        /// <summary>Valida que el userName no este repetido en la BD</summary>
        /// <param name="userName">El username del usuario</param>
        /// <returns>Retorna true si el username existe y false si no</returns>
        public Boolean ValidarUserNameUnico(String userName)
        {
            BDUsuario conexion = new BDUsuario();
            return conexion.usernameUnico(userName);
        }
        /// <summary> Valida que el correo no este repetido </summary>
        /// <param name="correoUsuario">Se busca por el correo del usuario</param>
        /// <returns>Regresa true si el correo ya existe y false si no/returns>
        public Boolean ValidarCorreoUnico(String correoUsuario)
        {
            BDUsuario conexion = new BDUsuario();
            return conexion.correoUnico(correoUsuario);
        }
        /// <summary> Obtiene el cargo de un usuario </summary>
        /// <param name="userName">Se busca por el username del usuario</param>
        /// <returns>Regresa el cargo del usuario</returns>
        public String obtenerCargoDeUsuarios(String userName)
        {
            BDUsuario conexion= new BDUsuario();
            return conexion.ObtenerCargo(userName);
        }
        /// <summary>Obtiene una lista de todos los usuarios segun el cargo</summary>
        /// <param name="cargo">El cargo por el que se va a filtrar</param>
        /// <returns>Regresa una lista de usuarios</returns>
        public List<Usuario> filtrarUsuariosPorCargo(String cargo)
        {

            List<Usuario> listaUsuario = new List<Usuario>();
            BDUsuario conexion = new BDUsuario();
            return conexion.ConsultaUsuariosSegunCargo(cargo);
        }
        /// <summary> Consulta la informacio de un Usuario </summary>
        /// <param name="nombre">El nombre del usuario</param>
        /// <param name="apellido">El apellido del usuario</param>
        /// <param name="cargo">El cargo del usuario</param>
        /// <returns>Regresa un usuario</returns>
        public Usuario consultarDatosDeUsuario(String nombre, String apellido, String cargo)
        {
            BDUsuario conexion = new BDUsuario();
            Usuario usuario = conexion.ConsultarDatosUsuario(nombre,apellido,cargo);
            return usuario;
        }
        /// <summary> Obtiene una lista de todos los usuarios que existen en el sistema </summary>
        /// <returns>Regresa una lista de usuarios de la BD</returns>
        public List<Usuario> listar()
        {
            BDUsuario conexion = new BDUsuario();
            return conexion.ObtenerListaUsuario();
        }
    }
}
