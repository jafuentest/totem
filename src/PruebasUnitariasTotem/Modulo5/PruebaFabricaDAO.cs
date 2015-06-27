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
        private DAO.Fabrica.FabricaDAOSqlServer fab;

        [SetUp]
        public void init() {
            this.fab = new DAO.Fabrica.FabricaDAOSqlServer();
        }

        [Test]
        public void PruebaFabrica() {
            Assert.IsNotNull(this.fab.ObtenerDAORequerimiento());
        }
    }
}
