using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Mocks;
using DominioTotem;
using ExcepcionesTotem.Modulo1;

namespace PruebasUnitariasTotem.Modulo1
{
    /// <summary>
    /// Clase para probar el codigo de la clase BDLogin
    /// </summary>
    [TestFixture]
    public class PruebaBDLogin
    {
        private Usuario user;

        [SetUp]
        public void Init()
        {
            user = new Usuario();
            user.username = "santiagop85";
            user.clave = "santi1890a";
            user.CalcularHash();
        }

        [Test]
        public void PruebaValidarLoginBDValido()
        {
            try
            {
                DatosTotem.Modulo1.BDLogin.ValidarLoginBD(user);
            }
            catch (Exception)
            {
                Assert.Fail("En login no deberia lanzar excepcion");
            }
            Assert.IsNotNull(user);
            Assert.AreEqual(user.correo, "santiagobernal93@gmail.com");

        }

        [Test]
        public void PruebaObtenerPreguntaSeguridad()
        {
            try
            {
                DatosTotem.Modulo1.BDLogin.ObtenerPreguntaSeguridad(user);
            }
            catch (Exception e)
            {
                Assert.Fail("En obtener pregunta seguridad no deberia lanzar excepcion");
            }
            Assert.AreEqual(user.preguntaSeguridad, "cual es mi carro favorito");
        }

        [Test]
        public void PruebaValidarPreguntaSeguridad()
        {
            user.respuestaSeguridad = "chevette";
            try
            {
                Assert.True(DatosTotem.Modulo1.BDLogin.ValidarPreguntaSeguridadBD(user));
            }
            catch (Exception e)
            {
                Assert.Fail("En validar respuesta seguridad no deberia lanzar excepcion");
            }
        }

    }
}
