using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;
using System.Data;

namespace GiamNuocWeb
{
    public partial class pageDoBe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            Load();
        }
        public void Load()
        {
            getLoadDMA();
          
        }
        public void getLoadDMA()
        {
            DataTable tb = LinQConnection.getDataTable("SELECT [MaDMA],([Lat]+','+[Lng]) AS CENTER FROM [tanhoa].[dbo].[g_LabelDMA] ");
            listDMA.DataSource = tb;
            listDMA.DataValueField = "MaDMA";
            listDMA.DataTextField = "MaDMA";
            listDMA.DataBind();

        }

        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = LinQConnection.getDataTable("SELECT *,([Lat]+','+[Lng]) AS CENTER FROM [tanhoa].[dbo].[g_LabelDMA] WHERE MaDMA='"+listDMA.SelectedValue.ToString()+"' ");
                if (tb != null)
                {
                    Session["maps"] = tb.Rows[0]["maps"].ToString();
                    Session["dobe"] = tb.Rows[0]["NhomDoBe"].ToString();
                    Session["center"] = tb.Rows[0]["CENTER"].ToString();
                }
               
               
                
            }
            catch (Exception)
            {

            }
        }
    }
}