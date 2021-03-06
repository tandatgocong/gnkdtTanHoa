﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiamNuocWeb.DataBase;
using log4net;
using System.Data;
using System.Data.SqlClient;

namespace GiamNuocWeb.Class
{
    public class CApLuc
    {
        static DMADataContext db = new DMADataContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);

        public static DataSet getApLucTheoNgay(string madma, string tNgay, string dNgay)
        {
            dsDma dsemp = new dsDma();
            try
            {

                DataTable tbLuuLuong = dsemp.g_LuuLuongDHT;
                string sql = "SELECT * FROM g_ThongTinDHT WHERE  MaDMA IN (" + madma + ")  AND ChannelCMP IS NOT NULL ";
                DataTable tb = LinQConnection.getDataTable(sql);
                bool f = true;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string ChannelId = tb.Rows[i]["ChannelCMP"].ToString();
                    string _maDMA = tb.Rows[i]["MaDMA"].ToString();

                    string query = " select '" + _maDMA + "' as MaDMA, null AS GIO, convert(date,[TimeStamp],103) as  NGAY, ROUND(AVG(Value),2) as Value  ";
                    query += "  from t_Data_Logger_" + ChannelId + " WHERE convert(date,[TimeStamp],101) BETWEEN CONVERT(datetime,'" + tNgay + "',101) AND CONVERT(datetime,'" + dNgay + "',101)  group by convert(date,[TimeStamp],103) order by [NGAY] desc";


                    //if (f == true)
                    //{
                    SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
                    adapter.Fill(dsemp, "g_LuuLuongDHT");
                    // //    f = false;
                    // }
                    // else {
                    //     DataTable t2 = LinQConnection.getDataTable(query);
                    //     dsemp.Tables["g_LuuLuongDHT"].Merge(t2);
                    // }
                    ////
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return dsemp;
        }

        public static DataSet getApLucTheoGio(string madma, string tNgay, string dNgay)
        {
            dsDma dsemp = new dsDma();
            try
            {

                DataTable tbLuuLuong = dsemp.g_LuuLuongDHT;
                string sql = "SELECT * FROM g_ThongTinDHT WHERE  MaDMA IN (" + madma + ")  AND ChannelCMP IS NOT NULL ";
                DataTable tb = LinQConnection.getDataTable(sql);
                bool f = true;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    string ChannelId = tb.Rows[i]["ChannelCMP"].ToString();
                    string _maDMA = tb.Rows[i]["MaDMA"].ToString();

                    string query = " select '" + _maDMA + "' as MaDMA,convert(int,DATEPART(hour,[TimeStamp])) AS GIO, null as  NGAY, ROUND(AVG(Value),2) as Value  ";
                    query += "  from t_Data_Logger_" + ChannelId + " WHERE convert(date,[TimeStamp],101) BETWEEN CONVERT(datetime,'" + tNgay + "',101) AND CONVERT(datetime,'" + dNgay + "',101)  group by DATEPART(hour,[TimeStamp]) order by convert(int,DATEPART(hour,[TimeStamp])) asc ";


                    //if (f == true)
                    //{
                    SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
                    adapter.Fill(dsemp, "g_LuuLuongDHT");
                    //  f = false;
                    //}
                    //else
                    //{
                    //    DataTable t2 = LinQConnection.getDataTable(query);
                    //    dsemp.Tables["g_LuuLuongDHT"].Merge(t2);
                    //}
                    //
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return dsemp;
        }

    }
}