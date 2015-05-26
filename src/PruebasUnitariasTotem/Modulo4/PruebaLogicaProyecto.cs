using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo4;

namespace PruebasUnitariasTotem.Modulo4
{
     [TestFixture]
    class PruebaLogicaProyecto
    {

        private Proyecto elProyecto;

        [SetUp]
        public void init()
        {
            elProyecto = new Proyecto("TES", "Test", true, "Test descripcion", "mon", 1000000);
        }
        [TearDown]
        public void clean()
        {
            elProyecto = null;
        }

        [Test]
        public void PruebaCrearProyecto()
        {
            
            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto));
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }

     
    }
}
