using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Framework.Utils
{
    public class StringUtil
    {
        /// <summary>
        /// 判断请求数据中必填字段是否有空值
        /// 有：返回true 没有：返回false
        /// </summary>
        /// <param name="data">请求字段</param>
        /// <returns></returns>
        public static bool IsRequestDataEmpty(params string[] data)
        {
            foreach (var item in data)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取32位GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGUID()
        {
            return Guid.NewGuid().ToString("N"); //直接返回字符串类型
        }

        /// <summary>
        /// 获取16位GUID
        /// </summary>
        /// <returns></returns>
        public static string GetShortGUID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 获取19位纯数字GUID
        /// </summary>
        /// <returns></returns>
        private long GenerateShortDigitGUID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
