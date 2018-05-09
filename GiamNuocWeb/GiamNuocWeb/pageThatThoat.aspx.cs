using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class pageThatThoat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM g_LabelDMA  ";
            DataTable tb = LinQConnection.getDataTable(sql);
            Session["dsDHtt"] = tb;
        }
    }
}