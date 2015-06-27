using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Data;
using System.Data.SqlClient;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;

namespace DAO.DAO.Modulo2
{
    /// <summary>
    /// Data Access Object para cliente juridico
    /// </summary>
    public class DaoClienteJuridico : DAO, IntefazDAO.Modulo2.IDaoClienteJuridico
    {
        #region IDAO
        /// <summary>
        /// Metodo para agregar cliente juridico
        /// </summary>
        /// <param name="parametro">cliente a agregar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public bool Agregar(Entidad parametro)
        {
            try 
            {
                ClienteJuridico elCliente = (ClienteJuridico)parametro;

                if (BuscarRifClienteJuridico(elCliente))
                {
                    #region Llenado de arreglo de parametros

                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
                        elCliente.Jur_Rif, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamJurNombre, SqlDbType.VarChar,
                        elCliente.Jur_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamJurLogo, SqlDbType.VarChar,
                        elCliente.Jur_Logo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamPais, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.ElPais, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamEstado, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.ElEstado, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCiudad, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.LaCiudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamDireccion, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.LaDireccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                        elCliente.Jur_Direccion.CodigoPostal, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCedula, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].ConCedula, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoNombre, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].Con_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoApellido, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].Con_Apellido, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCargo, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].ConCargo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCodTel, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].Con_Telefono.Codigo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoNumTel, SqlDbType.VarChar,
                        elCliente.Jur_Contactos[0].Con_Telefono.Numero, false);
                    parametros.Add(elParametro);
                    #endregion
                    List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteJur, parametros);
                    return true;
                }
                else
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()), 
                        new RifClienteJuridicoExistenteException());

                    throw new RifClienteJuridicoExistenteException(RecursoBDModulo2.CodigoRIFExistenteException,
                        RecursoBDModulo2.MensajeRIFExistenteException,
                        new RifClienteJuridicoExistenteException());
                }
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch(RifClienteJuridicoExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para modificar un cliente juridico
        /// </summary>
        /// <param name="parametro">cliente juridico modificado</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public bool Modificar(Entidad parametro)
        {
            try
            {
                ClienteJuridico elCliente = (ClienteJuridico)parametro;
                if (BuscarRifClienteJuridico(elCliente))
                {
                    #region Llenado de parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int,
                        elCliente.Id.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
                         elCliente.Jur_Rif, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamJurNombre, SqlDbType.VarChar,
                        elCliente.Jur_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamJurLogo, SqlDbType.VarChar,
                        elCliente.Jur_Logo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamDireccion, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.LaDireccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCiudad, SqlDbType.VarChar,
                        elCliente.Jur_Direccion.LaCiudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                        elCliente.Jur_Direccion.CodigoPostal, false);
                    parametros.Add(elParametro);
                    #endregion
                    List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteJur,
                        parametros);
                    return true;
                }
                else
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                        new RifClienteJuridicoExistenteException());

                    throw new RifClienteJuridicoExistenteException(RecursoBDModulo2.CodigoRIFExistenteException,
                        RecursoBDModulo2.MensajeRIFExistenteException,
                        new RifClienteJuridicoExistenteException());
                }
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (RifClienteJuridicoExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar todos los datos de un cliente juridico dado su ID
        /// </summary>
        /// <param name="parametro">parametro que contiene el Id del cliente a consultar</param>
        /// <returns>el cliente con todos sus datos</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteJuridico elCliente;
            Direccion laDireccion;
            try
            {
                elCliente = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDClienteJur,
                    SqlDbType.Int, parametro.Id.ToString(), false);
                parametros.Add(parametroStored);
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteJur, parametros);

                if (resultado == null)
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                        new ClienteInexistenteException());

                    throw new ClienteInexistenteException(RecursoBDModulo2.CodigoClienteInexistente,
                        RecursoBDModulo2.MensajeClienteInexistente, new ClienteInexistenteException());
                }

                foreach (DataRow row in resultado.Rows)
                {
                    laDireccion = (Direccion)laFabrica.ObtenerDireccion();
                    elCliente = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                    elCliente.Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());

                    elCliente.Jur_Nombre = row[RecursoBDModulo2.AliasClienteJurNombre].ToString();
                    elCliente.Jur_Logo = row[RecursoBDModulo2.AliasClienteJurLogo].ToString();
                    elCliente.Jur_Rif = row[RecursoBDModulo2.AliasClienteJurRif].ToString();
                    laDireccion.LaDireccion = row[RecursoBDModulo2.AliasClienteJurDireccion].ToString();
                    laDireccion.CodigoPostal = row[RecursoBDModulo2.AliasClienteJurCodPost].ToString();
                    laDireccion.LaCiudad = row[RecursoBDModulo2.AliasClienteJurCiudad].ToString();
                    laDireccion.ElEstado = row[RecursoBDModulo2.AliasClienteJurEstado].ToString();
                    laDireccion.ElPais = row[RecursoBDModulo2.AliasClienteJurPais].ToString();
                    elCliente.Jur_Direccion = laDireccion;
                }
                return elCliente;
            }
            #region Catches
            catch (ClienteInexistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar la lista de clientes juridicos
        /// </summary>
        /// <returns>lista completa de todos los clientes juridicos en bd</returns>
        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteJuridico elCliente;
            Direccion laDireccion;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaClientesJur, parametros);
                
                foreach (DataRow row in resultado.Rows)
                {
                    laDireccion = (Direccion)laFabrica.ObtenerDireccion();
                    elCliente = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                    elCliente.Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());

                    elCliente.Jur_Nombre = row[RecursoBDModulo2.AliasClienteJurNombre].ToString();
                    elCliente.Jur_Logo = row[RecursoBDModulo2.AliasClienteJurLogo].ToString();
                    elCliente.Jur_Rif = row[RecursoBDModulo2.AliasClienteJurRif].ToString();
                    laDireccion.LaDireccion = row[RecursoBDModulo2.AliasClienteJurDireccion].ToString();
                    laDireccion.CodigoPostal = row[RecursoBDModulo2.AliasClienteJurCodPost].ToString();
                    laDireccion.LaCiudad = row[RecursoBDModulo2.AliasClienteJurCiudad].ToString();
                    laDireccion.ElEstado = row[RecursoBDModulo2.AliasClienteJurEstado].ToString();
                    laDireccion.ElPais = row[RecursoBDModulo2.AliasClienteJurPais].ToString();
                    elCliente.Jur_Direccion = laDireccion;
                    laLista.Add(elCliente);
                }

                return laLista;

            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        #endregion
        #region IDaoClienteJuridico
        /// <summary>
        /// Metodo para consultar que el rif sea unico
        /// </summary>
        /// <param name="parametro">Cliente para verificar si el rif ya existe</param>
        /// <returns>true si el rif no esta asociado a algun cliente, 
        /// false si ya existe ese rif en bd</returns>
        public bool BuscarRifClienteJuridico(Entidad parametro)
        {
            ClienteJuridico elCliente = (ClienteJuridico)parametro;
            bool retorno = false;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
                    elCliente.Jur_Rif, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursoBDModulo2.ParamSalida, SqlDbType.Int, true);
                parametros.Add(elParametro);
                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.BuscarRifClienteJur,
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if (resultado.etiqueta == RecursoBDModulo2.ParamSalida)
                        if (elCliente.Id == 0)
                            retorno = true;
                        else
                            if (int.Parse(resultado.valor) == elCliente.Id)
                                retorno = true;
                }
                return retorno;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar la lista de contactos que posee una empresa
        /// </summary>
        /// <param name="parametro">empresa de la que se desean conocer sus contactos</param>
        /// <returns>lista de contactos asociados a esa empresa</returns>
        public List<Entidad> consultarListaDeContactosJuridico(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            Contacto elContacto;
            Telefono elTelefono;
            List<Parametro> parametros = new List<Parametro>();

            try
            {
                Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int, 
                    parametro.Id.ToString(), false);
                parametros.Add(parametroStored);
                DataTable resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaContactosJurID, 
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elContacto = (Contacto)laFabrica.ObtenerContacto();
                    elTelefono = (Telefono)laFabrica.ObtenerTelefono();
                    elContacto.Id = int.Parse(row[RecursoBDModulo2.AliasContactoID].ToString());
                    elContacto.Con_Nombre = row[RecursoBDModulo2.AliasContactoNombre].ToString();
                    elContacto.Con_Apellido = row[RecursoBDModulo2.AliasContactoApellido].ToString();
                    elContacto.ConCargo = row[RecursoBDModulo2.AliasCargoContacto].ToString();
                    elContacto.ConCedula = row[RecursoBDModulo2.AliasContactoCedula].ToString();
                    elTelefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elTelefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();
                    elContacto.Con_Telefono = elTelefono;
                    laLista.Add(elContacto);
                }
                return laLista;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// metodo para eliminar un cliente juridico
        /// </summary>
        /// <param name="parametro">cliente a eliminar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public bool eliminarClienteJuridico(Entidad parametro)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int, parametro.Id.ToString(), false);
            parametros.Add(parametroStored);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.EliminarClienteJuridico, parametros);
                return (tmp.ToArray().Length > 0);             
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para eliminar un contacto
        /// </summary>
        /// <param name="parametro">contacto a eliminar</param>
        /// <returns>booleano que refleja el valor de exito de la operacion</returns>
        public bool eliminarContacto(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Parametro> parametros = new List<Parametro>();
            try
            {
                Parametro parametroStored = new Parametro(RecursoBDModulo2.EliminarContacto, SqlDbType.Int,
                   parametro.Id.ToString(), false);
                parametros.Add(parametroStored);
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.EliminarContacto, parametros);
                return true;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar en BD toda la lista de paises
        /// </summary>
        /// <returns></returns>
        public List<String> consultarPaises()
        {
            List<String> laLista = new List<String>();
            DataTable resultado = new DataTable();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarPaises, new List<Parametro>());
                foreach (DataRow row in resultado.Rows)
                {
                    laLista.Add(row[RecursoBDModulo2.NombreLugar].ToString());
                }
                return laLista;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar todos los estados de un pais en especifico
        /// </summary>
        /// <param name="elPais">pais del que se desean saber los estados</param>
        /// <returns>lista de estados del pais seleccionado</returns>
        public List<String> consultarEstadosPorPais(String elPais)
        {
            List<String> laLista = new List<String>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamPais, SqlDbType.VarChar, elPais, false);
            parametros.Add(parametro);
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarEstadosPorPais,
                    parametros);
                foreach (DataRow row in resultado.Rows)
                {
                    laLista.Add(row[RecursoBDModulo2.NombreLugar].ToString());
                }
                return laLista;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar las ciudades de un estado en especifico
        /// </summary>
        /// <param name="elEstado">Estado del que se desean saber las ciudades</param>
        /// <returns>lista de ciudades del estado seleccionado</returns>
        public List<String> consultarCiudadesPorEstado(String elEstado)
        {
            List<String> laLista = new List<String>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamEstado, SqlDbType.VarChar, elEstado, false);
            parametros.Add(parametro);
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarCiudadesPorEstado,
                    parametros);
                foreach (DataRow row in resultado.Rows)
                {
                    laLista.Add(row[RecursoBDModulo2.NombreLugar].ToString());
                }
                return laLista;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar la lista de cargos que puede ocupar
        /// un contacto dentro de una empresa
        /// </summary>
        /// <returns>lista de cargos</returns>
        public List<String> consultarListaCargos()
        {
            List<String> laLista = new List<String>();
            DataTable resultado = new DataTable();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaCargos, new List<Parametro>());
                foreach (DataRow row in resultado.Rows)
                {
                    laLista.Add(row[RecursoBDModulo2.AliasCargoNombre].ToString());
                }
                return laLista;
            }
            #region Catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                    RecursoBDModulo2.MensajeExcepcionGeneral,
                    ex);
            }
            #endregion
        }
        #endregion
    }
}
