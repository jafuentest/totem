using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatosTotem.Modulo8;
using DominioTotem;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;

namespace LogicaNegociosTotem.Modulo8
{
    public class LogicaMinuta
    {
        private BDMinuta minutaDatos = new BDMinuta();
        private BDInvolucrados involucrados = new BDInvolucrados();
        private BDPunto puntos = new BDPunto();
        private BDAcuerdo acuerdos = new BDAcuerdo();
        private Minuta minuta;
        private List<Usuario> usuarios;
        private List<Contacto> contactos;
        private List<Acuerdo> listaAcuerdos;

        /// <summary>
        /// Metodo que lista todas las minutas de un Proyecto
        /// </summary>
        /// <param name="elProyecto">id del Proyecto</param>
        /// <returns>Retorna una Lista de Minutas</returns>
        public List<Minuta> ListaMinuta(Proyecto elProyecto)
        {
            try
            {
                return minutaDatos.ConsultarMinutasProyecto(elProyecto.Codigo);
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }

        /// <summary>
        /// Metodo que Obtiene todos los campos de una Minuta
        /// </summary>
        /// <param name="elProyecto">id del proyecto asociado a la minuta</param>
        /// <param name="codigoMinuta">codigo de la minuta a consultar</param>
        /// <returns>Retorna el Objeto Minuta</returns>
        public Minuta obtenerMinuta(Proyecto elProyecto, int codigoMinuta)
        {
            List<int> invo = new List<int>();
            List<int> invoAcuerdo = new List<int>();
            usuarios = new List<Usuario>();
            List<Usuario> usuariosAcuerdo = new List<Usuario>();
            contactos = new List<Contacto>();
            List<Contacto> contactosAcuerdo = new List<Contacto>();
            listaAcuerdos = new List<Acuerdo>();
            try
            {
                minuta = minutaDatos.ConsultarMinutaBD(codigoMinuta);
                usuarios.Clear();
                invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioMinuta
                    , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDMinuta, minuta.Codigo);
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        usuarios.Add(involucrados.ConsultarUsuarioMinutas(i));
                    }
                    minuta.ListaUsuario = usuarios;
                }
                invo.Clear();
                invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarContactoMinuta,
                    RecursosLogicaModulo8.AtributoAcuerdoContacto, RecursosLogicaModulo8.ParametroIDMinuta, minuta.Codigo);
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        contactos.Add(involucrados.ConsultarContactoMinutas(i));
                    }
                    minuta.ListaContacto = contactos;
                }
                minuta.ListaPunto = puntos.ConsultarPuntoBD(int.Parse(minuta.Codigo));

                listaAcuerdos = acuerdos.ConsultarAcuerdoBD(int.Parse(minuta.Codigo));
                      foreach (Acuerdo acu in listaAcuerdos)
                          {
                                invoAcuerdo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioAcuerdo
                                      , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDAcuerdo, acu.Codigo.ToString());
                                if (invoAcuerdo != null)
                                  {
                                      foreach (int a in invoAcuerdo)
                                      {
                                          usuariosAcuerdo.Add(involucrados.ConsultarUsuarioMinutas(a));
                                      }
                                    acu.ListaUsuario = usuariosAcuerdo;
                                  }
                                usuariosAcuerdo = null;
                                usuariosAcuerdo = new List<Usuario>();
                               invo.Clear();

                          }
                minuta.ListaAcuerdo = listaAcuerdos;
                return minuta;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }

        /// <summary>
        /// Metodo que obtiene el listado de los involucrados de un proyecto
        /// </summary>
        /// <param name="elProyecto">el objeto Proyecto</param>
        /// <returns>retorna un lista de Usuarios</returns>
        public List<Usuario> ListaUsuario(Proyecto elProyecto)
        {
            List<int> numInvolucrados = new List<int>();
            usuarios= new List<Usuario>();
            try
            {
                numInvolucrados = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureUsuarioProyecto,
                    RecursosLogicaModulo8.AtributoUsuario,
                    RecursosLogicaModulo8.ParametroIdProyecto, elProyecto.Codigo);
                if (numInvolucrados != null)
                {
                    foreach (int i in numInvolucrados)
                    {
                        usuarios.Add(involucrados.ConsultarUsuarioMinutas(i));
                    }
                }

                return usuarios;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }

        /// <summary>
        /// Metodo que obtiene el listado de los involucrados de un proyecto
        /// </summary>
        /// <param name="elProyecto">el objeto Proyecto</param>
        /// <returns>retorna un lista de Contactos</returns>
        public List<Contacto> ListaContacto(Proyecto elProyecto)
        {
            List<int> numInvolucrados = new List<int>();
            contactos = new List<Contacto>();
            try
            {
                numInvolucrados = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureContactoProyecto, RecursosLogicaModulo8.AtributoContacto,
                    RecursosLogicaModulo8.ParametroIdProyecto, elProyecto.Codigo);
                if (numInvolucrados != null)
                {
                    foreach (int i in numInvolucrados)
                    {
                        contactos.Add(involucrados.ConsultarContactoMinutas(i));
                    }
                }
                return contactos;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }

        /// <summary>
        /// Metodo que conecta con la capa de datos para guardar la minuta en la BD
        /// </summary>
        /// <param name="elProyecto">Obejeto Proyecto</param>
        /// <param name="laMinuta">Objeto Minuta</param>
        /// <returns>Retorna un string para saber si la operación se llevo con éxito</returns>
        public string GuardarMinuta(Proyecto elProyecto, Minuta laMinuta)
        {
            involucrados = new BDInvolucrados();
            usuarios = new List<Usuario>();
            contactos = new List<Contacto>();
            minutaDatos.AgregarMinuta(laMinuta);
            try
            {
                if (laMinuta.ListaPunto != null)
                {
                    foreach (Punto pun in laMinuta.ListaPunto)
                    {
                        puntos.AgregarPuntoBD(pun);
                    }
                }
                if (laMinuta.ListaUsuario != null)
                {
                    foreach (Usuario usu in laMinuta.ListaUsuario)
                    {
                        involucrados.AgregarInvolucradoEnMinuta(usu.idUsuario, elProyecto.Codigo,
                            RecursosLogicaModulo8.ProcedureAgregarUsuarioMinuta, RecursosLogicaModulo8.ParametroIdUsuario);
                    }
                }
                if (laMinuta.ListaContacto != null)
                {
                    foreach (Contacto con in laMinuta.ListaContacto)
                    {
                        involucrados.AgregarInvolucradoEnMinuta(con.Con_Id, elProyecto.Codigo, RecursosLogicaModulo8.ProcedureAgregarContactoMinuta,
                            RecursosLogicaModulo8.ParametroIdContacto);
                    }
                }
                if (laMinuta.ListaAcuerdo != null)
                {
                    foreach (Acuerdo acu in laMinuta.ListaAcuerdo)
                    {
                        acuerdos.AgregarAcuerdosBD(acu, elProyecto.Codigo);
                        usuarios = acu.ListaUsuario;
                        if (usuarios != null)
                        {
                            foreach (Usuario usu in usuarios)
                            {
                                involucrados.AgregarUsuarioEnAcuerdo(usu, elProyecto.Codigo);
                            }
                        }
                        contactos = acu.ListaContacto;
                        if (contactos != null)
                        {
                            foreach (Contacto con in contactos)
                            {
                                involucrados.AgregarContactoEnAcuerdo(con, elProyecto.Codigo);
                            }
                        }
                    }
                }

                return "Completado";
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }
           
        }


        public string ModificarMinuta(Proyecto elProyecto, Minuta laMinuta)
        {
            

            
            return "Completado";
        }
    }
}
