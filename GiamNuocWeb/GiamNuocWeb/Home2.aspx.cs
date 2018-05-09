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
    public partial class Home2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load();
        }
        public void Load()
        {
            //string sql = "SELECT * FROM g_ThongTinDHT WHERE StatusDHT IN (0,1) AND DHTLat IS NOT NULL ";
            //DataTable tb = LinQConnection.getDataTable(sql);
            //Session["dsDHTong"] = tb;

            //string sql2 = "SELECT * FROM g_ThongTinDHT WHERE StatusCMP IN (0,1) AND CMPLat IS NOT NULL ";
            //DataTable tb2 = LinQConnection.getDataTable(sql2);
            //Session["dsCMP"] = tb2;
        }
    }
}