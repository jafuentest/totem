using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;
using System.Data;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8;

using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using System.Data.SqlClient;

namespace DAO.DAO.Modulo8
{
    public class DaoInvolucradosMinuta : DAO, IntefazDAO.Modulo8.IDaoInvolucradosMinuta
    {

        public bool Agregar(Entidad parametro)
        {
           throw new NotImplementedException();
        }
        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
             throw new NotImplementedException();
        }


         /// <summary>
        /// Metodo para consultar los datos de Usuario
        /// </summary>
        /// <param name="idUsuario">id del Usuarios</param>
        /// <returns>Retorna el Objeto Usuario</returns>
        public Entidad ConsultarUsuarioMinutas(int idUsuario)
        {

            Usuario elUsuario;
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDUsuario,
                SqlDbType.Int, idUsuario.ToString(), false);
            parametros.Add(parametroStored);

            elUsuario = (Usuario)laFabrica.ObtenerUsuario();

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarUsuarios, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elUsuario.Id = int.Parse(row[RecursosBDModulo8.AtributoIDUsuario].ToString());
                    elUsuario.Nombre = row[RecursosBDModulo8.AtributoNombreUsuario].ToString();
                    elUsuario.Apellido = row[RecursosBDModulo8.AtributoApellidoUsuario].ToString();
                    elUsuario.Cargo = row[RecursosBDModulo8.AtributoCargoUsuario].ToString();
                   
                }  

               
           }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        return elUsuario;
        }

        /// <summary>
        /// Metodo para consultar los datos de contacto
        /// </summary>
        /// <param name="idContacto">id del Contacto</param>
        /// <returns>Retorna el Objeto Contacto</returns>
        public Entidad ConsultarContactoMinutas(int idContacto)
        {
            

            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDContacto,
                SqlDbType.Int, idContacto.ToString(), false);
            parametros.Add(parametroStored);
            
            Contacto elContacto = (Contacto)laFabrica.ObtenerContacto();;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarContactos, parametros);

                foreach (DataRow row in resultado.Rows)
                {


                    
                    elContacto.Id=int.Parse( row[RecursosBDModulo8.AtributoIDContacto].ToString());
                    elContacto.Con_Nombre=row[RecursosBDModulo8.AtributoNombreContacto].ToString();
                    elContacto.Con_Apellido=row[RecursosBDModulo8.AtributoApellidoContacto].ToString();
                    elContacto.ConCargo=row[RecursosBDModulo8.AtributoCargoContacto].ToString();
                   
                }  

               
           }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        return elContacto;
        }

        /// <summary>
        /// Metodo que para la consulta de todos los involucrados en una Minuta o los responsables de un Acuerdo
        /// </summary>
        /// <param name="procedure">Es el nombre del procedimiento que se ejecutara</param>
        /// <param name="atributoInvo">Es el id del Contacto o Usuario segun sea el caso que el procedimiento
        /// retornara</param>
        /// <param name="parametro">Es el nombre del parametro minuta que que ejecuta en la BD el 
        /// procedimiento</param>
        /// <param name="id">Es el id del Acuerdo o Minuta que se encuentra vinculado con los 
        /// Involucrados</param>
        /// <returns></returns>
        public List<int> ConsultarInvolucrado(string procedure, string atributoInvo, string parametro, string id)
        {
          
            List<int> laLista = new List<int>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(parametro,
                SqlDbType.VarChar, id, false);
            parametros.Add(parametroStored);

            try
            {
                resultado = EjecutarStoredProcedureTuplas(procedure, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    laLista.Add( int.Parse(row[atributoInvo].ToString()));
                }


            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
            return laLista;


        }

        /// <summary>
        /// Metodo para agregar un Usuario a la BD
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean AgregarUsuarioEnAcuerdo(Entidad usuario,string idAcuerdo, string idProyecto)
        {
            
            Usuario elUsuario = (Usuario)usuario;


            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int,
                elUsuario.Id.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.VarChar,
                idProyecto.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                idAcuerdo, false);
            parametros.Add(parametroStored);


            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarUsuarioAcuerdo, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }


        /// <summary>
        /// Metodo para agregar involucrado a la BD
        /// </summary>
        /// <param name="involucrado">involucrado a agregar</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <param name="procedure">procedure a llamar</param>
        /// <param name="parametro">parametro a utilizar</param>
        /// <param name="idMinuta">id de la minuta</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean AgregarInvolucradoEnMinuta(int involucrado, string idProyecto, string procedure, string parametro,int idMinuta)
        {
           
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(parametro, SqlDbType.Int,
                involucrado.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.VarChar,
                idProyecto, false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                idMinuta.ToString(), false);
            parametros.Add(parametroStored);


            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(procedure, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }


        }

        
        /// <summary>
        /// Metodo para Agregar un Contacto a un Acuerdo a la BD
        /// </summary>
        /// <param name="listaContacto">lista de Contactos a agregar</param>
        /// <param name="idAcuerdo">id del Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean AgregarContactoEnAcuerdo(Entidad contacto,string idAcuerdo, string idProyecto)
        {
            

            Contacto elContacto = (Contacto)contacto;


            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDContacto, SqlDbType.Int,
                elContacto.Id.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.VarChar,
                idAcuerdo, false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.VarChar,
                idProyecto, false);
            parametros.Add(parametroStored);


            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarContactoAcuerdo, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }
        /// <summary>
        /// Metodo para eliminar un Usuario de un Acuerdo
        /// </summary>
        /// <param name="listaUsuario">lista de Usuario que se desea eliminar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id del Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean EliminarUsuarioEnAcuerdo(Entidad usuario, int idAcuerdo, string idProyecto)
        {
            Usuario elUsuario = (Usuario)usuario;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int, idAcuerdo.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int, elUsuario.Id.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.VarChar, idProyecto.ToString(), false);
            parametros.Add(parametroStored);
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }


        }
        /// <summary>
        /// Metodo para eliminar un Contacto de un Acuerdo
        /// </summary>
        /// <param name="contacto"> Contacto a eliminar</param>
        /// <param name="idAcuerdo">id del acuerdo vinculado</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        public Boolean EliminarContactoEnAcuerdo(Entidad contacto, int idAcuerdo, string idProyecto)
        {
            Contacto elContacto = (Contacto)contacto;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int, idAcuerdo.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDContacto, SqlDbType.Int, elContacto.Id.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.VarChar, idProyecto.ToString(), false);
            parametros.Add(parametroStored);
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoEliminarAcuerdoContacto, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }


        }

        /// <summary>
        /// Metodo para eliminar involucrados de una minuta
        /// </summary>
        /// <param name="idMinuta">minuta a eliminar involucrados</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        public bool EliminarInvolucradoEnMinuta(int idMinuta)
        {
           

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int, idMinuta.ToString(), false);
            parametros.Add(parametroStored);
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedureEliminarInvolucradoMinuta, parametros);
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }

       

       


    }

}