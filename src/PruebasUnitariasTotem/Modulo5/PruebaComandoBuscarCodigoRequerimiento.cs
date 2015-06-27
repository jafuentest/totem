using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    class PruebaComandoBuscarCodigoRequerimiento
    {
        private Comandos.Comando<String, List<String>> comando;
        

        /// <summary>
        /// Inicializacion de atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            comando = Comandos.Fabrica.FabricaComandos.CrearComandoBuscarCodigoRequerimiento();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEjecutar()
        {
            try
            {
                this.comando.Ejecutar("TOT_RF_2");
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
