using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTotem;
using DatosTotem.Modulo8;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase BDMinuta
    /// </summary>
    [TestFixture]
    class PruebaBDMinuta
    {
        Minuta minuta;
        BDMinuta bdMinuta;
        List<Minuta> listaMinuta;

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
            listaMinuta = new List<Minuta>();
            minuta = new Minuta();
            bdMinuta = new BDMinuta();
        }

        /// <summary>
        /// Metodo que prueba que al consultar las minutas que tiene el proyecto con id 1
        /// dicho metodo debe devolver una lista con 3 minutas
        /// </summary>
        [Test]
        public void PruebaConsultarMinutasProyecto()
        {
            listaMinuta.Clear();
            listaMinuta =bdMinuta.ConsultarMinutasProyecto(1);
            Assert.AreEqual(listaMinuta.Count(),3);
        }

        /// <summary>
        /// Metodo que prueba que al consultar una minuta, el metodo correspondiente
        /// devuelva los valores adecuados
        /// </summary>
        [Test]
        public void PruebaConsultarMinutaBD()
        {
            minuta = bdMinuta.ConsultarMinutaBD(1);
            Assert.AreEqual(minuta.Fecha, DateTime.Parse("2015-04-25 18:00:00.000"));
            Assert.AreEqual(minuta.Motivo, "Requerimientos");
            Assert.AreEqual(minuta.Observaciones,"");
        }

        /// <summary>
        /// Metodo que prueba que se modifica una Minuta a la BD correctamente
        /// </summary>
        [Test]
        public void PruebaModificarMinutaBD()
        {
            minuta.Codigo = "1";
            minuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta.Motivo = "Requerimientos";
            minuta.Observaciones = "";
            Assert.IsTrue(bdMinuta.ModificarMinutaBD(minuta));
        }

        /// <summary>
        /// Metodo que prueba que se agrega una Minuta a la BD correctamente
        /// </summary>
        [Test]
        public void PruebaAgregarMinuta()
        {
            minuta = new Minuta(DateTime.Parse("2015-04-25 18:00:00.000"), "Requerimientos", "");
            Assert.IsTrue(bdMinuta.AgregarMinuta(minuta));
        }

        /// <summary>
        /// Metodo donde se resetean todas las variables
        /// </summary>
        [TearDown]
        public void close()
        {
            minuta = null;
            listaMinuta = null;
        }

    }
}
