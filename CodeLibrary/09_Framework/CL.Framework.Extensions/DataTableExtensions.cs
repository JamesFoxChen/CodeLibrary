using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Reflection;
using CL.Framework.Utils;

/// <summary>
/// DataTable扩展方法
/// </summary>
public static class DataTableExtensions
{
    /// <summary>
    /// 获取翻页后的数据
    /// </summary>
    /// <param name="obj"></param>
    public static DataTable GetPagerData(this DataTable obj, int pageIndex, int pageSize)
    {
        if (pageIndex < 1) throw new ArgumentException("pageIndex必须大于等于1");
        if (pageSize < 1) throw new ArgumentException("pageSize必须大于等于1");

        var rtn = obj.AsEnumerable().Skip((pageIndex - 1) * pageSize).Take(pageSize);
        return rtn.CopyToDataTable();
    }

    /// <summary>
    /// 将数据集转换为实体类集合
    /// </summary>
    /// <param name="obj"></param>
    public static List<T> ConvertToEntities<T>(this DataTable obj) where T : new()
    {
        List<T> listModel = new List<T>();

        for (int i = 0; i < obj.Rows.Count; i++)
        {
            T tempModel = new T();
            ReflectionUtil.ConvertDataRowToModel(tempModel, obj, i); //Convert DataRow To Model
            listModel.Add(tempModel);
        }

        return listModel;
    }
}