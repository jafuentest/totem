using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DominioTotem;

public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    #region Atributos
    private static ListaInvolucradoContacto listaContactos;
    private static ListaInvolucradoUsuario listaUsuarios;
    private Proyecto elProyecto = new Proyecto();
    private LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        #region redireccion a login
        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
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
        #endregion
        #region Acciones que se realizan cuando la pagina se muestra por primera vez
        if (!IsPostBack) // verificar si la pagina se muestra por primera vez
        {
            comboCargo.Enabled = false;
            comboPersonal.Enabled = false;
            llenarComboTipoEmpresas();
            logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados();
            listaContactos = new ListaInvolucradoContacto(); 
            listaUsuarios = new ListaInvolucradoUsuario();
        }
        #endregion

        elProyecto.Codigo = "TOT"; //codigo del proyecto cableado para prueba del metodo
        listaContactos.Proyecto = elProyecto;
        listaUsuarios.Proyecto = elProyecto;
        HttpCookie pcookie = Request.Cookies.Get("selectedProjectCookie");
        //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto

        String eliminacionUsuario = Request.QueryString["usuarioaeliminar"];
        String eliminacionContacto = Request.QueryString["contactoaeliminar"];

        if (eliminacionUsuario != null || eliminacionContacto != null)
        {
            if (eliminacionContacto == null)
                this.user_name.InnerText = eliminacionUsuario;
            else
                this.contacto_id.InnerText = eliminacionContacto;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_delete", "$('#modal_delete').modal();", true);
            upModal.Visible = true;
        }

        String alert_eliminacion = Request.QueryString["success-eliminacion"];

        if (alert_eliminacion == "true")
        {
            this.alertlocal.Attributes["class"] = "alert alert-success alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se elimino correctamente</div>";
            this.alertlocal.Visible = true;
        }
    }
    protected void llenarComboTipoEmpresas()
    {
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add("-1", "Selecciona una opcion");
        options.Add("1", "Cliente");
        options.Add("2", "Compañia de Software");

        comboTipoEmpresa.DataSource = options;
        comboTipoEmpresa.DataTextField = "value";
        comboTipoEmpresa.DataValueField = "key";
        comboTipoEmpresa.DataBind();
    }
    protected void actualizarComboCargos(object sender, EventArgs e)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();

        options.Add("-1", "Selecciona un cargo");

        if (!comboTipoEmpresa.SelectedValue.Equals("-1"))
        {
            comboCargo.Enabled = true;
            if (comboTipoEmpresa.SelectedValue.Equals("1"))
            {
                ClienteJuridico cli = new ClienteJuridico();
                cli.Jur_Id = 1;
                List<String> listaCargos = new List<String>();
                listaCargos = logInv.ListarCargosEmpleados(cli);

                try
                {
                    foreach (String cargo in listaCargos)
                    {
                        options.Add(cargo, cargo);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();
                List<String> listaCargos = new List<String>();
                listaCargos = mU.ListarCargosUsuarios();

                try
                {
                    foreach (String cargo in listaCargos)
                    {
                        options.Add(cargo, cargo);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        comboCargo.DataSource = options;
        comboCargo.DataTextField = "value";
        comboCargo.DataValueField = "key";
        comboCargo.DataBind();
    }
    protected void actualizarComboPersonal(object sender, EventArgs e)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();

        options.Add("-1", "Selecciona un personal");

        comboPersonal.Enabled = true;
        if (comboTipoEmpresa.SelectedIndex == 2 && comboCargo.SelectedIndex != -1)
        {
            LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = mU.ListarUsuariosCargo(comboCargo.SelectedItem.ToString());
            foreach (Usuario u in listaUsuarios)
            {
                options.Add(u.username, u.nombre + " " + u.apellido);
            }

        }
        else
        {
            if (comboTipoEmpresa.SelectedIndex == 1 && comboCargo.SelectedIndex != -1)
            {
                ClienteJuridico jur = new ClienteJuridico();
                jur.Jur_Id = 1;
                List<Contacto> listaContactos = new List<Contacto>();
                listaContactos = logInv.ListarContactoCargoEmpresa(jur, comboCargo.SelectedItem.ToString());
                foreach (Contacto c in listaContactos)
                {
                    options.Add(c.Con_Id.ToString(), c.Con_Nombre + " " + c.Con_Apellido);
                }
            }
        }
        comboPersonal.DataSource = options;
        comboPersonal.DataTextField = "value";
        comboPersonal.DataValueField = "key";
        comboPersonal.DataBind();
    }
    protected void AgregarInvolucrados_Click(object sender, EventArgs e)
    {
        if (comboTipoEmpresa.SelectedIndex == 2 && comboCargo.SelectedIndex != -1)
        {
            #region agregar usuario en la lista

            Usuario elUsuario = logInv.obtenerDatosUsuarioUsername(comboPersonal.SelectedValue);
            elUsuario.username = comboPersonal.SelectedValue;

            if (listaUsuarios.agregarUsuarioAProyecto(elUsuario))
            {
                this.laTabla.Text += "<tr id=\"" + elUsuario.username + "\" >";
                this.laTabla.Text += "<td>" + elUsuario.nombre + "</td>";
                this.laTabla.Text += "<td>" + elUsuario.apellido + "</td>";
                this.laTabla.Text += "<td>" + elUsuario.cargo + "</td>";
                this.laTabla.Text += "<td>Compañía De Software</td>";
                this.laTabla.Text += "<td>";
                this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrado.aspx?usuarioaeliminar=" + elUsuario.username + "\"></a>";
                this.laTabla.Text += "</td>";
                this.laTabla.Text += "</tr>";

                comboCargo.SelectedIndex = 0;
                comboPersonal.SelectedIndex = 0;
                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", "Seleccione una opcion");
                comboCargo.Items.Clear();
                comboCargo.DataSource = options;
                comboCargo.DataTextField = "value";
                comboCargo.DataValueField = "key";
                comboCargo.DataBind();

                comboPersonal.Items.Clear();
                comboPersonal.DataSource = options;
                comboPersonal.DataTextField = "value";
                comboPersonal.DataValueField = "key";
                comboPersonal.DataBind();

            }
            #endregion
        }
        else
        {
            #region agregar contacto en la lista
            Contacto elContacto = new Contacto();
            elContacto.Con_Id = int.Parse(comboPersonal.SelectedValue);
            elContacto = logInv.obtenerDatosContactoID(int.Parse(comboPersonal.SelectedValue));
            if (listaContactos.agregarContactoAProyecto(elContacto))
            {       
    
                this.laTabla.Text += "<tr id=\"" + elContacto.Con_Id + "\" >";
                this.laTabla.Text += "<td>" + elContacto.Con_Nombre + "</td>";
                this.laTabla.Text += "<td>" + elContacto.Con_Apellido + "</td>";
                this.laTabla.Text += "<td>" + elContacto.ConCargo + "</td>";
                this.laTabla.Text += "<td>" + elContacto.ConClienteJurid.Jur_Nombre + "</td>";
                this.laTabla.Text += "<td>";
                this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrado.aspx?contactoaeliminar=" + elContacto.Con_Id + "\"></a>";
                this.laTabla.Text += "</td>";
                this.laTabla.Text += "</tr>";

                comboCargo.SelectedIndex = 0;
                comboPersonal.SelectedIndex = 0;
                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("-1", "Seleccione una opcion");
                comboCargo.Items.Clear();
                comboCargo.DataSource = options;
                comboCargo.DataTextField = "value";
                comboCargo.DataValueField = "key";
                comboCargo.DataBind();

                comboPersonal.Items.Clear();
                comboPersonal.DataSource = options;
                comboPersonal.DataTextField = "value";
                comboPersonal.DataValueField = "key";
                comboPersonal.DataBind();
            }
            #endregion
        }
    }
    protected void btn_enviar_Click(object sender, EventArgs e)
    {
        try
        {
            if (listaContactos.Lista.ToArray().Length != 0)
                logInv.agregarContactosEnBD(listaContactos);
            if (listaUsuarios.Lista.ToArray().Length != 0)
                logInv.agregarUsuariosEnBD(listaUsuarios);
            Response.Redirect("../Modulo3/ListarPersonalInvolucrado.aspx?success=true");
        }
        catch (ExcepcionesTotem.Modulo3.ProyectoSinCodigoException ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.Modulo3.ListaSinProyectoException ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.Modulo3.ListaSinInvolucradosException ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.Modulo3.InvolucradoRepetidoException ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.Modulo3.UsuarioSinUsernameException ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
        catch (ExcepcionesTotem.ExceptionTotem ex)
        {
            this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alertlocal.Attributes["role"] = "alert";
            this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Mensaje + "</div>";
            this.alertlocal.Visible = true;    
        }
    }
    protected void evento_eliminar(object sender, EventArgs e)
    {
        if (!this.user_name.InnerText.Equals(""))
        {
            Usuario user = new Usuario();
            user.username = this.user_name.InnerHtml;

             if(listaUsuarios.eliminarUsuarioDeListaPorUsername(user, listaUsuarios))
                    Response.Redirect("../Modulo3/AgregarInvolucrado.aspx?success-eliminacion=true");
            else
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminación de usuario fallida</div>";
                this.alertlocal.Visible = true;
            }
        }
        else
            if (!this.contacto_id.InnerText.Equals(""))
            {
                Contacto contacto = new Contacto();
                contacto.Con_Id = int.Parse(this.contacto_id.InnerText);

                if (listaContactos.eliminarContactoDeListaPorID(contacto, listaContactos))
                    Response.Redirect("../Modulo3/AgregarInvolucrado.aspx?success-eliminacion=true");
                else
                {
                    this.alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminación de contacto fallida</div>";
                    this.alertlocal.Visible = true;
                }
            }
    }
}