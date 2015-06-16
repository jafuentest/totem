using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos.Comandos.Modulo7;
using Dominio.Entidades.Modulo7;


namespace PruebasUnitariasTotem.Modulo7
{
    [TestFixture]
    public class PruebaComandoAgregarUsuario
    {
        private ComandoAgregarUsuario agregar;
        private Usuario usuarioRegistrar;

        [SetUp]
        public void Init()
        {
            agregar = new ComandoAgregarUsuario();
            usuarioRegistrar = new Usuario("prueba","prueba","prueba","prueba","prueba","prueba","prueba","prueba","Gerente");
        }

        /// <summary>
        /// Prueba que verifica que los objetos no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(usuarioRegistrar);
        }

        /// <summary>
        /// Prueba que verifica que se pueda registar un usuario
        /// </summary>
        [Test]
        public void PruebaAgregarUsuario()
        {
            Assert.IsTrue(agregar.Ejecutar(usuarioRegistrar));
            
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        public void Limpiar()
        {
            usuarioRegistrar = null;
            agregar = null;
        }
    }
}
