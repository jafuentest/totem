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
using Dominio;
using Dominio.Fabrica;
using System.Data.SqlClient;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;


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
            try
            {
                ComandoListaUsuario comandoListaUsuario = (ComandoListaUsuario)FabricaComandos.CrearComandoListaUsuario();
                List<Dominio.Entidad> listaUsuario = comandoListaUsuario.Ejecutar(codigoProyecto);

                return listaUsuario;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public List<Dominio.Entidad> ListaInvolucradoContacto(string codigoProyecto)
        {
            try
            {
                ComandoListaContacto comandoListaContacto = (ComandoListaContacto)FabricaComandos.CrearComandoListaContacto();
                List<Dominio.Entidad> listaContacto = comandoListaContacto.Ejecutar(codigoProyecto);

                return listaContacto;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string crearMinuta(Entidad laMinuta,string codigoProyecto)
        {
            try
            {
                ComandoGuardarMinuta comandoGuardarMinuta = (ComandoGuardarMinuta)FabricaComandos.CrearComandoGuardarMinuta();
                List<Entidad> parametroGuardar = new List<Entidad>();
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Proyecto elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
                elProyecto.Codigo = codigoProyecto;
                parametroGuardar.Add(elProyecto);
                parametroGuardar.Add(laMinuta);

                return comandoGuardarMinuta.Ejecutar(parametroGuardar);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void ObtenerUsuarioLogeado()
        {
            try
            {
                Usuario usuario = HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
