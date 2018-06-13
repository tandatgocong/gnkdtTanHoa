using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace GiamNuocWeb.Class
{
    public class OledbConnection
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        //  static string connectionSting = ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFileLyLichDHN"].ConnectionString;

        public static int ExecuteCommand(string connectionSting, string sql)
        {
            int result = 0;
            OleDbConnection objConnection = new OleDbConnection(connectionSting);
            try
            {
                objConnection.Open();
                OleDbCommand objCmd = new OleDbCommand(sql, objConnection);
                result = objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection ExecuteCommand" + ex.Message);
            }
            finally
            {
                objConnection.Close();
            }
            return result;
        }


        public static DataTable getDataTable(string connectionSting, string sql)
        {
            log.Error(connectionSting);
            DataTable table = new DataTable();
            OleDbConnection conn = new OleDbConnection(connectionSting);
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, conn);
                dataAdapter.Fill(table);
            }
            catch (Exception ex)
            {
                log.Error("OleDbConnection getDataTable" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return table;
        }


    }
}
