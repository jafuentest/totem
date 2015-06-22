using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Comandos;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo2;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;

namespace Presentadores.Modulo2
{
    public class PresentadorListarEmpresas
    {
        private IContratoListarEmpresas vista;
        public PresentadorListarEmpresas(IContratoListarEmpresas laVista)
        {
            vista = laVista;
        }
        public void consultarEmpresas()
        {
            try
            {
                Comando<bool, List<Entidad>> comandoListarEmpresas = 
                    FabricaComandos.CrearComandoConsultarTodosClienteJuridico();

                List<Entidad> laLista = comandoListarEmpresas.Ejecutar(true);

                foreach (ClienteJuridico elCliente in laLista)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Jur_Rif
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Jur_Nombre
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonDetalleEmpresa + elCliente.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonModificarEmpresa + elCliente.Id +
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
