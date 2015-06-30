using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Reflection;
using CL.Framework.Utils;

/// <summary>
/// DataTable扩展方法
/// </summary>
public static class DataTimeExtensions
{
       #region 时间戳
       public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间
     
       /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(long dateTimeFromXml)
        {
            return BaseTime.AddTicks((dateTimeFromXml + 8 * 60 * 60) * 10000000);
        }
        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromXml(string dateTimeFromXml)
        {
            return GetDateTimeFromXml(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 获取微信DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetWeixinDateTime(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }
        #endregion
    /// <summary>
    /// 获取当前时间（格式为年月日时分秒毫秒）
    /// </summary>
    /// <param name="obj"></param>
    public static string GetCurrentDateTillMillisecond(this DateTime obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        return DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }

    /// <summary>
    /// 获取当前时间（格式为年月日时分秒）
    /// </summary>
    /// <param name="obj"></param>
    public static string GetCurrentDateTillSecond(this DateTime obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        return DateTime.Now.ToString("yyyyMMddHHmmss");
    }

    /// <summary>
    /// 获取当前时间（格式自定义）
    /// </summary>
    /// <param name="obj"></param>
    public static string GetCurrentDateByFormat(this DateTime obj, string format = "yyyyMMddHHmmss")
    {
        if (obj == null)
        {
            throw new ArgumentNullException("obj");
        }
        return DateTime.Now.ToString(format);
    }
}
