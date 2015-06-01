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

            if (IsPostBack) 
            {
                this.alertApellido.Visible = false;
                this.alertCedula.Visible = false;
                this.alertCiudad.Visible = false;
                this.alertCodigoPostal.Visible = false;
                this.alertCorreo.Visible = false;
                this.alertDireccion.Visible = false;
                this.alertEstado.Visible = false;
                this.alertNombre.Visible = false;
                this.alertPais.Visible = false;
                this.alertTelefono.Visible = false;            
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

        if (!ValidarCamposVacios())
        {
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

                //Verifica que el cliente exista en la Base de Datos 
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
    /// Método que verifica los campso vacíos 
    /// </summary>
    private bool ValidarCamposVacios()
    {
        bool vacio = false;

        if (this.cedulaNatural.Value == "")
        {
            this.alertCedula.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertCedula.Attributes["role"] = "alert";
            this.alertCedula.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La cédula no debe estar vacía</div>";
            this.alertCedula.Visible = true;
            vacio = true;
        }

        if (this.nombreNatural.Value == "")
        {
            this.alertNombre.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertNombre.Attributes["role"] = "alert";
            this.alertNombre.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre no debe estar vacío</div>";
            this.alertNombre.Visible = true;
            vacio = true;
        }

        if (this.apellidoNatural.Value == "")
        {
            this.alertApellido.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertApellido.Attributes["role"] = "alert";
            this.alertApellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido no debe estar vacío</div>";
            this.alertApellido.Visible = true;
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

        if (this.direccionCliente.Value == "")
        {
            this.alertDireccion.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertDireccion.Attributes["role"] = "alert";
            this.alertDireccion.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La dirección está vacía</div>";
            this.alertDireccion.Visible = true;
            vacio = true;
        }

        if (this.correoCliente.Value == "")
        {
            this.alertCorreo.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertCorreo.Attributes["role"] = "alert";
            this.alertCorreo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El correo está vacío</div>";
            this.alertCorreo.Visible = true;
            vacio = true;
        }
        if (this.telefonoCliente.Value == "")
        {
            this.alertTelefono.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertTelefono.Attributes["role"] = "alert";
            this.alertTelefono.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El teléfono está vacío</div>";
            this.alertTelefono.Visible = true;
            vacio = true;
        }


        return vacio;
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