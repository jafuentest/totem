using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo4;
using System.Web.UI;
using System.Web;



namespace Presentadores.Modulo4
{
    class PresentadorAgregarProyecto
    {
        private IContratoAgregarProyecto vista;
        private Dominio.Entidades.Modulo7.Usuario usuario;

        /// <summary>
        public PresentadorAgregarProyecto(IContratoAgregarProyecto laVista)
        {
            this.vista = laVista;

        }

        public void ObtenerUsuarioLogeado()
        {
            usuario =
                HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
            vista.codigoProyecto = "PROY";
        }

        /*public void ObtenerVariablesURL()
         {
             string error = HttpContext.Current.Request.QueryString["error"];
             if (error != null && error.Equals("input_malicioso"))
             {
                 vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                 vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                 vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                     RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                     RecursosPresentadorModulo5.Alerta_Html_Final;
             }

         }*/

        public List<String> ListaDeCampos()
        {
            List<String> campos = new List<string>();
            campos.Add(vista.codigoProyecto);
            campos.Add(vista.nombreProyecto);
            campos.Add(vista.descripcionProyecto);
            campos.Add(vista.monedaProyecto);

            return campos;
        }

        public bool ValidarCampos()
        {
            List<String> campos = ListaDeCampos();
            if (Validaciones.ValidarCamposVacios(campos))
            {
                return true;
            }

            ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                new ExcepcionesTotem.Modulo4.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo4.CamposInvalidosException()));

            throw new ExcepcionesTotem.Modulo4.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo4.CamposInvalidosException());
        }

        public void AgregaProyecto()
        {
            try
            {
                if (ValidarCampos())
                {
                    Comandos.Comando<Dominio.Entidad, Boolean> comandoAgregar;

                    //Dominio.Entidad proyecto;
                    //Dominio.Fabrica.FabricaEntidades fabricaEntidades = new
                    //Dominio.Fabrica.FabricaEntidades();

                    Dominio.Entidades.Modulo4.Proyecto proyecto = 
                        (Dominio.Entidades.Modulo4.Proyecto)
                        Dominio.Fabrica.FabricaEntidades.ObtenerProyecto(vista.codigoProyecto,
                        vista.nombreProyecto, vista.descripcionProyecto, vista.monedaProyecto);

                    comandoAgregar = Comandos.Fabrica.FabricaComandos.CrearComandoAgregarProyecto();
                    if (comandoAgregar.Ejecutar(proyecto))
                    {
                        HttpContext.Current.Response.Redirect(
                            RecursosPresentadorModulo4.Ventana_Listar_Proyecto +
                            RecursosPresentadorModulo4.Codigo_Exito_Agregar);
                    }

                    throw new ExcepcionesTotem.Modulo4.ProyectoNoAgregadoException(
                        RecursosPresentadorModulo4.Codigo_Error_Proyecto_No_Agregado,
                        RecursosPresentadorModulo4.Mensaje_Error_Proyecto_Errado,
                        new ExcepcionesTotem.Modulo4.ProyectoNoAgregadoException());

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}