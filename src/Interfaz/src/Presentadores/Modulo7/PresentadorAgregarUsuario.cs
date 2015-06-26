using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo7;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo7;
using Dominio.Entidades.Modulo7;
using Dominio;
using Comandos;
using Dominio.Fabrica;
using System.Web.UI.WebControls;
using ExcepcionesTotem.Modulo7;
using ExcepcionesTotem;

namespace Presentadores.Modulo7
{
    /// <summary>
    /// Clase que represnta el presentador de la vista Agregar Usuario segun el patron MVP
    /// </summary>
    public class PresentadorAgregarUsuario
    {
        //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoAgregarUsuario vista;

        /// <summary>
        /// Constructor de esta clase que recibe la vista
        /// </summary>
        /// <param name="vista">La vista que sera manipulada por este presentador</param>
        public PresentadorAgregarUsuario(IContratoAgregarUsuario vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que llena el Dropdown con los roles de un usuario
        /// </summary>
        public void LlenarCombos()
        {
            //Llenamos el combo de los roles
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            options.Add("Usuario", "Usuario");
            options.Add("Administrador", "Administrador");
            vista.comboTipoRol.DataSource = options;
            vista.comboTipoRol.DataTextField = "value";
            vista.comboTipoRol.DataValueField = "key";
            vista.comboTipoRol.DataBind();
            

            //Llenamos el combo de los cargos
            options = new Dictionary<string,string>();
            options.Add("-1", "Selecciona cargo");

            //Instanciamos la fabrica y la lista que contendra la respuesta
            Comando<bool, List<String>> comandoCargos = FabricaComandos.CrearComandoListarCargos();
            List<String> listaCargos = new List<String>();
            try
            {
                //Obtenemos la respuesta del comando
                listaCargos = comandoCargos.Ejecutar(true);
            
                //Recorremos cada cargo obtenido y lo anexamos al diccioanrio
                foreach (String cargo in listaCargos)
                {
                     options.Add(cargo, cargo);
                     
                }

                //finalmente todos los cargos se insertan en el combo
                vista.comboTipoCargo.DataSource = options;
                vista.comboTipoCargo.DataTextField = "value";
                vista.comboTipoCargo.DataValueField = "key";
                vista.comboTipoCargo.DataBind();
                
            }
            //Escribimos en el logger la exception correspondiente y si falla anexamos la primera opcion
            catch (ComandoCargosNoExistentesException ex)
            {
                Logger.EscribirError(this.GetType().Name,ex);
            }
            catch (ComandoBDDAOUsuarioException ex)
            {
                Logger.EscribirError(this.GetType().Name, ex);
            }
            catch(ComandoErrorInesperadoException ex)
            {
                Logger.EscribirError(this.GetType().Name,ex);
            }
            finally
            {
                vista.comboTipoCargo.DataSource = options;
                vista.comboTipoCargo.DataTextField = "value";
                vista.comboTipoCargo.DataValueField = "key";
                vista.comboTipoCargo.DataBind();
            }
        }

        /// <summary>
        /// Metodo que se encarga de Agregar un Usuario a la Base de Datos
        /// </summary>
        /// <returns>Verdadero si la insercion fue exitosa o false sino fue exitosa</returns>
        public bool AgregarUsuario()
        {
            bool exito = false;
            FabricaEntidades laFabrica = new FabricaEntidades();
            /*Verificamos que el nombre, apellido, username, correo, pregunta y respuesta secreta, clave y 
            confirmacion de clave no esten vacios, ademas el cargo y rol deben tener seleccionados valores permitidos*/
            if (!vista.nombreUsuario.Equals("") && !vista.apellidoUsuario.Equals("") && !vista.username.Equals("")
                && !vista.correoUsuario.Equals("") && !vista.preguntaUsuario.Equals("") && !vista.respuestaUsuario.Equals("")
                && (vista.clave == vista.confirmarClave) && !vista.comboTipoCargo.SelectedValue.Equals("-1")
                && !vista.comboTipoRol.SelectedValue.Equals("-1"))
            {

                // Instanciamos la entidad Usuario a traves de su fabrica
                Entidad Usuario = laFabrica.ObtenerUsuario(vista.username, vista.clave, vista.nombreUsuario,
                    vista.apellidoUsuario, vista.comboTipoRol.SelectedValue, vista.correoUsuario, vista.preguntaUsuario,
                    vista.respuestaUsuario, vista.comboTipoCargo.SelectedValue);

                //Instanciamos el comando agregarUsuario a traves de la fabrica
                Comando<Entidad, bool> agregarUsuario = FabricaComandos.CrearComandoAgregarUsuario();

                //Realizamos la operacion y retornamos la respuesta
                exito = agregarUsuario.Ejecutar(Usuario);
            }

            //Retornamos la respuesta
            return exito;
        }
    }
}
