using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaRequerimiento
    {
        private Requerimiento elRequerimiento;

        [SetUp]
        public void init()
        {
            elRequerimiento = new Requerimiento("TOT_RF_1", "Descripcion Requerimiento Funcional 1 Totem", "Funcional", "Alta", "Finalizado");
        }
        [TearDown]
        public void clean()
        {
            elRequerimiento = null;
        }

        [Test]
        public void pruebaReqNull()
        {
            Assert.IsNotNull(elRequerimiento);
        }


    }
}
