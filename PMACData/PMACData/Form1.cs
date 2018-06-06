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
using System.Configuration;

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
            stasusLabel.Text = DateTime.Now.ToString("T");
        }
        public void getTimeDatabase()
        {
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.t_Channel_Configurations);
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
            string path2 = @"\\192.168.1.2\c$\PMAC\DATA";

            DateTime dt = Directory.GetLastWriteTime(path);
            lbFilePMAC.Text = dt.ToString("G");

            //DateTime dt2 = Directory.GetLastWriteTime(path2);
            //dt2.ToString("G");
            //if (!lbFilePMAC.Equals(dt2.ToString("G")))
            //{
            //    btCopy.PerformClick();
            //}
            //  lbFilePMAC.Text = dt.ToString("G");


            AppPmac();


            DateTime tNow = DateTime.Now;

            if (tNow.Hour % 2 == 0 && tNow.Minute == 0 && tNow.Second == 0)
            {
                stop.PerformClick();
            }

            if (tNow.Hour % 2 == 0 && tNow.Minute == 15 && tNow.Second == 0)
            {
                // start.PerformClick();
                btCopy.PerformClick();
                btCopyData.PerformClick();

                //  start.PerformClick();
                //  getTimeDatabase();
                stasusLabel.Text = stasusLabel.Text + "__" + tNow.ToString("T");
            }
            if (tNow.Hour % 2 == 0 && tNow.Minute == 20 && tNow.Second == 0)
            {
                start.PerformClick();
            }

            if (tNow.Hour % 2 == 0 && tNow.Minute == 30 && tNow.Second == 0)
            {
                UpdateValue();
                getTimeDatabase();
            }

            //if (tNow.Minute % 10==0 && tNow.Second == 0 && lbStatus.Text.Equals("Stop"))
            //{
            //    start.PerformClick();
            //}

            //if (tNow.Minute % 10 == 0 && tNow.Second == 0)
            //{
            //    getTimeDatabase();
            //}

            if (tNow.Hour == 8 && tNow.Minute == 30 && tNow.Second == 0)
            {
                DateTime t = DateTime.Now;
                UpdateSanLuongDHT(t);
                UpdateSanLuongNRW(t);
                UpdateSanLuongDHN_TM(t);
                UpdateSanLuongDHN_TM_F2(t);
            }

            if (tNow.Hour == 5 && tNow.Minute == 30 && tNow.Second == 0)
            {
                System.Diagnostics.Process.Start("GNKDT.BAT");
            }

            // Update nhom do be 5g sang hang hang
            if (tNow.Hour == 5 && tNow.Minute == 0)
            {

                ThemNhomDoBe();
            }
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
        public DataTable getDataTable(string sql)
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
              //  MessageBox.Show(this, ex.Message);
                // log.Error("LinQConnection ExecuteCommand : " + sql);
                //   log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
           // db.SubmitChanges();
            return result;
        }

        public double ExecuteScalarCommand(string sql)
        {
            double result = 0.0;
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(this, ex.Message);
                // log.Error("LinQConnection ExecuteCommand : " + sql);
                //   log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            // db.SubmitChanges();
            return result;
        }

        public int ExecuteCommand_No(string sql)
        {
            DataBaseDataContext db = new DataBaseDataContext();
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
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(this, ex.Message);
                // log.Error("LinQConnection ExecuteCommand : " + sql);
                //   log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
                 
            }
            // db.SubmitChanges();
            return result;
        }



        public void UpdateSanLuongDHT(DateTime d)
        {
            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*    FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc ";
            string sql = " SELECT *   FROM [tanhoa].[dbo].[g_ThongTinDHT] where STT <= 102 ";

            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tinhtrang = table.Rows[i]["StatusDHT"] + "";
                string cs = table.Rows[i]["TieuThuLoi"] + ""; 

                string tbName = "t_Data_Logger_" + table.Rows[i]["ChannelId"];
                
                string ngay = d.ToString("yyyy-MM-dd") + " 07:00:00:000";
                string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:05:00:000";
                string maDMA = table.Rows[i]["MaDMA"] + "";
                double csCu = 0.0;
                double csMoi = 0.0;

                //string SQL = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay + "'";

                //DataTable t1 = getDataTable(SQL);

               
                //if (t1.Rows.Count != 0)
                //    try
                //    {
                //        csMoi = double.Parse(t1.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }

                //string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:05:00:000";

                //string SQL2 = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay2 + "'";

                //DataTable t2 = getDataTable(SQL2);

                
                //if (t2.Rows.Count != 0)
                //    try
                //    {
                //        csCu = double.Parse(t2.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }
                double tieuthu = 0.0;

                string SQL = "SELECT AVG(Value)*24 AS Value FROM " + tbName + " WHERE [TimeStamp] BETWEEN '" + ngay2 + "' AND '" + ngay + "'";

                tieuthu = ExecuteScalarCommand(SQL);

                if (tinhtrang.Equals("0") || tinhtrang.Equals("") || tinhtrang.Equals("False"))
                    tieuthu = double.Parse(cs);

                string sqlInsert = "INSERT INTO g_SanLuongDHT VALUES('" + ngay + "','" + maDMA + "'," + Math.Round(csCu) + "," + Math.Round(csMoi) + "," + tieuthu + ")";
                string sqlUpdate = "UPDATE  g_SanLuongDHT SET [CSCU] = " + Math.Round(csCu) + " ,[CSMOI] = " + Math.Round(csMoi) + ",[TIEUTHU] = " + tieuthu + " WHERE [TimeStamp]='" + ngay + "' AND [MaDMA]='" + maDMA + "'";

                if (ExecuteCommand(sqlInsert) == 0)
                    ExecuteCommand(sqlUpdate);
                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }
        }

        public void UpdateSanLuongNRW(DateTime d)
        {
           // string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*    FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc ";
            string sql = " SELECT *   FROM [tanhoa].[dbo].[g_ThongTinDHT] where STT <= 102 ";

            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tinhtrang = table.Rows[i]["StatusDHT"] + "";
                string cs = table.Rows[i]["TieuThuLoi"] + ""; 

                string tbName = "t_Data_Logger_" + table.Rows[i]["ChannelId"];
                string ngay = d.ToString("yyyy-MM-dd") + " 04:00:00:000";
                string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:05:00:000";
                string maDMA = table.Rows[i]["MaDMA"] + "";
                double csMoi = 0.0;
                double csCu = 0.0;

                //string SQL = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay + "'";

                //DataTable t1 = getDataTable(SQL);

              
                //if (t1.Rows.Count != 0)
                //    try
                //    {
                //        csMoi = double.Parse(t1.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }


                //string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 23:00:00:000";

                //string SQL2 = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay2 + "'";

                //DataTable t2 = getDataTable(SQL2);

              
                //if (t2.Rows.Count != 0)
                //    try
                //    {
                //        csCu = double.Parse(t2.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }

                double tieuthu = 0.0;

                string SQL = "SELECT AVG(Value)*24 AS Value FROM " + tbName + " WHERE [TimeStamp] BETWEEN '" + ngay2 + "' AND '" + ngay + "'";

                tieuthu = ExecuteScalarCommand(SQL);
               
                if (tinhtrang.Equals("0") || tinhtrang.Equals(""))
                    tieuthu = double.Parse(cs);


                string sqlInsert = "INSERT INTO g_SanLuongNRW VALUES('" + ngay + "','" + maDMA + "'," + Math.Round(csCu) + "," + Math.Round(csMoi) + "," + tieuthu + ")";
                string sqlUpdate = "UPDATE  g_SanLuongNRW SET [CSCU] = " + Math.Round(csCu) + " ,[CSMOI] = " + Math.Round(csMoi) + ",[TIEUTHU] = " + tieuthu + " WHERE [TimeStamp]='" + ngay + "' AND [MaDMA]='" + maDMA + "'";

                if (ExecuteCommand(sqlInsert) == 0)
                    ExecuteCommand(sqlUpdate);
                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }
        }


        public void UpdateSanLuongDHN_TM(DateTime d)
        {
            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*    FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc ";
            string sql = " SELECT *   FROM [tanhoa].[dbo].[g_ThongTinDHTM]  ";

            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string channel = table.Rows[i]["ChannelFlow1"].ToString();
                string tbName = "t_Data_Logger_" + channel;
                string ngay = d.ToString("yyyy-MM-dd") + " 07:00:00:000";
                string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:05:00:000";
                string maDMA = table.Rows[i]["MaDH"] + "";
                string stt = table.Rows[i]["STT"] + "";
                double csMoi = 0.0;
                double csCu = 0.0;
               
                //if(channel.Length==8)
                //    ngay = d.ToString("yyyy-MM-dd") + " 07:05:00:000";
               

                //string SQL = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay + "'";

                //DataTable t1 = getDataTable(SQL);

                //double csMoi = 0.0;
                //if (t1.Rows.Count != 0)
                //    try
                //    {
                //        csMoi = double.Parse(t1.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }

                
                //string SQL2 = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay2 + "'";

                //DataTable t2 = getDataTable(SQL2);

                //
                //if (t2.Rows.Count != 0)
                //    try
                //    {
                //        csCu = double.Parse(t2.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }
                double tieuthu = csMoi - csCu;
                //if (csMoi == 0.0)
                //    tieuthu = 0;

                string SQL = "SELECT AVG(Value)*24 AS Value FROM " + tbName + " WHERE [TimeStamp] BETWEEN '" + ngay2 + "' AND '" + ngay + "'";
                
                tieuthu = ExecuteScalarCommand(SQL);
                //DataTable t1 = getDataTable(SQL);


                if (maDMA.Equals("pt2027") || maDMA.Equals("pt2032") || maDMA.Equals("th2001") || maDMA.Equals("th2003"))
                {
                    tieuthu = tieuthu * (-1);
                }

                string sqlInsert = "INSERT INTO g_SanLuongTM VALUES('" + ngay + "','" + maDMA + "'," + csCu + "," + csMoi + "," + tieuthu + ",NULL,NULL,NULL," + tieuthu + ",0," + stt + ")";
                string sqlUpdate = "UPDATE  g_SanLuongTM SET [CSCU] = " + csCu + " ,[CSMOI] = " + csMoi + ",[TIEUTHU] = " + tieuthu + ",TONGTT= " + tieuthu + " WHERE [TimeStamp]='" + ngay + "' AND [MaDH]='" + maDMA + "'";

                if (ExecuteCommand(sqlInsert) == 0)
                    ExecuteCommand(sqlUpdate);
                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }
        }


        public void UpdateSanLuongDHN_TM_F2(DateTime d)
        {
            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*    FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc ";
            string sql = " SELECT *   FROM [tanhoa].[dbo].[g_ThongTinDHTM]  ";
            string ngay = d.ToString("yyyy-MM-dd") + " 07:00:00:000";
            string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:05:00:000";
            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
               // string tbName = "t_Index_Logger_" + table.Rows[i]["ChannelFlow2"];
                string maDMA = table.Rows[i]["MaDH"] + "";
                string channel = table.Rows[i]["ChannelFlow2"].ToString();
                string tbName = "t_Data_Logger_" + channel;
                //string ngay = d.ToString("yyyy-MM-dd") + " 07:05:00:000";
                //string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:00:00:000";
              //  string maDMA = table.Rows[i]["MaDH"] + "";
                string stt = table.Rows[i]["STT"] + "";
                double csMoi = 0.0;
                double csCu = 0.0;

                //string SQL = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay + "'";
                //DataTable t1 = getDataTable(SQL);
                //double csMoi = 0.0;
                //if (t1.Rows.Count != 0)
                //    try
                //    {
                //        csMoi = double.Parse(t1.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }
                //string SQL2 = "SELECT ROUND(Value,0) AS Value FROM " + tbName + " WHERE [TimeStamp]='" + ngay2 + "'";

                //DataTable t2 = getDataTable(SQL2);

                //double csCu = 0.0;
                //if (t2.Rows.Count != 0)
                //    try
                //    {
                //        csCu = double.Parse(t2.Rows[0][0].ToString());
                //    }
                //    catch (Exception)
                //    {

                //    }
          
                double tieuthu = csMoi - csCu;
                //if (csMoi == 0.0)
                //    tieuthu = 0;

                string SQL = "SELECT AVG(Value)*24 AS Value FROM " + tbName + " WHERE [TimeStamp] BETWEEN '" + ngay2 + "' AND '" + ngay + "'";

                tieuthu = ExecuteScalarCommand(SQL);



                if (maDMA.Equals("pt2027") ||maDMA.Equals("pt2032") ||maDMA.Equals("th2001") ||maDMA.Equals("th2003") )
                {
                    tieuthu = tieuthu * (-1);
                }
                //string sqlInsert = "INSERT INTO g_SanLuongTM VALUES('" + ngay + "','" + maDMA + "'," + Math.Round(csCu) + "," + Math.Round(csMoi) + "," + (Math.Round(csMoi) - Math.Round(csCu)) + ",0.0)";
                string sqlUpdate = "UPDATE  g_SanLuongTM SET [CSCUF2] = " + csCu + " ,[CSMOIF2] = " + csMoi + ",[TIEUTHUF2] = " + tieuthu + " WHERE [TimeStamp]='" + ngay + "' AND [MaDH]='" + maDMA + "'";

                // if (ExecuteCommand(sqlInsert) == 0)
                ExecuteCommand(sqlUpdate);

                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }

            string sqlUpdate2 = " UPDATE [tanhoa].[dbo].[g_SanLuongTM] SET TONGTT= TIEUTHU+(-TIEUTHUF2) WHERE TIEUTHU <> TIEUTHUF2 AND [TimeStamp]='" + ngay + "'";
            ExecuteCommand_No(sqlUpdate2);

            string sqlUpdate3 = "UPDATE [tanhoa].[dbo].[g_SanLuongTM] SET TANGGIAM=(TONGTT-T2.Tt) FROM (SELECT maDH, TONGTT AS Tt FROM  g_SanLuongTM where [TimeStamp] ='" + (d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:00:00:000") + "' )  as T2   where g_SanLuongTM.MaDH=T2.maDH AND [TimeStamp] ='" + ngay + "' ";
            ExecuteCommand_No(sqlUpdate3);

            string sqlUpdate5 = "  UPDATE [tanhoa].[dbo].[g_SanLuongTM] SET TONGTT= T1.TT,TANGGIAM=0 FROM (select  MaDH, [avg] as TT from g_ThongTinDHTM where TrungBinh='True') AS T1 WHERE g_SanLuongTM.MaDH=T1.MaDH AND [TimeStamp]='" + ngay + "' ";

            ExecuteCommand_No(sqlUpdate5);

        }

        public void ExecuteStoredProcedure(DateTime d)
        {
            string ngay = d.ToString("yyyy-MM-dd") + " 07:00:00:000";
            string ngay2 = d.AddDays(-1.0).ToString("yyyy-MM-dd") + " 07:00:00:000";
            DataBaseDataContext db = new DataBaseDataContext();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE_TANGGIAM", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _ky = cmd.Parameters.Add("@D1", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ngay;

                SqlParameter _nam = cmd.Parameters.Add("@D2", SqlDbType.VarChar);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = ngay2;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btCopyData_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("pmacServer.bat");
        }

        private void btSanLuong_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;

            for (int i = 0; i < 30; i++)
            {
                UpdateSanLuongNRW(t);
                //UpdateSanLuongDHT(t);
                 t = t.Date.AddDays(-1);
            }
        }

        public void UpdateValue()
        {
            string sql = " SELECT  * FROM g_ThongTinDHT ";

            //string sql = " SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA,*  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE ChannelId='20238_02'  order by MaDMA";
            DataTable table = getDataTable(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tbName = "t_Data_Logger_" + table.Rows[i]["ChannelId"];
                string tbCMP = "t_Data_Logger_" + table.Rows[i]["ChannelCMP"];
                string tbALOut = "t_Data_Logger_" + table.Rows[i]["ChannelOut"];
                string maDMA = table.Rows[i]["MaDMA"] + "";
                
                string sqlUpdate = "UPDATE dbo.g_ThongTinDHT SET vLuuLuong=T1.Value ";
                sqlUpdate += " FROM ( ";
                sqlUpdate += " SELECT  TOP(1) Value FROM " + tbName + " ORDER BY [TimeStamp] DESC ";
                sqlUpdate += " ) AS T1 ";
                sqlUpdate += " WHERE [MaDMA]='" + maDMA + "'";

                ExecuteCommand(sqlUpdate);

                //if (maDMA == "06-02")
                //{
                //    sqlUpdate = "UPDATE dbo.g_ThongTinDHT SET vCMP=T1.Value ";
                //}

                sqlUpdate = "UPDATE dbo.g_ThongTinDHT SET vCMP=T1.Value ";
                sqlUpdate += " FROM ( ";
                sqlUpdate += " SELECT  TOP(1) Value/10 as Value FROM " + tbCMP + " ORDER BY [TimeStamp] DESC ";
                sqlUpdate += " ) AS T1 ";
                sqlUpdate += " WHERE [MaDMA]='" + maDMA + "'";
                ExecuteCommand(sqlUpdate);

                sqlUpdate = "UPDATE dbo.g_ThongTinDHT SET vApOut=T1.Value ";
                sqlUpdate += " FROM ( ";
                sqlUpdate += " SELECT  TOP(1) Value/10 as Value FROM " + tbALOut + " ORDER BY [TimeStamp] DESC ";
                sqlUpdate += " ) AS T1 ";
                sqlUpdate += " WHERE [MaDMA]='" + maDMA + "'";
                ExecuteCommand(sqlUpdate);


                //listBox1.Items.Add(maDMA + "__" + Math.Round(csCu) + "___" + Math.Round(csMoi));
            }
        }
        private void btupdateVa_Click(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void btTachMang_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            t= t.Date.AddDays(-20);

            for (int i = 0; i < 21; i++)
            {
                UpdateSanLuongDHN_TM(t);
                UpdateSanLuongDHN_TM_F2(t);
                //ExecuteStoredProcedure(t);
                t = t.Date.AddDays(1);
            }
         
        }

        private void btDoBe_Click(object sender, EventArgs e)
        {
            ThemNhomDoBe();
        }


        public void ThemNhomDoBe()
        {
            ExecuteCommand("UPDATE g_LabelDMA SET NhomDoBe='', IDNhom=''  ");
            ExecuteCommand("DELETE FROM  g_NhomDoBe ");
          
            ExecuteCommand("INSERT INTO g_NhomDoBe VALUES (0,N'Tất cả',N' ',N'  ') ");

            string connectionString = ConfigurationManager.ConnectionStrings["Database1_beConnectionString"].ConnectionString;
            string sql = "SELECT * FROM T_NhomDoBe WHERE TinhTrang=True ";
            DataTable tb = OledbConnection.getDataTable(connectionString, sql);

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string id = tb.Rows[i]["ID"].ToString();
                string tennhom = tb.Rows[i]["TenNhom"].ToString();
                string _A = tb.Rows[i]["A"].ToString();
                string _B = tb.Rows[i]["B"].ToString();

                ExecuteCommand("INSERT INTO g_NhomDoBe VALUES (" + id + ",N'" + tennhom + "',N'" + _A + "',N'" + _B + "') ");
                try
                {
                    string sql2 = "SELECT t2.DMA FROM T_DMADoBe t1,T_DMA t2 WHERE t1.DMA= t2.ID AND Nhom=" + id + " ORDER BY NgayBatDau DESC  ";

                    DataTable tb2 = OledbConnection.getDataTable(connectionString, sql2);


                    ExecuteCommand("UPDATE g_LabelDMA SET IDNhom=" + id + ", NhomDoBe=N'" + tennhom + "' WHERE MaDMA='" + tb2.Rows[0]["DMA"].ToString() + "' ");
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("GNKDT.BAT");
        }
    }
}
