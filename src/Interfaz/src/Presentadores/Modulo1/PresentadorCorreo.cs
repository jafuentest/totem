using System;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using System.Text.RegularExpressions;
using Comandos;
using Comandos.Fabrica;
using System.Collections.Generic;
using System.Web;


namespace Presentadores.Modulo1
{
    
    public class PresentadorCorreo
    {
        private IContratoCorreo vista;

        /// <summary>
        /// Constructor de PresentadorCorreo
        /// </summary>
        /// <param name="laVista">Contrato que se utiliza para tener acceso a algunos componentes
        /// de la interfaz</param>
        public PresentadorCorreo(IContratoCorreo laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Metodo que maneja el evento manejar Correo
        /// </summary>
        public void ManejarEventoCorreo_Click()
        {
            string correo = vista.Correo;

            if (correo.Equals(""))
            {
                vista.Mensaje = RecursosM1.Mensaje_AlertaCorreo;
            }
            else
            {
                try
                {
                    FabricaEntidades fabricaEntidades = new FabricaEntidades();
                    Entidad usuario = fabricaEntidades.ObtenerUsuario();
                    ((Usuario)usuario).Correo = correo;
                    bool esCorreo = Regex.IsMatch(correo,
                        RecursosM1.Expresion_Regular_Correo,
                        RegexOptions.IgnoreCase);
                    if (esCorreo)
                    {
                        Comando<string, bool> comando = FabricaComandos.CrearComandoValidarCorreoExistente();
                        esCorreo = comando.Ejecutar(correo);
                        if (esCorreo)
                        {
                            List<string> lista = new List<string>();
                            List<string> listaDesen = new List<string>();
                            lista.Add(((Usuario)usuario).Correo);
                            lista.Add(RecursosM1.Passphrase);
                            Comando<List<string>, string> comandoEncrip = FabricaComandos.CrearComandoEncriptar();
                            string link = RecursosM1.Link_Recuperacion_Clave;
                            link = link + comandoEncrip.Ejecutar(lista);
                            Comando<List<string>, string> comandoDesen = FabricaComandos.CrearComandoDesencriptar();
                            listaDesen.Add(RecursosM1.Pswd_Correo_Totem);
                            listaDesen.Add(RecursosM1.Passphrase);
                            string network = comandoDesen.Ejecutar(listaDesen);
                            lista.Add(link);
                            lista.Add(network);
                            Comando<List<String>, bool> comandoEnviar = FabricaComandos.CrearComandoEnviarEmail();
                            comandoEnviar.Ejecutar(lista);
                            vista.Mensaje = RecursosM1.Parametro_CorreoEnviado;
                        }
                        else
                        {
                            ExcepcionesTotem.Modulo1.EmailErradoException ex = new ExcepcionesTotem.Modulo1.EmailErradoException(
                            RecursosM1.Codigo_Email_Errado,
                            RecursosM1.Mensaje_Email_errado,
                            new ExcepcionesTotem.Modulo1.EmailErradoException());
                            vista.Mensaje = ex.Message;
                        }
                    }
                    else
                    {
                        ExcepcionesTotem.Modulo1.EmailErradoException ex = new ExcepcionesTotem.Modulo1.EmailErradoException(
                            RecursosM1.Codigo_Email_Errado,
                            RecursosM1.Mensaje_Email_errado,
                            new ExcepcionesTotem.Modulo1.EmailErradoException());
                        vista.Mensaje = ex.Message;
                    }
                    
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    vista.Mensaje = ex.Message;
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    vista.Mensaje = ex.Message;
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    vista.Mensaje = ex.Message;
                }
                catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
                {
                    vista.Mensaje = ex.Message;
                }
                catch (ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException ex)
                {
                    vista.Mensaje = ex.Message;
                }
                catch (Exception ex)
                {
                    vista.Mensaje = ex.Message;
                }

            }
        }

    }
}
