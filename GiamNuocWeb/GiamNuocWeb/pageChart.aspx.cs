using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GiamNuocWeb.Class;
using GiamNuocWeb.DataBase;

namespace GiamNuocWeb
{
    public partial class pageChart : System.Web.UI.Page
    {
       static  g_ThongTinDHT gTg;
        protected void Page_Load(object sender, EventArgs e)
        {

            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            string value = Request.Params["value"].ToString();
            gTg = CThongTinDMA.getDHTByMaDMA(value);
            title.Text ="DMA "+ gTg.MaDMA;
            tTuNgay.Text = DateTime.Today.ToString("yyyy-MM-dd");
            getLuuLuong();

        }
        public void getLuuLuong()
        {
            if (gTg != null)
            {
                string date_ = tTuNgay.Text;
                try
                {
                    DateTime.Parse(tTuNgay.Text);


                }
                catch (Exception)
                {
                    date_ = DateTime.Now.ToString("MM/dd/yyyy");
                }

                string title = "['GIỜ','m3h']";

                string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),5) AS GIO,Value FROM dbo.t_Data_Logger_" + gTg.ChannelId + " WHERE convert(date,[TimeStamp],101) =CONVERT(datetime,'" + date_ + "',101) ORDER BY  [TimeStamp] DESC ";
                DataTable table = LinQConnection.getDataTable(sl);

                for (int i = 0; i < table.Rows.Count; i++)
                {


                    //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                    title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
                }

                Session["sanluong"] = title;

            }
        }

        public void getInlet()
        {
            if (gTg != null)
            {
                string date_ = tTuNgay.Text;
                try
                {
                    DateTime.Parse(tTuNgay.Text);


                }
                catch (Exception)
                {
                    date_ = DateTime.Now.ToString("MM/dd/yyyy");
                }

                string title = "['GIỜ','kg']";

                string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),5) AS GIO,Value/10 as Value  FROM dbo.t_Data_Logger_" + gTg.ChannelIn + " WHERE convert(date,[TimeStamp],101) =CONVERT(datetime,'" + date_ + "',101) ORDER BY  [TimeStamp] DESC ";
                DataTable table = LinQConnection.getDataTable(sl);

                for (int i = 0; i < table.Rows.Count; i++)
                {


                    //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                    title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
                }

                Session["sanluong"] = title;

            }
        }

        public void getOutlet()
        {
            if (gTg != null)
            {
                string date_ = tTuNgay.Text;
                try
                {
                    DateTime.Parse(tTuNgay.Text);


                }
                catch (Exception)
                {
                    date_ = DateTime.Now.ToString("MM/dd/yyyy");
                }

                string title = "['GIỜ','kg']";

                string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),5) AS GIO,Value/10 as Value FROM dbo.t_Data_Logger_" + gTg.ChannelOut + " WHERE convert(date,[TimeStamp],101) =CONVERT(datetime,'" + date_ + "',101) ORDER BY  [TimeStamp] DESC ";
                DataTable table = LinQConnection.getDataTable(sl);

                for (int i = 0; i < table.Rows.Count; i++)
                {


                    //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                    title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
                }

                Session["sanluong"] = title;

            }
        }

        public void getCMP()
        {
            if (gTg != null)
            {
                string date_ = tTuNgay.Text;
                try
                {
                    DateTime.Parse(tTuNgay.Text);


                }
                catch (Exception)
                {
                    date_ = DateTime.Now.ToString("MM/dd/yyyy");
                }

                string title = "['GIỜ','kg']";

                string sl = "SELECT  LEFT(CAST(convert(time,[TimeStamp]) AS VARCHAR),5) AS GIO,Value/10 as Value FROM dbo.t_Data_Logger_" + gTg.ChannelCMP + " WHERE convert(date,[TimeStamp],101) =CONVERT(datetime,'" + date_ + "',101) ORDER BY  [TimeStamp] DESC ";
                DataTable table = LinQConnection.getDataTable(sl);

                for (int i = 0; i < table.Rows.Count; i++)
                {


                    //title += "['" + f + "'" + ", " + table.Rows[i]["TIEUTHU"].ToString() + "],";
                    title += ", ['" + table.Rows[i]["GIO"].ToString() + "'," + table.Rows[i]["Value"].ToString() + "]";
                }

                Session["sanluong"] = title;

            }
        }



        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1")
            { getLuuLuong(); }
            if (RadioButtonList1.SelectedValue == "2")
            { getInlet(); }
            if (RadioButtonList1.SelectedValue == "3")
            { getOutlet(); }
            if (RadioButtonList1.SelectedValue == "4")
            { getCMP(); }
        }
    }
}