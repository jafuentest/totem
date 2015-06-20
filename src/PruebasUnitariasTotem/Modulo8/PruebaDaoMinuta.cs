using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo8;
using DAO.DAO.Modulo8;


namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase BDMinuta
    /// </summary>
    [TestFixture]
    class PruebaDaoMinuta
    {
        Minuta minuta;
        DaoMinuta daominuta;
        List<Minuta> listaMinuta;

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
            listaMinuta = new List<Minuta>();
            minuta = new Minuta();
            daominuta = new DaoMinuta();
        }

        /// <summary>
        /// Metodo que prueba que al consultar las minutas que tiene el proyecto con id 1
        /// dicho metodo debe devolver una lista con 3 minutas
        /// </summary>
        [Test]
        public void PruebaConsultarMinutasProyecto()
        {
            listaMinuta.Clear();
            listaMinuta = daominuta.ConsultarMinutasProyecto("TOT").Cast<Minuta>().ToList();
            Assert.AreEqual(listaMinuta.Count(), 3);
        }

        /// <summary>
        /// Metodo que prueba que al consultar una minuta, el metodo correspondiente
        /// devuelva los valores adecuados
        /// </summary>
        [Test]
        public void PruebaConsultarMinutaBD()
        {
            minuta = (Minuta)daominuta.ConsultarMinutaBD(1);
            Assert.AreEqual(minuta.Fecha, DateTime.Parse("2015-04-25 12:00:00.000"));
            Assert.AreEqual(minuta.Motivo, "Requerimientos");
            Assert.AreEqual(minuta.Observaciones, "");
        }
/*
        /// <summary>
        /// Metodo que prueba que se modifica una Minuta a la BD correctamente
        /// </summary>
        [Test]
        public void PruebaModificarMinutaBD()
        {
            minuta.Codigo = "1";
            minuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta.Motivo = "Prueba";
            minuta.Observaciones = "";
            Assert.IsTrue(daominuta.Modificar(minuta));
        }
        */
        /// <summary>
        /// Metodo que prueba que se agrega una Minuta a la BD correctamente
        /// </summary>
        [Test]
        public void PruebaAgregarMinuta()
        {
            minuta.Id = 1;
            minuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta.Motivo = "Prueba";
            minuta.Observaciones = "";
            int id=daominuta.AgregarMinuta(minuta);   
            Assert.IsTrue(id > 0);
          //  daominuta.EliminarMinuta(id);
            /*
            System.Console.Out.WriteLine("ahasdasdasdas :"+id);
            Minuta minuta2;
            minuta2 = (Minuta)daominuta.ConsultarMinutaBD(id);
            Assert.AreEqual(minuta.Fecha, minuta2.Fecha);
            Assert.AreEqual(minuta.Motivo, minuta2.Motivo);
            Assert.AreEqual(minuta.Observaciones, minuta2.Observaciones);*/
        }


        /// <summary>
        /// Metodo que prueba que se elimina una Minuta a la BD correctamente
        /// </summary>
        [Test]
        public void PruebaEliminarMinuta()
        {
           
            Assert.IsTrue(daominuta.EliminarMinuta(daominuta.BuscarUltimaMinuta()));
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