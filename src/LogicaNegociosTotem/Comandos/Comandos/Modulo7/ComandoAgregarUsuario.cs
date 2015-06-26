using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Entidades.Modulo7;
using Comandos.Fabrica;
using DAO.DAO.Modulo7;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para Agregar un Usuario a la Base de Datos
    /// </summary>
    public class ComandoAgregarUsuario : Comando<Entidad,bool>
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="parametro">usuario a crear</param>
        /// <returns>returns true si se realizo bien y false, si no se realizo</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            //Variable que retornara el exito o fallo del registro
            bool exito = false;
                      
            Comando<String, bool> validarUsername = FabricaComandos.CrearComandoValidarUsernameUnico();
            Comando<String, bool> validarCorreo = FabricaComandos.CrearComandoValidarCorreoUnico();
            Usuario elUsuario = (Usuario)parametro;
            Console.WriteLine("NO HE ENTRADO EN EL IF");
            //   try
            //   {
             if (validarUsername.Ejecutar(elUsuario.Username) && validarCorreo.Ejecutar(elUsuario.Correo) == true)
            {
                Console.WriteLine("ENTRE EN EL IF");
                //elUsuario.CalcularHash();
                //    manejador.RegistrarUsuario(parametro);
                FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();
                IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();
                exito = daoUsuario.AgregarUsuario(parametro);

            }
                
                       
                        
            //    manejador.ValidarUserNameUnico(elUsuario.username);
             //   manejador.ValidarCorreoUnico(elUsuario.correo);
             //   elUsuario.CalcularHash();
            //    manejador.RegistrarUsuario(elUsuario);

         /*   }
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
            }*/
                //Retornamos la respuesta
                 return exito;
        }
    }
}
