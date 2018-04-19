using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.DataBase;
using GiamNuocWeb.Class;

namespace GiamNuocWeb
{
    public partial class SanLuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            getLoadDMA();
        }
        public void getLoadDMA()
        {
            List<g_ThongTinDHT> ls = CThongTinDMA.getDMAHoatDong();
            foreach (var item in ls)
            {
                 DropDownDMA.Items.Add(item.MaDMA);                
            }
        }
    }
}