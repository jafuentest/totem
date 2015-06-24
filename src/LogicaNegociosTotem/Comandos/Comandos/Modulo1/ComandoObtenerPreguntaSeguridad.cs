using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using DAO.IntefazDAO.Modulo1;
using DAO.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando que sirve para obtener la pregunta de seguridad de un usuario mediante 
    /// su correo
    /// </summary>
    public class ComandoObtenerPreguntaSeguridad : Comando<Entidad, Entidad>
    {
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad usuario = fabricaEntidades.ObtenerUsuario();
                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin = fabricaDao.ObtenerDaoLogin();
                usuario =idaoLogin.ObtenerPreguntaSeguridad(parametro);
                if (((Usuario)usuario).PreguntaSeguridad!= null && ((Usuario)usuario).PreguntaSeguridad!="")
                {
                    return usuario;
                }
                else
                {
                    ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                    RecursosComandoModulo1.Codigo_Usuario_Vacio,
                    RecursosComandoModulo1.Mensaje_Usuario_Vacio,
                    new ExcepcionesTotem.Modulo1.UsuarioVacioException());

                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    excep);

                    throw excep;
                }
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
