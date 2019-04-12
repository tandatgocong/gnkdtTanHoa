using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace GiamNuocWeb
{
    public partial class pageDBTongKet : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"pageLogin.aspx");

            }
            //else if (!Session["role"].ToString().Equals(pUser))
            //{
            //    Response.Redirect(@"zphanquyen.aspx");
            //}
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBTongKet.aspx";
            pagePhanQuyen("baobe");           

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();

            if (Session["role"].ToString().Equals("dobe"))
            {
                cbNhomDB.SelectedValue = Session["manhom"] + "";
                cbNhomDB.Enabled = false;

            }
            LoadThongTin();
            
            
            //  LoadDiemBe("AND NOT Chuyen='True'");
        }

        public void pageLoad()
        {
            this.tNgay.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-21";
            this.dNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable tb = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe' Order By IdNhom ASC ");           
            cbNhomDB.DataSource = tb;
            cbNhomDB.DataTextField = "TenNhom";
            cbNhomDB.DataValueField = "IdNhom";
            cbNhomDB.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                if (e.Row.Cells[3].Text == "True") { e.Row.Cells[3].Text = "Nổi"; e.Row.Cells[3].BackColor = Color.Gainsboro; }
                else e.Row.Cells[3].Text = "Ngầm";

                if (e.Row.Cells[4].Text == "KTB") { e.Row.Cells[4].BackColor = Color.YellowGreen; }

                if (e.Row.Cells[5].Text == "True") { e.Row.Cells[5].Text = "x"; e.Row.Cells[5].BackColor = Color.Wheat; }
                else e.Row.Cells[5].Text = "";

                if (e.Row.Cells[6].Text == "True") { e.Row.Cells[6].Text = "x"; }
                else e.Row.Cells[6].Text = "";

                if (e.Row.Cells[7].Text == "True") { e.Row.Cells[7].Text = "x"; }
                else e.Row.Cells[7].Text = "";

                if (e.Row.Cells[8].Text == "1") { e.Row.Cells[8].Text = "Đã sửa"; }
                else if (e.Row.Cells[8].Text == "2") { e.Row.Cells[8].Text = "Không bể"; e.Row.Cells[8].BackColor = Color.Red; }
                else { e.Row.Cells[8].Text = "Chưa sửa"; e.Row.Cells[8].BackColor = Color.Cyan; }

            }
            if (e.Row.RowType != DataControlRowType.Header)
            {
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        public void LoadThongTin()
        {
            string sqlDiemBe = " SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',* FROM w_BaoBe ";


            string sqlSum = " select COUNT(*) as 'TS', COUNT(CASE WHEN LoaiBe='True' THEN 1 ELSE null END) AS BNOI, COUNT(CASE WHEN LoaiBe='False' THEN 1 ELSE null END) AS BNGAM ";
            sqlSum += " , COUNT(CASE WHEN LoaiBe='False' AND TinhTrangSuaBe=1 THEN 1 ELSE null END) AS DASUA ";
            sqlSum += " , COUNT(CASE WHEN LoaiBe='False' AND ISNULL(TinhTrangSuaBe,0)=0 THEN 1 ELSE null END) AS CSUA  ";
            sqlSum += " , COUNT(CASE WHEN LoaiBe='False' AND TinhTrangSuaBe=2 THEN 1 ELSE null END) AS KBE  ";
            sqlSum += " from dbo.w_BaoBe  ";

            string dk = " WHERE convert(datetime,CAST(ChuyenNgay AS DATE) ,101) BETWEEN CONVERT(datetime,'" + tNgay.Text + "',101) AND CONVERT(datetime,'" + dNgay.Text + "',101)  ";
            dk += " AND IdNhom=" + cbNhomDB.SelectedValue;

            GridView1.DataSource = Class.LinQConnection.getDataTable(sqlDiemBe+dk);
            GridView1.DataBind();

            DataTable tb = Class.LinQConnection.getDataTable(sqlSum + dk);
            if (tb.Rows.Count > 0)
            {
                tc_tongdiem.Text = tb.Rows[0]["TS"].ToString();
                tc_benoi.Text = tb.Rows[0]["BNOI"].ToString();
                tc_bengam.Text = tb.Rows[0]["BNGAM"].ToString();
                tc_diemsua.Text = tb.Rows[0]["DASUA"].ToString();
                tc_chuasua.Text = tb.Rows[0]["CSUA"].ToString();
                tc_khongbe.Text = tb.Rows[0]["KBE"].ToString();
            }
        }

        protected void btThen_Click(object sender, EventArgs e)
        {
            LoadThongTin();
        }

    }
}
