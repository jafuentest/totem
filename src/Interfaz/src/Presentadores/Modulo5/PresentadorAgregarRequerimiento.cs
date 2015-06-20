using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo5;
using System.Web.UI;
using System.Web;

namespace Presentadores.Modulo5
{
    public class PresentadorAgregarRequerimiento
    {
        private IContratoAgregarRequerimiento vista;
        private Dominio.Entidades.Modulo7.Usuario usuario;

        public PresentadorAgregarRequerimiento(IContratoAgregarRequerimiento vista)
        {
            this.vista = vista;
        }

        public void ObtenerUsuarioLogeado()
        {
            usuario = 
                HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
           
        }

        public void AgregarRequerimiento()
        {
            try
            {
                if (!vista.idRequerimiento.Equals("") && !vista.prioridad.Equals("") &&
                    !vista.requerimiento.Equals("") && vista.funcional != null &&
                    vista.finalizado != null)
                {

                    Comandos.Comando<Dominio.Entidad, Boolean> comandoAgregar;
                    Dominio.Entidad requerimiento;
                    requerimiento = Dominio.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado);

                    comandoAgregar = Comandos.Fabrica.FabricaComandos.CrearComandoAgregarRequerimiento();
                    comandoAgregar.Ejecutar(requerimiento);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
