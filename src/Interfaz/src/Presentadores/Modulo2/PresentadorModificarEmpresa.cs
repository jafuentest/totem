﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio.Fabrica;
using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Text.RegularExpressions;
using System.Web;

namespace Presentadores.Modulo2
{
    public class PresentadorModificarEmpresa
    {
        private IContratoModificarEmpresa vista;
        public PresentadorModificarEmpresa(IContratoModificarEmpresa laVista)
        {
            vista = laVista;
        }

        public void cargarDatosEmpresa(String idEmpresa)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarClienteJurXID();
            try
            {
                Entidad entidad = laFabrica.ObtenerClienteJuridico(int.Parse(idEmpresa));

                ClienteJuridico elCliente = (ClienteJuridico)elComando.Ejecutar(entidad);

                vista.rifEmpresa = elCliente.Jur_Rif;
                vista.nombreEmpresa = elCliente.Jur_Nombre;
                vista.comboPais.SelectedValue = elCliente.Jur_Direccion.ElPais;
                llenarComboEstadosXPais(elCliente.Jur_Direccion.ElPais);
                vista.comboEstado.SelectedValue = elCliente.Jur_Direccion.ElEstado;
                llenarComboCiudadXEstado(elCliente.Jur_Direccion.ElEstado);
                vista.comboCiudad.SelectedValue = elCliente.Jur_Direccion.LaCiudad;
                vista.direccionEmpresa = elCliente.Jur_Direccion.LaDireccion;
                vista.codigoPostalEmpresa = elCliente.Jur_Direccion.CodigoPostal;
                elCliente.Jur_Contactos = new List<Contacto>();

                Comando<Entidad, List<Entidad>> elComando2 = FabricaComandos.CrearComandoConsultarListaContactos();
                List<Entidad> contactos = elComando2.Ejecutar(elCliente);
                foreach (Entidad e in contactos)
                {
                    elCliente.Jur_Contactos.Add((Contacto)e);
                }
                foreach (Contacto elContacto in elCliente.Jur_Contactos)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elContacto.Con_Nombre + " "
                        + elContacto.Con_Apellido + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elContacto.ConCargo
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_tr;
                }
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

            vista.direccionEmpresa = "";
            vista.codigoPostalEmpresa = "";
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

            vista.direccionEmpresa = "";
            vista.codigoPostalEmpresa = "";
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
            String edicionEmpresa = HttpContext.Current.Request.QueryString["id"];
            if (edicionEmpresa != null)
            {
                cargarDatosEmpresa(edicionEmpresa);
            }

        }

        public bool modificarEmpresa(String elID)
        {
            List<String> alfabeticos = new List<String>();
            List<String> alfanumericos = new List<String>();
            List<String> numericos = new List<String>();

            alfabeticos.Add(vista.nombreEmpresa);
            alfanumericos.Add(vista.direccionEmpresa);
            alfanumericos.Add(vista.rifEmpresa);

            numericos.Add(vista.codigoPostalEmpresa);

            Regex expresion = new Regex(@"[0-9]{1,9}(\.[0-9]{0,2})?$");
           
            if (Validaciones.ValidarCamposVacios(alfabeticos) && Validaciones.ValidarCamposVacios(alfabeticos) &&
                Validaciones.ValidarCamposVacios(numericos))
            {
                if (Validaciones.ValidarCaracteresAlfabeticos(alfabeticos))
                {
                    if (Validaciones.ValidarExpresionRegular(numericos, expresion))
                    {
                        FabricaEntidades fabrica = new FabricaEntidades();

                        try
                        {                        
                            Entidad laDireccion = fabrica.ObtenerDireccion(vista.comboPais.SelectedValue,
                            vista.comboEstado.SelectedValue, vista.comboCiudad.SelectedValue,
                            vista.direccionEmpresa, vista.codigoPostalEmpresa);
                            
                            ClienteJuridico laEmpresa = (ClienteJuridico) fabrica.ObtenerClienteJuridico();
                            laEmpresa.Id = int.Parse(elID);

                            laEmpresa.Jur_Direccion = new Direccion();
                            laEmpresa.Jur_Direccion = (Direccion)laDireccion;
                            laEmpresa.Jur_Nombre = vista.nombreEmpresa;
                            laEmpresa.Jur_Logo = "aquivaellogo";
                            laEmpresa.Jur_Rif = vista.rifEmpresa;
                            Comando<Entidad, bool> comando = FabricaComandos.CrearComandoModificarClienteJuridico();

                            if (comando.Ejecutar(laEmpresa))
                                HttpContext.Current.Response.Redirect(RecursoInterfazM2.ListarEmpresas +
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
