using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using System.Configuration;

namespace GiamNuocWeb
{
    public partial class pageDoBeUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            Load();
           
        }
        public void Load()
        {
          
            tTuNgay.Text = DateTime.Today.ToString("yyyy-MM-dd");

            string connectionString = ConfigurationManager.ConnectionStrings["Database2_beConnectionString"].ConnectionString;

            string sql = " SELECT db.ID, nb.TenNHom, db.NgayDo, db.NgaySua, db.SoNha, db.Duong, dma.DMA, db.TinhTrang, db.LoaiDiemBe, db.OngBe, db.DVTC, db.NguyenNhan, db.GhiChu ";
            sql += " FROM T_DiemBe AS db, T_NhomDoBe AS nb, T_DMA AS dma ";
            sql += " WHERE db.Nhom= nb.ID AND db.DMA=dma.ID AND ";
            sql += "  db.TinhTrang=2 ";
            sql += " Order by db.Duong ASC";
            DataTable tb = OledbConnection.getDataTable(connectionString, sql);

            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ////ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpTongKeDiemBe.rdlc");
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpDiemBeChuaSua.rdlc");
            DataTable dtTable = tb;
            GridView1.DataSource = tb;
            GridView1.DataBind();
            //  ReportParameter p1 = new ReportParameter("tuNgay", "LƯU LƯỢNG TRUNG BÌNH (m3h)  ĐỒNG HỒ TỔNG DMA NGÀY " + DateTime.Parse(tn).ToString("dd/MM/yyyy"));
            //  this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            // 
            ////  dtTable.DefaultView.Sort = "STT ASC";

            //ReportDataSource rds = new ReportDataSource("v_DiemBe", dtTable);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(rds);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Database2_beConnectionString"].ConnectionString;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("CheckBox1");
                if (chkbox.Checked == true)
                {
                    Label id_ = (Label)row.FindControl("Label1");
                    //lblResult.Text = lblResult.Text +" "+ row.Cells[2].Text;

                    string sql = " UPDATE T_DiemBe SET TinhTrang ='1', NgaySua='" + tTuNgay.Text + "' WHERE ID='" + id_.Text + "'";
                    OledbConnection.ExecuteCommand(connectionString, sql);
                }
            }
            Load();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database2_beConnectionString"].ConnectionString;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("CheckBox1");
                if (chkbox.Checked == true)
                {
                    Label id_ = (Label)row.FindControl("Label1");
                    //lblResult.Text = lblResult.Text +" "+ row.Cells[2].Text;

                    string sql = " UPDATE T_DiemBe SET TinhTrang ='3', NgaySua='" + tTuNgay.Text + "'  WHERE ID='" + id_.Text + "'";
                    OledbConnection.ExecuteCommand(connectionString, sql);
                }
            }
            Load();
        } 
    }
}