using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ExcepcionesTotem.Modulo4;
using DominioTotem;

namespace PruebasUnitariasTotem.Modulo4
{
    [TestFixture]
    class PruebaExcepciones
    {
        [Test]
        public void PruebaCodigoRepetidoException()
        {
            try
            {
                Proyecto elProyecto = new Proyecto("TES", "Test", true, "Test descripcion", "Bs", 1000000);
                LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto);;
                LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(elProyecto);
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (CodigoRepetidoException codigoRepetidoException)
            {
                Assert.AreEqual("El codigo de proyecto ya existe, por favor elija otro.", codigoRepetidoException.Mensaje);
            }

        }

        [Test]
        public void PruebaInvolucradosInexistentesException()
        { 
            try
            {
                LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarTodosLosProyectos("UsuarioP");
                Assert.Fail("Una excepcion se ha debido de lanzar");
            }
            catch (InvolucradosInexistentesException involucradosInexistentesException)
            {
                Assert.AreEqual("No hay proyectos asociados al usuario.", involucradosInexistentesException.Mensaje);
            }

        }
    }
}
