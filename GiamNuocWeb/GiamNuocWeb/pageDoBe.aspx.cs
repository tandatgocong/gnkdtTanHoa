using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;
using System.Data;
using System.Configuration;
using Microsoft.Reporting.WebForms;

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
            getNhomDoBe();
           // tTuNgay.Text = DateTime.Today.ToString("yyyy-MM-dd");
            DateTime tun = DateTime.Today ;
            try
            {
               tun= DateTime.Parse(DateTime.Now.Year + "-" + (DateTime.Now.Month - 1) + "-21");
            }
            catch (Exception)
            {
            } 
            tTuNgay.Text =tun.ToString("yyyy-MM-dd");
            tDenNgay.Text = DateTime.Today.ToString("yyyy-MM-dd");

        }
        public void getLoadDMA()
        {
            DataTable tb = LinQConnection.getDataTable("SELECT *,([Lat]+','+[Lng]) AS CENTER FROM [tanhoa].[dbo].[g_LabelDMA] ");
            listDMA.DataSource = tb;
            listDMA.DataValueField = "MaDMA";
            listDMA.DataTextField = "MaDMA";
            listDMA.DataBind();
            Session["dsDHTong"] = tb;

            listDMA2.DataSource = tb;
            listDMA2.DataValueField = "MaDMA";
            listDMA2.DataTextField = "MaDMA";
            listDMA2.DataBind();
        }
        public void getNhomDoBe()
        {
            DataTable tb = LinQConnection.getDataTable("SELECT *  FROM [tanhoa].[dbo].[g_NhomDoBe] ");
            cbNhomDoBe.DataSource = tb;
            cbNhomDoBe.DataValueField = "ID";
            cbNhomDoBe.DataTextField = "TenNhom";
            cbNhomDoBe.DataBind();
        }

        protected void listDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = LinQConnection.getDataTable("SELECT *,([Lat]+','+[Lng]) AS CENTER FROM [tanhoa].[dbo].[g_LabelDMA] WHERE MaDMA='" + listDMA.SelectedValue.ToString() + "' ");
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
        protected void listDMA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DataTable tb = LinQConnection.getDataTable("SELECT *,([Lat]+','+[Lng]) AS CENTER FROM [tanhoa].[dbo].[g_LabelDMA] WHERE MaDMA='" + listDMA.SelectedValue.ToString() + "' ");
                //if (tb != null)
                //{
                //    Session["maps"] = tb.Rows[0]["maps"].ToString();
                //    Session["dobe"] = tb.Rows[0]["NhomDoBe"].ToString();
                //    Session["center"] = tb.Rows[0]["CENTER"].ToString();
                //}
                
                string connectionString = ConfigurationManager.ConnectionStrings["Database1_beConnectionString"].ConnectionString;

              //  string sql = " SELECT  * FROM T_DMADoBe  ";

                string sql = " SELECT nb.TenNHom, db.NgayBatDau ";
                sql += " FROM T_DMADoBe AS db, T_NhomDoBe AS nb, T_DMA AS dma ";
                sql += " WHERE db.Nhom= nb.ID AND db.DMA=dma.ID  AND dma.DMA='"+listDMA2.SelectedValue+"'";
                sql += " ORDER BY NgayBatDau DESC ";

                DataTable tb = OledbConnection.getDataTable(connectionString, sql);

              
                DataTable dtTable = tb;

                //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
                //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                // 
                ////  dtTable.DefaultView.Sort = "STT ASC";

                GridView1.DataSource = dtTable;
                GridView1.DataBind();


            }
            catch (Exception)
            {

            }
        }

        protected void radioCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioCheck.SelectedValue == "0")
            {
                panelTongKet.Visible = true;
                panelDMA.Visible = false;
                panelDiemBe.Visible = false;
             //   getDiemBe();
            }
            if (radioCheck.SelectedValue == "1")
            {
                panelTongKet.Visible = false;
                panelDiemBe.Visible = true;
                panelDMA.Visible = false;
            }
            if (radioCheck.SelectedValue == "2")
            {
                panelTongKet.Visible = false;
                panelDiemBe.Visible = false;
                panelDMA.Visible = true;
            }

        }
        public void getDiemBe()
        {
            if (chekChuaSua.Checked == true)
            {
                string tn = this.tTuNgay.Text;
                string dn = this.tDenNgay.Text;
                string connectionString = ConfigurationManager.ConnectionStrings["Database1_beConnectionString"].ConnectionString;

                string sql = " SELECT nb.TenNHom, db.NgayDo, db.NgaySua, db.SoNha, db.Duong, dma.DMA, db.TinhTrang, db.LoaiDiemBe, db.OngBe, db.DVTC, db.NguyenNhan, db.GhiChu ";
                sql += " FROM T_DiemBe AS db, T_NhomDoBe AS nb, T_DMA AS dma ";
                sql += " WHERE db.Nhom= nb.ID AND db.DMA=dma.ID AND ";
                sql += " (db.NgayDo) >= #" + tn + "# AND (db.NgayDo) <=#" + dn + "# ";

                sql += "  AND db.TinhTrang=2 ";
                    sql += " Order by db.Duong ASC";
                DataTable tb = OledbConnection.getDataTable(connectionString, sql);

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpTongKeDiemBe.rdlc");
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpDiemBeChuaSua.rdlc");
                DataTable dtTable = tb;

                //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
                //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                // 
                ////  dtTable.DefaultView.Sort = "STT ASC";

                ReportDataSource rds = new ReportDataSource("v_DiemBe", dtTable);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            else
            {
                string tn = this.tTuNgay.Text;
                string dn = this.tDenNgay.Text;
                string connectionString = ConfigurationManager.ConnectionStrings["Database1_beConnectionString"].ConnectionString;

                string sql = " SELECT nb.TenNHom, db.NgayDo, db.NgaySua, db.SoNha, db.Duong, dma.DMA, db.TinhTrang, db.LoaiDiemBe, db.OngBe, db.DVTC, db.NguyenNhan, db.GhiChu ";
                sql += " FROM T_DiemBe AS db, T_NhomDoBe AS nb, T_DMA AS dma ";
                sql += " WHERE db.Nhom= nb.ID AND db.DMA=dma.ID AND ";
                sql += " (db.NgayDo) >= #" + tn + "# AND (db.NgayDo) <=#" + dn + "# ";
                if (cbNhomDoBe.SelectedValue != "0")
                    sql += "  AND db.Nhom=" + cbNhomDoBe.SelectedValue.ToString() + " ";
                sql += " Order by db.NgayDo ASC";
                DataTable tb = OledbConnection.getDataTable(connectionString, sql);

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpTongKeDiemBe.rdlc");                 
                DataTable dtTable = tb;

                //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
                //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                // 
                ////  dtTable.DefaultView.Sort = "STT ASC";

                ReportDataSource rds = new ReportDataSource("v_DiemBe", dtTable);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }

        }
        protected void cbNhomDoBe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getDiemBe();
            }
            catch (Exception)
            {
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getDiemBe();
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Session["page"] = "pageDoBe.aspx";
            Response.Redirect("pageLogin.aspx");
            //if (UserLogin(this.txtusername.Text, this.txtpassword.Text) == true)
            //{
            //    if (Session["page"] == null)
            //        Response.Redirect("Home.aspx");
            //    else
            //        Response.Redirect(Session["page"].ToString());
            //}
            //else
            //    this.mess.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string FileName = "QuanLyDiemBe.xlsx"; // It's a file name displayed on downloaded file on client side.

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "application/ms-excel";
            response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(Server.MapPath("~/DanhSachDiemBe.xlsx"));
            response.Flush();
            response.End();
        }
      

    }
}