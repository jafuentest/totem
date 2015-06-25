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
using Comandos.Comandos.Modulo7;
using Dominio;
using Dominio.Fabrica;
using Comandos.Fabrica;

namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre la Logica del Usuario
    /// </summary>
    [TestFixture]
    public class PruebaLogicaUsuario
    {
       /* //Atributos que utilizaremos
        private Entidad usuarioRegistrar;
        
        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            usuarioRegistrar = fabrica.ObtenerUsuario("prueba", "prueba", "prueba", "prueba", "prueba", "prueba", 
                "prueba", "prueba","Gerente");
        }

        /// <summary>
        /// Prueba que verifica que se pueda registar un usuario
        /// </summary>
        [Test]
        public void PruebaAgregarUsuario()
        {
            ComandoAgregarUsuario agregar = new ComandoAgregarUsuario();
            Assert.IsTrue(agregar.Ejecutar(usuarioRegistrar));
        }

        [Test]
        public void PruebaValidarCorreoUnico()
        {
            Assert.IsTrue();
        }

        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            usuarioRegistrar = null;
            agregar = null;
        }

        
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
        }*/
    }
}
