using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;

namespace GiamNuocWeb
{
    public partial class pageSanLuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            this.tTuNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            this.tDenNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            getLoadDMA();
            getSanLuong();
        }

        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getDMAHoatDong();
            foreach (var item in ls)
            {
                DropDownDMA.Items.Add(item.MaDMA);
            }
        }
        public void getSanLuong()
        {
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;

            //ReportParameter p1 = new ReportParameter("tuNgay", " 23/07/2018 ĐẾN 25/88/2018");
            //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            //ReportDataSource rds = new ReportDataSource("dsDma", CSanLuong.getSanLuong("", "", "").Tables["g_SanLuongDHT"]);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
}