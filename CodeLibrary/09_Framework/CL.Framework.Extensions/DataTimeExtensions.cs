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