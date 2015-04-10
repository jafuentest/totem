using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



public partial class GUI_Modulo7_ListarUsuarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        

        ((MasterPage)Page.Master).IdModulo = "7";
        String success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("1"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
               
                alert.InnerText = "Se ha eliminado con éxito";
            }
            if (success.Equals("2"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerText = "Se ha editado con éxito";
            }
        }

    }
}