using DatosTotem.Modulo7;
using DominioTotem;
using LogicaNegociosTotem.Modulo7;
using NUnit.Framework;
using NUnit.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitariasTotem.Modulo7
{
    [TestFixture]
    class PruebaBDUsuario
    {
        private BDUsuario baseDeDatosUsuario;
        [SetUp]
        public void Init()
        {
            baseDeDatosUsuario = new BDUsuario();
        }
        [Test]
        public void PruebaRegistrarUsuario()
        {
            Usuario usuario = new Usuario("Argenis03", "dfsfdf3232343", "Argenis", "Rodriguez", "Administrador", "rodarge32@gmail.com", "Como se llama mi perro", "slipy", "Desarrollador");
            Assert.IsTrue(baseDeDatosUsuario.RegitrarUsuario(usuario));
        }
        [Test]
        public void PruebaUsernameUnico()
        {
            Assert.IsTrue(baseDeDatosUsuario.usernameUnico("albertodfds"));

        }
        [Test]
        public void PruebaCorreoUnico()
        {
            Assert.IsTrue(baseDeDatosUsuario.correoUnico("rodarge34@gmail.com"));

        }
        [Test]
        public void PruebaDatosUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.username = "albertods";
            Assert.IsNotNull(baseDeDatosUsuario.DatosUsuario(usuario));
        }
        [Test]
        public void PruebaModificarUsuario()
        {
            Usuario usuario = new Usuario("albertods", "5563albert", "alberto07", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");

            Assert.IsTrue(baseDeDatosUsuario.ModificarUsuario(usuario));
        }
        [Test]
        public void PruebaListaUsuario()
        {
            Assert.IsTrue(baseDeDatosUsuario.ObtenerListaUsuario().Count > 0);
        }
         [Test]
        public void PruebaObtenercargos()
        {
            Usuario usuario = new Usuario("Argenis04", "dfsfdf3232343", "Argenis", "Rodriguez", "Administrador", "rodarge32@gmail.com", "Como se llama mi perro", "slipy", "Desarrrollador");
            Assert.AreEqual("Desarrollador",baseDeDatosUsuario.ObtenerCargo("Argenis04"));
        }

        [Test]
         public void PruebaConsultarPregunta()
         {
             Usuario usuario = new Usuario("Argenis05", "dfsfdf3232343", "Argenis", "Rodriguez", "Administrador", "rodarge32@gmail.com", "Como se llama mi perro", "Fox", "Desarrrollador");
             Assert.IsTrue(baseDeDatosUsuario.ConsultaPregunta("Argenis05", "Como se llama mi perro","Fox"));  
         }
        [Test]
        public void PruebaConsultarClave()
        {
            Assert.IsTrue(baseDeDatosUsuario.ConsultarClaveUsuario("albertods") == "");
        }
    }
}
