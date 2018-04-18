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

namespace PMACData
{
    public partial class Form1 : Form
    {
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
            DataBaseDataContext db = new DataBaseDataContext();
            var q = from query in db.t_Channel_Configurations orderby query.TimeStamp descending select query;
            this.lbDatabase.Text = q.First().TimeStamp.Value.ToString("G");

             
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //   // System.Diagnostics.Process.Start("OFF.BAT");
        //    Process[] processlist = Process.GetProcesses();
        //    //MessageBox.Show(this, Process.GetProcessesByName("iPMAC-TANHOA.exe").Length +"");
        //    foreach (Process theprocess in processlist)
        //    {
        //       if ("iPMAC-TANHOA".Contains(theprocess.ProcessName))
        //           MessageBox.Show(this, theprocess.ProcessName);
                              
        //    }
            
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"D:\PROJECT\iPmac2SQL\iPMAC-TANHOA.exe");
            string time2 = DateTime.Now.ToString("T");
            MessageBox.Show(this, time2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dongho.Text = DateTime.Now.ToString("G");
            string path = @"C:\PMAC\DATA";
         
            DateTime dt = Directory.GetLastWriteTime(path);
            lbFilePMAC.Text = dt.ToString("G");
            AppPmac();

            //getTimeDatabase();
            //DateTime t = DateTime.Now;
            //MessageBox.Show(this, t.ToString("T") + "__" + t.Hour.ToString() + "__" + t.Minute.ToString() + "__" + t.Second.ToString());
            
            

            DateTime tNow = DateTime.Now;
            if (tNow.Hour % 2 == 0 && tNow.Minute == 15 && tNow.Second == 0)
            {
                btCopy.PerformClick();
                stop.PerformClick();
                start.PerformClick();
                getTimeDatabase();
                stasusLabel.Text = stasusLabel.Text + "__" + tNow.ToString("T");
            }

            
            if (tNow.Hour % 2 == 1 && tNow.Minute == 0 && tNow.Second == 0)
            { 
                getTimeDatabase();
            }
            string timeNow = DateTime.Now.ToString("T");

            string time1 = DateTime.Parse("12:15:00 AM").ToString("T");

            //if (time1.Equals(time2))
            //{
            //    MessageBox.Show(this, "1");
            //    // timer1.Stop();
            //}

            //string time3 = DateTime.Parse("9:37:00 AM").ToString("T");

            //if (time3.Equals(time2))
            //{
            //    MessageBox.Show(this, "2");
            //    // timer1.Stop();
            //}


            //time1 = DateTime.Parse("9:30:00 AM").ToString("t");
            //if (time1.Equals(time2))
            //{
            //    MessageBox.Show(this, "fdsafD");
            //}
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
         

        private void btReset_Click(object sender, EventArgs e)
        {
              
              
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
    }
}
