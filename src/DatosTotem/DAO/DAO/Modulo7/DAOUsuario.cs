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
using Dominio.Fabrica;
using ExcepcionesTotem;
using DAO;
using ExcepcionesTotem.Modulo7;

namespace DAO.DAO.Modulo7
{
	#region Teddy
    /// <summary>
    /// Clase DAO que interactua con la BD y realiza las operaciones del Usuario
    /// </summary>
    public class DAOUsuario : DAO, IDaoUsuario
    {
        //Conexion hacia la base de Datos y la instruccion (Consulta) que se le hara
        private SqlConnection conexion;
        private SqlCommand instruccion;

        /// <summary>
        /// Constructor de la clase DAO que instancia una conexion nueva con la Base de Datos
        /// </summary>
        public DAOUsuario()
        {
            try
            {
               //Sino existe conexion se hace una nueva indicando la ruta donde esta la BD con el Configuration Manager
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
            bool exito;

            try
            {

            /*Creamos una lista de parametros y le agregamos los valores correspondientes 
            a las variables de stored procedure*/
            List<Parametro> listaParametros = new List<Parametro>();
            Parametro parametroConsulta;
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,SqlDbType.VarChar
                ,elUsuario.Username,false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario, SqlDbType.VarChar
               , elUsuario.Clave, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario, SqlDbType.VarChar
               , elUsuario.Nombre, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario, SqlDbType.VarChar
               , elUsuario.Apellido, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.RolUsuario, SqlDbType.VarChar
               , elUsuario.Rol, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario, SqlDbType.VarChar
               , elUsuario.Correo, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.PreguntaUsuario, SqlDbType.VarChar
               , elUsuario.PreguntaSeguridad, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.RespuestaUsuario, SqlDbType.VarChar
               , elUsuario.RespuestaSeguridad, false);
            listaParametros.Add(parametroConsulta);
            parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.CargoUsuario, SqlDbType.VarChar
               , elUsuario.Cargo, false);
            listaParametros.Add(parametroConsulta);
            
            //Obtenemos las filas alteradas de la insercion
            int resultado = EjecutarStoredProcedureAlteraFilas(RecursosBaseDeDatosModulo7.ProcedimientoInsertarUsuario,
                listaParametros);
            
            //Si el resultado da mayor a cero significa que se agrego un usuario
            if (resultado > 0)
                exito = true;
            else
                exito = false;

            //Retornamos el exito o fallo de la insercion
            return exito;
            }
            catch(SqlException e)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Metodo que valida si el username ya existe en la Base de Datos
        /// </summary>
        /// <param name="username">El username que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso sino es valido</returns>
        public bool ValidarUsernameUnico (String username)
        {
            //Indicaremos si se encontro o no el username en la BD
            bool valido;

            try
            {
                /*Creamos una lista de parametros y le agregamos los valores correspondientes 
                a las variables de stored procedure*/
                List<Parametro> listaParametros = new List<Parametro>();
                Parametro parametroConsulta;
                parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,SqlDbType.VarChar,
                    username,false);
                listaParametros.Add(parametroConsulta);
                parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.Resultadorepetido, SqlDbType.VarChar, true);
                listaParametros.Add(parametroConsulta);

                //Ejecutamos el stored procedure y obtenemos el output
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosBaseDeDatosModulo7.ProcedimientoUsuarioUnico,
                    listaParametros);

                //Sino existe el username en la Base de Datos entonces es valido agregarlo
                if (resultado[0].valor == "")
                    valido = true;
                else
                    valido = false;

                return valido;
                
            }
            catch(Exception e)
            {
                throw new Exception();
            }
       }

        /// <summary>
        /// Metodo que valida si el correo que se desea registrar ya existe o no en la Base de Datos
        /// </summary>
        /// <param name="correo">El correo que se desea registrar</param>
        /// <returns>Verdadero si es valido o falso si ya existe en la Base de Datos</returns>
        public bool ValidarCorreoUnico (String correo)
        {
            //Indicaremos si se encontro o no el correo en la BD
            bool valido;

            try
            {
                /*Creamos una lista de parametros y le agregamos los valores correspondientes 
                a las variables de stored procedure*/
                List<Parametro> listaParametros = new List<Parametro>();
                Parametro parametroConsulta;
                parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario, SqlDbType.VarChar,
                    correo, false);
                listaParametros.Add(parametroConsulta);
                parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.Resultadorepetido, SqlDbType.VarChar, true);
                listaParametros.Add(parametroConsulta);

                //Ejecutamos el stored procedure y obtenemos el output
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosBaseDeDatosModulo7.ProcedimientoCorreoUnico,
                    listaParametros);

                //Sino existe el username en la Base de Datos entonces es valido agregarlo
                if (resultado[0].valor == "")
                    valido = true;
                else
                    valido = false;

                return valido;

            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Metodo que interactua con la Base de Datos y obtiene todos los cargos de la Base de Datos
        /// </summary>
        /// <returns>La lista con todos los cargos encontrados en la Base de Datos</returns>
        public List<string> ListarCargos()
        {
            //Lista que sera la respuesta de la consulta;
            List<String> cargos = new List<String>();

            //Parametros que tendra
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                //Recibimos la respuesta de la consulta
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBaseDeDatosModulo7.PROCEDIMIENTO_SELECCIONAR_CARGOS,
                    parametros);

                if (dt.Rows.Count >= 1 )
                {
                    //Recorremos el data table y asignamos cada cargo a la lista
                    foreach (DataRow fila in dt.Rows)
                    {
                        cargos.Add(fila[RecursosBaseDeDatosModulo7.CARGO_NOMBRE].ToString());
                    }

                    //Devolvemos la lista con los cargos
                    return cargos;
                }
                Logger.EscribirError(this.GetType().Name,new CargosNoExistentesException());
                throw new CargosNoExistentesException(RecursosBaseDeDatosModulo7.EXCEPTION_CARGOS_INEXISTENTES_CODIGO, 
                 RecursosBaseDeDatosModulo7.EXCEPTION_CARGOS_INEXISTENTES_MENSAJE, new CargosNoExistentesException());
            }
            catch (SqlException e)
            {
                //Si hay error en la Base de Datos escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotemConexionBD());
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, e);
            }
            catch (Exception e)
            {
                //Si existe un error inesperado escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotem());
                throw new ExceptionTotem(RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_MENSAJE,e);
            }
            
        }

        /// <summary>
        /// Metodo que consultara en la Base de Datos todos los usuarios y los devolvera en una lista
        /// </summary>
        /// <returns>Lista con todos los usuarios obtenidos de la Base de Datos</returns>
        public List<Entidad> ListarUsuarios()
        {
            //Lista que sera la respuesta de la consulta;
            List<Entidad> usuarios = new List<Entidad>();

            //Instanciamos la fabrica concreta de Entidades
            FabricaEntidades fabrica = new FabricaEntidades();

            //Parametros que tendra
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                //Recibimos la respuesta de la consulta
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBaseDeDatosModulo7.ProcedimientoListarUsuario,
                    parametros);

                //Recorremos el data table, crearmos el usuario con sus datos y asignamos cada usuario a la lista
                foreach (DataRow fila in dt.Rows)
                 {
                     Entidad aux = fabrica.ObtenerUsuario(fila[RecursosBaseDeDatosModulo7.UsernameNombre].ToString(),
                         fila[RecursosBaseDeDatosModulo7.NombreUsu].ToString(),
                         fila[RecursosBaseDeDatosModulo7.ApellidoUsu].ToString(),
                         fila[RecursosBaseDeDatosModulo7.CargoNombre].ToString());
                     usuarios.Add(aux);
                 }

            }
            catch (SqlException e)
            {
                //Si hay error en la Base de Datos escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotemConexionBD());
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, e);
            }
            catch (Exception e)
            {
                //Si existe un error inesperado escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotem());
                throw new ExceptionTotem(RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_MENSAJE, e);
            }
            
            //Retornamos la lista con los usuarios
            return usuarios;
        }

        /// <summary>
        /// Metodo que ejecuta la consulta para eliminar un usuario de la Base de Datos
        /// </summary>
        /// <param name="username">El usuario que se desea eliminar</param>
        /// <returns>Verdadero si se pude eliminar, falso sino se pudo</returns>
        public bool EliminarUsuario(String username)
        {
            //Exito o fallo de la eliminacion
            bool exito;

            //Lista de los parametros del query
            List<Parametro> listaParametros = new List<Parametro>();

            //Si el username tiene un valor valido
            if(username != null)
            {
                //Creamos un nuevo parametro y lo agregamos a la lista
                Parametro aux = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario, SqlDbType.VarChar, username,
                    false);
                listaParametros.Add(aux);
            }
            else
            {
                //Escribimos el error y Lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name,new UsernameVacioException());
                throw new UsernameVacioException(RecursosBaseDeDatosModulo7.EXCEPTION_USUARIO_VACIO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_USUARIO_VACIO_MENSAJE,new UsernameVacioException());
            }
                
            try
            {
                //Ejecutamos la consulta
                int resultadoQuery = EjecutarStoredProcedureAlteraFilas(
                    RecursosBaseDeDatosModulo7.ProcedimientoEliminarUsuario, listaParametros);

                //Si el resultado da mayor a cero significa que se elimino un usuario
                if (resultadoQuery > 0)
                    exito = true;
                else
                    exito = false;

                //Retornamos la respuesta
                return exito;
            }
            catch (SqlException e)
            {
                //Si hay error en la Base de Datos escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotemConexionBD());
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, e);
            }
            catch (Exception e)
            {
                //Si existe un error inesperado escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotem());
                throw new ExceptionTotem(RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_MENSAJE,e);
            }
        }

        #region Metodos que usan M3
        /// <summary>
        /// Metodo que se conecta con la Base de Datos para traer todos los Usuarios segun un cargo en especifico
        /// </summary>
        /// <param name="cargo">El cargo del que se desea obtener los usuarios</param>
        /// <returns>Todos los usuarios que ocupan ese cargo</returns>
        public List<Entidad> ListarUsuariosPorCargo(String cargo)
        {
            //Lista que sera la respuesta de la consulta;
            List<Entidad> usuarios = new List<Entidad>();

            //Instanciamos la fabrica concreta de Entidades
            FabricaEntidades fabrica = new FabricaEntidades();

            //Parametros que tendra
            List<Parametro> listaParametros = new List<Parametro>();

            //El parametro como tal
            Parametro parametroConsulta;

            try
            {
                //Le agregamos el parametro de la consulta y lo agregamos a la lista
                parametroConsulta = new Parametro(RecursosBaseDeDatosModulo7.CargosUsuarios,SqlDbType.VarChar,cargo,
                    false);
                listaParametros.Add(parametroConsulta);

                //Recibimos la respuesta de la consulta
              DataTable dt = EjecutarStoredProcedureTuplas(RecursosBaseDeDatosModulo7.PROCEDIMIENTO_USUARIOS_POR_CARGO,
                    listaParametros);

                //Recorremos el data table, crearmos el usuario con sus datos y asignamos cada usuario a la lista
                foreach (DataRow fila in dt.Rows)
                {
                    Entidad aux = fabrica.ObtenerUsuario(fila["usuarioUsername"].ToString(),
                        fila["usuarioNombre"].ToString(),
                        fila["usuarioApellido"].ToString(),
                        fila["cargoNombre"].ToString());
                    aux.Id = int.Parse(fila["usuarioID"].ToString());
                    usuarios.Add(aux);
                }

                //Retornamos la lista con los usuarios
                return usuarios;

            }
            catch (SqlException e)
            {
                //Si hay error en la Base de Datos escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotemConexionBD());
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, e);
            }
            catch (Exception e)
            {
                //Si existe un error inesperado escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotem());
                throw new ExceptionTotem(RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_MENSAJE, e);
            }
       }

        /// <summary>
        /// Metodo que ejecuta la consulta de leer todos los cargos de la BD si y solo si ese cargo lo tiene al menos un usuario
        /// </summary>
        /// <returns>Todos los cargos listados de la Base de Datos</returns>
        public List<String> LeerCargosUsuarios()
        {
            //Lista que sera la respuesta de la consulta;
            List<String> cargos = new List<String>();

            //Parametros que tendra
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                //Recibimos la respuesta de la consulta
                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBaseDeDatosModulo7.PROCEDIMIENTO_CARGOS_USUARIOS,
                    parametros);

               //Recorremos el data table y asignamos cada cargo a la lista
               foreach (DataRow fila in dt.Rows)
               {
                   cargos.Add(fila["nombreCargo"].ToString());
               }

               //Devolvemos la lista con los cargos
               return cargos;
            }
            catch (SqlException e)
            {
                //Si hay error en la Base de Datos escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotemConexionBD());
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, e);
            }
            catch (Exception e)
            {
                //Si existe un error inesperado escribimos en el logger y lanzamos la excepcion
                Logger.EscribirError(this.GetType().Name, new ExceptionTotem());
                throw new ExceptionTotem(RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_CODIGO,
                    RecursosBaseDeDatosModulo7.EXCEPTION_INESPERADO_MENSAJE, e);
            }

            

            /*
            try
            {
                //Respuesta de la consulta hecha a la Base de Datos
                SqlDataReader respuesta;

                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.instruccion = new SqlCommand("seleccionarCargosUsuarios", this.conexion);
                this.instruccion.CommandType = CommandType.StoredProcedure;

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron obtenidas
                respuesta = instruccion.ExecuteReader();

                //Si se encontraron cargos se comienzan a agregar a la variable lista, sino, se devolvera vacia
                if (respuesta.HasRows)
                    //Recorremos cada fila devuelta de la consulta
                    while (respuesta.Read())
                    {
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
            return cargos;*/
        }
       #endregion
       #endregion

		#region Juan
		public bool Modificar(Entidad parametro)
		{
			bool modificado = false;
			try
			{
				Usuario usuario = parametro as Usuario;
				if (usuario != null)
				{
					List<Parametro> parametros = parametrosModificarUsuario(usuario);
					List<Resultado> resultados = base.EjecutarStoredProcedure
						(RecursosBaseDeDatosModulo7.ProcedimientoModificarUsuario, parametros);
				}
				else
				{
					throw new Exception("El objeto usado no es una instancia de la clase Usuario");
				}
			}
			catch (ExceptionTotem e)
			{
				throw e;
			}

			return modificado;
		}

		public Entidad ConsultarPorUsername(Entidad parametro)
		{
			try
			{
				Usuario usuario = (Usuario) parametro;
				List<Parametro> parametros = parametrosDetalleUsuario(usuario);
				List<Resultado> resultados = EjecutarStoredProcedure(
					RecursosBaseDeDatosModulo7.ProcedimientoConsultarUsername, parametros);

				if (resultados == null)
				{
					throw new Exception("No se encontró el usuario");
				}
				else
				{
					foreach (Resultado resultado in resultados)
					{
						if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.NombreUsuario))
							usuario.Nombre = resultado.valor;
						else if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.ApellidoUsuario))
							usuario.Apellido = resultado.valor;
						else if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.CorreoUsuario))
							usuario.Correo = resultado.valor;
						else if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.RolUsuario))
							usuario.Rol = resultado.valor;
						else if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.UsernameUsuario))
							usuario.Username = resultado.valor;
						else if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.CargoUsuario))
							usuario.Cargo = resultado.valor;
					}
				}

				return usuario;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		private List<Parametro> parametrosModificarUsuario(Usuario usuario)
		{
			List<Parametro> parametros = new List<Parametro>();

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.IdUsuario, SqlDbType.Int, usuario.Id.ToString(), false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.UsernameUsuario, SqlDbType.VarChar, usuario.Username, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.ClaveUsuario, SqlDbType.VarChar, usuario.Clave, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.NombreUsuario, SqlDbType.VarChar, usuario.Nombre, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.ApellidoUsuario, SqlDbType.VarChar, usuario.Apellido, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.RolUsuario, SqlDbType.VarChar, usuario.Rol, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.CorreoUsuario, SqlDbType.VarChar, usuario.Correo, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.PreguntaUsuario, SqlDbType.VarChar, usuario.PreguntaSeguridad, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.RespuestaUsuario, SqlDbType.VarChar, usuario.RespuestaSeguridad, false
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.IdCargoUsuario, SqlDbType.Int, usuario.IdCargo.ToString(), false
			));

			return parametros;
		}

		private List<Parametro> parametrosDetalleUsuario(Usuario usuario)
		{
			List<Parametro> parametros = new List<Parametro>();

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.UsernameUsuario, SqlDbType.VarChar, usuario.Username, false
			)); 
			
			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.IdUsuario, SqlDbType.Int, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.ClaveUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.NombreUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.ApellidoUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.RolUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.CorreoUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.PreguntaUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.RespuestaUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.CargoUsuario, SqlDbType.VarChar, true
			));

			parametros.Add(new Parametro(
				RecursosBaseDeDatosModulo7.IdCargoUsuario, SqlDbType.Int, true
			));

			return parametros;
		}

		public bool Agregar(Entidad parametro)
		{
			throw new NotImplementedException();
		}

		public Entidad ConsultarXId(Entidad parametro)
		{
			throw new NotImplementedException();
		}

		public List<Entidad> ConsultarTodos()
		{
			throw new NotImplementedException();
		}
        #endregion
	}
}
