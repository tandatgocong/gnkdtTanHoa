using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebHMI
{
    public partial class pUngVienDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            LoadUngVien();
        }
        public void LoadUngVien()
        {
            string value = Request.Params["ID"].ToString();
            string sql = "SELECT * FROM MTUngVien WHERE MTUVID='" + value + "'";
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                try
                {
                    if (dr["Hinh"].ToString() != "")
                    {
                        byte[] _byteArr = (byte[])dr["Hinh"];
                        string strBase64 = Convert.ToBase64String(_byteArr);
                        Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                    }
                }
                catch (Exception)
                {

                }
                this.HoTen.Text = dr["HoTen"] + "";
                
            }
        }
    }
}