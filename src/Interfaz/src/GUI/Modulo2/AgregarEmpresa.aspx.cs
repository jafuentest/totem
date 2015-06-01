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

            }

        }
        else
        {
          /*  Response.Redirect("../Modulo1/M1_login.aspx");
        }*/
        if (!IsPostBack) 
        {
            this.LlenarPaises();
            this.LlenarCargos();
            
        }

        if (IsPostBack)
        {
            this.alertRif.Visible = false;
            this.alertNombreEmpresa.Visible = false;
            this.alertPais.Visible = false;
            this.alertEstado.Visible = false;
            this.alertCiudad.Visible = false;
            this.alertDireccion.Visible = false;
            this.alertCodigoPostal.Visible = false;
            this.alertCedulaContacto.Visible = false;
            this.alertNombreContacto.Visible = false;
            this.alertApellidoContacto.Visible = false;
            this.alertTelefonoContacto.Visible = false;
            this.alert.Visible = false; 
        }
    }

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

        if (!ValidarCamposVacios())
        {
            string rif = rifEmpresa.Value;
            string nombre = nombreEmpresa.Value;
            string direccion = direccionEmpresa.Value;
            try
            {
                string pais = comboPais.Items[comboPais.SelectedIndex].Text;
                string estado = comboEstado.Items[comboEstado.SelectedIndex].Text;
                string ciudad = comboCiudad.Items[comboCiudad.SelectedIndex].Text;
                int lugar = Convert.ToInt32(comboCiudad.Items[comboCiudad.SelectedIndex].Value);
                int cargo = Convert.ToInt32(comboCargo.Items[comboCargo.SelectedIndex].Value);
                string cedula = cedulaContacto.Value;
                string telefono = telefonoContacto.Value;
                Contacto contacto = new Contacto();
                contacto.Con_Nombre = nombreContacto.Value;
                contacto.Con_Apellido = apellidoContacto.Value;

                existe = logica.VerificarExistenciaJuridico(cedula);

                if (existe == 0)
                {
                    agrego = logica.AgregarClienteJuridico(rif, nombre, lugar, direccion, contacto.Con_Nombre,
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
            catch (ArgumentOutOfRangeException)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los datos" +
                    " no pueden estar vacíos" + "</div>";
            }
            catch (OperacionInvalidaException)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                    "Se ha originado una operación no permitida" + "</div>";
            }
            catch (FormatoIncorrectoException)
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
            catch (ExcepcionesTotem.ExceptionTotem)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en el sistema TOTEM. Por favor intente más tarde</div>";
            }
        }
        
    }

    /// <summary>
    /// Método para verificar campos vacíos
    /// </summary>
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

        if(nombreEmpresa.Value=="")
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

        if (cedulaContacto.Value == "") 
        {
            this.alertCedulaContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertCedulaContacto.Attributes["role"] = "alert";
            this.alertCedulaContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La cédula está vacía</div>";
            this.alertCedulaContacto.Visible = true;
            vacio = true;
        }

        if (nombreContacto.Value == "")
        {
            this.alertNombreContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertNombreContacto.Attributes["role"] = "alert";
            this.alertNombreContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre del contacto está vacío</div>";
            this.alertNombreContacto.Visible = true;
            vacio = true;
        }

        if (apellidoContacto.Value == "")
        {
            this.alertApellidoContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertApellidoContacto.Attributes["role"] = "alert";
            this.alertApellidoContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido del contacto está vacío</div>";
            this.alertApellidoContacto.Visible = true;
            vacio = true;
        }

        if (telefonoContacto.Value == "")
        {
            this.alertTelefonoContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertTelefonoContacto.Attributes["role"] = "alert";
            this.alertTelefonoContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El teléfono está vacío</div>";
            this.alertTelefonoContacto.Visible = true;
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
    private bool ValidarExpresionesRegulares()
    {
        bool noValido = false;

        if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]+$", this.rifEmpresa.Value))
        {
            alertCedulaContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertCedulaContacto.Attributes["role"] = "alert";
            alertCedulaContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El RIF debe ser numérico</div>";
            noValido = true;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]+$", this.cedulaContacto.Value))
        {
            alertCedulaContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertCedulaContacto.Attributes["role"] = "alert";
            alertCedulaContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La cédula solo puede ser numérica</div>";
            noValido = true;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch("^([a-zA-Z]? ?)*$", this.nombreContacto.Value))
        {
            alertNombreContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertNombreContacto.Attributes["role"] = "alert";
            alertNombreContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre debe ser solamente alfabético</div>";
            noValido = true;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]+$", this.codigoPostalEmpresa.Value))
        {
            alertCodigoPostal.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertCodigoPostal.Attributes["role"] = "alert";
            alertCodigoPostal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El código postal debe ser solamente numérico</div>";
            noValido = true;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch("^([a-zA-Z]? ?)*$", this.apellidoContacto.Value))
        {
            alertNombreContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertNombreContacto.Attributes["role"] = "alert";
            alertNombreContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido debe ser solamente alfabético</div>";
            noValido = true;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch("^[0-9]+$", this.telefonoContacto.Value))
        {
            alertTelefonoContacto.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertTelefonoContacto.Attributes["role"] = "alert";
            alertTelefonoContacto.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El teléfono solamente debe ser numérico</div>";
            noValido = true;
        }
        
        if (!System.Text.RegularExpressions.Regex.IsMatch("^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.:/-/ ]+)$", this.direccionEmpresa.Value))
        {
            alertDireccion.Attributes["class"] = "alert alert-danger alert-dismissible";
            alertDireccion.Attributes["role"] = "alert";
            alertDireccion.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Formato de dirección inválida</div>";
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
        this.codigoPostalEmpresa.Value = numero.ToString(); 
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
    

    
    private void LlenarCargos() 
    {
        try
        {
            LogicaCliente logica = new LogicaCliente();
            List<string> cargos = new List<string>();
            ListItem itemCargo; 
            cargos = logica.LlenarComboCargo();
            this.comboCargo.Items.Clear();

            itemCargo = new ListItem();
            itemCargo.Text = "Seleccione Cargo";
            itemCargo.Value = "0";
            this.comboCargo.Items.Add(itemCargo);           

           int numero = 1; 
            foreach (string cargo in cargos) 
            {
                itemCargo = new ListItem();
                itemCargo.Text = cargo;
                itemCargo.Value = numero.ToString();
                numero++;
                this.comboCargo.Items.Add(itemCargo);

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