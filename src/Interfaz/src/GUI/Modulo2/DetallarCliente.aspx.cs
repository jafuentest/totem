using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LogicaNegociosTotem.Modulo2;
using DominioTotem; 


public partial class GUI_Modulo2_AgregarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        if (!IsPostBack) 
        {
        
        }

       /* DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
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
      /*  else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }*/
    }

    /// <summary>
    /// Evento que hace las llamadas a la lógica de negocio 
    /// para editar los datos del cliente natural 
    /// </summary>
    protected void EditarCliente_Click(object sender, EventArgs e) 
    {
        LogicaCliente logica = new LogicaCliente();
        string nombre = nombreCliente.Value;
        string apellido = apellidoCliente.Value;
        string cedula = cedulaCliente.Value;
        /*string pais = paisCliente.InnerText;
        string estado = estadoCliente.InnerText;
        string ciudad = ciudadCliente.InnerText;*/
        string direccion = direccionCliente.Value;
        string codigoPostal = codigopostalCliente.Value;
        string correo = correoCliente.Value;
        string telefonoUno = telefonoCliente.Value; 

        //logica.ModificarClienteNatural();
    }

}