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
            Proyecto elProyecto;

            if (listaUsuarios.Proyecto != null)
                elProyecto = listaUsuarios.Proyecto;
            else
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                    RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());
            
            List<Parametro> parametros, parametrosContar;
            Parametro paramProyectoCod, paramUsername, paramFilas;
            BDConexion laConexion = new BDConexion();

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);

            if (listaUsuarios.Lista.ToArray().Length == 0 || listaUsuarios.Lista == null)
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                    RecursosBDModulo3.Mensaje_ListaSinInv, new Exception());
            try
            {
                List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                    parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                foreach (Usuario elUsuario in listaUsuarios.Lista)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    if (elProyecto.Codigo != null)
                    {
                        paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar,
                            elProyecto.Codigo, false);
                        parametros.Add(paramProyectoCod);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                            RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                            new Exception());
                    if (elUsuario.username != null)
                    {
                        paramUsername = new Parametro(RecursosBDModulo3.ParamUsername, SqlDbType.VarChar,
                            elUsuario.username, false);
                        parametros.Add(paramUsername);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.UsuarioSinUsernameException(RecursosBDModulo3.Codigo_UsuarioSinUsername,
                            RecursosBDModulo3.Mensaje_UsuarioSinUsername, new Exception());

                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarUsuario, parametros);
                }
                laConexion = new BDConexion();
                resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if (filasD == filasA + listaUsuarios.Lista.ToArray().Length)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                        RecursosBDModulo3.Codigo_Involucrado_Repetido,
                        RecursosBDModulo3.Mensaje_Involucrado_Repetido, new Exception());
                else
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", new Exception());
            }
        }
        /// <summary>
        /// Metodo que agrega la lista de contactos involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de contactos a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarContactosInvolucrados(ListaInvolucradoContacto listaContactos)
        {
            int filasA, filasD;
            Proyecto elProyecto;
            if (listaContactos.Proyecto != null)
                elProyecto= listaContactos.Proyecto;
            else
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                    RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());
            List<Parametro> parametros, parametrosContar;
            
            Parametro paramProyectoCod, paramContactoID, paramFilas; 
            BDConexion laConexion = new BDConexion();

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);

            if (listaContactos.Lista.ToArray().Length == 0 || listaContactos.Lista == null)
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                    RecursosBDModulo3.Mensaje_ListaSinInv, new Exception());
            try
            {
            foreach (Contacto elContacto in listaContactos.Lista)
            {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, 
                        elProyecto.Codigo, false);
                    parametros.Add(paramProyectoCod);
                    if (elContacto.Con_Id != null)
                    {
                        paramContactoID = new Parametro(RecursosBDModulo3.ParamContID, SqlDbType.Int,
                            elContacto.Con_Id.ToString(), false);
                        parametros.Add(paramContactoID);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                            RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                            new Exception());
                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarCliente, parametros);
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
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
                throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                    RecursosBDModulo3.Codigo_Involucrado_Repetido,
                    RecursosBDModulo3.Mensaje_Involucrado_Repetido, new Exception());
            else
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, new Exception());
        }
        catch (Exception ex)
        {
            throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", new Exception());
        }
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
                if (p.Codigo != null)
                {
                    codigoProyecto = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, p.Codigo, false);
                    parametros.Add(codigoProyecto);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                        RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                        new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarUsuario, 
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Usuario u = new Usuario();
                    u.idUsuario = int.Parse(row[RecursosBDModulo3.aliasUsuarioID].ToString());
                    u.nombre = row[RecursosBDModulo3.aliasUsuarioNombre].ToString();
                    u.apellido = row[RecursosBDModulo3.aliasUsuarioApellido].ToString();
                    u.cargo = row[RecursosBDModulo3.aliasCargoNombre].ToString();
                    u.username = row[RecursosBDModulo3.aliasUsuarioUsername].ToString();
                    lUsuarios.Add(u);
                }
                laListaDeUsuarios = new ListaInvolucradoUsuario(lUsuarios, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", new Exception());
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
                if (p.Codigo != null)
                {
                    codigoProyecto = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, p.Codigo, false);
                    parametros.Add(codigoProyecto);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                        RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                        new Exception());

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarContacto,
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Contacto c = new Contacto();
                    c.Con_Id = int.Parse(row[RecursosBDModulo3.aliasContactoID].ToString());
                    c.Con_Nombre = row[RecursosBDModulo3.aliasContactoNombre].ToString();
                    c.Con_Apellido = row[RecursosBDModulo3.aliasContactoApellido].ToString();
                    c.ConCargo = row[RecursosBDModulo3.aliasCargoNombre].ToString();
                    System.Console.WriteLine(row[RecursosBDModulo3.aliasValor].ToString());
                    if (row[RecursosBDModulo3.aliasValor].ToString().Equals("1"))
                    {
                        c.ConClienteJurid = new ClienteJuridico();
                        c.ConClienteJurid.Jur_Id = row[RecursosBDModulo3.aliasClienteID].ToString();
                        c.ConClienteJurid.Jur_Nombre = row[RecursosBDModulo3.aliasClienteNombre].ToString();

                    }
                    else
                    {
                        c.ConClienteNat = new ClienteNatural();
                        c.ConClienteNat.Nat_Id = row[RecursosBDModulo3.aliasClienteID].ToString();
                        c.ConClienteJurid.Jur_Nombre = row[RecursosBDModulo3.aliasClienteNombre].ToString();
                    }

                    lContactos.Add(c);
                }
                laListaDeContactos = new ListaInvolucradoContacto(lContactos, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, new Exception());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", new Exception());
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
            try
            {
                List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                    parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                laConexion = new BDConexion();
                listaParametros = new List<Parametro>();
                if (l.Proyecto != null)
                    if (l.Proyecto.Codigo != null)
                    {
                        paramProyectoCod = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamCodProy,
                                                        SqlDbType.VarChar, l.Proyecto.Codigo, false);
                        listaParametros.Add(paramProyectoCod);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                            RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                            new Exception());
                else 
                    throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                        RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());
            
                if (c.Con_Id != null)
                {
                    paramContactoId = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamContID,
                                                    SqlDbType.Int, c.Con_Id.ToString(), false);
                    listaParametros.Add(paramContactoId);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                        RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                        new Exception());

                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarContacto, listaParametros);
                laConexion = new BDConexion();
                resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if ((filasA - 1) == filasD)
                    return true;
                else
                    return false;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (Exception ex)
            {
                return false;
                //lanza otra
            }
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
            try
            {
                List<Resultado> resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                laConexion = new BDConexion();
                listaParametros = new List<Parametro>();
                if (l.Proyecto != null)
                    if (l.Proyecto.Codigo != null)
                    {
                        paramProyectoCod = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamCodProy,
                                                            SqlDbType.VarChar, l.Proyecto.Codigo, false);
                        listaParametros.Add(paramProyectoCod);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                            RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                            new Exception());
                else
                    throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                                            RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());
                if (u.username != null)
                {
                    paramUsuario = new Parametro(DatosTotem.Modulo3.RecursosBDModulo3.ParamUsername,
                                                    SqlDbType.VarChar, u.username, false);
                    listaParametros.Add(paramUsuario);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                        RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                        new Exception());

                laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarUsuario, listaParametros);
                laConexion = new BDConexion();
                resultado = laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if ((filasA - 1) == filasD)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (Exception ex)
            {
                return false;
                //lanza otra
            }
        }
        public static List<String> consultarCargosContactos(ClienteJuridico laEmpresa)
        {
            BDConexion laConexion;
            List<String> laListaDeCargos = new List<String>();
            List<Parametro> parametros;

            Parametro rifClienteJ;
            try
            {

                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                rifClienteJ = new Parametro("@cj_rif", SqlDbType.Int
                                            , laEmpresa.Jur_Id, false);
                parametros.Add(rifClienteJ);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas("ListarCargosPorEmpresa", parametros);

                foreach (DataRow row in dt.Rows)
                {
                    String cargo = null;

                    cargo = row["car_nombre"].ToString();
                    laListaDeCargos.Add(cargo);
                }
            }
            catch (Exception e)
            {
            }

            return laListaDeCargos;
        }
        public static Usuario datosUsuarioUsername(String user)
        {
            Usuario retorno = new Usuario();
            retorno.username = user;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro("@Username",  
                SqlDbType.VarChar, user, false);
            parametros.Add(parametro);
            parametro = new Parametro("@Usu_nombre", 
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro("@Usu_apellido", 
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro("@Usu_cargo", 
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            try
            {
                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure("Procedure_consultarDatosUsuarioUsername",
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if (resultado.etiqueta.Equals("@Usu_cargo"))
                    {
                        retorno.cargo = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals("@Usu_nombre"))
                    {
                        retorno.nombre = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals("@Usu_apellido"))
                    {
                        retorno.apellido = resultado.valor;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return retorno;
        }
    }
}
