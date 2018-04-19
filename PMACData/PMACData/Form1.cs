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
    }
}
