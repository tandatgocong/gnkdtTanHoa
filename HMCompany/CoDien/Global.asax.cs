using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebHMI
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            Application["FCKeditor:UserFilesPath"] = "../Image/Upload";
            log4net.Config.XmlConfigurator.Configure();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["content"] = "";
            Session["page"] = "";
            Session["USER"] = "";
            int count_visit = 0;
 
         //Kiểm tra file count_visit.txt nếu không tồn tại thì
         if(System.IO.File.Exists(Server.MapPath("count_visit.txt")) == false){
             count_visit = 1;
         }
         // Ngược lại thì
         else{
            // Đọc dử liều từ file count_visit.txt
             System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("count_visit.txt"));
             count_visit = int.Parse(read.ReadLine());
             read.Close();
             // Tăng biến count_visit thêm 1
             count_visit ++;
         }
 
         // khóa website
         Application.Lock();
        
         // gán biến Application count_visit
         Application["count_visit"] = count_visit;
        
         // Mở khóa website
         Application.UnLock();
        
       // [color=red] // Lưu dử liệu vào file count_visit.txt
         System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("count_visit.txt"));
         writer.WriteLine(count_visit);
         writer.Close();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
