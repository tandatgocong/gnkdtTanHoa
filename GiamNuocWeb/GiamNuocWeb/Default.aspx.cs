using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace GiamNuocWeb
{
    public partial class Default : System.Web.UI.Page
    {
      //  private static readonly ILog log = LogManager.GetLogger(typeof(Default).Name);
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            Response.Redirect("Home.aspx");

      //      log.Error("dsfdsafds");
        }
    }
}