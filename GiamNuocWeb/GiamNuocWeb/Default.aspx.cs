using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiamNuocWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            log4net.ILog logger = log4net.LogManager.GetLogger("File");

            Response.Redirect(@"Default.aspx");
        }
    }
}