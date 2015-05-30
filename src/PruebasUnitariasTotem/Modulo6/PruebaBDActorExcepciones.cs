using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DatosTotem.Modulo6;

namespace PruebasUnitariasTotem.Modulo6
{
    [TestFixture]
    class PruebaBDActorExcepciones
    {
        private BDActor bdActor;

        [SetUp]
        public void Init()
        {
            bdActor = new BDActor();

        }

        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void PruebaFallaAgregarActor()
        {
            bdActor.AgregarActor(null, 0);
        }

        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void PruebaFallaModificarActor()
        {
            bdActor.ModificarActor(null, 0);
        }

        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void PruebaFallaEliminarActor()
        {
            bdActor.EliminarActor(null, 0);
        }
    }
}
