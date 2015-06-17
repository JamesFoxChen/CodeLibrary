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

//字符串转换成枚举值
   public static RequestMsgType GetRequestMsgType(string str)
        {
            return (RequestMsgType)Enum.Parse(typeof(RequestMsgType), str, true);
        }
        
//获取枚举描述属性
 public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }


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

}
