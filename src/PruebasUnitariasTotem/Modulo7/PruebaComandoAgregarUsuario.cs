﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Comandos.Comandos.Modulo7;
using Dominio.Entidades.Modulo7;
using Comandos;
using Dominio;
using Comandos.Fabrica;
using Dominio.Fabrica;


namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el comando de AgregarUsuario
    /// </summary>
    [TestFixture]
    public class PruebaComandoAgregarUsuario
    {
        //Atributos que utilizaremos para las pruebas
        private Comando<Entidad, bool> comandoAgregar;
        private Entidad usuarioRegistrar;
        private Comando<String, bool> eliminarUsuario;

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

            //Comando que eliminara al usuario de prueba
            eliminarUsuario = FabricaComandos.CrearComandoEliminarUsuarios();

        }

        /// <summary>
        /// Prueba que verifica que se pueda registar un usuario
        /// </summary>
        [Test]
        public void PruebaAgregarUsuario()
        {
            //Lo registramos
            Assert.IsTrue(comandoAgregar.Ejecutar(usuarioRegistrar));

            //Intentamos registrarlo de nuevo
            Assert.IsTrue(!comandoAgregar.Ejecutar(usuarioRegistrar));

            //Limpiamos el usuario de prueba
            eliminarUsuario.Ejecutar("prueba");
                  
        }

        /// <summary>
        /// Posiciona los objetos a Null para que puedan ser limpiados por el Garbaje Collector
        /// </summary>
        public void Limpiar()
        {
            usuarioRegistrar = null;
            comandoAgregar = null;
            eliminarUsuario = null;

        }
    }
}
