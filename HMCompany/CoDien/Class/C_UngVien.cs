using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebHMI.DB;

namespace WebHMI.Class
{
    public class C_UngVien
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("File");
        static HMIDataContext db = new HMIDataContext();
        //public static  MTUngVien(string ma)
        //{

        //    var q = from p in db.MTUngViens where p.MTUVID == ma select p;
        //    return q.SingleOrDefault();
        //}

        //public static bool Update()
        //{
        //    try
        //    {
        //        db.SubmitChanges();
        //        // db.Refresh(System.Data.Linq.RefreshMode,null);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message);
        //    }
        //    return false;
        //}
    }
}