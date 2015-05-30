using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaNegociosTotem.Modulo1
{
    /// <summary>
    /// Clase para el manejo logico del login/logout y 
    /// recuperacion de clave
    /// </summary>
    public static class LogicaLogin
    {
        #region Inicio de Sesion
        /// <summary>
        /// Atributo para el control de los intentos que tendra el usuario para hacer login
        /// </summary>
        private static int intentos=0;
        public static bool captchaActivo = false;

        /// <summary>
        /// Constructor de la clase BDLogin
        /// </summary>
        /// <returns>Retorna el objeto con el numero de intentos inicializado en 0 </returns>
      

        /// <summary>
        /// Metodo para validar el inicio de sesion
        /// </summary>
        /// <param name="usuario">Usuario con atributos username y clave para realizar el 
        /// Log in
        /// <returns>Retorna el objeto usuario si se pudo validar, de lo contrario
        /// retorna null</returns>
        /// <exception cref="ExcepcionesTotem.Modulo1.UsuarioVacioException">
        /// Excepcion que se lanza si se pasa como parametro un usuario
        /// incompleto</exception>
        /// <exception cref="ExcepcionesTotem.Modulo1.IntentosFallidosException">
        /// Excepcion que se lanza si el usuario intenta hacer login
        /// una cantidad determinada de veces y falla</exception>
        /// <exception cref="ExcepcionesTotem.Modulo1.LoginErradoException">
        /// Excepcion que se lanza si se no se pudo comprobar el 
        /// inicio de sesion del usuario</exception>
        /// <exception cref="ExcepcionesTotem.ExceptionTotemConexionBD">
        /// Excepcion que se lanza si hubo algun problema con la base de 
        /// datos</exception>
        public static DominioTotem.Usuario Login(string Username, string Clave)
        {
                try
                {
                    if (!captchaActivo)
                    {
                        intentos++;
                    }
                    DominioTotem.Usuario loginUser = new DominioTotem.Usuario();
                    loginUser.username = Username;
                    loginUser.clave = Clave;
                    loginUser.CalcularHash();
                    DominioTotem.Usuario retornoUser= 
                        DatosTotem.Modulo1.BDLogin.ValidarLoginBD(loginUser);
                    intentos = 0;
                    captchaActivo = false;
                    return retornoUser;
                }
                catch (ExcepcionesTotem.Modulo1.LoginErradoException)
                {
                    if (intentos >= 
                        Convert.ToInt32(RecursosLogicaModulo1.Cantidad_Intentos_Permitidos))
                    {
                        throw new ExcepcionesTotem.Modulo1.IntentosFallidosException(
                            RecursosLogicaModulo1.Codigo_Intentos_Fallidos,
                            RecursosLogicaModulo1.Mensaje_Intentos_Fallidos,
                            new ExcepcionesTotem.Modulo1.IntentosFallidosException());
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.LoginErradoException(
                            RecursosLogicaModulo1.Codigo_Login_Errado,
                            RecursosLogicaModulo1.Mensaje_Login_Errado,
                            new ExcepcionesTotem.Modulo1.LoginErradoException());
                    }
                }
                catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
                {
                    if (intentos >= 
                        Convert.ToInt32(RecursosLogicaModulo1.Cantidad_Intentos_Permitidos))
                    {
                        throw new ExcepcionesTotem.Modulo1.IntentosFallidosException(
                            RecursosLogicaModulo1.Codigo_Intentos_Fallidos,
                            RecursosLogicaModulo1.Mensaje_Login_Errado, ex);
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                            ex.Codigo, ex.Mensaje, ex);
                    }
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    if (intentos >= 
                        Convert.ToInt32(RecursosLogicaModulo1.Cantidad_Intentos_Permitidos))
                    {
                        throw new ExcepcionesTotem.Modulo1.IntentosFallidosException(
                            RecursosLogicaModulo1.Codigo_Intentos_Fallidos,
                            RecursosLogicaModulo1.Mensaje_Login_Errado, ex);
                    }
                    else
                    {
                        throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                            RecursosLogicaModulo1.Codigo_Error_Conexion_BD, 
                            RecursosLogicaModulo1.Mensaje_Error_Conexion_BD,
                            ex);
                    }
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                        ex.Codigo, ex.Mensaje, ex);
                }
            
        }
        #endregion

        #region Recuperacion de Clave
        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le cambiara la clave</param>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario
        /// retorna False</returns>
        public static bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            if (usuario != null && usuario.correo != null
                && usuario.correo != "")
            {
                try
                {
                    bool esCorreo = Regex.IsMatch(usuario.correo,
                        RecursosLogicaModulo1.Expresion_Regular_Correo,
                        RegexOptions.IgnoreCase);

                    if (esCorreo && 
                        DatosTotem.Modulo1.BDLogin.ValidarCorreoBD(usuario.correo))
                    {
                        EnviarEmail(usuario);
                        return true;
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                            RecursosLogicaModulo1.Codigo_Email_Errado,
                            RecursosLogicaModulo1.Mensaje_Email_errado,
                            new ExcepcionesTotem.Modulo1.EmailErradoException());
                    }
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                        ex.Codigo, ex.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                        ex.Codigo, ex.Mensaje, ex);
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                        ex.Codigo, ex.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        ex.Codigo, ex.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException(
                        ex.Codigo, ex.Mensaje, ex);
                }
            }
            else
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                    RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                    new ExcepcionesTotem.Modulo1.UsuarioVacioException());
            }
        }

        /// <summary>
        /// Metodo encargado de la generacion del link que debe seguir el usuario para
        /// el cambio de su clave
        /// </summary>
        /// <returns>Retorna el URL que debe seguir el usuario para cambiar su clave,
        /// de lo contrario
        /// disparara una exception</returns>
        public static string GenerarLink(DominioTotem.Usuario usuario)
        {
            if (usuario != null && usuario.correo != null
                && usuario.correo != "")
            {
                string link = RecursosLogicaModulo1.Link_Recuperacion_Clave;
                    link += EncriptarConRijndael(usuario.correo,
                    RecursosLogicaModulo1.Passphrase);
                return link;
            }
            else
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                    RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                    new ExcepcionesTotem.Modulo1.UsuarioVacioException());
            }

        }

        /// <summary>
        /// Metodo encargado del envio del correo que contenga el link para el cambio 
        /// de la clave
        /// </summary>
        /// <param name="usuario">Usuario al cual se le enviara el EMAIL</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito,
        /// de lo contrario disparara
        /// una exception(EmailErradoException)</returns>
        /// <exception cref="ExcepcionesTotem.Modulo1.UsuarioVacioException">
        /// Excepcion que se lanza si se pasa como parametro un usuario
        /// incompleto</exception>
        /// <exception cref="ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException">
        /// Excepcion que se lanza si el correo no se pudo enviar</exception>
        public static bool EnviarEmail(DominioTotem.Usuario usuario)
        {
            try
            {
                //validar expresiones regulares de correo
                if (usuario != null && usuario.correo != null &&
                    usuario.correo != "")
                {

                    MailMessage mail = new MailMessage(RecursosLogicaModulo1.Correo_Totem
                        , usuario.correo);
                    SmtpClient servidorSmtp = new SmtpClient(RecursosLogicaModulo1.Servidor_Smtp);
                    mail.Subject = RecursosLogicaModulo1.Correo_Asunto_Recuperacion_Clave;
                    mail.Body = RecursosLogicaModulo1.Correo_Mensaje_Recuperacion_Clave;
                    mail.Body += GenerarLink(usuario);
                    mail.Body += "\n\n\n" + RecursosLogicaModulo1.Correo_Mensaje_Ignorar;

                    servidorSmtp.Port = Convert.ToInt32(RecursosLogicaModulo1.Puerto_Smtp);
                    servidorSmtp.UseDefaultCredentials = false;
                    servidorSmtp.Credentials =
                        new System.Net.NetworkCredential(
                            RecursosLogicaModulo1.Correo_Totem,
                            DesencriptarConRijndael(RecursosLogicaModulo1.Pswd_Correo_Totem,
                            RecursosLogicaModulo1.Passphrase));

                    servidorSmtp.EnableSsl = true;

                    servidorSmtp.Send(mail);
                    return true;
                }
                else
                {
                    throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                        RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());
                }
            }
            catch (SmtpException ex)
            {
                throw new ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException(
                    RecursosLogicaModulo1.Codigo_Error_Envio_Correo,
                    RecursosLogicaModulo1.Mensaje_Error_Envio_Correo,
                    ex);
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    ex.Codigo, ex.Mensaje, ex);
            }

        }
        #endregion

        #region Cambio de Clave
        /// <summary>
        /// Metodo encargado de validar la respuesta de seguridad utilizada por el usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le validara la respuesta</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito,
        /// de lo contrario disparara
        /// una exception (RespuestaErradoException)</returns>
        public static bool ValidarRespuestaSecreta(DominioTotem.Usuario usuario)
        {
            try
            {
                usuario.correo = DesencriptarConRijndael(usuario.correo,
                    RecursosLogicaModulo1.Passphrase);
                if (DatosTotem.Modulo1.BDLogin.ValidarPreguntaSeguridadBD(
                    usuario))
                {
                    return true;
                }
                else
                {
                    throw new ExcepcionesTotem.Modulo1.RespuestaErradoException(
                        RecursosLogicaModulo1.Codigo_Respuesta_Errada,
                        RecursosLogicaModulo1.Mensaje_Respuesta_Errada,
                        new ExcepcionesTotem.Modulo1.RespuestaErradoException());
                }
            }
            catch (ExcepcionesTotem.Modulo1.RespuestaErradoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.RespuestaErradoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        ///</summary>
        /// <param name="usuario">Usuario al cual se cambiara la clave
        /// de acceso al sistema</param>      
        /// <returns>Retorna True si el cambio de clave fue exitoso,
        /// de lo contrario retorna False</returns>
        public static bool CambioDeClave(DominioTotem.Usuario usuario)
        {
            try
            {
                if (usuario != null && usuario.clave != null &&
                    usuario.clave != "" && usuario.correo != null
                    && usuario.correo != "")
                {
                    usuario.correo =
                        DesencriptarConRijndael(usuario.correo,
                        RecursosLogicaModulo1.Passphrase);
                    usuario.CalcularHash();
                    DatosTotem.Modulo1.BDLogin.CambiarClave(usuario);
                    return true;
                }
                else
                {
                    throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                        RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());
                }
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
            }
        }

        /// <summary>
        /// Metodo que extrae la pregunta de seguridad de un usuario dado su correo
        /// </summary>
        /// <param name="usuario">Usuario al que se le quiere obtener la pregunta de 
        /// seguridad dado su correo</param>
        /// <returns>Retorna a el usuario con su pregunta de seguridad cargada</returns>
        public static DominioTotem.Usuario ObtenerPreguntaUsuario(DominioTotem.Usuario usuario)
        {
            try
            {
                if (usuario.correo != null && usuario.correo != "")
                {
                    usuario.correo = DesencriptarConRijndael(usuario.correo,
                        RecursosLogicaModulo1.Passphrase);
                    usuario = DatosTotem.Modulo1.BDLogin.ObtenerPreguntaSeguridad(usuario);
                    if (usuario.preguntaSeguridad != null &&
                        usuario.preguntaSeguridad != "")
                    {
                        return usuario;
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                        RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());
                    }
                }
                else
                {
                    throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosLogicaModulo1.Codigo_Usuario_Vacio,
                        RecursosLogicaModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());
                }
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                throw new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                    ex.Codigo, ex.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
            }
        }

        #endregion

        #region Cerrar Sesion
        /// <summary>
        /// Metodo encargado del cierre de sesion
        ///</summary>
        /// <returns>Retorna True si el cambio de clave fue exitoso, 
        /// de lo contrario retornara False</returns>
        public static bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

        #endregion

        #region Encriptado/Desencriptado con Rijndael
        /// <summary>
        /// Metodo para encriptar con Rijndael un texto, algoritmo establecido como uno de los 
        /// estandares para la criptografia moderna
        /// </summary>
        /// <param name="textoAEncriptar">Texto que se quiere encriptar</param>
        /// <param name="passPhrase">Una clave que luego se podra usar para desencriptar</param>
        /// <returns>String con el texto encriptado</returns>
        public static string EncriptarConRijndael(string textoAEncriptar, string passPhrase)
        {
            byte[] textoEnBytes = Encoding.UTF8.GetBytes(textoAEncriptar);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] bytesDeClave = password.GetBytes(
                    Convert.ToInt32(RecursosLogicaModulo1.Tamano_Clave) / 8);
                using (RijndaelManaged claveSimetrica = new RijndaelManaged())
                {
                    claveSimetrica.Mode = CipherMode.CBC;
                    byte[] salt = 
                        Encoding.ASCII.GetBytes(RecursosLogicaModulo1.Salt_Encriptado);

                    using (ICryptoTransform encriptor = 
                        claveSimetrica.CreateEncryptor(bytesDeClave, salt))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = 
                                new CryptoStream(memoryStream, encriptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(textoEnBytes, 0, textoEnBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] textoCifradoEnBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(textoCifradoEnBytes);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que sirve para desencriptar un texto que fue encriptado con el algoritmo
        /// de Rijndael, se tiene que colocar la misma passphrase que se puso para encriptar
        /// </summary>
        /// <param name="textoCifrado">El texto que fue cifrado anteriormente</param>
        /// <param name="passPhrase">La clave para desenciptar, debe ser la misma
        /// usada para encriptar</param>
        /// <returns>El texto desencriptado</returns>
        public static string DesencriptarConRijndael(string textoCifrado, string passPhrase)
        {
            try
            {
                byte[] bytesDeTextoCifrado = Convert.FromBase64String(textoCifrado);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] bytesDeClave = password.GetBytes(
                    Convert.ToInt32(RecursosLogicaModulo1.Tamano_Clave) / 8);
                    using (RijndaelManaged claveSimetrica = new RijndaelManaged())
                    {
                        claveSimetrica.Mode = CipherMode.CBC;

                        byte[] salt =
                            Encoding.ASCII.GetBytes(RecursosLogicaModulo1.Salt_Encriptado);

                        using (ICryptoTransform desencriptor =
                            claveSimetrica.CreateDecryptor(bytesDeClave, salt))
                        {
                            using (MemoryStream memoryStream =
                                new MemoryStream(bytesDeTextoCifrado))
                            {
                                using (CryptoStream cryptoStream =
                                    new CryptoStream(memoryStream, desencriptor,
                                        CryptoStreamMode.Read))
                                {
                                    byte[] textoDesencriptado = new byte[bytesDeTextoCifrado.Length];
                                    int cuentaBytesDesencriptado =
                                        cryptoStream.Read(textoDesencriptado, 0,
                                        textoDesencriptado.Length);
                                    return Encoding.UTF8.GetString(textoDesencriptado,
                                        0, cuentaBytesDesencriptado);
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesTotem.Modulo1.EmailErradoException(
                    RecursosLogicaModulo1.Codigo_Email_Errado,
                    RecursosLogicaModulo1.Mensaje_Email_errado,
                    ex);
            }
        }
        #endregion
    }
}
