using System;
using System.Web;
using Contratos.Modulo1;
using ExcepcionesTotem.Modulo1;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using Comandos;
using Comandos.Fabrica;
using System;
using System.Collections.Generic;


namespace Presentadores.Modulo1
{
    public class PresentadorClave
    {
        private IContratoClave vista;

        public PresentadorClave(IContratoClave laVista)
        {
            vista = laVista;
        }

        public void ManejarEventoPassword_Click(HttpRequest request)
        {
            try
            {
                string correo= request.Cookies["userInfo"]["usuario"];
                if (request.Cookies["userInfo"] == null)
                    throw new ErrorParametroHttpRequest(RecursosM1.Mensaje_parametroHttp); 
                if (string.IsNullOrEmpty(vista.Password) || string.IsNullOrEmpty(vista.PasswordConfirmar))
                    throw  new Exception(RecursosM1.Mensaje_campoVacio);
                if (!vista.Password.Equals(vista.PasswordConfirmar))
                    throw new Exception(RecursosM1.Mensaje_passwordNoCoincide);
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad usuario = fabricaEntidades.ObtenerUsuario();
                Comando<List<string>, string> comandoDesencriptar = FabricaComandos.CrearComandoDesencriptar();
                List<string> lista = new List<string>();
                lista.Add(correo);
                lista.Add(RecursosM1.Passphrase);
                ((Usuario)usuario).Correo = comandoDesencriptar.Ejecutar(lista);
                ((Usuario)usuario).Clave = vista.Password;
                Comando<Entidad, bool> comando = FabricaComandos.CrearComandoCambioDeClave();
                if (comando.Ejecutar(usuario))
                {
                    HttpContext.Current.Response.Redirect("../Modulo1/Login.aspx");
                }
            }
            catch (Exception e)
            {
                vista.setMensaje(true, e.Message);
            }
        }

    }

}
