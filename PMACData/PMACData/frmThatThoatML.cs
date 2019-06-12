using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMACData
{
    public partial class frmThatThoatML : Form
    {
        public frmThatThoatML()
        {
            InitializeComponent();
        }
        DataBaseDataContext db = new DataBaseDataContext();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand("INSERT INTO g_ThatThoatMangLuoi VALUES (" + KY.Text + "," + NAM.Text + "," + SONGAY.Text + "," + SLXNTDNS.Text + "," + SUCXA.Text + "," + DHTONG.Text + "," + TANHOA.Text + "," + THATTHOAT.Text + "," + TILE.Text + ")");
            MessageBox.Show(this, "Thành Công");
        }
    }
}
