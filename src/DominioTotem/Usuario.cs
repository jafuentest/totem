using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DominioTotem
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string rol { get; set; }
        public string correo { get; set; }
        public string preguntaSeguridad { get; set; }
        public string respuestaSeguridad { get; set; }
        public string cargo { get; set; }


        public Usuario()
        {

        }

        public Usuario(int idUsuario, string username, string clave, string nombre, string apellido, string rol, string correo, string preguntaSeguridad, string respuestaSeguridad, string cargo)
        {
            this.idUsuario = idUsuario;
            this.username = username;
            this.clave = clave;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.correo = correo;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.cargo = cargo;
        }
        public Usuario(string username, string clave, string nombre, string apellido, string rol, string correo, string preguntaSeguridad, string respuestaSeguridad, string cargo)
        {
            this.username = username;
            this.clave = clave;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.correo = correo;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.cargo = cargo;
        }

        public void ModificarUsuario(Usuario usuario)
        {
            this.username = usuario.username;
            this.clave = usuario.clave;
            this.nombre = usuario.nombre;
            this.apellido = usuario.apellido;
            this.rol = usuario.rol;
            this.correo = usuario.correo;
            this.preguntaSeguridad = usuario.preguntaSeguridad;
            this.cargo = usuario.cargo;
        }

        public Boolean ValidarCorreo(String correoValidar)
        {
            if (this.correo == correoValidar)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Metodo que le calcula el hash a la clave actual del usuario y se la cambia al objeto con 
        /// la nueva clave creada
        /// </summary>
        public void CalcularHash()
        {
            if (this.clave != null)
            {
                byte[] claveEnBytes = new byte[this.clave.Length * sizeof(char)];
                System.Buffer.BlockCopy(this.clave.ToCharArray(), 0, claveEnBytes, 0, claveEnBytes.Length);
                SHA256 shaM = new SHA256Managed();
                byte[] hashClave = shaM.ComputeHash(claveEnBytes);
                this.clave = BitConverter.ToString(hashClave);
            }
        }

    }
}
