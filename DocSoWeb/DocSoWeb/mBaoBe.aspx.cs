using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMobile.Class;
using System.Data;

namespace WebMobile
{
    public partial class mBaoBe : System.Web.UI.Page
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

            tungay.Text = Format.NgayVNVN(DateTime.Now.Date);
            denngay.Text = Format.NgayVNVN(DateTime.Now.Date);
            pagLoad();
            Panel2.Visible = false;
        }

        public void pagLoad()
        {
            //DateTime tNgay = DateTime.ParseExact(tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime dNgay = DateTime.ParseExact(denngay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
             string sql = " SELECT v.*,CASE WHEN v.LoaiThucHien  = 1 THEN N'Hoàn Thiện' ELSE N'' END  AS TenLoai, (CAST( (DATEDIFF(mi,TuGio,DenGio)/60) AS VARCHAR)) AS GIO,   CAST(  (DATEDIFF(mi,TuGio,DenGio)%60) AS VARCHAR) as PHUT, ";
            sql += " (CAST((DATEDIFF(mi,NgayBao,DenGio)/60) AS VARCHAR)) AS HGIO,   CAST((DATEDIFF(mi,NgayBao,DenGio)%60) AS VARCHAR) as HPHUT, ";
            sql += "   CASE WHEN DATEDIFF(DD,NgayBao,GETDATE())>3  AND NgayThucHien IS NULL THEN 1 ELSE 0 END  AS BETON,CASE WHEN NgayChuyenSuaBe IS NULL  THEN 3 ELSE CASE WHEN NgayTiepNhan IS NULL THEN 1 ELSE 2  END END AS THUCHIEN  from W_BAOBE v ";
            sql += " WHERE CONVERT(DATE,NgayBao,103) BETWEEN CONVERT(DATE,'" + tungay.Text + "',103) AND CONVERT(DATE,'" + denngay.Text + "',103) ";
            if (Session["cap"].ToString() == "1")
            {
                sql += " AND  CreateBy='" + Session["login"] + "'"; ;
            }
            //string sql = " SELECT * from KT_BaoBe  where CAST(GETDATE() as date) =  CAST(NgayBao as date)  ";

            DataTable tb = C_KyThuat.getDataTable(sql);
            lbTong.Text = "Tổng số " + tb .Rows.Count + " điểm  bể !";
            Session["dsBaoBe"] = tb;
            if (chekHien.Checked == true)
            {
                gChuyen.DataSource = tb;
                gChuyen.DataBind();
            }

            cbDonViSuaBe.DataSource = C_KyThuat.getDataTable("SELECT * FROM KT_DonViSuaBe");
            cbDonViSuaBe.DataValueField = "MaDonVi";
            cbDonViSuaBe.DataTextField = "TenDonVi";
            cbDonViSuaBe.DataBind();
        }

        protected void btXemBangKe_Click(object sender, EventArgs e)
        {
            pagLoad();
        }

        protected void chekHien_CheckedChanged(object sender, EventArgs e)
        {
            if (chekHien.Checked == true)
            {
                Panel2.Visible = true;
                panelChuyen.Visible = false;
                pagLoad();
            }
            else
            {
                panelChuyen.Visible = true;
                Panel2.Visible = false;
            }
        }

        protected void btChuyen_Click(object sender, EventArgs e)
        {
            string listID = "";
            foreach (GridViewRow row in gChuyen.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        Label lbID = (row.Cells[1].FindControl("lbID") as Label);
                        listID += ("'" + lbID.Text + "',");
                    }
                }
            }
            // Label1.Text = listID.Remove(listID.Length - 1, 1);

            string sql = "UPDATE KT_BaoBe SET NguoiGiaoSB='" + Session["login"] + "', SoBangKe='" + this.TextBox1.Text + "', DonViSuaBe='" + cbDonViSuaBe.SelectedValue.ToString() + "',NgayChuyenSuaBe=GETDATE() WHERE ID IN (" + listID.Remove(listID.Length - 1, 1) + ")";
            C_KyThuat.ExecuteCommand(sql);
            pagLoad();
        }


    }
}