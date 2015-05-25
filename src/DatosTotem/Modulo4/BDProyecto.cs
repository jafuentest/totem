
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

namespace DatosTotem.Modulo4
{
    /// <summary>
    /// Clase para el gestionamiento de as minutas, con respecto a las conexiones y llamadas
    /// a la BD
    /// </summary>
    public class BDProyecto : BDConexion
    {
        private Proyecto proyecto;


        #region Create
        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto CrearProyecto(Proyecto proyecto)
        {
            try
            {
                SqlCommand comando = new SqlCommand(RecursosBDModulo4.ProcedimientoConsultarProyecto, Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosBDModulo4.ProcedimientoAgregarProyecto, proyecto.));

                SqlDataReader leer;
                Conectar().Open();
                leer = comando.ExecuteReader();

                leer.Read();
                proyecto = ObtenerObjetoProyecto(leer);


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
            return proyecto;
        }
        #endregion


        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar</param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto ConsultarProyecto(String codigo)
        {
            try
            {
                SqlCommand comando = new SqlCommand(RecursosBDModulo4.ProcedimientoConsultarProyecto, Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter(RecursosBDModulo4.ParametroCodigoProyecto, codigo));

                SqlDataReader leer;
                Conectar().Open();
                leer = comando.ExecuteReader();

                leer.Read();
                proyecto = ObtenerObjetoProyecto(leer);


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
            return proyecto;
        }

       


        public Proyecto ObtenerObjetoProyecto(SqlDataReader BDProyecto)
        {
            Proyecto proyecto = new Proyecto(BDProyecto[RecursosBDModulo4.AtributoCodigoProyecto].ToString(),
                                             BDProyecto[RecursosBDModulo4.AtributoNombreProyecto].ToString(),
                                             bool.Parse(BDProyecto[RecursosBDModulo4.AtributoEstadoProyecto].ToString()),
                                             BDProyecto[RecursosBDModulo4.AtributoDescripcionProyecto].ToString(),
                                             BDProyecto[RecursosBDModulo4.AtributoMonedaProyecto].ToString(),
                                             float.Parse(BDProyecto[RecursosBDModulo4.AtributoCostoProyecto].ToString()));


            BDProyecto.Close();
            return proyecto;

        }
    }
}
