using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GiamNuocWeb.DataBase;
using System.Data.SqlClient;
using log4net;

namespace GiamNuocWeb.Class
{
    public class CSanLuong
    {
        static DMADataContext db = new DMADataContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);

        public static dsDma getSanLuong(string madma, string tNgay, string dNgay)
        {
            dsDma dsemp = new dsDma();
            try
            {
                string query = " select convert(date,[TimeStamp],103) as  [TimeStamp], MaDMA, CSCU, CSMOI, TIEUTHU from g_SanLuongDHT  ";
                query += " where  MaDMA IN (" + madma + ") AND convert(date,[TimeStamp],101) BETWEEN CONVERT(datetime,'" + tNgay + "',101) AND CONVERT(datetime,'" + dNgay + "',101)  ";
                query += " order by [TimeStamp] asc, MaDMA asc ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
                adapter.Fill(dsemp, "g_SanLuongDHT");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return dsemp;
        }
    }
}