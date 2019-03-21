using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiamNuocWeb.Class
{
    public class zPhanQuyen : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser,string currenPage)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"LogIn.aspx");
                Session["page"] = currenPage;
            }
            else if (!Session["user"].ToString().Equals(pUser))
            {
                Response.Redirect(@"zphanquyen.aspx"); 
            }
        }

        //public void pagePhanQuyen(string pUser)
        //{
        //    if (Session["login"] == null)
        //    {
        //        Response.Redirect(@"pageLogin.aspx");

        //    }
        //    else if (!Session["role"].ToString().Equals(pUser))
        //    {
        //        Response.Redirect(@"zphanquyen.aspx");
        //    }
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    Session["page"] = "pageDoBeBaoBe.aspx";
        //    pagePhanQuyen("baobe");
        //    MaintainScrollPositionOnPostBack = true;
        //    if (IsPostBack)
        //        return;
        //}


    }
}