using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Data;

namespace DAO.DAO.Modulo_2
{
    public class DaoClienteJuridico : DAO, IntefazDAO.Modulo_2.IDaoClienteJuridico
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
            return true;
        }
        public Entidad ConsultarXId(Entidad parametro)
        {
            return new FabricaEntidades().ObtenerClienteJuridico();
        }
        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }
    }
}
