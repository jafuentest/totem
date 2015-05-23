using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    class Usuario
    {
        public string username { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string rol { get; set; }
        public string correo { get; set; }
        public string preguntaSeguridad { get; set; }
        public string respuestaSeguridad { get; set; }
        public string cargo { get; set; }


        public Usuario() { 
        
        }


        //Por implementar
        public Boolean RegistrarUsuario() {
             
            return true;
        }

        public Boolean ModificarUsuario()
        {

            return true;
        }

        public Boolean ValidarCorreo()
        {

            return true;
        }

        public Boolean ValidarUsuario()
        {

            return true;
        }

        public Boolean RegistrarUsuario()
        {

            return true;
        }

        public List<String> obtenerCargoDeUsuarios()
        {
            List<String> listaCargo = new List<String>();

            return listaCargo;
        }

           public List<Usuario> filtrarUsuariosPorCargo(String cargo)
        {

            List<Usuario> listaUsuario = new List<Usuario>();

            return listaUsuario;
        }

           public Usuario consultarDatosDeUsuario(String nombre, String apellido, String cargo)
        {
            Usuario usuario = new Usuario();

            return usuario;
        }
    
    }
}
