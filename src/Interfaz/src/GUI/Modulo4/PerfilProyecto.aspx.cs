using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class GUI_Modulo4_PerfilProyecto : System.Web.UI.Page
{
    private DominioTotem.Proyecto esteProyecto = new DominioTotem.Proyecto();

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

        /*DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
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
        }*/

        String[] success = Request.QueryString["success"].Split(new Char [] {','});
        if (success != null)
        {
            switch (success[1])
            {
                case "0":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto modificado exitosamente</div>";
                    break;
                case "1":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento modificado exitosamente</div>";
                    break;
                case "2":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento eliminado exitosamente</div>";
                    break;
                case "3":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso modificado exitosamente</div>";
                    break;
                case "4":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso eliminado exitosamente</div>";
                    break;
                case "5":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Involucrado eliminado exitosamente</div>";
                    break;
            }
        }

        //DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
        esteProyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(success[0]);


        HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

        if (projectCookie == null)
        {
            projectCookie = new HttpCookie("selectedProjectCookie");
            projectCookie.Values["projectCode"] = esteProyecto.Codigo;
            projectCookie.Values["projectName"] = esteProyecto.Nombre;
            Response.Cookies.Add(projectCookie);
        }
        else if (projectCookie.Values["projectCode"] != esteProyecto.Codigo)
        {
            //ScriptManager.RegisterStartupScript(this,typeof(Page),"CallMyFunction","openModal()",true);
            Response.Cookies.Remove("selectedProjectCookie");
            projectCookie = new HttpCookie("selectedProjectCookie");
            projectCookie.Values["projectCode"] = esteProyecto.Codigo;
            projectCookie.Values["projectName"] = esteProyecto.Nombre;
            Response.Cookies.Add(projectCookie);
        }



        this.div_proyecto.InnerHtml = "<div class='jumbotron'>";
        this.div_proyecto.InnerHtml += "<h2 class='sameLine bootstrapBlue' id='nombreProyecto' runat='server'>" + esteProyecto.Nombre + "</h2> <h5 class='sameLine'>COD: </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + esteProyecto.Codigo + "</h5>";
        this.div_proyecto.InnerHtml += "<p class='desc'>" + esteProyecto.Descripcion + "</p>";
        if (esteProyecto.Estado == true)
        {
            this.div_proyecto.InnerHtml += "<input disabled checked data-toggle='toggle' data-size='normal' type='checkbox' data-on='Activo' data-off='Inactivo' data-onstyle='success' data-offstyle='warning' data-width='100'>";
        }
        else
        {
            this.div_proyecto.InnerHtml += "<input disabled unchecked data-toggle='toggle' data-size='normal' type='checkbox' data-on='Activo' data-off='Inactivo' data-onstyle='success' data-offstyle='warning' data-width='100'>";
        }
        this.div_proyecto.InnerHtml += "<br><br>";
        this.div_proyecto.InnerHtml += "<p class='sameLine'>Cliente: </p><p id='nombreCliente' class='sameLine bootstrapBlue'>"+"</p>";
        this.div_proyecto.InnerHtml += "<br><br>";
        this.div_proyecto.InnerHtml += "<p>Progreso:</p>";
        this.div_proyecto.InnerHtml += "<div class='progress'>";
        //Aqui va la funcion para calcular el porcentaje de requerimientos realizados
        this.div_proyecto.InnerHtml += "<div class='progress-bar progress-bar-success' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style='width: 3%;' data-toggle='tooltip' data-placement='top' title='"+" Requerimientos completados de "+"'>";
        this.div_proyecto.InnerHtml += "0%";
        this.div_proyecto.InnerHtml += "</div>";
        this.div_proyecto.InnerHtml += "</div>";
        this.div_proyecto.InnerHtml += "</div>";

        this.modifyButton.Text += "<a class='btn btn-primary' runat='server' href='ModificarProyecto.aspx?success='" + esteProyecto.Codigo + "&success=-1'>Modificar</a>";
    }

    public void Ers(object sender, EventArgs e)
    {
        try
        {
            HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");
            LogicaNegociosTotem.Modulo4.LogicaProyecto.GenerarERS(projectCookie.Values["projectCode"]);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + "ers.pdf");
            Response.TransmitFile(@"C:\Program Files (x86)\IIS Express\ers.pdf");
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}