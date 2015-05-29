using DatosTotem;
using DatosTotem.Modulo1;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using LogicaNegociosTotem.Modulo1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitariasTotem.Modulo1
{
    /// <summary>
    /// Clase para la prueba de las excepciones del modulo 1
    /// </summary>
    [TestFixture]
    public class PruebaExcepciones
    {
        /// <summary>
        /// Objeto para la realizacion de las pruebas
        /// </summary>
        private Usuario usuario;

        /// <summary>
        /// Metodo para la inicializacion de los objetos que se utilizaran en las
        /// pruebas
        /// </summary>
        [SetUp]
        public void init()
        {
            usuario = new Usuario();
        }

        /// <summary>
        /// Metodo para liberar la memoria utilizada por los objetos de las pruebas
        /// </summary>
        [TearDown]
        public void Exit()
        {
            this.usuario = null;
        }

        #region Pruebas unitarias de la logica login

        /// <summary>
        /// Metodo para probar si el metodo login de la clase LogicaLogin dispara
        /// una excepcion(LoginErradoException) al momento de intentar de realizar
        /// login con credenciales invalidas
        /// </summary>
        [Test]
        public void PruebaLoginErradoException()
        {
            try
            {
                usuario.clave = "asdasd";
                usuario.username = "asdasd";
                LogicaLogin.Login(usuario.username, usuario.clave);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (LoginErradoException loginErradoException)
            {
                Assert.AreEqual("No se pudo iniciar sesion, datos erroneos", loginErradoException.Mensaje);
            }
            catch (IntentosFallidosException intentosErradoException)
            {
                Assert.AreEqual("Se fallo el inicio de sesion multiples veces, el usuario puede ser un bot", intentosErradoException.Mensaje);
            }
            
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si el metodo login de la clase LogicaLogin dispara
        /// una excepcion(UsuarioVacioException) al momento de intentar de realizar
        /// login sin los datos necesarios
        /// </summary>
        [Test]
        public void PruebaLoginUsuarioVacioException() {
            try {
                LogicaLogin.Login(null,null);
                Assert.Fail("Una excepcion tuvo que haber sido disparada");
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException err) { 
                
            }
        
        }

        /// <summary>
        /// Metodo para probar si el metodo login de la clase LogicaLogin dispara
        /// una excepcion(ExceptionTotemConexionBD) al momento de intentar de realizar
        /// login sin una conexion establecida a la base de datos de TOTEM
        /// </summary>
        [Test]
        public void PruebaLoginConexionBDException()
        {
            try { 
                LogicaLogin.Login(RecursosPUMod1.UsuarioExitoso, RecursosPUMod1.ClaveExitosa);
                Assert.Fail("Una excepcion se tuvo que haber disparado");
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD){ 
            
            }
        }

        /// <summary>
        /// Metodo para probar si el metodo RecuperacionDeClave de la clase LogicaLogin
        /// dispara una excepcion(EmailErradoException) al momento de realizar la recuperacion 
        /// de la clave con un correo no registrado en TOTEM
        /// </summary>
        [Test]
        public void PruebaRecuperacionClaveEmailErradoException()
        {
            DominioTotem.Usuario user = new Usuario();
            user.correo = "daklsdjlasdjlaksdj.com";
            try{
            LogicaLogin.RecuperacionDeClave(user);
            Assert.Fail("Una excepcion se tuvo que haber disparado");
            }
            catch(ExcepcionesTotem.Modulo1.EmailErradoException err){

            }
            catch(ExcepcionesTotem.ExceptionTotemConexionBD err){
            }
        }

        /// <summary>
        /// Metodo para probar si el metodo RecuperacionDeClave de la clase LogicaLogin
        /// dispara una excepcion(UsuarioVacioException) al momento de realizar la recuperacion 
        /// de la clave no le fue suministrada la informacion minima necesaria al metodo 
        /// </summary>
        [Test]
        public void PruebaRecuperacionClaveUsuarioVacioException() {
            DominioTotem.Usuario user = new Usuario();
            try
            {
                LogicaLogin.RecuperacionDeClave(user);
                Assert.Fail("Una excepcion se tuvo que haber disparado");
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException err)
            {

            }
        
        }

        /// <summary>
        /// Metodo para probar si el metodo PruebaGenerarLinkUsuario  de la clase LogicaLogin
        /// dispara una excepcion(UsuarioVacioException) al momento de realizar la generacion 
        /// del link no le fue suministrado la informacion minima necesaria al metodo 
        /// </summary>
        [Test]
        public void PruebaGenerarLinkUsuarioException() {
            DominioTotem.Usuario user = new Usuario();
            try
            {
                LogicaLogin.RecuperacionDeClave(user);
                Assert.Fail("Una excepcion se tuvo que haber disparado");
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException err)
            {

            }

        }

        /// <summary>
        /// Metodo para probar si el metodo PruebaGenerarLinkUsuario  de la clase LogicaLogin
        /// dispara una excepcion(UsuarioVacioException) cuando no se pueda enviar un correo
        /// a un usuario de recuperacion de clave a un usuario o administrado de TOTEM
        ///</summary>>
        [Test]
        public void PruebaErrorEnvioDeCorreoException()
        {
            try
            {
                usuario.correo = RecursosPUMod1.CorreoFallido;
                LogicaLogin.EnviarEmail(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (EmailErradoException emailErradoException)
            {
                Assert.AreEqual("Error en el envio del correo", emailErradoException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si el metodo EnvioDeCorreo de la clase LogicaLogin dispara
        /// una excepcion(UsuarioVacioException) al momento de intentar de realizar
        /// login sin los datos necesarios
        /// </summary>
        [Test]
        public void PruebaErrorEnvioDeCorreoUsuarioVacioException() {
             try
                 {
                LogicaLogin.EnviarEmail(new Usuario());
                Assert.Fail("Una excepcion se ha debido de lanzar");
                 }
             catch (ExcepcionesTotem.Modulo1.UsuarioVacioException err)
                {

                }

        }



        #endregion

        #region Pruebas unitarias de BD Login
        
        /// <summary>
        /// Metodo para probar si el metodo ValidarPreguntaSeguridadBD
        /// dispara una excepcion (RespuestaErradoException)
        /// </summary>
        [Test]
        public void PruebaRespuestaErradoException()
        {
            try
            {
                usuario.correo = RecursosPUMod1.CorreoExitoso;
                usuario.respuestaSeguridad = RecursosPUMod1.RespuestaDeSeguridadFallida;
                BDLogin.ValidarPreguntaSeguridadBD(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (RespuestaErradoException respuestaErradoException)
            {
                Assert.AreEqual("No se pudo validar la pregunta, respuesta invalida", respuestaErradoException.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si el metodo ValidarLoginBD
        /// dispara una excepcion (UsuarioVacioException)
        /// </summary>
        [Test]
        public void PruebaUsuarioVacioException()
        {
            try
            {

                BDLogin.ValidarLoginBD(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (UsuarioVacioException usuarioVacioException)
            {
                Assert.AreEqual("Datos de usuario incompletos", usuarioVacioException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si el metodo ValidarLoginBD
        /// dispara una excepcion (LoginErradoException)
        /// </summary>
        [Test]
        public void PruebaBDLoginErradoException()
        {
            try
            {
                usuario.username = RecursosPUMod1.UsuarioFallido;
                usuario.clave = RecursosPUMod1.ClaveFallida;
                BDLogin.ValidarLoginBD(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (LoginErradoException err)
            {
            
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );
                
            }

        }

        /// <summary>
        /// Metodo para probar si BDConexion 
        /// dispara una excepcion (ParametroInvalidoException)
        /// </summary>
        [Test]
        public void PruebaParametroInvalidoException()
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = null;
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                con.AsignarParametros(parametros);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (ParametroInvalidoException parametroInvalidoException)
            {
                Assert.AreEqual("Error en un parametro del stored procedure", parametroInvalidoException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si ObtenerPreguntaSeguridad 
        /// dispara una excepcion (EmailErradoException)
        /// </summary>
        [Test]
        public void PruebaEmailErradoException()
        {
            try
            {

                usuario.correo = RecursosPUMod1.CorreoFallido;
                BDLogin.ObtenerPreguntaSeguridad(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (EmailErradoException emailErradoException)
            {
                Assert.AreEqual("No se pudo obtener la pregunta de seguridad, el email es invalido", emailErradoException.Mensaje);
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }

        /// <summary>
        /// Metodo para probar si ObtenerPreguntaSeguridad
        /// dispara la excepcion (UsuarioVacioException)
        /// </summary>
        [Test]
        public void PruebaObtenerPreguntaDeSeguridadUsuarioVacioException() {
            try
            {
                usuario.correo = "";
                BDLogin.ObtenerPreguntaSeguridad(usuario);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (UsuarioVacioException err)
            {
            }
            catch (Exception e)
            {
                Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                           e.GetType(), e.Message)
                );


            }

        }



        #endregion


    }
}
