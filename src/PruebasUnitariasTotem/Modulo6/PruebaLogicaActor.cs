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
    /// <summary>
    /// Prueba unitaria que trabaja sobre la clase PruebaLogicaActor
    /// </summary>
    [TestFixture]
    public class PruebaLogicaActor
    {
        List<Entidad> _prueba;

        /// <summary>
        /// Inicializa la clase que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {


            List<Entidad> _prueba = new List<Entidad>();



        }


        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoDetalleActoresCombo()
        {

            Actor actor1 = new Actor();


            actor1.NombreActor = "Administrador";
            actor1.DescripcionActor = "El que mantiene la pagina";


            List<Entidad> actores = FabricaComandos.CrearComandoConsultarActoresCB().Ejecutar("TOT");

            Assert.IsNotNull(actores);

        }



        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaVerificarExistenciaActor()
        {

            FabricaEntidades fabrica = new FabricaEntidades();

            Entidad entidadActor = fabrica.ObtenerActor();
            Entidad entidadCasoUso = fabrica.ObtenerCasoDeUso();


            CasoDeUso casoUso = entidadCasoUso as CasoDeUso;



            Comando<string, bool> comandoVerificarActor =
                        FabricaComandos.CrearComandoVerificarActor();

            bool laLista = comandoVerificarActor.Ejecutar("Administrador");


            Assert.IsNotNull(laLista);

        }

        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoConsultarTodosLosActores()
        {
            Actor actor1 = new Actor();


            actor1.NombreActor = "Administrador";
            actor1.DescripcionActor = "El que mantiene la pagina";


            List<Entidad> actores = FabricaComandos.CrearComandoListarActores().Ejecutar("TOT");


            Assert.IsNotNull(actores);


        }

        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoConsultarActoresXCasoDeUso()
        {
            Actor actor1 = new Actor();


            actor1.NombreActor = "Administrador";
            actor1.DescripcionActor = "El que mantiene la pagina";


            List<string> actores = FabricaComandos.CrearComandoConsultarActoresXCasoDeUso().Ejecutar(1);


            Assert.IsNotNull(actores);


        }


        /// <summary>
        /// Metodo que prueba el comando detalle de una minuta 
        /// </summary>
        [Test]
        public void PruebaComandoConsultarCasoDeUsoPorActor()
        {

            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidadAct = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();

            Actor actor = entidadAct as Actor;
            actor.NombreActor = "Administrador";

            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            actor.ProyectoAsociado = proyecto;




            Comando<Entidad, List<Entidad>> comandoCasosUsoPorActor =
                        FabricaComandos.CrearComandoConsultarCasosDeUsoXActor();

            List<Entidad> laLista = comandoCasosUsoPorActor.Ejecutar(actor);


            Assert.IsNotNull(laLista);


        }











        /// <summary>
        /// Se prueba que la clase pueda agregar actores
        /// </summary>
        [Test]
        public void PruebaComandoAgregar()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            entidad.Id = 4;
            Actor actor = entidad as Actor;
            actor.NombreActor = "Sandra";
            actor.DescripcionActor = "es buena estudiante";
            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            actor.ProyectoAsociado = proyecto;


            Assert.IsTrue(FabricaComandos.CrearComandoAgregarActor().Ejecutar(entidad));


        }



        /// <summary>
        /// Se prueba que la clase pueda eliminiar actores
        /// </summary>
        [Test]
        public void PruebaComandoEliminarActor()
        {

            int id = 1;
            Assert.IsTrue(FabricaComandos.CrearComandoEliminarCU().Ejecutar(id));
        }





        /// <summary>
        /// Se deja en vacio el atributo creado para ser limpiado por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            _prueba = null;
        }

    }
}

