using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo8_DetalleMinutas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "8";
        String minuta = Request.QueryString["minuta"];
        if (minuta != null)
        {
            if (minuta.Equals("1"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerText = "Se ha creado la minuta con éxito";
            }
        }
    }
}