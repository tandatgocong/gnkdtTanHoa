﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;
using Microsoft.Reporting.WebForms;
using System.Drawing;
using System.Data;

namespace GiamNuocWeb
{
    public partial class pageSanLuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   this.Label1.Text = CThongTinDMA.getDHTLoi();
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            //this.tTuNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //this.tDenNgay.Text = DateTime.Now.ToString("MM/dd/yyyy");
            getLoadDMA();
            bt92dh.Style.Add("background-color", "red");
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
     
        public void getSanLuong()
        {
            string listDMA = "";
            foreach (System.Web.UI.WebControls.ListItem item in DropDownDMA.Items)
            {

                if (item.Selected)
                {
                    listDMA += "'" + item.Value + "',";
                }


            }
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            
            string tn = this.tTuNgay.Text;
            string dn = this.tDenNgay.Text;

            ReportParameter p1 = new ReportParameter("tuNgay", "" + DateTime.Parse(tn).ToString("dd/MM/yyyy") + " ĐẾN " + DateTime.Parse(dn).ToString("dd/MM/yyyy") + "");
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            ReportDataSource rds = new ReportDataSource("dsDma", CSanLuong.getSanLuong(listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_SanLuongDHT"]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }
        public void getSanLuongNRW()
        {
            string listDMA = "";
            foreach (System.Web.UI.WebControls.ListItem item in DropDownDMA.Items)
            {

                if (item.Selected)
                {
                    listDMA += "'" + item.Value + "',";
                }


            }
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            string tn = this.tTuNgay.Text;
            string dn = this.tDenNgay.Text;

            ReportParameter p1 = new ReportParameter("tuNgay", "" + DateTime.Parse(tn).ToString("dd/MM/yyyy") + " ĐẾN " + DateTime.Parse(dn).ToString("dd/MM/yyyy") + "");
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            ReportDataSource rds = new ReportDataSource("dsDma", CSanLuong.getSanLuongNRW(listDMA.Remove(listDMA.Length - 1, 1), tn, dn).Tables["g_SanLuongDHT"]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (check.Checked == false)
                {
                    getSanLuong();
                }
                else
                {
                    getSanLuongNRW();
                }

            }
            catch (Exception)
            {
                
            }
            
        }

        protected void bt92dh_Click(object sender, EventArgs e)
        {
            //bt92dh.BackColor = Color.Red;
          //  bt49dh.BackColor = Color.Red;
            bt92dh.Style.Add("background-color", "red");
            bt49dh.Style.Add("background-color", "#02579D");
            Panel92.Visible = true;
            Panel49.Visible = false;
        }

        protected void bt49dh_Click(object sender, EventArgs e)
        {
           // bt49dh.BackColor = Color.Red;
            //bt92dh.BackColor = Color.Red;
            bt49dh.Style.Add("background-color", "red");
            bt92dh.Style.Add("background-color", "#02579D");

            Panel92.Visible = false;
            Panel49.Visible = true;
        }
        protected void bt49_Click(object sender, EventArgs e)
        {
            string tn = this.tnNgay49.Text;
            string dn = this.dnNgay49.Text;
            ReportViewer2.ProcessingMode = ProcessingMode.Local;
            ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/rpSanLuongDHT.rdlc");
            DataTable dtTable = CSanLuong.getLuuLuongDHTM(tn, dn).Tables["w_SanLuongTM"];

            //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
            //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            // 
            ////  dtTable.DefaultView.Sort = "STT ASC";

            ReportDataSource rds = new ReportDataSource("w_SanLuongTM", dtTable);
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(rds);

        }
    }
}