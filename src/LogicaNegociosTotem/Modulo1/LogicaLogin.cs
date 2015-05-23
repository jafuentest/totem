using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo1
{
    /// <summary>
    /// Clase para el manejo de la logica de negocio del login del usuario
    /// </summary>
    public class LogicaLogin
    {
        /// <summary>
        /// Atributo para el calculo de los intentos posibles de intento de inicio de sesion del usuario
        /// </summary>
        private int intentos {
            private get {return this.intentos;}
            private set {
                if (this.intentos <=3){
                    this.intentos = value;}
            }
        }

        /// <summary>
        /// Constructor de la clase LogicaLogin, establece el numero de intentos de inicio de sesion
        /// en cero
        /// </summary>
        public LogicaLogin()
        {
            this.intentos = 0;
        }

        /// <summary>
        /// Metodo para verificar el login del usuario
        /// </summary>
        /// <param name="usuario">String con el nombre del usuario que se intenta iniciar sesion</param>
        /// <param name="clave">String con la clave que el usuario ingreso</param>
        /// <returns>Objeto Usuario con los datos del usuario que se encuentra en la base de
        /// datos</returns>
        public DominioTotem.Usuario Login(string usuario, string clave)
        {
            throw new System.NotImplementedException();
        }    

        /// <summary>
        /// Metodo para realizar todo el proceso necesario para la recuperacion de clave del 
        /// usuario
        /// </summary>
        /// <param name="usuario">Usuario que quiere recuperar su clave con su email</param>
        /// <returns>booleano true si se pudo validar la recuperacion</returns>
        public bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            throw new System.NotImplementedException();
        
        }

        /// <summary>
        /// Metodo que genera el link de recuperacion de clave
        /// </summary>
        /// <returns>String con el link generado</returns>
        public string GenerarLink()
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Metodo que envia el email a usuario con el link de recuperacion de clave
        /// </summary>
        /// <returns>Booleano true si se pudo enviar</returns>
        public bool EnviarEmail()
        {
            throw new System.NotImplementedException();

        }
        
        /// <summary>
        /// Metodo para validar la respuesta secreta ingresada por el usuario
        /// </summary>
        /// <param name="respuesta">String con la respuesta que el usuario ingreso</param>
        /// <returns>Booleano true si es la respuesta correcta</returns>
        public bool ValidarRespuestaSecreta(string respuesta)
        {
            throw new System.NotImplementedException();

        }
        
        /// <summary>
        /// Metodo para realizar el cambio de clave de un usuario
        /// </summary>
        /// <param name="usuario">Usuario al que se le quiere cambiar la clave</param>
        /// <returns>Booleano true si se pudo realizar</returns>
        public bool CambioDeClave(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Metodo que maneja el cierre de sesion del usuario
        /// </summary>
        /// <returns>Booleano true si se logro cerrar la sesion</returns>
        public bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

    }
}
