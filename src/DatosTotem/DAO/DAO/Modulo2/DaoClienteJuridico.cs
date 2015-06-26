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
    public class DaoClienteJuridico : DAO, IntefazDAO.Modulo2.IDaoClienteJuridico
    {
        public bool BuscarCIContacto(String cedulaCon)
        {
            bool retorno = false;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursoBDModulo2.ParamContactoCedula, SqlDbType.VarChar,
                    cedulaCon, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursoBDModulo2.ParamSalida, SqlDbType.Int, true);
                parametros.Add(elParametro);
                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.BuscarCIContacto,
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if ((resultado.etiqueta == RecursoBDModulo2.ParamSalida) &&
                        (int.Parse(resultado.valor) == 0))
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
        public bool BuscarRifClienteJuridico(String elRif)
        {
            bool retorno = false;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
                    elRif, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursoBDModulo2.ParamSalida, SqlDbType.Int, true);
                parametros.Add(elParametro);
                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.BuscarRifClienteJur,
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if ((resultado.etiqueta == RecursoBDModulo2.ParamSalida) &&
                        (int.Parse(resultado.valor) == 0))
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
        public bool Agregar(Entidad parametro)
        {
            try 
            {
                ClienteJuridico elCliente = (ClienteJuridico)parametro;

                if (BuscarRifClienteJuridico(elCliente.Jur_Rif))
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
        public bool Modificar(Entidad parametro)
        {
            try
            {
                ClienteJuridico elCliente = (ClienteJuridico)parametro;
                if (BuscarRifClienteJuridico(elCliente.Jur_Rif))
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
        public Entidad consultarDatosContactoID(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            try
            {
                #region Llenado de parametros
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDContacto,
                    SqlDbType.Int, parametro.Id.ToString(), false);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoNombre,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoApellido,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoCargo,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoCodTel,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoNumTel,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                parametroStored = new Parametro(RecursoBDModulo2.ParamContactoCedula,
                    SqlDbType.VarChar, true);
                parametros.Add(parametroStored);
                #endregion

                Contacto elContacto = (Contacto)laFabrica.ObtenerContacto();

                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.ConsultarDatosContacto, 
                    parametros);
                
                if (resultados == null)
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                        new ContactoInexistenteException());

                    throw new ContactoInexistenteException(RecursoBDModulo2.CodigoClienteInexistente,
                        RecursoBDModulo2.MensajeClienteInexistente, new ClienteInexistenteException());
                }
                elContacto.Con_Telefono = new Telefono();
                foreach (Resultado resultado in resultados)
                {
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoCargo))
                    {
                        elContacto.ConCargo = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoNombre))
                    {
                        elContacto.Con_Nombre = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoApellido))
                    {
                        elContacto.Con_Apellido = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoCodTel))
                    {
                        elContacto.Con_Telefono.Codigo = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoNumTel))
                    {
                        elContacto.Con_Telefono.Numero = resultado.valor;
                    }
                    if (resultado.etiqueta.Equals(RecursoBDModulo2.ParamContactoCedula))
                    {
                        elContacto.ConCedula = resultado.valor;
                    }
                }
                return elContacto;
            }
            #region Catches
            catch (ContactoInexistenteException ex)
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

        public bool modificarContacto(Entidad parametro)
        {
            try
            {
                Contacto elContacto = (Contacto)parametro;
                if (BuscarCIContacto(elContacto.ConCedula))
                {
                    #region Llenado de parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDContacto, SqlDbType.Int,
                        elContacto.Id.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoNombre, SqlDbType.VarChar,
                        elContacto.Con_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoApellido, SqlDbType.VarChar,
                        elContacto.Con_Apellido, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCedula, SqlDbType.VarChar,
                        elContacto.ConCedula, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCodTel, SqlDbType.VarChar,
                        elContacto.Con_Telefono.Codigo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoNumTel, SqlDbType.VarChar,
                        elContacto.Con_Telefono.Numero, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamContactoCargo, SqlDbType.VarChar,
                        elContacto.ConCargo, false);
                    parametros.Add(elParametro);
                    #endregion
                    EjecutarStoredProcedure(RecursoBDModulo2.ModificarContacto,
                        parametros);
                    return true;
                }
                else
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                        new CIContactoExistenteException());

                    throw new CIContactoExistenteException(RecursoBDModulo2.CodigoCIExistenteExceptionContacto,
                        RecursoBDModulo2.MensajeCIContactoExistente,
                        new CIContactoExistenteException());
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
            catch (CIContactoExistenteException ex)
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
    }
}
