using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;
using LogicaNegociosTotem.Modulo2;
using ExcepcionesTotem.Modulo2; 

public partial class GUI_Modulo2_AgregarEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

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
     /*   else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }*/
    }


    /// <summary>
    /// Método que se ejecuta cuando el usuario presiona 
    /// el botón de agregar empresa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AgregarEmpresa_Click(object sender, EventArgs e) 
    {
        LogicaCliente logica = new LogicaCliente();

        string rif = rifEmpresa.Value;
        string nombre = nombreEmpresa.Value;
        
        string pais=comboPais.Items[comboPais.SelectedIndex].Text; 
       
        /*string pais = paisEmpresa.InnerText;
        string estado = estadoEmpresa.InnerText;
        string ciudad = ciudadLista.InnerText;
        string direccion = direccionEmpresa.Value;*/
        string codigoPostal = codigoPostalEmpresa.Value;
        string telefono = telefonoEmpresa.Value;
        Contacto contacto = new Contacto();
        contacto.Con_Nombre = "";
        contacto.Con_Apellido = "";

        //logica.ModificarClienteJuridico();   
    
    }

   /// <summary>
   /// Método que extrae la información de los paises para el
   /// combo
   /// </summary>
    private void LlenarPaises() 
    {
        try
        {
            LogicaLugar logica = new LogicaLugar();
            List<Lugar> paises = logica.LlenarComboPaises();
            ListItem itemPais;

            this.comboPais.Items.Clear();

            itemPais = new ListItem();
            itemPais.Text = "Seleccione un país";
            itemPais.Value = "0";
            this.comboPais.Items.Add(itemPais);

            foreach (Lugar objetoPais in paises)
            {
                itemPais = new ListItem();
                itemPais.Text = objetoPais.NombreLugar;
                itemPais.Value = objetoPais.IdLugar.ToString();
                this.comboPais.Items.Add(itemPais);
            }
        }
        catch (ClienteDatosException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
        }
        catch (ClienteLogicaException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
        }

     }

    /// <summary>
    /// Método que extrae la información de los 
    /// estados para el combo
    /// </summary>
    private void LlenarEstados(int idPais) 
    {
        try 
        {
            LogicaLugar logica = new LogicaLugar();
            List<Lugar> estados = logica.LlenarComboEstados(idPais);
            ListItem itemEstado;

            this.comboEstado.Items.Clear();

            itemEstado = new ListItem();
            itemEstado.Text = "Seleccione Estado";
            itemEstado.Value = "0";
            this.comboEstado.Items.Add(itemEstado);

            foreach (Lugar objetoEstado in estados)
            {
                itemEstado = new ListItem();
                itemEstado.Text = objetoEstado.NombreLugar;
                itemEstado.Value = objetoEstado.IdLugar.ToString();
                this.comboEstado.Items.Add(itemEstado);
            }

        }
        catch (ClienteDatosException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
        }
        catch (ClienteLogicaException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
        }
    }


    /// <summary>
    /// Método que extrae la información de las 
    /// ciudades para el combo
    /// </summary>
    private void LlenarCiudades(int idEstado)
    {
        try
        {
            LogicaLugar logica = new LogicaLugar();
            List<Lugar> ciudades = logica.LlenarComboCiudades(idEstado);
            ListItem itemCiudad;

            this.comboEstado.Items.Clear();

            itemCiudad = new ListItem();
            itemCiudad.Text = "Seleccione Estado";
            itemCiudad.Value = "0";
            this.comboCiudad.Items.Add(itemCiudad);

            foreach (Lugar objetoCiudad in ciudades)
            {
                itemCiudad = new ListItem();
                itemCiudad.Text = objetoCiudad.NombreLugar;
                itemCiudad.Value = objetoCiudad.IdLugar.ToString();
                this.comboEstado.Items.Add(itemCiudad);
            }

        }
        catch (ClienteDatosException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
        }
        catch (ClienteLogicaException e)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
        }
    }

}