using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Framework.Utils
{
    public class DateTimeUtil
    {
        /// <summary>
        /// 获取当前时间（格式为年月日时分秒毫秒）
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDateTillMillisecond()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 获取当前时间（格式为年月日时分秒）
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDateTillSecond()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
