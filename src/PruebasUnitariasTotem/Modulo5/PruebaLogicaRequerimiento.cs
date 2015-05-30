using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo5;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaLogicaRequerimiento
    {
        private Proyecto elProyecto;
        private Requerimiento elRequerimiento;

        [SetUp]
        public void init()
        {

            
            elRequerimiento = new Requerimiento("test","test","test","test","test");
                        

        }
        [TearDown]
        public void clean()
        {
            elRequerimiento = null;
        }

        #region Crear
       /* [Test]
        public void PruebaCrearRequeriento()
        {

            try
            {
                Assert.IsTrue(LogicaNegociosTotem.Modulo5.LogicaRequerimiento.CrearRequerimiento(elRequerimiento));
               
            }
            catch (Exception e)
            {
                
            }
        }
        */
        #endregion

        #region Consultar

        /*  [Test]
        public void PruebaConsultarRequerimiento()
        {

            Assert.IsTrue(LogicaNegociosTotem.Modulo5.LogicaRequerimiento.ConsultarRequerimiento(1).Count > 0);
            

        }
        */
        #endregion



    }
}
