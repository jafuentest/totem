using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTotem.Modulo1;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using LogicaNegociosTotem.Modulo1;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo1
{
    [TestFixture]
    class PruebaLogicaLogin
    {
        [SetUp]
        public void Init() {
        }

        [Test]
        public void PruebaIntentosFallidos() {
            Usuario user = new Usuario();
            user.username = "santiagop85";
            user.clave = "asdasd";
            user.CalcularHash();
        
            for (int x = 0; x < 3;x++ )
            {
                try
                {
                    LogicaNegociosTotem.Modulo1.LogicaLogin.Login(user.username, user.clave);
                }
                catch (ExcepcionesTotem.Modulo1.IntentosFallidosException)
                {

                }
                catch (ExcepcionesTotem.Modulo1.LoginErradoException) { 
                
                }

            }
        }

        [Test]
        public void PruebaUsuarioVacio(){
            Usuario user = new Usuario();
            try
            {
                LogicaNegociosTotem.Modulo1.LogicaLogin.Login(user.username, user.clave);
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException) { 
            
            }
        }

        [Test]
        public void PruebaBDconexionFallida() {
            Usuario user = new Usuario();
            user.username = "santiagop85";
            user.clave = "minerva";
            user.CalcularHash();
            try
            {
                LogicaNegociosTotem.Modulo1.LogicaLogin.Login(user.username, user.clave);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {

            }

        
        }
        
        [Test]
        public void PruebaLogin()
        {
            Usuario user = new Usuario();
            user.username = "santiagop85";
            user.clave = "santi1890a";
            user.CalcularHash();
            try
            {
                LogicaNegociosTotem.Modulo1.LogicaLogin.Login(user.username, user.clave);
            }
            catch (Exception e) {
                Assert.Fail("No se tuvo que haber disparado ninguna exception");
            }


        }








    }
}
