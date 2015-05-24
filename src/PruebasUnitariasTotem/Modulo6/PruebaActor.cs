using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo6
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre la clase Actor
    /// </summary>
    [TestFixture]
    class PruebaActor
    {
        //Los diferentes actores sobre los que probaremos.
        private Actor actor1;
        private Actor actor2;
        private Actor actor3;

        /// <summary>
        /// Inicializa la clase que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            actor1 = new Actor();
            actor2 = new Actor("prueba", "prueba");
            actor3 = new Actor(1, "prueba", "prueba");
        }

        /// <summary>
        /// Se prueba que los diferentes actores no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(actor1);
            Assert.IsNotNull(actor2);
            Assert.IsNotNull(actor3);
        }

        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            actor1 = null;
            actor2 = null;
            actor3 = null;
        }
    }
}