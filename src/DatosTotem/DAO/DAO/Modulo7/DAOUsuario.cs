using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO.Modulo7;
using Dominio.Entidades.Modulo7;
using DAO.DAO.Modulo7;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dominio;

namespace DAO.DAO.Modulo7
{
    /// <summary>
    /// Clase DAO que interactua con la BD y realiza las operaciones del Usuario
    /// </summary>
    public class DAOUsuario : IDaoUsuario
    {
        private SqlConnection conexion;
        private SqlCommand instruccion;

        public DAOUsuario()
        {
            try
            {
                if (this.conexion == null)
                    this.conexion = new SqlConnection(ConfigurationManager.
                    ConnectionStrings[RecursoGeneralDAO.Nombre_Base_Datos].ConnectionString);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (ConfigurationErrorsException m)
            {
                throw new ConfigurationErrorsException("Error en la Configuracion de la BD", m);
            }
            
        }

        /// <summary>
        /// Metodo que agrega un Usuario nuevo a la Base de Datos
        /// </summary>
        /// <param name="usuario">El usuario a ser insertado en la BD</param>
        /// <returns>Verdadero si el usuario fue agregado o falso sino fue agregado</returns>
        public bool AgregarUsuario(Entidad parametro)
        {
            //Casteamos explicitamente para trabajar con el usuario que registraremos
            Usuario elUsuario = (Usuario)parametro;
            
            //Calculamos el hash de su clave
            elUsuario.CalcularHash();

             //Indicaremos si la insercion fue exitosa o fallida
            bool exito = false;
            try
            {
                //Variable que cambiara su valor si las filas de la Base de Datos fueron alteradas (se inserto)
                Int32 filasAfectadas = 0;

                //Indicamos que es un stored procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBaseDeDatosModulo7.ProcedimientoInsertarUsuario, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de stored procedure
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    elUsuario.Username);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    elUsuario.Clave);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.NombreUsuario,
                    elUsuario.Nombre);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    elUsuario.Apellido);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.RolUsuario,
                    elUsuario.Rol);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.CorreoUsuario,
                    elUsuario.Correo);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.PreguntaUsuario,
                    elUsuario.PreguntaSeguridad);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.RespuestaUsuario,
                    elUsuario.RespuestaSeguridad);
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.CargoUsuario,
                    elUsuario.Cargo);


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
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al agregar", error);
            }


            return exito;
        }

        /// <summary>
        /// Metodo que valida si el username ya existe en la Base de Datos
        /// </summary>
        /// <param name="username">El username que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso sino es valido</returns>
        public bool ValidarUsernameUnico (String username)
        {
            //Indicaremos si se encontro o no el username en la BD
            bool valido = false;

            //  List<Parametro> parametros = new List<Parametro>();
            try
            {
                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBaseDeDatosModulo7.ProcedimientoUsuarioUnico, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de Stored Procedure y ademas el output
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.UsernameUsuario, username);
                this.instruccion.Parameters.Add(RecursosBaseDeDatosModulo7.Resultadorepetido,SqlDbType.VarChar,60);
                this.instruccion.Parameters[RecursosBaseDeDatosModulo7.Resultadorepetido].Direction = ParameterDirection.Output;

                Console.WriteLine("Antes del Open");

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos si existe el username que se desea registrar
                this.instruccion.ExecuteNonQuery();

                Console.WriteLine("El query es: " + this.instruccion.Parameters[RecursosBaseDeDatosModulo7.Resultadorepetido].Value.ToString());

                //Si existe se indicara que es falso, caso contrario se indicara que es verdadero
                if (this.instruccion.Parameters[RecursosBaseDeDatosModulo7.Resultadorepetido].Value.ToString() == "")
                    valido = true;
                
                //Cerramos conexion
                this.conexion.Close();

                /*Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                        SqlDbType.VarChar, userName, false);
                parametros.Add(parametro);*/
                
        /*        parametro = new Parametro(RecursosBaseDeDatosModulo7.Resultadorepetido,
                        SqlDbType.VarChar, true);
                parametros.Add(parametro);*/
              //  string query = RecursosBaseDeDatosModulo7.ProcedimientoUsuarioUnico;
               // BDConexion conexionBD = new BDConexion();

                //Lista donde obtendremos
             //   List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query, parametros);
                
            }
            catch (SqlException e)
            {
                valido = false;

            }
            return valido;
            
        }

        /// <summary>
        /// Metodo que valida si el correo que se desea registrar ya existe o no en la Base de Datos
        /// </summary>
        /// <param name="correo">El correo que se desea registrar</param>
        /// <returns>Verdadero si es valido o falso si ya existe en la Base de Datos</returns>
        public bool ValidarCorreoUnico (String correo)
        {
            //Indicaremos si se encontro o no el username en la BD
            bool valido = false;

            //  List<Parametro> parametros = new List<Parametro>();
            try
            {
                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand(RecursosBaseDeDatosModulo7.ProcedimientoCorreoUnico, this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Le agregamos los valores correspondientes a las variables de Stored Procedure y ademas el output
                this.instruccion.Parameters.AddWithValue(RecursosBaseDeDatosModulo7.CorreoUsuario, correo);
                this.instruccion.Parameters.Add(RecursosBaseDeDatosModulo7.Resultadorepetido,SqlDbType.VarChar,60);
                this.instruccion.Parameters[RecursosBaseDeDatosModulo7.Resultadorepetido].Direction = ParameterDirection.Output;

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos si existe el username que se desea registrar
                this.instruccion.ExecuteNonQuery();

                //Si existe se indicara que es falso, caso contrario se indicara que es verdadero
                if (this.instruccion.Parameters[RecursosBaseDeDatosModulo7.Resultadorepetido].Value.ToString() == "")
                    valido = true;
                
                //Cerramos conexion
                this.conexion.Close();

            }
            catch (SqlException e)
            {
                valido = false;

            }
            return valido;
        }

        /// <summary>
        /// Metodo que interactua con la Base de Datos y obtiene todos los cargos de la Base de Datos
        /// </summary>
        /// <returns>La lista con todos los cargos encontrados en la Base de Datos</returns>
        public List<string> ListarCargos()
        {
            //throw new NotImplementedException();

            //Lista que sera la respuesta de la consulta;
            List<String> cargos = new List<String>();

            try
            {
            //Respuesta de la consulta hecha a la Base de Datos
            SqlDataReader respuesta;

            //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
            this.instruccion = new SqlCommand(RecursosBaseDeDatosModulo7.PROCEDIMIENTO_SELECCIONAR_CARGOS, this.conexion);
            this.instruccion.CommandType = CommandType.StoredProcedure;

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
                    //Actor aux = new Actor(respuesta.GetInt32(2), respuesta.GetString(0), respuesta.GetString(1));
                    //listaActores.Add(aux);

                    //Llenamos la lista
                    cargos.Add(respuesta.GetString(0));

                }

            //Cerramos conexion
            this.conexion.Close();
            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al Listar", error);
            }

            //Retornamos la respuesta
            return cargos;
        }
    }
}
