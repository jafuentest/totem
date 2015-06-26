using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos;
using Comandos.Fabrica;
using Dominio;
using Dominio.Fabrica;


namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el comando de AgregarUsuario
    /// </summary>
    [TestFixture]
    public class PruebaComandoValidarCorreoUnico
    {
        //Atributos que utilizaremos para las pruebas
        private Comando<String, bool> comandoValidarCorreo;
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

            //comando que eliminara al usuario de prueba
            eliminarUsuario = FabricaComandos.CrearComandoEliminarUsuarios();

            //Instanciamos el comando de validar correo Unico
            comandoValidarCorreo = FabricaComandos.CrearComandoValidarCorreoUnico();
        }

        /// <summary>
        /// Prueba que verifica si existe o no un correo ingresado
        /// </summary>
        [Test]
        public void PruebaValidarCorreo()
        {
            //Verificamos que el correo no existe aun
            Assert.IsTrue(comandoValidarCorreo.Ejecutar("prueba"));

            //Lo registraemos
            comandoAgregar.Ejecutar(usuarioRegistrar);

            //Verificamos que el correo ya existe
            Assert.IsTrue(!comandoValidarCorreo.Ejecutar("prueba"));

            //Limpiamos el usuario de prueba
            eliminarUsuario.Ejecutar("prueba");
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoValidarCorreo = null;
            eliminarUsuario = null;
            usuarioRegistrar = null;
            comandoAgregar = null;
        }
    }
}
