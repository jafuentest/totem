using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using System.Web;
using Dominio.Fabrica;
using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Presentadores.Modulo2
{
    public class PresentadorModificarContacto
    {
        private IContratoModificarContacto vista;
        public PresentadorModificarContacto(IContratoModificarContacto laVista)
        {
            vista = laVista;
        }
        public void llenarComboCargos()
        {
            Comando<bool, List<String>> comando = FabricaComandos.CrearComandoConsultarListaCargos();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona un cargo");
            try
            {
                List<String> resultado = comando.Ejecutar(true);
                foreach (String cargo in resultado)
                {
                    options.Add(cargo, cargo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            vista.comboCargo.DataSource = options;
            vista.comboCargo.DataTextField = "value";
            vista.comboCargo.DataValueField = "key";
            vista.comboCargo.DataBind();
            vista.comboCargo.Enabled = true;
        }
        public void ObtenerVariablesURL()
        {
            String detalleContacto = HttpContext.Current.Request.QueryString["id"];
            String success = HttpContext.Current.Request.QueryString["success"];
            if (detalleContacto != null && !(HttpContext.Current.Handler as Page).IsPostBack)
            {
                cargarDatos(detalleContacto);
            }
            String error = HttpContext.Current.Request.QueryString["error"];
            if (error != null && error.Equals("input_malicioso"))
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursoInterfazM2.Alerta_Html_Final;
            }


        }
        public void cargarDatos(String idContacto)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();

            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarDatosContactoID();
            try
            {
                Entidad entidad = laFabrica.ObtenerContacto();
                entidad.Id = int.Parse(idContacto);
                Contacto elContacto = (Contacto)elComando.Ejecutar(entidad);

                vista.cedulaContacto = elContacto.ConCedula;
                vista.nombreContacto = elContacto.Con_Nombre;
                vista.comboCargo.SelectedValue = elContacto.ConCargo;
                vista.apellidoContacto = elContacto.Con_Apellido;
                vista.telefonoContacto = elContacto.Con_Telefono.Numero;
                vista.codTelefono = elContacto.Con_Telefono.Codigo;
            }
            catch (NullReferenceException ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursoInterfazM2.Alerta_Error_NullPointer +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            catch (Exception ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    ex.Message +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
        }
        public void modificarContacto()
        {
            String detalleContacto = HttpContext.Current.Request.QueryString["id"];
            String paginaRedirect = HttpContext.Current.Request.QueryString["pag"];
            List<String> alfabeticos = new List<String>();
            List<String> numericos = new List<String>();
            Regex expresion = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
           
            alfabeticos.Add(vista.apellidoContacto);
            alfabeticos.Add(vista.nombreContacto);
            alfabeticos.Add(vista.comboCargo.SelectedValue);

            numericos.Add(vista.cedulaContacto);
            numericos.Add(vista.telefonoContacto);
            numericos.Add(vista.codTelefono);

            if (Validaciones.ValidarCamposVacios(alfabeticos) && Validaciones.ValidarCamposVacios(numericos))
            {
                if (Validaciones.ValidarCaracteresAlfabeticos(alfabeticos))
                {
                    if (Validaciones.ValidarExpresionRegular(numericos, expresion))
                    {
                        FabricaEntidades fabrica = new FabricaEntidades();

                        try
                        {
                            Entidad telefono = fabrica.ObtenerTelefono(vista.codTelefono, vista.telefonoContacto);
                            Entidad elContacto = fabrica.ObtenerContacto(vista.cedulaContacto, vista.nombreContacto,
                                vista.apellidoContacto, vista.comboCargo.SelectedValue, telefono);
                            elContacto.Id = int.Parse(detalleContacto);

                            Comando<Entidad, bool> elComando = FabricaComandos.CrearComandoModificarContacto();
                            if (elComando.Ejecutar(elContacto))
                                HttpContext.Current.Response.Redirect(paginaRedirect + 
                                    RecursoInterfazM2.Codigo_Exito_ModficiarContacto);
                        }
                        catch(Exception ex)
                        {
                            vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                            vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                            vista.alerta = RecursoInterfazM2.Alerta_Html +
                                ex.Message +
                                RecursoInterfazM2.Alerta_Html_Final;
                        }
                    }
                    else
                    {
                        vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                        vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                        vista.alerta = RecursoInterfazM2.Alerta_Html +
                            RecursoInterfazM2.Alerta_Error_Numericos +
                        RecursoInterfazM2.Alerta_Html_Final;
                    }
                }
                else
                {
                    vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                    vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                    vista.alerta = RecursoInterfazM2.Alerta_Html +
                        RecursoInterfazM2.Alerta_Error_Alfabeticos +
                    RecursoInterfazM2.Alerta_Html_Final;
                }
            }
            else
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursoInterfazM2.Alerta_Error_CamposVacios +
                RecursoInterfazM2.Alerta_Html_Final;

            }
        }
    }
}
