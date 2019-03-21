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

namespace GiamNuocWeb
{
    public partial class pageDoBeBaoBe : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser)
        {
            if (Session["login"] == null)
            {
                Response.Redirect(@"pageLogin.aspx");
               
            }
            else if (!Session["role"].ToString().Equals(pUser))
            {
                Response.Redirect(@"zphanquyen.aspx");
            }
        }

        bool update;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBBaoBe.aspx";
             pagePhanQuyen("baobe");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
            LoadDiemBe("WHERE NOT Chuyen='True'");
            update=false;

        }
        public void LoadDiemBe(string dk)
        {
            GridView1.DataSource = Class.LinQConnection.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',CASE WHEN [Chuyen]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'Chuyen',* FROM w_BaoBe  " + dk);
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
                    cmd.CommandText = "select TenDuong from w_TenDuong where TenDuong like  N'%" + prefix + "%' group by TenDuong";
                    //cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["TenDuong"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

     public void pageLoad()
     {
         cbNhomDB.DataSource = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe' Order By IdNhom ASC ");
         cbNhomDB.DataTextField = "TenNhom";
         cbNhomDB.DataValueField = "IdNhom";
         cbNhomDB.DataBind();
     }

        protected void btBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"mBaoBe.aspx");
            Class.LinQConnection.ExecuteCommand_("DELETE FROM w_BaoBe WHERE ID='" + IDBB.Text + "'");

            RadioButtonList2_SelectedIndexChanged(sender, e);
            refesh();
        }

        string imgpath = "";

        public System.Drawing.Image ResizeByWidth(System.Drawing.Image img, int width)
        {
            // lấy chiều rộng và chiều cao ban đầu của ảnh
            int originalW = img.Width;
            int originalH = img.Height;

            // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh
            int resizedW = width;
            int resizedH = (originalH * resizedW) / originalW;

            // tạo một Bitmap có kích thước tương ứng với chiều rộng và chiều cao mới
            Bitmap bmp = new Bitmap(resizedW, resizedH);

            // tạo mới một đối tượng từ Bitmap
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)bmp);
            graphic.InterpolationMode = InterpolationMode.High;

            // vẽ lại ảnh với kích thước mới
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);

            // gải phóng resource cho đối tượng graphic
            graphic.Dispose();

            // trả về anh sau khi đã resize
            return (System.Drawing.Image)bmp;
        }

        public void UploadImg(w_BaoBe kt)
        {
            if (kt != null)
            {
                if (FileUpload1.HasFile)
                    try
                    {
                        string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("."));

                        string SaveLocation = Server.MapPath("~/HinhDiemBe/");

                       // System.IO.Directory.CreateDirectory(SaveLocation + @"/" + kt.ID);

                        SaveLocation = SaveLocation  + @"/" + fileName;

                        //FileUpload1.SaveAs(SaveLocation);
                        // upload.Visible = true;

                        imgpath = @"HinhDiemBe" + @"/" + fileName;

                        // this.imagePath.Value = this.imagePath.Value + imgpath + ",";
                        System.Drawing.Image imag = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        ResizeByWidth(imag, 500).Save(SaveLocation);
                        this.uploadfile.Text = "Upload Thành Công";
                        this.uploadfile.ForeColor = Color.Blue;
                        Class.LinQConnection.ExecuteCommand("UPDATE w_BaoBe SET HinhAnh='" + imgpath + "' WHERE ID='" + kt.ID + "'");


                    }
                    catch (Exception ex)
                    {
                        this.uploadfile.ForeColor = System.Drawing.Color.Red;
                        this.uploadfile.Text = "Lỗi Không Upload Về Server" + ex.ToString(); ;
                    }
            }
        }
       
        public void refesh()
        {
            update=false;
            IDBB.Text = "";
            this.btThen.Text="Thêm Mới";
            txtSoNha.Text = "";
            txtDuong.Text = "";
            cbKetCauLe.Text = "";
            cbKetCauDuong.Text = "";
            this.txtGhiChu.Text = "";
            this.imagePath.Value = "";
            this.btBack.Visible = false;
           
        }
        DMADataContext db ;
        w_BaoBe kt;
        protected void btThen_Click(object sender, EventArgs e)
        {
            if (IDBB.Text.Equals("") == true)
            {
                //// string sohoso = Class.C_TrungTamKhachHang.IdentityBienNhan();
                w_BaoBe kt = new w_BaoBe();

                kt.IdNhom = int.Parse(cbNhomDB.SelectedValue + "");
                kt.TenNhom = cbNhomDB.SelectedItem.Text;
                kt.TinhTrang = cbTinhTrang.SelectedValue + "";
                kt.SoNha = txtSoNha.Text;
                kt.TenDuong = txtDuong.Text;
                kt.KetCauLe = cbKetCauLe.Text;
                kt.KetCauDuong = cbKetCauDuong.Text;
                kt.Chuyen = false;
                kt.GhiChu = this.txtGhiChu.Text;
                kt.CreateDate = DateTime.Now;
                kt.CreateBy = Session["login"].ToString();
                if (this.imagePath.Value != "")
                    kt.HinhAnh = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);
                kt.NgayBao = DateTime.Now;
                kt.AutoDel = false;
                //  Response.Redirect(@"mBaoBe.aspx");
                if (Class.CBaoBe.InsertBaoBe(kt))
                {
                    lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                    this.lbThanhCong.Text = "Thêm mới điểm bể thành công.";

                    UploadImg(kt);
                    LoadDiemBe("WHERE NOT Chuyen='True'");
                    kt = null;
                    refesh();
                }
                else
                {
                    lbThanhCong.ForeColor = System.Drawing.Color.Red;
                    this.lbThanhCong.Text = "Thêm mới điểm bể thất bại.";
                }
            }
            else
            {

                db = new DMADataContext();
                var q = from p in db.w_BaoBes where p.ID == int.Parse(IDBB.Text) select p;
                kt = q.SingleOrDefault();

                kt.IdNhom = int.Parse(cbNhomDB.SelectedValue + "");
                kt.TenNhom = cbNhomDB.SelectedItem.Text;
                kt.TinhTrang = cbTinhTrang.SelectedValue + "";
                kt.SoNha = txtSoNha.Text;
                kt.TenDuong = txtDuong.Text;
                kt.KetCauLe = cbKetCauLe.Text;
                kt.KetCauDuong = cbKetCauDuong.Text;
                kt.Chuyen = false;
                kt.GhiChu = this.txtGhiChu.Text;
                if (this.imagePath.Value != "")
                    kt.HinhAnh = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);

                //  Response.Redirect(@"mBaoBe.aspx");
                db.SubmitChanges();

                lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                this.lbThanhCong.Text = "Cập Nhật điểm bể thành công.";
                
                if (this.imagePath.Value != "")
                    UploadImg(kt);


                RadioButtonList2_SelectedIndexChanged(sender, e);
                kt = null;
                refesh();


                refesh();
            }
        }
        string id;
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                pThemMoi.Visible = true;
                pChuyen.Visible = false;
                PTheoDoi.Visible = false;
 
            }
            else if (RadioButtonList1.Items[1].Selected) {
                pThemMoi.Visible = false;
                pChuyen.Visible = true;
                PTheoDoi.Visible = false;
            }
            else if (RadioButtonList1.Items[2].Selected) {
                pThemMoi.Visible = false;
                pChuyen.Visible = false;
                PTheoDoi.Visible = true;

            }


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btChuyenTT = (Button)e.Row.FindControl("btChuyenTT");
                Button btChuyenTB = (Button)e.Row.FindControl("btChuyenTB");
                if (btChuyenTT.Text == "ĐĐS")
                {
                    btChuyenTB.Visible = true;
                }

                try
                {
                    DateTime now = DateTime.Now;
                    DateTime t = DateTime.Parse(e.Row.Cells[7].Text);
                    System.TimeSpan d = now.Subtract(t);
                    double days = d.TotalDays;
                    if (days > 4)
                    {
                        e.Row.Cells[1].BackColor = Color.FromName("#FFFF00");
                        e.Row.Cells[2].BackColor = Color.FromName("#FFFF00");
                        e.Row.Cells[7].BackColor = Color.FromName("#FFFF00");
                    }
                }
                catch (Exception)
                {

                }



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
                Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET TinhTrang=CASE WHEN TinhTrang=N'ĐĐS' THEN N'KTB' ELSE N'ĐĐS' END,MofifyDate=GETDATE()  WHERE ID='" + id + "'");

                RadioButtonList2_SelectedIndexChanged(sender, e);
            }
            else if (e.CommandName == "chuyenTB")
            {
                string id = e.CommandArgument.ToString();
                Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET Chuyen=CASE WHEN Chuyen= 'true' THEN 'false' ELSE 'true' END, ChuyenNgay=GETDATE()    WHERE ID='" + id + "'");
                RadioButtonList2_SelectedIndexChanged(sender, e);
            }
            else if (e.CommandName == "updateeee")
            {
                db = new DMADataContext();
                var q = from p in db.w_BaoBes where p.ID == int.Parse(e.CommandArgument.ToString()) select p;
                kt = q.SingleOrDefault();
                IDBB.Text = e.CommandArgument.ToString();
                update = true;
                cbNhomDB.SelectedValue = kt.IdNhom.ToString();
                cbTinhTrang.SelectedValue = kt.TinhTrang;
                txtSoNha.Text = kt.SoNha;
                txtDuong.Text = kt.TenDuong;
                cbKetCauLe.SelectedValue = kt.KetCauLe;
                cbKetCauDuong.SelectedValue = kt.KetCauDuong;
                txtGhiChu.Text = kt.GhiChu;
                this.btThen.Text = "Cập Nhật";
                this.btBack.Visible = true;
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.Items[0].Selected)
            {
                //pThemMoi.Visible = true;
                //pChuyen.Visible = false;
                //PTheoDoi.Visible = false;
                LoadDiemBe("WHERE NOT Chuyen='True' ");
            }
            else if (RadioButtonList2.Items[1].Selected)
            {
                //pThemMoi.Visible = false;
                //pChuyen.Visible = true;
                //PTheoDoi.Visible = false;
                LoadDiemBe("WHERE NOT Chuyen='True' AND TinhTrang=N'ĐĐS' ");
            }
            else if (RadioButtonList2.Items[2].Selected)
            {
                //pThemMoi.Visible = false;
                //pChuyen.Visible = false;
                //PTheoDoi.Visible = true;
                LoadDiemBe("WHERE NOT Chuyen='True' AND TinhTrang=N'KTB' ");

            }


        }

    }
}