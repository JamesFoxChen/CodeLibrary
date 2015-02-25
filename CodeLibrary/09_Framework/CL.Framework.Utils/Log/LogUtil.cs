using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Framework.Utils
{
    public class LogUtil
    {
        public static void LogException(string msg)
        {
            if (ConfigUtil.IsLog)
            {
                try
                {
                    string logPath = ConfigUtil.LogPath;
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                    string path = logPath + ConfigUtil.LogName;
                    LogUtil.deleteIfLarge(path);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("[异常信息]\r\n");
                    stringBuilder.Append("[").Append(DateTime.Now.ToString(CultureInfo.InvariantCulture)).Append("] \r\n").Append("==> \r\n").Append(msg).Append("\r\n").Append("===================================================================\r\n");
                    if (!File.Exists(path))
                    {
                        FileStream fileStream = File.Create(path);
                        fileStream.Close();
                    }
                    StreamReader streamReader = new StreamReader(path);
                    string s = streamReader.ReadToEnd();
                    streamReader.Close();
                    StreamWriter streamWriter = new StreamWriter(path, false);
                    StringReader stringReader = new StringReader(s);
                    streamWriter.WriteLine(stringBuilder);
                    streamWriter.WriteLine(stringReader.ReadToEnd());
                    streamWriter.Close();
                }
                catch
                {
                }
            }
        }
        private static void deleteIfLarge(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    long length = fileInfo.Length;
                    //if (length > ConfigUtil.MaxTxtLength)
                    if (length > 10000000)
                    {
                        fileInfo.Delete();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public static string LogRequestHeader()
        {
            string result = string.Empty;
            //if (ConfigUtil.IsLog)
            //{
            //    StringBuilder stringBuilder = new StringBuilder();
            //    stringBuilder.Append("[请求头]\r\n");
            //    stringBuilder.Append("Accept:").Append(WebOperationContext.Current.IncomingRequest.Accept).Append("\r\n");
            //    if (WebOperationContext.Current.IncomingRequest.Method == "POST")
            //    {
            //        stringBuilder.Append("Content-Length:").Append(WebOperationContext.Current.IncomingRequest.ContentLength).Append("\r\n");
            //    }
            //    stringBuilder.Append("Content-Type:").Append(WebOperationContext.Current.IncomingRequest.ContentType).Append("\r\n");
            //    stringBuilder.Append("Method:").Append(WebOperationContext.Current.IncomingRequest.Method).Append("\r\n");
            //    stringBuilder.Append("UserAgent:").Append(WebOperationContext.Current.IncomingRequest.UserAgent).Append("\r\n");
            //    stringBuilder.Append("RequestUri:").Append(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.OriginalString).Append("\r\n");
            //    result = stringBuilder.ToString();
            //}
            //else
            //{
            //    result = string.Empty;
            //}
            return result;
        }

        public static void LogRequestBody(string header, string requestStr, string data = "")
        {
            if (ConfigUtil.IsLog)
            {
                try
                {
                    StringBuilder stringBuilder = new StringBuilder(header);
                    stringBuilder.Append("\r\n").Append("[请求参数]\r\n").Append(data);
                    stringBuilder.Append("\r\n\r\n").Append("[请求体]\r\n").Append(requestStr);
                    string logPath = ConfigUtil.LogPath;
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                    string path = logPath + ConfigUtil.LogName;
                    LogUtil.deleteIfLarge(path);
                    stringBuilder.Append("[").Append(DateTime.Now.ToString(CultureInfo.InvariantCulture)).Append("] \r\n").Append("===========================================================================================\r\n\r\n\r\n");
                    StreamReader streamReader = new StreamReader(path);
                    string s = streamReader.ReadToEnd();
                    streamReader.Close();
                    StreamWriter streamWriter = new StreamWriter(path, false);
                    StringReader stringReader = new StringReader(s);
                    streamWriter.WriteLine(stringBuilder);
                    streamWriter.WriteLine(stringReader.ReadToEnd());
                    streamWriter.Close();
                }
                catch
                {
                }
            }
        }
    }
}
