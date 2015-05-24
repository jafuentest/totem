using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatosTotem.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento de as minutas, con respecto a las conexiones y llamadas
    /// a la BD
    /// </summary>
    public class BDMinuta : BDConexion
    {
        private Minuta minuta = new Minuta();

        /// <summary>
        /// Método para consultar los datos de una minuta en la BD
        /// </summary>
        /// <param name="id">Se recibe el id de la minuta que se desea consultar</param>
        /// <returns>Retrorna el objeto Minuta</returns>
        public Minuta ConsultarMinuta(int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarMinuta, Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, id));

                SqlDataReader leer;
                Conectar().Open();
                leer = comando.ExecuteReader();

                leer.Read();
                minuta = ObtenerObjetoMinuta(leer);


            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;
                
            }

            finally
            {
                Desconectar();
                
            }
            return minuta;
        }

        public Minuta ObtenerObjetoMinuta(SqlDataReader BDMinuta)
        {
            Minuta minuta = new Minuta();

            minuta.Codigo = BDMinuta[RecursosBDModulo8.AtributoIDMinuta].ToString();
            minuta.Fecha= DateTime.Parse(BDMinuta[RecursosBDModulo8.AtributoFechaMinuta].ToString());
            minuta.Motivo = BDMinuta[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
            minuta.Observaciones = BDMinuta[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();

            BDMinuta.Close();
            return minuta;

        }
    }
}
