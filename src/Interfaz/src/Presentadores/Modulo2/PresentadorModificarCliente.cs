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


namespace Presentadores.Modulo2
{
    public class PresentadorModificarCliente
    {
        private IContratoModificarCliente vista;
        public PresentadorModificarCliente(IContratoModificarCliente laVista)
        {
            vista = laVista;
        }

        public void cargarCliente(String idCliente)
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidadCliente = fabrica.ObtenerClienteNatural();

            entidadCliente.Id = int.Parse(idCliente);

            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarXIDClienteNatural();

            ClienteNatural elCliente = (ClienteNatural)comando.Ejecutar(entidadCliente);

            vista.cedulaCliente = elCliente.Nat_Cedula;
            vista.nombreCliente = elCliente.Nat_Nombre;
            vista.apellidoCliente = elCliente.Nat_Apellido;
            vista.codigoPostalCliente = elCliente.Nat_Direccion.CodigoPostal;
            vista.codTelefono = elCliente.Nat_Telefono.Codigo;
            vista.telefonoCliente = elCliente.Nat_Telefono.Numero;
            vista.correoCliente = elCliente.Nat_Correo;
            vista.direccionCliente = elCliente.Nat_Direccion.LaDireccion;
            vista.comboPais.SelectedValue = elCliente.Nat_Direccion.ElPais;
            llenarComboEstadosXPais(elCliente.Nat_Direccion.ElPais);
            vista.comboEstado.SelectedValue = elCliente.Nat_Direccion.ElEstado;
            llenarComboCiudadXEstado(elCliente.Nat_Direccion.ElEstado);
            vista.comboCiudad.SelectedValue = elCliente.Nat_Direccion.LaCiudad;
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

            }
            vista.comboCiudad.DataSource = options;
            vista.comboCiudad.DataTextField = "value";
            vista.comboCiudad.DataValueField = "key";
            vista.comboCiudad.DataBind();
            vista.comboCiudad.Enabled = true;
        }

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

                                Entidad laDireccion = fabrica.ObtenerDireccion(vista.comboPais.SelectedValue,
                                    vista.comboEstado.SelectedValue, vista.comboCiudad.SelectedValue,
                                    vista.direccionCliente, vista.codigoPostalCliente);
                                Entidad elTelefono = fabrica.ObtenerTelefono(vista.codTelefono, vista.telefonoCliente);
                                Entidad elCliente = fabrica.ObtenerClienteNatural(vista.nombreCliente,
                                    vista.apellidoCliente, vista.correoCliente, laDireccion, elTelefono, vista.cedulaCliente);
                                elCliente.Id = int.Parse(elID);

                                try
                                {
                                    Comando<Entidad, bool> comando = FabricaComandos.CrearComandoModificarClienteNatural();
                                    return comando.Ejecutar(elCliente);
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
