using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos;
using Comandos.Fabrica;
using Dominio;
using Dominio.Entidades.Modulo7;

namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el comando de listar usuarios
    /// </summary>
    [TestFixture]
    public class PruebaComandoListarUsuarios
    {
        //Atributos que utilizaremos para las pruebas
        Comando<bool, List<Entidad>> comandoListarUsuarios;
        List<Entidad> listaUsuarios;

        /// <summary>
        /// Inicializa los valores que necesitaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            //Instanciamos el comando Listar Usuarios
            comandoListarUsuarios = FabricaComandos.CrearComandoListarUsuarios();
        }

        /// <summary>
        /// Prueba en la que se enlista todos los usuarios existentes de la Base de Datos
        /// </summary>
        [Test]
        public void PruebaListarUsuarios()
        {
            listaUsuarios = comandoListarUsuarios.Ejecutar(true);
            Assert.IsNotNull(listaUsuarios);
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            comandoListarUsuarios = null;
            comandoListarUsuarios = null;
        }
    }
}
