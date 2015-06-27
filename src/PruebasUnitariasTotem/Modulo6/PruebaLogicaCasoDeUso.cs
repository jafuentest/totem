using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Fabrica;
using Comandos.Fabrica;
using Comandos;
using Comandos.Comandos.Modulo6;
using System.IO;
using Dominio.Entidades.Modulo5;
using Dominio;

namespace PruebasUnitariasTotem.Modulo6
{
    [TestFixture]
    class PruebaLogicaCasoDeUso
    {
        FabricaEntidades fabrica;

        [SetUp]
        public void Init()
        {

            FabricaEntidades fabrica = new FabricaEntidades();



        }





        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoConsultarRequerimientosPorCasoDeUso()
        {

            FabricaEntidades fabrica = new FabricaEntidades();

            Entidad entidadActor = fabrica.ObtenerActor();
            Entidad entidadCasoUso = fabrica.ObtenerCasoDeUso();


            CasoDeUso casoUso = entidadCasoUso as CasoDeUso;

            int idcasodeUso = 1;

            Comando<int, List<Entidad>> comandoRequerimientosPorCasoDeUso =
                        FabricaComandos.CrearComandoConsultarRequerimientosXCasoDeUso();

            List<Entidad> laLista = comandoRequerimientosPorCasoDeUso.Ejecutar(idcasodeUso);


            Assert.IsNotNull(laLista);


        }




        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoEliminarCasoDeUso()
        {

            FabricaEntidades fabrica = new FabricaEntidades();

            Entidad entidadActor = fabrica.ObtenerActor();
            Entidad entidadCasoUso = fabrica.ObtenerCasoDeUso();


            CasoDeUso casoUso = entidadCasoUso as CasoDeUso;


            Comando<int, bool> comandoEliminarCasoDeUso =
                        FabricaComandos.CrearComandoEliminarCU();

            bool laLista = comandoEliminarCasoDeUso.Ejecutar(1);


            Assert.IsTrue(laLista);


        }




        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoListarCasoDeUso()
        {

            FabricaEntidades fabrica = new FabricaEntidades();

            Entidad entidadActor = fabrica.ObtenerActor();
            Entidad entidadCasoUso = fabrica.ObtenerCasoDeUso();


            CasoDeUso casoUso = entidadCasoUso as CasoDeUso;


            Comando<string, List<Entidad>> comandoListarCasoDeUso =
                        FabricaComandos.CrearComandoListarCU();

            List<Entidad> laLista = comandoListarCasoDeUso.Ejecutar("TOT");


            Assert.IsNotNull(laLista);


        }
        /// <summary>
        /// Se deja en vacio el atributo creado para ser limpiado por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            fabrica = null;
        }

    }
}