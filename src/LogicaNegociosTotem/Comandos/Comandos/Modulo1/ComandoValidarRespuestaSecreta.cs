using Dominio;
using DAO.IntefazDAO.Modulo1;
using DAO.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando para validar la respuesta que da un usuario a su pregunta secreta
    /// </summary>
    public class ComandoValidarRespuestaSecreta : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin = fabricaDao.ObtenerDaoLogin();
                if (idaoLogin.ValidarRespuestaSeguridad(parametro))
                {
                    return true;
                }
                else
                {
                    ExcepcionesTotem.Modulo1.RespuestaErradoException ex = new ExcepcionesTotem.Modulo1.RespuestaErradoException(
                        RecursosComandoModulo1.Codigo_Respuesta_Errada,
                        RecursosComandoModulo1.Mensaje_Respuesta_Errada,
                        new ExcepcionesTotem.Modulo1.RespuestaErradoException());
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);

                    throw ex;
                }
            }
            catch (ExcepcionesTotem.Modulo1.RespuestaErradoException ex)
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
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
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
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);

                throw ex;
            }
        }
    }
}
