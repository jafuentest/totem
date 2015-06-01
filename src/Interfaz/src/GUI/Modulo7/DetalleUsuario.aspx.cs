using DominioTotem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo7_DetalleUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "7";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {

                ((MasterPage)Page.Master).ShowDiv = true;
                String userName = Request.QueryString["p"];

                //this.input_cargo.Value = datoUsuario.cargo;

                if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                {
                    userName = "johan7850";
                    Usuario datoUsuario = LogicaNegociosTotem.Modulo7.LogicaUsuario.ObtenerDatos(userName);
                    this.input_usuario.Value = datoUsuario.username;
                    this.input_nombre.Value = datoUsuario.nombre;
                    this.input_apelido.Value = datoUsuario.apellido;
                    this.input_correo.Value = datoUsuario.correo;
                    this.input_pregunta.Value = datoUsuario.preguntaSeguridad;
                    this.input_respuesta.Value = datoUsuario.respuestaSeguridad;
                    llenarComboTipoRol(datoUsuario.rol);
                    actualizarComboCargos(datoUsuario.cargo);
                }
                if (IsPostBack)
                {
                    this.alert_apellido.Visible = false;
                    this.alert_correo.Visible = false;
                    this.alert_nombre.Visible = false;
                    this.alert_pregunta.Visible = false;
                    this.alert_respuesta.Visible = false;
                    this.alert_username.Visible = false;
                    this.alert.Visible = false;
                }

            }
            else
            {
                //Mostrar menu lateral
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        } 
    }

    protected void llenarComboTipoRol(string rolUsuario)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add(rolUsuario, rolUsuario);
        if(rolUsuario == "Usuario")
            options.Add("Administrador", "Administrador");
        if(rolUsuario == "Administrador")
            options.Add("Usuario", "Usuario");      
        comboTipoRol.DataSource = options;
        comboTipoRol.DataTextField = "value";
        comboTipoRol.DataValueField = "key";
        comboTipoRol.DataBind();
    }

    protected void actualizarComboCargos(string cargoUsuario)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();

        options.Add(cargoUsuario, cargoUsuario);

        //   comboCargo.Items.Clear();


        LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();
        List<String> listaCargos = new List<String>();
        listaCargos = mU.ListarCargosUsuarios();

        try
        {
            foreach (String cargo in listaCargos)
            {
                if(cargoUsuario != cargo)
                   options.Add(cargo, cargo);

            }
        }
        catch (Exception ex)
        {

        }


        comboCargo.DataSource = options;
        comboCargo.DataTextField = "value";
        comboCargo.DataValueField = "key";
        comboCargo.DataBind();
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string nuevaClave = "";
        try
        {
            if (this.input_nombre.Value != "")
            {
                if (this.input_apelido.Value != "")
                {
                    if (this.input_correo.Value != "")
                    {
                        if (this.pswd_nuevo.Value != "" && this.pswd_nuevo_conf.Value == this.pswd_nuevo.Value)
                        {
                            nuevaClave = this.pswd_nuevo_conf.Value;
                        }
                        else
                        {
                            //codigo para en caso de que las claves introducidas no coincidan
                        }
                        if (this.input_pregunta.Value != "")
                        {
                            if (this.input_respuesta.Value != "")
                            {
                                Usuario datoNuevo = new Usuario();
                                datoNuevo.username = this.input_usuario.Value;
                                datoNuevo.nombre = this.input_nombre.Value;
                                datoNuevo.apellido = this.input_apelido.Value;
                                datoNuevo.correo = this.input_correo.Value;
                                datoNuevo.clave = this.pswd_nuevo.Value;
                                datoNuevo.rol = this.comboTipoRol.SelectedValue;
                                datoNuevo.cargo = this.comboCargo.SelectedValue;
                                datoNuevo.preguntaSeguridad = this.input_pregunta.Value;
                                datoNuevo.respuestaSeguridad = this.input_respuesta.Value;

                                LogicaNegociosTotem.Modulo7.LogicaUsuario.ModificarUsuario(datoNuevo, nuevaClave);
                                this.alert.Attributes["class"] = "alert alert-info alert-dismissible";
                                this.alert.Attributes["role"] = "alert";
                                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cambios realizados Exitosamente</div>";
                                this.alert.Visible = true;                                

                            }
                            else
                            {
                                this.alert_password.Attributes["class"] = "alert alert-danger alert-dismissible";
                                this.alert_password.Attributes["role"] = "alert";
                                this.alert_password.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Las claves introducidas no coinciden</div>";
                                this.alert_password.Visible = true;
                            }
                        }
                        else
                        {
                            this.alert_pregunta.Attributes["class"] = "alert alert-danger alert-dismissible";
                            this.alert_pregunta.Attributes["role"] = "alert";
                            this.alert_pregunta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La pregunta secreta esta vacio</div>";
                            this.alert_pregunta.Visible = true;
                        }

                    }
                    else
                    {
                        this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
                        this.alert_correo.Attributes["role"] = "alert";
                        this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El correo esta vacio</div>";
                        this.alert_correo.Visible = true;
                    }
                }
                else
                {
                    this.alert_apellido.Attributes["class"] = "alert alert-danger alert-dismissible";
                    this.alert_apellido.Attributes["role"] = "alert";
                    this.alert_apellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido esta vacio</div>";
                    this.alert_apellido.Visible = true;
                }
            }
            else
            {
                this.alert_nombre.Attributes["class"] = "alert alert-danger alert-dismissible";
                this.alert_nombre.Attributes["role"] = "alert";
                this.alert_nombre.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre esta vacio</div>";
                this.alert_nombre.Visible = true;
            }
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
        {
            this.alert_username.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_username.Attributes["role"] = "alert";
            this.alert_username.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Registro no se completo correctamente. Usuario vacio</div>";
            this.alert_username.Visible = true;
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD)
        {
            this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Imposible conectar a la base de datos</div>";
            this.alert.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.CorreoRepetidoException)
        {
            this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_correo.Attributes["role"] = "alert";
            this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Correo Repetido</div>";
            this.alert_correo.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.ClaveNoValidaException)
        {
            this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_correo.Attributes["role"] = "alert";
            this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La clave no pudo ser cambiada,la clave antigua introducido, no concuerda con la del sistema</div>";
            this.alert_correo.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.RegistroUsuarioFallidoException)
        {
            this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Registro de usuario fallido</div>";
            this.alert.Visible = true;
        }
    }
    protected void Unnamed1_Click1(object sender, EventArgs e)
    {
        try
        {
            LogicaNegociosTotem.Modulo7.LogicaUsuario.eliminarUsuario(this.input_usuario.Value);
            Response.Redirect("../Modulo7/ListarUsuarios.aspx");
        }
        catch (ExcepcionesTotem.Modulo7.EliminacionUsuarioExcepcion)
        {
            this.alert_eliminar.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_eliminar.Attributes["role"] = "alert";
            this.alert_eliminar.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminación de usuario fallida</div>";
            this.alert_eliminar.Visible = true;
        }
    }
}