using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHMI
{
    public partial class iisstart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");

            //   logger.Info("Starting page load");

            //   pLoad();

            Response.Redirect(@"Home.aspx");
        }
    }
}