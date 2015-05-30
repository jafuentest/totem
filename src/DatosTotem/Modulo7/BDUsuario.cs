using DatosTotem.Modulo1;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DatosTotem.Modulo7
{
    public class BDUsuario
    {
        public BDUsuario()
        {

        }
        /// <summary>
        /// Registra un Usuario nuevo en la base de datos
        /// </summary>
        /// <param name="elUsuario">El usuario que se registrara</param>
        /// <returns>returna true en caso de que se completara el registro, y false en caso de que no</returns>
        public Boolean RegitrarUsuario(Usuario elUsuario)
        {
            Boolean exito;
            BDConexion conexionBD = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            try{
            Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    SqlDbType.VarChar, elUsuario.username, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar, elUsuario.clave, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario,
                    SqlDbType.VarChar, elUsuario.nombre, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    SqlDbType.VarChar, elUsuario.apellido, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.RolUsuario,
                    SqlDbType.VarChar, elUsuario.rol, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario,
                    SqlDbType.VarChar, elUsuario.correo, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.PreguntaUsuario,
                    SqlDbType.VarChar, elUsuario.preguntaSeguridad, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.RespuestaUsuario,
                    SqlDbType.VarChar, elUsuario.respuestaSeguridad, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.CargoUsuario,
                    SqlDbType.VarChar, elUsuario.cargo,false);
            parametros.Add(parametro);
            string query = RecursosBaseDeDatosModulo7.ProcedimientoInsertarUsuario;
            //conexionBD.Conectar();
            List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query,parametros);
            }
            catch(SqlException){
                return false;
            }
            return true;
        }
        /// <summary>
        /// Obtiene el cargo perteneciente a un usuario
        /// </summary>
        /// <param name="cargoUsuario">La clave foranea del cargo del usuario</param>
        /// <returns>returna el cargo del usuario a consultar</returns>
        public String ObtenerCargo(String userName)
        {
            SqlDataReader resultadoConsulta;
            BDConexion conexionBd = new BDConexion();
            String nombreCargo;
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery(RecursosBaseDeDatosModulo7.QueryObtenerCargo + userName);
            conexionBd.Desconectar();
            if (resultadoConsulta.Read())
                nombreCargo = resultadoConsulta.GetValue(0).ToString();
            else
                nombreCargo = "";
            return nombreCargo;
        }
        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="userName">Se busca por el username del usuario</param>
        /// <returns>Regresa un usuario</returns>
        public Usuario ConsultarUsuario(String userName)
        {

            SqlDataReader resultadoConsulta;
            BDConexion conexionBd = new BDConexion();
            Usuario usuario;
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery(RecursosBaseDeDatosModulo7.queryObtenerUsuario + userName);
            conexionBd.Desconectar();
            if (resultadoConsulta.Read())
                usuario = new Usuario(resultadoConsulta.GetInt32(0), 
                                     resultadoConsulta.GetString(1), 
                                     resultadoConsulta.GetString(2), 
                                     resultadoConsulta.GetString(3), 
                                     resultadoConsulta.GetString(4), 
                                     resultadoConsulta.GetString(5), 
                                     resultadoConsulta.GetString(6), 
                                     resultadoConsulta.GetString(7), 
                                     resultadoConsulta.GetString(8), 
                                     resultadoConsulta.GetString(9));
            else
                usuario = null;
            return usuario;
        }
        /// <summary>
        /// Verifica que la respuesta de seguridad sea correcta
        /// </summary>
        /// <param name="userName">El username del usuario</param>
        /// <param name="preguntaUsuario">la  pregunta del usuario</param>
        /// <param name="respuestaUsuario">la respuesta del usuario</param>
        /// <returns>returna true en caso de que la pregunta y a respuesta concuerde con lo que esta en la base de datos y false en caso de que no coincida</returns>
        public Boolean ConsultaPregunta(String userName, String preguntaUsuario, String respuestaUsuario)
        {
            SqlDataReader resultadoConsulta;
            BDConexion conexionBd = new BDConexion();
            Boolean valorResultado = false;
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery("SELECT * FROM USUARIO WHERE usu_username=" + userName + " AND usu_pregseguridad=" + preguntaUsuario + " AND usu_respseguridad=" + preguntaUsuario);
            conexionBd.Desconectar();
            if (resultadoConsulta.HasRows)
                valorResultado = true;
            else
                valorResultado = false;
            return valorResultado;
        }
        /// <summary>
        /// Procedimiento para obtener todos los usuarios que estan ocupando un cargo
        /// </summary>
        /// <param name="cargo">El nombre del cargo a buscar</param>
        /// <returns>Returna una lista con todos los usuarios que tiene el cargo</returns>
        public List<Usuario> ConsultaUsuariosSegunCargo(String cargo)
        {
            SqlDataReader resultadoConsulta;
            List<Usuario> listUsuario = new List<Usuario>();
            BDConexion conexionBd = new BDConexion();
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery("SELECT * FROM USUARIO WHERE CARGO_car_id=(SELECT car_id FROM CARGO WHERE car_nombre=" +cargo+")");
            conexionBd.Desconectar();
            while(resultadoConsulta.Read()){
                listUsuario.Add(new Usuario(resultadoConsulta.GetInt32(0), resultadoConsulta.GetValue(1).ToString(), resultadoConsulta.GetValue(2).ToString(), resultadoConsulta.GetValue(3).ToString(), resultadoConsulta.GetValue(4).ToString(), resultadoConsulta.GetValue(5).ToString(), resultadoConsulta.GetValue(6).ToString(), resultadoConsulta.GetValue(7).ToString(), resultadoConsulta.GetValue(8).ToString(), resultadoConsulta.GetValue(9).ToString()));
            }
            return listUsuario;
        }
        /// <summary>
        /// Procedimiento para obtener todos los usuarios registrados en el sistema
        /// </summary>
        /// <returns>Returna una lista con todos los usuarios que hay en el sistema</returns>
        public List<Usuario> ObtenerListaUsuario()
        {
            SqlDataReader resultadoConsulta;
            List<Usuario> listUsuario = new List<Usuario>();
            BDConexion conexionBd = new BDConexion();
            resultadoConsulta = conexionBd.EjecutarQuery(RecursosBaseDeDatosModulo7.QueryListarUsuario);
            while (resultadoConsulta.Read())
            {
                listUsuario.Add(new Usuario(resultadoConsulta.GetInt32(0), 
                                            resultadoConsulta.GetValue(1).ToString(), 
                                            resultadoConsulta.GetValue(2).ToString(), 
                                            resultadoConsulta.GetValue(3).ToString(), 
                                            resultadoConsulta.GetValue(4).ToString(), 
                                            resultadoConsulta.GetValue(5).ToString(), 
                                            resultadoConsulta.GetValue(6).ToString(), 
                                            resultadoConsulta.GetValue(7).ToString(), 
                                            resultadoConsulta.GetValue(8).ToString(), 
                                            resultadoConsulta.GetValue(9).ToString()));
            }
            return listUsuario;
        }
        /// <summary>
        /// Permite consultar la informacion de un usuario, segun su nombre, apellido y cargo
        /// </summary>
        /// <param name="nombre">El nombre del usuario que se desea consultar</param>
        /// <param name="apellido">El apellido del usuario que se desea consultar </param>
        /// <param name="cargo">El cargo del usuario que se desea consultar</param>
        /// <returns>Returna el usuario que a consultar</returns>
        public Usuario ConsultarDatosUsuario(String nombre, String apellido, String cargo)
        {
            SqlDataReader resultadoConsulta;
            Usuario usuario = new Usuario();
            BDConexion conexionBd = new BDConexion();
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery("SELECT * FROM USUARIO WHERE usu_nombre ="+nombre+"AND usu_apellido="+apellido+" CARGO_car_id=(SELECT car_id FROM CARGO WHERE car_nombre=" + cargo + ")");
            conexionBd.Desconectar();
            if(resultadoConsulta.Read())
            {
                usuario = new Usuario(resultadoConsulta.GetInt32(0),
                                     resultadoConsulta.GetString(1),
                                     resultadoConsulta.GetString(2),
                                     resultadoConsulta.GetString(3),
                                     resultadoConsulta.GetString(4),
                                     resultadoConsulta.GetString(5),
                                     resultadoConsulta.GetString(6),
                                     resultadoConsulta.GetString(7),
                                     resultadoConsulta.GetString(8),
                                     resultadoConsulta.GetString(9));
            }
            return usuario;
        }
        /// <summary>Valida si el username existe o no en la BD</summary>
        /// <param name="userName">Se busca por el username del usuario a registrar</param>
        /// <returns>Regresa true si existe y false si no existe el username</returns>
        public Boolean usernameUnico(String userName)
        {
             Boolean exito = false;
         
            List<Parametro> parametros = new List<Parametro>();
            try
            {
                Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                        SqlDbType.VarChar, userName, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.Resultadorepetido,
                        SqlDbType.VarChar, true);
                parametros.Add(parametro);
                string query = RecursosBaseDeDatosModulo7.ProcedimientoUsuarioUnico;
                BDConexion conexionBD = new BDConexion();
                List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query, parametros);
                if (resultados[0].valor == "")
                    exito = true;
                else
                    exito = false;
            }
            catch (SqlException)
            {
                exito = false;

            }
            return exito;
        }
        /// <summary>
        /// Metodo para validar el inicio de sesion en la base de datos
        /// Excepciones posibles: 
        /// LoginErradoException: Excepcion de login invalido
        /// ExceptionTotemConexionBD: Excepcion de base de datos sql server
        /// ParametroInvalidoException: Excepcion de parametros erroneos
        /// UsuarioVacioException: Excepcion si alguna de la informacion del usuario
        /// es vacia o incorrecta
        /// </summary>
        /// <param name="user">Usuario al que se le va a validar el inicio de sesion
        /// debe tener como minimo el nombre de usuario o email y contrasena</param>
        /// <returns>Retorna el objeto usuario si se pudo validar</returns>
        public Usuario DatosUsuario(Usuario user)
        {
            if (user.username != null  && user.username != "")
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    SqlDbType.VarChar, user.username, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.RolUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.PreguntaUsuario,
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.RespuestaUsuario,
                SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.CargoUsuario,
                SqlDbType.VarChar, true);
                parametros.Add(parametro);
                try
                {
                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(
                        RecursosBaseDeDatosModulo7.ProcedimientoObtenerUsuario, parametros);
                   
                        foreach (Resultado resultado in resultados)
                        {
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.NombreUsuario))
                            {
                                user.nombre = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.ApellidoUsuario))
                            {
                                user.apellido = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.RolUsuario))
                            {
                                user.rol = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.CorreoUsuario))
                            {
                                user.correo = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.CargoUsuario))
                            {
                                user.cargo = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.PreguntaUsuario))
                            {
                                user.preguntaSeguridad = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBaseDeDatosModulo7.RespuestaUsuario))
                            {
                                user.respuestaSeguridad = resultado.valor;
                            }
                        }                             
                        return user;
                   
                }
                catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.LoginErradoException(ex.Codigo,
                        ex.Mensaje, ex);
                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                
            }
            else
            {
                throw new UsuarioVacioException(
                    RecursosBDModulo1.Codigo_Usuario_Vacio,
                    RecursosBDModulo1.Mensaje_Usuario_Vacio, new Exception());
            }
        }
        /// <summary>Verifica si un correo existe o no en la BD</summary>
        /// <param name="correo">Se busca por el correo del usuario</param>
        /// <returns>Regresa true si existe y false si no existe el correo</returns>
        public Boolean correoUnico(string correoUsuario)
        {
            Boolean exito = false;

            List<Parametro> parametros = new List<Parametro>();
            try
            {
                Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario,
                        SqlDbType.VarChar, correoUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBaseDeDatosModulo7.Resultadorepetido,
                        SqlDbType.VarChar, true);
                parametros.Add(parametro);
                string query = RecursosBaseDeDatosModulo7.ProcedimientoCorreoUnico;
                BDConexion conexionBD = new BDConexion();
                List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query, parametros);
                if (resultados[0].valor == "")
                    exito = true;
                else
                    exito = false;
            }
            catch (SqlException)
            {
                exito = false;

            }
            return exito;
        }       
      
        /// <summary>
        /// Modifica los datos del usuario
        /// </summary>
        /// <param name="edUsuario">El usuario que se modificara en la base de datos</param>
        /// <returns>returna true en caso de que el usuario se modifique y false en caso de que no</returns>
        public Boolean ModificarUsuario(Usuario elUsuario)
        {
            Boolean exito;
            BDConexion conexionBD = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    SqlDbType.VarChar, elUsuario.username, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar, elUsuario.clave, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario,
                    SqlDbType.VarChar, elUsuario.nombre, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    SqlDbType.VarChar, elUsuario.apellido, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.RolUsuario,
                    SqlDbType.VarChar, elUsuario.rol, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.CorreoUsuario,
                    SqlDbType.VarChar, elUsuario.correo, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.PreguntaUsuario,
                    SqlDbType.VarChar, elUsuario.preguntaSeguridad, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.RespuestaUsuario,
                    SqlDbType.VarChar, elUsuario.respuestaSeguridad, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.CargoUsuario,
                    SqlDbType.VarChar, elUsuario.cargo, false);
            parametros.Add(parametro);
            string query = RecursosBaseDeDatosModulo7.ProcedimientoModificarUsuario;
            conexionBD.Conectar();
            List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query, parametros);
            if (resultados != null)
                exito = true;
            else
                exito = false;
            return exito;
        }
        /// <summary>
        /// Consulta la clave de un usuario
        /// </summary>
        /// <param name="userName">El nombre de usuario a buscar</param>
        /// <returns>returna true en caso de que el usuario se modifique y false en caso de que no</returns>
        public string ConsultarClaveUsuario(string userName)
        {
            Boolean exito;
            string claveUsuario = "";
            BDConexion conexionBD = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    SqlDbType.VarChar, userName, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar,  true);
            parametros.Add(parametro);
            string query = RecursosBaseDeDatosModulo7.ConsultarClaveUsuario;
            List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query, parametros);
            claveUsuario = resultados[0].valor;
            return claveUsuario;
        }

        /// <summary>
        /// Procedimiento para obtener todos los cargos de los usuarios.</summary> 
        /// <returns>Returna una lista con todos los cargos de los usuarios</returns>
        public List<String> ConsultaCargos()
        {
            SqlDataReader resultadoConsulta;
            List<String> listCargos = new List<String>();
            BDConexion conexionBd = new BDConexion();
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery(RecursosBaseDeDatosModulo7.QueryCargosUsuarios);
            conexionBd.Desconectar();
            while (resultadoConsulta.Read())
            {
                listCargos.Add(resultadoConsulta.GetValue(0).ToString());
            }
            return listCargos;
        }

        public List<String> LeerCargosUsuarios()
        {
            List<String> laLista = new List<String>();
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas("seleccionarCargosUsuarios", parametros);
                foreach (DataRow row in dt.Rows)
                {
                    laLista.Add(row["nombreCargo"].ToString());
                }

            }
            catch (Exception ex)
            {

            }
            return laLista;
        }
        public List<Usuario> listarUsuariosPorCargo(String elCargo)
        {
            List<Usuario> laLista = new List<Usuario>();
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@cargo", SqlDbType.VarChar, elCargo, false));
            try
            {
                laConexion = new BDConexion();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas("ListarUsuariosPorCargo", parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Usuario u = new Usuario();
                    u.apellido = row["usuarioApellido"].ToString();
                    u.nombre = row["usuarioNombre"].ToString();
                    u.username = row["usuarioUsername"].ToString();
                    u.idUsuario = int.Parse(row["usuarioID"].ToString());
                    u.cargo = row["cargoNombre"].ToString();
                    laLista.Add(u);
                }
            }
            catch (Exception ex)
            {

            }
            return laLista;
        }
    
    }
}
