using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace GiamNuocWeb
{
    public partial class pageThatThoat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            LoadBieuDo();
            for (int i = 0; i < 3; i++)
            {
                drNam.Items.Add((DateTime.Now.Year + (-i)).ToString());

            }
            
        }
        void LoadBieuDo()
        {

            string sql = "SELECT CASE WHEN NhomDoBe='' THEN  MaDMA ELSE NhomDoBe END AS MaDMA, Lat, Lng, NhomDoBe, maps FROM g_LabelDMA   ";
            DataTable tb = LinQConnection.getDataTable(sql);
            Session["dsDHtt"] = tb;
        }
        void LoadTiLe()
        {
            string sql = " SELECT TOP(92) [TimeStamp], A.[STT],A.[MaDMA],[QI],[QM],[Sucxa],[NRW] ,[TiLe] ,[MNF] ,[DiemBeTon] ,[TinhTrang],B.NhomDoBe  FROM [tanhoa].[dbo].[g_ThatThoatDMA] A  LEFT JOIN [tanhoa].[dbo].[g_LabelDMA] B  ON A.MaDMA=B.MaDMA AND A.TiLe is not null  ORDER BY [TimeStamp] DESC, STT ASC ";
            DataTable tb = LinQConnection.getDataTable(sql);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpThatThoatTuan.rdlc");
            DataTable dtTable = LinQConnection.getDataTable(sql);

            //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
            //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            // 
            ////  dtTable.DefaultView.Sort = "STT ASC";

            ReportDataSource rds = new ReportDataSource("g_ThatThoatDMA", dtTable);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);



        }
        public void LoadThatThoatMangLuoi(int nam)
        {
            string sql = " SELECT * FROM g_ThatThoatMangLuoi WHERE NAM="+nam+" ORDER BY KY ASC";
            DataTable tb = LinQConnection.getDataTable(sql);

            ReportViewer2.ProcessingMode = ProcessingMode.Local;
            ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/rpThatThoatMangLuoi.rdlc");
            DataTable dtTable = LinQConnection.getDataTable(sql);

            //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
            //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            // 
            ////  dtTable.DefaultView.Sort = "STT ASC";

            ReportDataSource rds = new ReportDataSource("g_ThatThoatMangLuoi", dtTable);
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(rds);
        }
        protected void radioCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioCheck.SelectedValue == "0")
            {
                pBieuDoThatThoat.Visible = true;
                pThatThoatMangLuoi.Visible = false;
                pTiLeThatThoat.Visible = false;
                LoadBieuDo();
            }
            if (radioCheck.SelectedValue == "1")
            {
                pBieuDoThatThoat.Visible = false;
                pTiLeThatThoat.Visible = true;
                pThatThoatMangLuoi.Visible = false;
                LoadTiLe();
            }

            if (radioCheck.SelectedValue == "2")
            {
                pBieuDoThatThoat.Visible = false;
                pTiLeThatThoat.Visible = false;
                pThatThoatMangLuoi.Visible = true;
                LoadThatThoatMangLuoi(DateTime.Now.Year);
            }

        }

        protected void drNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int t = int.Parse(drNam.SelectedItem.ToString());
                LoadThatThoatMangLuoi(t);
            }
            catch (Exception)
            {
                
               
            }
           
        }

       
    }
}