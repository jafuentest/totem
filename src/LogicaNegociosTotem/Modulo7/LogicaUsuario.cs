using DatosTotem.Modulo7;
using DominioTotem;
using ExcepcionesTotem.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo7
{
    public static class LogicaUsuario
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="elUsuario">usuario a crear</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public static void agregarUsuario(Usuario elUsuario)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            try
            {
                  manejador.ValidarUserNameUnico(elUsuario.username);
                  manejador.ValidarCorreoUnico(elUsuario.correo);
                  elUsuario.CalcularHash();      
                  manejador.RegistrarUsuario(elUsuario);

            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException();
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
            }
            catch (UserNameRepetidoException)
            {
                throw new UserNameRepetidoException();
            }
            catch (CorreoRepetidoException)
            {
                throw new CorreoRepetidoException();
            }
            catch (RegistroUsuarioFallidoException)
            {
                throw new CorreoRepetidoException();
            }
        }
        /// <summary>
        /// Este metodo se utiliza para modificar los datos del usuario seleccionado
        /// </summary>
        /// <param name="elUsuario">usuario a modificar</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public static Boolean ModificarUsuario(DominioTotem.Usuario elUsuario,string antiguoCorreo,string clavenueva)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            try
            {
                if(elUsuario.correo != antiguoCorreo)
                    manejador.ValidarCorreoUnico(elUsuario.correo);
                elUsuario.CalcularHash();
                Usuario datoCompleto = manejador.consultarDatos(elUsuario.username);
                
                if (clavenueva != null)
                    datoCompleto.clave = clavenueva;
                else
                    datoCompleto.clave = manejador.ObtnerClave(elUsuario.username);
                datoCompleto.nombre = elUsuario.nombre;
                datoCompleto.apellido = elUsuario.apellido;
                datoCompleto.preguntaSeguridad = elUsuario.preguntaSeguridad;
                datoCompleto.respuestaSeguridad = elUsuario.respuestaSeguridad;
                datoCompleto.correo = elUsuario.correo;
                elUsuario.clave = datoCompleto.clave;
                manejador.ModificarManejador(datoCompleto);

            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException();
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
            }
            catch (UserNameRepetidoException)
            {
                throw new ExcepcionesTotem.Modulo7.UserNameRepetidoException();
            }
            catch (CorreoRepetidoException)
            {
                throw new ExcepcionesTotem.Modulo7.CorreoRepetidoException();
            }
            catch (ClaveNoValidaException)
            {
                throw new ExcepcionesTotem.Modulo7.ClaveNoValidaException();
            }
            catch (RegistroUsuarioFallidoException)
            {
                throw new ExcepcionesTotem.Modulo7.RegistroUsuarioFallidoException();
            }
            return true;
        }
        /// <summary>
        /// Metodo que lista todos los usuarios existentes
        /// </summary>
        public static void listarUsuario()
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            List<Usuario> listaUsuario = manejador.listar();
        }


        /// <summary>
        /// Metodo que lista todos los cargos de los usuarios
        /// </summary>
        public static List<String> listarCargos()
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            List<String> listaCargos = manejador.ListarCargosUsuarios();
            return listaCargos;
        }

        /// <summary>
        /// Metodo que lista todos los cargos de los usuarios
        /// </summary>
        public static Usuario ObtenerDatos(string userName)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            return manejador.consultarDatos(userName);
        }
    }
}
