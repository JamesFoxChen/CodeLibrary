using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;


/// <summary>
/// 字符串扩展方法
/// </summary>
public static class StringExtensions
{

    #region 字符串过滤
    /// <summary>
    /// 字符串类型公共过滤函数(1、去除两边空格 2、过滤sql注入  3、转换成半角)
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string FilterCommon(this string source)
    {
        return source.Trim().FilterSqlInject().ToBanjiao();
    }

    /// <summary>
    /// 字符串类型公共过滤函数(空字符串时返回NULL)
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string FilterCommonAndToNullWhileEmptyOrWhiteSpace(this string source)
    {
        return FilterCommon(source).ToNullWhileEmptyOrWhiteSpace();
    }

    /// <summary>
    /// 专用于数码查询接口请求数据的过滤的扩展方法
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string FilterCommonForServices(this string source)
    {
        return FilterCommon(source);
    }

    /// <summary>
    /// 过滤Sql注入字符串
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string FilterSqlInject(this string source)
    {
        source = Regex.Replace(source, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        source = Regex.Replace(source, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        source = Regex.Replace(source, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        source = Regex.Replace(source, "<([^<>]*)>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        //source = Regex.Replace(source, @"\<(img)[^>]*>|<\/(img)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<(table|tbody|tr|td|th|)[^>]*>|<\/(table|tbody|tr|td|th|)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<(div|blockquote|fieldset|legend)[^>]*>|<\/(div|blockquote|fieldset|legend)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<(font|i|u|h[1-9]|s)[^>]*>|<\/(font|i|u|h[1-9]|s)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<(style|strong)[^>]*>|<\/(style|strong)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<a[^>]*>|<\/a>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<(meta|iframe|frame|span|tbody|layer)[^>]*>|<\/(iframe|frame|meta|span|tbody|layer)>", "", RegexOptions.IgnoreCase);
        //source = Regex.Replace(source, @"\<a[^>]*", "", RegexOptions.IgnoreCase);

        source = Regex.Replace(source, @"\s*(exec|select|drop|alter|exists|union|and|or|xor|order|mid|execute|xp_cmdshell|insert|update|delete|join|declare|char|sp_oacreate|wscript.shell|xp_regwrite|'|;|\|SP\w+)(\s|$)", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        return Regex.Replace(source, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    public static string ToNullWhileEmptyOrWhiteSpace(this string source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return null;
        }
        return source;
    }
    #endregion


    #region Url编解码

    /// <summary>
    /// 文本Url编码
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string UrlEncoding(this string source)
    {
        return HttpUtility.UrlEncode(source);
    }

    /// <summary>
    /// 文本Url解码
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string UrlDecoding(this string source)
    {
        return HttpUtility.UrlDecode(source);
    }
    #endregion


    #region 全半角转换

    /// <summary>
    /// 转全角的函数
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static String ToQuanjiao(this string source)
    {
        // 半角转全角：
        char[] c = source.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 32)
            {
                c[i] = (char)12288;
                continue;
            }
            if (c[i] < 127)
                c[i] = (char)(c[i] + 65248);
        }
        return new String(c);
    }

    /// <summary>
    /// 转半角的函数
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static String ToBanjiao(this string source)
    {
        char[] c = source.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 12288)
            {
                c[i] = (char)32;
                continue;
            }
            if (c[i] > 65280 && c[i] < 65375)
                c[i] = (char)(c[i] - 65248);
        }
        return new String(c);
    }
    #endregion


    #region 其它判断

    /// <summary>
    /// 获得字符串表示字节长度
    /// </summary>
    /// <param name="source">字符串</param>
    /// <returns>长度</returns>
    public static int GetStringByteLength(this string source)
    {
        int len = source.Length;

        if (source == null || len < 1)
        {
            return 0;
        }

        int count = System.Text.Encoding.Default.GetByteCount(source);

        return count;
    }

    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static String Md5Encrypt(this string source)
    {
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(source);
        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString().ToLower();
    }


    /// <summary>
    /// 是否为全数字
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsDigit(this string source)
    {
        if (!string.IsNullOrWhiteSpace(source))
        {
            foreach (var item in source)
            {
                if (item < 48 || item > 57)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    #endregion


    #region 基本类型转换
    #region Int32类型
    /// <summary>
    /// 转换成Int32类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int ToInt32(this string source)
    {
        return Convert.ToInt32(source);
    }

    /// <summary>
    /// 转换成Int32类型，转换失败返回null
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int? ToInt32OrNull(this object source)
    {
        if (source == null) return null;

        int result;
        if (int.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return null;
    }

    /// <summary>
    /// 转换成Int32类型，转换失败返回int.MinValue
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int? ToInt32OrMinValue(this object source)
    {
        if (source == null) return null;

        int result;
        if (int.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return int.MinValue;
    }


    public static bool IsInt32Type(this object source)
    {
        if (source == null) return false;

        int result;
        return int.TryParse(source.ToString(), out result);
    }
    #endregion


    #region long类型

    /// <summary>
    /// 转换成long类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long ToLong(this object source)
    {
        return Convert.ToInt64(source);
    }

    /// <summary>
    /// 转换成long类型，转换失败返回null
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long? ToLongOrNull(this object source)
    {
        if (source == null) return null;

        long result;
        if (long.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return null;
    }

    /// <summary>
    /// 转换成long类型，转换失败返回long.MinValue
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long? ToLongOrMinValue(this object source)
    {
        if (source == null) return null;

        long result;
        if (long.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return long.MinValue;
    }
    #endregion


    #region DateTime类型

    /// <summary>
    /// 字符串转换为DateTime类型（字符串长度规定为8位年月日或14位年月日时分秒）
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeYMRSFM(this object source)
    {
        var str = source.ToString();
        int year = str.Substring(0, 4).ToInt32();
        int month = str.Substring(4, 2).ToInt32();
        int day = str.Substring(6, 2).ToInt32();

        if (str.Length == 8)
        {
            return new DateTime(year, month, day);
        }

        int hour = str.Substring(8, 2).ToInt32();
        int minute = str.Substring(10, 2).ToInt32();
        int second = str.Substring(12, 2).ToInt32();

        return new DateTime(year, month, day, hour, minute, second);
    }

    /// <summary>
    /// 转换成DateTime类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this object source)
    {
        return Convert.ToDateTime(source);
    }

    /// <summary>
    /// 转换成DateTime类型，转换失败返回null
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static DateTime? ToDateTimeOrNull(this object source)
    {
        if (source == null) return null;
        DateTime result;
        if (DateTime.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return null;
    }

    /// <summary>
    /// 转换成Int32类型，转换失败返回int.MinValue
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static DateTime? ToDateTimeMinValue(this object source)
    {
        if (source == null) return null;

        DateTime result;
        if (DateTime.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return DateTime.MinValue;
    }

    /// <summary>
    /// 获取当天的最大时间
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static DateTime? ToMaxOfDay(this object source)
    {
        if (source == null) return null;

        DateTime result;
        if (DateTime.TryParse(source.ToString(), out result))
        {
            return result.AddDays(1).AddSeconds(-1);
        }
        return null;
    }
    #endregion


    #region Decimal类型

    /// <summary>
    /// 转换成Decimal类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Decimal ToDecimal(this object source)
    {
        return Convert.ToDecimal(source);
    }

    /// <summary>
    /// 转换成Decimal类型，转换失败返回null
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Decimal? ToDecimalOrNull(this object source)
    {
        if (source == null) return null;

        Decimal result;
        if (Decimal.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return null;
    }

    #endregion


    #region Boolean类型
    /// <summary>
    /// 转换成Boolean类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Boolean ToBoolean(this object source)
    {
        return Convert.ToBoolean(source);
    }

    /// <summary>
    /// 转换成Boolean类型，转换失败返回null
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static Boolean? ToBooleanOrNull(this object source)
    {
        if (source == null) return null;

        Boolean result;
        if (Boolean.TryParse(source.ToString(), out result))
        {
            return result;
        }
        return null;
    }
    #endregion
    #endregion


    #region 生成GUID
    /// <summary>
    /// 转换成Int32类型，转换失败抛异常
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long GenerateGUID(this string source)
    {
        byte[] value = Guid.NewGuid().ToByteArray();
        return BitConverter.ToInt64(value, 0);
    }

    #endregion
}
