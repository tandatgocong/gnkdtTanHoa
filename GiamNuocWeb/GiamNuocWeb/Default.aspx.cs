using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Microsoft.Reporting.WebForms;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class Default : System.Web.UI.Page
    {
      //  private static readonly ILog log = LogManager.GetLogger(typeof(Default).Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
           Response.Redirect("Home.aspx");

            //if (!IsPostBack)
            //{
            //    //set Processing Mode of Report as Local  
            //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //    //set path of the Local report  
            // //   ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
            //    //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter  
                
            //    //Providing DataSource for the Report  
            //    ReportParameter p1 = new ReportParameter("tuNgay", " 23/07/2018 ĐẾN 25/88/2018");
            //    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

            //    ReportDataSource rds = new ReportDataSource("dsDma", CSanLuong.getSanLuong("", "", "").Tables["g_SanLuongDHT"]);
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    //Add ReportDataSource  
            //    ReportViewer1.LocalReport.DataSources.Add(rds);

            //}  


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}