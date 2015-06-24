using NUnit.Framework;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using ExcepcionesTotem.Modulo1;
using DAO.DAO.Modulo1;

namespace PruebasUnitariasTotem.Modulo1
{
    /// <summary>
    /// Pruebas Unitarias para la Clase DaoLogin de la capa DAO
    /// </summary>
    [TestFixture]
    public class PruebaDAOLogin
    {
        #region Atributos
        private Usuario usuario;
        private DaoLogin daoLogin;
        private FabricaEntidades fabricaEntidades;
        #endregion

        #region Inicio y Fin de la Prueba Unitaria
        /// <summary>
        /// Método para Inicializar los atributos de la clase PruebaDaoLogin
        /// </summary>
        [SetUp]
        public void Init()
        {
            daoLogin = new DaoLogin();
            fabricaEntidades = new FabricaEntidades();
            usuario = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuario.Username = RecursosPUMod1.UsuarioExitoso;
            usuario.Clave = RecursosPUMod1.ClaveExitosa;
            usuario.CalcularHash();
        }

        /// <summary>
        /// Método para limpiar la memoria una vez finalizado el test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            usuario = null;
            daoLogin = null;
            fabricaEntidades = null;
        }
        #endregion 

        #region Pruebas Unitarias de ValidarUsuarioLogin
        /// <summary>
        /// Método para asegurar que el Método ValidarUsuarioLogin
        /// la Entidad no puede tener valores Nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void ValidarParametrosNulosLogin()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            Entidad salida = daoLogin.ValidarUsuarioLogin(usuarioPrueba);
        }

        /// <summary>
        /// Método para verificar que se devuelva NULL cuando un Login fue errado
        /// </summary>
        [Test]
        public void LoginErrado()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuarioPrueba.Username = RecursosPUMod1.UsuarioFallido;
            usuarioPrueba.Clave = RecursosPUMod1.ClaveFallida;
            usuarioPrueba.CalcularHash();
            Entidad salida = (Usuario)daoLogin.ValidarUsuarioLogin(usuarioPrueba);
            Assert.AreEqual(salida, null);
        }

        /// <summary>
        /// Método para verificar que funcione correctamente
        /// </summary>
        [Test]
        public void ValidarDatosUsuarioCorrectoLogin()
        {
            Usuario salida = (Usuario)daoLogin.ValidarUsuarioLogin(usuario);
            Assert.AreEqual(RecursosPUMod1.CorreoExitoso, salida.Correo);
        }

        #endregion 

        #region Pruebas Unitarias ObtenerPreguntaSeguridad
        /// <summary>
        /// Método para asegurar que el Método ObtenerPreguntaSeguridad
        /// la Entidad no puede tener valores Nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void ValidarParametrosNulosObPreguntaSeguridad()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            Entidad salida = daoLogin.ObtenerPreguntaSeguridad(usuarioPrueba);
        }

        /// <summary>
        /// Método para verificar que se devuelva NULL cuando un usuario 
        /// que no existe solicite su pregunta de seguridad
        /// </summary>
        [Test]
        public void UsuarioNoExistePreguntaSeguridad()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuarioPrueba.Username = RecursosPUMod1.UsuarioFallido;
            usuarioPrueba.Correo = RecursosPUMod1.CorreoFallido;
            Usuario salida = (Usuario)daoLogin.ObtenerPreguntaSeguridad(usuarioPrueba);
            Assert.AreEqual(salida.PreguntaSeguridad, null);
        }

        /// <summary>
        /// Método para verificar que la pregunta de seguridad sea la correcta
        /// </summary>
        [Test]
        public void PreguntaCorrectaPreguntaSeguridad()
        {
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            Usuario salida = (Usuario)daoLogin.ObtenerPreguntaSeguridad(usuario);
            Assert.AreEqual(RecursosPUMod1.PreguntaDeSeguridad, salida.PreguntaSeguridad);
        }

        #endregion

        #region Pruebas Unitarias de ValidarRespuestaSeguridad

        /// <summary>
        /// Método para asegurar que en el Método ValidarRespuestaSeguridad
        /// no reciba un parámetro null
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void ValidarParametrosNulosRespuestaSeguridad()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            bool salida = daoLogin.ValidarRespuestaSeguridad(usuarioPrueba);
        }

        /// <summary>
        /// Método para verificar el comportamiento sea el correcto cuando la respuesta es incorrecta
        /// </summary>
        [Test, ExpectedException(typeof(RespuestaErradoException))]
        public void RespuestaIncorrectaRespuestaSeguridad()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuarioPrueba.Username = RecursosPUMod1.UsuarioExitoso;
            usuarioPrueba.Correo = RecursosPUMod1.CorreoExitoso;
            usuarioPrueba.RespuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadFallida;
            bool salida = daoLogin.ValidarRespuestaSeguridad(usuarioPrueba);
        }

        /// <summary>
        /// Método para verificar que la respuesta de seguridad es la correcta
        /// </summary>
        [Test]
        public void RespuestaCorrectaRespuestaSeguridad()
        {
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            usuario.RespuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadExitosa;
            bool salida = daoLogin.ValidarRespuestaSeguridad(usuario);
            Assert.AreEqual(true, salida);
        }
        #endregion

        #region Pruebas Unitarias de ValidarCorreoExistente
        /// <summary>
        /// Método para verificar que cuando no exista el correo en la BD
        /// Retorne False
        /// no reciba un parámetro null
        /// </summary>
        [Test]
        public void ValidarCorreoIncorrecto()
        {
            string correo = RecursosPUMod1.CorreoFallido;
            bool salida = daoLogin.ValidarCorreoExistente(correo);
            Assert.AreEqual(false, salida);
        }

        /// <summary>
        /// Método para verificar que cuando exista el correo en la BD
        /// Retorne True
        /// no reciba un parámetro null
        /// </summary>
        [Test]
        public void ValidarCorreoCorrecto()
        {
            string correo = RecursosPUMod1.CorreoExitoso;
            bool salida = daoLogin.ValidarCorreoExistente(correo);
            Assert.AreEqual(true, salida);
        }

        #endregion

        #region Pruebas Unitarias de Modificar
        /// <summary>
        /// Método para asegurar que el Método Modificar
        /// no reciba parámetros Nulos
        /// </summary>
        [Test, ExpectedException(typeof(UsuarioVacioException))]
        public void ValidarParametrosNulosModificar()
        {
            Usuario usuarioPrueba = (Usuario)fabricaEntidades.ObtenerUsuario();
            bool salida = daoLogin.Modificar(usuarioPrueba);
        }

        /// <summary>
        /// Método para verificar que el Método Modificar retorna True cuando se realizó correctamente
        /// </summary>
        [Test]
        public void ValidarModificar()
        {
            usuario.Correo = RecursosPUMod1.CorreoExitoso;
            bool salida = daoLogin.Modificar(usuario);
            Assert.AreEqual(true, salida);
        }
        #endregion

    }
}
