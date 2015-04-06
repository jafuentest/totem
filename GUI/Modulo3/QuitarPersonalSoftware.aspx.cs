using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_persona.Items.Clear();

        if(id_proyecto.SelectedItem.Value == "1") {
            id_persona.Items.Add(new ListItem("Maria Guzman","34"));
            id_persona.Items.Add(new ListItem("Gregorio Mendosa","12"));
            id_persona.Items.Add(new ListItem("Julio Pino","10"));
        }

        if(id_proyecto.SelectedItem.Value == "2") {
            id_persona.Items.Add(new ListItem("Diana Moreno","15"));
            id_persona.Items.Add(new ListItem("Katherine Villamizar","11"));
            id_persona.Items.Add(new ListItem("Charlie Halper","22"));
        }

        if (id_proyecto.SelectedItem.Value == "3") {
            id_persona.Items.Add(new ListItem("Raul Castro","24"));
            id_persona.Items.Add(new ListItem("Manuel Hernandez","25"));
            id_persona.Items.Add(new ListItem("Augusto Cordova","26"));
        }

    }
}