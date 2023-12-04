using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PTInTem.Helper
{
    public static class LogHelper
    {
        //Write log file
        public static void WriteLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {

                var url = AppDomain.CurrentDomain.BaseDirectory + @"\Log";
                if (!System.IO.Directory.Exists(url))
                    System.IO.Directory.CreateDirectory(url);
                string fileName = @"\ExceptionLog_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
                FileStream fs = new FileStream(url + fileName, FileMode.OpenOrCreate, FileAccess.Write);

                sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public static void WriteLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
               
                var url = AppDomain.CurrentDomain.BaseDirectory + @"\Log";
                if (!System.IO.Directory.Exists(url))
                    System.IO.Directory.CreateDirectory(url);
                string fileName = @"\" + DateTime.Now.ToString("dd_MM_yyyy") + "Log.txt";
                FileStream fs = new FileStream(url + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public static string GetIDLog()
        {
            Random rnd = new Random();
            var idlog = DateTime.Now.ToString("ddMMyyyyHHmmss") + rnd.Next(0, 999);
            return idlog;
        }
    }
}
