using Comandos.Fabrica;
using Comandos.Comandos.Modulo8;
using Contratos.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo4;
using System.Web.UI;
using System.Web;
using Dominio;
using Dominio.Fabrica;


namespace Presentadores.Modulo8
{
    public class PresentadorCrearMinuta
    {
        //private IContratoCrearMinuta vista;

        public PresentadorCrearMinuta()//IContratoCrearMinuta laVista)
        {
            //vista = laVista;
        }


        public List<Dominio.Entidad> ListaInvolucrado(string codigoProyecto)
        {
            ComandoListaUsuario comandoListaUsuario = (ComandoListaUsuario)FabricaComandos.CrearComandoListaUsuario();
            List<Dominio.Entidad> listaUsuario = comandoListaUsuario.Ejecutar(codigoProyecto);


            return listaUsuario;
        }

        public string crearMinuta(Entidad laMinuta,string codigoProyecto)
        {
            ComandoGuardarMinuta comandoGuardarMinuta = (ComandoGuardarMinuta)FabricaComandos.CrearComandoGuardarMinuta();
             List<Entidad> parametroGuardar = new List<Entidad>();
            FabricaEntidades fabricaEntidades=new FabricaEntidades();
            Proyecto elProyecto=(Proyecto)FabricaEntidades.ObtenerProyecto();
           elProyecto.Codigo=codigoProyecto;
                parametroGuardar.Add(elProyecto);
                parametroGuardar.Add(laMinuta);

            return comandoGuardarMinuta.Ejecutar(parametroGuardar);
        }

        public void ObtenerUsuarioLogeado()
        {
            Usuario usuario = HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
        }
    }
}
