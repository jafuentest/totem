using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAO.DAO.Modulo6;
using Dominio.Entidades;
using Dominio;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo5;
using Dominio.Fabrica;
using LogicaNegociosTotem;
using LogicaNegociosTotem.Modulo6;

using Comandos.Fabrica;
using Comandos.Comandos.Modulo6;
using Comandos;

namespace PruebasUnitariasTotem.Modulo6
{
    [TestFixture]
    class PruebaConstructores
    {
        private CasoDeUso casodeUso;
        private Actor actor;
        private Extension extension;
        private Proyecto elProyecto;
        private List<string> precondicionesCasoUso;
        private List<Actor> actores;
        private List<Requerimiento> requerimientos;
        private List<Paso> escenarioExito;
        private List<Extension> lasExtensiones;
        private List<Paso> losPasos;
        private Paso paso;

        [SetUp]
        public void Init()
        {
            actor = new Actor();
            casodeUso = new CasoDeUso();
            extension = new Extension();
            elProyecto = new Proyecto();
            paso = new Paso();
            precondicionesCasoUso = new List<string>();
            actores = new List<Actor>();
            requerimientos = new List<Requerimiento>();
            escenarioExito = new List<Paso>();
            losPasos = new List<Paso>();
            lasExtensiones = new List<Extension>();

        }




        #region Prueba de los Constructores


        /// <summary>
        /// Prueba sobre los constructores vacíos
        /// de la clase actor
        /// Natural
        /// </summary>
        [Test]
        public void PruebaCtroVacioActor()
        {
            Assert.IsNotNull(actor);

        }

        /// <summary>
        /// Prueba sobre los constructores vacíos
        /// de la clase caso de uso
        /// </summary>
        [Test]
        public void PruebaCtroVacioCasoDeUso()
        {
            Assert.IsNotNull(casodeUso);

        }

        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresActorConParametros()
        {
            //Prueba con parámetros de nombre, descripcion y el proyecto
            string nombre = "Ingeniero";
            string descripcion = "el que resuelve problemas";

            Proyecto elProyecto = new Proyecto("TOT", "LOCATEL", true, "esta",
       "$", 120);
            actor = new Actor(nombre, descripcion, elProyecto);
            Assert.IsNotNull(actor);

            //Nombre Y Descripcion







        }




        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresCasoDeUsoConParametros()
        {
            //Prueba con parámetros de nombre, descripcion y el proyecto
            string nombre = "Ingeniero";
            string descripcion = "el que resuelve problemas";


            CasoDeUso elCasoDeUso = new CasoDeUso("TOT", "LOCATEL", "Actor Creado", "esta",
            "Menu principal -> Crear Actor");

            precondicionesCasoUso.Add("el usuario da al boton aceptar");
            Requerimiento requerimiento = new Requerimiento("codigo",
            "se desea que al agregar se acceda a la consulta", "funcional",
            "alta", "finalizado");


            requerimientos.Add(requerimiento);

            int numeroPaso = 1;

            Paso paso = new Paso(numeroPaso, "A.", lasExtensiones);
            escenarioExito.Add(paso);


            //   Extension extension = new Paso(numeroPaso, "A.", lasExtensiones);
            requerimientos.Add(requerimiento);

            string condicionExitosa = "Actor Creado";
            string condicionFallo = "Actor no Creado";
            string disparadorCasoUso = "Menu principal -> Crear Actor";

            casodeUso = new CasoDeUso("TOT-CU", "Agregar Actor",
            actores, precondicionesCasoUso,
            requerimientos, condicionExitosa, condicionFallo,
            disparadorCasoUso, escenarioExito);



            Assert.IsNotNull(casodeUso);







            // string identificadorCasoUso, string tituloCasoUso, string condicionExito,









        }

        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresCasoDeUsoConParametros2()
        {

            casodeUso = new CasoDeUso("TOT-CU", "Agregar Actor", "Actor Creado",
        "Actor no Creado", "Menu principal -> Crear Actor");



            Assert.IsNotNull(casodeUso);

        }


        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresExtensionConParametros()
        {

            extension = new Extension("El Administrador Selecciona Cancelar", losPasos);



            Assert.IsNotNull(extension);

        }



        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresExtensionSinParametros()
        {

            extension = new Extension();



            Assert.IsNotNull(extension);

        }


        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresPasoSinParametros()
        {

            paso = new Paso();
            Assert.IsNotNull(extension);

        }


        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresExtensionConParametros2()
        {

            paso = new Paso(1, "A.", lasExtensiones);



            Assert.IsNotNull(paso);

        }







        #endregion

        /// <summary>
        /// Método que limpia 
        /// los objetos utilizados durante las pruebas
        /// para ser recolectados por el Recolector de Basura
        /// </summary>

        [TearDown]
        public void Limpiar()
        {
            actor = null;
            casodeUso = null;
            elProyecto = null;
        }
    }
}