using DAO.IntefazDAO.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO.DAO.Modulo3
{
    class DAOInvolucrados: DAO,IDaoInvolucrados
    {
        /// <summary>
        /// Metodo que agrega la lista de usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de usuarios a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public bool AgregarUsuariosInvolucrados(Entidad parametro)
        {
            int filasA, filasD;
            Proyecto elProyecto;
            bool exito = false;
            ListaInvolucradoUsuario listaUsuarios = (ListaInvolucradoUsuario) parametro;
            if (listaUsuarios.Proyecto != null)
                elProyecto = listaUsuarios.Proyecto;
            else
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                    RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());

            List<Parametro> parametros, parametrosContar;
            Parametro paramProyectoCod, paramUsername, paramFilas;

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);

            if (listaUsuarios.Lista.ToArray().Length == 0 || listaUsuarios.Lista == null)
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                    RecursosBDModulo3.Mensaje_ListaSinInv, new Exception());
            try
            {
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                    parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                foreach (Usuario elUsuario in listaUsuarios.Lista)
                {
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
                    if (elUsuario.Username != null)
                    {
                        paramUsername = new Parametro(RecursosBDModulo3.ParamUsername, SqlDbType.VarChar,
                            elUsuario.Username, false);
                        parametros.Add(paramUsername);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.UsuarioSinUsernameException(RecursosBDModulo3.Codigo_UsuarioSinUsername,
                            RecursosBDModulo3.Mensaje_UsuarioSinUsername, new Exception());

                    EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarUsuario, parametros);
                }
                resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if (filasD == filasA + listaUsuarios.Lista.ToArray().Length)
                    exito = true;
                else
                    exito = false;
                return exito;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                    RecursosBDModulo3.Codigo_Involucrado_Repetido,
                    RecursosBDModulo3.Mensaje_Involucrado_Repetido, new Exception());
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
        public bool AgregarContactosInvolucrados(Entidad parametro)
        {
            int filasA, filasD;
            Proyecto elProyecto;
            bool exito = false;
            ListaInvolucradoContacto listaContactos = (ListaInvolucradoContacto)parametro;
            if (listaContactos.Proyecto != null)
                elProyecto = listaContactos.Proyecto;
            else
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                    RecursosBDModulo3.Mensaje_ListaSinProy, new Exception());
            List<Parametro> parametros, parametrosContar;

            Parametro paramProyectoCod, paramContactoID, paramFilas;

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);

            List<Resultado> resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                parametrosContar);
            filasA = int.Parse(resultado[0].valor);

            if (listaContactos.Lista.ToArray().Length == 0 || listaContactos.Lista == null)
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                    RecursosBDModulo3.Mensaje_ListaSinInv, new Exception());
            try
            {
                foreach (Contacto elContacto in listaContactos.Lista)
                {
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar,
                        elProyecto.Codigo, false);
                    parametros.Add(paramProyectoCod);
                    if (elContacto.Id != null)
                    {
                        paramContactoID = new Parametro(RecursosBDModulo3.ParamContID, SqlDbType.Int,
                            elContacto.Id.ToString(), false);
                        parametros.Add(paramContactoID);
                    }
                    else
                        throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                            RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                            new Exception());
                    EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarCliente, parametros);
                }

                resultado = null;

                resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente, parametrosContar);
                System.Diagnostics.Debug.WriteLine(resultado[0]);
                filasD = int.Parse(resultado[0].valor);

                if (filasD > filasA)
                    exito = true;
                else
                    exito = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                        RecursosBDModulo3.Codigo_Involucrado_Repetido,
                        RecursosBDModulo3.Mensaje_Involucrado_Repetido, new Exception());
                else
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD();
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", new Exception());
            }
            return exito;
        }
        /// <summary>
        /// Metodo que consulta los usuarios involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de usuarios involucrados al proyecto que recibe como parametro</returns>
        public Entidad ConsultarUsuariosInvolucradosPorProyecto(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            ListaInvolucradoUsuario laListaDeUsuarios = new ListaInvolucradoUsuario();
            Proyecto p = (Proyecto)parametro;
            List<Parametro> parametros;
            Parametro codigoProyecto;
            List<Usuario> lUsuarios = new List<Usuario>();
            try
            {
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

                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarUsuario,
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Usuario u = (Usuario)laFabrica.ObtenerUsuario();
                    u.IdUsuario = int.Parse(row[RecursosBDModulo3.aliasUsuarioID].ToString());
                    u.Nombre = row[RecursosBDModulo3.aliasUsuarioNombre].ToString();
                    u.Apellido = row[RecursosBDModulo3.aliasUsuarioApellido].ToString();
                    u.Cargo = row[RecursosBDModulo3.aliasCargoNombre].ToString();
                    u.Username = row[RecursosBDModulo3.aliasUsuarioUsername].ToString();
                    lUsuarios.Add(u);
                }
                laListaDeUsuarios = (ListaInvolucradoUsuario)laFabrica.
                                    ObtenetListaInvolucradoUsuario(lUsuarios, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
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
        /// <param name="parametro">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de contactos involucrados al proyecto que recibe como parametro</returns>
        public Entidad ConsultarContactosInvolucradosPorProyecto(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            ListaInvolucradoContacto laListaDeContactos = (ListaInvolucradoContacto)laFabrica.
                                                          ObtenetListaInvolucradoContacto();
            Proyecto p = (Proyecto)parametro;
            List<Parametro> parametros;
            Parametro codigoProyecto = null ;

            List<Contacto> lContactos = new List<Contacto>();
            try
            {
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

                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredConsultarContacto,
                    parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Contacto c = (Contacto)laFabrica.ObtenerContacto();
                    c.Id = int.Parse(row[RecursosBDModulo3.aliasContactoID].ToString());
                    c.Con_Nombre = row[RecursosBDModulo3.aliasContactoNombre].ToString();
                    c.Con_Apellido = row[RecursosBDModulo3.aliasContactoApellido].ToString();
                    c.ConCargo = row[RecursosBDModulo3.aliasCargoNombre].ToString();
                    System.Console.WriteLine(row[RecursosBDModulo3.aliasValor].ToString());
                    if (row[RecursosBDModulo3.aliasValor].ToString().Equals("1"))
                    {
                        c.ConClienteJurid = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                        c.ConClienteJurid.Id = int.Parse(row[RecursosBDModulo3.aliasClienteID].ToString());
                        c.ConClienteJurid.Jur_Nombre = row[RecursosBDModulo3.aliasClienteNombre].ToString();

                    }
                    else
                    {
                        c.ConClienteNat = (ClienteNatural)laFabrica.ObtenerClienteNatural();
                        c.ConClienteNat.Id = int.Parse(row[RecursosBDModulo3.aliasClienteID].ToString());
                        c.ConClienteJurid.Jur_Nombre = row[RecursosBDModulo3.aliasClienteNombre].ToString();
                    }

                    lContactos.Add(c);
                }
                laListaDeContactos = (ListaInvolucradoContacto)laFabrica.
                                        ObtenetListaInvolucradoContacto(lContactos, p);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
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
        /// <param name="parametroc">contacto a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public bool EliminarContactoDeIvolucradosEnProyecto(Entidad parametroc, Entidad parametrol)
        {
            int filasA, filasD;
            Contacto c = (Contacto)parametroc;
            ListaInvolucradoContacto l = (ListaInvolucradoContacto)parametrol;
            Parametro paramProyectoCod = null;
            Parametro paramContactoId = null;
            Parametro paramFilas = null;
            List<Parametro> listaParametros, parametrosContar;
            bool exito = false;
            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);
            try
            {
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente,
                    parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                listaParametros = new List<Parametro>();
                if (l.Proyecto != null)
                    if (l.Proyecto.Codigo != null)
                    {
                        paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy,
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

                if (c.Id != null)
                {
                    paramContactoId = new Parametro(RecursosBDModulo3.ParamContID,
                                                    SqlDbType.Int, c.Id.ToString(), false);
                    listaParametros.Add(paramContactoId);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                        RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                        new Exception());

                EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarContacto, listaParametros);
                resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarCliente, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if ((filasA - 1) == filasD)
                    exito = true;
                else
                    exito = false;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
            }
            catch (Exception ex)
            {
                exito = false;
                //lanza otra
            }
            return exito;
        }
        /// <summary>
        /// Metodo que elimina un usuario involucrado a un proyecto
        /// </summary>
        /// <param name="c">usuario a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public bool EliminarUsuariosDeIvolucradosEnProyecto(Entidad parametrou, Entidad parametrol)
        {
            int filasA, filasD;
            bool exito = false;
            Usuario u = (Usuario)parametrou;
            ListaInvolucradoUsuario l = (ListaInvolucradoUsuario)parametrol;
            Parametro paramProyectoCod = null;
            Parametro paramFilas = null;
            Parametro paramUsuario = null;
            List<Parametro> listaParametros, parametrosContar;

            parametrosContar = new List<Parametro>();
            paramFilas = new Parametro(RecursosBDModulo3.ParamFilas, SqlDbType.Int, true);
            parametrosContar.Add(paramFilas);
            try
            {
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario,
                parametrosContar);
                filasA = int.Parse(resultado[0].valor);

                listaParametros = new List<Parametro>();
                if (l.Proyecto != null)
                    if (l.Proyecto.Codigo != null)
                    {
                        paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy,
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
                if (u.Username != null)
                {
                    paramUsuario = new Parametro(RecursosBDModulo3.ParamUsername,
                                                    SqlDbType.VarChar, u.Username, false);
                    listaParametros.Add(paramUsuario);
                }
                else
                    throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                        RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                        new Exception());

                EjecutarStoredProcedure(RecursosBDModulo3.StoredEliminarUsuario, listaParametros);
                resultado = EjecutarStoredProcedure(RecursosBDModulo3.StoredContarUsuario, parametrosContar);
                filasD = int.Parse(resultado[0].valor);

                if ((filasA - 1) == filasD)
                    exito = true;
                else
                    exito = false;
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD();
            }
            catch (Exception ex)
            {
                exito = false;
                //lanza otra
            }
            return exito;
        }
        public List<String> ConsultarCargosContactos(Entidad parametro)
        {
            List<String> laListaDeCargos = new List<String>();
            List<Parametro> parametros;
            ClienteJuridico laEmpresa = (ClienteJuridico)parametro;
            Parametro rifClienteJ;
            try
            {

                parametros = new List<Parametro>();

                rifClienteJ = new Parametro(RecursosBDModulo3.ParamRif, SqlDbType.Int
                                            , laEmpresa.Id.ToString(), false);
                parametros.Add(rifClienteJ);

                DataTable dt = EjecutarStoredProcedureTuplas(RecursosBDModulo3.StoredListarCargos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    String cargo = null;

                    cargo = row[RecursosBDModulo3.ColumnaCarNombre].ToString();
                    laListaDeCargos.Add(cargo);
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }

            return laListaDeCargos;
        }
        public Entidad DatosUsuarioUsername(String user)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Usuario retorno = (Usuario)laFabrica.ObtenerUsuario();
            retorno.Username = user;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo3.ParamUser,
                SqlDbType.VarChar, user, false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamUserNombre,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamUserApellido,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamUserCargo,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            try
            {
                List<Resultado> resultados = EjecutarStoredProcedure(RecursosBDModulo3.StoredConsultarDatosUsuario,
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamUserCargo))
                    {
                        retorno.Cargo = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamUserNombre))
                    {
                        retorno.Nombre = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamUserApellido))
                    {
                        retorno.Apellido = resultado.valor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }
            return retorno;
        }
        public Entidad DatosContactoID(int idCon)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Contacto elContacto = (Contacto)laFabrica.ObtenerContacto();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosBDModulo3.ParamIdContacto,
                SqlDbType.Int, idCon.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamNombreContacto,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamApellidoContacto,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamCargoContacto,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosBDModulo3.ParamCjNombre,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);

            try
            {
                List<Resultado> resultados = EjecutarStoredProcedure(RecursosBDModulo3.StoredConsultarDatosContacto, parametros);
                foreach (Resultado resultado in resultados)
                {
                    elContacto.Id = idCon;

                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamCargoContacto))
                    {
                        elContacto.ConCargo = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamNombreContacto))
                    {
                        elContacto.Con_Nombre = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamApellidoContacto))
                    {
                        elContacto.Con_Apellido = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursosBDModulo3.ParamCjNombre))
                    {
                        ClienteJuridico cj = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                        cj.Jur_Nombre = resultado.valor;
                        elContacto.ConClienteJurid = cj;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }
            return elContacto;
        }
        public List<Entidad> ListarContactosPorEmpresa(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laListaDeContactos = new List<Entidad>();
            ClienteJuridico laEmpresa = (ClienteJuridico)parametro;
            List<Parametro> parametros;

            Parametro rifClienteJ, nombre_cargo;

            try
            {

                parametros = new List<Parametro>();

                rifClienteJ = new Parametro(RecursosBDModulo3.ParamRif, SqlDbType.Int, laEmpresa.Id.ToString(), false);
                parametros.Add(rifClienteJ);

                DataTable dt = EjecutarStoredProcedureTuplas(
                               RecursosBDModulo3.StoredConsultarContactoPorEmpresa, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Contacto c = (Contacto)laFabrica.ObtenerContacto();

                    c.Con_Nombre = row[RecursosBDModulo3.ColumnaNombreContacto].ToString();
                    c.Con_Apellido = row[RecursosBDModulo3.ColumnaApellidoContacto].ToString();
                    c.ConCargo = row[RecursosBDModulo3.ColumnaCargoContacto].ToString();
                    c.Id = int.Parse(row[RecursosBDModulo3.ColumnaIdContacto].ToString());

                    laListaDeContactos.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }

            return laListaDeContactos;
        }
        public List<Entidad> ListarContactosPorCargoEmpresa(Entidad parametro,String cargo)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laListaDeContactos = new List<Entidad>();
            ClienteJuridico laEmpresa = (ClienteJuridico)parametro;
            List<Parametro> parametros;

            Parametro rifClienteJ, nombre_cargo;

            try
            {

                parametros = new List<Parametro>();

                rifClienteJ = new Parametro(RecursosBDModulo3.ParamRif, SqlDbType.Int, laEmpresa.Id.ToString(), false);
                parametros.Add(rifClienteJ);

                nombre_cargo = new Parametro(RecursosBDModulo3.ParamCargoNombre, SqlDbType.NVarChar, cargo, false);
                parametros.Add(nombre_cargo);

                DataTable dt = EjecutarStoredProcedureTuplas(
                               RecursosBDModulo3.StoredConsultarEmpleadosEmprsa, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Contacto c = (Contacto)laFabrica.ObtenerContacto();

                    c.Con_Nombre = row[RecursosBDModulo3.ColumnaNombreContacto].ToString();
                    c.Con_Apellido = row[RecursosBDModulo3.ColumnaApellidoContacto].ToString();
                    c.ConCargo = row[RecursosBDModulo3.ColumnaCargoContacto].ToString();
                    c.Id = int.Parse(row[RecursosBDModulo3.ColumnaIdContacto].ToString());

                    laListaDeContactos.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }

            return laListaDeContactos;

        }

        public bool Agregar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
