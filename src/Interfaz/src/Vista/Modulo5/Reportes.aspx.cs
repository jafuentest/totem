using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo5_RFuncionalesID : System.Web.UI.Page,Contratos.Modulo5.IContratoReportes
{
    private Presentadores.Modulo5.PresentadorReportes presentador;

    public GUI_Modulo5_RFuncionalesID()
    {
        this.presentador = new Presentadores.Modulo5.PresentadorReportes(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       // this.Master.idModulo = "5";
       // this.Master.presentador.CargarMenuLateral();       
 

    }
}