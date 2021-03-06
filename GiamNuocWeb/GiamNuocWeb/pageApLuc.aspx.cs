﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace GiamNuocWeb
{
    public partial class pageApLuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Label1.Text = CThongTinDMA.getCMPLoi();
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            this.tTuNgay.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            this.tDenNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");
            getLoadDMA();
            //   getSanLuong();
        }

        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getCMPHoatDong();
            foreach (var item in ls)
            {
                DropDownDMA.Items.Add(item.MaDMA);
            }
        }
      
        public void getApLuc()
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


                ReportParameter p1 = new ReportParameter("tuNgay", "ÁP LỰC TRUNG BÌNH (bar)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                DataTable dtTable = CApLuc.getApLucTheoGio(listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_LuuLuongDHT"];
                dtTable.DefaultView.Sort = "GIO ASC";

                ReportDataSource rds = new ReportDataSource("dsDma", dtTable);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            else
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpLuLuongByDate.rdlc");


                ReportParameter p1 = new ReportParameter("tuNgay", "ÁP LỰC TRUNG BÌNH (bar)  ĐỒNG HỒ TỔNG DMA TỪ NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy") + " ĐẾN " + DateTime.Parse(dn).ToString("dd/MM/yyyy") + "");
                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

                ReportDataSource rds = new ReportDataSource("dsDma", CApLuc.getApLucTheoNgay (listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_LuuLuongDHT"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
        } 

        protected void bt_Click(object sender, EventArgs e)
        {
            getApLuc();
        }
    }
}
