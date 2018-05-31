using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using System.Configuration;

namespace GiamNuocWeb
{
    public partial class pageThatThoat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            Load();
            
        }
        void Load()
        {

            string sql = "SELECT CASE WHEN NhomDoBe='' THEN  MaDMA ELSE NhomDoBe END AS MaDMA, Lat, Lng, NhomDoBe, maps FROM g_LabelDMA   ";
            DataTable tb = LinQConnection.getDataTable(sql);
            Session["dsDHtt"] = tb;
        }
       
    }
}