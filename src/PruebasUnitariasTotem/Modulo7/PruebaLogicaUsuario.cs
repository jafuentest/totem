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
    public class PruebaLogicaUsuario
    {
        /// <summary>
        /// Prueba para el metodo de listar cargos
        /// </summary>

        [Test]
        public void PruebaListaCargos() {

            Assert.IsTrue(LogicaUsuario.listarCargos().Count > 0);
            
        }
        /// <summary>
        /// Prueba para el metodo de obterner datos
        /// </summary>
        [Test]
        public void PruebaObtenerdatos()
        {

            Assert.IsNotNull(LogicaUsuario.ObtenerDatos("albertods"));
        }
        /// <summary>
        /// Prueba para el metodo modificicar logica
        /// </summary>
        [Test]
        public void PruebaModificarLogica()
        {
            Usuario usuario = new Usuario("albertods", "5563albert", "alberto08", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");
            Assert.IsTrue(LogicaUsuario.ModificarUsuario(usuario,"rodarge33@gmail.com"));
        }
        /// <summary>
        /// Prueba para el metodo eliminar usuario
        /// </summary>
        [Test]
        public void PruebaEliminarUsuario()
        {
            ManejadorUsuario manejador = new ManejadorUsuario();
            Usuario usuario = new Usuario("BaronRojo", "5563albert", "alberto08", "sdfgh", "Administrador", "rodarge100@hotmail.com", "mi perro", "dexter", "Desarrollador");
            LogicaUsuario.agregarUsuario(usuario);
            LogicaUsuario.eliminarUsuario(usuario.username);
            Assert.IsTrue((LogicaUsuario.ObtenerDatos(usuario.username)).nombre == "");
        }
    }
}
