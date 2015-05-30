using DatosTotem.Modulo7;
using DominioTotem;
using ExcepcionesTotem.Modulo7;
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
    public class PruebaLogicaUsuario
    {


        [Test]
        public void PruebaListaCargos() {

            Assert.IsTrue(LogicaUsuario.listarCargos().Count > 0);
            
        }
        [Test]
        public void PruebaObtenerdatos()
        {

            Assert.IsNotNull(LogicaUsuario.ObtenerDatos("albertods"));
        }
        [Test]
        public void PruebaModificarLogica()
        {
            Usuario usuario = new Usuario("albertods", "5563albert", "alberto08", "sdfgh", "Administrador", "rodarge33@hotmail.com", "mi perro", "dexter", "Desarrollador");
            Assert.IsTrue(LogicaUsuario.ModificarUsuario(usuario,"rodarge33@gmail.com",""));
        }
    }
}
