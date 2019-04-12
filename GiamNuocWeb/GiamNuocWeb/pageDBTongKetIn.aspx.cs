using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using GiamNuocWeb.DataBase;
using System.Data.SqlClient;

namespace GiamNuocWeb
{
    public partial class pageDBTongKetIn : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"pageLogin.aspx");

            }
            else if (!Session["role"].ToString().Equals(pUser))
            {
                Response.Redirect(@"zphanquyen.aspx");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBTongKet.aspx";
            pagePhanQuyen("thongbao");           

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();

            //if (Session["role"].ToString().Equals("dobe"))
            //{
            //    cbNhomDB.SelectedValue = Session["manhom"] + "";
            //    cbNhomDB.Enabled = false;

            //}
            //  LoadDiemBe("AND NOT Chuyen='True'");
        }

        public void pageLoad()
        {
            this.tNgay.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-21";
            this.dNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
        }



        public DataSet getThongBaoSuaBe()
        {
            DMADataContext db = new DMADataContext();
            dsDma dsemp = new dsDma();
            DataTable tbLuuLuong = dsemp.g_LuuLuongDHT;
            
            ///////////////////////////// ds

            string sql = "  select * from w_BaoBe ";
            sql += " WHERE TinhTrang=N'ĐĐS' AND  convert(datetime,CAST(ChuyenNgay AS DATE) ,101) BETWEEN CONVERT(datetime,'" + tNgay.Text + "',101) AND CONVERT(datetime,'" + dNgay.Text + "',101)  ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            adapter.Fill(dsemp, "w_BaoBe");

            return dsemp;
        }

        protected void btThen_Click(object sender, EventArgs e)
        {
           
            ReportViewer1.Visible = true;

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            if ("1".Equals(cbChonBC.SelectedValue.ToString()))
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpDBTheoDoi.rdlc");
            }
            else if ("2".Equals(cbChonBC.SelectedValue.ToString()))
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpDBTongKet.rdlc");
            }
            else if ("3".Equals(cbChonBC.SelectedValue.ToString()))
            { }
            else { }
            

            DataTable dsDB = getThongBaoSuaBe().Tables["w_BaoBe"];

            ReportParameter p1 = new ReportParameter("pThang", DateTime.Parse(dNgay.Text).ToString("MM/yyyy"));
            ReportParameter p2 = new ReportParameter("tNgay", DateTime.Parse(tNgay.Text).ToString("dd/MM/yyyy"));
            ReportParameter p3 = new ReportParameter("dNgay", DateTime.Parse(dNgay.Text).ToString("dd/MM/yyyy"));
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDMA", dsDB));
        }

    }
}
