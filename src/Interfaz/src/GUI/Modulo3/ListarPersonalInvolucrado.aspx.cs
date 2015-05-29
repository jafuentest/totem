using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;
public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    private ListaInvolucradoUsuario laListaDeUsuarios = new ListaInvolucradoUsuario();

    private ListaInvolucradoContacto laListaDeContactos = new ListaInvolucradoContacto();

    private Proyecto elProy = new Proyecto();

    private Usuario elUser = new Usuario();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

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
        //Muetra alerta en caso de que se haya asignado involucrados al proyecto
         String success = Request.QueryString["success"];
         if (success != null)
         {
             if (success.Equals("1"))
             {
                 alert.Attributes["class"] = "alert alert-success alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Personal agregado exitosamente</div>";
                 
             }
         }

        #region Llenar Data Table Con Usuarios Involucrados
         elProy.Codigo = "TOT"; //codigo del proyecto cableado para prueba del metodo
        LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados(elProy);
        
        HttpCookie pcookie = Request.Cookies.Get("selectedProjectCookie");
        //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
        laListaDeUsuarios = logInv.obtenerUsuariosInvolucradosProyecto(elProy);

        LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();

         foreach(Usuario u in laListaDeUsuarios.Lista)
         {
             this.laTabla.Text +="<tr>";
             this.laTabla.Text +="<td>"+u.nombre.ToString()+"</td>";
             this.laTabla.Text +="<td>"+u.apellido.ToString()+"</td>";
             this.laTabla.Text +="<td>"+u.cargo.ToString()+"</td>";
             this.laTabla.Text += "<td>Compañía De Software</td>";
             this.laTabla.Text += "<td>";
             this.laTabla.Text += "<a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"<%= Page.ResolveUrl(\"~/GUI/Modulo2/DetallarCliente.aspx\") % ></a>";
             this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"  runat=\"server\"></a>";
             this.laTabla.Text += "</td>";
             this.laTabla.Text += "</tr>";

         }
        #endregion

    }



}