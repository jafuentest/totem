using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Contratos.Modulo7
{
    /// <summary>
    /// Interface que contiene la firma de las propiedades a ser usadas por la vista de ListarUsuario
    /// </summary>
    public interface IContratoListarUsuarios
    {
        //Variables que se usaran en la interfaz
        HtmlGenericControl tablaUsuarios { get; set; }
    }
}
