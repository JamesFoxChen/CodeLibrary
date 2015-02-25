using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 日志工具类(文本日志)
    /// </summary>
    public class LogTxtUtil
    {

        #region 异常信息写入日志
        /// <summary>
        /// 异常信息写入日志
        /// </summary>
        /// <param name="msg"> </param>
        public static void LogException(string msg)
        {
            //if (!ConfigUtil.IsLog) return;

            //var log = new StringBuilder(msg);
            //try
            //{
            //    string path = ConfigUtil.LogPath;
            //    if (Directory.Exists(path) == false)
            //        Directory.CreateDirectory(path);

            //    string logPath = path + ConfigUtil.LogName;
            //    DeleteIfLarge(logPath);

            //    var write = new StreamWriter(logPath, true);
            //    string logFormation = "[" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "] \r\n" +
            //                          "==> \r\n" +
            //                          log + "\r\n" +
            //                          "===================================================================\r\n";
            //    write.WriteLine(logFormation);
            //    write.Close();
            //    write.Dispose();
            //}
            //catch
            //{
            //}
        }
        #endregion

        #region 如果txt文件过大则删除
        /// <summary>
        /// 如果txt文件过大则删除
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteIfLarge(string path)
        {
            //try
            //{
            //    if (File.Exists(path))
            //    {
            //        var file = new FileInfo(path);
            //        var l = file.Length;
            //        if (l > ConfigUtil.MaxTxtLength)
            //        {
            //            file.Delete();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        #endregion

    }
}
