using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Dominio;
using Dominio.Entidades.Modulo7;
using Datos.IntefazDAO.Modulo1;
using Datos.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    class ComandoEnviarEmail : Comando<List<String>, bool>
    {
        public override bool Ejecutar(List<String> parametro)
        {
            try
            {
                if (parametro[0] != null && parametro[0] != "")
                {

                    MailMessage mail = new MailMessage(RecursosComandoModulo1.Correo_Totem
                        , parametro[0]);
                    SmtpClient servidorSmtp = new SmtpClient(RecursosComandoModulo1.Servidor_Smtp);
                    mail.Subject = RecursosComandoModulo1.Correo_Asunto_Recuperacion_Clave;
                    mail.Body = RecursosComandoModulo1.Correo_Mensaje_Recuperacion_Clave;
                    mail.Body += parametro[2];
                    mail.Body += "\n\n\n" + RecursosComandoModulo1.Correo_Mensaje_Ignorar;

                    servidorSmtp.Port = Convert.ToInt32(RecursosComandoModulo1.Puerto_Smtp);
                    servidorSmtp.UseDefaultCredentials = false;
                    servidorSmtp.Credentials =
                        new System.Net.NetworkCredential(
                            RecursosComandoModulo1.Correo_Totem,parametro[3]);

                    servidorSmtp.EnableSsl = true;

                    servidorSmtp.Send(mail);
                    return true;
                }
                else
                {
                    ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosComandoModulo1.Codigo_Usuario_Vacio,
                        RecursosComandoModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name, excep);

                    throw excep;
                }
            }
            catch (SmtpException ex)
            {
                ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException excep = new ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException(
                    RecursosComandoModulo1.Codigo_Error_Envio_Correo,
                    RecursosComandoModulo1.Mensaje_Error_Envio_Correo,
                    ex);
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name, excep);

                throw excep;
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,excep);

                throw excep;
            }
            catch (Exception excep)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name, excep);

                throw excep;
            }
        }
    }
}
