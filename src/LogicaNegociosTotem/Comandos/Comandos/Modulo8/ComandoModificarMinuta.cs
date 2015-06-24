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
using Comandos.Fabrica;
using Dominio;
using Dominio.Entidades;

namespace Comandos.Comandos.Modulo8
{
    class ComandoModificarMinuta : Comando<string, string>
    {
        public override string Ejecutar(List<Entidad> parametro)
        {
            try
            {

                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvMinutas = fabricaDAO.ObtenerDAOInvolucradosMinuta();

                List<Dominio.Entidad> usuarios = new List<Dominio.Entidad>();
                List<Dominio.Entidad> contactos = new List<Dominio.Entidad>();

                DAO.IntefazDAO.Modulo8.IDaoMinuta daoMinutas = fabricaDAO.ObtenerDAOMinuta();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvolucradosMinuta = fabricaDAO.ObtenerDAOInvolucradosMinuta();
                DAO.IntefazDAO.Modulo8.IDaoAcuerdo daoAcuerdo = fabricaDAO.ObtenerDAOAcuerdo();
                DAO.IntefazDAO.Modulo8.IDaoPunto daoPunto = fabricaDAO.ObtenerDAOPunto();
                DAO.IntefazDAO.Modulo4.IDaoProyecto daoProyectos = fabricaDAO.ObtenerDAOProyecto();


                Proyecto elProyecto = (Proyecto)parametro[0];
                Minuta nueva=(Minuta)parametro[1];
                Minuta laMinuta=(Minuta)parametro[2];

                
                daoInvolucradosMinuta.EliminarInvolucradoEnMinuta(int.Parse(laMinuta.Codigo));
                foreach (Acuerdo acu in laMinuta.ListaAcuerdo)
                {
                    if (acu.ListaUsuario != null)
                    {
                        foreach (Usuario usu in acu.ListaUsuario)
                        {
                            daoInvolucradosMinuta.EliminarUsuarioEnAcuerdo(usu, acu.Id, elProyecto.Codigo);
                        }
                    }
                    if (acu.ListaContacto != null)
                    {
                        foreach (Contacto con in acu.ListaContacto)
                        {
                            daoInvolucradosMinuta.EliminarContactoEnAcuerdo(con, acu.Id, elProyecto.Codigo);
                        }
                    }
                  // PACHECOoooooooooo
                   // daoAcuerdo.EliminarAcuerdoBD(acu.Codigo);
                }

                foreach (Punto pun in laMinuta.ListaPunto)
                {
                    daoPunto.EliminarPuntoBD(pun, int.Parse(laMinuta.Codigo));
                }

                daoMinutas.EliminarMinuta(int.Parse(laMinuta.Codigo));
                List<Entidad>parametroGuardar=new List<Entidad>();
                parametroGuardar.Add(elProyecto);
                parametroGuardar.Add(nueva);

                ComandoGuardarMinuta c=(ComandoGuardarMinuta)FabricaComandos.CrearComandoGuardarMinuta();
             //   c.Ejecutar(parametroGuardar);

                

                return "Completado";
                
                
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