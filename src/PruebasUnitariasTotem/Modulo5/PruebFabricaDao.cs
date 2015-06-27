using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]

    class PruebFabricaDao
    {
        [Test]
        public void PruebaFabricaComando() {

            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoGenerarArchivoLatex());
            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoAgregarRequerimiento());
            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoBuscarCodigoRequerimiento());
            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimiento());
            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoEliminarRequerimiento());
            Assert.IsNotNull(Comandos.Fabrica.FabricaComandos.CrearComandoModificarRequerimiento());






        
        }        
    }
}
