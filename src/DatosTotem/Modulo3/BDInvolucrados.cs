using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosTotem.Modulo3
{
    public static class BDInvolucrados
    {
        /// <summary>
        /// Metodo que agrega la lista de usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de usuarios a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarUsuariosInvolucrados(ListaInvolucradoUsuario listaUsuarios)
        {
            int filasA, filasD;
            Proyecto elProyecto = listaUsuarios.Proyecto;
            List<Parametro> parametros, parametrosContar;

            Parametro paramProyectoCod, paramUsername, paramFilas;
            BDConexion laConexion = new BDConexion();

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);

            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);

            foreach (Usuario elUsuario in listaUsuarios.Lista)
            {
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, 
                        elProyecto.Codigo, false);
                    paramUsername = new Parametro(RecursosBDModulo3.ParamUsername, SqlDbType.VarChar, 
                        elUsuario.username, false);

                    parametros.Add(paramUsername);
                    parametros.Add(paramProyectoCod);

                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarUsuario, parametros);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                            RecursosBDModulo3.Codigo_Involucrado_Repetido, 
                            RecursosBDModulo3.Mensaje_Involucrado_Repetido, ex);
                    else
                        throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }

            }

            laConexion = new BDConexion();

            resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
            filasD = int.Parse(resultado[0].valor);

            if (filasD > filasA)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo que agrega la lista de contactos involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de contactos a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarContactosInvolucrados(ListaInvolucradoContacto listaContactos)
        {
            int filasA, filasD;
            Proyecto elProyecto = listaContactos.Proyecto;
            List<Parametro> parametros, parametrosContar;
            
            Parametro paramProyectoCod, paramContactoID, paramFilas; 
            BDConexion laConexion = new BDConexion();

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);

            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);

            foreach (Contacto elContacto in listaContactos.Lista)
            {
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, 
                        elProyecto.Codigo, false);
                    paramContactoID = new Parametro(RecursosBDModulo3.ParamContID, SqlDbType.Int, 
                        elContacto.Con_Id.ToString(), false);

                    parametros.Add(paramContactoID);
                    parametros.Add(paramProyectoCod);

                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarCliente, parametros);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                            RecursosBDModulo3.Codigo_Involucrado_Repetido,
                            RecursosBDModulo3.Mensaje_Involucrado_Repetido, ex);
                    else
                        throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                }
            }

            laConexion = new BDConexion();
            resultado = null;

            resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente, parametrosContar);
            System.Diagnostics.Debug.WriteLine(resultado[0]);
            filasD = int.Parse(resultado[0].valor);

            if (filasD > filasA)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo que consulta los usuarios involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de usuarios involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoUsuario consultarUsuariosInvolucradosPorProyecto(Proyecto p)
        {
            BDConexion laConexion;
            ListaInvolucradoUsuario laListaDeUsuarios = new ListaInvolucradoUsuario();
            List<Parametro> parametros;
            Parametro codigoProyecto;

            List<Usuario> lUsuarios = new List<Usuario>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                codigoProyecto = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, p.Codigo, false);

                parametros.Add(codigoProyecto);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarUsuario, 
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Usuario u = new Usuario();
                    u.idUsuario = int.Parse(row[RecursosBDModulo3.aliasUsuarioID].ToString());
                    u.nombre = row[RecursosBDModulo3.aliasUsuarioNombre].ToString();
                    u.apellido = row[RecursosBDModulo3.aliasUsuarioApellido].ToString();
                    u.cargo = row[RecursosBDModulo3.aliasCargoNombre].ToString();
                    lUsuarios.Add(u);
                }
                laListaDeUsuarios = new ListaInvolucradoUsuario(lUsuarios, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            return laListaDeUsuarios;
        }
        /// <summary>
        /// Metodo que consulta los contactos involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de contactos involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoContacto consultarContactosInvolucradosPorProyecto(Proyecto p)
        {
            BDConexion laConexion;
            ListaInvolucradoContacto laListaDeContactos = new ListaInvolucradoContacto();
            List<Parametro> parametros;
            Parametro codigoProyecto;

            List<Contacto> lContactos = new List<Contacto>();
            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                codigoProyecto = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, p.Codigo, false);

                parametros.Add(codigoProyecto);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarContacto,
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Contacto c     = new Contacto();
                    c.Con_Id       = int.Parse(row[RecursosBDModulo3.aliasContactoID].ToString());
                    c.Con_Nombre   = row[RecursosBDModulo3.aliasContactoNombre].ToString();
                    c.Con_Apellido = row[RecursosBDModulo3.aliasContactoApellido].ToString();
                    c.ConCargo     = row[RecursosBDModulo3.aliasCargoNombre].ToString();

                    lContactos.Add(c);
                }
                laListaDeContactos = new ListaInvolucradoContacto(lContactos, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            return laListaDeContactos;
        }
        /// <summary>
        /// Metodo que elimina un contacto involucrado a un proyecto
        /// </summary>
        /// <param name="c">contacto a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarContactoDeIvolucradosEnProyecto(Contacto c, ListaInvolucradoContacto l)
        {
            int filasA, filasD;

            Parametro paramProyectoCod, paramContactoId, paramFilas;
            BDConexion laConexion = new BDConexion();
            List<Parametro> listaParametros, parametrosContar;

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);

            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);
            try
            {
                laConexion = new BDConexion();
                listaParametros = new List<Parametro>();

                paramProyectoCod = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamCodProy,
                                                 SqlDbType.VarChar, l.Proyecto.Codigo, false);
                paramContactoId = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamContID,
                                                 SqlDbType.Int, c.Con_Id.ToString(), false);
                listaParametros.Add(paramContactoId);
                listaParametros.Add(paramProyectoCod);

                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarContacto, listaParametros);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
            filasD = int.Parse(resultado[0].valor);

            if ((filasA - 1) == filasD)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo que elimina un usuario involucrado a un proyecto
        /// </summary>
        /// <param name="c">usuario a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarUsuariosDeIvolucradosEnProyecto(Usuario u, ListaInvolucradoUsuario l)
        {
            int filasA, filasD;

            Parametro paramProyectoCod, paramFilas, paramUsuario;
            BDConexion laConexion = new BDConexion();
            List<Parametro> listaParametros, parametrosContar;

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);

            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);

            try
            {
                laConexion = new BDConexion();
                listaParametros = new List<Parametro>();

                paramProyectoCod = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamCodProy,
                                                 SqlDbType.VarChar, l.Proyecto.Codigo, false);
                paramUsuario = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamUsername,
                                                 SqlDbType.VarChar, u.username, false);
                listaParametros.Add(paramUsuario);
                listaParametros.Add(paramProyectoCod);

                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarUsuario, listaParametros);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            laConexion = new BDConexion();

            resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
            filasD = int.Parse(resultado[0].valor);

            if ((filasA - 1) == filasD)
                return true;
            else
                return false;
        }


    }
}
