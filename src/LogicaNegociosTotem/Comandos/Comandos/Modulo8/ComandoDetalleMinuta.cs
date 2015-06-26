

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;
using DAO.Fabrica;
using DAO.DAO.Modulo8;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo8
{
    public class ComandoDetalleMinuta : Comando<String,Dominio.Entidad>
    {

        public override Entidad Ejecutar(String parametro)
        {
            List<int> invo = new List<int>();
            List<int> invoAcuerdo = new List<int>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuariosAcuerdo = new List<Usuario>();
            List<Contacto> contactos = new List<Contacto>();
            List<Contacto> contactosAcuerdo = new List<Contacto>();
            List<Acuerdo> listaAcuerdos = new List<Acuerdo>();
            Minuta minuta;
            try
            {
                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoMinuta daoMinuta = fabricaDAO.ObtenerDAOMinuta();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvolucradosMinuta = fabricaDAO.ObtenerDAOInvolucradosMinuta();
                DAO.IntefazDAO.Modulo8.IDaoPunto daoPunto = fabricaDAO.ObtenerDAOPunto();
                DAO.IntefazDAO.Modulo8.IDaoAcuerdo daoAcuerdo = fabricaDAO.ObtenerDAOAcuerdo();
               
                minuta = (Minuta)daoMinuta.ConsultarMinutaBD(int.Parse(parametro));
                usuarios.Clear();
                invo = daoInvolucradosMinuta.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarUsuarioMinuta
                    , RecursosComandosModulo8.AtributoAcuerdoUsuario, RecursosComandosModulo8.ParametroIDMinuta, minuta.Id.ToString());
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        usuarios.Add((Usuario)daoInvolucradosMinuta.ConsultarUsuarioMinutas(i));
                    }
                    minuta.ListaUsuario = usuarios;
                }
                invo.Clear();
                invo = daoInvolucradosMinuta.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarContactoMinuta,
                    RecursosComandosModulo8.AtributoAcuerdoContacto, RecursosComandosModulo8.ParametroIDMinuta, minuta.Id.ToString());
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        contactos.Add((Contacto)daoInvolucradosMinuta.ConsultarContactoMinutas(i));
                    }
                    minuta.ListaContacto = contactos;
                }
                minuta.ListaPunto = daoPunto.ConsultarPuntoBD(minuta.Id).Cast<Punto>().ToList();


                listaAcuerdos = daoAcuerdo.ConsultarTodos(minuta.Id).Cast<Acuerdo>().ToList();
                          foreach (Acuerdo acu in listaAcuerdos)
                              {
                                    invoAcuerdo = daoInvolucradosMinuta.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarUsuarioAcuerdo
                                          , RecursosComandosModulo8.AtributoAcuerdoUsuario, RecursosComandosModulo8.ParametroIDAcuerdo, acu.Id.ToString());
                                    if (invoAcuerdo != null)
                                      {
                                          foreach (int a in invoAcuerdo)
                                          {
                                              usuariosAcuerdo.Add((Usuario)daoInvolucradosMinuta.ConsultarUsuarioMinutas(a));
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
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
