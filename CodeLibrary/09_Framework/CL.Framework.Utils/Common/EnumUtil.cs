using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace CL.Framework.Utils
{
    public class EnumUtil
    {
        /// <summary>
        /// 数据库操作类型
        /// </summary>
        public enum Enum_DbOprType
        {
            /// <summary>
            /// 查询
            /// </summary>
            Query,
            /// <summary>
            /// 新增
            /// </summary>
            Insert,
            /// <summary>
            /// 修改
            /// </summary>
            Update,
            /// <summary>
            /// 删除
            /// </summary>
            Delete
        }


        /// <summary>
        /// 获取指定枚举的Description信息
        /// </summary>
        /// <param name="e">枚举值(T为枚举类型；e为枚举值）</param>
        /// <returns>获取成功返回描述；获取失败返回空字符串</returns>
        public static string GetEnumDescription<T>(T e)
        {
            FieldInfo fielInfo = e.GetType().GetField(e.ToString());
            if (fielInfo == null) return "";

            object[] attrs = fielInfo.GetCustomAttributes(true);
            if (attrs.Length <= 0)
            {
                return string.Empty;
            }

            DescriptionAttribute desAttr = attrs[0] as DescriptionAttribute;
            return desAttr.Description;

            //MenuTypeEnum enumType = ((MenuTypeEnum)e.CellValue.ToInt());  将枚举值转换为枚举类型，如 1=>EnumUtil.Query
            //e.Cell.Text = EnumHelper.GetEnumDescription<MenuTypeEnum>(enumType);
        }
    }


}
