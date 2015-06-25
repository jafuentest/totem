using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using Dominio;
using DAO.Fabrica;
using DAO.DAO.Modulo8;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo8
{
    public class ComandoListaMinuta : Comando<String,List<Dominio.Entidad>>
    {

        public override List<Dominio.Entidad> Ejecutar(String parametro)
        {
            try
            {
                FabricaAbstractaDAO fabricaDAO = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                DAO.IntefazDAO.Modulo8.IDaoMinuta daoMinuta = fabricaDAO.ObtenerDAOMinuta();
                return daoMinuta.ConsultarMinutasProyecto(parametro);
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
