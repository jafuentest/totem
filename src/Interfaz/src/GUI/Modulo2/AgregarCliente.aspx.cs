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

public partial class GUI_Modulo2_AgregarCliente : System.Web.UI.Page
{


       

        ClienteNatural clienteNatural;
        LogicaCliente logicaCliente = new LogicaCliente();

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
                }

            }
            else
            {
                /*Response.Redirect("../Modulo1/M1_login.aspx");

            }*/

            if (!IsPostBack) 
            {
                this.LlenarPaises();    
            }
        }

    /// <summary>
    /// Evento que se dispara cuando 
    /// se genera presiona agregar cliente
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AgregarCliente_Click(object sender, EventArgs e) 
    {
        bool agrego = false;
        int existe = 0; 
        
        string nombre = nombreNatural.Value;
        string apellido = apellidoNatural.Value;
        string correo = correoCliente.Value;
        string cedula = cedulaNatural.Value; 
        string direccion = direccionCliente.Value;
        string telefono = telefonoCliente.Value;
        LogicaCliente logica = new LogicaCliente();
        try
        {

            int ciudad = Convert.ToInt32(comboCiudad.Items[comboCiudad.SelectedIndex].Value);


            existe = logicaCliente.VerificarExistenciaNatural(cedula);

            if (existe == 0)
            {
                agrego = logicaCliente.AgregarClienteNatural(cedula, nombre,
                    apellido, ciudad, direccion, correo, telefono);
                if (agrego)
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente agregado éxitosamente</div>";
                    this.botonAgregar.Disabled = true;
                }
                else
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo agregar el cliente</div>";
                }
            }
            else
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente ya existente</div>";
            }
        }

        catch(ArgumentOutOfRangeException)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los datos"+
                " no pueden estar vacíos"+"</div>";
        }
        catch (FormatoIncorrectoException )
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en el formato de tipo de datos</div>";
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD) 
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al conectarse a Base de Datos</div>";
        }
        catch(ExcepcionesTotem.ExceptionTotem)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en el sistema TOTEM. Por favor intente más tarde</div>";
        }
    }


    /// <summary>
    /// Evento que se dispara cuando se selecciona algún elemento de 
    /// país y carga sus estados
    /// </summary>
    protected void CbCambioAEstado(object sender, EventArgs e)
    {
        this.comboEstado.Items.Clear();
        this.comboCiudad.Items.Clear();
        int _idPais = Convert.ToInt32(this.comboPais.SelectedValue);
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
        int _idEstado = Convert.ToInt32(this.comboEstado.SelectedValue);
        LlenarCiudades(_idEstado);
    }
    /// <summary>
    /// Evento que se dispara al seleccionar algunos 
    /// de los valores que tiene ciudad
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CbCargarCodigoPostal(object sender, EventArgs e)
    {
        int _idCiudad = Convert.ToInt32(this.comboCiudad.SelectedValue);
        CargarCodigoPostal(_idCiudad);

    }

    private void CargarCodigoPostal(int idCiudad)
    {
        LogicaLugar logicaLugar = new LogicaLugar();
        int numero = logicaLugar.ObtenerCodigoPostal(idCiudad);
        this.codigoPostalCliente.Value = numero.ToString();
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
            itemPais.Text = "Seleccione Pais";
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

            this.comboCiudad.Items.Clear();
            itemCiudad = new ListItem();
            itemCiudad.Text = "Seleccione Ciudad";
            itemCiudad.Value = "0";
            this.comboEstado.Items.Add(itemCiudad);


            foreach (Lugar objetoCiudad in ciudades)
            {
                itemCiudad = new ListItem();
                itemCiudad.Text = objetoCiudad.NombreLugar;
                itemCiudad.Value = objetoCiudad.IdLugar.ToString();
                this.comboCiudad.Items.Add(itemCiudad);
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