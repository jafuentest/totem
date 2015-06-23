using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Comandos;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo2;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;
using Dominio;
using System.Text.RegularExpressions;
using System.Web;

namespace Presentadores.Modulo2
{
    public class PresentadorAgregarCliente
    {
        private IContratoAgregarCliente vista;

        public PresentadorAgregarCliente(IContratoAgregarCliente laVista)
        {
            vista = laVista;
        }
        public void deshabilitarCombos()
        {
            vista.comboPais.Enabled = false;

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona un estado");

            vista.comboEstado.DataSource = options;
            vista.comboEstado.DataTextField = "value";
            vista.comboEstado.DataValueField = "key";
            vista.comboEstado.DataBind();

            options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una ciudad");

            vista.comboCiudad.DataSource = options;
            vista.comboCiudad.DataTextField = "value";
            vista.comboCiudad.DataValueField = "key";
            vista.comboCiudad.DataBind();

        }
        public void llenarComboPais()
        {
            Comando<bool, List<String>> comando =
                FabricaComandos.CrearComandoConsultarListaPaises();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona un pais");
            try
            {
                List<String> lista = comando.Ejecutar(true);
                foreach (String pais in lista)
                {
                    options.Add(pais, pais);
                }
            }
            catch (Exception ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    ex.Message +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            vista.comboPais.DataSource = options;
            vista.comboPais.DataTextField = "value";
            vista.comboPais.DataValueField = "key";
            vista.comboPais.DataBind();
            vista.comboPais.Enabled = true;
        }
        public void llenarComboEstadosXPais(String elPais)
        {
            Comando<String, List<String>> comando =
                FabricaComandos.CrearComandoConsultarEstadosPorPais();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona un estado");
            try
            {
                List<String> lista = comando.Ejecutar(elPais);
                foreach (String estado in lista)
                {
                    options.Add(estado, estado);
                }
            }
            catch (Exception ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    ex.Message +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            vista.comboEstado.DataSource = options;
            vista.comboEstado.DataTextField = "value";
            vista.comboEstado.DataValueField = "key";
            vista.comboEstado.DataBind();
            vista.comboEstado.Enabled = true;
        }
        public void llenarComboCiudadXEstado(String elEstado)
        {
            Comando<String, List<String>> comando =
                FabricaComandos.CrearComandoConsultarCiudadPorEstado();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una ciudad");
            try
            {
                List<String> lista = comando.Ejecutar(elEstado);
                foreach (String ciudad in lista)
                {
                    options.Add(ciudad, ciudad);
                }
            }
            catch (Exception ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    ex.Message +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            vista.comboCiudad.DataSource = options;
            vista.comboCiudad.DataTextField = "value";
            vista.comboCiudad.DataValueField = "key";
            vista.comboCiudad.DataBind();
            vista.comboCiudad.Enabled = true;
        }
        public void ObtenerVariablesURL()
        {
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
        public bool agregarCliente()
        {

            List<String> alfabeticos = new List<String>();
            List<String> alfanumericos = new List<String>();
            List<String> numericos = new List<String>();
            List<String> correo = new List<String>();

            alfabeticos.Add(vista.apellidoNatural);
            alfabeticos.Add(vista.nombreNatural);

            correo.Add(vista.correoCliente);
            alfanumericos.Add(vista.direccionCliente);

            numericos.Add(vista.cedulaNatural);
            numericos.Add(vista.codigoPostalCliente);
            numericos.Add(vista.codTelefono);
            numericos.Add(vista.telefonoCliente);
            Regex expresion = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            Regex expresion2 = new Regex(@"\d{1,5}\s\w.\s(\b\w*\b\s){1,2}\w*\.");
            Regex expresion3 = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");


            if (Validaciones.ValidarCamposVacios(alfabeticos) && Validaciones.ValidarCamposVacios(alfabeticos) &&
                Validaciones.ValidarCamposVacios(numericos) && Validaciones.ValidarCamposVacios(correo))
            {
                if (Validaciones.ValidarCaracteresAlfabeticos(alfabeticos))
                {
                    if (Validaciones.ValidarExpresionRegular(correo, expresion3))
                    {
                        if (Validaciones.ValidarExpresionRegular(numericos, expresion))
                        {
                            FabricaEntidades fabrica = new FabricaEntidades();

                            try
                            {
                                Entidad laDireccion = fabrica.ObtenerDireccion(vista.comboPais.SelectedValue,
                                    vista.comboEstado.SelectedValue, vista.comboCiudad.SelectedValue,
                                    vista.direccionCliente, vista.codigoPostalCliente);
                                Entidad elTelefono = fabrica.ObtenerTelefono(vista.codTelefono, vista.telefonoCliente);
                                Entidad elCliente = fabrica.ObtenerClienteNatural(vista.nombreNatural,
                                    vista.apellidoNatural, vista.correoCliente, laDireccion, elTelefono,
                                    vista.cedulaNatural);
                                Comando<Entidad, bool> comando = FabricaComandos.CrearComandoAgregarClienteNatural();
                                if (comando.Ejecutar(elCliente))
                                    HttpContext.Current.Response.Redirect(RecursoInterfazM2.ListarClientes + 
                                        RecursoInterfazM2.Codigo_Exito_Agregar);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                                vista.alerta = RecursoInterfazM2.Alerta_Html +
                                    ex.Message +
                                    RecursoInterfazM2.Alerta_Html_Final;
                                return false;
                            }
                        }
                        else
                        {
                            vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                            vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                            vista.alerta = RecursoInterfazM2.Alerta_Html +
                                RecursoInterfazM2.Alerta_Error_Numericos +
                            RecursoInterfazM2.Alerta_Html_Final;
                            return false;
                        }
                    }
                    else
                    {
                        vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                        vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                        vista.alerta = RecursoInterfazM2.Alerta_Html +
                            RecursoInterfazM2.Alerta_Error_Correo +
                        RecursoInterfazM2.Alerta_Html_Final;
                        return false;
                    }
                }
                else
                {
                    vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                    vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                    vista.alerta = RecursoInterfazM2.Alerta_Html +
                        RecursoInterfazM2.Alerta_Error_Alfabeticos +
                    RecursoInterfazM2.Alerta_Html_Final;
                    return false;
                }
            }
            else
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursoInterfazM2.Alerta_Error_CamposVacios +
                RecursoInterfazM2.Alerta_Html_Final;
                return false;
            }
        }
    }
}
