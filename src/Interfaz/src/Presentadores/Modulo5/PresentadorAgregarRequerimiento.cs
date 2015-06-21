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

        /// <summary>
        /// Metodo que agrega un requerimiento en la base de datos
        /// </summary>
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
                    if (comandoAgregar.Ejecutar(requerimiento))
                    {
                        HttpContext.Current.Response.Redirect(
                            RecursosPresentadorModulo5.Ventana_Listar_Requerimiento +
                            RecursosPresentadorModulo5.Codigo_Exito);
                    }

                    throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                        RecursosPresentadorModulo5.Codigo_Error_Requerimiento_Errado,
                        RecursosPresentadorModulo5.Mensaje_Error_Requerimiento_Errado,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                }
            }

            #region Capturar Excepcion
            catch (ExcepcionesTotem.Modulo5.CamposInvalidosException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_BaseDatos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Invalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (Exception e)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            #endregion
        }

    }
}
