using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo4
{
    [TestFixture]
    class PruebaComandosProyecto
    {
	   [Test]
	   public void pruebaComandoConsultarProyectosPorUsuario()
	   {
		  Comandos.Comando<String, List<Dominio.Entidad>> consultarProyectos;

		  consultarProyectos = Comandos.Fabrica.FabricaComandos.
			 CrearComandoConsultarProyectosPorUsuario();

		  consultarProyectos.Ejecutar("carlo125");
	   }
    }
}
