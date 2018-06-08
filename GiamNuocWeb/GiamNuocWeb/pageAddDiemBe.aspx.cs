using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiamNuocWeb.Class;
using System.Configuration;
using System.Drawing;

namespace GiamNuocWeb
{
    public partial class pageAddDiemBe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            string lat = Request.QueryString["lat"];
            string lng = Request.QueryString["lng"];
            string madma = Request.QueryString["madma"];
            string loai = Request.QueryString["loai"];
            string ong = Request.QueryString["ong"];
            string sonha = Request.QueryString["sonha"];
            string duong = Request.QueryString["duong"];
            string ghichu = Request.QueryString["ghichu"];
            DateTime ngaydo = DateTime.Now.Date;
            string nhomdo = Session["manhom"] + "";

            //if ("01".Equals(loai))
            //{
            //    string sql = "UPDATE g_ThongTinDHT SET DHTLat='" + lat + "', DHTLng='" + lng + "' WHERE MaDMA='" + madma + "' ";
            //    LinQConnection.ExecuteCommand(sql);
            //}
            //else if ("02".Equals(loai))
            //{
            string sql = "INSERT INTO T_DiemBe (Nhom, NgayDo, NgaySua, SoNha, Duong, DMA, TinhTrang, LoaiDiemBe, OngBe, GhiChu, DinhMuc, BaoDienThoai, Status)";
            sql += " VALUES        ("+nhomdo+", #"+ngaydo.ToShortDateString()+"#, NULL, '"+sonha+"', '"+duong+"', "+madma+", 2, "+loai+", "+ong+", '"+ghichu+"', 1, 1, 1) ";
         
            string connectionString = ConfigurationManager.ConnectionStrings["Database1_beConnectionString"].ConnectionString;
           int resul= OledbConnection.ExecuteCommand(connectionString, sql);
            //}
            //string sql = "INSERT INTO g_LabelDMA VALUES ('" + madma + "','" + lat + "','" + lng + "') ";
            //    LinQConnection.ExecuteCommand(sql);

           if (resul>0)
           {
               lbThanhCong.ForeColor = Color.Blue;
               this.lbThanhCong.Text = "Cập Nhật Điểm Bể Thành Công.";
               Response.Redirect(@"pageDoBe.aspx");
           }
           else
           {
               lbThanhCong.ForeColor = Color.Red;
               this.lbThanhCong.Text = "Cập Nhật Điểm Bể Thất Bại.";
           }

           

        }
    }
}