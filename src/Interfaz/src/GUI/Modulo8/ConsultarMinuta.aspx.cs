using DominioTotem;
using DominioTotem.ResponseObject;
using LogicaNegociosTotem.Modulo8;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class GUI_Modulo8_ConsultarMinuta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "8";
        String success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("1"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><strong>¡Correcto!</strong> - Se ha Creado la Minuta Correctamente</div>";

            }
            else
                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><strong>¡Correcto!</strong> - Se ha Modificado la Minuta Correctamente</div>";

                }
              
        }

        if (Request.Cookies["userInfo"] != null)
        {
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
            {
                Master.ShowDiv = true;
            }
            else
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }

        }
    }


    /// <summary>
    /// Método que construye la Tabla de Consultar Minuta
    /// </summary>
    /// <returns>Retorna un JSON con los valores de la Tabla: Código - Fecha - Motivo - Botones de Acción</returns>
    [WebMethod]
    public static string ListaMinuta()
    {
        LogicaMinuta logicaMinuta = new LogicaMinuta();
        List<Minuta> listaMinuta = logicaMinuta.ListaMinuta(new Proyecto()
        {
            Codigo = "1"
        });
        var dataResponse = new ResponseDataMinuta()
        {
            Draw = 1,
            RecordsTotal = listaMinuta.Count,
            RecordsFiltered = 20,
            Data = from c in listaMinuta select new[] { c.Codigo, c.Fecha.ToString(), c.Motivo, BotonesAcciones(c.Codigo) }
        };
        var output = JsonConvert.SerializeObject(dataResponse);
        return output;
    }


    /// <summary>
    /// Método parar generar los botones de Acción de la Tabla
    /// </summary>
    /// <param name="id">Se utiliza para asiganarle un ID a los botones de Acción</param>
    /// <returns>Retorna un String con los Botones de Acción</returns>
    public static string BotonesAcciones(string id)
    {
        string botonDetalle = "<a id='{0}' class='btn btn-primary glyphicon glyphicon-info-sign' href='DetalleMinutas.aspx?idMinuta={0}'></a>";
        botonDetalle = String.Format(botonDetalle, id);

        string botonModificar = "<a id='{0}' class='btn btn-default glyphicon glyphicon-pencil' href='ModificarMinuta.aspx?idMinuta={0}'></a>";
        botonModificar = String.Format(botonModificar, id);

        string botonImprimir = "<a id='{0}' class='btn btn-success glyphicon glyphicon-print' href='<%= Page.ResolveUrl(\"~/GUI/Modulo8/MINUTA3.aspx\")%>'></a>";
        botonImprimir = String.Format(botonImprimir, id);

        return botonDetalle + botonModificar + botonImprimir;
    }
    
}