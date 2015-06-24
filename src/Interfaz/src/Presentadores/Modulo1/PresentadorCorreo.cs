using System;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using System.Text.RegularExpressions;
using Comandos;
using Comandos.Fabrica;
using System.Collections.Generic;
using System.Web;


namespace Presentadores.Modulo1
{
    
    public class PresentadorCorreo
    {
        private IContratoCorreo vista;

        public PresentadorCorreo(IContratoCorreo laVista)
        {
            vista = laVista;
        }

        public void ManejarEventoCorreo_Click()
        {
            string correo = vista.Correo;

            if (correo.Equals(""))
            {
                vista.Mensaje = "Debe Ingresar un Correo";
            }
            else
            {
                try
                {
                    FabricaEntidades fabricaEntidades = new FabricaEntidades();
                    Entidad usuario = fabricaEntidades.ObtenerUsuario();
                    ((Usuario)usuario).Correo = correo;
                    bool esCorreo = Regex.IsMatch(correo,
                        RecursosM1.Expresion_Regular_Correo,
                        RegexOptions.IgnoreCase);
                    if (esCorreo)
                    {
                        Comando<string, bool> comando = FabricaComandos.CrearComandoValidarCorreoExistente();
                        esCorreo = comando.Ejecutar(correo);
                        if (esCorreo)
                        {
                            List<string> lista = new List<string>();
                            lista.Add(((Usuario)usuario).Correo);
                            lista.Add(RecursosM1.Passphrase);
                            Comando<List<string>, string> comandoEncrip = FabricaComandos.CrearComandoEncriptar();
                            string link = RecursosM1.Link_Recuperacion_Clave;
                            link = link + comandoEncrip.Ejecutar(lista);
                            HttpContext.Current.Response.Redirect(link);
                        }
                        else
                        {
                            ExcepcionesTotem.Modulo1.EmailErradoException excep = new ExcepcionesTotem.Modulo1.EmailErradoException(
                            RecursosM1.Codigo_Email_Errado,
                            RecursosM1.Mensaje_Email_errado,
                            new ExcepcionesTotem.Modulo1.EmailErradoException());
                            ExcepcionesTotem.Logger.EscribirError(this.GetType().Name, excep);
                            throw excep;
                        }
                    }
                    else
                    {
                        ExcepcionesTotem.Modulo1.EmailErradoException excep = new ExcepcionesTotem.Modulo1.EmailErradoException(
                            RecursosM1.Codigo_Email_Errado,
                            RecursosM1.Mensaje_Email_errado,
                            new ExcepcionesTotem.Modulo1.EmailErradoException());
                        ExcepcionesTotem.Logger.EscribirError(this.GetType().Name, excep);
                        throw excep;
                    }
                    

                }
                catch (Exception)
                {
                    vista.Mensaje = "El correo suministrado es erroneo o no se encuentra registrado";
                }

            }
        }

    }
}
