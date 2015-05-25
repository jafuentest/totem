using DominioTotem;
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
            Parametro parametro = new Parametro(RecursosBaseDeDatosModulo7.UsernameUsuario,
                    SqlDbType.VarChar, elUsuario.username, false);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar, elUsuario.clave, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario,
                    SqlDbType.VarChar, elUsuario.nombre, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    SqlDbType.VarChar, elUsuario.apellido, false);
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
            string query = RecursosBaseDeDatosModulo7.ProcedimientoInsertarUsuario;
            conexionBD.Conectar();
            List<Resultado> resultados = conexionBD.EjecutarStoredProcedure(query,parametros);
            if (resultados != null)
                exito = true;
            else
                exito = false;
            return false;
        }
        /// <summary>
        /// Obtiene el cargo perteneciente a un usuario
        /// </summary>
        /// <param name="cargoUsuario">La clave foranea del cargo del usuario</param>
        /// <returns>returna el cargo del usuario a consultar</returns>
        public String ObtenerCargo(int cargoUsuario)
        {
            SqlDataReader resultadoConsulta;
            BDConexion conexionBd = new BDConexion();
            String nombreCargo;
            conexionBd.Conectar();
            resultadoConsulta = conexionBd.EjecutarQuery(RecursosBaseDeDatosModulo7.QueryObtenerCargo + cargoUsuario);
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
                usuario = new Usuario(resultadoConsulta.GetInt32(0), resultadoConsulta.GetString(1), resultadoConsulta.GetString(2), resultadoConsulta.GetString(3), resultadoConsulta.GetString(4), resultadoConsulta.GetString(5), resultadoConsulta.GetString(6), resultadoConsulta.GetString(7), resultadoConsulta.GetString(8), resultadoConsulta.GetString(9));
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
        public Boolean ConsultaPregunta(int userName, String preguntaUsuario, String respuestaUsuario)
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
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ClaveUsuario,
                    SqlDbType.VarChar, elUsuario.clave, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.NombreUsuario,
                    SqlDbType.VarChar, elUsuario.nombre, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBaseDeDatosModulo7.ApellidoUsuario,
                    SqlDbType.VarChar, elUsuario.apellido, false);
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
            return false;
        }

    }
}
