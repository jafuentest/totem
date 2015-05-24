using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data.SqlClient;
using System.Data;

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
            this.conexion = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Teddy J Sears\Desktop\totem\src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True");


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
                this.instruccion = new SqlCommand("INSERTAR_ACTOR", this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue("@nombre", actor.NombreActor);
                this.instruccion.Parameters.AddWithValue("@descripcion", actor.DescripcionActor);
                this.instruccion.Parameters.AddWithValue("@idproyecto", proyectoActor);

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

            //Respuesta de la consulta hecha a la Base de Datos
            SqlDataReader respuesta;

            //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
            this.instruccion = new SqlCommand("LEER_ACTOR", this.conexion);
            this.instruccion.CommandType = CommandType.StoredProcedure;

            //Le agregamos los valores correspondientes a las variables de Stored Procedure
            this.instruccion.Parameters.AddWithValue("@idproyecto", proyectoActor);

            //Se abre conexion contra la Base de Datos
            this.conexion.Open();

            //Ejecutamos la consulta y traemos las filas que fueron obtenidas
            respuesta = instruccion.ExecuteReader();

            //Si se encontraron actores se comienzan a agregar a la variable lista, sino, se devolvera vacia
            if (respuesta.HasRows)
                //Recorremos cada fila devuelta de la consulta
                while (respuesta.Read())
                {
                    Actor aux = new Actor(respuesta.GetInt32(2), respuesta.GetString(0), respuesta.GetString(1));
                    listaActores.Add(aux);
                }

            //Cerramos conexion
            this.conexion.Close();

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
                this.instruccion = new SqlCommand("MODIFICAR_ACTOR", this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue("@nombre", actor.NombreActor);
                this.instruccion.Parameters.AddWithValue("@descripcion", actor.DescripcionActor);
                this.instruccion.Parameters.AddWithValue("@idproyecto", proyectoActor);
                this.instruccion.Parameters.AddWithValue("@idactor", actor.IdentificacionActor);

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
                this.instruccion = new SqlCommand("ELIMINAR_ACTOR", this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue("@nombre", actor.NombreActor);
                this.instruccion.Parameters.AddWithValue("@idproyecto", proyectoActor);

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

            //Retornamos la respuesta
            return exito;
        }
    }
}
