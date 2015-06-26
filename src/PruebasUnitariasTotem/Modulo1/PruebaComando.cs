using System;
using System.Collections.Generic;
using Comandos;
using Comandos.Comandos.Modulo1;
using NUnit.Framework;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using ExcepcionesTotem.Modulo1;
using Dominio;

namespace PruebasUnitariasTotem.Modulo1
{

    /// <summary>
    /// Pruebas Unitarias para los Comandos de Login
    /// </summary>
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

        /// <summary>
        /// Prueba de parámetros vacios  
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoCambioClaveUsuarioVacio()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            ComandoCambioDeClave comandoCambioDeClave = new ComandoCambioDeClave();
            comandoCambioDeClave.Ejecutar(usuarioPrueba);
        }

        /// <summary>
        /// Método para validar el Caso Correcto
        /// </summary>
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
        /// <summary>
        /// Método para validar que el comando EncriptarConRijndael
        /// funcione correctamente
        /// </summary>
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
        /// <summary>
        /// Método para verificar que el comando Encriptar funcione correctamente
        /// </summary>
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
        
        #region Pruebas Unitarias ComandoIniciarSesion
        /// <summary>
        /// Método para verificar que el ComandoIniciarSesion funcione correctamente
        /// </summary>
        [Test]
        public void PruebaComandoInciarSesionCorrecto()
        {
            Comando<List<string>, Entidad> comando = new ComandoIniciarSesion();
            List<string> parametros = new List<string>();
            parametros.Add(RecursosPUMod1.UsuarioExitoso);
            parametros.Add(RecursosPUMod1.ClaveExitosa);
            usuario = (Usuario)comando.Ejecutar(parametros);

            Assert.AreEqual(RecursosPUMod1.CorreoExitoso,usuario.Correo);
        }

        /// <summary>
        /// Método para verificar que se ejecute la Excepción cuando se pasa una clave incorrecta
        /// </summary>
        [Test, ExpectedException(typeof(LoginErradoException))]
        public void PruebaComandoIniciarSesionIncorrecto()
        {
            Comando<List<string>, Entidad> comando = new ComandoIniciarSesion();
            List<string> parametros = new List<string>();
            parametros.Add(RecursosPUMod1.UsuarioExitoso);
            parametros.Add(RecursosPUMod1.ClaveFallida);
            usuario = (Usuario)comando.Ejecutar(parametros);
        }

        /// <summary>
        /// Método para asegurar que el Método responda correctamente
        /// si se le pasa parámetros con valores nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoIniciarSesionParametroNulo()
        {
            Comando<List<string>, Entidad> comando = new ComandoIniciarSesion();
            List<string> parametros = new List<string>();
            parametros.Add(null);
            parametros.Add(null);
            usuario = (Usuario)comando.Ejecutar(parametros);
        }

        #endregion

        #region Pruebas Unitarias ComandoObtenerPreguntaSeguridad
        /// <summary>
        /// Método para verificar que el comando ObtenerPreguntaDeSeguridad funcione correctamente
        /// </summary>
        [Test]
        public void PruebaComandoObtenerPreguntaSeguridadCorrecto()
        {
            Comando<Entidad, Entidad> comando = new ComandoObtenerPreguntaSeguridad();
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            Usuario salida = (Usuario)comando.Ejecutar(usuario);
            Assert.AreEqual(RecursosPUMod1.PreguntaDeSeguridad, salida.PreguntaSeguridad);
        }

        /// <summary>
        /// Método para asegurar que el Comando responda correctamente
        /// si se le pasa parámetros con valores nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoObtenerPreguntaSeguridadParametroNulo()
        {
            Comando<Entidad, Entidad> comando = new ComandoObtenerPreguntaSeguridad();
            usuario.Correo = null;
            Usuario salida = (Usuario)comando.Ejecutar(usuario);
        }

        /// <summary>
        /// Método para vericar que se ejecute la excepción cuando la respuesta es incorrecta
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoObtenerPreguntaSeguridadIncorrecto()
        {
            Comando<Entidad, Entidad> comando = new ComandoObtenerPreguntaSeguridad();
            usuario.Correo = RecursosPUMod1.CorreoFallido;
            Usuario salida = (Usuario)comando.Ejecutar(usuario);
        }

        #endregion

        #region Pruebas Unitarias ComandoValidarCorreoExistente
        /// <summary>
        /// Método para verficar que el comando ValidarCorreoExistente funcione correctamente
        /// </summary>
        [Test]
        public void PruebaComandoValidarCorreoExistenteCorrecto()
        {
            Comando<string, bool> comando = new ComandoValidarCorreoExistente();
            bool salida = comando.Ejecutar(RecursosPUMod1.CorreoExitoso);
            Assert.AreEqual(salida, true);
        }

        /// <summary>
        /// Método para verificar que cuando se pase un correo inexistente retorne que este no es válido
        /// </summary>
        [Test]
        public void PruebaComandoValidarCorreoExistenteIncorrecto()
        {
            Comando<string, bool> comando = new ComandoValidarCorreoExistente();
            bool salida = comando.Ejecutar(RecursosPUMod1.CorreoFallido);
            Assert.AreEqual(salida, false);
        }
        #endregion

        #region Pruebas Unitarias ComandoValidarRespuestaSecreta
        /// <summary>
        /// Método para validar que el comando ValidarRespuestaCorrecta funcione correctamente
        /// </summary>
        [Test]
        public void PruebaComandoValidarRespuestaCorrecto()
        {
            Comando<Entidad, bool> comando = new ComandoValidarRespuestaSecreta();
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            usuario.RespuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadExitosa;
            bool salida = comando.Ejecutar(usuario);
            Assert.AreEqual(salida, true);
        }

        /// <summary>
        /// Método para verificar que cuando se pase una respuesta incorrecta ejecute la excepción correspondiente
        /// </summary>
        [Test, ExpectedException(typeof(RespuestaErradoException))]
        public void PruebaComandoValidarRespuestaIncorrecto()
        {
            Comando<Entidad, bool> comando = new ComandoValidarRespuestaSecreta();
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            usuario.RespuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadFallida;
            bool salida = comando.Ejecutar(usuario);
            Assert.AreEqual(salida, false);
        }

        /// <summary>
        /// Método para asegurar que el Comando responda correctamente
        /// si se le pasa parámetros con valores nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void PruebaComandoValidarRespuestaParametroVacio()
        {
            Comando<Entidad, bool> comando = new ComandoValidarRespuestaSecreta();
            bool salida = comando.Ejecutar(usuario);
        }
        #endregion
    }
}
