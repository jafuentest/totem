using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo8;
using Dominio.Fabrica;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo8;
using System.IO;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase BDMinuta
    /// </summary>
    [TestFixture]
    class PruebaComandos
    {
        FabricaComandos fabricaComandos=new FabricaComandos();
        FabricaEntidades fabricaEntidades=new FabricaEntidades();
/*
        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
           
        }*/

        /// <summary>
        /// Metodo que prueba agregar un punto a una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoDetalleMinuta()
        {
            ComandoDetalleMinuta comandoDetalleMinuta = (ComandoDetalleMinuta)FabricaComandos.CrearComandoComandoDetalleMinuta();
            Minuta minuta = (Minuta)comandoDetalleMinuta.Ejecutar("1");
            Assert.IsNotNull(minuta);
            System.Console.Out.WriteLine("Minuta id: " + minuta.Codigo);
            System.Console.Out.WriteLine("Minuta fecha: " + minuta.Fecha);
            System.Console.Out.WriteLine("Minuta Motivo: " + minuta.Motivo);
            System.Console.Out.WriteLine("Minuta Observaciones: " + minuta.Observaciones);
            System.Console.Out.WriteLine("Minuta ListaUsuario: " + minuta.ListaUsuario.Count);
            System.Console.Out.WriteLine("Minuta ListaPunto: " + minuta.ListaPunto.Count);


            
        }

        [Test]

        public void PruebaCompilarLatex()
        {
            ComandoCompilarLatex comandoCompilarLatex = (ComandoCompilarLatex)FabricaComandos.CrearComandoCompilarLatex();
            bool auxiliar = comandoCompilarLatex.Ejecutar(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\Vista\Modulo8\docs\BaseMinuta.tex");
            Assert.IsTrue(File.Exists(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\Vista\Modulo8\docs\BaseMinuta.pdf"));
        }
        /*
        [TearDown]
        public void close()
        {
            punto = null;
            listaPunto = null;
        }*/
    }
}