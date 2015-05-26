using DatosTotem.Modulo7;
using DominioTotem;
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
                
                if (manejador.ValidarUserNameUnico(elUsuario.username))
                {
                    if (manejador.ValidarCorreoUnico(elUsuario.correo))
                    {
                        if(manejador.ValidarClave(elUsuario.clave)){
                            elUsuario.CalcularHash();
                            if (manejador.RegistrarUsuario(elUsuario))
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException();
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
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

                if (manejador.ValidarUserNameUnico(elUsuario.username))
                {
                    if (manejador.ValidarCorreoUnico(elUsuario.correo))
                    {
                        if (manejador.ValidarClave(elUsuario.clave))
                        {
                            elUsuario.CalcularHash();
                            if (manejador.RegistrarUsuario(elUsuario))
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException();
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
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
