using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{

    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    class PruebaComandoGenerarArchivoLatex
    {
        private List<Dominio.Entidad> listaRequerimientos;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;
        private Comandos.Comandos.Modulo5.ComandoGenerarArchivoLatex laTex;
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void init() { 
            laTex = Comandos.Fabrica.FabricaComandos.CrearComandoGenerarArchivoLatex() as Comandos.Comandos.Modulo5.ComandoGenerarArchivoLatex;
            
        }

        /// <summary>
        /// 
        /// </summary>
        [TearDown]
        public void finish() { 
        
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaGenerarDocumento() {
            
            laTex.Ejecutar("TOT");
        }


        [Test]
        public void PruebaCompilarArchivo() {
            laTex.CompilarArchivo();
        
        }


       

    }
}
