using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class pageDoBeTiepNhan : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser, string currenPage)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"pageLogin.aspx");
                Session["page"] = currenPage;
            }
            else if (!Session["role"].ToString().Equals(pUser))
            {
                Response.Redirect(@"zphanquyen.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           pagePhanQuyen("tiepnhan", "pageDoBeTiepNhan.aspx");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
        }
    }
}