using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace PMACData
{
    public partial class Form1 : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public Form1()
        {
            InitializeComponent();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;

            timer1.Start();
            getTimeDatabase();
            //string time1 = DateTime.Parse("12:15:00 AM").ToString("T");
            stasusLabel.Text =  DateTime.Now.ToString("T");
        }
        public void getTimeDatabase()
        {
            
            var q = from query in db.t_Channel_Configurations orderby query.TimeStamp descending select query;
            this.lbDatabase.Text = q.First().TimeStamp.Value.ToString("G");

             
        }
      

        public void AppPmac()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if ("iPMAC-TANHOA".Contains(theprocess.ProcessName))
                {
                    this.lbStatus.Text = "Start";
                    break;
                }
                else
                {
                    this.lbStatus.Text = "Stop";
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dongho.Text = DateTime.Now.ToString("G");
            string path = @"C:\PMAC\DATA";
         
            DateTime dt = Directory.GetLastWriteTime(path);
            lbFilePMAC.Text = dt.ToString("G");

            AppPmac();


            DateTime tNow = DateTime.Now;

            if (tNow.Hour % 2 == 0 && tNow.Minute ==40 && tNow.Second == 0)
            {
                stop.PerformClick();
            }

            if (tNow.Hour % 2 == 0 && tNow.Minute == 15 && tNow.Second == 0)
            {
                
                start.PerformClick();

                btCopy.PerformClick();

              //  start.PerformClick();
              //  getTimeDatabase();
                stasusLabel.Text = stasusLabel.Text + "__" + tNow.ToString("T");
            }


            //if (tNow.Minute % 10==0 && tNow.Second == 0 && lbStatus.Text.Equals("Stop"))
            //{
            //    start.PerformClick();
            //}

            if (tNow.Minute % 20 == 0 && tNow.Second == 0)
            {
                getTimeDatabase();
            }        
          if (tNow.Hour == 7 && tNow.Minute == 0 && tNow.Second == 0)
            {
            
              DateTime t = DateTime.Now;
                 UpdateSanLuongDHT(t);
            }
              

            // tieng
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("PmacCopy.bat");
        }

        private void start_Click(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.Start("OFF.BAT");
            System.Diagnostics.Process.Start("ON.BAT");
        }

        private void stop_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("OFF.BAT");
        }

        private void pMacStatus_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public  DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
               // log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }

        public int ExecuteCommand(string sql)
        {
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
               // log.Error("LinQConnection ExecuteCommand : " + sql);
             //   log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public void UpdateSanLuongDHT(DateTime d)
        {
            string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*    FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc ";

            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tbName = "t_Index_Logger_" + table.Rows[i]["ChannelId"];
                string ngay = d.ToString("yyyy-MM-dd") + " 06:00:00:000";
                string maDMA = table.Rows[i]["MaDMA"] + "";

                string SQL = "SELECT Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay + "'";

                DataTable t1 = getDataTable(SQL);

                double csMoi = -1.0;
                if (t1.Rows.Count != 0)
                    try
                    {
                        csMoi = double.Parse(t1.Rows[0][0].ToString());
                    }
                    catch (Exception)
                    {

                    }

                string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 06:00:00:000";

                string SQL2 = "SELECT Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay2 + "'";

                DataTable t2 = getDataTable(SQL2);

                double csCu = -1.0;
                if (t2.Rows.Count != 0)
                    try
                    {
                        csCu = double.Parse(t2.Rows[0][0].ToString());
                    }
                    catch (Exception)
                    {

                    }

                string sqlInsert = "INSERT INTO g_SanLuongDHT VALUES('" + ngay + "','" + maDMA + "'," + Math.Round(csCu) + "," + Math.Round(csMoi) + "," + (Math.Round(csMoi) - Math.Round(csCu)) + ")";
                string sqlUpdate = "UPDATE  g_SanLuongDHT SET [CSCU] = " + Math.Round(csCu) + " ,[CSMOI] = " + Math.Round(csMoi) + ",[TIEUTHU] = " + (Math.Round(csMoi) - Math.Round(csCu)) + " WHERE [TimeStamp]='" + ngay + "' AND [MaDMA]='" + maDMA + "'";
            
                if (ExecuteCommand(sqlInsert) == 0)
                    ExecuteCommand(sqlUpdate);
                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;

            for (int i = 0; i < 400; i++)
            {
                UpdateSanLuongDHT(t);
                t = t.Date.AddDays(-1);
            }
           
        }
    }
}
