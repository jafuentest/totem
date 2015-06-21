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
    class PresentadorDetalleMinuta
    {

        private IContratoDetalleMinutas vista;
        public PresentadorDetalleMinuta(IContratoDetalleMinutas laVista)
        {
            vista = laVista;
        }
        public void DetalleMinutas()
        {
            /*try
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
                    vista.laTabla += RecursosInterfazModulo8.BotonDetalle;
                    vista.laTabla += RecursosInterfazModulo8.BotonModificar;
                    vista.laTabla += RecursosInterfazModulo8.BotonImprimir;
                    vista.laTabla += RecursosInterfazModulo8.CerrarEtiquetaTd;
                    vista.laTabla += RecursosInterfazModulo8.CerrarEtiquetaTr;
                }


            }
            catch (Exception ex)
            {

            }*/
        }
    }
    
}
