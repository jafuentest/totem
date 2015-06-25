using Comandos.Fabrica;
using Comandos.Comandos.Modulo8;
using Contratos.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo4;
using System.Web.UI;
using System.Web;


namespace Presentadores.Modulo8
{
    public class PresentadorCrearMinuta
    {
        //private IContratoCrearMinuta vista;

        public PresentadorCrearMinuta()//IContratoCrearMinuta laVista)
        {
            //vista = laVista;
        }


        public List<Dominio.Entidad> ListaInvolucrado(string codigoProyecto)
        {
            ComandoListaUsuario comandoListaUsuario = (ComandoListaUsuario)FabricaComandos.CrearComandoListaUsuario();
            List<Dominio.Entidad> listaUsuario = comandoListaUsuario.Ejecutar(codigoProyecto);


            return listaUsuario;

            /*foreach (Usuario usuario in listaUsuario)
            {
                int codigoUsuario = usuario.IdUsuario;
                string nombreCompletoUsuario = usuario.Nombre + " " + usuario.Apellido;
                var cargoUsuario = usuario.Cargo;
                var divUsuario = codigoUsuario + "_par";
                var checkUsuario = codigoUsuario + "_par_check";
                vista.ListaInvolucrado = (
                   "<div id='" + divUsuario + "' class='panel panel-default panel-participante col-xs-12 col-sm-6' onclick='seleccionado(this)'>"
                   + "   <div class='panel-boddy participante'>"
                   + "       <div class='col-xs-1 check-contenedor'><input type='checkbox' class='participante-check' id='" + checkUsuario + "'/></div>"
                   + "       <div class='col-xs-2 img-participante-contenedor'><img class='img-participante' src='img/user.png' alt='Participante' /></div>"
                   + "       <div class='col-xs-8 nombre-participante'>"
                   + "           <p class='participante-nombre'>" + nombreCompletoUsuario + "</p>"
                   + "           <p class='participante-rol'><small>" + cargoUsuario + "</small></p>"
                   + "       </div>"
                   + "   </div>"
                   + "</div>");

            }*/

        }

        public string crearMinuta(object laMinuta)
        {
            /*string mensaje = "Minuta";
            try
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

                LogicaMinuta logicaMinuta = new LogicaMinuta();
                Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
                mensaje = logicaMinuta.GuardarMinuta(elProyecto, minuta);
            }
            catch (NullReferenceException ex)
            {
                mensaje = "Error en las Referencias";
            }
            catch (ExceptionTotemConexionBD ex)
            {
                mensaje = "Error de conexión con la base de datos";
            }
            catch (SqlException ex)
            {
                mensaje = "Error en la Base de Datos";

            }
            catch (FormatException ex)
            {
                mensaje = "Error con la conversión de un Número";
            }
            catch (AtributoIncorrectoException ex)
            {
                mensaje = "Error en los Atributos";
            }
            catch (Exception ex)
            {
                mensaje = "Error";

            }

            return mensaje;

        }*/
            throw new NotImplementedException();
        }

        public void ObtenerUsuarioLogeado()
        {
            Usuario usuario = HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
        }
    }
}
