using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTotem.Modulo1;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using LogicaNegociosTotem.Modulo1;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo1
{
    /// <summary>
    /// Clase para la prueba de los metodos de la clase LogicaLogin
    /// </summary>
    [TestFixture]
    class PruebaLogicaLogin
    {
        /// <summary>
        /// Metodo para probar el login de un usuario en el sistema
        /// Se valida que el usuario de retorno contenga toda la informacion necesaria
        /// Informacion a validar : username,clave,correo,nombre,apellido,rols
        /// </summary>
        [Test]
        public void PruebaLogin()
        {
            Usuario user = new Usuario();
            user.username = RecursosPUMod1.UsuarioExitoso;
            user.clave = RecursosPUMod1.ClaveExitosa;
            DominioTotem.Usuario retornoUsuario= LogicaNegociosTotem.Modulo1.LogicaLogin.Login(user.username, user.clave);
            Assert.IsNotNull(retornoUsuario);
            Assert.AreEqual(user.username,retornoUsuario.username);
            Assert.IsNotNull(retornoUsuario.correo);
            Assert.IsNotNull(retornoUsuario.nombre);
            Assert.IsNotNull(retornoUsuario.apellido);
            Assert.IsNotNull(retornoUsuario.rol);
        }

        /// <summary>
        /// Metodo para probar la encriptacion de strings
        /// </summary>
        [Test]
        public void PruebaEncriptarConRijndael() {
            String mensajeEncriptado=LogicaLogin.EncriptarConRijndael(RecursosPUMod1.mensaje,RecursosPUMod1.Passphrase);
            Assert.AreNotEqual(mensajeEncriptado,RecursosPUMod1.mensaje);
        }

        /// <summary>
        /// Metodo para probar la desencriptacion de strings
        /// </summary>
        [Test]
        public void PruebaDesencriptarConRijndael()
        {
            string mensajeEncriptado = LogicaLogin.EncriptarConRijndael(RecursosPUMod1.mensaje, RecursosPUMod1.Passphrase);
            string mensajedesencriptado=LogicaLogin.DesencriptarConRijndael(mensajeEncriptado,RecursosPUMod1.Passphrase);
            Assert.AreEqual(mensajedesencriptado,RecursosPUMod1.mensaje);}

        /// <summary>
        /// Metodo para probar el envio del correo en el metodo EnviarEmail
        /// </summary>
        [Test]
        public void PruebaEnvioCorreo() {
            try
            {
                Usuario user = new Usuario();
                user.correo = RecursosPUMod1.CorreoExitoso;
                Assert.IsTrue(LogicaLogin.EnviarEmail(user));
            }
            catch (Exception err) {
                Assert.Fail("No se tuvo que haber disparado ninguna exception");
            }
        }
        
        /// <summary>
        ///Metodo para probar la recuperacion de clave 
        /// </summary>
        [Test]
        public void PruebaRecuperacionClave() {
            Usuario user = new Usuario();
            user.correo = RecursosPUMod1.CorreoExitoso;
            Assert.IsTrue(LogicaLogin.RecuperacionDeClave(user));
        }

        /// <summary>
        /// Metodo para probar la validacion de la respuesta secreta
        /// </summary>
        [Test]
        public void PruebaValidarRespuestaSecreta() {
            Usuario user = new Usuario();
            user.correo = LogicaLogin.EncriptarConRijndael(RecursosPUMod1.CorreoExitoso, RecursosPUMod1.Passphrase);
            user.respuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadExitosa;
            Assert.IsTrue(LogicaLogin.ValidarRespuestaSecreta(user));
            
        
        }

        /// <summary>
        /// Metodo para obtener la pregunta de seguridad
        /// </summary>
        [Test]
        public void PruebaObtenerPreguntaDeSeguridad() {
            Usuario user = new Usuario();
            user.username = RecursosPUMod1.UsuarioExitoso;
            user.correo = LogicaLogin.EncriptarConRijndael(RecursosPUMod1.CorreoExitoso, RecursosPUMod1.Passphrase);
            user.respuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadExitosa;
            DominioTotem.Usuario usuarioTmp = LogicaLogin.ObtenerPreguntaUsuario(user);
            Assert.IsNotNull(usuarioTmp);
            Assert.IsNotNull(usuarioTmp.preguntaSeguridad);
            Assert.AreNotEqual(usuarioTmp.preguntaSeguridad,String.Empty);
        }
        
        /// <summary>
        /// Metodo para probar el cambio de clave
        /// </summary>
        [Test]
        public void PruebaCambioDeClave() {
            Usuario user = new Usuario();
            user.username = RecursosPUMod1.UsuarioExitoso;
            user.clave = RecursosPUMod1.ClaveExitosa;
            user.correo = LogicaLogin.EncriptarConRijndael(RecursosPUMod1.CorreoExitoso, RecursosPUMod1.Passphrase);
            Assert.IsTrue( LogicaLogin.CambioDeClave(user));
        }

    }

        



}
