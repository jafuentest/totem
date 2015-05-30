using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using DominioTotem;
using DominioTotem.ResponseObject;
using LogicaNegociosTotem.Modulo8;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class GUI_Modulo8_ModificarMinuta : System.Web.UI.Page
{
    private static string codigoMinuta;

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
    }


    /// <summary>
    /// Método parar cargar los Involucrados del Proyecto
    /// </summary>
    /// <returns>Retorna un String con JSON para poder cargar los Involucrados del Proyecto</returns>
    [WebMethod]
    public static string ListaUsuario()
    {
        LogicaMinuta logicaMinuta = new LogicaMinuta();
        Proyecto elProyecto = new Proyecto() { Codigo = "1" };
        List<Usuario> listaUsuario = logicaMinuta.ListaUsuario(elProyecto);
        var output = JsonConvert.SerializeObject(listaUsuario);
        return output;
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
        Proyecto elProyecto = new Proyecto() { Codigo = "1" };
        Minuta minuta = logicaMinuta.obtenerMinutaPrueba(elProyecto, codMinuta);
        var output = JsonConvert.SerializeObject(minuta);
        return output;
    }

    /// <summary>
    /// Método parar guardar la Minuta
    /// </summary>
    /// <returns>Retorna un mensaje con el estado de la Minuta</returns>
    [WebMethod]
    public static string crearMinuta(object laMinuta)
    {
        dynamic minutaDinamica = laMinuta;
        
        List<Usuario> listaUsuario = new List<Usuario>();
        for (int i = 0; i<minutaDinamica["involucrado"].Length; i++)
        {
            Usuario usuario = new Usuario 
            {
                idUsuario =  Int32.Parse(minutaDinamica["involucrado"][i])
            };
            listaUsuario.Add(usuario);
        }
        List<Punto> listaPunto = new List<Punto>();
        
        for (int i = 0; i < minutaDinamica["punto"].Length; i++)
        {
            Punto punto = new Punto();
            punto.Titulo = minutaDinamica["punto"][i]["titulo"];
            punto.Desarrollo = minutaDinamica["punto"][i]["desarrollo"];
            listaPunto.Add(punto);
        }

        List<Acuerdo> listaAcuerdo = new List<Acuerdo>();
        
        for (int i = 0; i < minutaDinamica["acuerdo"].Length; i++)
        {
            Acuerdo acuerdo = new Acuerdo();
            List<Usuario> listaUsuarioAcuerdo = new List<Usuario>();
            string fechaAcuerdo = minutaDinamica["acuerdo"][i]["fecha"];
            DateTime fechaAcue = DateTime.ParseExact(fechaAcuerdo, "dd-MM-yyyy", null);
            acuerdo.Fecha = fechaAcue;
            acuerdo.Compromiso = minutaDinamica["acuerdo"][i]["compromiso"];
            for (int j = 0; j < minutaDinamica["acuerdo"][i]["involucrado"].Length; j++)
            {
                Usuario usuarioAcuerdo = new Usuario
                {
                    idUsuario = Int32.Parse(minutaDinamica["acuerdo"][i]["involucrado"][j])
                };
                listaUsuarioAcuerdo.Add(usuarioAcuerdo);
            }
            acuerdo.ListaUsuario = listaUsuarioAcuerdo;
            listaAcuerdo.Add(acuerdo);
        }

        string fechaMinuta = minutaDinamica["fecha"];
        DateTime fechaMi = DateTime.ParseExact(fechaMinuta, "dd/MM/yyyy HH:mm", null);

        Minuta minuta = new Minuta
        {
            Codigo = codigoMinuta,
            Fecha = fechaMi,
            Motivo = minutaDinamica["motivo"],
            ListaUsuario = listaUsuario,     
            ListaPunto = listaPunto,
            ListaAcuerdo = listaAcuerdo,
            Observaciones = minutaDinamica["observaciones"]
        };

        LogicaMinuta logicaMinuta = new LogicaMinuta();
        Proyecto elProyecto = new Proyecto() { Codigo = "1" };
        string mensaje = logicaMinuta.GuardarMinuta(elProyecto, minuta);
        return mensaje;
    }
}