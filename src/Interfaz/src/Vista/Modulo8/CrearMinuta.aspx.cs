using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo8
{
    public partial class CrearMinuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string ListaInvolucrado()
        {
            /*LogicaMinuta logicaMinuta = new LogicaMinuta();
            List<Usuario> listaUsuario = logicaMinuta.ListaUsuario(new Proyecto()
            {
                Codigo = codigoProyecto
            });
            var output = JsonConvert.SerializeObject(listaUsuario);
            return output;*/
            throw new NotImplementedException();
        }

    }
}