using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CL.Framework.Utils;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 数据/流转换工具类
    /// </summary>
    public class ParseUtil
    {
        #region 将流数据转换成字符串
        /// <summary>
        /// 将流数据转换成字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string StreamToString(Stream stream)
        {
            string strData = string.Empty;

            try
            {
                byte[] bytes = streamToByteArray(stream);
                strData = Encoding.UTF8.GetString(bytes);               //以字符串表示的流数据
            }
            catch (Exception ex)
            {
                var stackFrame = new System.Diagnostics.StackFrame();
                var methodBase = stackFrame.GetMethod();
                LogTxtUtil.LogException("方法：" + methodBase + "\t异常信息：" + ex.Message + "\t【将流数据转换成字符串】方法发生错误");
            }
            return strData;
        }
        #endregion

        #region 将流数据转换成字节数组
        /// <summary>
        /// 将流数据转换成字节数组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private byte[] streamToByteArray(Stream stream)
        {
            var buffer = new byte[32768];

            byte[] bytesReturn = null;
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    var read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0) //无数据时跳出循环
                    {
                        break;
                    }
                    ms.Write(buffer, 0, read);
                }

                bytesReturn = ms.ToArray();
            }
            stream.Close();

            return bytesReturn;
        }
        #endregion

        #region 将字符串转换成流

        /// <summary>
        /// 将字符串转换成流
        /// </summary>
        /// <returns></returns>
        public Stream StringToStream(string xml)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(xml);
                Stream st = new MemoryStream(buffer);
                st.Flush();
                st.Position = 0;

                return st;
            }
            catch (Exception ex)
            {
                var stackFrame = new System.Diagnostics.StackFrame();
                var methodBase = stackFrame.GetMethod();
                LogTxtUtil.LogException("方法：" + methodBase + "\t异常信息：" + ex.Message + "\t【将字符串转换成流】方法发生错误");
                return null;
            }
        }
        #endregion
    }
}
