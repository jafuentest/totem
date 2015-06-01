using System;
using System.Collections.Generic;
using System.Web.Services;
using DominioTotem;
using LogicaNegociosTotem.Modulo8;
using Newtonsoft.Json;

public partial class GUI_Modulo8_CrearMinuta : System.Web.UI.Page
{
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

        
    }

    [WebMethod]
    public static string ListaInvolucrado()
    {
        LogicaMinuta logicaMinuta = new LogicaMinuta();
        List<Usuario> listaUsuario = logicaMinuta.ListaUsuario(new Proyecto()
        {
            Codigo = "TOT"
        });
        var output = JsonConvert.SerializeObject(listaUsuario);
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
        for (int i = 0; i < minutaDinamica["involucrado"].Length; i++)
        {
            Usuario usuario = new Usuario
            {
                idUsuario = Int32.Parse(minutaDinamica["involucrado"][i])
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
        //DateTime fechaMi = DateTime.ParseExact(fechaMinuta, "dd/MM/yyyy HH:mm", null);
        DateTime fechaMi = DateTime.Now;
        Minuta minuta = new Minuta
        {
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