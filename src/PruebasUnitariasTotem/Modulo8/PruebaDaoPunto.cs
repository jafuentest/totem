using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo8;
using DAO.DAO.Modulo8;
using DAO.Fabrica;
using Dominio.Fabrica;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase BDMinuta
    /// </summary>
    [TestFixture]
    class PruebaDaoPunto
    {
        Punto punto;
        DAO.IntefazDAO.Modulo8.IDaoPunto daopunto;
        List<Punto> listaPunto;
        FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
        FabricaEntidades fabricaEntidades = new FabricaEntidades();

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
            listaPunto = new List<Punto>();
            punto = (Punto)fabricaEntidades.ObtenerPunto();
            daopunto = fabricaDAO.ObtenerDAOPunto();
        }

        /// <summary>
        /// Metodo que prueba agregar un punto a una minuta 
        /// </summary>
        [Test]
        public void PruebaAgregarPuntoBD()
        {
            punto.Titulo="Titulo Prueba";
            punto.Desarrollo = "Desarrollo Prueba";
            punto.Id = daopunto.AgregarPunto(punto, 1);
            Assert.IsTrue(punto.Id > 0);

            daopunto.EliminarPuntoBD(punto, 1);
        }

        /// <summary>
        /// Metodo que prueba eliminar un punto a una minuta 
        /// </summary>
        [Test]
        public void PruebaEliminarPuntoBD()
        {
            punto.Titulo = "Titulo Prueba";
            punto.Desarrollo = "Desarrollo Prueba";
            punto.Id = daopunto.AgregarPunto(punto, 1);

            Assert.IsTrue(daopunto.EliminarPuntoBD(punto,1));
            daopunto.EliminarPuntoBD(punto, 1);
        }

        /// <summary>
        /// Metodo que prueba que se modifica un punto de una minuta  correctamente
        /// </summary>
        [Test]
        public void PruebaModificarPuntoBD()
        {
            punto.Titulo = "Titulo Prueba";
            punto.Desarrollo = "Desarrollo Prueba";
            punto.Id = daopunto.AgregarPunto(punto, 1);
            punto.Titulo = "Titu Modificado";
            punto.Desarrollo = "Des Mod";
            Assert.IsTrue(daopunto.ModificarPuntoBD(punto,1));
            daopunto.EliminarPuntoBD(punto, 1);
        }
        
        /// <summary>
        /// Metodo que prueba la consulta de un punto de una minuta en BD correctamente
        /// </summary>
        [Test]
        public void PruebaConsultarPuntoBD()
        {
            
            Assert.IsTrue(daopunto.ConsultarPuntoBD(1).Count >1);
            
        }
        
        /// <summary>
        /// Metodo donde se resetean todas las variables
        /// </summary>
        [TearDown]
        public void close()
        {
            punto = null;
            listaPunto = null;
        }
    }
}