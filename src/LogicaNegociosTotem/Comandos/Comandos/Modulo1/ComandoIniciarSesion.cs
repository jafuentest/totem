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
    /// Comando que se utiliza para validar el inicio de sesion de un usuario
    /// </summary>
    public class ComandoIniciarSesion : Comando<List<string>, Entidad>
    {
        public override Entidad Ejecutar(List<string> parametro)
        {
            bool captchaActivo= false;
            int intentos= 0;
            try
            {
                if (!captchaActivo)
                {
                    intentos++;
                }
                Entidad usuario = FabricaEntidades.ObtenerUsuario();
                ((Usuario)usuario).Username = parametro[0];
                ((Usuario)usuario).Clave= parametro[1];
                ((Usuario)usuario).CalcularHash();
                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin= fabricaDao.ObtenerDaoLogin();
                usuario = idaoLogin.ValidarUsuarioLogin(((Usuario)usuario));
                intentos = 0;
                captchaActivo = false;
                return usuario;

            }
            catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
            {
                if (intentos >=Convert.ToInt32( RecursosComandoModulo1.Cantidad_Intentos_Permitidos))
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                    throw ex;
                }
                else
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                     ex);

                    throw ex;
                }
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                if (intentos >= Convert.ToInt32(RecursosComandoModulo1.Cantidad_Intentos_Permitidos))
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                    throw ex;
                }
                else
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                       ex);

                    throw ex;
                }
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                if (intentos >= Convert.ToInt32(RecursosComandoModulo1.Cantidad_Intentos_Permitidos))
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                    throw ex;
                }
                else
                {
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                     ex);

                    throw ex;
                }
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
        }
    }
}
