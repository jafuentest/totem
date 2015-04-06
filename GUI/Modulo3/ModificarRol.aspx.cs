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
    protected void Unnamed1_Click(object sender, EventArgs e)
    {

    }
    protected void proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        //code here
        id_persona.Items.Add(new ListItem("Argenis Rodriguez", "1"));
        id_persona.Items.Add(new ListItem("Scheryl Palencia", "2"));
        id_persona.Items.Add(new ListItem("Alberto Da Silva", "3"));
        id_persona.Items.Add(new ListItem("Juan Soto", "1"));
        id_persona.Items.Add(new ListItem("Carlos Carrasco", "1"));
    }
    protected void persona_SelectedIndexChanged(object sender, EventArgs e)
    {
        rolactual.Value = "fdg";
        if (id_persona.SelectedItem.Value == "1")
            rolactual.Value = "Lider del Proyecto";
        if (id_persona.SelectedItem.Value == "2")
            rolactual.Value = "Analista";
        if (id_persona.SelectedItem.Value == "3")
            rolactual.Value = "Programador";
        if (id_persona.SelectedItem.Value == "4")
            rolactual.Value = "Programador";
        if (id_persona.SelectedItem.Value == "5")
            rolactual.Value = "Programador";
        
       
    }
}