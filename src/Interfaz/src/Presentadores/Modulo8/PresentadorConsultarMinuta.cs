using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo8;
using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo8;
using Dominio.Fabrica;

namespace Presentadores.Modulo8
{
    public class PresentadorConsultarMinuta
    {
        private IContratoConsultarMinuta vista;
        public PresentadorConsultarMinuta(IContratoConsultarMinuta laVista)
        {
            vista = laVista;
        }
        public void consultarMinutas()
        {
            try
            {
                Comando<bool, List<Entidad>> comandoListarClientes =
                    FabricaComandos.CrearComandoConsultarTodosClienteNatural();

                List<Entidad> laLista = comandoListarClientes.Ejecutar(true);

                /*foreach (ClienteNatural elCliente in laLista)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Cedula
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Nombre
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Apellido
                       + RecursoInterfazM2.CerrarEtiqueta_td;

                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonDetalleCliente + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonModificarCliente + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonEliminarCliente + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_tr;
                }*/


            }
            catch (Exception ex)
            {

            }
        }
    }
}
