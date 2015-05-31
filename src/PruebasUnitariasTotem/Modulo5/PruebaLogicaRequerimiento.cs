using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo5;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaLogicaRequerimiento
    {
	   #region Atributos
	   private int elId;
	   private string elCodigo;
	   private List<Requerimiento> listaRequerimientos =
		  new List<Requerimiento>();
	   #endregion

	   #region SetUp & TearDown
	   [SetUp]
	   public void init()
	   {
		  elCodigo = "TOT";
		  listaRequerimientos =
			 new List<Requerimiento>();
	   }
	   [TearDown]
	   public void clean()
	   {
		  elCodigo = "";
		  listaRequerimientos = null;
	   }
	   #endregion

	   #region Pruebas unitarias
	   [Test]
	   public void PruebaRetornarIdPorCodigoProyecto()
	   {
		  int id;
		  id = LogicaNegociosTotem.Modulo5.LogicaRequerimiento.
			 RetornarIdPorCodigoProyecto(elCodigo);
		  Assert.AreEqual(1, id);
	   }
	   [Test]
	   public void PruebaConsultarRequerimientosPorProyecto()
	   {
		  listaRequerimientos =
			 LogicaNegociosTotem.Modulo5.LogicaRequerimiento.
			 ConsultarRequerimientosPorProyecto(elCodigo);
		  Assert.AreEqual(1,
			 listaRequerimientos[0].Id);
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
