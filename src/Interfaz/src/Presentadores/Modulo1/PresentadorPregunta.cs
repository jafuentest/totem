using System;
using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using Comandos;
using Comandos.Fabrica;
using System.Collections.Generic;

namespace Presentadores.Modulo1
{
    public class PresentadorPregunta
    {
        private IContratoPregunta vista;

        /// <summary>
        /// Constructor de PresentadorPregunta
        /// </summary>
        /// <param name="laVista">Contrato que se utiliza para tener acceso a algunos componentes
        /// de la interfaz</param>
        public PresentadorPregunta(IContratoPregunta laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Metodo que carga la pregunta del usuario
        /// </summary>
        /// <param name="request"></param>
        public void CargarPregunta(HttpRequest request)
        {
            try
            {
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad usuario = fabricaEntidades.ObtenerUsuario();
                string correo = request.QueryString[RecursosM1.Parametro_usuario];
                if (string.IsNullOrEmpty(correo))
                    throw new ErrorParametroHttpRequest(RecursosM1.Mensaje_parametroHttp);
                else
                {
                    Comando<List<string>, string> comandoDesencriptar = FabricaComandos.CrearComandoDesencriptar();
                    List<string> lista = new List<string>();
                    lista.Add(correo);
                    lista.Add(RecursosM1.Passphrase);
                    ((Usuario)usuario).Correo = comandoDesencriptar.Ejecutar(lista);
                    Comando<Entidad, Entidad> comandoPreg = FabricaComandos.CrearComandoObtenerPreguntaSeguridad();
                    usuario = comandoPreg.Ejecutar(usuario);
                    var pregunta = ((Usuario)usuario).PreguntaSeguridad;
                    if (string.IsNullOrEmpty(pregunta))
                        throw new ParametroInvalidoException(RecursosM1.Mensaje_ErrorPregunta);

                    vista.Pregunta = pregunta;
                }

            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                vista.setMensaje(true, ex.Message);
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                vista.setMensaje(true, ex.Message);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.setMensaje(true, ex.Message);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.setMensaje(true, ex.Message);
            }
            catch (Exception ex)
            {
                vista.setMensaje(true, ex.Message);
            }
        }

        /// <summary>
        /// Metodo que valida que la respuesta del usuario sea correcta
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void ManejarEventoPregunta_Click(HttpRequest request, HttpResponse response)
        {
            string respuesta = vista.Respuesta;

            if (string.IsNullOrEmpty(respuesta))
            {
                vista.setMensaje(true, RecursosM1.Mensaje_AlertaRespuesta);
            }
            else
            {
                try
                {
                    string correo = request.QueryString[RecursosM1.Parametro_usuario];
                    FabricaEntidades fabricaEntidades = new FabricaEntidades();
                    Entidad usuario = fabricaEntidades.ObtenerUsuario();
                    Comando<List<string>, string> comandoDesencriptar = FabricaComandos.CrearComandoDesencriptar();
                    List<string> lista = new List<string>();
                    lista.Add(correo);
                    lista.Add(RecursosM1.Passphrase);
                    ((Usuario)usuario).Correo = comandoDesencriptar.Ejecutar(lista);
                    ((Usuario)usuario).RespuestaSeguridad = respuesta;
                    Comando<Entidad, bool> comandoValidar = FabricaComandos.CrearComandoValidarRespuestaSecreta();
                    if (comandoValidar.Ejecutar(usuario))
                    {
                        HttpCookie aCookie = new HttpCookie(RecursosM1.Parametro_userInfo);
                        aCookie.Values[RecursosM1.Parametro_usuario] = correo;
                        aCookie.Expires = DateTime.Now.AddMinutes(15);
                        response.Cookies.Add(aCookie);
                        vista.setMensaje(false, RecursosM1.Mensaje_Correcto);
                        HttpContext.Current.Response.Redirect(RecursosM1.Ventana_RecuperacionClave);
                    }
                    else
                    {
                        vista.setMensaje(true, RecursosM1.Mensaje_ErrorRespuesta);
                       
                    }

                }
                catch (ExcepcionesTotem.Modulo1.RespuestaErradoException ex)
                {
                    vista.setMensaje(true, ex.Message);
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    vista.setMensaje(true, ex.Message);
                }
                catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
                {
                    vista.setMensaje(true, ex.Message);
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    vista.setMensaje(true, ex.Message);
                }
                catch (Exception ex)
                {
                    vista.setMensaje(true, ex.Message);
                }

            }
        }

    }
}
