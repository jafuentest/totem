using DatosTotem.Modulo7;
using DominioTotem;
using ExcepcionesTotem.Modulo7;
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
    public class PruebaManejadorUsuario
    {
        private ManejadorUsuario manejador;
        [SetUp]
        public void Init()
        {
            
            manejador = new ManejadorUsuario();
        }
        /// <summary>
        /// Prueba para el metodo registrar usuario
        /// </summary>
        [Test]
        public void PruebaRegistrarUsuario()
        {
            try
            {
                manejador.RegistrarUsuario(null);
                Assert.Fail("Se produjo la excepcion de RegistroUsuarioFallidoException");
            }
            catch (RegistroUsuarioFallidoException)
            {

            }
        }
        /// <summary>
        /// Prueba para el metodo consultar datos
        /// </summary>
        [Test]
        public void PruebaConsultarDatos()
        {
            Assert.IsNotNull(manejador.consultarDatos("albertods"));
        }
        /// <summary>
        /// Prueba para el metodo modificar usuario
        /// </summary>
        [Test]
        public void PruebaModificar()
        {
            Usuario usuario = new Usuario("albertods", "5563albert", "alberto08", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");
            Assert.IsTrue(manejador.ModificarManejador(usuario));
        }
        /// <summary>
        /// Prueba para el metodo eliminar usuario
        /// </summary>
        [Test]
        public void PrebaEliminar()
        {
            Usuario usuario = new Usuario("argenis1000", "5563albert", "alberto08", "sdfgh", "Administrador", "rodarge3783@hotmail.com", "mi perro", "dexter", "Desarrollador");
            manejador.RegistrarUsuario(usuario);
            manejador.EliminarManejador(usuario.username);
            Assert.IsTrue(manejador.consultarDatos(usuario.username).nombre == "");
        }
    }
}
