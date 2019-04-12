using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;

namespace GiamNuocWeb
{
    public partial class pageLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private const string cryptoKey = "tanhoa";
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

      
      
        public bool UserLogin(string userName, string passWord)
        {
            DMADataContext db = new DMADataContext();
            var data = from user in db.t_Users where user.Username == userName && user.Password == passWord && user.Active==true select user;
            t_User userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
               
                Session["login"] = userLogin.Username;
                Session["manhom"] = userLogin.IdNhom;
                Session["tennhom"] = "NHÓM "+userLogin.Email;
                Session["role"] = userLogin.Role;
                Session["ten"] = userLogin.TenNhom;

               
                return true;
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserLogin(this.txtusername.Text, this.txtpassword.Text) == true)
            {
                if (Session["page"] == null)
                    Response.Redirect("Home.aspx");
                else
                    Response.Redirect(Session["page"].ToString());
            }
            else
                this.mess.Visible = true;
        }
    }
}