using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LogicaNegociosTotem.Modulo1
{
    /// <summary>
    /// Clase para el manejo logico del login/logout y 
    /// recuperacion de clave
    /// </summary>
    public static class LogicaLogin
    {

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
        /// <param name="usuario">Usuario con atributos username y clave para realizar el Log in
        /// <returns>Retorna el objeto usuario si se pudo validar, de lo contrario
        /// retorna null</returns>
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
            
        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le cambiara la clave</param>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario
        /// retorna False</returns>
        public static bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Metodo encargado del envio del correo que contenga el link para el cambio de la clave
        /// </summary>
        /// <param name="usuario">Usuario al cual se le enviara el EMAIL</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito,
        /// de lo contrario disparara
        /// una exception(EmailErradoException)</returns>
        public static bool EnviarEmail(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }
        
        /// <summary>
        /// Metodo encargado de validar la respuesta de seguridad utilizada por el usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le validara la respuesta</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito,
        /// de lo contrario disparara
        /// una exception (RespuestaErradoException)</returns>
        public static bool ValidarRespuestaSecreta(string respuesta)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado del cierre de sesion
        ///</summary>
        /// <returns>Retorna True si el cambio de clave fue exitoso, 
        /// de lo contrario retornara False</returns>
        public static bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        /// <summary>
        /// Metodo para encriptar con Rijndael un texto, algoritmo establecido como uno de los estandares
        /// para la criptografia moderna
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
                                    cryptoStream.Read(textoDesencriptado, 0, textoDesencriptado.Length);
                                return Encoding.UTF8.GetString(textoDesencriptado, 
                                    0, cuentaBytesDesencriptado);
                            }
                        }
                    }
                }
            }
        }

    }
}
