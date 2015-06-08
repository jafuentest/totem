using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos;
using Presentadores;

namespace Vista.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage, IContratoMasterPage
    {
        private PresentadorMasterPage presentador;
        private String idModulo;

        public MasterPage()
        {
            presentador = new PresentadorMasterPage(this);
        }

        #region Contrato
        bool IContratoMasterPage.menuLateral
        {
            set { menuLateral.Visible = value; }
        }

        bool IContratoMasterPage.ulNav
        {
            set { ulNav.Visible = value; }
        }

        String IContratoMasterPage.opcionesDeMenu
        {
            get { return opcionesDeMenu.InnerHtml; }
            set { opcionesDeMenu.InnerHtml = value; }
        }

        String IContratoMasterPage.idModulo
        {
            set { idModulo = value; }
            get { return idModulo; }
        }

        String IContratoMasterPage.selectedProject
        {
            set { selectedProject.InnerText = value; }
        }

        String IContratoMasterPage.perfilProyecto
        {
            set { perfilProyecto.Text = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador.CargarMenuLateral();
            presentador.RevisarCookies();
            presentador.RevisarSession();
        }



    }

}