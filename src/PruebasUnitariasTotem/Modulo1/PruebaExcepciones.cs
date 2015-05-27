using DatosTotem.Modulo1;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using LogicaNegociosTotem.Modulo1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitariasTotem.Modulo1
{
    [TestFixture]
    public class PruebaExcepciones
    {

        private Usuario usuario;
        [SetUp]
        public void init()
        {
            usuario = new Usuario();
        }

        [Test]

        public void PruebaLoginErradoException()
        {
            try
            {
                usuario.clave = "asdasd";
                usuario.username = "asdasd";
                LogicaLogin.Login(usuario.username, usuario.clave);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (LoginErradoException loginErradoException)
            {
                Assert.AreEqual("No se pudo iniciar sesion, datos erroneos", loginErradoException.Mensaje);
            }
            catch (IntentosFallidosException intentosErradoException)
            {
                Assert.AreEqual("Se fallo el inicio de sesion multiples veces, el usuario puede ser un bot", intentosErradoException.Mensaje);
            }
            
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        [Test]

        public void PruebaEmailErradoException()
        {
            try
            {
                
                usuario.correo = "asdasd";
                BDLogin.ObtenerPreguntaSeguridad(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (EmailErradoException emailErradoException)
            {
                Assert.AreEqual("No se pudo obtener la pregunta de seguridad, el email es invalido", emailErradoException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }


        [Test]
        public void PruebaErrorEnvioDeCorreoException()
        {
            try
            {
                usuario.correo = "asdasdasd@sasas.com";
                LogicaLogin.EnviarEmail(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (EmailErradoException emailErradoException)
            {
                Assert.AreEqual("Error en el envio del correo", emailErradoException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }


        [Test]

        public void PruebaRespuestaErradoException()
        {
            try
            {
                usuario.correo = "alberto21ds@gmail.com";
                usuario.respuestaSeguridad = "asdasd";
                BDLogin.ValidarPreguntaSeguridadBD(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (RespuestaErradoException respuestaErradoException)
            {
                Assert.AreEqual("No se pudo validar la pregunta, respuesta invalida", respuestaErradoException.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }


    }
}
