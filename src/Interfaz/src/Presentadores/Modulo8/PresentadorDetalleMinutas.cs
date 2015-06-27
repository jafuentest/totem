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
using Comandos.Comandos.Modulo8;

namespace Presentadores.Modulo8
{
    public class PresentadorDetalleMinuta
    {
        public PresentadorDetalleMinuta()
        {

        }
        public Dominio.Entidad DetalleMinuta(String idminuta)
        {
            try
            {
                Comando<String,Entidad> comandoDetalleMinuta =  FabricaComandos.CrearComandoComandoDetalleMinuta();

                Entidad laMinuta = comandoDetalleMinuta.Ejecutar(idminuta);

                return laMinuta;
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

        public void GenerarMinuta(String idMinuta)
        {
            int idMinuta2 = int.Parse(idMinuta);
            Comando<String, Entidad> comandoDetalleMinuta = FabricaComandos.CrearComandoComandoDetalleMinuta();

            Entidad laMinuta = comandoDetalleMinuta.Ejecutar(idMinuta);

            ComandoGenerarMinuta comandoGenerarMinuta = (ComandoGenerarMinuta)FabricaComandos.CrearComandoGenerarMinuta();
            bool aux = comandoGenerarMinuta.Ejecutar(laMinuta);

        }


    }
    
}
