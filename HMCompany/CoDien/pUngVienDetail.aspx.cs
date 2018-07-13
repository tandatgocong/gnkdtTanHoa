using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebHMI
{
    public partial class pUngVienDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pageLoad();
           LoadUngVien();
        }
        void pageLoad()
        {
            gioitinhh.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='GIOITINH' ");
            gioitinhh.DataValueField = "MaDM";
            gioitinhh.DataTextField = "TenDM";
            gioitinhh.DataBind();
            drNoiSinh.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='THANHPHO' ");
            drNoiSinh.DataValueField = "MaDM";
            drNoiSinh.DataTextField = "TenDM";
            drNoiSinh.DataBind();

            drNguyenQuan.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='THANHPHO' ");
            drNguyenQuan.DataValueField = "MaDM";
            drNguyenQuan.DataTextField = "TenDM";
            drNguyenQuan.DataBind();

            cmndNoiCap.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='THANHPHO' ");
            cmndNoiCap.DataValueField = "MaDM";
            cmndNoiCap.DataTextField = "TenDM";
            cmndNoiCap.DataBind();

            hcNoiCapp.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='THANHPHO' ");
            hcNoiCapp.DataValueField = "MaDM";
            hcNoiCapp.DataTextField = "TenDM";
            hcNoiCapp.DataBind();

            honnhann.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='HONNHAN' ");
            honnhann.DataValueField = "MaDM";
            honnhann.DataTextField = "TenDM";
            honnhann.DataBind();

            taythuan.DataSource = Class.LinQConnection.getDataTable("SELECT [MaDM] ,[TenDM] FROM DMDanhMuc WHERE NhomDM='TAYTHUAN' ");
            taythuan.DataValueField = "MaDM";
            taythuan.DataTextField = "TenDM";
            taythuan.DataBind();
        }
        public void LoadUngVien()
        {
            string value = Request.Params["ID"].ToString();
            string sql = "SELECT * FROM MTUngVien WHERE MTUVID='" + value + "'";
            DataTable tb = Class.LinQConnection.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                try
                {
                    if (dr["Hinh"].ToString() != "")
                    {
                        byte[] _byteArr = (byte[])dr["Hinh"];
                        string strBase64 = Convert.ToBase64String(_byteArr);
                        Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                    }
                }
                catch (Exception)
                {

                }
                this.HoTen.Text = dr["HoTen"] + "";
                this.NgaySinh.Text = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("yyyy-MM-dd");
                this.gioitinhh.SelectedValue = dr["GioiTinh"] + "";
                this.drNoiSinh.SelectedValue = dr["NoiSinh"] + "";
                this.drNguyenQuan.SelectedValue = dr["NguyenQuan"] + "";
                this.ChoOht.Text = dr["DiaChi"] + "";
                DienThoai.Text = dr["SDT"] + "";
                DiDong.Text = dr["DTDD"] + "";
                CMND.Text = dr["SoCMND"] + "";
                this.cmndNgayCap.Text = DateTime.Parse(dr["NgayCap"].ToString()).ToString("yyyy-MM-dd");
                this.cmndNoiCap.SelectedValue = dr["NoiCap"] + "";

                if (!"".Equals(dr["HoChieu"] + ""))
                {
                    try
                    {
                        hcSo.Text = dr["HoChieu"] + "";
                        this.hcNgayCap.Text = DateTime.Parse(dr["HCNgay"].ToString()).ToString("yyyy-MM-dd");
                        this.hcNoiCapp.SelectedValue = dr["HCNoiCap"] + "";
                    }
                    catch (Exception)
                    {

                    }

                }

                this.hkThuongTru.Text = dr["HKTT"] + "";
               // this.hkTamTru.Text = dr["DiaChi"] + "";
                this.dtNguoiThan.Text = dr["SDTNT"] + "";
                this.honnhann.SelectedValue = dr["TTHN"] + "";
                this.sothich.Text = dr["SoThich"] + "";
                this.kynang.Text = dr["KyNang"] + "";
                this.nganhnghe.Text = dr["NganhNghe"] + "";
                this.drTinhTrang.SelectedValue = dr["TinhTrang"] + "";
                this.chieucao.Text = string.Format("{0:0}", dr["ChieuCao"]);
                this.cannang.Text = string.Format("{0:0}", dr["CanNang"]);
                this.matphai.Text = dr["TLMP"] + "";
                this.matrai.Text = dr["TLMT"] + "";
                this.mumau.Text = dr["MuMau"] + "";
                this.drNhomMau.SelectedValue = dr["Blood"] + "";
                this.taythuan.SelectedValue = dr["TayThuan"] + "";
                this.suckhoe.Text = dr["TTSK"] + "";
                this.tiensubenh.Text = dr["TSBenh"] + "";

                /// gia dinh
                string sql2 = " SELECT gt.TenDM,DTGDID, MTUVID, QHe, HoTen, NamSinh, CVHienTai, DiaChi   FROM [HMI].[dbo].[DTGiaDinh] gd LEFT JOIN DMDanhMuc gt ON gt.MaDM=gd.QHe WHERE MTUVID='" + value + "' ORDER BY gd.QHe asc";
                DataTable tbGiaDinh = Class.LinQConnection.getDataTable(sql2);
                grvGiaDinh.DataSource = tbGiaDinh;
                grvGiaDinh.DataBind();
                // hoc van
                sql2 = " SELECT CONVERT(varchar(50),[TuThang],103) as [TuThang], CONVERT(varchar(50),[DenThang],103) as [DenThang],gt.TenDM as [TruongHoc],CASE WHEN [IsTN]=1 THEN 'TN' ELSE N'Chưa' END AS TT,kh.TenDM as [KhoaID],[Ghichu] ";
                sql2 += " FROM [HMI].[dbo].[DTHocVan] hv LEFT JOIN DMDanhMuc gt ON gt.MaDM=hv.TruongHoc   LEFT JOIN DMDanhMuc kh ON kh.MaDM=hv.KhoaID WHERE MTUVID='" + value + "' ORDER BY TuThang ASC ";
                DataTable tbHV = Class.LinQConnection.getDataTable(sql2);
                grvHocVan.DataSource = tbHV;
                grvHocVan.DataBind();

                // CHUNG CHI 

                sql2 = "  SELECT CONVERT(varchar(50),[ThangNam],103) as [ThangNam],bc.TenDM as [BangCap],bc.TenDM as [ChuyenNganh]FROM [HMI].[dbo].[DTChungChi] cc ";
                sql2 += "  LEFT JOIN DMDanhMuc bc ON bc.MaDM=cc.BangCap  LEFT JOIN DMDanhMuc cn ON cn.MaDM=cc.ChuyenNganh WHERE MTUVID='" + value + "' ORDER BY [ThangNam] ASC";
                DataTable tbCC = Class.LinQConnection.getDataTable(sql2);
                grvCHUNGCHI.DataSource = tbCC;
                grvCHUNGCHI.DataBind();
                /// KINH NGHIEM LAM VIEC
                /// 
                sql2 = "  SELECT  CONVERT(varchar(50),[TuNgay],103) as [TuThang], CONVERT(varchar(50),DenNgay,103) as [DenThang],pb.TenDM as PhongBan,  vt.TenDM as ViTri,SanPham,CongCu,MoTa,Congty ";
                sql2 += "   FROM [HMI].[dbo].[DTKNLV] hv   LEFT JOIN DMDanhMuc pb ON pb.MaDM=hv.PhongBan   LEFT JOIN DMDanhMuc vt ON vt.MaDM=hv.ViTri WHERE MTUVID='" + value + "' ORDER BY TuNgay ASC   ";
                DataTable tbKN = Class.LinQConnection.getDataTable(sql2);
                grvKinhNghiem.DataSource = tbKN;
                grvKinhNghiem.DataBind();
                ///////////////
                sql2 = "   SELECT [TT],MaKH ,NganhNghe ,MoTa ,[Remark] ,[KetQua]  FROM [HMI].[dbo].[DTPhongVan]  dt,(   ";
                sql2 += " SELECT   [MTPVID] ,[Ngay] ,[MaKH] ,nn.TenDM as [NganhNghe] ,[MoTa] ,[NgayNH]  FROM [HMI].[dbo].[MTPhongVan] pv  ";
                sql2 += " LEFT JOIN DMDanhMuc nn ON nn.MaDM=pv.NganhNghe) as mt  ";
                sql2 += " where dt.MTPVID=mt.MTPVID AND MTUVID='" + value + "' ";
                sql2 += " ORDER BY TT ASC  ";
                DataTable tbPV = Class.LinQConnection.getDataTable(sql2);
                grvPhongVan.DataSource = tbPV;
                grvPhongVan.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.pThongTinCaNhan.Visible = true;
            this.pThongTinKhac.Visible = false;
            this.pXuatQuoc.Visible = false;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.pThongTinCaNhan.Visible = false;
            this.pThongTinKhac.Visible = true;
            this.pXuatQuoc.Visible = false;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.pThongTinCaNhan.Visible = false;
            this.pThongTinKhac.Visible = false;
            this.pXuatQuoc.Visible = true;
        }
    }
}