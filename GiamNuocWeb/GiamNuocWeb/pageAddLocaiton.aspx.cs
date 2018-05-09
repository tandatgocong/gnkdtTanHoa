using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class pageAddLocaiton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            string lat = Request.QueryString["lat"];
            string lng = Request.QueryString["lng"];
            string madma = Request.QueryString["madma"];
            string loai = Request.QueryString["loai"];
            if ("01".Equals(loai))
            {
                string sql = "UPDATE g_ThongTinDHT SET DHTLat='" + lat + "', DHTLng='" + lng + "' WHERE MaDMA='" + madma + "' ";
                LinQConnection.ExecuteCommand(sql);
            }
            else if ("02".Equals(loai))
            {
                string sql = "UPDATE g_ThongTinDHT SET CMPLat='" + lat + "', CMPLng='" + lng + "' WHERE MaDMA='" + madma + "' ";
                LinQConnection.ExecuteCommand(sql);
            }
            //string sql = "INSERT INTO g_LabelDMA VALUES ('" + madma + "','" + lat + "','" + lng + "') ";
            //    LinQConnection.ExecuteCommand(sql);
            
            Response.Redirect(@"Home.aspx");
            
        }

    }
}