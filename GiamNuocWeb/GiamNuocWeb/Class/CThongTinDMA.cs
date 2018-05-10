using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GiamNuocWeb.DataBase;
using log4net;

namespace GiamNuocWeb.Class
{
    public class CThongTinDMA
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LinQConnection).Name);
        static DMADataContext db = new DMADataContext();
        public static string getDHTLoi()
        {
            
            DataTable t = LinQConnection.getDataTable("select MaDMA from g_ThongTinDHT WHERE StatusDHT='False' ORDER BY STT ASC");
            string s = "Tổng Số "+t.Rows.Count +" ĐH Lỗi : ";
            for (int i = 0; i < t.Rows.Count; i++)
            {
                s += t.Rows[i]["MaDMA"].ToString() + " ; ";
            }
            return s;
        }

        public static string getCMPLoi()
        {

            DataTable t = LinQConnection.getDataTable("select MaDMA from g_ThongTinDHT WHERE StatusCMP='0' ORDER BY STT ASC");
            string s = "Tổng Số " + t.Rows.Count + " CMP Không hoạt động : ";
            for (int i = 0; i < t.Rows.Count; i++)
            {
                s += t.Rows[i]["MaDMA"].ToString() + " ; ";
            }
            return s;
        }

        public static List<g_ThongTinDHT> getDMAHoatDong()
        {
            var q = from p in db.g_ThongTinDHTs where p.StatusDHT == true orderby p.STT ascending select p;
            return q.ToList();
        }
        public static List<g_ThongTinDHT> getCMPHoatDong()
        {
            var q = from p in db.g_ThongTinDHTs where p.StatusCMP =="1" orderby p.STT ascending select p;
            return q.ToList();
        }

        public static List<g_ThongTinDHT> getThongTinDHT()
        {
            var q = from p in db.g_ThongTinDHTs orderby p.STT ascending select p;
            return q.ToList();
        }

        public static g_ThongTinDHT getDHTByMaDMA(string ma)
        {
            var q = from p in db.g_ThongTinDHTs where p.MaDMA==ma   select p;
            return q.SingleOrDefault();
        }

        public static bool Update()
        {
            try
            {
                db.SubmitChanges();
               // db.Refresh(System.Data.Linq.RefreshMode,null);
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool InsertLichSu(g_GhiChu g)
        {
            try
            {
                db.g_GhiChus.InsertOnSubmit(g);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                
            }
            return false;
        }

    }
}