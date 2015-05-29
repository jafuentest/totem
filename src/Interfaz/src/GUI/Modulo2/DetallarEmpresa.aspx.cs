using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;
using LogicaNegociosTotem.Modulo2;  

public partial class GUI_Modulo2_AgregarEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";
/*
        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            if (user.username != "" &&
                user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }*/
       /* else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }*/
    }

    /// <summary>
    /// Evento que llama a la lógica de Negocios para realizar las actualizaciones
    /// de los datos de una empresa
    /// </summary>
    protected void EditarEmpresa_Click(object sender, EventArgs e) 
    {
        LogicaCliente logica = new LogicaCliente();
        
        string rif = rifEmpresa.Value;
        string nombre = nombreEmpresa.Value;
        /*string pais = paisEmpresa.InnerText; 
        string estado = estadoEmpresa.InnerText;*/
       /* string ciudad = ciudadLista.InnerText;*/
        string direccion = direccionEmpresa.Value;
        string codigoPostal = codigopostalEmpresa.Value;
        string telefono = telefonoEmpresa.Value;
        Contacto contacto = new Contacto();
        contacto.Con_Nombre = "";
        contacto.Con_Apellido = "";

        //logica.ModificarClienteJuridico();       

    }

}