using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Datos.DAO.Modulo7;
using Comandos;
using Comandos.Fabrica;

namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el comando de Listar Cargos
    /// </summary>
    [TestFixture]
    public class PruebaComandoListarCargos
    {
        private List<String> cargos;
        //Atributos que utilizaremos para las pruebas
        private Comando<bool, List<String>> comandoCargos;
        private List<String> listaCargos;


        /// <summary>
        /// Inicializa los valores que necesitaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            //Instanciamos el comando de Listar Cargos
            comandoCargos = FabricaComandos.CrearComandoListarCargos();

        }

        /// <summary>
        /// Se prueba que regrese los diferentes cargos existentes
        /// </summary>
        [Test]
        public void ListarCargos()
        {


            listaCargos = comandoCargos.Ejecutar(true);
            Assert.IsNotNull(listaCargos);
            Assert.AreEqual("Gerente", listaCargos[0]);
            Assert.AreEqual("Desarrollador", listaCargos[1]);
            Assert.AreEqual("Diseñador", listaCargos[2]);
            Assert.AreEqual("Lider de Proyecto", listaCargos[3]);
            Assert.AreEqual("Arquitecto de Solucion", listaCargos[4]);
            Assert.AreEqual("Arquitecto de Base de Datos", listaCargos[5]);
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoCargos = null;
        }

    }
}
