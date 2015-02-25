using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// 列表扩展类
/// </summary>
public static class ListExtensions
{
    public static bool MultiContains<T>(this List<T> source, params T[] itemArray)
    {
        foreach (var item in itemArray)
        {
            if (source.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    public static List<T> GetPagerResult<T>(this List<T> obj, int pageIndex, int pageSize)
    {
        if (pageIndex < 1) throw new ArgumentException("pageIndex必须大于等于1");
        if (pageSize < 1) throw new ArgumentException("pageSize必须大于等于1");

        return obj.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
    }
}
