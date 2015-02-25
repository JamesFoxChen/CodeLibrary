using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 可空类型扩展类
/// </summary>
public static class NullableExtensions
{
    public static string NullToString<T>(this Nullable<T> source) where T : struct
    {
        if (source == null)
        {
            return string.Empty;
        }

        return source.ToString();
    }
}