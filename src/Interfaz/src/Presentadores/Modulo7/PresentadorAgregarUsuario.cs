﻿using System;
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

namespace Presentadores.Modulo7
{
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
        public void llenarComboTipoRol()
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            options.Add("Usuario", "Usuario");
            options.Add("Administrador", "Administrador");

            vista.comboTipoRol.DataSource = options;
            vista.comboTipoRol.DataTextField = "value";
            vista.comboTipoRol.DataValueField = "key";
            vista.comboTipoRol.DataBind();
                 
        }

        /// <summary>
        /// Metodo que se encarga de Agregar un Usuario a la Base de Datos
        /// </summary>
        /// <returns>Verdadero si la insercion fue exitosa o false sino fue exitosa</returns>
        public bool AgregarUsuario()
        {
            // Instanciamos la entidad Usuario a traves de su fabrica
            Entidad Usuario = FabricaEntidades.ObtenerUsuario(vista.username,vista.clave,vista.nombreUsuario,
                vista.apellidoUsuario,vista.rolUsuario,vista.correoUsuario,vista.preguntaUsuario,vista.respuestaUsuario,
                vista.cargoUsuario);

            //Instanciamos el comando agregarUsuario a traves de la fabrica
            Comando<Entidad, bool> agregarUsuario = FabricaComandos.CrearComandoAgregarUsuario();

            //Realizamos la operacion y retornamos la respuesta
            bool exito = agregarUsuario.Ejecutar(Usuario);

            //Retornamos la respuesta
            return exito;
        }
    }
}