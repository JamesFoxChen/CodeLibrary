using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CL.Framework.Utils
{
    public class FileUtil
    {
        public static bool DownloadFile(string filePath,string fileName)
        {
            try
            {
                //以字符流的形式下载文件 
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开 
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                System.Web.HttpContext.Current.Response.BinaryWrite(bytes);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
