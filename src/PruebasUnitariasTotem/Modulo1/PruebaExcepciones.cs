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
        [SetUp]
        public void init()
        {

        }

        [Test]

        public void PruebaLoginErradoException()
        {
            try
            {
                var logica = new LogicaLogin();
                var usuario = new Usuario();
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
    }
}
