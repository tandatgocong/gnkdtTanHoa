using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;
using Microsoft.Reporting.WebForms;

namespace GiamNuocWeb
{
    public partial class pageDBTheoDoi : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"pageLogin.aspx");

            }
            else if (Session["role"].ToString().Equals(pUser) == true || Session["role"].ToString().Equals("admin"))
            {

            }
            else
            {
                Response.Redirect(@"zphanquyen.aspx");
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBTheoDoi.aspx";
           // pagePhanQuyen("thongbao");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
            LoadDiemBe("");
            //RadioButtonList1_SelectedIndexChanged(sender, e);


        }

        public DataTable DataDiemBe(string dk)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',GhiChu  AS 'GhiChuu',CASE WHEN [InThongBao]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'InThongBao',* FROM w_BaoBe  WHERE InThongBao='True' AND ISNULL(TinhTrangSuaBe,0) IN(0,2) ";
            sql += "  " + dk;
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            return tb;
        }

        public void LoadDiemBe(string dk)
        {

            GridView1.DataSource = DataDiemBe("");
            GridView1.DataBind();

        }


        [WebMethod]
        public static string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["tanhoaConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select NguyenNhanBe from w_NguyenNhanBe where NguyenNhanBe like  N'%" + prefix + "%' group by NguyenNhanBe";
                    //cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["NguyenNhanBe"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        public void LoadPhuong(string sql)
        {
            cbPhuong.DataSource = Class.LinQConnection.getDataTable(sql);
            cbPhuong.DataTextField = "TenPhuong";
            cbPhuong.DataValueField = "MaPhuong";
            cbPhuong.DataBind();
        }
        public void pageLoad()
        {

            this.ngaysuaBe.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //this.dNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //this.tcTNgay.Text = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            //this.tcDNgay.Text = DateTime.Now.AddDays(9).ToString("yyyy-MM-dd");


            DataTable tb = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe'  AND Active='True' Order By IdNhom ASC ");
            cbNhomDB.DataSource = tb;
            cbNhomDB.DataTextField = "TenNhom";
            cbNhomDB.DataValueField = "IdNhom";
            cbNhomDB.DataBind();

            LoadPhuong("SELECT * FROM  w_Phuong ");

            cbQuan.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM  w_Quan");
            cbQuan.DataTextField = "TenQuan";
            cbQuan.DataValueField = "MaQuan";
            cbQuan.DataBind();

            cbOngBe.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM  w_ONG ORDER BY STT ASC");
            cbOngBe.DataTextField = "Name";
            cbOngBe.DataValueField = "ONG";
            cbOngBe.DataBind();



            // Xóa điểm KTB
            // Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET AutoDel='True'  WHERE TinhTrang=N'KTB' AND AutoDel='false'  AND DATEDIFF(DD,NgayBao,GETDATE())>8 ");
        }

        public void refesh()
        {
            IDBB.Text = "";
            txtSoNha.Text = "";
            txtDuong.Text = "";
            //cbKetCauLe.Text = "";
            //cbKetCauDuong.Text = "";
            this.txtGhiChu.Text = "";
            //  this.imagePath.Value = "";
        //    this.btBack.Visible = false;

        }
        DMADataContext db;
        w_BaoBe kt;
        protected void btThen_Click(object sender, EventArgs e)
        {
            if (IDBB.Text.Equals("") == false)
            {
                db = new DMADataContext();
                var q = from p in db.w_BaoBes where p.ID == int.Parse(IDBB.Text) select p;
                kt = q.SingleOrDefault();

                kt.TinhTrangSuaBe = int.Parse(cbKetQuaSua.SelectedValue+"");
                kt.NgaySua = DateTime.Parse(this.ngaysuaBe.Text);
                kt.GhiChuSuaBe = txtGhiChu.Text;
                kt.OngBe = cbOngBe.SelectedValue;
                kt.NguyenNhanBe = txtNguyenNhanBe.Text;
                db.SubmitChanges();

                lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                this.lbThanhCong.Text = "Cập Nhật điểm bể thành công.";
                
                kt = null;
                refesh();
                LoadDiemBe("");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btSuaBe = (Button)e.Row.FindControl("btChuyenTT");
                 

                Label idText = (Label)e.Row.FindControl("ID");

                if (btSuaBe.Text == "1") btSuaBe.Text = "Đã Sửa";
                else if (btSuaBe.Text == "2") { btSuaBe.Text = "Không Bể"; btSuaBe.BackColor = Color.Red; }
                else btSuaBe.Text = "Chưa Sửa";
               
                if (e.Row.Cells[6].Text == "False") e.Row.Cells[6].Text = "Bể ngầm";
                else e.Row.Cells[6].Text = "Bể nổi";
               
            }
            if (e.Row.RowType != DataControlRowType.Header)
            {
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "chuyenTT")
            {
                string id = e.CommandArgument.ToString();
                Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET TinhTrangSuaBe=CASE WHEN TinhTrangSuaBe=0 THEN 2 ELSE 0 END, NgaySua=GETDATE() WHERE ID='" + id + "'");
                LoadDiemBe("");
            }
            //else if (e.CommandName == "chuyenTB")
            //{
            //    string id = e.CommandArgument.ToString();
            //    Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET Chuyen=CASE WHEN Chuyen= 'true' THEN 'false' ELSE 'true' END, ChuyenNgay=GETDATE()    WHERE ID='" + id + "'");
            //    RadioButtonList2_SelectedIndexChanged(sender, e);
            //}

            if (e.CommandName == "updateeee")
            {
                db = new DMADataContext();
                var q = from p in db.w_BaoBes where p.ID == int.Parse(e.CommandArgument.ToString()) select p;
                kt = q.SingleOrDefault();
                IDBB.Text = e.CommandArgument.ToString();
                cbNhomDB.SelectedValue = kt.IdNhom.ToString();
                cbLoaiBe.SelectedValue = kt.LoaiBe.ToString();
                cbKetQuaSua.SelectedValue = "1";
                //cbTinhTrang.SelectedValue = kt.TinhTrang;
                txtSoNha.Text = kt.SoNha;
                txtDuong.Text = kt.TenDuong;
                //cbKetCauLe.SelectedValue = kt.KetCauLe;
                //cbKetCauDuong.SelectedValue = kt.KetCauDuong;
                txtGhiChu.Text = kt.GhiChuSuaBe;
                this.btThen.Text = "Cập Nhật";
               // this.btBack.Visible = true;
               // loadDMAByDuong();
            }
               
        }

        
    }
}