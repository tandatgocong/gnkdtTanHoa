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

 
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBBaoBe.aspx";
             pagePhanQuyen("baobe");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
            LoadDiemBe("AND NOT Chuyen='True'");
           

        }
        public DataTable DataDiemBe(string dk)
        {
            DataTable tb = Class.LinQConnection.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',GhiChu  AS 'GhiChuu',CASE WHEN [Chuyen]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'Chuyen',* FROM w_BaoBe  WHERE DATEDIFF(dd, NgayBao,getdate())<=7 AND AutoDel='false' " + dk);
            return tb;
        }

        public void LoadDiemBe(string dk)
        {
            GridView1.DataSource = DataDiemBe(dk);
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
                    cmd.CommandText = "SELECT TenDuong  FROM w_TenDuongDB where TenDuong like  N'%" + prefix + "%' group by TenDuong";
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
         this.tNgay.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM") + "-21";
         this.dNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");

         DataTable tb = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe' Order By IdNhom ASC ");

         cbNhomDB.DataSource = tb;
         cbNhomDB.DataTextField = "TenNhom";
         cbNhomDB.DataValueField = "IdNhom";
         cbNhomDB.DataBind();

         DataRow ro= tb.NewRow();
         ro["IdNhom"] = "0";
         ro["TenNhom"] = "Tất Cả";
         tb.Rows.Add(ro);

         tdNhomDB.DataSource = tb;
         tdNhomDB.DataTextField = "TenNhom";
         tdNhomDB.DataValueField = "IdNhom";
         tdNhomDB.DataBind();

         

         // Xóa điểm KTB
         Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET AutoDel='True'  WHERE TinhTrang=N'KTB' AND AutoDel='false'  AND DATEDIFF(DD,NgayBao,GETDATE())>8 ");
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
                if (!"".Equals(txtSoNha.Text))
                {
                    DataTable tb = DataDiemBe(" AND AutoDel='True' AND replace((SoNha+TenDuong),' ','') LIKE replace(N'%" + txtSoNha.Text + txtDuong.Text + "%',' ','')");
                    if (tb.Rows.Count <= 0)
                    {
                        w_BaoBe kt = new w_BaoBe();
                        kt.IdNhom = int.Parse(cbNhomDB.SelectedValue + "");
                        kt.LoaiBe = bool.Parse(cbLoaiBe.SelectedValue);
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
                            LoadDiemBe("AND NOT Chuyen='True'");
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
                        txtSoNha.Text = txtSoNha.Text + "(1)";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Trùng Điểm Bể Đã Báo ! Báo Tiếp Tục không ?')", true);
                        GridView1.DataSource = tb;
                        GridView1.DataBind();
                    }

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
                kt.LoaiBe = bool.Parse(cbLoaiBe.SelectedValue);
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
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                pThemMoi.Visible = true;
                PTheoDoi.Visible = false;
            }
            else if (RadioButtonList1.Items[1].Selected) {
                pThemMoi.Visible = false;
                PTheoDoi.Visible = true;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btChuyenTT = (Button)e.Row.FindControl("btChuyenTT");
                Button btChuyenTB = (Button)e.Row.FindControl("btChuyenTB");
                Label idText = (Label)e.Row.FindControl("ID");

                if (e.Row.Cells[4].Text == "False")  e.Row.Cells[4].Text = "Bể ngầm";
                else e.Row.Cells[4].Text = "Bể nổi";

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
                    if (days > 3)
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
             
                cbNhomDB.SelectedValue = kt.IdNhom.ToString();
                cbLoaiBe.SelectedValue = kt.LoaiBe.ToString();
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
                LoadDiemBe("AND NOT Chuyen='True' ");
            }
            else if (RadioButtonList2.Items[1].Selected)
            {
                //pThemMoi.Visible = false;
                //pChuyen.Visible = true;
                //PTheoDoi.Visible = false;
                LoadDiemBe("AND NOT Chuyen='True' AND TinhTrang=N'ĐĐS' ");
            }
            else if (RadioButtonList2.Items[2].Selected)
            {
                //pThemMoi.Visible = false;
                //pChuyen.Visible = false;
                //PTheoDoi.Visible = true;
                LoadDiemBe("AND NOT Chuyen='True' AND TinhTrang=N'KTB' ");

            }


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            RadioButtonList2.SelectedIndex = 0;
            DataTable tb = Class.LinQConnection.getDataTable("SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',CASE WHEN [AutoDel]='True' THEN GhiChu+N' [KTB tự động xóa]' ELSE GhiChu END AS 'GhiChuu',CASE WHEN [Chuyen]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'Chuyen',* FROM w_BaoBe  WHERE replace((SoNha+TenDuong),' ','') LIKE replace(N'%" + txtSearch.Text + "%',' ','')");
            GridView1.DataSource = tb;
            GridView1.DataBind();
         

         
        }
        protected void THeoDoiDemB_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',GhiChu  AS 'GhiChuu',CASE WHEN [Chuyen]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'Chuyen',* FROM w_BaoBe ";
            sql += " WHERE convert(datetime,NgayBao,101) BETWEEN CONVERT(datetime,'" + tNgay.Text + "',101) AND CONVERT(datetime,'" + dNgay.Text + "',101) ";
          
            if (tdNhomDB.SelectedValue != "0") sql += " AND IdNhom='" + tdNhomDB.SelectedValue + "' ";
            if(tdTinhTrang.SelectedValue=="") sql += " ";
            else if (tdTinhTrang.SelectedValue == "1") sql += " AND TinhTrang=N'ĐĐS' ";
            else if (tdTinhTrang.SelectedValue == "2") sql += " AND TinhTrang=N'KTB' ";
            else if (tdTinhTrang.SelectedValue == "3") sql += " AND AutoDel='True' ";
            else if (tdTinhTrang.SelectedValue == "4") sql += " AND LoaiBe='False' ";
            else if (tdTinhTrang.SelectedValue == "5") sql += " AND LoaiBe='True' ";

            DataTable tb = Class.LinQConnection.getDataTable(sql);
            GridView2.DataSource = tb;
            GridView2.DataBind();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label btXoa= (Label)e.Row.FindControl("AutoDel");
                Label idText = (Label)e.Row.FindControl("ID");

                if (e.Row.Cells[3].Text == "False") e.Row.Cells[3].Text = "Bể ngầm";
                else e.Row.Cells[3].Text = "Bể nổi";

                if (btXoa.Text == "True")
                {
                    btXoa.Text = "Đã xóa";
                    e.Row.Cells[10].BackColor = Color.FromName("#FFFF00");
                }else
                    btXoa.Text = "";


                Label lbChuyenTBB = (Label)e.Row.FindControl("lbChuyenTBB");
                if (lbChuyenTBB.Text == "Chưa")
                {
                    e.Row.Cells[8].BackColor = Color.FromName("#999933");
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

    }
}