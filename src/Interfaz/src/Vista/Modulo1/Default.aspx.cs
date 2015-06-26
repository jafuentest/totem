using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie aCookie = new HttpCookie("Intento");
            aCookie.Values["inten"] = "0";
            aCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(aCookie);
        }
    }
}