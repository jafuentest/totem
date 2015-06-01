using DominioTotem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatosTotem.Modulo6
{
	public class BDCasoUso
	{
        SqlConnection conexion;
        SqlCommand instruccion;

        public BDCasoUso()
        {
            try
            {
                this.conexion = new SqlConnection(
					ConfigurationManager.ConnectionStrings[RecursoGeneralBD.NombreBD].ConnectionString);
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException("Error en la Configuracion de la BD", e);
            }
        }

        public List<CasoDeUso> ListarCasosDeUso(int idProyecto)
        {
            //Lista donde devolveremos los actores del proyecto
			List<CasoDeUso> lista = new List<CasoDeUso>();
            try
            {
				this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LISTAR_CU, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;
				//this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_PROY, idProyecto);
                this.conexion.Open();

				SqlDataReader respuesta = instruccion.ExecuteReader();

				if (respuesta.HasRows)
				{
					while (respuesta.Read())
					{
						CasoDeUso caso = new CasoDeUso(respuesta.GetInt32(0), respuesta.GetString(1),
							respuesta.GetString(2), respuesta.GetString(3), respuesta.GetString(4),
							respuesta.GetString(5));
						lista.Add(caso);
					}
				}
				this.conexion.Close();

				foreach(CasoDeUso caso in lista)
				{
					#region Requerimientos
					this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LEER_REQUERIMIENTO_DEL_CU, this.conexion);
					this.instruccion.CommandType = CommandType.StoredProcedure;
					this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_CU, caso.IdCasoUso);
					this.conexion.Open();

					respuesta = instruccion.ExecuteReader();
					List<Requerimiento> requerimientos = new List<Requerimiento>();
					while (respuesta.Read())
						requerimientos.Add(new Requerimiento(respuesta.GetString(0), respuesta.GetString(1),
							respuesta.GetString(2), respuesta.GetString(3), respuesta.GetString(4)));

					caso.RequerimientosAsociados = requerimientos;
					this.conexion.Close();
					#endregion
					
					#region Actores
					this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LEER_ACTOR_DEL_CU, this.conexion);
					this.instruccion.CommandType = CommandType.StoredProcedure;
					this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_CU, caso.IdCasoUso);
					this.conexion.Open();

					respuesta = instruccion.ExecuteReader();
					List<Actor> actores = new List<Actor>();
					while (respuesta.Read())
						actores.Add(new Actor(respuesta.GetString(0), respuesta.GetString(1)));

					caso.Actores = actores;
					this.conexion.Close();
					#endregion

					#region Precondiciones
					this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LEER_PRECONDICION, this.conexion);
					this.instruccion.CommandType = CommandType.StoredProcedure;
					this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_CU, caso.IdCasoUso);
					this.conexion.Open();

					respuesta = instruccion.ExecuteReader();
					List<String> precondiciones = new List<String>();
					while (respuesta.Read())
						precondiciones.Add(respuesta.GetString(0));
					
					caso.PrecondicionesCasoUso = precondiciones;
					this.conexion.Close();
					#endregion

					#region Pasos
					this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LEER_PASO, this.conexion);
					this.instruccion.CommandType = CommandType.StoredProcedure;
					this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_CU, caso.IdCasoUso);
					this.conexion.Open();

					respuesta = instruccion.ExecuteReader();
					List<Tuple<String, Dictionary<String, List<String>>>> pasos = 
						new List<Tuple<String, Dictionary<String, List<String>>>>();
					while (respuesta.Read())
					{
						List<String> pasosExtension = new List<String>();
						pasosExtension.Add("Se hace algo");
						pasosExtension.Add("Se hace otra cosa");

						Dictionary<String, List<String>> extensiones = new Dictionary<String, List<String>>();
						extensiones.Add("El usuario cometio un error", pasosExtension);
						
						Tuple<String, Dictionary<String, List<String>>> paso =
							new Tuple<String, Dictionary<String,List<String>>>(respuesta.GetString(1), extensiones);
					}
					caso.EscenarioExito = pasos;
					this.conexion.Close();
					#endregion
				}
			}
            catch (SqlException e)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + e.Errors[i].Message + "\n" +
                        "LineNumber: " + e.Errors[i].LineNumber + "\n" +
                        "Source: " + e.Errors[i].Source + "\n" +
                        "Procedure: " + e.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                throw e;
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al Listar", error);
            }

            return lista;
        }
    }
}
