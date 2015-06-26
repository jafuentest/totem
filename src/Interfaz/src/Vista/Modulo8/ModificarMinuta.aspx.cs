using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Versioning;
using System.Web.Services;
using Newtonsoft.Json;
using Presentadores;
using System.Linq;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;

namespace Vista.Modulo8
{
    public partial class ModificarMinuta : System.Web.UI.Page
    {
        private static string codigoMinuta;
        private static Minuta minuta = new Minuta();

        private static string codigoProyecto;
        private Presentadores.Modulo8.PresentadorCrearMinuta presentador = new Presentadores.Modulo8.PresentadorCrearMinuta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "8";
                this.Master.presentador.CargarMenuLateral();
                presentador.ObtenerUsuarioLogeado();
            }
            codigoMinuta = Request.QueryString["idMinuta"];
            codigoProyecto = Server.HtmlEncode(Request.Cookies["selectedProjectCookie"]["projectCode"]);
        }


        /// <summary>
        /// Método parar cargar los Involucrados del Proyecto
        /// </summary>
        /// <returns>Retorna un String con JSON para poder cargar los Involucrados del Proyecto</returns>
        [WebMethod]
        public static string ListaUsuario()
        {
            /*LogicaMinuta logicaMinuta = new LogicaMinuta();
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            List<Usuario> listaUsuario = logicaMinuta.ListaUsuario(elProyecto);
            List<Contacto> listaContacto = logicaMinuta.ListaContacto(elProyecto);
            var output = JsonConvert.SerializeObject(listaUsuario);
            return output;*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método parar cargar los Detalles de la Minuta
        /// </summary>
        /// <returns>Retorna un String con JSON para poder cargar los Detalles de la Minuta</returns>
        [WebMethod]
        public static string detalleMinuta()
        {
            /*int codMinuta = Int32.Parse(codigoMinuta);
            LogicaMinuta logicaMinuta = new LogicaMinuta();
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            minuta = logicaMinuta.obtenerMinuta(elProyecto, codMinuta);
            var output = JsonConvert.SerializeObject(minuta);
            return output;*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método parar guardar la Minuta
        /// </summary>
        /// <returns>Retorna un mensaje con el estado de la Minuta</returns>
        [WebMethod]
        public static string crearMinuta(object laMinuta)
        {
            /*dynamic minutaDinamica = laMinuta;
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
            DateTime fechaMi = DateTime.ParseExact(fechaMinuta, "dd/MM/yyyy HH:mm", null);

            Minuta minutaNueva = new Minuta
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
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            string mensaje = logicaMinuta.ModificarMinuta(elProyecto, minutaNueva, minuta);
            return mensaje;*/
            throw new NotImplementedException();
        }
    }
}