using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using NUnit.Framework;
using Dominio.Fabrica;
using Dominio;

namespace PruebasUnitariasTotem.Modulo7
{
    /// <summary>
    /// Prueba Unitaria que trabaja sobre la entidad Usuario
    /// </summary>
    [TestFixture]
    public class PruebaUsuario
    {
        //Los diferentes usuarios sobre los que probaremos.
        private Usuario usuarioVacio;
        private Usuario usuarioCompleto;
        private Usuario usuarioSinID;
        private Usuario usuarioDatosBasicos;
        
        /// <summary>
        /// Inicializa las clases que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            usuarioVacio = new Usuario();
            usuarioCompleto = new Usuario(1, "username", "clave", "nombre", "apellido", "rol", "correo", "pregunta", 
                "respuesta", "cargo");
            usuarioSinID = new Usuario("username", "clave", "nombre", "apellido", "rol", "correo", "pregunta", "respuesta", 
                "cargo");
            usuarioDatosBasicos = new Usuario ("username", "nombre", "apellido", "cargo");
        }

        /// <summary>
        /// Se prueba que los diferentes Usuarios no apunten a vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(usuarioVacio);
            Assert.IsNotNull(usuarioCompleto);
            Assert.IsNotNull(usuarioSinID);
            Assert.IsNotNull(usuarioDatosBasicos);

        }

        /// <summary>
        /// Se prueba que los diferentes actores tengan los valores correspondientes
        /// </summary>
        [Test]
        public void PruebaValores()
        {
            //Verificamos todos los valores del Usuario Completo
            Assert.AreEqual(1,usuarioCompleto.Id);
            Assert.AreEqual("username", usuarioCompleto.Username);
            Assert.AreEqual("clave", usuarioCompleto.Clave);
            Assert.AreEqual("nombre", usuarioCompleto.Nombre);
            Assert.AreEqual("apellido", usuarioCompleto.Apellido);
            Assert.AreEqual("rol", usuarioCompleto.Rol);
            Assert.AreEqual("correo", usuarioCompleto.Correo);
            Assert.AreEqual("pregunta", usuarioCompleto.PreguntaSeguridad);
            Assert.AreEqual("respuesta", usuarioCompleto.RespuestaSeguridad);
            Assert.AreEqual("cargo", usuarioCompleto.Cargo);

            //Verificamos todos los valores del Usuario sin ID
            Assert.AreEqual("username", usuarioSinID.Username);
            Assert.AreEqual("clave", usuarioSinID.Clave);
            Assert.AreEqual("nombre", usuarioSinID.Nombre);
            Assert.AreEqual("apellido", usuarioSinID.Apellido);
            Assert.AreEqual("rol", usuarioSinID.Rol);
            Assert.AreEqual("correo", usuarioSinID.Correo);
            Assert.AreEqual("pregunta", usuarioSinID.PreguntaSeguridad);
            Assert.AreEqual("respuesta", usuarioSinID.RespuestaSeguridad);
            Assert.AreEqual("cargo", usuarioSinID.Cargo);

            //Verificamos todos los valores del usuario con los Datos Basicos
            Assert.AreEqual("username", usuarioDatosBasicos.Username);
            Assert.AreEqual("nombre", usuarioDatosBasicos.Nombre);
            Assert.AreEqual("apellido", usuarioDatosBasicos.Apellido);
            Assert.AreEqual("cargo", usuarioDatosBasicos.Cargo);
        }

        /// <summary>
        /// Se prueba los metodos correspondientes para instanciar al usuario en la fabrica
        /// </summary>
        [Test]
        public void PruebaFabricaUsuario()
        {
            //Instanciamos la fabrica
            FabricaEntidades fabrica = new FabricaEntidades();

            //Obtenemos cada uno de los valores y los casteamos
            Entidad usuarioFabricaVacio = fabrica.ObtenerUsuario();
            Entidad usuarioFabricaDatosBasicos = fabrica.ObtenerUsuario("username", "nombre", "apellido", "cargo");
            Entidad usuarioFabricaSinID = fabrica.ObtenerUsuario("username", "clave", "nombre", "apellido", "rol",
                "correo", "pregunta", "respuesta","cargo");
            usuarioFabricaVacio = usuarioFabricaVacio as Usuario;
            usuarioFabricaDatosBasicos = usuarioFabricaDatosBasicos as Usuario;
            usuarioFabricaSinID = usuarioFabricaSinID as Usuario;

            //Probamos
            Assert.IsNotNull(usuarioFabricaVacio);
            Assert.IsNotNull(usuarioFabricaDatosBasicos);
            Assert.IsNotNull(usuarioFabricaSinID);

        }

        /// <summary>
        /// Se deja en vacio los atributos creados para ser limpiados por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            usuarioVacio = null;
            usuarioSinID = null;
            usuarioDatosBasicos = null;
            usuarioCompleto = null;
        }
    }
}
