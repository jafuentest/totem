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

        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="vista">Contrato que va a acceder el presentador</param>
        public PresentadorAgregarRequerimiento(IContratoAgregarRequerimiento vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que obtiene la sesion de usuario actual
        /// </summary>
        public void ObtenerUsuarioLogeado()
        {
            usuario = 
                HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
            vista.idRequerimiento = "TOT_213";
        }

        /// <summary>
        /// Metodo que agrega todos los campos en una lista de String
        /// </summary>
        /// <returns>Lista de String con todos los campos</returns>
        public List<String> ListaDeCampos()
        {
            List<String> campos = new List<string>();
            campos.Add(vista.idRequerimiento);
            campos.Add(vista.prioridad);
            campos.Add(vista.requerimiento);
            campos.Add(vista.funcional);
            campos.Add(vista.finalizado);
            return campos;
        }

        /// <summary>
        /// Metodo que valida todos los campos de la vista
        /// </summary>
        /// <returns>true si todos los campos son validos</returns>
        public bool ValidarCampos()
        {
            List<String> campos = ListaDeCampos();
            if (Validaciones.ValidarCamposVacios(campos))
            {
                return true;
            }

            ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException()));

            throw new ExcepcionesTotem.Modulo5.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException());
        }

        public void AgregarRequerimiento()
        {
            try
            {
                if (ValidarCampos())
                {
                    HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
                    //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
                    Comandos.Comando<Dominio.Entidad, Boolean> comandoAgregar;
                    Dominio.Entidad requerimiento;
                    requerimiento = Dominio.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado, "TOT"); //Cableado
                    /*Dominio.Entidad requerimiento;
                    requerimiento = Dominio.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado,pcookie.Values["projectCode"].ToString());
                     Para Cuando funcione el cookie del proyecto*/

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
