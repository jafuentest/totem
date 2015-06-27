using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    /// <summary>
    /// Prueba de la fabrica de comandos
    /// </summary>
    [TestFixture]
    class PruebFabricaComando
    {   [Test]
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
