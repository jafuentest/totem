using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo4;

namespace PruebasUnitariasTotem.Modulo4
{
     [TestFixture]
    class PruebaLogicaProyecto
    {

        private Proyecto elProyecto;
        private ClienteJuridico elClienteJuridico;
        private ClienteNatural elClienteNatural;
        private Lugar elLugar;

        [SetUp]
        public void init()
        {

            //elLugar = new Lugar(1, "Venezuela");
            elProyecto = new Proyecto("TES", "Test", true, "Test descripcion", "Bs", 1000000);

            //elClienteJuridico.Jur_Id = "J-231425-5";
            //elClienteJuridico.Jur_Nombre = "Venetur";

            //int fkLugar = 1;

            //Assert.IsTrue(baseDeDatosCliente.AgregarClienteJuridico(cliente, fkLugar));

        }
        [TearDown]
        public void clean()
        {
            elProyecto = null;
        }

        [Test]
        public void PruebaCrearProyecto()
        {

            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto));
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }

        [Test]
        public void PruebaCrearProyectoClienteJuridico()
        {

            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto,elClienteJuridico));
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }

        public void PruebaModificarProyecto()
        {
            String codigoAnterior = elProyecto.Codigo;
            elProyecto.Codigo = "TWI";
            elProyecto.Nombre = "Twitter";
            elProyecto.Descripcion = "Red social para compartir mensajes de hasta 140 caracteres";
            elProyecto.Estado = false;
            elProyecto.Costo = 2000000;
            elProyecto.Moneda = "$";
            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.ModificarProyecto(elProyecto, codigoAnterior));
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }
     
    }
}
