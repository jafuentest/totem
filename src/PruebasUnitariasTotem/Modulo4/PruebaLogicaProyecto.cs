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

            elProyecto = new Proyecto("TES", "Test", true, "Test descripcion", "Bs", 1000000);
            elClienteJuridico = new ClienteJuridico();
            elClienteNatural = new ClienteNatural();
            elClienteJuridico.Jur_Id = "2";
            elClienteNatural.Nat_Id = "1";
      
        }
        [TearDown]
        public void clean()
        {
            elProyecto = null;
        }

        #region Crear 
        [Test]
        public void PruebaCrearProyecto()
        {

            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto));
                //DatosTotem.Modulo4.BDProyecto.EliminarProyecto("TES");
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }

        [Test]
        public void PruebaCrearProyectoClienteJuridico()
        {
            elClienteJuridico.Jur_Id="2";

            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto, elClienteJuridico));
                DatosTotem.Modulo4.BDProyecto.EliminarProyecto("TES");
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }

        [Test]
        public void PruebaCrearProyectoClienteNatural()
        {

            elClienteNatural.Nat_Id="1";
            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto, elClienteJuridico));
                DatosTotem.Modulo4.BDProyecto.EliminarProyecto("TES");
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }
        #endregion

        [Test]
        public void PruebaModificarProyecto()
        {
            String codigoAnterior = elProyecto.Codigo;
            //se crea el proyecto
            LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto);
            elProyecto.Codigo = "TWI";
            elProyecto.Nombre = "Twitter";
            elProyecto.Descripcion = "Red social para compartir mensajes de hasta 140 caracteres";
            elProyecto.Estado = false;
            elProyecto.Costo = 2000000;
            elProyecto.Moneda = "$";
            try
            {
                //se modifica
                Assert.IsTrue(LogicaNegociosTotem.Modulo4.LogicaProyecto.ModificarProyecto(elProyecto, codigoAnterior));

                DatosTotem.Modulo4.BDProyecto.EliminarProyecto("TWI");
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {

            }
        }


        [Test]
        public void PruebaConsultarProyecto()
        {

            LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto);
            Proyecto elProyectoConsultado = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto("TES");

            Assert.AreEqual(elProyecto.Codigo, elProyectoConsultado.Codigo);
            Assert.AreEqual(elProyecto.Nombre, elProyectoConsultado.Nombre);
            Assert.AreEqual(elProyecto.Estado, elProyectoConsultado.Estado);
            Assert.AreEqual(elProyecto.Descripcion, elProyectoConsultado.Descripcion);
            Assert.AreEqual(elProyecto.Costo, elProyectoConsultado.Costo);
            Assert.AreEqual(elProyecto.Moneda, elProyectoConsultado.Moneda);

            
            DatosTotem.Modulo4.BDProyecto.EliminarProyecto("TES");

        }

        [Test]
        public void PruebaConsultarProyectosUsuario()
        {

            Assert.IsNotNull(LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarTodosLosProyectos("albertods"));

        }
    }
}
