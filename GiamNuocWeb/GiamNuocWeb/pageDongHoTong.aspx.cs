using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class pageDongHoTong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            //this.tTuNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //this.tDenNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            getLoadDMA();
            //   getSanLuong();
        }

        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getThongTinDHT ();
            listDMA.DataSource = ls;
            listDMA.DataValueField = "MaDMA";
            listDMA.DataTextField = "MaDMA";
            listDMA.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {

        }

        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string madma = listDMA.SelectedValue.ToString();
                g_ThongTinDHT dh = CThongTinDMA.getDHTByMaDMA(madma);
                if (dh != null)
                {
                    this.txtViTri.Text = dh.ViTri;
                    this.txtPhuong.Text = dh.Phuong;
                    this.txtQuan.Text = dh.Quan;
                    this.txtCoDHN.Text = dh.CoDHN;
                    this.txtHieuDHN.Text = dh.Hieu;
                    this.txtThietBi.Text = dh.ThietBi;
                    this.txtPinNguon.Text = dh.PinNguon;
                    this.txtSoSim.Text = dh.SoSIM;
                    this.txtTinhTrangDHT.Text = dh.TinhTrangDH;
                    this.txtTinhTrangBlogger.Text = dh.TinhTrangBlogger;
                    prv.SelectedValue = dh.PRV.ToString();
                    hamdht.SelectedValue = dh.HamDHT.ToString();
                }
            }
            catch (Exception)
            {
                
                
            }
            
        }
    }
}