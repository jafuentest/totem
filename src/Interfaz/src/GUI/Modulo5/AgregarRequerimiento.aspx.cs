﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTotem;

public partial class GUI_Modulo5_AgregarRequerimiento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "5";

	   DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

	   if ( user != null )
	   {
		  if ( user.username != "" &&
			  user.clave != "" )
		  {
			 ((MasterPage)Page.Master).ShowDiv = true;
		  }
		  else
		  {
			 ((MasterPage)Page.Master).MostrarMenuLateral = false;
			 ((MasterPage)Page.Master).ShowDiv = false;
		  }
	   }
	   else
	   {
		  Response.Redirect("../Modulo1/M1_login.aspx");
	   }
    }

    public void ListarRequerimiento(Object sender, System.EventArgs e)
    {
	   CommandEventArgs ex = (CommandEventArgs)e;
	   int codigo = 1;
	   Label1.Text = LogicaNegociosTotem.Modulo5.LogicaRequerimiento.ConsultarRequerimiento(codigo);
    }
}