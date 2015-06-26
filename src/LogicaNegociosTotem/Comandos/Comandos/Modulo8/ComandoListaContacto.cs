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

namespace Comandos.Comandos.Modulo8
{
    public class ComandoListaContacto : Comando<String, List<Dominio.Entidad>>
    {
        public override List<Dominio.Entidad> Ejecutar(String parametro)
        {
            try
            {
                List<int> numInvolucrados = new List<int>();
                List<Dominio.Entidad> contactos = new List<Dominio.Entidad>();
                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvMinutas = fabricaDAO.ObtenerDAOInvolucradosMinuta();
                numInvolucrados = daoInvMinutas.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureContactoProyecto, RecursosComandosModulo8.AtributoContacto,
                    RecursosComandosModulo8.ParametroIdProyecto, parametro);
                if (numInvolucrados != null)
                {
                    foreach (int i in numInvolucrados)
                    {
                        contactos.Add(daoInvMinutas.ConsultarContactoMinutas(i));
                    }
                }
                return contactos;
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
