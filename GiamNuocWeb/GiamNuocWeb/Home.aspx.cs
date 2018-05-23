using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;

namespace GiamNuocWeb
{
    public partial class Home1 : System.Web.UI.Page
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
            LoadApLuc("");
            LoadLuuLuong("");
        }
        public void LoadApLuc(string maDMA)
        {
            DataTable tb2=null;
            string sql2 = "SELECT * FROM g_ThongTinDHT WHERE StatusCMP IN (0,1) AND CMPLat IS NOT NULL ";
            if (maDMA != "")
            {
                sql2 = "SELECT * FROM g_ThongTinDHT WHERE MaDMA='" + maDMA + "' AND StatusCMP IN (0,1) AND CMPLat IS NOT NULL ";
                tb2 = LinQConnection.getDataTable(sql2);
            }
            else {
                 tb2 = LinQConnection.getDataTable(sql2);
            }
            Session["dsCMP"] = tb2;
        }

        public void LoadLuuLuong(string maDMA)
        {
            string sql = "SELECT * FROM g_ThongTinDHT WHERE StatusDHT IN (0,1) AND DHTLat IS NOT NULL ";
            if(maDMA!="")
                sql = "SELECT * FROM g_ThongTinDHT WHERE MaDMA='" + maDMA + "' AND StatusDHT IN (0,1) AND DHTLat IS NOT NULL ";
            DataTable tb = LinQConnection.getDataTable(sql);
            if (tb.Rows.Count == 1)
            {
                string tt = "" + tb.Rows[0]["DHTLat"].ToString() + ", " + tb.Rows[0]["DHTLng"].ToString() + "";
                Session["center"] = tt;
            }
            Session["dsDHTong"] = tb;
        }
        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getThongTinDHT();
            listDMA.DataSource = ls;
            listDMA.DataValueField = "MaDMA";
            listDMA.DataTextField = "MaDMA";
            listDMA.DataBind();

        }
        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Select(listDMA.SelectedValue.ToString());
                Session["zoom"] = "16";
            }
            catch (Exception)
            {

            }
        }

        public void Select(string maDMA)
        {
            Session["dsCMP"] = null;
            Session["dsDHTong"] = null;
            if (maDMA != "")
            {
                maDMA = listDMA.SelectedValue.ToString();

                LoadApLuc(maDMA);
                LoadLuuLuong(maDMA);
            }
            else
            {
                if (chekApLuc.Checked == true)
                    LoadApLuc("");
                if (chekLuuLuong.Checked == true)
                    LoadLuuLuong("");
                if (chekApLuc.Checked == true && chekLuuLuong.Checked == true)
                {
                    LoadApLuc("");
                    LoadLuuLuong("");
                }
            }
        }

        protected void chekApLuc_CheckedChanged(object sender, EventArgs e)
        {

            Select("");
        }

        protected void chekLuuLuong_CheckedChanged(object sender, EventArgs e)
        {
            Select("");
        }

    }
}