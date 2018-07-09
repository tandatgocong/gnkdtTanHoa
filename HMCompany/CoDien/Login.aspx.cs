using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MapGoogle.Databases;
using System.Security.Cryptography;
using System.Text;

namespace MapGoogle
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private const string cryptoKey = "tanhoa";
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
      
        public  string Encrypt(string s)
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
            MapDemoDataContext db = new MapDemoDataContext();
            var data = from user in db.USERs where user.USERNAME == userName && user.PASSWORD == passWord && user.ENABLED == true select user;
            USER userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                USER userlogin = (USER)data.SingleOrDefault();
                Session["login"] = userlogin.USERNAME;
                return true;
            }
            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserLogin(this.txtusername.Text, Encrypt(this.txtpassword.Text)) == true)
                Response.Redirect("Default.aspx");
            else
                this.mess.Visible = true;
        }
    }
}