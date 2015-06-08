using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GUI_Modulo4_ListaProyectos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

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
            LlenarComboBoxFiltro();

            DataTable proyectos = new DataTable();
            String username = "albertods";
            proyectos = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarTodosLosProyectos(username);
            if (proyectos != null)
            {
                if (proyectos.Rows.Count > 0)
                {
                    foreach (DataRow row in proyectos.Rows)
                    {
                        this.jumbotronProyecto.Text += "<div class='form-group'>";
                        // this.jumbotronProyecto.Text += "<div id='div_perfiles' class='col-sm-12 col-md-12 col-lg-12'>";
                        this.jumbotronProyecto.Text += "<div class='jumbotron'>";
                        this.jumbotronProyecto.Text += "<h2 class='sameLine'><a href='PerfilProyecto.aspx?success=" + row["codigo"].ToString() + "&success=-1'>" + row["nombre"].ToString() + "</a></h2> <h5 class='sameLine'>COD: </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + row["codigo"].ToString() + "</h5>";
                        this.jumbotronProyecto.Text += "<p class='desc'>" + row["descripcion"].ToString() + "</p>";
                        if (bool.Parse(row["estado"].ToString()) == true)
                        {
                            this.jumbotronProyecto.Text += "<input type='checkbox' checked disabled> Activo";
                        }
                        else
                        {
                            this.jumbotronProyecto.Text += "<input type='checkbox' unchecked disabled> Inactivo";
                        }
                        this.jumbotronProyecto.Text += "<br><br>";
                        DataTable nombreClienteNatural = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerNombreClienteNatural(row["codigo"].ToString());
                        DataTable nombreClienteJuridico = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerNombreClienteJuridico(row["codigo"].ToString());
                        if (nombreClienteNatural != null)
                        {
                            foreach (DataRow cliente in nombreClienteNatural.Rows)
                            {
                                this.jumbotronProyecto.Text += "<p class='sameLine'>Cliente: " + cliente["cn_nombre"].ToString() + " " + cliente["cn_apellido"].ToString() + "</p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
                            }
                        }
                        if (nombreClienteJuridico != null)
                        {
                            foreach (DataRow cliente in nombreClienteJuridico.Rows)
                            {
                                this.jumbotronProyecto.Text += "<p class='sameLine'>Cliente: " + cliente["cj_nombre"].ToString() + "</p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
                            }
                        }
                        this.jumbotronProyecto.Text += "</div>";
                        //this.jumbotronProyecto.Text += "</div>";
                        this.jumbotronProyecto.Text += "</div>";
                    }
                }
            }
            else
            {
                this.jumbotronProyecto.Text += "<div class='form-group'>";
                this.jumbotronProyecto.Text += "<div id='div_perfiles' class='col-sm-12 col-md-12 col-lg-12'>";
                this.jumbotronProyecto.Text += "<div class='jumbotron'>";
                this.jumbotronProyecto.Text += "<h2>:(</h2>";
                this.jumbotronProyecto.Text += "<p class='desc'>Lo sentimos, no hay proyectos asociados a este ususario...</p>";
                this.jumbotronProyecto.Text += "</div>";
                this.jumbotronProyecto.Text += "</div>";
                this.jumbotronProyecto.Text += "</div>";
            }
        }
    }

    public void BuscarProyectos(object sender, EventArgs e)
    {
        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            String username = user.username;
            DataTable proyectosFiltrados = new DataTable();
            this.jumbotronProyecto.Text = "";

            if (this.comboFiltro.SelectedItem.ToString().Equals("Todos"))
            {
                proyectosFiltrados = LogicaNegociosTotem.Modulo4.LogicaProyecto.BuscarProyectos(this.tbBusqueda.Text, username);
            }
            else if (this.comboFiltro.SelectedItem.ToString().Equals("Activos"))
            {
                proyectosFiltrados = LogicaNegociosTotem.Modulo4.LogicaProyecto.BuscarProyectosActivos(this.tbBusqueda.Text, username);
            }
            else
            {
                proyectosFiltrados = LogicaNegociosTotem.Modulo4.LogicaProyecto.BuscarProyectosInactivos(this.tbBusqueda.Text, username);
            }

            if (proyectosFiltrados != null)
            {
                if (proyectosFiltrados.Rows.Count > 0)
                {
                    foreach (DataRow row in proyectosFiltrados.Rows)
                    {
                        this.jumbotronProyecto.Text += "<div class='form-group'>";
                        this.jumbotronProyecto.Text += "<div class='jumbotron'>";
                        this.jumbotronProyecto.Text += "<h2 class='sameLine'><a href='PerfilProyecto.aspx?success=" + row["pro_codigo"].ToString() + "&success=-1'>" + row["pro_nombre"].ToString() + "</a></h2> <h5 class='sameLine'>COD: </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + row["pro_codigo"].ToString() + "</h5>";
                        this.jumbotronProyecto.Text += "<p class='desc'>" + row["pro_descripcion"].ToString() + "</p>";
                        if (bool.Parse(row["pro_estado"].ToString()) == true)
                        {
                            this.jumbotronProyecto.Text += "<input type='checkbox' checked disabled> Activo";
                        }
                        else
                        {
                            this.jumbotronProyecto.Text += "<input type='checkbox' unchecked disabled> Inactivo";
                        }
                        this.jumbotronProyecto.Text += "<br><br>";
                        DataTable nombreClienteNatural = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerNombreClienteNatural(row["pro_codigo"].ToString());
                        DataTable nombreClienteJuridico = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerNombreClienteJuridico(row["pro_codigo"].ToString());
                        if (nombreClienteNatural != null)
                        {
                            foreach (DataRow cliente in nombreClienteNatural.Rows)
                            {
                                this.jumbotronProyecto.Text += "<p class='sameLine'>Cliente: " + cliente["cn_nombre"].ToString() + " " + cliente["cn_apellido"].ToString() + "</p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
                            }
                        }
                        if (nombreClienteJuridico != null)
                        {
                            foreach (DataRow cliente in nombreClienteJuridico.Rows)
                            {
                                this.jumbotronProyecto.Text += "<p class='sameLine'>Cliente: " + cliente["cj_nombre"].ToString() + "</p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
                            }
                        }
                        this.jumbotronProyecto.Text += "</div>";
                        this.jumbotronProyecto.Text += "</div>";
                    }
                }
            }
            else
            {
                this.jumbotronProyecto.Text += "<div class='form-group'>";
                this.jumbotronProyecto.Text += "<div class='jumbotron'>";
                this.jumbotronProyecto.Text += "<h2>:(</h2>";
                this.jumbotronProyecto.Text += "<p class='desc'>Lo sentimos, no encontramos proyectos relacionados con la informacion ingresada...</p>";
                this.jumbotronProyecto.Text += "</div>";
                this.jumbotronProyecto.Text += "</div>";
            }
        }
    }


    public void LlenarComboBoxFiltro()
    {
        comboFiltro.Items.Add("Todos");
        comboFiltro.Items.Add("Activos");
        comboFiltro.Items.Add("Inactivos");
    }

}