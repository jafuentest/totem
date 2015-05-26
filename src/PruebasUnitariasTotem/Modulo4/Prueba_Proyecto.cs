using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitarias
{

    [TestFixture]
    class Prueba_Proyecto
    {
        private Proyecto elProyecto;

        [SetUp]
        public void init()
        {
            elProyecto = new Proyecto("TOT","Totem",true,"Sistema de gestion de proyectos","BsF",1000000);
        }
        [TearDown]
        public void clean()
        {
            elProyecto = null;
        }

        
        [Test]
        public void pruebaCtor()
        {
            Assert.IsNotNull(elProyecto);
        }
        [Test]
        public void pruebaCtorConProyecto()
        {   
            Assert.AreEqual("TOT", elProyecto.Codigo);
            Assert.AreEqual("Totem", elProyecto.Nombre);
            Assert.IsTrue(elProyecto.Estado);
            Assert.AreEqual("Sistema de gestion de proyectos", elProyecto.Descripcion);
            Assert.AreEqual("BsF", elProyecto.Moneda);
            Assert.AreEqual(1000000, elProyecto.Costo);
        }
       
    }
}
