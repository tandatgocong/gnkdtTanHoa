using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebHMI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");

            logger.Info("Starting page load");
            //DataTable tb = Class.LinQConnection.getDataTable("SELECT * FROM MTUngVien");
            //GridView1.DataSource = tb;
            //GridView1.DataBind();
           
          
             Response.Redirect(@"Home.aspx");
        }
    }
}