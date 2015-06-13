using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTotem;
using Contratos.Modulo5;

public partial class GUI_Modulo5_PrincipalProyecto : System.Web.UI.Page,
    Contratos.Modulo5.IContratoListarRequerimientos 
{
    private  Presentadores.Modulo5.PresentadorListarRequerimiento presentador;
    
    List<Requerimiento> listaRequerimientos;
    

    /// <summary>
    /// Constructor de la clase de la vista
    /// </summary>
    public GUI_Modulo5_PrincipalProyecto()
    {
        this.presentador = new Presentadores.Modulo5.PresentadorListarRequerimiento(this);
    }
    
    
    #region Page_Load()
    protected void Page_Load(object sender, EventArgs e)
    {
        
       this.presentador.ListarRequerimientosPorProyecto("TOT");
    
    } 
    #endregion
}