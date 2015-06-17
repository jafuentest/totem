using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6;
using Presentadores;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Entidades.Modulo6;
using Dominio.Fabrica;
using Dominio;
using Comandos.Comandos;
using Comandos.Fabrica; 

namespace Presentadores.Modulo6
{
    public class PresentadorAgregarActor
    {
        private IContratoAgregarActor vista;
        private Actor elActor; 
 
        public PresentadorAgregarActor(IContratoAgregarActor vista) 
        {
            this.vista = vista; 
        }

        /// <summary>
        /// Método que se encarga de la lógica 
        /// al generarse el evento para agregar Actor
        /// </summary>
        public void AgregarActor_Click() 
        {
            bool agrego = false; 
            Entidad entidad = FabricaEntidades.ObtenerActor();
            
            elActor = entidad as Actor;
            elActor.NombreActor = vista.nombreActor;
            elActor.DescripcionActor = vista.descActor;
            //elActor.ProyectoAsociado.Id = 1; 

            try
            {

                Comandos.Comando<Entidad, bool> comandoAgregarActor =
                FabricaComandos.CrearComandoAgregarActor();

                agrego = comandoAgregarActor.Ejecutar(elActor);
            }
            catch (HttpRequestValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                //Falta implementar excepciones
                throw e;
            }
            
            

        }
    }
}
