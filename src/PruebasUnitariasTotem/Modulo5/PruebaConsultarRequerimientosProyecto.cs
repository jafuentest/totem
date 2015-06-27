using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{

    [TestFixture]
    class PruebaConsultarRequerimientosProyecto
    {
        private Comandos.Comando<String, List<Dominio.Entidad>> comando;


        /// <summary>
        /// Inicializacion de atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            comando = Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimientosProyecto();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEjecutar()
        {
            try
            {
                this.comando.Ejecutar("1");
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException err)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {

            }

        }

    }
}
