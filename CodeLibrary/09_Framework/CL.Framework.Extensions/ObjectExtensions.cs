using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 对象扩展方法
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// 当对象为空时返回空字符串，否则返回字符串形式
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string ToStringOrEmptyString(this object source)
    {
        if (source == null || Convert.IsDBNull(source) || source == DBNull.Value)
        {
            return string.Empty;
        }
        return source.ToString();
    }
}
