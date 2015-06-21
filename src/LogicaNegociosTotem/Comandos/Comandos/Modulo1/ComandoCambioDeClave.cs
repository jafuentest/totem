using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using DAO.DAO;
using DAO.IntefazDAO.Modulo1;
using DAO.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando que se utiliza para cambiar la clave de un usuario
    /// </summary>
    public class ComandoCambioDeClave : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                ((Usuario)parametro).CalcularHash();
                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin = fabricaDao.ObtenerDaoLogin();
                return  idaoLogin.Modificar(((Usuario)parametro));
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
        }
    }
}
