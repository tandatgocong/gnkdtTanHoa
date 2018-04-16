using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMobile.Class;

namespace WebMobile
{
    public partial class mHoanCong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "mHoanCong.aspx";
            if (Session["login"] == null)
            {
                Response.Redirect(@"LogIn.aspx");
            }
            else if (("TOCNTT".Contains(Session["phong"].ToString())))
            {

            }
            else if (!("DTCTB,DTCXL".Contains(Session["phong"].ToString())))
            {
                Response.Redirect(@"zphanquyen.aspx");
            }

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pagLoad();

            if (Request.QueryString["login"] != null)
                Session["login"] = Request.QueryString["login"].ToString();

        }

        public void pagLoad()
        {
            Session["dsBaoBe"] = null;
            //string sql = " SELECT ID, lat, lng,DiaChi, CONVERT(VARCHAR(20),TuNgay,103) AS TuNgay,CONVERT(VARCHAR(20),DenNgay,103) AS DenNgay , TuGio, DenGio, NoiDung, CreateDate, CreateBy, ModifyDate, ModifyBy from KT_DongNuoc where CAST(GETDATE()as date) between TuNgay and DenNgay ";
            string sql = " SELECT v.*,CASE WHEN v.LoaiThucHien  = 1 THEN N'Hoàn Thiện' ELSE N'' END  AS TenLoai, (CAST( (DATEDIFF(mi,TuGio,DenGio)/60) AS VARCHAR)) AS GIO,   CAST(  (DATEDIFF(mi,TuGio,DenGio)%60) AS VARCHAR) as PHUT, ";
            sql += " (CAST((DATEDIFF(mi,NgayBao,DenGio)/60) AS VARCHAR)) AS HGIO,   CAST((DATEDIFF(mi,NgayBao,DenGio)%60) AS VARCHAR) as HPHUT, ";
            sql += " CASE WHEN DATEDIFF(DD,NgayBao,GETDATE())>3  AND NgayThucHien IS NULL THEN 1 ELSE 0 END  AS BETON,CASE WHEN NgayTiepNhan IS NULL THEN 1 ELSE 2 END AS THUCHIEN  from W_BAOBE v WHERE DonViSuaBe='" + Session["phong"] + "'";
            Session["dsBaoBe"] = C_KyThuat.getDataTable(sql);

         

        }
    }
}