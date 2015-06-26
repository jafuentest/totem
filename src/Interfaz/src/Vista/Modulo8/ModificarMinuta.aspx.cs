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
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;

namespace Vista.Modulo8
{
    public partial class ModificarMinuta : System.Web.UI.Page
    {
        private static string codigoMinuta;
        private static FabricaEntidades laFabrica = new FabricaEntidades();
        private static Minuta minuta = (Minuta)laFabrica.ObtenerMinuta();

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
            Presentadores.Modulo8.PresentadorCrearMinuta presentador = new Presentadores.Modulo8.PresentadorCrearMinuta();
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            List<Usuario> listaUsuario = presentador.ListaInvolucrado(elProyecto.Codigo).Cast<Usuario>().ToList();
            List<Contacto> listaContacto = presentador.ListaInvolucradoContacto(elProyecto.Codigo).Cast<Contacto>().ToList();
            var output = JsonConvert.SerializeObject(listaUsuario);
            return output;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método parar cargar los Detalles de la Minuta
        /// </summary>
        /// <returns>Retorna un String con JSON para poder cargar los Detalles de la Minuta</returns>
        [WebMethod]
        public static string detalleMinuta()
        {
            string aux = "";
            for (int i = 0; i <= codigoMinuta.Length - 1; i++)
            {
                if ((codigoMinuta[i].ToString() != "{") && (codigoMinuta[i].ToString() != "}"))
                {
                    aux = aux + codigoMinuta[i];
                }
            }
            string idminuta = aux;
            int codMinuta = Int32.Parse(idminuta);
            Presentadores.Modulo8.PresentadorDetalleMinuta presentador = new Presentadores.Modulo8.PresentadorDetalleMinuta();
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            minuta = (Minuta)presentador.DetalleMinuta(idminuta);
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
            for (int i = 0; i < minutaDinamica["involucrado"].Length; i++)
            {
                Usuario usuario = new Usuario
                {
                    Id = Int32.Parse(minutaDinamica["involucrado"][i])
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
                System.Console.Out.WriteLine(minutaDinamica["acuerdo"]);
                Acuerdo acuerdo = new Acuerdo();
                List<Usuario> listaUsuarioAcuerdo = new List<Usuario>();
                acuerdo.Id = minutaDinamica["acuerdo"][i]["codigo"]; 
                string fechaAcuerdo = minutaDinamica["acuerdo"][i]["fecha"];
                DateTime fechaAcue = DateTime.ParseExact(fechaAcuerdo, "dd-MM-yyyy", null);
                acuerdo.Fecha = fechaAcue;
                acuerdo.Compromiso = minutaDinamica["acuerdo"][i]["compromiso"];
                for (int j = 0; j < minutaDinamica["acuerdo"][i]["involucrado"].Length; j++)
                {
                    Usuario usuarioAcuerdo = new Usuario
                    {
                        Id = Int32.Parse(minutaDinamica["acuerdo"][i]["involucrado"][j])
                    };

                    Console.WriteLine(minutaDinamica["acuerdo"][i]["involucrado"][j]);
                    listaUsuarioAcuerdo.Add(usuarioAcuerdo);
                }
                acuerdo.ListaUsuario = listaUsuarioAcuerdo;
                listaAcuerdo.Add(acuerdo);
            }

            string fechaMinuta = minutaDinamica["fecha"];
            string fechaMinuta2 = "holsgsgsds";
            System.Console.Out.WriteLine(fechaMinuta + " " + fechaMinuta2);
            DateTime fechaMi = DateTime.ParseExact(fechaMinuta, "dd/MM/yyyy HH:mm", null);
            string aux = "";
            for (int i = 0; i <= codigoMinuta.Length - 1; i++)
            {
                if ((codigoMinuta[i].ToString() != "{") && (codigoMinuta[i].ToString() != "}"))
                {
                    aux = aux + codigoMinuta[i];
                }
            }
            string idminuta = aux;
            Minuta minutaNueva = new Minuta
            {
                Id = Int32.Parse(idminuta),
                Fecha = fechaMi,
                Motivo = minutaDinamica["motivo"],
                ListaUsuario = listaUsuario,
                ListaPunto = listaPunto,
                ListaAcuerdo = listaAcuerdo,
                Observaciones = minutaDinamica["observaciones"]
            };

            Presentadores.Modulo8.PresentadorModificarMinuta presentador = new Presentadores.Modulo8.PresentadorModificarMinuta();
            
            Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            string mensaje = presentador.ModificarMinuta(elProyecto, minutaNueva, minuta);
            return mensaje;
        }
    }
}