using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMobile
{
    public partial class LogOut2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["login"] = null;
            Session["phong"] = null;
            Response.Redirect("mHome.aspx");
        }
    }
}