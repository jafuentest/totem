using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;
using DAO.Fabrica;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using ExcepcionesTotem;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo8
{
    class ComandoObtenerMinuta : Comando<String, Dominio.Entidad>
    {
        public override Dominio.Entidad Ejecutar(String parametro)
        {
            List<int> invo = new List<int>();
            List<int> invoAcuerdo = new List<int>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuariosAcuerdo = new List<Usuario>();
            List<Contacto> contactos = new List<Contacto>();
            List<Contacto> contactosAcuerdo = new List<Contacto>();
            List<Acuerdo> listaAcuerdos = new List<Acuerdo>();
            try
            {
                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoMinuta daoMinuta = fabricaDAO.ObtenerDAOMinuta();
                
                FabricaEntidades laFabrica = new FabricaEntidades();
                Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
                
                string[] parametros = parametro.Split(';');
                int codigoMinuta = int.Parse(parametros[0]);
                string codigoProyecto = parametros[1];
                
                laMinuta = (Minuta)daoMinuta.ConsultarMinutaBD(codigoMinuta);
                
                usuarios.Clear();

                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvMinutas = fabricaDAO.ObtenerDAOInvolucradosMinuta();

                invo = daoInvMinutas.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarUsuarioMinuta
                    , RecursosComandosModulo8.AtributoAcuerdoUsuario, RecursosComandosModulo8.ParametroIDMinuta, laMinuta.Codigo);
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        usuarios.Add((Usuario)daoInvMinutas.ConsultarUsuarioMinutas(i));
                    }
                    laMinuta.ListaUsuario = usuarios;
                }
                invo.Clear();
                invo = daoInvMinutas.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarContactoMinuta,
                    RecursosComandosModulo8.AtributoAcuerdoContacto, RecursosComandosModulo8.ParametroIDMinuta, laMinuta.Codigo);
                if (invo.Count != 0)
                {
                    foreach (int i in invo)
                    {
                        contactos.Add((Contacto)daoInvMinutas.ConsultarContactoMinutas(i));
                    }
                    laMinuta.ListaContacto = contactos;
                }

                DAO.IntefazDAO.Modulo8.IDaoPunto daoPunto = fabricaDAO.ObtenerDAOPunto();

                //No se Como Hacer Para castear en lista tanto de acuerdo como de punto

                /*laMinuta.ListaPunto = (List<Punto>)daoPunto.ConsultarPuntoBD(int.Parse(laMinuta.Codigo));

                DAO.IntefazDAO.Modulo8.IDaoAcuerdo daoAcuerdo = fabricaDAO.ObtenerDAOAcuerdo();
                listaAcuerdos = (List<Acuerdo>)daoAcuerdo.ConsultarTodos(int.Parse(minuta.Codigo));
                foreach (Acuerdo acu in listaAcuerdos)
                {
                    invoAcuerdo = daoInvMinutas.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureConsultarUsuarioAcuerdo
                          , RecursosComandosModulo8.AtributoAcuerdoUsuario, RecursosComandosModulo8.ParametroIDAcuerdo, acu.Codigo.ToString());
                    if (invoAcuerdo != null)
                    {
                        foreach (int a in invoAcuerdo)
                        {
                            usuariosAcuerdo.Add((Usuario)daoInvMinutas.ConsultarUsuarioMinutas(a));
                        }
                        acu.ListaUsuario = usuariosAcuerdo;
                    }
                    usuariosAcuerdo = null;
                    usuariosAcuerdo = new List<Usuario>();
                    invo.Clear();

                }
                laMinuta.ListaAcuerdo = listaAcuerdos;*/
                return laMinuta;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosComandosModulo8.Codigo_ExcepcionNullReference,
                    RecursosComandosModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosComandosModulo8.Codigo,
                    RecursosComandosModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosComandosModulo8.Codigo_ExcepcionSql,
                    RecursosComandosModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosComandosModulo8.Codigo_ExcepcionParametro,
                    RecursosComandosModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosComandosModulo8.Codigo_ExcepcionAtributo,
                    RecursosComandosModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosComandosModulo8.Codigo_ExcepcionGeneral,
                   RecursosComandosModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }
    }
}
