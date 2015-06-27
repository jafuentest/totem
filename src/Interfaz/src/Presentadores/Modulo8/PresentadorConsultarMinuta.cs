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
                Comando<String, List<Entidad>> comandoListarMinutas =  FabricaComandos.CrearComandoComandoListaMinuta();

                List<Entidad> laLista = comandoListarMinutas.Ejecutar("Tot");

                foreach (Minuta minuta in laLista)
                {
                    Console.WriteLine(minuta.Id);
                    vista.laTabla += RecursosInterfazModulo8.AbrirEtiquetaTr;
                    vista.laTabla += RecursosInterfazModulo8.AbrirEtiquetaTd + minuta.Id + RecursosInterfazModulo8.CerrarEtiquetaTd;
                    vista.laTabla += RecursosInterfazModulo8.AbrirEtiquetaTd + minuta.Fecha + RecursosInterfazModulo8.CerrarEtiquetaTd;
                    vista.laTabla += RecursosInterfazModulo8.AbrirEtiquetaTd + minuta.Motivo+ RecursosInterfazModulo8.CerrarEtiquetaTd;
                    vista.laTabla += RecursosInterfazModulo8.AbrirEtiquetaTd;

                    vista.laTabla += RecursosInterfazModulo8.BotonDetalleIniciar+minuta.Id;
                    vista.laTabla += RecursosInterfazModulo8.BotonDetalle;
                    vista.laTabla += minuta.Id + RecursosInterfazModulo8.BotonDetalleCerrar;

                    vista.laTabla += RecursosInterfazModulo8.BotonDetalleIniciar + minuta.Id;
                    vista.laTabla += RecursosInterfazModulo8.BotonModificar;
                    vista.laTabla += minuta.Id + RecursosInterfazModulo8.BotonDetalleCerrar;

                    vista.laTabla += RecursosInterfazModulo8.BotonDetalleIniciar + minuta.Id;
                    vista.laTabla += RecursosInterfazModulo8.BotonImprimir;
                    vista.laTabla += minuta.Id + RecursosInterfazModulo8.BotonDetalleCerrar;


                    vista.laTabla += RecursosInterfazModulo8.CerrarEtiquetaTd;
                    vista.laTabla += RecursosInterfazModulo8.CerrarEtiquetaTr;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InfoProyecto(String codigoProy, String nombreProy)
        {
            vista.codigoProyecto = codigoProy;
            vista.nombreProyecto = nombreProy;
        }

        public void GenerarMinuta(String idMinuta)
        {
            int idMinuta2 = int.Parse(idMinuta);

        }
    }
}
