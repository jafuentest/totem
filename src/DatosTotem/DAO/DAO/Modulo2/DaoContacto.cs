using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO.DAO.Modulo2
{
    public class DaoContacto : DAO, IntefazDAO.Modulo2.IDaoContacto
    {
        public bool Agregar(Dominio.Entidad parametro)
        {
            try
            {
                Contacto elContacto = (Contacto)parametro;
                if (BuscarCIContacto(elContacto))
                {
                    #region Llenado de parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int,
                        elContacto.ConClienteJurid.Id.ToString(), false);
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
                    EjecutarStoredProcedure(RecursoBDModulo2.AgregarContacto,
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
        public bool Modificar(Dominio.Entidad parametro)
        {
            try
            {
                Contacto elContacto = (Contacto)parametro;
                if (BuscarCIContacto(elContacto))
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
        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
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
        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        public bool BuscarCIContacto(Entidad parametro)
        {
            Contacto elContacto = (Contacto)parametro;
            bool retorno = false;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursoBDModulo2.ParamContactoCedula, SqlDbType.VarChar,
                    elContacto.ConCedula, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursoBDModulo2.ParamSalida, SqlDbType.Int, true);
                parametros.Add(elParametro);
                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.BuscarCIContacto,
                    parametros);
                foreach (Resultado resultado in resultados)
                {
                    if (resultado.etiqueta == RecursoBDModulo2.ParamSalida)
                        if (elContacto.Id == 0)
                            retorno = true;
                        else
                            if (int.Parse(resultado.valor) == elContacto.Id)
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
    }
}
