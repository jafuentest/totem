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
using Dominio.Entidades.Modulo4;
using Dominio;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase BDMinuta
    /// </summary>
    [TestFixture]
    class PruebaComandos
    {
        FabricaComandos fabricaComandos = new FabricaComandos();
        FabricaEntidades fabricaEntidades = new FabricaEntidades();

        List<Entidad> parametroComando = new List<Entidad>();
        Proyecto proyecto;

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {

            parametroComando = new List<Entidad>();
            proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            proyecto.Codigo = "TOT";
            proyecto.Nombre = "Totem";
        }

        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoDetalleMinuta()
        {
            ComandoDetalleMinuta comandoDetalleMinuta = (ComandoDetalleMinuta)FabricaComandos.CrearComandoComandoDetalleMinuta();
            Minuta minuta = (Minuta)comandoDetalleMinuta.Ejecutar("1");
            Assert.IsNotNull(minuta);
            System.Console.Out.WriteLine("Minuta id: " + minuta.Id);
            System.Console.Out.WriteLine("Minuta fecha: " + minuta.Fecha);
            System.Console.Out.WriteLine("Minuta Motivo: " + minuta.Motivo);
            System.Console.Out.WriteLine("Minuta Observaciones: " + minuta.Observaciones);
            System.Console.Out.WriteLine("Minuta ListaUsuario: " + minuta.ListaUsuario.Count);
            System.Console.Out.WriteLine("Minuta ListaPunto: " + minuta.ListaPunto.Count);
        }

        /// <summary>
        /// Metodo que prueba el comando guardar una
        /// </summary>
        [Test]
        public void PruebaComandoGuardarMinuta()
        {
            Minuta minuta = (Minuta)fabricaEntidades.ObtenerMinuta();
            minuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta.Motivo = "Prueba";
            minuta.Observaciones = "";

            parametroComando.Add(proyecto);
            parametroComando.Add(minuta);

            ComandoGuardarMinuta comandoGuardarMinuta = (ComandoGuardarMinuta)FabricaComandos.CrearComandoGuardarMinuta();
            Assert.IsTrue(int.Parse(comandoGuardarMinuta.Ejecutar(parametroComando)) > 0);
        }
        /// <summary>
        /// Metodo que prueba el comando lista de contacto de una minuta
        /// </summary>
        [Test]
        public void PruebaComandoListaContacto()
        {
            ComandoListaContacto comandoListaContacto = (ComandoListaContacto)FabricaComandos.CrearComandoListaContacto();
            Assert.IsNotNull(comandoListaContacto.Ejecutar("TOT"));
        }
        /// <summary>
        /// Metodo que prueba el comando lista minutas de un proyecto
        /// </summary>
        [Test]
        public void PruebaComandoListaMinuta()
        {
            ComandoListaMinuta comandoListaMinuta = (ComandoListaMinuta)FabricaComandos.CrearComandoComandoListaMinuta();

            Assert.IsNotNull(comandoListaMinuta.Ejecutar("TOT"));


        }
        /// <summary>
        /// Metodo que prueba el comando lista de usuarios de una minuta
        /// </summary>
        [Test]
        public void PruebaComandoListaUsuario()
        {
            ComandoListaUsuario comandoListaUsuario = (ComandoListaUsuario)FabricaComandos.CrearComandoListaUsuario();
            Assert.IsNotNull(comandoListaUsuario.Ejecutar("TOT"));

        }
        /// <summary>
        /// Metodo que prueba el comando modificar una minuta
        /// </summary>
        [Test]
        public void PruebaComandoModificarMinuta()
        {
            Minuta minuta = (Minuta)fabricaEntidades.ObtenerMinuta();
            minuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta.Motivo = "Prueba";
            minuta.Observaciones = "";

            parametroComando.Add(proyecto);
            parametroComando.Add(minuta);

            ComandoGuardarMinuta comandoGuardarMinuta = (ComandoGuardarMinuta)FabricaComandos.CrearComandoGuardarMinuta();
            minuta.Id = int.Parse(comandoGuardarMinuta.Ejecutar(parametroComando));

            parametroComando = new List<Entidad>();


            parametroComando.Add(proyecto);
            parametroComando.Add(minuta);

            Minuta minuta2 = (Minuta)fabricaEntidades.ObtenerMinuta();
            minuta2.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            minuta2.Motivo = "Prueba Modificada";
            minuta2.Observaciones = "Modificada";
            minuta.Motivo = "Prueba Modificada";
            parametroComando.Add(minuta2);

            ComandoModificarMinuta comandoModificarMinuta = (ComandoModificarMinuta)FabricaComandos.CrearComandoModificarMinuta();
            Assert.AreEqual(comandoModificarMinuta.Ejecutar(parametroComando), "Completado");

        }
        /// <summary>
        /// Metodo que prueba el comando compilar latex
        /// </summary>
        [Test]
        public void PruebaCompilarLatex()
        {
            ComandoCompilarLatex comandoCompilarLatex = (ComandoCompilarLatex)FabricaComandos.CrearComandoCompilarLatex();
            bool auxiliar = comandoCompilarLatex.Ejecutar(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\Vista\Modulo8\docs\BaseMinuta.tex");
            Assert.IsTrue(File.Exists(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\Vista\Modulo8\docs\BaseMinuta.pdf"));
        }
        /// <summary>
        /// Metodo que prueba el comando generar minuta
        /// </summary>
        [Test]
        public void PruebaComandoGenerarMinuta()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            ComandoGenerarMinuta comandoGenerarMinuta = (ComandoGenerarMinuta)FabricaComandos.CrearComandoGenerarMinuta();
            Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
            laMinuta.Id = 1;
            laMinuta.Fecha = DateTime.Parse("2015-04-25 18:00:00.000");
            laMinuta.Motivo = "Prueba";
            laMinuta.Observaciones = "Probando Generar la Minuta";
            bool aux = comandoGenerarMinuta.Ejecutar(laMinuta);
            System.IO.StreamReader archivo = new System.IO.StreamReader(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\Vista\Modulo8\docs\Minuta.tex");
            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                Assert.IsTrue(linea != "motivo");
            }

        }

        [TearDown]
        public void close()
        {
            parametroComando = null;
        }
    }
}