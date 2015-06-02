using System;
using System.Web.Services;
using DominioTotem;
using LogicaNegociosTotem.Modulo8;
using Newtonsoft.Json;

public partial class GUI_Modulo8_DetalleMinutas : System.Web.UI.Page
{
    private static string codigoMinuta;
    private static string codigoProyecto;
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "8";

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
        codigoMinuta = Request.QueryString["idMinuta"];
        codigoProyecto = Server.HtmlEncode(Request.Cookies["selectedProjectCookie"]["projectCode"]);
    }


    /// <summary>
    /// Método parar cargar los Detalles de la Minuta
    /// </summary>
    /// <returns>Retorna un String con JSON para poder cargar los Detalles de la Minuta</returns>
    [WebMethod]
    public static string detalleMinuta()
    {
        int codMinuta = Int32.Parse(codigoMinuta);
        LogicaMinuta logicaMinuta = new LogicaMinuta();
        Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
        Minuta minuta = logicaMinuta.obtenerMinuta(elProyecto, codMinuta);
        var output = JsonConvert.SerializeObject(minuta);
        return output;
    }
}