using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace CL.Framework.Utils
{
    public class ServicesLogRecorder : ILogRecorder
    {
        public void ProcessLog(SysLogType type, string requestStr, string data, Exception exception)
        {
            //DebugPrint("{0},{1},{2},{3}", type, name, message, exception);

            //var header = LogRequestHeader();
            //LogRequestBody(header, requestStr, data);
        }


        ///// <summary>
        ///// 请求头数据
        ///// </summary>
        //private static string LogRequestHeader()
        //{
        //    if (ConfigUtil.IsLog)
        //    {
        //        var log = new StringBuilder();
        //        log.Append("[Request Header]\r\n");
        //        log.Append("Accept:").Append(WebOperationContext.Current.IncomingRequest.Accept).Append("\r\n");
        //        if (WebOperationContext.Current.IncomingRequest.Method == "POST")
        //        {
        //            log.Append("Content-Length:").Append(WebOperationContext.Current.IncomingRequest.ContentLength).Append("\r\n");
        //        }
        //        log.Append("Content-Type:").Append(WebOperationContext.Current.IncomingRequest.ContentType).Append("\r\n");
        //        log.Append("Method:").Append(WebOperationContext.Current.IncomingRequest.Method).Append("\r\n");
        //        log.Append("UserAgent:").Append(WebOperationContext.Current.IncomingRequest.UserAgent).Append("\r\n");
        //        log.Append("RequestUri:").Append(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.OriginalString).Append("\r\n");

        //        return log.ToString();
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// 请求体数据，并写入文本文件
        /// </summary>
        /// <param name="header"> </param>
        /// <param name="data"></param>
        /// <param name="requestStr"></param>
        private static void LogRequestBody(string header, string requestStr, string data = "")
        {
            //if (ConfigUtil.IsLog)
            //{
            //    var log = new StringBuilder(header);
            //    log.Append("\r\n").Append("[UrlQueryString]\r\n").Append(data);
            //    log.Append("\r\n").Append("[Request Body]\r\n").Append(requestStr);

            //    try
            //    {
            //        string path = ConfigUtil.LogPath;
            //        if (Directory.Exists(path) == false)
            //            Directory.CreateDirectory(path);

            //        var logPath = path + ConfigUtil.LogName;
            //        LogTxtUtil.DeleteIfLarge(logPath);

            //        var write = new StreamWriter(logPath, true);
            //        var logFormation = "[" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "] \r\n" +
            //            "==> \r\n" +
            //            log + "\r\n" +
            //            "===================================================================\r\n";
            //        write.WriteLine(logFormation);
            //        write.Close();
            //        write.Dispose();
            //    }
            //    catch
            //    {
            //    }
            //}
        }
    }
}
