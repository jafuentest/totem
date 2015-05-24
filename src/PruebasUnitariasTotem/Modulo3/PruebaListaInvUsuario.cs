using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo3
{

    /// <summary>
    /// Grupo de pruebas unitarias para la clase ListaInvolucradoUsuario
    /// </summary>
    [TestFixture]
    public class PruebaListaInvUsuario
    {
        private ListaInvolucradoUsuario laLista;
        private Proyecto elProyecto;
        private List<Usuario> laListaUsuarios;
        private Usuario elUsuario;

        [SetUp]
        public void init()
        {
            laLista = new ListaInvolucradoUsuario();
            laListaUsuarios = new List<Usuario>();
            elUsuario = new Usuario();
            laListaUsuarios.Add(elUsuario);
            elUsuario.username = "adosale";
            elUsuario.cargo = "Gerente";

        }
        [TearDown]
        public void limpiar()
        {
            laLista = null;
            elProyecto = null;
            laListaUsuarios = null;
            elUsuario = null;

        }

        /// <summary>
        /// Prueba para el constructor vacio de la clase ListaInvolucradoUsuario
        /// </summary>
        [Test]
        public void pruebaCtorVacio()
        {
            Assert.IsNotNull(laLista);
        }

        /// <summary>
        /// Prueba para el constructor de la clase ListaInvolucradoUsuario que recibe proyecto como parametro
        /// </summary>
        [Test]
        public void pruebaCtorConProyecto()
        {
            laLista = new ListaInvolucradoUsuario(elProyecto);
            Assert.IsNotNull(laLista);
        }

        /// <summary>
        /// Prueba del constructor de la lista ListaInvolucradoUsuario que recibe un proyecto y una lista de usuarios
        /// </summary>
        [Test]
        public void pruebaCtorConListaUsuariosProyecto()
        {
            laLista = new ListaInvolucradoUsuario(laListaUsuarios, elProyecto);

            Assert.IsNotNull(laLista);
        }

        /// <summary>
        /// Prueba del metodo agregarUsuarioAProyecto de la clase ListaInvolucradoUsuario
        /// </summary>
        [Test]
        public void pruebaAgregarUsuarioAProyecto()
        {
            Assert.IsTrue(laLista.agregarUsuarioAProyecto(elUsuario));

            Assert.AreEqual("adosale", laLista.Lista.Last().username);
            Assert.AreEqual("Gerente", laLista.Lista.Last().cargo);

            System.Console.WriteLine("Username: " + laLista.Lista.Last().username);
            System.Console.WriteLine("Cargo: " + laLista.Lista.Last().cargo);
        }

        /// <summary>
        /// Prueba del metodo eliminarUsuarioDeProyecto de la clase ListaInvolucradoUsuario
        /// </summary>
        [Test]
        public void eliminarUsuarioDeProyecto()
        {
            laLista.agregarUsuarioAProyecto(elUsuario);
            laLista.eliminarUsuarioDeProyecto(elUsuario);

            Assert.AreEqual(0, laLista.Lista.ToArray().Length);
            System.Console.WriteLine("Tamaño de lista: " + laLista.Lista.ToArray().Length);
        }


    }
}
