using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{


    /// <summary>
    /// Clase encargada de probar el comando Generar Archivo Latex
    /// </summary>
    [TestFixture]
    class PruebaComandoGenerarArchivoLatex
    {
        /// <summary>
        /// Atributos usados en la prueba unitaria
        /// </summary>
        private List<Dominio.Entidad> listaRequerimientos;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;
        private Comandos.Comandos.Modulo5.ComandoGenerarArchivoLatex laTex;
        
        /// <summary>
        /// Inicializacion de atributos
        /// </summary>
        [SetUp]
        public void init() { 
            laTex = Comandos.Fabrica.FabricaComandos.CrearComandoGenerarArchivoLatex() as Comandos.Comandos.Modulo5.ComandoGenerarArchivoLatex;
            Dominio.Fabrica.FabricaEntidades fabrica = new Dominio.Fabrica.FabricaEntidades();
            this.listaRequerimientos= new List<Dominio.Entidad>();
            this.requerimiento = fabrica.ObtenerRequerimiento() as Dominio.Entidades.Modulo5.Requerimiento;
            this.requerimiento.Codigo = "Prueba";
            this.requerimiento.Descripcion = "Prueba";
            this.requerimiento.Tipo = "Funcional";
            this.requerimiento.Prioridad = "Alta";
            this.listaRequerimientos.Add(this.requerimiento);
        }

        
        /// <summary>
        /// Metodo encargado de probar El metodo generar documento
        /// </summary>
        [Test]
        public void PruebaGenerarDocumento() {
            try
            {
                laTex.Ejecutar("TOT");
            }
            catch (ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException err)
            {

            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException err)
            {

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD err)
            {

            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException err)
            {

            }
            catch (ExcepcionesTotem.Modulo5.ArchivoInexistenteException err) {
            
            
            }

            }

        /// <summary>
        /// Metodo encargado de probar el metodo compilar achivo
        /// </summary>
        [Test]
        public void PruebaCompilarArchivo() {
            try
            {
                laTex.CompilarArchivo();
            }
            catch (ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException err) { 
            
            }
        }
    
        /// <summary>
        /// metodo encargado de probar la generacion del documento final
        /// </summary>
        [Test]
        public void PruebaGenerarDocumentoFinal() {
            try
            {
                laTex.GenerarDocumentoFuncional(this.listaRequerimientos);
            }
            catch (ExcepcionesTotem.Modulo5.ArchivoInexistenteException err) { 
            
            }
            
          }


       

    }
}
