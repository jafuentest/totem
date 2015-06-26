using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos;
using Comandos.Fabrica;
using Dominio;
using Dominio.Entidades;
using Dominio.Fabrica;

namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el comando de Validar username unico
    /// </summary>
    [TestFixture]
    public class PruebaComandoValidarUsernameUnico
    {
        //Atributos que utilizaremos para las pruebas
        Comando<String, bool> comandoValidarUsername;
        private Comando<String, bool> eliminarUsuario;
        private Entidad usuarioRegistrar;
        private Comando<Entidad, bool> comandoAgregar;

        /// <summary>
        /// Inicializa los valores que necesitaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            //Instanciamos el comando de agregar Usuario
            comandoAgregar = FabricaComandos.CrearComandoAgregarUsuario();

            //Creamos la entidad de Usuario
            FabricaEntidades entidades = new FabricaEntidades();
            usuarioRegistrar = entidades.ObtenerUsuario("prueba", "prueba", "prueba", "prueba", "prueba", "prueba", "prueba",
                "prueba", "Gerente");

            //Instanciamos el comando de Validar Username Unico
            comandoValidarUsername = FabricaComandos.CrearComandoValidarUsernameUnico();

            //comando que eliminara al usuario de prueba
            eliminarUsuario = FabricaComandos.CrearComandoEliminarUsuarios();

        }

        /// <summary>
        /// Prueba que verifica si existe o no ese username
        /// </summary>
        [Test]
        public void PruebaValidarUsername()
        {
            //Verificamos un usuario que no existe aun
            Assert.IsTrue(comandoValidarUsername.Ejecutar("prueba"));

            //Lo registraemos
            comandoAgregar.Ejecutar(usuarioRegistrar);

            //Verificamos de nuevo al usuario
            Assert.IsTrue(!comandoValidarUsername.Ejecutar("prueba"));

            //Limpiamos el usuario de prueba
            eliminarUsuario.Ejecutar("prueba");
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoValidarUsername = null;
            eliminarUsuario = null;
            usuarioRegistrar = null;
            comandoAgregar = null;
        }

    }
}
