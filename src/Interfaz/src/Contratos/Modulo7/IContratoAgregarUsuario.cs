using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Contratos.Modulo7
{
    /// <summary>
    /// Interface que contiene la firma de las propiedades a ser usadas por la vista
    /// </summary>
    public interface IContratoAgregarUsuario
    {
        //Variables que se usaran en la interfaz
        string username { get; }
        string clave { get; }
        string confirmarClave { get; }
        string nombreUsuario { get; }
        string apellidoUsuario { get; }
        string correoUsuario { get; }
        string preguntaUsuario { get; }
        string respuestaUsuario { get; }
        DropDownList comboTipoRol { get; set; }
        DropDownList comboTipoCargo { get; set; }


    }
}
