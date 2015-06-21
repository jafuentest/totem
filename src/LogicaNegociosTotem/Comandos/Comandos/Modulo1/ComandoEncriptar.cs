using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando que se utilizara para encriptar un texto con Rijndael
    /// </summary>
    public class ComandoEncriptar: Comando<List<string>, string>
    {
        public override string Ejecutar(List<string> parametro)
        {
            byte[] textoEnBytes = Encoding.UTF8.GetBytes(parametro[0]);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(parametro[1], null))
            {
                byte[] bytesDeClave = password.GetBytes(
                    Convert.ToInt32(RecursosComandoModulo1.Tamano_Clave) / 8);
                using (RijndaelManaged claveSimetrica = new RijndaelManaged())
                {
                    claveSimetrica.Mode = CipherMode.CBC;
                    byte[] salt =
                        Encoding.ASCII.GetBytes(RecursosComandoModulo1.Salt_Encriptado);

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
    }
}
