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
        /// <summary>
        /// Objeto usuario de prueba para la realizacion de las pruebas unitarias
        /// </summary>
        private Usuario user;

        /// <summary>
        /// Inicializacion del usuario que se va a usar en las pruebas
        /// Datos requeridos para las pruebas:
        /// -username
        /// -clave
        /// y que se le calcule el hash a la clave
        /// </summary>
        [SetUp]
        public void Init()
        {
            user = new Usuario();
            user.username = "santiagop85";
            user.clave = "santi1890a";
            user.CalcularHash();
        }

        /// <summary>
        /// Metodo para validar el metodo de BDLogin: ValidarLoginBD
        /// El metodo deberia retorname el usuario completo con sus datos cargados
        /// por lo cual se usa el usuario declarado en el setup y se intenta iniciar
        /// sesion con el, al hacer el metodo el usuario no deberia ser null
        /// y su correo deberia ser el especificado
        /// Falla si el usuario es null o el correo es invalido, tambien si se lanza
        /// alguna excepcion
        /// </summary>
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

        /// <summary>
        /// Metodo para probar el metodo de BDLogin: Obtener pregunta de seguridad
        /// Se usa el objeto usuario creado en el setup y se valida que me traiga 
        /// de la base de datos la pregunta de seguridad del usuario
        /// Falla si me trae una pregunta incorrecta o lanza una excepcion
        /// </summary>
        [Test]
        public void PruebaObtenerPreguntaSeguridad()
        {
            try
            {
                DatosTotem.Modulo1.BDLogin.ObtenerPreguntaSeguridad(user);
            }
            catch (Exception)
            {
                Assert.Fail("En obtener pregunta seguridad no deberia lanzar excepcion");
            }
            Assert.AreEqual(user.preguntaSeguridad, "cual es mi carro favorito");
        }


        /// <summary>
        /// Metodo para probar el metodo de ValidarPreguntaSeguridad de BDLogin
        /// Se le agrega la respuesta a la pregunta de seguridad al usuario y se 
        /// llama al metodo, deberia retorname true, de lo contrario falla
        /// tambien falla si se lanza alguna excepcion
        /// </summary>
        [Test]
        public void PruebaValidarPreguntaSeguridad()
        {
            user.respuestaSeguridad = "chevette";
            try
            {
                Assert.True(DatosTotem.Modulo1.BDLogin.ValidarPreguntaSeguridadBD(user));
            }
            catch (Exception)
            {
                Assert.Fail("En validar respuesta seguridad no deberia lanzar excepcion");
            }
        }

    }
}
