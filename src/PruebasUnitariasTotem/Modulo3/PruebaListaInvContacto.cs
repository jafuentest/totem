using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo3
{    

    /// <summary>
    /// Grupo de pruebas unitarias para la clase ListaInvolucradoContacto
    /// </summary>
    [TestFixture]
    public class PruebaListaInvContacto
    {

        private ListaInvolucradoContacto laLista;
        private Proyecto elProyecto;
        private List<Contacto> contactos;
        private Contacto elContacto;

        [SetUp]
        public void init()
        {
            laLista    = new ListaInvolucradoContacto();
            elContacto = new Contacto();
            elContacto.Con_Nombre = "Carlos";
            elContacto.Con_Apellido = "Unda";
            contactos = new List<Contacto>();
            contactos.Add(elContacto);
        }
        [TearDown]
        public void clean()
        {
            laLista    = null;
            elProyecto = null;
            contactos  = null;
            elContacto = null;
        }

        #region Pruebas de Constructores
        /// <summary>
        /// Prueba para el constructor vacio de la clase ListaInvolucradoContacto
        /// </summary>
        [Test]
        public void pruebaCtorVacio()
        {
            Assert.IsNotNull(laLista);
        }
        /// <summary>
        /// Prueba para el constructor de la clase ListaInvolucradoContacto que recibe un proyecto como parametro
        /// </summary>
        [Test]
        public void pruebaCtorConProyecto()
        {
            laLista = new ListaInvolucradoContacto(elProyecto);
            Assert.IsNotNull(laLista);
        }
        /// <summary>
        /// Prueba para el constructor de la clase ListaInvolucradoContacto que recibe un proyecto y 
        /// la lista de contactos
        /// </summary>
        [Test]
        public void pruebaCtorCompleto()
        {
            laLista = new ListaInvolucradoContacto(contactos, elProyecto);
            Assert.IsNotNull(laLista);
        }
        #endregion

        /// <summary>
        /// Prueba para el metodo agregarContactoAProyecto de la clase ListaInvolucradoContacto
        /// </summary>
        [Test]
        public void pruebaAgregarContacto()
        {
            Assert.IsTrue(laLista.agregarContactoAProyecto(elContacto));
            Assert.AreEqual("Carlos", laLista.Lista.Last().Con_Nombre);
            Assert.AreEqual("Unda", laLista.Lista.Last().Con_Apellido);
            System.Console.WriteLine(laLista.Lista.Last().Con_Nombre);
            System.Console.WriteLine(laLista.Lista.Last().Con_Apellido);
        }
        /// <summary>
        /// Prueba para el metodo eliminarContactoDeProyecto de la clase ListaInvolucradoContacto
        /// </summary>
        [Test]
        public void pruebaEliminarContacto()
        {
            laLista.agregarContactoAProyecto(elContacto);
            Assert.IsTrue(laLista.eliminarContactoDeProyecto(elContacto));
            Assert.AreEqual(0, laLista.Lista.ToArray().Length);
        }

    }
}
