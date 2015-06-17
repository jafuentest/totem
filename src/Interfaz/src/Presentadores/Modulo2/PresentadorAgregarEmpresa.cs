using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Contratos.Modulo2;
using Comandos;
using Comandos.Fabrica;
using Dominio;
using Comandos.Comandos.Modulo2;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;

namespace Presentadores.Modulo2
{
    public class PresentadorAgregarEmpresa
    {
        private IContratoAgregarEmpresa vista;

        public PresentadorAgregarEmpresa(IContratoAgregarEmpresa laVista)
        {
            this.vista = laVista;
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
            Comando<bool, List<String>> comando = FabricaComandos.CrearComandoConsultarListaPaises();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona un pais");
            try
            {
                List<String> resultado = comando.Ejecutar(true);
                foreach (String pais in resultado)
                {
                    options.Add(pais, pais);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            vista.comboPais.DataSource = options;
            vista.comboPais.DataTextField = "value";
            vista.comboPais.DataValueField = "key";
            vista.comboPais.DataBind();
            vista.comboPais.Enabled = true;
        }
        public void llenarComboEstadosPorPais(String elPais)
        {
            Comando<String, List<String>> comando = FabricaComandos.CrearComandoConsultarEstadosPorPais();
            Dictionary<string, string> options = new Dictionary<string, string>(); 
            options.Add("-1", "Selecciona un estado");
            try
            {
                List<String> resultado = comando.Ejecutar(elPais);
                foreach (String estado in resultado)
                {
                    options.Add(estado, estado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            vista.comboEstado.DataSource = options;
            vista.comboEstado.DataTextField = "value";
            vista.comboEstado.DataValueField = "key";
            vista.comboEstado.DataBind();
            vista.comboEstado.Enabled = true;
        }
        public void llenarComboCiudadesPorEstado(String elEstado)
        {
            Comando<String, List<String>> comando = FabricaComandos.CrearComandoConsultarCiudadPorEstado();
            Dictionary<string, string> options = new Dictionary<string, string>(); 
            options.Add("-1", "Selecciona una ciudad");
            try
            {
                List<String> resultado = comando.Ejecutar(elEstado);
                foreach (String ciudad in resultado)
                {
                    options.Add(ciudad, ciudad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            vista.comboCiudad.DataSource = options;
            vista.comboCiudad.DataTextField = "value";
            vista.comboCiudad.DataValueField = "key";
            vista.comboCiudad.DataBind();
            vista.comboCiudad.Enabled = true;
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
        public bool agregarEmpresa()
        {
            List<String> alfabeticos = new List<String>();
            List<String> alfanumericos = new List<String>();
            List<String> numericos = new List<String>();
            alfabeticos.Add(vista.apellidoContacto);
            alfabeticos.Add(vista.nombreContacto);
            alfanumericos.Add(vista.direccionEmpresa);
            alfanumericos.Add(vista.nombreEmpresa);
            alfanumericos.Add(vista.rifEmpresa);
            numericos.Add(vista.cedulaContacto);
            numericos.Add(vista.codTelefono);
            numericos.Add(vista.telefonoCliente);
            Regex expresion = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
            Regex expresion2 = new Regex(@"^.*(?=.*[0-9])(?=.*[a-zA-ZñÑ\s]).*$");

            if (Validaciones.ValidarCamposVacios(alfabeticos) || Validaciones.ValidarCamposVacios(alfabeticos) ||
                Validaciones.ValidarCamposVacios(numericos))
            {
                if (Validaciones.ValidarCaracteresAlfabeticos(alfabeticos))
                {
                    if (Validaciones.ValidarExpresionRegular(alfanumericos, expresion2))
                    {
                        if (Validaciones.ValidarExpresionRegular(numericos,expresion))
                        {
                            FabricaEntidades fabrica = new FabricaEntidades();
                            Entidad direccion = fabrica.ObtenerDireccion(vista.comboPais.SelectedValue,
                                vista.comboEstado.SelectedValue, vista.comboCiudad.SelectedValue,
                                vista.direccionEmpresa, vista.codigoPostalEmpresa);
                            Entidad telefono = fabrica.ObtenerTelefono(vista.codTelefono, vista.telefonoCliente);
                            Entidad contacto = fabrica.ObtenerContacto(vista.cedulaContacto, vista.nombreContacto,
                                vista.apellidoContacto, vista.comboCargo.SelectedValue, telefono);
                            List<Entidad> contactos = new List<Entidad>();
                            contactos.Add(contacto);
                            Entidad clientej = fabrica.ObtenerClienteJuridico(vista.nombreEmpresa, contactos, direccion, vista.rifEmpresa, "aquivaellogo");
                            try
                            {
                                Comando<Entidad, bool> comando = FabricaComandos.CrearComandoAgregarClienteJuridico();
                                return comando.Ejecutar(clientej);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
