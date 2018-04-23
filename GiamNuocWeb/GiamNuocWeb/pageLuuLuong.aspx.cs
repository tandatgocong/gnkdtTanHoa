using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;
using Microsoft.Reporting.WebForms;
using System.Data;
 

namespace GiamNuocWeb
{
    public partial class pageLuuLuong : System.Web.UI.Page
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
            List<g_ThongTinDHT> ls = CThongTinDMA.getDMAHoatDong();
            foreach (var item in ls)
            {
                DropDownDMA.Items.Add(item.MaDMA);
            }
        }
        public void getLuuLuong()
        {
            string listDMA = "";
            foreach (System.Web.UI.WebControls.ListItem item in DropDownDMA.Items)
            {

                if (item.Selected)
                {
                    listDMA += "'" + item.Value + "',";
                }
            }
           
            
            string tn = this.tTuNgay.Text;
            string dn = this.tDenNgay.Text;
            if (tn.Equals(dn))
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpLuLuongByGio.rdlc");


                ReportParameter p1 = new ReportParameter("tuNgay", "" + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                DataTable dtTable= CLuuLuong.getLuuLuongTheoGio(listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_LuuLuongDHT"];
                dtTable.DefaultView.Sort = "GIO ASC";

                ReportDataSource rds = new ReportDataSource("dsDma",dtTable );
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            else
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpLuLuongByDate.rdlc");


                ReportParameter p1 = new ReportParameter("tuNgay", "" + DateTime.Parse(tn).ToString("dd/MM/yyyy") + " ĐẾN " + DateTime.Parse(dn).ToString("dd/MM/yyyy") + "");
                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

                ReportDataSource rds = new ReportDataSource("dsDma", CLuuLuong.getLuuLuongTheoNgay(listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_LuuLuongDHT"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
        }

        protected void bt_Click(object sender, EventArgs e)
        {

            getLuuLuong();
        }
    }
}