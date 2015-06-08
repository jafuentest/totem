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

namespace DatosTotem.Modulo2
{
    /// <summary>
    /// Clase para la conexion a base de datos para las clases de clientes
    /// </summary>
    public static class BDCliente
    {
        /// <summary>
        /// Metodo para insertar un cliente juridico en BD
        /// </summary>
        /// <param name="elCliente">Cliente juridico a insertar en BD</param>
        public static void agregarClienteJuridico(ClienteJuridico elCliente)
        {
            BDConexion laConexion = new BDConexion();

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

            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteJur, 
                    parametros);
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// Metodo para consultar la lista de los clientes juridicos
        /// </summary>
        /// <returns>Lista de clientes que se encuentran en BD</returns>
        public static List<ClienteJuridico> consultarListaClientesJuridicos()
        {
            BDConexion laConexion = new BDConexion();
            List<ClienteJuridico> laLista = new List<ClienteJuridico>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteJuridico elCliente;
            Direccion laDireccion;
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaClientesJur, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    laDireccion = new Direccion();
                    elCliente = new ClienteJuridico();
                    elCliente.Jur_Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());

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
            catch(Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para consultar los datos de un cliente juridico
        /// </summary>
        /// <param name="idClienteJur">
        /// Identificador del cliente juridico para realizar la busqueda
        /// </param>
        /// <returns>Retorna el cliente con todos sus datos</returns>
        public static ClienteJuridico consultarDatosClienteJuridicoId(int idClienteJur)
        {
            BDConexion laConexion = new BDConexion();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamIDClienteJur, 
                SqlDbType.Int, idClienteJur.ToString(), false);
            parametros.Add(parametro);
            ClienteJuridico elCliente = new ClienteJuridico();
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteJur, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elCliente = new ClienteJuridico();
                    elCliente.Jur_Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());

                    elCliente.Jur_Nombre = row[RecursoBDModulo2.AliasClienteJurNombre].ToString();
                    elCliente.Jur_Logo = row[RecursoBDModulo2.AliasClienteJurLogo].ToString();
                    elCliente.Jur_Rif = row[RecursoBDModulo2.AliasClienteJurRif].ToString();
                    elCliente.Jur_Direccion.LaDireccion = row[RecursoBDModulo2.AliasClienteJurDireccion].ToString();
                    elCliente.Jur_Direccion.CodigoPostal = row[RecursoBDModulo2.AliasClienteJurCodPost].ToString();
                    elCliente.Jur_Direccion.LaCiudad = row[RecursoBDModulo2.AliasClienteJurCiudad].ToString();
                    elCliente.Jur_Direccion.ElEstado = row[RecursoBDModulo2.AliasClienteJurEstado].ToString();
                    elCliente.Jur_Direccion.ElPais = row[RecursoBDModulo2.AliasClienteJurPais].ToString();

                }
                return elCliente;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para consultar los datos de un contacto
        /// </summary>
        /// <param name="idCon">Identificador del contacto para realizar la busqueda</param>
        /// <returns>Retorna el contacto con todos sus datos</returns>
        public static Contacto consultarDatosContactoID(int idCon)
        {
            Contacto elContacto = new Contacto();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamIDContacto,
                SqlDbType.Int, idCon.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoBDModulo2.ParamContactoNombre,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoBDModulo2.ParamContactoApellido,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoBDModulo2.ParamContactoCargo,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoBDModulo2.ParamContactoCodTel, 
                SqlDbType.VarChar ,true);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoBDModulo2.ParamContactoNumTel,
                SqlDbType.VarChar, true);
            parametros.Add(parametro);

            BDConexion laConexion = new BDConexion();
            try
            {
                elContacto.Con_Id = idCon;
                List<Resultado> resultados = laConexion.EjecutarStoredProcedure(RecursoBDModulo2.ConsultarDatosContacto, parametros);
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

                }
                return elContacto;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para consultar todos los contactos que posee un cliente juridico asociados
        /// </summary>
        /// <param name="elCliente">Cliente del que se desea consultar la lista de contactos</param>
        /// <returns>Lista de contactos asociados a un cliente juridico</returns>
        public static List<Contacto> consultarListaDeContactosJuridico(ClienteJuridico elCliente)
        {
            BDConexion laConexion = new BDConexion();
            List<Contacto> laLista = new List<Contacto>();
            Contacto elContacto;

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int, 
                elCliente.Jur_Id.ToString(), false);
            parametros.Add(parametro);

            try
            {
                DataTable resultado = laConexion.EjecutarStoredProcedureTuplas(
                    RecursoBDModulo2.ConsultarListaContactosJurID, parametros);
                foreach (DataRow row in resultado.Rows)
                {
                    elContacto = new Contacto();
                    elContacto.Con_Id = int.Parse(row[RecursoBDModulo2.AliasContactoID].ToString());
                    elContacto.Con_Nombre = row[RecursoBDModulo2.AliasContactoNombre].ToString();
                    elContacto.Con_Apellido = row[RecursoBDModulo2.AliasContactoApellido].ToString();
                    elContacto.ConCargo = row[RecursoBDModulo2.AliasCargoContacto].ToString();
                    elContacto.ConCedula = row[RecursoBDModulo2.AliasContactoCedula].ToString();
                    elContacto.Con_Telefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elContacto.Con_Telefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();

                    laLista.Add(elContacto);
                }
                return laLista;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para eliminar un cliente juridico
        /// </summary>
        /// <param name="elCliente">Cliente juridico que se desea eliminar</param>
        public static void eliminarClienteJuridico(ClienteJuridico elCliente)
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamIDClienteJur, SqlDbType.Int,
                elCliente.Jur_Id.ToString(), false);
            parametros.Add(parametro);
            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.EliminarClienteJuridico, parametros);
            }
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para eliminar un contacto de BD
        /// </summary>
        /// <param name="elContacto">Contacto que se desea eliminar</param>
        public static void eliminarContacto(Contacto elContacto)
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.EliminarContacto, SqlDbType.Int,
                elContacto.Con_Id.ToString(), false);
            parametros.Add(parametro);
            try 
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.EliminarContacto, parametros);
            }
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para modificar cliente juridico
        /// </summary>
        /// <param name="elCliente">Cliente que se desea modificar</param>
        public static void modificarClienteJuridico(ClienteJuridico elCliente)
        {
            BDConexion laConexion = new BDConexion();
            ClienteJuridico clienteModificado = new ClienteJuridico();
            #region Llenado de parametros
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
                elCliente.Jur_Id.ToString(), false);
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
            elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                elCliente.Jur_Direccion.CodigoPostal, false);
            parametros.Add(elParametro);
            #endregion
            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteJur,
                    parametros);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para insertar un cliente natural en BD
        /// </summary>
        /// <param name="elCliente">cliente a insertar en BD</param>
        public static void agregarClienteNatural(ClienteNatural elCliente)
        {
            BDConexion laConexion = new BDConexion();

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

            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteNat, parametros);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Metodo para consultar la lista de clientes naturales
        /// </summary>
        /// <returns>lista de clientes naturales en BD</returns>
        public static List<ClienteNatural> consultarListaClientesNaturales()
        {
            BDConexion laConexion = new BDConexion();
            List<ClienteNatural> laLista = new List<ClienteNatural>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteNatural elCliente;
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarListaClienteNat, 
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elCliente = new ClienteNatural();
                    elCliente.Nat_Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());
                    elCliente.Nat_Nombre = row[RecursoBDModulo2.AliasNombreClienteNat].ToString();
                    elCliente.Nat_Apellido = row[RecursoBDModulo2.AliasApellidoClienteNat].ToString();
                    elCliente.Nat_Cedula = row[RecursoBDModulo2.AliasCedulaClienteNat].ToString();
                    elCliente.Nat_Correo = row[RecursoBDModulo2.AliasCorreoClienteNat].ToString();
                    elCliente.Nat_Telefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elCliente.Nat_Telefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();
                    elCliente.Nat_Direccion.LaDireccion = row[RecursoBDModulo2.AliasNombreDireccion].ToString();
                    elCliente.Nat_Direccion.CodigoPostal = row[RecursoBDModulo2.AliasCodPostalDireccion].ToString();
                    elCliente.Nat_Direccion.LaCiudad = row[RecursoBDModulo2.AliasNombreCiudad].ToString();
                    elCliente.Nat_Direccion.ElEstado = row[RecursoBDModulo2.AliasNombreEstado].ToString();
                    elCliente.Nat_Direccion.ElPais = row[RecursoBDModulo2.AliasNombrePais].ToString();
                    laLista.Add(elCliente);
                }

                return laLista;

            }
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para consultar los datos de un cliente natural
        /// </summary>
        /// <param name="idClienteNat">
        /// Identificador del cliente natural para realizar la busqueda
        /// </param>
        /// <returns>Retorna el cliente con todos sus datos</returns>
        public static ClienteNatural consultarDatosClienteNaturalId(int idClienteNat)
        {
            BDConexion laConexion = new BDConexion();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteNatural elCliente = new ClienteNatural();
            Parametro elParametro;

            elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat, 
                SqlDbType.Int, idClienteNat.ToString(), false);
            parametros.Add(elParametro);
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteNat,
                                                                     parametros);
                foreach (DataRow row in resultado.Rows)
                {
                    elCliente.Nat_Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());
                    elCliente.Nat_Nombre = row[RecursoBDModulo2.AliasNombreClienteNat].ToString();
                    elCliente.Nat_Apellido = row[RecursoBDModulo2.AliasApellidoClienteNat].ToString();
                    elCliente.Nat_Cedula = row[RecursoBDModulo2.AliasCedulaClienteNat].ToString();
                    elCliente.Nat_Correo = row[RecursoBDModulo2.AliasCorreoClienteNat].ToString();
                    elCliente.Nat_Telefono.Codigo = row[RecursoBDModulo2.AliasCodigoTelefono].ToString();
                    elCliente.Nat_Telefono.Numero = row[RecursoBDModulo2.AliasNumTelefono].ToString();
                    elCliente.Nat_Direccion.LaDireccion = row[RecursoBDModulo2.AliasNombreDireccion].ToString();
                    elCliente.Nat_Direccion.CodigoPostal = row[RecursoBDModulo2.AliasCodPostalDireccion].ToString();
                    elCliente.Nat_Direccion.LaCiudad = row[RecursoBDModulo2.AliasNombreCiudad].ToString();
                    elCliente.Nat_Direccion.ElEstado = row[RecursoBDModulo2.AliasNombreEstado].ToString();
                    elCliente.Nat_Direccion.ElPais = row[RecursoBDModulo2.AliasNombrePais].ToString();

                }

                return elCliente;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para eliminar un cliente natural
        /// </summary>
        /// <param name="elCliente">Cliente natural que se desea eliminar</param>
        public static void eliminarClienteNatural(ClienteNatural elCliente)
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat, SqlDbType.Int,
                elCliente.Nat_Id.ToString(), false);
            parametros.Add(parametro);
            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.EliminarClienteNat, parametros);
            }
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para modificar cliente natural
        /// </summary>
        /// <param name="elCliente">Cliente que se desea modificar</param>
        public static void modificarClienteNatural(ClienteNatural elCliente)
        {
            BDConexion laConexion = new BDConexion();
            ClienteNatural clienteModificado = new ClienteNatural();
            #region Llenado de parametros
            List<Parametro> parametros = new List<Parametro>();

            Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat, SqlDbType.VarChar,
                elCliente.Nat_Id.ToString(), false);
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

            elParametro = new Parametro(RecursoBDModulo2.ParamDireccion, SqlDbType.VarChar,
                elCliente.Nat_Direccion.LaDireccion, false);
            parametros.Add(elParametro);

            elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                elCliente.Nat_Direccion.CodigoPostal, false);
            parametros.Add(elParametro);

            elParametro = new Parametro(RecursoBDModulo2.ParamCorreoClienteNat, SqlDbType.Int,
                elCliente.Nat_Correo, false);
            parametros.Add(elParametro);

            elParametro = new Parametro(RecursoBDModulo2.ParamCodigoTelef, SqlDbType.Int,
                elCliente.Nat_Telefono.Codigo, false);
            parametros.Add(elParametro);

            elParametro = new Parametro(RecursoBDModulo2.ParamNumeroTelef, SqlDbType.Int,
                elCliente.Nat_Telefono.Numero, false);
            parametros.Add(elParametro);

            #endregion
            try
            {
                laConexion.EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteNat,
                    parametros);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Metodo para consultar en BD toda la lista de paises
        /// </summary>
        /// <returns></returns>
        public static List<String> consultarPaises()
        {
            List<String> laLista = new List<String>();
            BDConexion laConexion = new BDConexion();
            DataTable resultado = new DataTable();
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarPaises, new List<Parametro>());
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
        public static List<String> consultarEstadosPorPais(String elPais)
        {
            List<String> laLista = new List<String>();
            BDConexion laConexion = new BDConexion();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamPais, SqlDbType.VarChar, elPais, false);
            parametros.Add(parametro);
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarEstadosPorPais,
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
        public static List<String> consultarCiudadesPorEstado(String elEstado)
        {
            List<String> laLista = new List<String>();
            BDConexion laConexion = new BDConexion();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursoBDModulo2.ParamEstado, SqlDbType.VarChar, elEstado, false);
            parametros.Add(parametro);
            try
            {
                resultado = laConexion.EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarCiudadesPorEstado,
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

    }
}
