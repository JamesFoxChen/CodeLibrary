using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Framework.Utils
{
    /// <summary>
    /// 翻页信息实体类
    /// </summary>
    public class PagerEntity
    {
        public PagerEntity()
        {
            this.PageIndex = null;
            this.PageSize = null;
            this.TotalCounts = null;
            this.IsGetAll = null;
        }

        /// <summary>
        ///当前页数
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        ///每页显示数量
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        ///总数量
        /// </summary>
        public int? TotalCounts { get; set; }

        /// <summary>
        ///是否显示所有数据
        /// </summary>
        public bool? IsGetAll { get; set; }
    }
}
