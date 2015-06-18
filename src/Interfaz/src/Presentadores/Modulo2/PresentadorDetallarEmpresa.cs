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

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarEmpresa
    {
        private IContratoDetallarEmpresa vista;

        public PresentadorDetallarEmpresa(IContratoDetallarEmpresa laVista)
        {
            vista = laVista;
        }

        public void cargarDatos(String idEmpresa)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Entidad entidad = laFabrica.ObtenerClienteJuridico(int.Parse(idEmpresa));

            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarClienteJurXID();

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
    }
}
