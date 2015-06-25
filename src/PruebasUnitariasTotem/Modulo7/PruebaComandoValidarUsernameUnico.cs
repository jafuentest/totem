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
    /// Prueba unitaria que trabaja sobre el comando de Validar username unico
    /// </summary>
    [TestFixture]
    public class PruebaComandoValidarUsernameUnico
    {
        //Atributos que utilizaremos para las pruebas
        Comando<String, bool> comandoValidarUsername;

        /// <summary>
        /// Inicializa los valores que necesitaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            //Instanciamos el comando de Validar Username Unico
            comandoValidarUsername = FabricaComandos.CrearComandoValidarUsernameUnico();

        }

        /// <summary>
        /// Prueba que verifica si existe o no ese username
        /// </summary>
        [Test]
        public void PruebaValidarUsername()
        {
            Assert.IsTrue(comandoValidarUsername.Ejecutar(""));
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoValidarUsername = null;
        }

    }
}
