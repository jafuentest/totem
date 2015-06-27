using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;
using Dominio;
using Comandos.Comandos.Modulo2;
using Comandos;
using Comandos.Fabrica;
using System.Web;

namespace Presentadores.Modulo2
{
    /// <summary>
    /// Presentador para la ventana Detallar Cliente
    /// </summary>
    public class PresentadorDetallarCliente
    {
        private IContratoDetallarCliente vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarCliente(IContratoDetallarCliente laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// Metodo para consultar las variables URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            String detalleCliente = HttpContext.Current.Request.QueryString["detalle"];
            if (detalleCliente != null)
                cargarDatos(detalleCliente);
        }
        /// <summary>
        /// Metodo para cargar los datos del cliente natural 
        /// </summary>
        /// <param name="idCliente">id del cliente</param>
        public void cargarDatos(String idCliente)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Entidad entidad = laFabrica.ObtenerClienteNatural();
            Comando<Entidad, Entidad> comando =
                FabricaComandos.CrearComandoConsultarXIDClienteNatural();
            try
            {
                entidad.Id = int.Parse(idCliente);
                ClienteNatural elCliente = (ClienteNatural)comando.Ejecutar(entidad);

                vista.apellidoCliente = elCliente.Nat_Apellido;
                vista.cedulaCliente = elCliente.Nat_Cedula;
                vista.ciudad = elCliente.Nat_Direccion.LaCiudad;
                vista.codpostal = elCliente.Nat_Direccion.CodigoPostal;
                vista.correocliente = elCliente.Nat_Correo;
                vista.direccion = elCliente.Nat_Direccion.LaDireccion;
                vista.estado = elCliente.Nat_Direccion.ElEstado;
                vista.nombreCliente = elCliente.Nat_Nombre;
                vista.pais = elCliente.Nat_Direccion.ElPais;
                vista.telefono = elCliente.Nat_Telefono.Codigo + "-" + elCliente.Nat_Telefono.Numero;
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

    }

}
