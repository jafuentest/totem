using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaFrabricaRequerimiento
    {
	   private Dominio.Fabrica.FabricaEntidades fabrica; 
	   
	   [SetUp]
	   public void init()
	   {
           this.fabrica = new Dominio.Fabrica.FabricaEntidades();
       }
	   
        [Test]
	   public void PruebaRequerimientoNoNulo()
	   {
		  Assert.IsNotNull(fabrica.ObtenerRequerimiento());
	   }
    }
}
