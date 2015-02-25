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


     
    }

}
