using System;
using System.Collections.Generic;
using Comandos;
using Comandos.Comandos.Modulo1;
using NUnit.Framework;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using ExcepcionesTotem.Modulo1;



namespace PruebasUnitariasTotem.Modulo1
{
    [TestFixture]
    public class PruebaComandos
    {
        #region Atributos
        private Usuario usuario;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region Inicio y Fin de la Prueba Unitaria
        /// <summary>
        /// Método para Inicializar los atributos de la clase PruebaDaoLogin
        /// </summary>
        [SetUp]
        public void Init()
        {
            fabricaEntidades = new FabricaEntidades();
            usuario = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuario.Username = RecursosPUMod1.UsuarioExitoso;
            usuario.Clave = RecursosPUMod1.ClaveExitosa;
        }

        /// <summary>
        /// Método para limpiar la memoria una vez finalizado el test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            usuario = null;
            fabricaEntidades = null;
        }
        #endregion 

        #region Pruebas Unitarias ComandoCambioDeClave
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoCambioClaveUsuarioVacio()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            ComandoCambioDeClave comandoCambioDeClave = new ComandoCambioDeClave();
            comandoCambioDeClave.Ejecutar(usuarioPrueba);
        }


        [Test]
        public void PruebaComandoCambioClaveCorrecto()
        {
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            ComandoCambioDeClave comandoCambioDeClave = new ComandoCambioDeClave();
            bool salida = comandoCambioDeClave.Ejecutar(usuario);
            Assert.AreEqual(true, salida);
        }
        #endregion

        #region Pruebas Unitarias ComandoDesencriptar
        [Test]
        public void PruebaComandoDescifrarConRijndael()
        {
            Comando<List<string>, string> comandoCifrar = new ComandoEncriptar();
            List<string> parametroCifrar = new List<string>();
            parametroCifrar.Add(RecursosPUMod1.mensaje);
            parametroCifrar.Add(RecursosPUMod1.Passphrase);
            String mensajeCifrado = comandoCifrar.Ejecutar(parametroCifrar);

            List<string> parametroDescifrar = new List<string>();
            parametroDescifrar.Add(mensajeCifrado);
            parametroDescifrar.Add(RecursosPUMod1.Passphrase);
            Comando<List<string>, string> comandoDesencriptar = new ComandoDesencriptar();
            String mensajeDescifrado = comandoDesencriptar.Ejecutar(parametroDescifrar);

            Assert.AreEqual(mensajeDescifrado, RecursosPUMod1.mensaje);
        }

        #endregion

        #region Pruebas Unitarias ComandoEncriptar
        [Test]
        public void PruebaComandoCifrarConRijndael()
        {
            Comando<List<string>, string> comandoCifrar = new ComandoEncriptar();
            List<string> parametroCifrar = new List<string>();
            parametroCifrar.Add(RecursosPUMod1.mensaje);
            parametroCifrar.Add(RecursosPUMod1.Passphrase);
            String mensajeCifrado = comandoCifrar.Ejecutar(parametroCifrar);

            Assert.AreNotEqual(mensajeCifrado, RecursosPUMod1.mensaje);
        }

        #endregion

    }
}
