using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace GiamNuocWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sql = "SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',[TinhTrang],* FROM [tanhoa].[dbo].[w_BaoBe] ";
            //GridView1.DataSource = Class.LinQConnection.getDataTable(sql);
            //GridView1.DataBind();
            //LoadThongTin();
        }


    }
}