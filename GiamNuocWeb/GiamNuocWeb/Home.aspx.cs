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

            string sql = "SELECT * FROM g_ThongTinDHT WHERE StatusDHT IN (0,1) AND DHTLat IS NOT NULL ";
            DataTable tb = LinQConnection.getDataTable(sql);
            Session["dsDHTong"] = tb;

            string sql2 = "SELECT * FROM g_ThongTinDHT WHERE StatusCMP IN (0,1) AND CMPLat IS NOT NULL ";
            DataTable tb2 = LinQConnection.getDataTable(sql2);
            Session["dsCMP"] = tb2;
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
            //Session["imgfile"] = "";
            //try
            //{
            //    lbThanhCong.Text = "";
            //    string madma = listDMA.SelectedValue.ToString();
            //    dh = CThongTinDMA.getDHTByMaDMA(madma);
            //    if (dh != null)
            //    {
            //        this.txtViTri.Text = dh.ViTri;
            //        this.txtPhuong.Text = dh.Phuong;
            //        this.txtQuan.Text = dh.Quan;
            //        this.txtCoDHN0.Text = dh.CoDHN;
            //        this.txtViTriCMP.Text = dh.ViTriCMP;
            //        this.txtHieuDHN0.Text = dh.Hieu;
            //        this.txtThietBi.Text = dh.ThietBi;
            //        //   this.txtPinNguon.Text = dh.PinNguon;
            //        this.txtSoSim.Text = dh.SoSIM;
            //        this.txtTinhTrangDHT.Text = dh.TinhTrangDH;
            //        this.txtTinhTrangBlogger.Text = dh.TinhTrangBlogger;
            //        this.txtTinhTrangPRV.Text = dh.TinhTrangPRV;
            //        prv.SelectedValue = dh.PRV.ToString();
            //        hamdht.SelectedValue = dh.HamDHT.ToString();
            //        cmpPinNguon.SelectedValue = dh.PinNguon.ToString();
            //        txtSoSim.Text = dh.SoSIM;
            //        this.imagePath.Value = dh.Img;
            //        Session["imgfile"] = dh.Img;

            //        loadGhiChu();
            //    }
            //}
            //catch (Exception)
            //{


            //}

        }
       
    }
}