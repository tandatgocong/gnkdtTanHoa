using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMobile.Class;

namespace WebMobile
{
    public partial class mBaoCao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            tungay.Text = Format.NgayVNVN(DateTime.Now.Date);
            denngay.Text = Format.NgayVNVN(DateTime.Now.Date);
            pageLoad();
        }
        void pageLoad()
        {
            string sql = " SELECT  COUNT(*) TONGCONG, ";
            sql += " COUNT(CASE WHEN LoaiBao=N'Bể Nổi' THEN 1 ELSE NULL END) AS BENOI,  ";
            sql += " COUNT(CASE WHEN LoaiBao=N'Bể Ngầm' THEN 1 ELSE NULL END) AS BENGAM,  ";
            sql += " COUNT(CASE WHEN NgayChuyenSuaBe IS NULL THEN 1 ELSE NULL END) AS CHUAGIAO, ";
            sql += " COUNT(CASE WHEN NgayThucHien IS NOT NULL THEN 1 ELSE NULL END) AS DASUA,  ";
            sql += " COUNT(CASE WHEN NgayThucHien IS NULL AND NgayChuyenSuaBe IS NOT NULL THEN 1 ELSE NULL END) AS CHUASUA,  ";
            sql += " COUNT(CASE WHEN DATEDIFF(DD,NgayBao,GETDATE())>3  AND NgayThucHien IS NULL THEN 1 ELSE NULL END)  AS BETON  ";
            sql += " FROM [KYTHUAT].[dbo].[KT_BaoBe]  ";
            sql += " WHERE CONVERT(DATE,NgayBao,103) BETWEEN CONVERT(DATE,'" + tungay.Text + "',103) AND CONVERT(DATE,'" + denngay.Text + "',103) ";
            DetailsView1.DataSource = Class.C_KyThuat.getDataTable(sql);
            DetailsView1.DataBind();

        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            pageLoad();
        }
    }
}