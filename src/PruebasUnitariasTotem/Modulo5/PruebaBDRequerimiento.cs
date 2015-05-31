using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaBDRequerimiento
    {
	   #region Atributos
	   private int elCodigo;
	   private List<Requerimiento> listaRequerimientos =
		  new List<Requerimiento>();
	   #endregion

	   #region SetUp & TearDown
	   [SetUp]
	   public void init()
	   {
		  elCodigo = 1;
		  listaRequerimientos =
			 new List<Requerimiento>();
	   }
	   [TearDown]
	   public void clean()
	   {
		  elCodigo = 0;
		  listaRequerimientos = null;
	   } 
	   #endregion

	   #region Pruebas unitarias
	   [Test]
	   public void PruebaConsultarRequerimientosPorProyecto()
	   {
		  listaRequerimientos =
			 DatosTotem.Modulo5.BDRequerimiento.
			 ConsultarRequerimientosPorProyecto(elCodigo);
		  Assert.AreEqual("TOT_RF_1",
			 listaRequerimientos[0].Codigo.ToString());
		  Assert.AreEqual("Funcional",
			 listaRequerimientos[0].Tipo.ToString());
		  Assert.AreEqual("Alta",
			 listaRequerimientos[0].Prioridad.ToString());
		  Assert.AreEqual("Finalizado",
			 listaRequerimientos[0].Estatus.ToString());
	   } 
	   #endregion
    }
}
