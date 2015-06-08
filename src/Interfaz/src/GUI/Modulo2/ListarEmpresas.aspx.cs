using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosTotem.Modulo2;
using DominioTotem;

public partial class GUI_Modulo2_ListarEmpresas : System.Web.UI.Page
{
    private static List<ClienteJuridico> listaEstatica;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        String success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("elim"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha eliminado exitosamente</div>";

            }
            if (success.Equals("edit"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha editado exitosamente</div>";
            }
            if (success.Equals("regis"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha registrado exitosamente</div>";
            }
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

        if (!IsPostBack)
        {
            listaEstatica = new List<ClienteJuridico>();
            consultarEmpresas();
        }
    }
    public void consultarEmpresas()
    {
        try
        {
            listaEstatica = LogicaCliente.consultarListaClientesJuridicos();
            foreach(ClienteJuridico elCliente in listaEstatica)
            {
                this.laTabla.Text += RecursoInterfazM2.AbrirEtiqueta_tr;
                this.laTabla.Text += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Jur_Rif 
                    + RecursoInterfazM2.CerrarEtiqueta_td;
                this.laTabla.Text += RecursoInterfazM2.AbrirEtiqueta_td + elCliente.Jur_Nombre
                    + RecursoInterfazM2.CerrarEtiqueta_td;
                this.laTabla.Text += RecursoInterfazM2.AbrirEtiqueta_td;
                this.laTabla.Text += RecursoInterfazM2.AbrirBotonDetalle + elCliente.Jur_Id +
                    RecursoInterfazM2.CerrarBoton;
                this.laTabla.Text += RecursoInterfazM2.AbrirBotonModificar + elCliente.Jur_Id +
                    RecursoInterfazM2.CerrarBoton;
                this.laTabla.Text += RecursoInterfazM2.AbrirBotonEliminar + elCliente.Jur_Id + 
                    RecursoInterfazM2.CerrarBoton;
                this.laTabla.Text += RecursoInterfazM2.CerrarEtiqueta_td;
                this.laTabla.Text += RecursoInterfazM2.CerrarEtiqueta_tr;
            }
        }
        catch(Exception ex)
        {

        }
    }

}