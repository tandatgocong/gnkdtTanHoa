using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebHMI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            dropSearch.SelectedIndex = 3;
            //log4net.ILog logger = log4net.LogManager.GetLogger("File");

            //   logger.Info("Starting page load");

       //   pLoad();

         Response.Redirect(@"Home.aspx");
        }
        
        public void pLoad()
        {
            string sql = "SELECT TOP(200) MTUVID,Hinh, HoTen,gt.TenDM as GioiTinh, CONVERT(varchar(20), NgaySinh,103) as NgaySinh,ns.TenDM as NoiSinh, SoCMND,CONVERT(varchar(20), NgayCap,103) as NgayCap,nc.TenDM as NoiCap, HoChieu, CONVERT(varchar(20), HCNgay,103) as HCNgay,hc.TenDM as HCNoiCap,nq.TenDM as NguyenQuan, ";
            sql += " DiaChi, HKTT, DTDD, SDT, SDTNT, TTSK, SoThich, KyNang,TinhTrang ";
            sql += " FROM MTUngVien uv ";
            sql += " LEFT JOIN DMDanhMuc gt ON gt.MaDM=uv.GioiTinh  ";
            sql += " LEFT JOIN DMDanhMuc ns ON ns.MaDM=uv.NoiSinh ";
            sql += " LEFT JOIN DMDanhMuc nc ON nc.MaDM=uv.NoiCap ";
            sql += " LEFT JOIN DMDanhMuc nq ON nq.MaDM=uv.NguyenQuan ";
            sql += " LEFT JOIN DMDanhMuc hc ON hc.MaDM=uv.HCNoiCap ";
            if (dropSearch.SelectedIndex == 0) {
                { sql += " WHERE HoTen LIKE N'%"+this.txtSearch.Text+"%' "; }
            }
            else if (dropSearch.SelectedIndex == 1) { sql += " WHERE DiaChi LIKE N'%" + this.txtSearch.Text + "%' "; }
 
            else if (dropSearch.SelectedIndex == 2) { sql += " WHERE TinhTrang=N'Chưa phỏng vấn' "; }
            else if (dropSearch.SelectedIndex == 3) { sql += " WHERE TinhTrang=N'Đã xếp phỏng vấn' "; }
            else if (dropSearch.SelectedIndex == 4) { sql += " WHERE TinhTrang=N'Đã phỏng vấn' "; }
            else if (dropSearch.SelectedIndex == 5) { sql += " WHERE TinhTrang=N'Đậu phỏng vấn' "; }
            else if (dropSearch.SelectedIndex == 6) { sql += " WHERE TinhTrang=N'Đậu phỏng vấn' "; }
            else if (dropSearch.SelectedIndex == 7) { sql += " WHERE TinhTrang=N'Hủy' "; }
     //       <asp:ListItem Value="0">Tên Ứng Viên</asp:ListItem>
     //<asp:ListItem Value="1">Địa Chỉ</asp:ListItem>
 
     //<asp:ListItem Value="3">Chưa phỏng vấn</asp:ListItem>
     //<asp:ListItem Value="4">Đã xếp phỏng vấn</asp:ListItem>
     //<asp:ListItem Value="5">Đã phỏng vấn</asp:ListItem>
     //<asp:ListItem Value="6">Đậu phỏng vấn</asp:ListItem>
     //<asp:ListItem Value="7">Hủy</asp:ListItem>
         
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            GridView1.DataSource = tb;
            GridView1.DataBind();
            lbTong.Text = "Tổng Số : " + String.Format("{0:0,0}", tb.Rows.Count) + " ứng viên ";
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (dr["Hinh"].ToString()!="")
                {
                    byte[] _byteArr = (byte[])dr["Hinh"];
                    string strBase64 = Convert.ToBase64String(_byteArr);


                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();                    
                    img.ImageUrl = "data:Image/png;base64," + strBase64;

                    (e.Row.FindControl("Image1") as Image).ImageUrl = "data:Image/png;base64," + strBase64;

                }
                 
            }
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label lbTongSo = (Label)e.Row.FindControl("lbTongSo");
            //    lbTongSo.Text = "Tổng Số : " + String.Format("{0:0,0}", tongso) + " ứng viên ";

            //}  

            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewRow pagerRow = GridView1.BottomPagerRow;
                Label pageLabel = (Label)e.Row.FindControl("CurrentPageLabel");
                if (pageLabel != null)
                {
                    int currentPage = GridView1.PageIndex + 1;
                    pageLabel.Text = "" + currentPage.ToString() +
                      " of " + GridView1.PageCount.ToString();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;   //trang hien tai
                //int trang_thu = e.NewPageIndex;      //the hien trang thu may
                //int so_dong = GridView1.PageSize;       //moi trang co bao nhieu dong
                //stt = trang_thu * so_dong + 1;
                pLoad();
            }
            catch (Exception)
            {
                 
            }
            
        }

        protected void menuclick(object sender, MenuEventArgs e)
        {
            GridView1.PageIndex = Int32.Parse(e.Item.Value);
        }

        protected void dropSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if(e
        }

        protected void grvHocVan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}