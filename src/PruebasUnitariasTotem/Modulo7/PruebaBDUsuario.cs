using DatosTotem.Modulo7;
using DominioTotem;
using LogicaNegociosTotem.Modulo7;
using NUnit.Framework;
using NUnit.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitariasTotem.Modulo7
{
    [TestFixture]
    class PruebaBDUsuario
    {
        private BDUsuario baseDeDatosUsuario;
        [SetUp]
        public void Init()
        {
            baseDeDatosUsuario = new BDUsuario();
        }
        /// <summary>
        /// Prueba para el metodo registrar usuario
        /// </summary>
        [Test]
        public void PruebaRegistrarUsuario()
        {
            Usuario usuario = new Usuario("Argenis03", "dfsfdf3232343", "Argenis", "Rodriguez", "Administrador", "rodarge32@gmail.com", "Como se llama mi perro", "slipy", "Desarrollador");
            Assert.IsTrue(baseDeDatosUsuario.RegitrarUsuario(usuario));
        }
        /// <summary>
        /// Prueba para el metodo de username unico
        /// </summary>
        [Test]
        public void PruebaUsernameUnico()
        {
            Assert.IsTrue(baseDeDatosUsuario.usernameUnico("albertodfds"));

        }
        /// <summary>
        /// Prueba para el metodo de correo unico
        /// </summary>
        [Test]
        public void PruebaCorreoUnico()
        {
            Assert.IsTrue(baseDeDatosUsuario.correoUnico("rodarge34@gmail.com"));

        }
        /// <summary>
        /// Prueba para el metodo datos de usurios
        /// </summary>
        [Test]
        public void PruebaDatosUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.username = "albertods";
            Assert.IsNotNull(baseDeDatosUsuario.DatosUsuario(usuario));
        }
        /// <summary>
        /// Prueba para el metodo de modificar usuario
        /// </summary>
        [Test]
        public void PruebaModificarUsuario()
        {
            Usuario usuario = new Usuario("albertods", "5563albert", "alberto07", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");

            Assert.IsTrue(baseDeDatosUsuario.ModificarUsuario(usuario));
        }
        /// <summary>
        /// Prueba para el metodo eliminar usuario
        /// </summary>
        [Test]
        public void PruebaEliminarUsuario()
        {
            Usuario usuario = new Usuario("AlfaPrueba", "5563albert", "alberto07", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");
            Boolean seRealizo = baseDeDatosUsuario.RegitrarUsuario(usuario);
            baseDeDatosUsuario.EliminarUsuario(usuario.username);
            Assert.IsTrue(baseDeDatosUsuario.usernameUnico(usuario.username));
        }
        /// <summary>
        /// Prueba para el metodo listar los usuarios
        /// </summary>
        [Test]
        public void PruebaListaUsuario()
        {
            Assert.IsTrue(baseDeDatosUsuario.ObtenerListaUsuario().Count > 0);
        }

        /// <summary>
        /// Prueba para el metodo consultar la clave
        /// </summary>
        [Test]
        public void PruebaConsultarClave()
        {
            Assert.AreEqual("5563albert",baseDeDatosUsuario.ConsultarClaveUsuario("albertods"));
        }
    }
}
