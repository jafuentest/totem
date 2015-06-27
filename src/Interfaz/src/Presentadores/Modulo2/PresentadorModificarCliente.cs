using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Comandos;
using Comandos.Fabrica;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;


namespace Presentadores.Modulo2
{
    /// <summary>
    /// Presentador para la ventana Modificar Cliente
    /// </summary>
    public class PresentadorModificarCliente
    {
        private IContratoModificarCliente vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorModificarCliente(IContratoModificarCliente laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// metodo para cargar los datos del cliente
        /// </summary>
        /// <param name="idCliente">id del cliente</param>
        public void cargarCliente(String idCliente)
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidadCliente = fabrica.ObtenerClienteNatural();
            try
            {
                entidadCliente.Id = int.Parse(idCliente);

                Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarXIDClienteNatural();

                ClienteNatural elCliente = (ClienteNatural)comando.Ejecutar(entidadCliente);

                vista.cedulaCliente = elCliente.Nat_Cedula;
                vista.nombreCliente = elCliente.Nat_Nombre;
                vista.apellidoCliente = elCliente.Nat_Apellido;
                vista.codTelefono = elCliente.Nat_Telefono.Codigo;
                vista.telefonoCliente = elCliente.Nat_Telefono.Numero;
                vista.correoCliente = elCliente.Nat_Correo;
                vista.comboPais.SelectedValue = elCliente.Nat_Direccion.ElPais;
                llenarComboEstadosXPais(elCliente.Nat_Direccion.ElPais);
                vista.comboEstado.SelectedValue = elCliente.Nat_Direccion.ElEstado;
                llenarComboCiudadXEstado(elCliente.Nat_Direccion.ElEstado);
                vista.comboCiudad.SelectedValue = elCliente.Nat_Direccion.LaCiudad;
                vista.direccionCliente = elCliente.Nat_Direccion.LaDireccion;
                vista.codigoPostalCliente = elCliente.Nat_Direccion.CodigoPostal;
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
        /// <summary>
        /// metodo para llenar el combo de paises
        /// </summary>
        public void llenarComboPais()
        {
            Comando<bool, List<String>> comando = FabricaComandos.CrearComandoConsultarListaPaises();

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
        /// <summary>
        /// metodo para llenar el combo de estados 
        /// </summary>
        /// <param name="elPais">pais para filtrar los estados</param>
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

            options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una ciudad");

            vista.comboCiudad.DataSource = options;
            vista.comboCiudad.DataTextField = "value";
            vista.comboCiudad.DataValueField = "key";
            vista.comboCiudad.DataBind();

            vista.direccionCliente = "";
            vista.codigoPostalCliente = "";
        }
        /// <summary>
        /// metodo para llenar el combo de ciudades
        /// </summary>
        /// <param name="elEstado">estado para filtrar las ciudades</param>
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

            vista.direccionCliente = "";
            vista.codigoPostalCliente = "";

        }
        /// <summary>
        /// metodo para consultar las variables del url
        /// </summary>
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
            String edicionCliente = HttpContext.Current.Request.QueryString["id"];
            if (edicionCliente != null && !(HttpContext.Current.Handler as Page).IsPostBack)
                cargarCliente(edicionCliente);
        }
        /// <summary>
        /// metodo para modificar el cliente
        /// </summary>
        /// <param name="elID">id del cliente a modificar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public bool modificarCliente(String elID)
        {
            List<String> alfabeticos = new List<String>();
            List<String> alfanumericos = new List<String>();
            List<String> numericos = new List<String>();
            List<String> correo = new List<String>();

            alfabeticos.Add(vista.nombreCliente);
            alfabeticos.Add(vista.apellidoCliente);

            correo.Add(vista.correoCliente);
            alfanumericos.Add(vista.direccionCliente);

            numericos.Add(vista.cedulaCliente);
            numericos.Add(vista.codigoPostalCliente);
            numericos.Add(vista.codTelefono);
            numericos.Add(vista.telefonoCliente);
            Regex expresion = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            Regex expresion3 = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (Validaciones.ValidarCamposVacios(alfabeticos) && Validaciones.ValidarCamposVacios(alfabeticos) &&
                Validaciones.ValidarCamposVacios(numericos) && Validaciones.ValidarCamposVacios(correo))
            {
                if (Validaciones.ValidarCaracteresAlfabeticos(alfabeticos))
                {
                    if (Validaciones.ValidarExpresionRegular(numericos, expresion))
                    {
                        if (Validaciones.ValidarExpresionRegular(correo, expresion3))
                        {
                            FabricaEntidades fabrica = new FabricaEntidades();

                            try
                            {
                                Entidad laDireccion = fabrica.ObtenerDireccion(vista.comboPais.SelectedValue,
                                    vista.comboEstado.SelectedValue, vista.comboCiudad.SelectedValue,
                                    vista.direccionCliente, vista.codigoPostalCliente);
                                Entidad elTelefono = fabrica.ObtenerTelefono(vista.codTelefono, vista.telefonoCliente);
                                Entidad elCliente = fabrica.ObtenerClienteNatural(vista.nombreCliente,
                                    vista.apellidoCliente, vista.correoCliente, laDireccion, elTelefono, vista.cedulaCliente);
                                elCliente.Id = int.Parse(elID);
                                Comando<Entidad, bool> comando = FabricaComandos.CrearComandoModificarClienteNatural();
                                if (comando.Ejecutar(elCliente))
                                    HttpContext.Current.Response.Redirect(RecursoInterfazM2.ListarClientes +
                                        RecursoInterfazM2.Codigo_Exito_Modificar);
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
