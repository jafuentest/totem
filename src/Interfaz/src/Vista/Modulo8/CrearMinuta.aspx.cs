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
    public partial class CrearMinuta : System.Web.UI.Page
    {
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
            codigoProyecto = Server.HtmlEncode(Request.Cookies["selectedProjectCookie"]["projectCode"]);


        }


        /// <summary>
        /// Método parar obtener los Involucrados
        /// </summary>
        /// <returns>Retorna un JSON con la lista de involucrados</returns>
        [WebMethod]
        public static string ListaInvolucrado()
        {
            Presentadores.Modulo8.PresentadorCrearMinuta presentador = new Presentadores.Modulo8.PresentadorCrearMinuta();
            List<Usuario> listaUsuario = presentador.ListaInvolucrado("TOT").Cast<Usuario>().ToList();
            foreach( Usuario usu in listaUsuario)
            {
                System.Console.Out.WriteLine(usu.Nombre);
                System.Console.Out.WriteLine(usu.Apellido);
                System.Console.Out.WriteLine(usu.Rol);


            }
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
            string mensaje = "Minuta";
            try
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
                            Id = Int32.Parse(minutaDinamica["acuerdo"][i]["involucrado"][j])
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
                    Fecha = fechaMi,
                    Motivo = minutaDinamica["motivo"],
                    ListaUsuario = listaUsuario,
                    ListaPunto = listaPunto,
                    ListaAcuerdo = listaAcuerdo,
                    Observaciones = minutaDinamica["observaciones"]
                };

                Presentadores.Modulo8.PresentadorCrearMinuta presentador = new Presentadores.Modulo8.PresentadorCrearMinuta();
                mensaje = presentador.crearMinuta(minuta);
            }
            catch (NullReferenceException ex)
            {
                mensaje = "Error en las Referencias";
            }
            /*catch (ExceptionTotemConexionBD ex)
            {
                mensaje = "Error de conexión con la base de datos";
            }*/
            catch (SqlException ex)
            {
                mensaje = "Error en la Base de Datos";

            }
            catch (FormatException ex)
            {
                mensaje = "Error con la conversión de un Número";
            }
            /*catch (AtributoIncorrectoException ex)
            {
                mensaje = "Error en los Atributos";
            }*/
            catch (Exception ex)
            {
                mensaje = "Error";

            }

            return mensaje;

        }
    }
}