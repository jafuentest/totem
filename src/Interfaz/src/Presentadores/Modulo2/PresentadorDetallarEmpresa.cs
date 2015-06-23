using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using Comandos;
using Comandos.Fabrica;
using System.Web;

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarEmpresa
    {
        private IContratoDetallarEmpresa vista;

        public PresentadorDetallarEmpresa(IContratoDetallarEmpresa laVista)
        {
            vista = laVista;
        }
        public void ObtenerVariablesURL()
        {
            String detalleEmpresa = HttpContext.Current.Request.QueryString["detalle"];
            if (detalleEmpresa != null)
                cargarDatos(detalleEmpresa);
        }
        public void cargarDatos(String idEmpresa)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();

            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarClienteJurXID();
            try
            {
                Entidad entidad = laFabrica.ObtenerClienteJuridico(int.Parse(idEmpresa));
                ClienteJuridico elCliente = (ClienteJuridico)elComando.Ejecutar(entidad);

                vista.rifEmpresa = elCliente.Jur_Rif;
                vista.paisEmpresa = elCliente.Jur_Direccion.ElPais;
                vista.nombreEmpresa = elCliente.Jur_Nombre;
                vista.estadoEmpresa = elCliente.Jur_Direccion.ElEstado;
                vista.direccionEmpresa = elCliente.Jur_Direccion.LaDireccion;
                vista.codigoPostal = elCliente.Jur_Direccion.CodigoPostal;
                vista.ciudadEmpresa = elCliente.Jur_Direccion.LaCiudad;
                elCliente.Jur_Contactos = new List<Contacto>();
                Comando<Entidad,List<Entidad>> elComando2 = FabricaComandos.CrearComandoConsultarListaContactos();
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
    }
}
