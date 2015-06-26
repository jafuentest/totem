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
   
    public class ComandoListaUsuario :Comando<string, List<Dominio.Entidad>>
    {
        /// <summary>
        /// Comando que obtiene el listado de los involucrados de un proyecto
        /// </summary>
        /// <param name="elProyecto">el objeto Proyecto</param>
        /// <returns>retorna un lista de Usuarios</returns>
        public override List<Dominio.Entidad> Ejecutar(string elProyecto)
        {
            try
            {
                List<int> numInvolucrados = new List<int>();
                List<Dominio.Entidad> usuarios = new List<Dominio.Entidad>();
                FabricaEntidades laFabrica = new FabricaEntidades();
                Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
                FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvMinutas = fabricaDAO.ObtenerDAOInvolucradosMinuta();
                numInvolucrados = daoInvMinutas.ConsultarInvolucrado(RecursosComandosModulo8.ProcedureUsuarioProyecto,
                    RecursosComandosModulo8.AtributoUsuario,
                    RecursosComandosModulo8.ParametroIdProyecto, elProyecto);
                if (numInvolucrados != null)
                {
                    foreach (int i in numInvolucrados)
                    {
                        usuarios.Add((Usuario)daoInvMinutas.ConsultarUsuarioMinutas(i));
                    }
                }

                return usuarios;
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
