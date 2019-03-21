using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiamNuocWeb
{
    public partial class pageLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["login"] = null;
            Session["manhom"] = null;
            Session["tennhom"] = null;
            Session["role"] = null;
           
            Response.Redirect("Home.aspx");
        }
    }
}