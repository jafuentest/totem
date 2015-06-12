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
    public class DaoClienteJuridico : DAO, IntefazDAO.Modulo2.IDaoClienteJuridico
    {
        public bool Agregar(Entidad parametro)
        {
            ClienteJuridico elCliente = (ClienteJuridico)parametro; 

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
                List<Resultado> tmp=EjecutarStoredProcedure(RecursoBDModulo2.AgregarClienteJur, parametros);
                return (tmp.ToArray().Length > 0);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public bool Modificar(Entidad parametro)
        {
            ClienteJuridico elCliente = (ClienteJuridico)parametro;
            #region Llenado de parametros
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursoBDModulo2.ParamJurRif, SqlDbType.VarChar,
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
            elParametro = new Parametro(RecursoBDModulo2.ParamCodigoPostal, SqlDbType.Int,
                elCliente.Jur_Direccion.CodigoPostal, false);
            parametros.Add(elParametro);
            #endregion
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursoBDModulo2.ModificarClienteJur,
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
            Parametro parametroStored = new Parametro(RecursoBDModulo2.ParamIDClienteJur,
                SqlDbType.Int, parametro.Id.ToString(), false);
            parametros.Add(parametroStored);
            ClienteJuridico elCliente = new ClienteJuridico();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoBDModulo2.ConsultarDatosClienteJur, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elCliente = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
                    elCliente.Id = int.Parse(row[RecursoBDModulo2.AliasClienteJurID].ToString());

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
            catch (Exception ex)
            {
                //arreglar excepciones
                throw new Exception();
            }
        }
    }
}
