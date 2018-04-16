using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMobile.Class;

namespace WebMobile
{
    public partial class mHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            pagLoad();

        }

        public void pagLoad()
        {
            Session["dsBaoBe"] = null;
            //DateTime tNgay = DateTime.ParseExact(tNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime dNgay = DateTime.ParseExact(dN.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //string sql = " SELECT ID, lat, lng,DiaChi, CONVERT(VARCHAR(20),TuNgay,103) AS TuNgay,CONVERT(VARCHAR(20),DenNgay,103) AS DenNgay , TuGio, DenGio, NoiDung, CreateDate, CreateBy, ModifyDate, ModifyBy from KT_DongNuoc where CAST(GETDATE()as date) between TuNgay and DenNgay ";
            string sql = " SELECT v.*,CASE WHEN v.LoaiThucHien  = 1 THEN N'Hoàn Thiện' ELSE N'' END  AS TenLoai, (CAST( (DATEDIFF(mi,TuGio,DenGio)/60) AS VARCHAR)) AS GIO,   CAST(  (DATEDIFF(mi,TuGio,DenGio)%60) AS VARCHAR) as PHUT, ";
            sql += " (CAST((DATEDIFF(mi,NgayBao,DenGio)/60) AS VARCHAR)) AS HGIO,   CAST((DATEDIFF(mi,NgayBao,DenGio)%60) AS VARCHAR) as HPHUT, ";
            sql += "   CASE WHEN DATEDIFF(DD,NgayBao,GETDATE())>3  AND NgayThucHien IS NULL THEN 1 ELSE 0 END  AS BETON,CASE WHEN NgayChuyenSuaBe IS NULL  THEN 3 ELSE CASE WHEN NgayTiepNhan IS NULL THEN 1 ELSE 2  END END AS THUCHIEN  from W_BAOBE v ";
            Session["dsBaoBe"] = C_KyThuat.getDataTable(sql);

        }
    }
}