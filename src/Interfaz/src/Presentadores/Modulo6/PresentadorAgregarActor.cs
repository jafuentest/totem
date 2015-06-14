using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6;
using Presentadores;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace Presentadores.Modulo6
{
    public class PresentadorAgregarActor
    {
        private IContratoAgregarActor vista;
         
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
            //Mi lista de datos a validar
            List<string> listaVacios = new List<string>();
            listaVacios.Add(this.vista.nombreActor);
            listaVacios.Add(this.vista.descActor);

            Validaciones.ValidarCamposVacios(listaVacios);
            

        }
    }
}
