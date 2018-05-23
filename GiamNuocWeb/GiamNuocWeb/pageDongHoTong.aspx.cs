using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace GiamNuocWeb
{
    public partial class pageDongHoTong : System.Web.UI.Page
    {
        static g_ThongTinDHT dh;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            //this.tTuNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //this.tDenNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            getLoadDMA();
            Session["imgfile"] = null;
            //   getSanLuong();
        }

        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getThongTinDHT ();
            listDMA.DataSource = ls;
            listDMA.DataValueField = "MaDMA";
            listDMA.DataTextField = "MaDMA";
            listDMA.DataBind();

            if (Session["login"] != null)
            {
                btClear.Visible = true;
                btUpload.Visible = true;
                btSearch.Visible = true;
            }
        }
       
        protected void btSearch_Click(object sender, EventArgs e)
        {
            string madma = listDMA.SelectedValue.ToString();
            //dh = CThongTinDMA.getDHTByMaDMA(madma);
            try
            {
                if (dh != null)
                {
                    dh.ViTri = this.txtViTri.Text;
                    dh.Phuong = this.txtPhuong.Text;
                    dh.Quan = this.txtQuan.Text;
                    dh.ViTriCMP = this.txtViTriCMP.Text;
                    dh.CoDHN = this.txtCoDHN0.Text;
                    dh.Hieu = this.txtHieuDHN0.Text;
                    dh.ThietBi = this.txtThietBi.Text;
                    dh.PinNguon = this.cmpPinNguon.SelectedValue;
                    try { dh.PRV = bool.Parse(this.prv.SelectedValue); }
                    catch (Exception) { }
                    try { dh.HamDHT = hamdht.SelectedValue; }
                    catch (Exception) { }
                    dh.TinhTrangPRV = this.txtTinhTrangPRV.Text;
                    dh.TinhTrangDH = this.txtTinhTrangDHT.Text;
                    dh.TinhTrangBlogger = this.txtTinhTrangBlogger.Text;
                    dh.SoSIM = this.txtSoSim.Text;
                    try
                    {
                        //kt.Img = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);
                        dh.Img = this.imagePath.Value.Replace(",,", @",");
                    }
                    catch (Exception) { }

                    dh.ModifyDate = DateTime.Now;
                    dh.ModifyBy = Session["login"] + "";

                }
                if (CThongTinDMA.Update())
                {
                    lbThanhCong.ForeColor = Color.Blue;
                    this.lbThanhCong.Text = "Cập Nhật Hoàn Công Thành Công.";

                    try
                    {
                        if (!this.txtNoiDung.Text.Equals(""))
                        {
                            g_GhiChu g = new g_GhiChu();
                            g.MaDMA = madma;
                            g.NOIDUNG = this.txtNoiDung.Text;
                            g.CREATEDATE = DateTime.Now;
                            g.CREATEBY = Session["login"] + "";
                            CThongTinDMA.InsertLichSu(g);
                            loadGhiChu();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    lbThanhCong.ForeColor = Color.Red;
                    this.lbThanhCong.Text = "Cập Nhật Hoàn Công Thất Bại.";
                }

               

            }
            catch (Exception)
            {
                lbThanhCong.ForeColor = Color.Red;
                this.lbThanhCong.Text = "Cập Nhật Hoàn Công Thất Bại.";

            }
        }
        public void loadGhiChu()
        {
            string madma = listDMA.SelectedValue.ToString();
            DataTable tb = Class.LinQConnection.getDataTable("SELECT  CONVERT(varchar(25),CREATEDATE,103) AS CREATEDATE,NOIDUNG FROM  g_GhiChu WHERE MaDMA='" + madma + "'");
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }
        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["imgfile"] = "";
            try
            {
                lbThanhCong.Text = "";
                string madma = listDMA.SelectedValue.ToString();
                dh = CThongTinDMA.getDHTByMaDMA(madma);
                if (dh != null)
                {
                    this.txtViTri.Text = dh.ViTri;
                    this.txtPhuong.Text = dh.Phuong;
                    this.txtQuan.Text = dh.Quan;
                    this.txtCoDHN0.Text = dh.CoDHN;
                    this.txtViTriCMP.Text = dh.ViTriCMP;
                    this.txtHieuDHN0.Text = dh.Hieu;
                    this.txtThietBi.Text = dh.ThietBi;
                 //   this.txtPinNguon.Text = dh.PinNguon;
                    this.txtSoSim.Text = dh.SoSIM;
                    this.txtTinhTrangDHT.Text = dh.TinhTrangDH;
                    this.txtTinhTrangBlogger.Text = dh.TinhTrangBlogger;
                    this.txtTinhTrangPRV.Text = dh.TinhTrangPRV;
                    prv.SelectedValue = dh.PRV.ToString();
                    hamdht.SelectedValue = dh.HamDHT.ToString();
                    cmpPinNguon.SelectedValue = dh.PinNguon.ToString();
                    txtSoSim.Text = dh.SoSIM;
                    this.imagePath.Value = dh.Img;
                    Session["imgfile"] = dh.Img;

                    loadGhiChu();
                }
            }
            catch (Exception)
            {
                
                
            }
            
        }
        string imgpath = "";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    string madma = listDMA.SelectedValue.ToString();
                    string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".")); ;

                    string SaveLocation = Server.MapPath("~/FileUpload/");

                    try
                    {
                        System.IO.Directory.CreateDirectory(SaveLocation + @"/" + madma);
                    }
                    catch (Exception)
                    {
                    }
                    SaveLocation = SaveLocation + @"/" + madma + @"/" + fileName;

                     
                    FileUpload1.SaveAs(SaveLocation);

                    upload.Visible = true;

                    imgpath = @"/FileUpload" + @"/" + madma + @"/" + fileName;

                    imgFile.ImageUrl = imgpath;
                  //  this.imagePath.Value = this.imagePath.Value + imgpath + ",";
                    if ("".Equals(this.imagePath.Value))
                    { this.imagePath.Value = this.imagePath.Value + imgpath + ","; }
                    else
                    { this.imagePath.Value = this.imagePath.Value + "," + imgpath; }

                   // Session["imgfile"] = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);
                    Session["imgfile"] = this.imagePath.Value;
                   
                }
                catch (Exception ex)
                {
                    this.upload.Text = "Lỗi Không Upload Ảnh Về Server" + ex.ToString();
                }
        }
        
        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            FileStream newFile = new FileStream(strPath, FileMode.Create);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            string filelis = Session["imgfile"].ToString();
            string[] words = Regex.Split(filelis, ",");
            string SaveLocation = Server.MapPath("~");
            for (int i = 0; i < words.Length; i++)
            {
                if (!words[i].Equals(""))
                {
                    System.IO.File.Delete(SaveLocation + words[i]);
                }

            }
            Session["imgfile"] = "";
        }
    }
}