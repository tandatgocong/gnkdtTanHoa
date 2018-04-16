using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMobile.DataBase;
using System.Security.Cryptography;
using System.Text;

namespace WebMobile
{
    public partial class Default1 : System.Web.UI.Page
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static dbKyThuatDataContext db = new dbKyThuatDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
        }
        
        private const string cryptoKey = "tanhoa";
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
            }

            return result;
        }
        public string Decrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {

            }

            return result;
        }
        public bool UserLogin(string userName, string passWord)
        {

            var data = from user in db.sys_Users where user.USERNAME == userName && user.PASSWORD == passWord  select user;
            sys_User userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                sys_User userlogin = (sys_User)data.SingleOrDefault();
                Session["login"] = userlogin.USERNAME;
                Session["phong"] = userlogin.MAPHONG;
                Session["cap"] = userlogin.CAP;
                return true;
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserLogin(this.txtusername.Text, Encrypt(this.txtpassword.Text)) == true)
            {
                if(Session["page"]==null)
                    Response.Redirect("mHome.aspx");
                else
                    Response.Redirect(Session["page"].ToString());
            }
            else
                this.mess.Visible = true;
        }
    }
}