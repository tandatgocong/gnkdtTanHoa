using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using Microsoft.Reporting.WebForms;

namespace GiamNuocWeb
{
    public partial class pageThatThoatSanLuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
           // PageLoad();
        }
        public void LoadData()
        {
            DataTable workTable = new DataTable("DHNTM");
            workTable.Columns.Add("STT", typeof(String));
            workTable.Columns.Add("MaDH", typeof(String));
            workTable.Columns.Add("ViTri", typeof(String));
            workTable.Columns.Add("TONGSL", typeof(String));
           
            DateTime tNgay = DateTime.ParseExact("22/05/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dNgay = DateTime.ParseExact("25/05/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //thang__ = dNgay.Month.ToString();
            TimeSpan Time = dNgay - tNgay;
            int TongSoNgay = Time.Days+1;
           // Panel2.Width = TongSoNgay * 150;
            string[] arrTitle = new string[TongSoNgay];
            int numTitle = 0;            
            int flag = 2;
            while (tNgay <= dNgay)
            {
               // workTable.Columns.Add(Class.Format.NgayVNVN__(tNgay), typeof(String));
                arrTitle[numTitle++] = Class.Format.NgayVNVN__(tNgay);
                workTable.Columns.Add(Class.Format.NgayVNVN__(tNgay) + "TONGTT", typeof(String));
                workTable.Columns.Add(Class.Format.NgayVNVN__(tNgay) + "TANGGIAM", typeof(String));
                tNgay = tNgay.AddDays(1.0);
                flag = flag + 3;
            }
          
           

            string sqlDHTM = "SELECT * FROM [tanhoa].[dbo].[g_ThongTinDHTM] ORDER BY STT ASC ";
            
            DataTable tb = LinQConnection.getDataTable(sqlDHTM);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow row = workTable.NewRow();
                string MaDH = tb.Rows[i]["MaDH"].ToString();
                string sql2 = "SELECT * FROM [tanhoa].[dbo].[g_SanLuongTM] WHERE MaDH='" + MaDH + "' AND convert(date,[TimeStamp],101) BETWEEN CONVERT(datetime,'" + tNgay + "',101) AND CONVERT(datetime,'" + dNgay + "',101) ";
                DataTable tb2 = LinQConnection.getDataTable(sql2);
                row["STT"] = i+1;
                row["MaDH"] = MaDH;
                row["ViTri"] = tb.Rows[i]["DiaChi"].ToString();
                
                double _tongsl = 0;
                //for (int j = 0; j < tb2.Rows.Count; j++)
                //{
                //    row[Class.Format.NgayVNVN__(tNgay) + "TONGTT"] = tb2.Rows[i]["TONGTT"];
                //    row[Class.Format.NgayVNVN__(tNgay) + "TANGGIAM"] = tb2.Rows[i]["TANGGIAM"];
                //    try
                //    {
                //        _tongsl += double.Parse(tb2.Rows[i]["TONGTT"].ToString());
                //    }
                //    catch (Exception)
                //    {
                        
                //    }
                //}
                row["TONGSL"] = _tongsl;

                workTable.Rows.Add(row);
            }

            Session["DHNTM"] = workTable;
            Session["col"] = flag;
            Session["arrTitle"] = arrTitle;
        }

        //void PageLoad()
        //{
        //    string tn = "05/22/2018";
        //    string dn = "05/25/2018";
        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpSanLuongDHT.rdlc");
        //    DataTable dtTable = CSanLuong.getLuuLuongDHTM("", tn, dn).Tables["w_SanLuongTM"];

        //    ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
        //    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

        //    //  dtTable.DefaultView.Sort = "STT ASC";

        //    ReportDataSource rds = new ReportDataSource("w_SanLuongTM", dtTable);
        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    ReportViewer1.LocalReport.DataSources.Add(rds);
        //}
    
    }
}