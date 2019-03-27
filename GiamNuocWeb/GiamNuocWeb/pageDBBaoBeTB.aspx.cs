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
    public partial class pageDBBaoBeTB : System.Web.UI.Page
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
            Session["page"] = "pageDBBaoBeTB.aspx";
            pagePhanQuyen("thongbao");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
            LoadDiemBe("AND NOT Chuyen='True'");
            RadioButtonList1_SelectedIndexChanged(sender, e);


        }
        public DataTable DataDiemBe(string dk)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],[SoNha] + ' '+  [TenDuong]  AS 'DiaChi',GhiChu  AS 'GhiChuu',CASE WHEN [InThongBao]='True' THEN N'Rồi' ELSE N'Chưa' END AS 'InThongBao',* FROM w_BaoBe  WHERE Chuyen='True' AND AutoDel='false' ";
            sql += " AND convert(datetime,CAST(ChuyenNgay AS DATE) ,101) BETWEEN CONVERT(datetime,'" + tNgay.Text + "',101) AND CONVERT(datetime,'" + dNgay.Text + "',101)  " + dk;
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            return tb;
        }

        public void LoadDiemBe(string dk)
        {

            GridView1.DataSource = DataDiemBe("");
            GridView1.DataBind();

            GridView2.DataSource = DataDiemBe("");
            GridView2.DataBind();
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

        public void LoadPhuong(string sql)
        {
            cbPhuong.DataSource = Class.LinQConnection.getDataTable(sql);
            cbPhuong.DataTextField = "TenPhuong";
            cbPhuong.DataValueField = "MaPhuong";
            cbPhuong.DataBind();
        }
        public void pageLoad()
        {

            this.tNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.dNgay.Text = DateTime.Now.ToString("yyyy-MM-dd");

            this.tcTNgay.Text = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            this.tcDNgay.Text = DateTime.Now.AddDays(9).ToString("yyyy-MM-dd");


            DataTable tb = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe' Order By IdNhom ASC ");
            cbNhomDB.DataSource = tb;
            cbNhomDB.DataTextField = "TenNhom";
            cbNhomDB.DataValueField = "IdNhom";
            cbNhomDB.DataBind();

            LoadPhuong("SELECT * FROM  w_Phuong ");

            cbQuan.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM  w_Quan");
            cbQuan.DataTextField = "TenQuan";
            cbQuan.DataValueField = "MaQuan";
            cbQuan.DataBind();

            inQuan.DataSource = Class.LinQConnection.getDataTable("SELECT * FROM  w_Quan");
            inQuan.DataTextField = "TenQuan";
            inQuan.DataValueField = "MaQuan";
            inQuan.DataBind();



            // Xóa điểm KTB
            // Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET AutoDel='True'  WHERE TinhTrang=N'KTB' AND AutoDel='false'  AND DATEDIFF(DD,NgayBao,GETDATE())>8 ");
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"mBaoBe.aspx");
            Class.LinQConnection.ExecuteCommand_("DELETE FROM w_BaoBe WHERE ID='" + IDBB.Text + "'");

            //RadioButtonList2_SelectedIndexChanged(sender, e);
            refesh();
        }

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
            //if (kt != null)
            //{
            //    if (FileUpload1.HasFile)
            //        try
            //        {
            //            string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("."));

            //            string SaveLocation = Server.MapPath("~/HinhDiemBe/");

            //           // System.IO.Directory.CreateDirectory(SaveLocation + @"/" + kt.ID);

            //            SaveLocation = SaveLocation  + @"/" + fileName;

            //            //FileUpload1.SaveAs(SaveLocation);
            //            // upload.Visible = true;

            //            imgpath = @"HinhDiemBe" + @"/" + fileName;

            //            // this.imagePath.Value = this.imagePath.Value + imgpath + ",";
            //            System.Drawing.Image imag = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
            //            ResizeByWidth(imag, 500).Save(SaveLocation);
            //            this.uploadfile.Text = "Upload Thành Công";
            //            this.uploadfile.ForeColor = Color.Blue;
            //            Class.LinQConnection.ExecuteCommand("UPDATE w_BaoBe SET HinhAnh='" + imgpath + "' WHERE ID='" + kt.ID + "'");


            //        }
            //        catch (Exception ex)
            //        {
            //            this.uploadfile.ForeColor = System.Drawing.Color.Red;
            //            this.uploadfile.Text = "Lỗi Không Upload Về Server" + ex.ToString(); ;
            //        }
            //}
        }

        public void refesh()
        {
            IDBB.Text = "";
            txtSoNha.Text = "";
            txtDuong.Text = "";
            cbKetCauLe.Text = "";
            cbKetCauDuong.Text = "";
            this.txtGhiChu.Text = "";
            //  this.imagePath.Value = "";
            this.btBack.Visible = false;

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

                kt.IdNhom = int.Parse(cbNhomDB.SelectedValue + "");
                kt.TenNhom = cbNhomDB.SelectedItem.Text;
                kt.TinhTrang = cbTinhTrang.SelectedValue + "";
                kt.LoaiBe = bool.Parse(cbLoaiBe.SelectedValue);
                kt.SoNha = txtSoNha.Text;
                kt.TenDuong = txtDuong.Text;
                kt.KetCauLe = cbKetCauLe.Text;
                kt.KetCauDuong = cbKetCauDuong.Text;
                kt.GhiChu = this.txtGhiChu.Text;
                kt.MaDMA = cbMaDMA.SelectedValue.ToString();

                int maquan = int.Parse(cbQuan.SelectedItem.Value);
                kt.MaQuan = maquan;
                kt.TenQuan = CThongTinDMA.getQuan(maquan).TenQuan;
                string maphuong = cbPhuong.SelectedItem.Value;
                kt.MaPhuong = maphuong;
                kt.TenPhuong = CThongTinDMA.getPhuong(maquan, maphuong).TenPhuong;

                kt.PhuiLe = lePhui.Text;
                kt.PhuiDuong = duongPhui.Text;
                //if (this.imagePath.Value != "")
                //    kt.HinhAnh = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);

                //  Response.Redirect(@"mBaoBe.aspx");
                db.SubmitChanges();

                lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                this.lbThanhCong.Text = "Cập Nhật điểm bể thành công.";

                //if (this.imagePath.Value != "")
                //    UploadImg(kt);


                //RadioButtonList2_SelectedIndexChanged(sender, e);
                kt = null;
                refesh();
                LoadDiemBe("AND NOT Chuyen='True'");
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[0].Selected)
            {
                pThemMoi.Visible = true;
                PTheoDoi.Visible = false;
            }
            else if (RadioButtonList1.Items[1].Selected)
            {
                pThemMoi.Visible = false;
                PTheoDoi.Visible = true;
                inQuan_SelectedIndexChanged(sender, e);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btChuyenTB = (Button)e.Row.FindControl("btChuyenTB");
                if (btChuyenTB.Text=="Chưa")
                    btChuyenTB.Visible = false;

                Label idText = (Label)e.Row.FindControl("ID");

                if (e.Row.Cells[7].Text == "False") e.Row.Cells[7].Text = "Bể ngầm";
                else e.Row.Cells[7].Text = "Bể nổi";
            }
            if (e.Row.RowType != DataControlRowType.Header)
            {
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
        void loadDMAByDuong()
        {
            cbMaDMA.DataSource = Class.LinQConnection.getDataTable("SELECT MaDMA FROM  w_TenDuongDB Where replace((TenDuong),' ','') LIKE replace(N'%" + txtDuong.Text + "%',' ','') GROUP BY MaDMA ORDER BY MaDMA ASC ");
            cbMaDMA.DataTextField = "MaDma";
            cbMaDMA.DataValueField = "MaDma";
            cbMaDMA.DataBind();
        }
        public string getTenKetCau(string kc)
        {
            string result = "";

            switch (kc)
            {
                case "BTXM": result = "BTXM"; break;
                case "GACH": result = "Gạch"; break;
                case "DA": result = "Đá Hoa Cương"; break;
                case "NHUA": result = "Nhựa"; break;
                case "DAT": result = "Đất"; break;
                default:
                    result = "";
                    break;
            }


            return result;

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "updateeee")
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
                loadDMAByDuong();

                if (!" ".Equals(kt.KetCauLe.ToString()) && " ".Equals(kt.KetCauDuong.ToString()))
                {
                    lePhui.Text = "0,5x0,8+3,0x0,3m " + getTenKetCau(kt.KetCauLe) + "(phui=1,1m)";
                }
                else if (!" ".Equals(kt.KetCauLe.ToString()) && " ".Equals(kt.KetCauDuong.ToString()))
                {
                    duongPhui.Text = "0,5x0,8+6,0x0,3m " + getTenKetCau(kt.KetCauDuong) + "(phui=1,1m)";
                }
                else
                {
                    lePhui.Text = "3,0x0,3m " + getTenKetCau(kt.KetCauLe);
                    duongPhui.Text = "0,5x0,8+6,0x0,3m " + getTenKetCau(kt.KetCauDuong) + "(phui=1,1m)";
                }


                cbMaDMA_SelectedIndexChanged(sender, e);

            }
            else if (e.CommandName == "chuyenTB")
            {
                string id = e.CommandArgument.ToString();
                Class.LinQConnection.ExecuteCommand_("UPDATE w_BaoBe SET InThongBao=null,NgayIn=null WHERE ID='" + id + "'");
                inQuan_SelectedIndexChanged(sender, e);
            }
        }

        //protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RadioButtonList2.Items[0].Selected)
        //    {
        //        //pThemMoi.Visible = true;
        //        //pChuyen.Visible = false;
        //        //PTheoDoi.Visible = false;
        //        LoadDiemBe("AND NOT Chuyen='True' ");
        //    }
        //    else if (RadioButtonList2.Items[1].Selected)
        //    {
        //        //pThemMoi.Visible = false;
        //        //pChuyen.Visible = true;
        //        //PTheoDoi.Visible = false;
        //        LoadDiemBe("AND NOT Chuyen='True' AND TinhTrang=N'ĐĐS' ");
        //    }
        //    else if (RadioButtonList2.Items[2].Selected)
        //    {
        //        //pThemMoi.Visible = false;
        //        //pChuyen.Visible = false;
        //        //PTheoDoi.Visible = true;
        //        LoadDiemBe("AND NOT Chuyen='True' AND TinhTrang=N'KTB' ");

        //    }


        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            LoadDiemBe("AND NOT Chuyen='True'");
        }



        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

            if (e.Row.RowType != DataControlRowType.Header)
            {
                if (e.Row.Cells[8].Text == "False") e.Row.Cells[8].Text = "Bể ngầm";
                else e.Row.Cells[8].Text = "Bể nổi";
                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void cbMaDMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT MaPhuong,MaQuan FROM g_LabelDMA WHERE MaDMA='" + cbMaDMA.SelectedValue + "'";
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                string mquan = tb.Rows[0]["MaQuan"].ToString();
                cbQuan.SelectedValue = mquan;

                LoadPhuong("SELECT * FROM  w_Phuong WHERE MaQuan='" + mquan + "' ");

                string mphuong = tb.Rows[0]["MaPhuong"].ToString();
                cbPhuong.SelectedValue = mphuong;
            }
        }

        protected void inQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.DataSource = DataDiemBe("AND InThongBao is null AND MaQuan='" + inQuan.SelectedValue + "'");
            GridView2.DataBind();
        }

        protected void THeoDoiDemB_Click(object sender, EventArgs e)
        {
            
            string listID = "";
            foreach (GridViewRow row in GridView2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    //CheckBox chkRow = (row.Cells[0].FindControl("checkChon") as CheckBox);
                    //if (chkRow.Checked)
                    //{
                        Label lbID = (row.Cells[1].FindControl("lbID") as Label);
                        listID += ("'" + lbID.Text + "',");
                    //}
                }
            }
            listID = listID.Remove(listID.Length - 1, 1);

            string sql = "UPDATE w_BaoBe SET InThongBao='True',NgayIn=GETDATE(),ThiCongTN='"+tcTNgay.Text+"',ThiCongDN='"+tcDNgay.Text+"'  WHERE  ID IN ("+listID+")  ";
            Class.LinQConnection.ExecuteCommand_(sql);




        }
    }
}