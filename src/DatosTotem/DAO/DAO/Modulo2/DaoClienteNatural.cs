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
    /// Data Access Object para Cliente Natural
    /// </summary>
    public class DaoClienteNatural : DAO, IntefazDAO.Modulo2.IDaoClienteNatural
    {
        #region IDAO
        /// <summary>
        /// metodo para agregar un cliente natural
        /// </summary>
        /// <param name="parametro">cliente natural a agregar</param>
        /// <returns>booleano que relfeja el exito de la operacion</returns>
        public bool Agregar(Entidad parametro)
        {
            try
            {
                ClienteNatural elCliente = (ClienteNatural)parametro;
                if (BuscarCIClienteNatural(elCliente))
                {
                    #region Llenado de arreglo de parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamCedulaClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Cedula, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamNombreClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamApellidoClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Apellido, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCorreoClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Correo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoTelef, SqlDbType.VarChar,
                        elCliente.Nat_Telefono.Codigo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamNumeroTelef, SqlDbType.VarChar,
                        elCliente.Nat_Telefono.Numero, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamPais, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.ElPais, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamEstado, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.ElEstado, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCiudad, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.LaCiudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamDireccion, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.LaDireccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                        elCliente.Nat_Direccion.CodigoPostal, false);
                    parametros.Add(elParametro);
                    #endregion

                    List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteNat,
                                            parametros);
                    return true;
                }
                else
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                                            new CIClienteNatExistenteException());
                    throw new CIClienteNatExistenteException(RecursoBDModulo2.CodigoCIExistenteException,
                                                        RecursoBDModulo2.MensajeCIExistenteException,
                                                        new CIClienteNatExistenteException());

                }


            }
            #region catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (CIClienteNatExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                                         RecursoBDModulo2.MensajeExcepcionGeneral,
                                         ex);
            }
            #endregion

        }
        /// <summary>
        /// metodo para modificar un cliente natural
        /// </summary>
        /// <param name="parametro">cliente natural a modificar</param>
        /// <returns>booleano que refleja el valor de exito de la operacion</returns>
        public bool Modificar(Entidad parametro)
        {
            ClienteNatural elCliente = (ClienteNatural)parametro;

            try
            {
                if (BuscarCIClienteNatural(elCliente))
                {

                    #region Llenado de arreglo de parametros
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat, SqlDbType.Int,
                        elCliente.Id.ToString(), false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCedulaClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Cedula, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamNombreClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Nombre, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamApellidoClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Apellido, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCorreoClienteNat, SqlDbType.VarChar,
                        elCliente.Nat_Correo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoTelef, SqlDbType.VarChar,
                        elCliente.Nat_Telefono.Codigo, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamNumeroTelef, SqlDbType.VarChar,
                        elCliente.Nat_Telefono.Numero, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(RecursoBDModulo2.ParamCiudad, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.LaCiudad, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamDireccion, SqlDbType.VarChar,
                        elCliente.Nat_Direccion.LaDireccion, false);
                    parametros.Add(elParametro);
                    elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                        elCliente.Nat_Direccion.CodigoPostal, false);
                    parametros.Add(elParametro);
                    #endregion
                    List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteNat,
                        parametros);
                    return true;
                }
                else
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                                           new CIClienteNatExistenteException());
                    throw new CIClienteNatExistenteException(RecursoBDModulo2.CodigoCIExistenteException,
                                                        RecursoBDModulo2.MensajeCIExistenteException,
                                                        new CIClienteNatExistenteException());
                }
            }
            #region catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (CIClienteNatExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                                         RecursoBDModulo2.MensajeExcepcionGeneral,
                                         ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar todos los datos de un cliente natural
        /// dado un id
        /// </summary>
        /// <param name="parametro">entidad que posee el id del que se desean saber
        /// todos los datos</param>
        /// <returns>cliente natural con todos sus datos</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro;
            Direccion laDireccion;
            Telefono elTelefono;

            try
            {
                ClienteNatural elCliente = (ClienteNatural)laFabrica.ObtenerClienteNatural();
                elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat,
                SqlDbType.Int, parametro.Id.ToString(), false);
                parametros.Add(elParametro);
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteNat,
                                                                     parametros);
                if (resultado == null)
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                                           new ClienteInexistenteException());
                    throw new ClienteInexistenteException(RecursoBDModulo2.CodigoClienteInexistente,
                                                          RecursoBDModulo2.MensajeClienteInexistente,
                                                          new ClienteInexistenteException());
                }

                foreach (DataRow row in resultado.Rows)
                {
                    laDireccion = (Direccion)laFabrica.ObtenerDireccion();
                    elTelefono = (Telefono)laFabrica.ObtenerTelefono();
                    elCliente = (ClienteNatural)laFabrica.ObtenerClienteNatural();
                    elCliente.Id = int.Parse(row[RecursoBDModulo2.AliasIDClienteNat].ToString());
                    elCliente.Nat_Nombre = row[RecursoBDModulo2.AliasNombreClienteNat].ToString();
                    elCliente.Nat_Apellido = row[RecursoBDModulo2.AliasApellidoClienteNat].ToString();
                    elCliente.Nat_Cedula = row[RecursoBDModulo2.AliasCedulaClienteNat].ToString();
                    elCliente.Nat_Correo = row[RecursoBDModulo2.AliasCorreoClienteNat].ToString();
                    elTelefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elTelefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();
                    elCliente.Nat_Telefono = elTelefono;
                    laDireccion.LaDireccion = row[RecursoBDModulo2.AliasNombreDireccion].ToString();
                    laDireccion.CodigoPostal = row[RecursoBDModulo2.AliasCodPostalDireccion].ToString();
                    laDireccion.LaCiudad = row[RecursoBDModulo2.AliasNombreCiudad].ToString();
                    laDireccion.ElEstado = row[RecursoBDModulo2.AliasNombreEstado].ToString();
                    laDireccion.ElPais = row[RecursoBDModulo2.AliasNombrePais].ToString();
                    elCliente.Nat_Direccion = laDireccion;

                }

                return elCliente;

            }
            #region catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ClienteInexistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                                         RecursoBDModulo2.MensajeExcepcionGeneral,
                                         ex);
            }
            #endregion
        }
        /// <summary>
        /// Metodo para consultar toda la lista de clientes naturales en bd
        /// </summary>
        /// <returns>lista de clientes naturales</returns>
        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteNatural elCliente;
            Direccion laDireccion;
            Telefono elTelefono;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaClienteNat,
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    laDireccion = (Direccion)laFabrica.ObtenerDireccion();
                    elTelefono = (Telefono)laFabrica.ObtenerTelefono();
                    elCliente = (ClienteNatural)laFabrica.ObtenerClienteNatural();
                    elCliente.Id = int.Parse(row[RecursoBDModulo2.AliasIDClienteNat].ToString());
                    elCliente.Nat_Nombre = row[RecursoBDModulo2.AliasNombreClienteNat].ToString();
                    elCliente.Nat_Apellido = row[RecursoBDModulo2.AliasApellidoClienteNat].ToString();
                    elCliente.Nat_Cedula = row[RecursoBDModulo2.AliasCedulaClienteNat].ToString();
                    elCliente.Nat_Correo = row[RecursoBDModulo2.AliasCorreoClienteNat].ToString();
                    elTelefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elTelefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();
                    elCliente.Nat_Telefono = elTelefono;
                    laDireccion.LaDireccion = row[RecursoBDModulo2.AliasNombreDireccion].ToString();
                    laDireccion.CodigoPostal = row[RecursoBDModulo2.AliasCodPostalDireccion].ToString();
                    laDireccion.LaCiudad = row[RecursoBDModulo2.AliasNombreCiudad].ToString();
                    laDireccion.ElEstado = row[RecursoBDModulo2.AliasNombreEstado].ToString();
                    laDireccion.ElPais = row[RecursoBDModulo2.AliasNombrePais].ToString();
                    elCliente.Nat_Direccion = laDireccion;
                    laLista.Add(elCliente);
                }

                return laLista;

            }
            #region catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                                         RecursoBDModulo2.MensajeExcepcionGeneral,
                                         ex);
            }
            #endregion
        }
        #endregion
        #region IDaoClienteNatural
        /// <summary>
        /// metodo para eliminar un cliente natural
        /// </summary>
        /// <param name="parametro">cliente natural a eliminar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public bool eliminarClienteNatural(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDClienteNat, SqlDbType.Int,
               parametro.Id.ToString(), false);
            parametros.Add(parametroStored);
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.EliminarClienteNat, parametros);
                return (tmp.ToArray().Length > 0);

            }
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }

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
            catch (Exception ex)
            {
                throw ex;
            }
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
            catch (Exception ex)
            {
                throw ex;
            }
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo para consultar que la cedula sea unica
        /// </summary>
        /// <param name="parametro">Cliente para verificar si la cedula ya existe</param>
        /// <returns>true si la cedula no esta asociada a algun cliente, 
        /// false si ya existe esa cedula en bd</returns>
        public bool BuscarCIClienteNatural(Entidad parametro)
        {
            ClienteNatural elCliente = (ClienteNatural)parametro;
            bool retorno = false;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursoBDModulo2.ParamCedulaClienteNat,
                    SqlDbType.VarChar, elCliente.Nat_Cedula, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursoBDModulo2.ParamSalida, SqlDbType.Int, true);
                parametros.Add(elParametro);
                List<Resultado> resultados = EjecutarStoredProcedure(RecursoBDModulo2.BuscarCIClienteNatural,
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
            #region catches
            catch (SqlException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos,
                    ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()), ex);

                throw new ExceptionTotem(RecursoBDModulo2.CodigoExcepcionGeneral,
                                         RecursoBDModulo2.MensajeExcepcionGeneral,
                                         ex);
            }
            #endregion
        }
        #endregion
    }
}
