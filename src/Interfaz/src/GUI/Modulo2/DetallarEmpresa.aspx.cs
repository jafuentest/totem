using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;

using ExcepcionesTotem.Modulo2; 
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

        if (!IsPostBack) 
        {
            this.LlenarPaises();
            this.CargarDatosEmpresa("J-11111111-1");
        }
        if (IsPostBack) 
        {
            this.alertCiudad.Visible = false;
            this.alertDireccion.Visible = false;
            this.alertEstado.Visible = false;
            this.alertNombreEmpresa.Visible = false;
            this.alertPais.Visible = false;
            this.alertRif.Visible = false;
            this.alertTelefono.Visible = false;
            this.alert.Visible = true; 
        }
    }

    /// <summary>
    /// Evento que llama a la lógica de Negocios para realizar las actualizaciones
    /// de los datos de una empresa
    /// </summary>
    protected void EditarEmpresa_Click(object sender, EventArgs e) 
    {
        LogicaCliente logica = new LogicaCliente();
        
        Lugar ciudad = new Lugar(); 
        Lugar direccion = new Lugar();
        if (!ValidarCamposVacios() )
        {

            try
            {
                ciudad.IdLugar = Convert.ToInt32(comboCiudad.SelectedValue);
                ciudad.NombreLugar = comboCiudad.Text;
                direccion.NombreLugar = direccionEmpresa.Value;
                string rif = rifEmpresa.Value;
                string nombreEmp = nombreEmpresa.Value;
                string pais = comboPais.Text;
                string estado = comboEstado.Text;

                ClienteJuridico cliente = new ClienteJuridico(rif, nombreEmp, pais,
                    estado, ciudad, direccion);



                if (logica.ModificarClienteJuridico(cliente))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Datos modificados del cliente éxitosamente</div>";
                    this.botonEditar.Disabled = true;
                }
                else
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar al cliente</div>";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los datos" +
                    " no pueden estar vacíos" + "</div>";
            }
            catch (FormatoIncorrectoException)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en el formato de tipo de datos</div>";
            }
            catch (OperacionInvalidaException)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                    "Se ha originado una operación no permitida" + "</div>";
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al conectarse a Base de Datos</div>";
            }
            catch (ExcepcionesTotem.ExceptionTotem)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en el sistema TOTEM. Por favor intente más tarde</div>";
            }
        }
    }

    /// <summary>
    /// Método para validar que los campos de la interfaz no
    /// se encuentren vacíos
    /// </summary>
    /// <returns></returns>
    private bool ValidarCamposVacios() 
    {
        bool vacio = false;

        if (rifEmpresa.Value == "")
        {
            this.alertRif.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertRif.Attributes["role"] = "alert";
            this.alertRif.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El Rif está vacío</div>";
            this.alertRif.Visible = true;
            vacio = true;
        }

        if (nombreEmpresa.Value == "")
        {
            this.alertNombreEmpresa.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertNombreEmpresa.Attributes["role"] = "alert";
            this.alertNombreEmpresa.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre de la empresa está vacío</div>";
            this.alertNombreEmpresa.Visible = true;
            vacio = true;
        }

        if (direccionEmpresa.Value == "")
        {
            this.alertDireccion.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertDireccion.Attributes["role"] = "alert";
            this.alertDireccion.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La dirección está vacía</div>";
            this.alertDireccion.Visible = true;
            vacio = true;
        }

       if (comboPais.SelectedValue == "0")
        {
            this.alertPais.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertPais.Attributes["role"] = "alert";
            this.alertPais.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debe seleccionar país</div>";
            this.alertPais.Visible = true;
            vacio = true;
        }

        if (comboEstado.SelectedValue == "0")
        {
            this.alertEstado.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertEstado.Attributes["role"] = "alert";
            this.alertEstado.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debe seleccionar estado</div>";
            this.alertEstado.Visible = true;
            vacio = true;
        }

        if (comboCiudad.SelectedValue == "0")
        {
            this.alertCiudad.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertCiudad.Attributes["role"] = "alert";
            this.alertCiudad.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debe seleccionar ciudad</div>";
            this.alertCiudad.Visible = true;
            vacio = true;
        }
        
        return vacio; 
    }
    /*
    private bool ValidarTelefono() 
    {
        bool noValido = false;

        if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]", this.telefonoEmpresa.Value))
        {
            alertTelefono.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertTelefono.Attributes["role"] = "alert";
            alertTelefono.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El teléfono solamente es numérico</div>";
            noValido = true; 
        }
        return noValido; 
    }*/


     
    /// <summary>
    /// Evento que se dispara cuando se selecciona algún elemento de 
    /// país y carga sus estados
    /// </summary>
    protected void CbCambioAEstado(object sender, EventArgs e) 
    {
        this.comboEstado.Items.Clear();
        this.comboCiudad.Items.Clear();
        int _idPais =Convert.ToInt32(this.comboPais.SelectedValue);
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
    /// Método encargado de cargar los datos de una empresa
    /// al iniciar la página
    /// </summary>
    private void CargarDatosEmpresa(string id) 
    {
        ClienteJuridico cliente = new ClienteJuridico();
        List<Contacto> contactos = new List<Contacto>();
        Contacto contacto = new Contacto(); 
        LogicaCliente logica = new LogicaCliente();
        LogicaContacto logicaContacto = new LogicaContacto();

       try
        {
            cliente = logica.ConsultarClienteJuridico(id);
            
            rifEmpresa.Value = cliente.Jur_Id;
            nombreEmpresa.Value = cliente.Jur_Nombre;
            
            contactos = logicaContacto.ListarContactosEmpresa(rifEmpresa.Value);
            

            
            foreach (Contacto elContacto in contactos)
            {
                cuerpo.InnerHtml =
                    cuerpo.InnerHtml + "<tr><td>" +
                    elContacto.Con_Nombre +
                    elContacto.Con_Apellido + "</td><td>" +
                    elContacto.ConCargo +                    
                    "</td><td><a class=\"btn btn-default glyphicon glyphicon-pencil\" data-toggle=\"modal\" data-target=\"#modal-update\" href=\"#\"></a><a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a></td></tr>"; ;
            }
            this.CargarDireccionEmpresa(cliente);
        }

       catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
       {
           alert.Attributes["class"] = "alert alert-danger alert-dismissible";
           alert.Attributes["role"] = "alert";
           alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al cargar los datos de la Base de Datos</div>";
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

         private void CargarDireccionEmpresa(ClienteJuridico cliente)
        {
             LogicaLugar logica = new LogicaLugar();
             try
             {
                 this.comboPais.DataSource = logica.LlenarComboPaises();
                 this.comboPais.DataTextField = "NombreLugar";
                 this.comboPais.DataValueField = "IdLugar";
                 this.comboPais.DataBind();

                 this.comboPais.Items.FindByValue(logica.ConsultarDireccionCompleta(cliente.Jur_Direccion.IdLugar).ElementAt(0).ToString()).Selected = true;

                 this.comboEstado.DataSource = logica.LlenarComboEstados(logica.ConsultarDireccionCompleta(cliente.Jur_Direccion.IdLugar).ElementAt(0));
                 this.comboEstado.DataTextField = "NombreLugar";
                 this.comboEstado.DataValueField = "IdLugar";
                 this.comboEstado.DataBind();

                 this.comboEstado.Items.FindByValue(logica.ConsultarDireccionCompleta(cliente.Jur_Direccion.IdLugar).ElementAt(1).ToString()).Selected = true;

                 this.comboCiudad.DataSource = logica.LlenarComboCiudades(logica.ConsultarDireccionCompleta(cliente.Jur_Direccion.IdLugar).ElementAt(1));
                 this.comboCiudad.DataTextField = "NombreLugar";
                 this.comboCiudad.DataValueField = "IdLugar";
                 this.comboCiudad.DataBind();

                 this.comboCiudad.Items.FindByValue(logica.ConsultarDireccionCompleta(cliente.Jur_Direccion.IdLugar).ElementAt(2).ToString()).Selected = true;

                 this.direccionEmpresa.Value = logica.ObtenerDireccionCompleta(cliente.Jur_Direccion.IdLugar);
             }
             catch (ExcepcionesTotem.ExceptionTotemConexionBD)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al cargar "
                     + "los datos de las direcciones desde la Base de Datos " + "</div>";
             }
             catch (Exception e) 
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error de sistema "
                     + "Por favor intente más tarde " + "</div>";
             }
        }

    }

