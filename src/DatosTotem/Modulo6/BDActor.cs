using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace DatosTotem.Modulo6
{
    /// <summary>
    /// Summary description for BDActor
    /// </summary>
    public class BDActor
    {
        //Conexion de la BD e instruccion a realizar
        SqlConnection conexion;
        SqlCommand instruccion;

        //Constructor que inicializa la conexion indicando la ruta de la Base de Datos
        public BDActor()
        {
            try
            {
                //Obtenemos la ruta de la Base de Datos
                String[] aux = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "src" }, StringSplitOptions.None);
                String configuracion = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + aux[0] + @"src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True";

                //La colocamos en la configuracion
                this.conexion = new SqlConnection(configuracion);
            }
            catch (ConfigurationErrorsException e)
            {
                throw new ConfigurationErrorsException("Error en la Configuracion de la BD", e);
            }

        }

        /// <summary>
        /// Agrega un actor nuevo al proyecto en la Base de Datos
        /// </summary>
        /// <param name="actor">El actor que se creara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool AgregarActor(Actor actor, int proyectoActor)
        {
            //Indicaremos si la insercion fue exitosa o fallida
            bool exito = false;
            try
            {
                //Variable que cambiara su valor si las filas de la Base de Datos fueron alteradas (se inserto)
                Int32 filasAfectadas = 0;

                //Indicamos que es un stored procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_INSERTAR_ACTOR, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.NOMBRE_ACTOR, actor.NombreActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.DESC_ACTOR, actor.DescripcionActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_PROY_ACTOR, proyectoActor);

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron altearadas (agregadas en este caso)
                filasAfectadas = this.instruccion.ExecuteNonQuery();

                //Cerramos conexion
                this.conexion.Close();

                //Si la respuesta es mayor que uno entonces se agrego exitosamente
                if (filasAfectadas > 0)
                    exito = true;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Actor debe existir", e);
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                throw ex;
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al agregar", error);
            }

            //Retornamos la respuesta
            return exito;
        }

        /// <summary>
        /// Lee todos los actores asociados al proyecto en la Base de Datos
        /// </summary>
        /// <param name="proyectoActor">El proyecto al que se desea obtener los actor(es)</param>
        /// <returns>Los actores asociados al proyecto</returns>
        public List<Actor> ListarActor(int proyectoActor)
        {
            //Lista donde devolveremos los actores del proyecto
            List<Actor> listaActores = new List<Actor>();
            try
            {
                //Respuesta de la consulta hecha a la Base de Datos
                SqlDataReader respuesta;

                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_LEER_ACTOR, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de Stored Procedure
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_PROY_ACTOR, proyectoActor);

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron obtenidas
                respuesta = instruccion.ExecuteReader();

                //Si se encontraron actores se comienzan a agregar a la variable lista, sino, se devolvera vacia
                if (respuesta.HasRows)
                    //Recorremos cada fila devuelta de la consulta
                    while (respuesta.Read())
                    {
                        //Creamos el Actor y lo anexamos a la lista
                        Actor aux = new Actor(respuesta.GetInt32(2), respuesta.GetString(0), respuesta.GetString(1));
                        listaActores.Add(aux);
                    }

                //Cerramos conexion
                this.conexion.Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                throw ex;
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al Listar", error);
            }
            //Retornamos la respuesta
            return listaActores;
        }

        /// <summary>
        /// Modifica un actor existente del proyecto en la Base de Datos
        /// </summary>
        /// <param name="actor">El actor que se modificara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarActor(Actor actor, int proyectoActor)
        {
            //Indicaremos si la insercion fue exitosa o fallida
            bool exito = false;
            try
            {
                //Variable que cambiara su valor si las filas de la Base de Datos fueron alteradas (se inserto)
                Int32 filasAfectadas = 0;

                //Indicamos que es un stored procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_MODIFICAR_ACTOR, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.NOMBRE_ACTOR, actor.NombreActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.DESC_ACTOR, actor.DescripcionActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_PROY_ACTOR, proyectoActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_ACTOR, actor.IdentificacionActor);

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron altearadas (agregadas en este caso)
                filasAfectadas = this.instruccion.ExecuteNonQuery();

                //Cerramos conexion
                this.conexion.Close();

                //Si la respuesta es mayor que uno entonces se agrego exitosamente
                if (filasAfectadas > 0)
                    exito = true;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Actor debe existir", e);
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                throw ex;
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al modificar", error);
            }

            //Retornamos la respuesta
            return exito;
        }

        /// <summary>
        /// Elimina un actor existente del proyecto en la Base de Datos
        /// </summary>
        /// <param name="actor">El actor que se eliminara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool EliminarActor(Actor actor, int proyectoActor)
        {
            //Indicaremos si la insercion fue exitosa o fallida
            bool exito = false;
            try
            {
                //Variable que cambiara su valor si las filas de la Base de Datos fueron alteradas (se inserto)
                Int32 filasAfectadas = 0;

                //Indicamos que es un stored procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBDModulo6.PROCEDURE_ELIMINAR_ACTOR, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_ACTOR, actor.IdentificacionActor);
                this.instruccion.Parameters.AddWithValue(RecursosBDModulo6.ID_PROY_ACTOR, proyectoActor);

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron afectadas (eliminadas en este caso)
                filasAfectadas = this.instruccion.ExecuteNonQuery();

                //Cerramos conexion
                this.conexion.Close();

                //Si la respuesta es mayor que uno entonces se agrego exitosamente
                if (filasAfectadas > 0)
                    exito = true;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Actor debe existir", e);
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                throw ex;
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al eliminar", error);
            }

            //Retornamos la respuesta
            return exito;
        }

        /*
       /// <summary>
       /// Lista los Casos de Usos del actor
       /// </summary>
       /// <param name="actor">El actor que se desea consultar sus Casos de Uso</param>
       /// <param name="proyectoActor">El proyecto que tiene el Actor</param>
       /// <returns>Los Casos de Uso asociados al Actor</returns>
       public List<CasoDeUso> CasoUsoPorActor(Actor actor, int proyectoActor)
       {
           try
           { 
               //Lista donde devolveremos los Casos de Uso del actor
               List<CasoDeUso> listaCasos = new List<CasoDeUso>();

               //Respuesta de la consulta hecha a la Base de Datos
               SqlDataReader respuesta;

               //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
               this.instruccion = new SqlCommand("LEER_CU_POR_ACTOR", this.conexion);
               this.instruccion.CommandType = CommandType.StoredProcedure;

               //Le agregamos los valores correspondientes a las variables de Stored Procedure
               this.instruccion.Parameters.AddWithValue("@nombreActor", actor.NombreActor);
               this.instruccion.Parameters.AddWithValue("@idproyecto", proyectoActor);

               //Se abre conexion contra la Base de Datos
               this.conexion.Open();

               //Ejecutamos la consulta y traemos las filas que fueron obtenidas
               respuesta = instruccion.ExecuteReader();

               //Si se encontraron Casos de Uso se comienzan a agregar a la variable lista, sino, se devolvera vacia
               if (respuesta.HasRows)
                   //Recorremos cada fila devuelta de la consulta
                   while (respuesta.Read())
                   {
                       //Creamos el Caso de Uso y lo anexamos a la lista
                       CasoDeUso aux = new CasoDeUso(respuesta.GetInt32(0), respuesta.GetString(1),
                           respuesta.GetString(2), respuesta.GetString(3), respuesta.GetString(4));
                       listaCasos.Add(aux);
                   }

               //Cerramos conexion
               this.conexion.Close();
           }
           catch (NullReferenceException e)
           {
               throw new NullReferenceException("Actor debe existir", e);
           }

           //Retornamos la respuesta
           return listaCasos;
       }*/


    }
}
