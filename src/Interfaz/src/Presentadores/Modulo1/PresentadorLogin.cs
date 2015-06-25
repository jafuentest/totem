using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo7;

namespace Presentadores.Modulo1
{
    public class PresentadorLogin
    {
        private IContratoLogin vista;


        /// <summary>
        /// Constructor de la clase Presentador Login
        /// </summary>
        /// <param name="laVista">Vista que usa el Presentador</param>
        public PresentadorLogin(IContratoLogin laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método que maneja que se activa cuando el usario le da click a Iniciar Sesión
        /// 1° Valida si los campos estan correctamente llenos
        /// 2° Verfica si el Usuario existe en la base de datos 
        /// 3° Crea las credenciales
        /// </summary>
        public void ManejarEventoLogin_Click()
        {
            try
            {
                List<string> usuarioLogin = new List<string>();
                usuarioLogin.Add(vista.Usuario);
                usuarioLogin.Add(vista.Clave);

                if (string.IsNullOrEmpty(vista.Usuario))
                {
                    throw new Exception(RecursosM1.Mensaje_AlertaUsername);
                }

                if (string.IsNullOrEmpty(vista.Clave))
                {
                    throw new Exception(RecursosM1.Mensaje_AlertaClave);
                }
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad credenciales = fabricaEntidades.ObtenerUsuario();
                Comando<List<string>, Entidad> comando = FabricaComandos.CrearComandoIniciarSesion();
                credenciales = comando.Ejecutar(usuarioLogin);
                if (((Usuario)credenciales).Correo != "" && ((Usuario)credenciales).Correo != null)
                {
                    HttpContext.Current.Session[RecursosM1.Parametro_Credencial] = credenciales;
                    HttpContext.Current.Response.Redirect(RecursosM1.Ventana_Default);
                }
                else
                {
                    vista.SetMesaje(true,RecursosM1.Mensaje_ErrorLogin);
                }

            }
            catch (ExcepcionesTotem.Modulo1.IntentosFallidosException e)
            {
                vista.SetMesaje(true, e.Message);
            }
            catch (ExcepcionesTotem.Modulo1.LoginErradoException e)
            {
                vista.SetMesaje(true, e.Message);

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD e)
            {
                vista.SetMesaje(true, e.Message);
            } 
            catch (Exception e)
            {
                vista.SetMesaje(true, e.Message);
            }

        }

    }
}
