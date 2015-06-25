using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    ///  Comando que se utilizara para desencriptar un texto con Rijndael
    /// </summary>
    public class ComandoDesencriptar: Comando<List<string>, string>
    {
        public override string Ejecutar(List<string> parametro)
        {
            try
            {
                byte[] bytesDeTextoCifrado = Convert.FromBase64String(parametro[0]);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(parametro[1], null))
                {
                    byte[] bytesDeClave = password.GetBytes(
                    Convert.ToInt32(RecursosComandoModulo1.Tamano_Clave) / 8);
                    using (RijndaelManaged claveSimetrica = new RijndaelManaged())
                    {
                        claveSimetrica.Mode = CipherMode.CBC;

                        byte[] salt =
                            Encoding.ASCII.GetBytes(RecursosComandoModulo1.Salt_Encriptado);

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
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
        }
    }
}
