using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LogicaNegociosTotem.Modulo2;
using DominioTotem;
using ExcepcionesTotem.Modulo2;

public partial class GUI_Modulo2_AgregarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        if (!IsPostBack) 
        {
           // this.DesplegarClienteNatural(); 
        }

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

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }
    }

    ///// <summary>
    ///// Evento que hace las llamadas a la lógica de negocio 
    ///// para editar los datos del cliente natural 
    ///// </summary>
    protected void EditarCliente_Click(object sender, EventArgs e)
    {
        //bool modifico = false;
        //LogicaCliente logicaCliente = new LogicaCliente();
        //string cedula = cedulaCliente.Value;
        //string nombre = nombreCliente.Value;
        //string apellido = apellidoCliente.Value;
        //string correo = correoCliente.Value;
        //string pais = comboPais.Items[1].Text;
        //string estado = comboEstado.Items[1].Text;
        //string ciudad = comboCiudad.Items[1].Text;
        //string direccion = direccionCliente.Value;
        //string telefono = telefonoCliente.Value;


        //modifico = logicaCliente.ModificarClienteNatural(cedula, nombre, apellido, correo, pais, estado, ciudad, direccion, telefono);
        //if (modifico)
        //{
        //    alert.Attributes["class"] = "alert alert-success alert-dismissible";
        //    alert.Attributes["role"] = "alert";
        //    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente Natural Modificado éxitosamente</div>";
        //    this.botonEditar.Disabled = true;
        //}
        //else
        //{
        //    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
        //    alert.Attributes["role"] = "alert";
        //    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo Modificar el Cliente Natural</div>";
        //}

    }

    ///// <summary>
    ///// Muestra los datos del cliente a modificar 
    ///// Desplegandolos en la interfaz para posteriormente ser modificado 
    ///// </summary>
    //private void DesplegarClienteNatural() 
    //{
    //    LogicaCliente logica = new LogicaCliente();
    //    ClienteNatural cliente=logica.ConsultarClienteNatural(4);
    //    List<string> telefonos = new List<string>(); 
    //    telefonos = cliente.Nat_Telefonos; 
        
    //    foreach(string telefono in telefonos)
    //    {
    //        this.telefonoCliente.Value=telefono; 
    //    }

    //    this.direccionCliente.Value = cliente.Nat_Direccion; 
    //    this.apellidoCliente.Value = cliente.Nat_Apellido;
    //    this.nombreCliente.Value = cliente.Nat_Nombre;
    //    this.cedulaCliente.Value = cliente.Nat_Id;
    //    LlenaCampoPais(cliente.Nat_Pais);
    //    LlenaCampoEstado(cliente.Nat_Estado);
    //    LlenaCampoCiudad(cliente.Nat_Ciudad.NombreLugar);
    //    this.comboPais.Items[1].Text = cliente.Nat_Pais;
    //    this.comboEstado.Items[1].Text = cliente.Nat_Estado;
    //    this.comboCiudad.Items[1].Text = cliente.Nat_Ciudad.NombreLugar;
    //    this.comboCiudad.SelectedIndex = 1;
    //    this.codigopostalCliente.Value = cliente.Nat_Ciudad.CodigoPostal;
    //    this.correoCliente.Value = cliente.Nat_Correo;
        
        
    //}

    ///// <summary>
    ///// ComboBox de pais  
    ///// Muestra la opcion en el combobox que viene cargada de la base de datos  
    ///// </summary>
    //private void LlenaCampoPais(string pais) 
    //{

    //    string nombreEvento = "CbCambioAPais";
    //    this.contenedorComboPais.InnerHtml = "<select runat=\"server\" id=\"comboPais\" class=\"btn btn-default dropdown-toggle\""
    //                                       + "onchange=\" " + nombreEvento + "\">" +
    //                                        "<option id=\"opcionPais" + "0" + "\" runat=\"server\" value=\""+pais+"\">" +pais+                                             
    //                                        "</option>"+
    //                                        "</select>"; 
    
    //}

    ///// <summary>
    ///// ComboBox de estado  
    ///// Muestra la opcion en el combobox que viene cargada de la base de datos  
    ///// </summary>
    //private void LlenaCampoEstado(string estado) 
    //{
    //    string nombreEvento = "CbCambioAEstado";
    //    this.contenedorComboEstado.InnerHtml = "<select runat=\"server\" id=\"comboEstado\" class=\"btn btn-default dropdown-toggle\""
    //                                       + "onchange=\" " + nombreEvento + "\">" +
    //                                        "<option id=\"opcionEstado" + "0" + "\" runat=\"server\" value=\"" + estado + "\">" + estado +
    //                                        "</option>"+
    //                                        "</select>";
    //}

    ///// <summary>
    ///// ComboBox de ciudad  
    ///// Muestra la opcion en el combobox que viene cargada de la base de datos  
    ///// </summary>
    //private void LlenaCampoCiudad(string ciudad)
    //{
    //    string nombreEvento = "CbCambioACiudad";
    //    this.contenedorComboCiudad.InnerHtml = "<select runat=\"server\" id=\"comboCiudad\" class=\"btn btn-default dropdown-toggle\""
    //                                        + "onchange=\" " + nombreEvento + "\">" +
    //                                        "<option id=\"opcionCiudad" + "0" + "\" runat=\"server\" value=\"" + ciudad + "\">" + ciudad +
    //                                        "</option>"+
    //                                        "</select>";
    //}


}