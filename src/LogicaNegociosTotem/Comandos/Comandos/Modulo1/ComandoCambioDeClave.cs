using Dominio;
using Dominio.Entidades.Modulo7;
using DAO.IntefazDAO.Modulo1;
using DAO.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando que se utiliza para cambiar la clave de un usuario
    /// </summary>
    public class ComandoCambioDeClave : Comando<Entidad, bool>
    {
        /// <summary>
        /// Comando que ejecuta la logica del cambio de clave de un usuario
        /// </summary>
        /// <param name="parametro">Entidad de tipo Usuario</param>
        /// <returns>retorna true si la clave se cambio satisfactoriamente,
        /// de lo contrario devueleve false</returns>
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
