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
using Microsoft.Reporting.WebForms;

namespace GiamNuocWeb
{
    public partial class pageDBGiaoNhanDMA : System.Web.UI.Page
    {
        public void pagePhanQuyen(string pUser)
        {
           if (Session["role"].ToString().Equals(pUser))
            {
                Panel1.Visible = true;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "pageDBGiaoNhanDMA.aspx";
            pagePhanQuyen("thongbao");
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            LoadDMADoBee();
            PageLoad();
            //RadioButtonList1_SelectedIndexChanged(sender, e);
            NgayBatDau.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        void LoadDMADoBee()
        {
            DataTable table = new DataTable("TONGKETKINHPHI");
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("TenNhom", typeof(string));
            table.Columns.Add("NgayBatDau", typeof(string));
            table.Columns.Add("DMA", typeof(string));
            DataTable tb = Class.LinQConnection.getDataTable("SELECT IdNhom,TenNhom FROM  t_Users WHERE Role='dobe' Order By IdNhom ASC ");
           
            cbNhomDB.DataSource = tb;
            cbNhomDB.DataTextField = "TenNhom";
            cbNhomDB.DataValueField = "IdNhom";
            cbNhomDB.DataBind();

            int i = 1;
            foreach (DataRow item in tb.Rows)
            {
                DataRow myDataRow = table.NewRow();
                myDataRow["STT"] = i;
                myDataRow["TenNhom"] = item["TenNhom"];
                DataTable tb2 = Class.LinQConnection.getDataTable("SELECT TOP (1) [NgayBatDau] ,[DMA] FROM [w_NhomDoDMA]  WHERE IdNhom='" + item["IdNhom"] + "' order by NgayBatDau ");
                try
                {
                    myDataRow["NgayBatDau"] = DateTime.Parse(tb2.Rows[0]["NgayBatDau"]+"").ToString("dd/MM/yyyy");
                    myDataRow["DMA"] = tb2.Rows[0]["DMA"];
                }
                catch (Exception)
                {
                }
                table.Rows.Add(myDataRow);
                i++;
            }

            GridView1.DataSource = table;
            GridView1.DataBind();

        }
        void PageLoad()
        {
            cbMaDMA.DataSource = Class.LinQConnection.getDataTable("SELECT MaDMA FROM  g_LabelDMA ORDER BY MaDMA ASC ");
            cbMaDMA.DataTextField = "MaDMA";
            cbMaDMA.DataValueField = "MaDMA";
            cbMaDMA.DataBind();


        }
        protected void btThen_Click(object sender, EventArgs e)
        {
         
             w_NhomDoDMA nh = new w_NhomDoDMA();
             nh.IdNhom = int.Parse(cbNhomDB.SelectedValue);
             nh.TenNhom = cbNhomDB.SelectedItem.Text;
             nh.NgayBatDau = DateTime.Parse(NgayBatDau.Text);
             nh.DMA = cbMaDMA.SelectedValue;

             try
             {
                 DMADataContext db = new DMADataContext();
                 db.w_NhomDoDMAs.InsertOnSubmit(nh);
                 db.SubmitChanges();

                 lbThanhCong.ForeColor = System.Drawing.Color.Blue;
                 this.lbThanhCong.Text = "Cập nhật nhóm dò bể thành công.";
                 LoadDMADoBee();

             }
             catch (Exception)
             {

                 lbThanhCong.ForeColor = System.Drawing.Color.Red;
                 this.lbThanhCong.Text = "Cập nhật nhóm dò bể  thất bại.";
             }
        }
    }
}