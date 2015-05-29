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

             }*/
        if (!IsPostBack) // verificar si la pagina se muestra por primera vez
        {
            /*  this.LlenarPaises();*/
            /*  this.LlenarCargos();*/
        }

    }
    /*   else
       {
           Response.Redirect("../Modulo1/M1_login.aspx");
       }*/



    /// <summary>
    /// Método que se ejecuta cuando el usuario presiona 
    /// el botón de agregar empresa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AgregarEmpresa_Click(object sender, EventArgs e)
    {
        int existe = 0;
        bool agrego = false; 
        LogicaCliente logica = new LogicaCliente();

        string rif = rifEmpresa.Value;
        string nombre = nombreEmpresa.Value;
        string direccion = direccionEmpresa.Value; 
        /*string pais=comboPais.Items[comboPais.SelectedIndex].Text; */

        /*string pais = paisEmpresa.InnerText;
        string estado = estadoEmpresa.InnerText;
        string ciudad = ciudadLista.InnerText;
        string direccion = direccionEmpresa.Value;*/
        string pais = comboPais.Items[comboPais.SelectedIndex].Text;
        string estado = comboEstado.Items[comboEstado.SelectedIndex].Text;
        string ciudad = comboCiudad.Items[comboCiudad.SelectedIndex].Text;
        int lugar =Convert.ToInt32(comboCiudad.Items[comboCiudad.SelectedIndex].Value);
        int cargo = Convert.ToInt32(comboCargo.Items[comboCargo.SelectedIndex].Value);
        string cedula = cedulaContacto.Value; 
        string telefono = telefonoContacto.Value;
        Contacto contacto = new Contacto();
        contacto.Con_Nombre = nombreContacto.Value;
        contacto.Con_Apellido = apellidoContacto.Value;

        existe = logica.VerificarExistenciaJuridico(cedula);

        if (existe == 0)
        {
            agrego=logica.AgregarClienteJuridico(rif, nombre, lugar, direccion, contacto.Con_Nombre,
            contacto.Con_Apellido, cargo, telefono, cedula);

            if (agrego) 
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente agregado éxitosamente</div>";
                this.botonAgregar.Disabled = true;
            }

        }
        else 
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente ya existente</div>";
        }
        
    }

    /*
    /// <summary>
    /// Evento que se dispara cuando se selecciona algún elemento de 
    /// país y carga sus estados
    /// </summary>
    protected void CbCambioAEstado(object sender, EventArgs e) 
    {
        this.comboEstado.Items.Clear();
        this.comboCiudad.Items.Clear();
        int _idPais =this.comboPais.SelectedIndex;
        LlenarEstados(_idPais);
    }

    /// <summary>
    /// Evento que se dispara cuando se selecciona algún elemento de 
    /// estados y carga sus ciudades
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CbCambioACiudad(object sender, EventArgs e)
    {
        int _idEstado = this.comboEstado.SelectedIndex;
        LlenarCiudades(_idEstado);
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
            
            string prueba = "Seleccione Pais";
            string nombreEvento = "alert('hello');"; 
            this.contenedorComboPais.InnerHtml = "<select runat=\"server\" id=\"comboPais\" class=\"btn btn-default dropdown-toggle\""
                                               + "onchange=\" " + nombreEvento + "\">" +
                                                "<option id=\"opcionPais"+"0"+"\" runat=\"server\" value=\"0\">" +
                                                 prueba    +
                                                "</option>"
                                                ; 

            
           foreach (Lugar objetoPais in paises)
            {
                this.contenedorComboPais.InnerHtml = contenedorComboPais.InnerHtml +
                                                     "<option id=\"opcionPais" + objetoPais.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoPais.IdLugar.ToString() + "\">" +
                                                      objetoPais.NombreLugar +
                                                     "</option>";
            }

            this.contenedorComboPais.InnerHtml= this.contenedorComboPais.InnerHtml+"</select>"; 
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
            string prueba = "Seleccione Estado";
            string nombreEvento = "CbCambioACiudad()"; 
            this.contenedorComboEstado.InnerHtml = "<select runat=\"server\" id=\"comboEstado\" class=\"btn btn-default dropdown-toggle\""
                                               + "onchange=\""+nombreEvento+"\">" +
                                                "<option id=\"opcionEstado" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                 prueba +
                                                "</option>";


            foreach (Lugar objetoEstado in estados)
            {

                this.contenedorComboEstado.InnerHtml = contenedorComboEstado.InnerHtml +
                                                     "<option id=\"opcionEstado" + objetoEstado.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoEstado.IdLugar.ToString() + "\">" +
                                                      objetoEstado.NombreLugar +
                                                     "</option>";
            }

            this.contenedorComboEstado.InnerHtml = this.contenedorComboEstado.InnerHtml + "</select>"; 

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
            

            string prueba = "Seleccione Ciudad";

            this.contenedorComboCiudad.InnerHtml = "<select runat=\"server\" id=\"comboCiudad\" class=\"btn btn-default dropdown-toggle\">" +
                                                "<option id=\"opcionCiudad" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                 prueba +
                                                "</option>";

            foreach (Lugar objetoCiudad in ciudades)
            {

                this.contenedorComboCiudad.InnerHtml = contenedorComboCiudad.InnerHtml +
                                                     "<option id=\"opcionCiudad" + objetoCiudad.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoCiudad.IdLugar.ToString() + "\">" +
                                                      objetoCiudad.NombreLugar +
                                                     "</option>";
            }
            this.contenedorComboCiudad.InnerHtml = this.contenedorComboCiudad.InnerHtml + "</select>"; 
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
    */

    /*
    private void LlenarCargos() 
    {
        try
        {
            LogicaCliente logica = new LogicaCliente();
            List<string> cargos = new List<string>();
            cargos = logica.LlenarComboCargo(); 
            string prueba="Seleccione cargo";

            this.contenedorCargo.InnerHtml = "<select runat=\"server\" id=\"comboCargo\" class=\"btn btn-default dropdown-toggle\">" +
                                                "<option id=\"opcionCargo" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                 prueba +
                                                "</option>";
            int numero = 0;
            foreach (string cargo in cargos) 
            {
                this.contenedorCargo.InnerHtml = contenedorCargo.InnerHtml +
                                                     "<option id=\"opcionCiudad" + numero.ToString() + "\" runat=\"server\" value=\"" + numero.ToString() + "\">" +
                                                      cargo +
                                                     "</option>";
                numero++; 
            }

            this.contenedorCargo.InnerHtml = this.contenedorCargo.InnerHtml + "</select>";
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

    }*/

}