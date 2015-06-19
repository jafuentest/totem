using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Data;


namespace DAO.DAO.Modulo2
{
    public class DaoClienteNatural : DAO, IntefazDAO.Modulo2.IDaoClienteNatural
    {
        public bool Agregar(Entidad parametro)
        {
            ClienteNatural elCliente = (ClienteNatural)parametro;
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
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteNat, parametros);
                return (tmp.ToArray().Length > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(Entidad parametro)
        {
            ClienteNatural elCliente = (ClienteNatural)parametro;
            #region Llenado de parametros
            List<Parametro> parametros = new List<Parametro>();

            Parametro elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat, SqlDbType.VarChar,
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
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteNat,
                    parametros);
                return (tmp.ToArray().Length > 0);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            ClienteNatural elCliente = (ClienteNatural)laFabrica.ObtenerClienteNatural();
            Parametro elParametro;
            Direccion laDireccion;
            Telefono elTelefono;

            elParametro = new Parametro(RecursoBDModulo2.ParamIDClienteNat,
                SqlDbType.Int, parametro.Id.ToString(), false);
            parametros.Add(elParametro);
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteNat,
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

                }

                return elCliente;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

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
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }

        public bool eliminarClienteNatural(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursoBDModulo2.EliminarContacto, SqlDbType.Int,
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

    }
}
