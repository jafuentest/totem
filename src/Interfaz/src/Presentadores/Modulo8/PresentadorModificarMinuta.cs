using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo8;
using Contratos.Modulo8;
using Dominio.Entidades.Modulo8;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo4;
using System.Web.UI;
using System.Web;
using Dominio;
using Dominio.Fabrica;

namespace Presentadores.Modulo8
{
    public class PresentadorModificarMinuta
    {

        public PresentadorModificarMinuta()//IContratoCrearMinuta laVista)
        {
            //vista = laVista;
        }

        public String ModificarMinuta(Entidad proyecto, Entidad minutaVieja, Entidad minutaNueva)
        {
            ComandoModificarMinuta comandoModificarMinuta = (ComandoModificarMinuta)FabricaComandos.CrearComandoModificarMinuta();
            List<Entidad> parametroModificar = new List<Entidad>();

            parametroModificar.Add(proyecto);
            parametroModificar.Add(minutaVieja);
            parametroModificar.Add(minutaNueva);

            return comandoModificarMinuta.Ejecutar(parametroModificar);
        }


    }
}
