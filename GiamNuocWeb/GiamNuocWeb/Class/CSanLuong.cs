using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GiamNuocWeb.DataBase;
using System.Data.SqlClient;

namespace GiamNuocWeb.Class
{
    public class CSanLuong
    {
        static DMADataContext db = new DMADataContext();
        public static dsDma getSanLuong(string madma, string tNgay, string dNgay)
        {
            dsDma dsemp = new dsDma();
            string query = " select convert(date,[TimeStamp],103) as  [TimeStamp], MaDMA, CSCU, CSMOI, TIEUTHU from g_SanLuongDHT  ";
            query += " where convert(date,[TimeStamp],101) BETWEEN CONVERT(datetime,'04/18/2018',101) AND CONVERT(datetime,'04/19/2018',101)  ";
            query += " order by [TimeStamp] asc, MaDMA asc ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(dsemp, "g_SanLuongDHT");
            return dsemp;
        }
    }
}