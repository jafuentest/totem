using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    public class PruebaFabricaDAO
    {
        private Datos.Fabrica.FabricaDAOSqlServer fab;

        [SetUp]
        public void init() {
            this.fab = new Datos.Fabrica.FabricaDAOSqlServer();
        }

        [Test]
        public void PruebaFabrica() {
            Assert.IsNotNull(this.fab.ObtenerDAORequerimiento());
        }
    }
}
