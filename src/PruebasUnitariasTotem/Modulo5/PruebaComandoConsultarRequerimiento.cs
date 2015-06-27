using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    class PruebaComandoConsultarRequerimiento
    {
        private Comandos.Comando<Dominio.Entidad, Dominio.Entidad> comando;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;
        
        /// <summary>
        /// Inicializacion de atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            comando = Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimiento();
            Dominio.Fabrica.FabricaEntidades fabrica = new Dominio.Fabrica.FabricaEntidades();
            this.requerimiento = fabrica.ObtenerRequerimiento() as Dominio.Entidades.Modulo5.Requerimiento;
            this.requerimiento.Codigo = "TOT_RF_2";
        
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PruebaEjecutar()
        {
            try
            {
                this.comando.Ejecutar(this.requerimiento);
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
