using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{

    [TestFixture]
    class PruebaComandoModificarRequerimiento
    {
        private Comandos.Comando<Dominio.Entidad, Boolean> comando;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;

        /// <summary>
        /// Inicializacion de atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            comando = Comandos.Fabrica.FabricaComandos.CrearComandoModificarRequerimiento();
            Dominio.Fabrica.FabricaEntidades fabrica = new Dominio.Fabrica.FabricaEntidades();
            this.requerimiento = fabrica.ObtenerRequerimiento() as Dominio.Entidades.Modulo5.Requerimiento;
            this.requerimiento.Codigo = "TOT_RF_2";
            this.requerimiento.Descripcion = "Prueba";
            this.requerimiento.Tipo = "Funcional";
            this.requerimiento.Prioridad = "Alta";
            this.requerimiento.CodigoProyecto = "1";
            this.requerimiento.Estatus = "Finalizado";
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
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException )
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {

            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoNoModificadoException) { 
            
            }




        }


    }
}
