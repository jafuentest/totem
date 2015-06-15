using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorListarClientes
    {
        private IContratoListarClientes vista;
        public PresentadorListarClientes(IContratoListarClientes laVista)
        {
            vista = laVista;
        }
        public void consultarClientes()
        {
            try
            {
                Comando<bool, List<Entidad>> comandoListarClientes =
                    FabricaComandos.CrearComandoConsultarTodosClienteNatural();

                List<Entidad> laLista = comandoListarClientes.Ejecutar(true);

                foreach (ClienteNatural elCliente in laLista)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Cedula
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Nombre
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Nat_Apellido
                       + RecursoInterfazM2.CerrarEtiqueta_td;

                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonDetalle + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonModificar + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonEliminar + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_tr;
                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}
