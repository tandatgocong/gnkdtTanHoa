﻿using System;
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
        static public string loggger = "";
        private static readonly ILog log = LogManager.GetLogger(typeof(CBaoBe).Name);
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
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTs where p.StatusDHT == true orderby p.STT ascending select p;
            return q.ToList();
        }

        public static List<g_ThongTinDHTM> getDongHoTachMang()
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTMs  orderby p.STT ascending select p;
            return q.ToList();
        }

        public static g_ThongTinDHTM getDongHoTachMang(string madh)
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTMs where p.MaDH==madh orderby p.STT ascending select p;
            return q.SingleOrDefault();
        }


        public static List<g_ThongTinDHT> getCMPHoatDong()
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTs where p.StatusCMP == true orderby p.STT ascending select p;
            return q.ToList();
        }

        public static List<g_ThongTinDHT> getThongTinDHT()
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTs orderby p.STT ascending select p;
            return q.ToList();
        }

        public static List<g_LabelDMA> getThongTinDHT_DB()
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_LabelDMAs orderby p.MaDMA ascending select p;
            return q.ToList();
        }
        
        public static g_ThongTinDHT getDHTByMaDMA(string ma)
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.g_ThongTinDHTs where p.MaDMA==ma   select p;
            return q.SingleOrDefault();
        }
    
        public  bool Update()
        {
           
            try
            {
                DMADataContext db = new DMADataContext();
                db.SubmitChanges();
               // db.Refresh(System.Data.Linq.RefreshMode,null);
                return true;
            }
            catch (Exception ex)
            {
                loggger = ex.Message;
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool InsertLichSu(g_GhiChu g)
        {
            try
            {
                DMADataContext db = new DMADataContext();
                db.g_GhiChus.InsertOnSubmit(g);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                loggger = ex.Message;
                log.Error(ex.Message);
                
            }
            return false;
        }
        public static w_Quan getQuan(int maquan)
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.w_Quans where p.MaQuan == maquan select p;
            return q.SingleOrDefault();
        }

        public static w_Phuong getPhuong(int maquan, string maphuong)
        {
            DMADataContext db = new DMADataContext();
            var q = from p in db.w_Phuongs where p.MaQuan == maquan && p.MaPhuong == maphuong select p;
            return q.SingleOrDefault();
        }

    }
}