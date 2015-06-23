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
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using System.Data.SqlClient;

namespace Presentadores.Modulo8
{
    public class PresentadorDetalleMinuta
    {

        private IContratoDetalleMinutas vista;
        public PresentadorDetalleMinuta(IContratoDetalleMinutas laVista)
        {
            vista = laVista;
        }
        public void DetalleMinuta(String idminuta)
        {
            try
            {
                Comando<String,Entidad> comandoDetalleMinuta =  FabricaComandos.CrearComandoComandoDetalleMinuta();

                Entidad laMinuta = comandoDetalleMinuta.Ejecutar(idminuta);
                /* inyectat HTML 
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
              */

            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
