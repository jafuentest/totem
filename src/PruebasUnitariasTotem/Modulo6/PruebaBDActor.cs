using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DatosTotem.Modulo6;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo6
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre la clase BDActor
    /// </summary>
    [TestFixture]
    public class PruebaBDActor
    {
        //Atributos para probar la clase
        private Actor actorPrueba;
        private BDActor bdPrueba;

        /// <summary>
        /// Inicializa la clase que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            bdPrueba = new BDActor();
            actorPrueba = new Actor("prueba", "prueba");
        }

        /// <summary>
        /// Se prueba que la clase creada no apunte a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(bdPrueba);

        }

        /// <summary>
        /// Se prueba que la clase pueda agregar actores
        /// </summary>
        [Test]
        public void PruebaAgregar()
        {
            Assert.IsTrue(bdPrueba.AgregarActor(actorPrueba, 1));
        }

        [Test]
        public void PruebaLeer()
        {
            //Insertamos un valor de prueba
            bdPrueba.AgregarActor(actorPrueba, 1);

            //Leemos los actores
            List<Actor> listaActores = bdPrueba.ListarActor(1);

            /*Probamos que la lista devuelta no es nula y a su vez
            que nos devuelva un actor de predeterminado de prueba*/
            Assert.IsNotNull(listaActores);
            Assert.AreEqual(listaActores[listaActores.Count - 1].NombreActor, "prueba");
            Assert.AreEqual(listaActores[listaActores.Count - 1].DescripcionActor, "prueba");
        }

        /// <summary>
        /// Se prueba que la clase pueda modificar actores
        /// </summary>
        [Test]
        public void PruebaModificar()
        {
            //Insertamos un valor de prueba
            bdPrueba.AgregarActor(actorPrueba, 1);

            //Obtenemos ese valor de prueba
            List<Actor> listaActores = bdPrueba.ListarActor(1);
            Actor actorModificar = listaActores[listaActores.Count - 1];

            //Alteramos sus valores
            actorModificar.NombreActor = "PRUEBA";
            actorModificar.DescripcionActor = "PRUEBA";

            //Lo modificamos
            Assert.IsTrue(bdPrueba.ModificarActor(actorModificar, 1));
        }

        /// <summary>
        /// Se prueba que la clase pueda eliminiar actores
        /// </summary>
        [Test]
        public void PruebaEliminar()
        {
            //Insertamos un valor de prueba
            bdPrueba.AgregarActor(actorPrueba, 1);

            //Leemos los actores
            List<Actor> listaActores = bdPrueba.ListarActor(1);

            //Eliminamos el valor de prueba insertado
            Assert.IsTrue(bdPrueba.EliminarActor(listaActores[listaActores.Count - 1], 1));
        }

        /// <summary>
        /// Se deja en vacio el atributo creado para ser limpiado por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            actorPrueba = null;
            bdPrueba = null;
        }

    }
}
