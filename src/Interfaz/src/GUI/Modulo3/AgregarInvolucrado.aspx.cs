using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTotem;

public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    private ListaInvolucradoContacto listaContactos;
    private ListaInvolucradoUsuario listaUsuarios;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        
        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                //Mostrar menu lateral
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }   
    }

    protected void AgregarInvolucrados_Click(object sender, EventArgs e)
    {
        // Falta implementar jalando los comoboboxes
    }


}