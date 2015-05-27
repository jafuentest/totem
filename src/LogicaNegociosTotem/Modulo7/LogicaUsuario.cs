using DatosTotem.Modulo7;
using DominioTotem;
using ExcepcionesTotem.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo7
{
    class LogicaUsuario
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="elUsuario">usuario a crear</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public Boolean agregarUsuario(Usuario elUsuario)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            try
            {
                   manejador.ValidarUserNameUnico(elUsuario.username); 
                   manejador.ValidarCorreoUnico(elUsuario.correo);
                   manejador.ValidarClave(elUsuario.clave);
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
                
            }
            catch (CorreoRepetidoException)
            {
            }
            catch (ClaveNoValidaException)
            {
            }
            catch (RegistroUsuarioFallidoException)
            {
            }
            return true;
        }
        /// <summary>
        /// Este metodo se utiliza para modificar los datos del usuario seleccionado
        /// </summary>
        /// <param name="elUsuario">usuario a modificar</param>
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public Boolean modificarUsuario(DominioTotem.Usuario elUsuario)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            try
            {
                manejador.ValidarUserNameUnico(elUsuario.username);
                manejador.ValidarCorreoUnico(elUsuario.correo);
                manejador.ValidarClave(elUsuario.clave);
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

            }
            catch (CorreoRepetidoException)
            {
            }
            catch (ClaveNoValidaException)
            {
            }
            catch (RegistroUsuarioFallidoException)
            {
            }
            return true;
        }
        /// <summary>
        /// Metodo que lista todos los usuarios existentes
        /// </summary>
        public void listarUsuario()
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            List<Usuario> listaUsuario = manejador.listar();
        }
    }
}
