using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos;
using Comandos.Fabrica;

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

        /// <summary>
        /// Inicializa los valores que necesitaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            //Instanciamos el comando de validar correo Unico
            comandoValidarCorreo = FabricaComandos.CrearComandoValidarCorreoUnico();
        }

        /// <summary>
        /// Prueba que verifica si existe o no un correo ingresado
        /// </summary>
        [Test]
        public void PruebaValidarCorreo()
        {
            Assert.IsTrue(comandoValidarCorreo.Ejecutar("blabla"));
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoValidarCorreo = null;
        }
    }
}
