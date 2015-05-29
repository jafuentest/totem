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
            this.DesplegarClienteNatural(); 
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

    private void DesplegarClienteNatural() 
    {
        LogicaCliente logica = new LogicaCliente();
        ClienteNatural cliente=logica.ConsultarClienteNatural(1);
        List<string> telefonos = new List<string>(); 
        telefonos = cliente.Nat_Telefonos; 
        
        foreach(string telefono in telefonos)
        {
            this.telefonoCliente.Value=telefono; 
        }

        this.direccionCliente.Value = cliente.Nat_Direccion; 
        this.apellidoCliente.Value = cliente.Nat_Apellido;
        this.nombreCliente.Value = cliente.Nat_Nombre;
        this.cedulaCliente.Value = cliente.Nat_Id;
        LlenaCampoPais(cliente.Nat_Pais);
        LlenaCampoEstado(cliente.Nat_Estado);
        LlenaCampoEstado(cliente.Nat_Ciudad.NombreLugar); 
        this.comboEstado.Value = cliente.Nat_Estado;
        this.comboCiudad.Value = cliente.Nat_Ciudad.NombreLugar;
        this.codigopostalCliente.Value = cliente.Nat_Ciudad.CodigoPostal;
        this.correoCliente.Value = cliente.Nat_Correo; 
        
    }

    private void LlenaCampoPais(string pais) 
    {

        

        
        string nombreEvento = "CbCambioAEstado";
        this.contenedorComboPais.InnerHtml = "<select runat=\"server\" id=\"comboPais\" class=\"btn btn-default dropdown-toggle\""
                                           + "onchange=\" " + nombreEvento + "\">" +
                                            "<option id=\"opcionPais" + "0" + "\" runat=\"server\" value=\""+pais+"\">" +pais+                                             
                                            "</option>"+
                                            "</select>"; 
    
    }

    private void LlenaCampoEstado(string estado) 
    {
        string nombreEvento = "CbCambioACiudad";
        this.contenedorComboEstado.InnerHtml = "<select runat=\"server\" id=\"comboEstado\" class=\"btn btn-default dropdown-toggle\""
                                           + "onchange=\" " + nombreEvento + "\">" +
                                            "<option id=\"opcionEstado" + "0" + "\" runat=\"server\" value=\"" + estado + "\">" + estado +
                                            "</option>"+
                                            "</select>";
    }

    private void LlenaCampoCiudad(string ciudad) 
    {
        this.contenedorComboCiudad.InnerHtml = "<select runat=\"server\" id=\"comboCiudad\" class=\"btn btn-default dropdown-toggle\">"+
                                           
                                            "<option id=\"opcionCiudad" + "0" + "\" runat=\"server\" value=\"" + ciudad + "\">" + ciudad +
                                            "</option>"+
                                            "</select>";
    }


}