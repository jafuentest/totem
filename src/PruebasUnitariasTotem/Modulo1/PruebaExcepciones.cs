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
        private LogicaLogin logica;
        [SetUp]
        public void init()
        {
            var logica = new LogicaLogin();
            var usuario = new Usuario();
        }

        [Test]

        public void PruebaLoginErradoException()
        {
            try
            {
                usuario.clave = "";
                usuario.username = "";
                logica.Login(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (LoginErradoException loginErradoException)
            {
                Assert.AreEqual("La clave o el usuario son incorrectos", loginErradoException.Message);
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
                
                usuario.correo = "";
                BDLogin.ObtenerPreguntaSeguridad(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (EmailErradoException emailErradoException)
            {
                Assert.AreEqual("El Correo No Existe o es Incorrecto", emailErradoException.Message);
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

                usuario.respuestaSeguridad = "";
                BDLogin.ValidarPreguntaSeguridadBD(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (RespuestaErradoException respuestaErradoException)
            {
                Assert.AreEqual("La respuesta no es correcta", respuestaErradoException.Message);
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
