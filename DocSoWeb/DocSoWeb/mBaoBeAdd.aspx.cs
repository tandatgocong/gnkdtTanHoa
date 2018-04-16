using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMobile.Class;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using WebMobile.DataBase;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WebMobile
{
    public partial class mBaoBeAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "mBaoBe.aspx";
            if (Session["login"] == null)
            {
                Response.Redirect(@"LogIn.aspx");
            }
            else if (("TOCNTT".Contains(Session["phong"].ToString())))
            {

            }
            else if (!Session["phong"].ToString().Equals("GNKDT"))
            {
                Response.Redirect(@"zphanquyen.aspx");
            }

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
            //tungay.Text = Format.NgayVNVN(DateTime.Now.Date);
            //denngay.Text = Format.NgayVNVN(DateTime.Now.Date);
            //Panel2.Visible = false;
        }
        [WebMethod]
        public static string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["KTConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DUONG from TENDUONG where DUONG like @SearchText + '%' group by DUONG";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["DUONG"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }
        string lat = "";
        string lng = "";
        public void pageLoad()
        {

            if (Session["login"] == null)
            {
                Response.Redirect(@"Login.aspx");
            }
            if (Request.QueryString["lng"] != null)
            {

                txtLat.Value = Request.QueryString["lat"].ToString();
                txtLng.Value = Request.QueryString["lng"].ToString();

                cbPhuong.DataSource = Class.C_KyThuat.getDataTable("SELECT * FROM  QuanPhuong ");
                cbPhuong.DataTextField = "TenPhuong";
                cbPhuong.DataValueField = "MaPhuong";
                cbPhuong.DataBind();

                cbQuan.DataSource = Class.C_KyThuat.getDataTable("SELECT MaQuan,TenQuan FROM  QuanPhuong    GROUP BY MaQuan,TenQuan");
                cbQuan.DataTextField = "TenQuan";
                cbQuan.DataValueField = "MaQuan";
                cbQuan.DataBind();

                cbMaDMA.DataSource = Class.C_KyThuat.getDataTable("SELECT * FROM  THONGTINDMA ORDER BY MaDma");
                cbMaDMA.DataTextField = "MaDma";
                cbMaDMA.DataValueField = "MaDma";
                cbMaDMA.DataBind();

            }


            if (Request.QueryString["id"] != null)
            {
                Class.C_KyThuat.ExecuteCommand("DELETE KT_BaoBe WHERE ID='" + Request.QueryString["id"].ToString() + "' AND CreateBy='" + Session["login"].ToString() + "' ");
                Response.Redirect(@"mBaoBe.aspx");
            }

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"mBaoBe.aspx");
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

        public void UploadImg(KT_BaoBe kt)
        {
            if (kt != null)
            {
                if (FileUpload1.HasFile)
                    try
                    {
                        string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("."));

                        string SaveLocation = Server.MapPath("~/FileUpload/");

                        System.IO.Directory.CreateDirectory(SaveLocation + @"/" + kt.ID);

                        SaveLocation = SaveLocation + @"/" + kt.ID + @"/" + fileName;

                        //FileUpload1.SaveAs(SaveLocation);
                        // upload.Visible = true;

                        imgpath = @"/FileUpload" + @"/" + kt.ID + @"/" + fileName;

                       // this.imagePath.Value = this.imagePath.Value + imgpath + ",";
                        System.Drawing.Image imag = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        ResizeByWidth(imag, 500).Save(SaveLocation);
                        this.uploadfile.Text = "Upload Thành Công";
                        this.uploadfile.ForeColor = Color.Blue;
                        Class.C_KyThuat.ExecuteCommand("UPDATE KT_BaoBe SET Img='" + imgpath + "' WHERE ID='" + kt.ID + "'");


                    }
                    catch (Exception ex)
                    {
                        this.uploadfile.ForeColor = System.Drawing.Color.Red;
                        this.uploadfile.Text = "Lỗi Không Upload Về Server" + ex.ToString(); ;
                    }
            }
        }

        protected void btThen_Click(object sender, EventArgs e)
        {
            // string sohoso = Class.C_TrungTamKhachHang.IdentityBienNhan();
            KT_BaoBe kt = new KT_BaoBe();
         
            kt.SoHoSo = null;
            kt.TinhTrang = 1;
            kt.Lat = txtLat.Value;
            kt.Lng = txtLng.Value;
            kt.SoDT = txtSoDT.Text; ;
            kt.MaDMA = cbMaDMA.SelectedValue + "";
            kt.LoaiBao = cbLoaiBe.SelectedValue + "";
            kt.SoNha = txtSoNha.Text;
            kt.TenDuong = txtDuong.Text;
            kt.Phuong = cbPhuong.SelectedValue;
            kt.Quan = cbQuan.SelectedValue;
            kt.NgayBao = DateTime.Now;
            kt.GhiChu = this.txtGhiChu.Text;
            kt.CreateDate = DateTime.Now;
            kt.CreateBy = Session["login"].ToString();
            //if(this.imagePath.Value!="")
            //    kt.Img = this.imagePath.Value.Remove(imagePath.Value.Length - 1, 1);

            //  Response.Redirect(@"mBaoBe.aspx");
            if (Class.C_KyThuat.Insert(kt))
            {
                lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                this.lbThanhCong.Text = "Thêm mới điểm bể thành công.";

                UploadImg(kt);


            }
            else
            {
                lbThanhCong.ForeColor = System.Drawing.Color.Red;
                this.lbThanhCong.Text = "Thêm mới điểm bể thất bại.";
            }
        }
    }
}