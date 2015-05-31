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
	   #region Atributos
	   private Requerimiento elRequerimiento; 
	   #endregion

	   #region SetUp & TearDown
	   [SetUp]
	   public void init()
	   {
		  elRequerimiento = new Requerimiento(
			 1,
			 "TOT_RF_1",
			 "Descripcion Requerimiento Funcional 1 Totem",
			 "Funcional",
			 "Alta",
			 "Finalizado"
		  );
	   }
	   [TearDown]
	   public void clean()
	   {
		  elRequerimiento = null;
	   } 
	   #endregion

	   #region Pruebas unitarias
	   [Test]
	   public void PruebaRequerimientoNoNulo()
	   {
		  Assert.IsNotNull(elRequerimiento);
	   }
	   [Test]
	   public void PruebaRequerimientoConValores()
	   {
		  Assert.AreEqual(1, elRequerimiento.Id);
		  Assert.AreEqual("TOT_RF_1", elRequerimiento.Codigo);
		  Assert.AreEqual("Descripcion Requerimiento Funcional 1 Totem",
			 elRequerimiento.Descripcion);
		  Assert.AreEqual("Funcional", elRequerimiento.Tipo);
		  Assert.AreEqual("Alta", elRequerimiento.Prioridad);
		  Assert.AreEqual("Finalizado", elRequerimiento.Estatus);
	   } 
	   #endregion
    }
}
