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
using Dominio.Entidades.Modulo4;
using Dominio;

namespace Comandos.Comandos.Modulo8
{
    public class ComandoGuardarMinuta : Comando<List<Entidad>, string>
    {
        public override string Ejecutar(List<Entidad> parametro)
        {
            try
            {


                Proyecto elProyecto = (Proyecto)parametro[0];
                Minuta laMinuta = (Minuta)parametro[1];
                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvMinutas = fabricaDAO.ObtenerDAOInvolucradosMinuta();

                List<Dominio.Entidad> usuarios = new List<Dominio.Entidad>();
                List<Dominio.Entidad> contactos = new List<Dominio.Entidad>();

                DAO.IntefazDAO.Modulo8.IDaoMinuta daoMinutas = fabricaDAO.ObtenerDAOMinuta();
                DAO.IntefazDAO.Modulo8.IDaoAcuerdo daoAcuerdos = fabricaDAO.ObtenerDAOAcuerdo();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvolucradosMinuta = fabricaDAO.ObtenerDAOInvolucradosMinuta();
                DAO.IntefazDAO.Modulo4.IDaoProyecto daoProyectos = fabricaDAO.ObtenerDAOProyecto();

                int idMinuta = daoMinutas.AgregarMinuta(laMinuta);
                DAO.IntefazDAO.Modulo8.IDaoPunto daoPuntos = fabricaDAO.ObtenerDAOPunto();

                if (laMinuta.ListaPunto != null)
                {
                    foreach (Punto pun in laMinuta.ListaPunto)
                    {
                        int auxiliar = daoPuntos.AgregarPunto(pun, idMinuta);
                    }
                }

                if (laMinuta.ListaUsuario != null)
                {
                    foreach (Usuario usu in laMinuta.ListaUsuario)
                    {
                        bool aux = daoInvMinutas.AgregarInvolucradoEnMinuta(usu.Id, elProyecto.Codigo,
                            RecursosComandosModulo8.ProcedureAgregarUsuarioMinuta, RecursosComandosModulo8.ParametroIdUsuario, idMinuta);
                    }
                }

                if (laMinuta.ListaContacto != null)
                {
                    foreach (Contacto con in laMinuta.ListaContacto)
                    {
                        bool aux2 = daoInvMinutas.AgregarInvolucradoEnMinuta(con.Id, elProyecto.Codigo, RecursosComandosModulo8.ParametroIdContacto, RecursosComandosModulo8.ProcedureAgregarUsuarioMinuta, idMinuta);
                    }
                }
                if (laMinuta.ListaAcuerdo != null)
                {
                    foreach (Acuerdo acu in laMinuta.ListaAcuerdo)
                    {
                        daoAcuerdos.AgregarAcuerdo(acu, idMinuta, elProyecto.Codigo);
                        /*usuarios = acu.ListaUsuario;
                        if (usuarios != null)
                        {
                            foreach (Usuario usu in usuarios)
                            {
                                daoInvolucradosMinuta.AgregarUsuarioEnAcuerdo(usu, elProyecto.Codigo);
                            }
                        }
                        contactos = acu.ListaContacto;
                        if (contactos != null)
                        {
                            foreach (Contacto con in contactos)
                            {
                                daoInvolucradosMinuta.AgregarContactoEnAcuerdo(con, elProyecto.Codigo);
                            }
                        }*/
                    }
                }
                return idMinuta.ToString();
            }

            #region catch
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
            #endregion
        }
    }
}
