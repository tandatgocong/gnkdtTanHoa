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
using System.Configuration;

namespace GiamNuocWeb
{
    public partial class pageDMADoBe : System.Web.UI.Page
    {
        // static g_ThongTinDHT dh;
        string imgpath;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDongHoTong.aspx";
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
                sql += " WHERE db.Nhom= nb.ID AND db.DMA=dma.ID  AND dma.DMA='" + listDMA.SelectedValue + "'";
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
    }
}