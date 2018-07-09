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
    public partial class pageThatThoatTiLe : System.Web.UI.Page
    {
        static string value;
        protected void Page_Load(object sender, EventArgs e)
        {

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            getLoadDMA();
            try
            {
                value = Request.Params["value"].ToString().Replace("DMA ", "").Replace(".", "-");
            }
            catch (Exception)
            {
            }
            listDMA.SelectedValue = value.Substring(0, 5);
            getTiLee(value);
            getCMP(value);
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
                value = listDMA.SelectedValue.ToString();
                getTiLee(value);
                getCMP(value);
            }
            catch (Exception)
            {

            }

        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                value = listDMA.SelectedValue.ToString();
                getTiLee(value);
                getCMP(value);
            }
            catch (Exception)
            {

            }
        }
        void getTiLee(string madma)
        {
            int rc = int.Parse(this.tTuNgay.Text);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpThatThoatTiLe.rdlc");
            DataTable dtTable = CSanLuong.getThatThoatTiLe(rc, madma).Tables["g_ThatThoatDMA"];

            //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
            //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            // 
            ////  dtTable.DefaultView.Sort = "STT ASC";

            ReportDataSource rds = new ReportDataSource("g_ThatThoatDMA", dtTable);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }

        public void getCMP(string madma)
        {

            int rc = int.Parse(this.tTuNgay.Text);
            DataTable dtTable = CSanLuong.getThatThoatTiLe(rc, madma).Tables["g_ThatThoatDMA"];
            string title = "['Ngày','TL']";



            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                string tim = DateTime.Parse(dtTable.Rows[i]["TimeStamp"].ToString()).ToString("dd/MM");
                string tile = String.Format("{0:0.##}", double.Parse(dtTable.Rows[i]["TiLe"].ToString()) * 100) ;
                //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                title += ", ['" + tim + "'," + tile + "]";
            }

            Session["sanluong"] = title;


        }

    }
}