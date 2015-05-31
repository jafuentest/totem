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
        /// <param name="antiguoCorreo">EL correo del usuario</param> 
        /// <param name="nuevaClave">La nueva clave introducida por el usuario</param> 
        /// <returns>returno true si se realizo bien y false, si no se realizo</returns>
        public static Boolean ModificarUsuario(DominioTotem.Usuario elUsuario,string nuevaClave)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            Boolean claveCoincide = true;
            try
            {
                //obtiene los datos actuales del usuario
                Usuario datoCompleto = manejador.consultarDatos(elUsuario.username);
                //compara para saber si el usuario no realizo cambio a su correo.
                if(elUsuario.correo != datoCompleto.correo)
                    //en caso de que el usuario halla decidido cambiar de correo,valida si ese nuevo correo es unico
                    manejador.ValidarCorreoUnico(elUsuario.correo);

                //obtiene la clave actual del usuario
                datoCompleto.clave = manejador.ObtnerClave(elUsuario.username);
                //Es para saber si el usuario quiere cambiar de clave
                if (elUsuario.clave != null)
                {
                    //calcula el hash de la nueva clave
                    elUsuario.CalcularHash();
                    //compara para saber si la la clave actual del usuario es la misma que esta 
                    //en la base de datos.
                    if (datoCompleto.clave == elUsuario.clave)
                    {
                        //para saber si existe una nueva clave
                        if(nuevaClave != ""){
                            //en caso de que exista una nueva clave, que reemplazara la actual
                            datoCompleto.clave = nuevaClave;
                            datoCompleto.CalcularHash();
                        }else{
                            //si no hay ninguna clave con que reemplazar a la actual
                            //se mantiene la que ya existe
                            datoCompleto.clave = elUsuario.clave;
                        }
                    }
                    else
                    {
                        //en caso de que la clave introducida no coincida con la que esta en 
                        //la base de datos se le agrega false a la variable.
                        claveCoincide = false;
                    }           
                }
                //sobrrescribe los datos actuales del usuario con los datos nuevos
                datoCompleto.nombre = elUsuario.nombre;
                datoCompleto.apellido = elUsuario.apellido;
                datoCompleto.preguntaSeguridad = elUsuario.preguntaSeguridad;
                datoCompleto.respuestaSeguridad = elUsuario.respuestaSeguridad;
                datoCompleto.correo = elUsuario.correo;
                elUsuario.clave = datoCompleto.clave;
                //si es false lanza una excepcion
                //si no, entonces modifica los datos del usuario
                if (claveCoincide == false)
                    throw new ClaveNoValidaException();
                else
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
