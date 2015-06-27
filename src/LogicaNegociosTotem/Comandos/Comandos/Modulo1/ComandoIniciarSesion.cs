using System;
using System.Collections.Generic;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using Datos.IntefazDAO.Modulo1;
using Datos.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    /// <summary>
    /// Comando que se utiliza para validar el inicio de sesion de un usuario
    /// </summary>
    public class ComandoIniciarSesion : Comando<List<string>, Entidad>
    {
        public bool captchaActivo = false;
        private int intentos = 0;

        public override Entidad Ejecutar(List<string> parametro)
        {
            try
            {
                if (!captchaActivo)
                {
                   intentos++;
                }
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad usuario = fabricaEntidades.ObtenerUsuario();
                ((Usuario)usuario).Username = parametro[0];
                ((Usuario)usuario).Clave= parametro[1];
                ((Usuario)usuario).CalcularHash();
                FabricaDAOSqlServer fabricaDao = new FabricaDAOSqlServer();
                IDaoLogin idaoLogin= fabricaDao.ObtenerDaoLogin();
                usuario = idaoLogin.ValidarUsuarioLogin(((Usuario)usuario));
                intentos = 0;
                captchaActivo = false;
                if (usuario != null && ((Usuario)usuario).Nombre != null && ((Usuario)usuario).Nombre != "")
                {
                    return usuario;
                }
                else
                {
                    ExcepcionesTotem.Modulo1.LoginErradoException excep = new ExcepcionesTotem.Modulo1.LoginErradoException(
                           RecursosComandoModulo1.Codigo_Login_Errado,
                           RecursosComandoModulo1.Mensaje_Login_Errado, new Exception());
                    ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    excep);

                    throw excep;
                }

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
